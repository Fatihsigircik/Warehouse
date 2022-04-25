using System;
using System.Web.Http;

namespace DatabaseServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //var token = JwtManager.GenerateToken("Test", 1000);
        }

        public void Application_BeginRequest()
        {

        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            Response.Headers.Remove("X-Powered-By");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
            Response.Headers["Server"] = "Fatih SIÐIRCIK";
        }
    }
}