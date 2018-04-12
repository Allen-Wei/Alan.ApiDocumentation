using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Alan.ApiDocumentation.Models;
using Alan.ApiDocumentation.Utils;

namespace Alan.ApiDocumentation.Demonstration
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            RunTest();
        }

        static void RunTest()
        {
            var memebers = RawMemberNode.Parse(@"D:\OpenSource\HsmEdu\HsmEdu.WebApi\App_Data\HsmEdu.WebApi.XML").ToList();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(memebers);
        }
    }
}