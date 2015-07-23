using System;
using System.Web;

namespace Task2.Infostructure
{
    public class CustomHttpModule : IHttpModule
    {
        public CustomHttpModule()
        {
        }

        public String ModuleName
        {
            get { return "CustomHttpModule"; }
        }

        
        public void Init(HttpApplication application)
        {
            application.BeginRequest +=
                (new EventHandler(this.Application_BeginRequest));
            application.EndRequest +=
                (new EventHandler(this.Application_EndRequest));
        }

        private void Application_BeginRequest(Object source,
             EventArgs e)
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(""))
            {
                context.Response.Write("<div><h4><font color=red>" + "Request started at " +
                    DateTime.Now +
                    "</font></h4></div><hr>");
            }
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(""))
            {
                context.Response.Write("<hr><h1><font color=red>" +
                    "End of Request</font></h1>");
            }
        }

        public void Dispose() { }
    }
}