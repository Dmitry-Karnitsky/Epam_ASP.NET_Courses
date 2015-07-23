using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Task_2.DAL;
using Task_2.DAL.Security;
using Newtonsoft.Json;

namespace Task_2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer<DataContext>(new DataContextInitializer());
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {                
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (DateTime.Compare(authCookie.Expires, DateTime.Now) > 0)
                {
                    authCookie.Expires.AddMinutes(15);
                    
                    CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
                    CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                    newUser.UserId = serializeModel.UserId;
                    newUser.FirstName = serializeModel.FirstName;
                    newUser.LastName = serializeModel.LastName;
                    newUser.roles = serializeModel.roles;

                    HttpContext.Current.User = newUser;
                }
            }
        }

    }
}
