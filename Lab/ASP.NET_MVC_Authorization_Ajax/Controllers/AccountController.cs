using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_2.DAL;
using Task_2.DAL.Security;
using Task_2.ViewModels;
using Newtonsoft.Json;
using System.Web.Security;

namespace Task_2.Controllers
{
    public class AccountController : Controller
    {
        DataContext Context = new DataContext();

        [HttpGet]
        public ActionResult LogIn(string username, string returnUrl)
        {
            if (String.IsNullOrEmpty(username))
                return View();
            else
            {
                LoginViewModel lvm = new LoginViewModel();
                lvm.Username = username;
                return View(lvm);
            }
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            string returnUrl = null;

            if (Request.QueryString.AllKeys.Contains("returnUrl"))
                returnUrl = Request.QueryString["returnUrl"];
            else
                returnUrl = Request.UrlReferrer.OriginalString;

            if (ModelState.IsValid)
            {
                var user = Context.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();

                if (user != null)
                {
                    var roles = user.Roles.Select(m => m.RoleName).ToArray();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.UserId;
                    serializeModel.FirstName = user.FirstName;
                    serializeModel.LastName = user.LastName;
                    serializeModel.roles = roles;

                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                             user.Email,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(15),
                             model.RememberMe,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    //FormsAuthentication.RedirectFromLoginPage(user.Email, false);                   
                    if (Request.IsAjaxRequest())
                        return Json(HttpContext.Request.UrlReferrer.ToString());
                    else
                        return Redirect(Request.QueryString.AllKeys.Contains("returnUrl") ? Request.QueryString["returnUrl"] : Request.UrlReferrer.OriginalString);
                }

                ModelState.AddModelError("", "Incorrect username and/or password");

                string url = String.Format("{0}://{1}/{2}?username={3}&returnUrl={4}", Request.UrlReferrer.Scheme, Request.UrlReferrer.Authority, "Account/LogIn", model.Username, returnUrl);

                if (Request.IsAjaxRequest())
                {
                    return Json(url);
                }
                else
                    return Redirect(url);
            }

            string loginUrl = String.Format("{0}://{1}/{2}?returnUrl={3}", Request.UrlReferrer.Scheme, Request.UrlReferrer.Authority, "Account/LogIn", returnUrl);

            if (Request.IsAjaxRequest())
                return Json(loginUrl);
            else
                return Redirect(loginUrl);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            string returnUrl = null;

            if (Request.QueryString.AllKeys.Contains("returnUrl"))
                returnUrl = Request.QueryString["returnUrl"];
            else
                returnUrl = String.Format("{0}://{1}/", Request.UrlReferrer.Scheme, Request.UrlReferrer.Authority);

            string url = String.Format("{0}://{1}/{2}?returnUrl={3}", Request.UrlReferrer.Scheme, Request.UrlReferrer.Authority, "Account/Register", returnUrl);

            if (ModelState.IsValid)
            {
                var user = Context.Users.Where(u => u.Username == model.Username || u.Email == model.Email).FirstOrDefault();

                if (user == null)
                {
                    User newUser = new User
                    { 
                        Username = model.Username, 
                        Email = model.Email, 
                        FirstName =  model.FirstName,
                        Password = model.Password, 
                        IsActive = true, 
                        CreateDate = DateTime.UtcNow, 
                        Roles = new List<Role>() 
                    };

                    Role role = Context.Roles.Where(r => r.RoleName == "User").FirstOrDefault();

                    newUser.Roles.Add(role);

                    //role.Users.Add(newUser);

                    Context.Users.Add(newUser);

                    Context.SaveChanges();

                    if (Request.IsAjaxRequest())
                        return Json(HttpContext.Request.UrlReferrer.ToString());
                    else
                        return Redirect(returnUrl);
                }

                ModelState.AddModelError("", "User with specified username and/or email already exists.");                

                if (Request.IsAjaxRequest())
                {
                    return Json(url);
                }
                else
                    return Redirect(url);
            }
                        
            if (Request.IsAjaxRequest())
                return Json(url);
            else
                return Redirect(url);
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            Uri uri = HttpContext.Request.UrlReferrer;
            FormsAuthentication.SignOut();
            return Redirect(uri.ToString());
        }

    }
}