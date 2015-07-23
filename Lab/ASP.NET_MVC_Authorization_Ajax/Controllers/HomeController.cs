using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Task_2.Infostructure;

namespace Task_2.Controllers
{
    public class HomeController : Controller
    {
        string pathToFile = null;

        public static List<CommentInfo> comments = new List<CommentInfo>();

        public async Task<ActionResult> Index(PagingInfo pi = null)
        {
            pathToFile = Server.MapPath("~/App_Data/json.json");
            List<Dictionary<string, object>> jsonData = null;           

            jsonData = await JsonHelper.ReadJsonFromFileAndCache(pathToFile, HttpContext.Cache);

            if (pi != null)
            {
                if (!pi.IsDefault)
                {
                    ViewBag.PagingInfo = pi;
                    return View();
                }
            }   

            PagingInfo info = new PagingInfo();
            info.IsDefault = false;
            info.PageSize = 3;
            info.PageCount = Convert.ToInt32(Math.Ceiling((double)(jsonData.Count / info.PageSize)));
            info.CurrentPageIndex = 0;

            ViewBag.PagingInfo = info;

            return View();
        }

        public async Task<List<Dictionary<string, object>>> GetData(PagingInfo info)
        {
            List<Dictionary<string, object>> jsonData = null;

            if (HttpContext.Cache["jsonData"] == null)
            {
                jsonData = await JsonHelper.ReadJsonFromFileAndCache(pathToFile, HttpContext.Cache);
            }
            else
            {
                jsonData = (List<Dictionary<string, object>>)HttpContext.Cache["jsonData"];
            }

            List<Dictionary<string, object>> result = jsonData.Skip(info.CurrentPageIndex * info.PageSize).Take(info.PageSize).ToList();

            return result;
        }

        public async Task<PartialViewResult> GetDataUsingView(PagingInfo info)
        {
            ViewBag.PagingInfo = info;
            return PartialView(await GetData(info));
        }

        public async Task<JsonResult> GetDataUsingJson(PagingInfo info)
        {
            ViewBag.PagingInfo = info;
            return Json(await GetData(info), JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetComments()
        {
            ViewBag.Comments = comments;
            return PartialView();
        }
        
        public ActionResult AddComment(string comment)
        { 
            if (String.IsNullOrEmpty(comment))
                return RedirectToAction("Index");

            CommentInfo ci = AddCommentToList(comment);

            if (Request.IsAjaxRequest())
            {
                return Json(ci);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        private CommentInfo AddCommentToList(string comment)
        {
            string username = null;
            if (!HttpContext.User.Identity.IsAuthenticated)
                username = "Guest";
            else username = HttpContext.User.Identity.Name;
            CommentInfo ci = new CommentInfo(username, Server.HtmlEncode(comment), DateTime.Now);
            comments.Add(ci);
            return ci;
        }

    }
}