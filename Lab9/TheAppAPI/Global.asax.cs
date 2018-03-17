using System.Web.Http;
using TheAppAPI.App_Start;
using System;

namespace TheAppAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\Projects\CST356\Lab9\Lab9\App_Data");
            DependencyInjectionConfig.Register();
        }
    }
}
