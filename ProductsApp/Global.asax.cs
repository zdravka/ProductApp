using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ProductsApp.App_Start;
using System.Web.Http.WebHost;

namespace ProductsApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}