using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;
using Alan.ApiDocumentation.WebApi;
using Alan.ApiDocumentation.Models;
using Alan.ApiDocumentation.Demonstration.Models;
using Alan.ApiDocumentation.Attributes;
using System.Web.Routing;
using Alan.ApiDocumentation.Interfaces;
using Alan.ApiDocumentation.AssemblyApi;

namespace Alan.ApiDocumentation.Demonstration.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index action
        /// </summary>
        /// <returns></returns>
        [ApiMethodMember("Home/Index", "GET")]
        [HttpGet]
        public ActionResult Index()
        {
            var xmlPath = HostingEnvironment.MapPath("~/App_Data/Alan.ApiDocumentation.Demonstration.XML");
            IApiQueryable assemblyQuery = new AssemblyApiQueryable(Assembly.GetExecutingAssembly());
            IApiQueryable apiQuery = new WebApiQueryable();
            List<TypeMember<MethodMember<CustomParameterMember>, CustomParameterMember>> typeMembers =
                RawMemberNode.Parse<TypeMember<MethodMember<CustomParameterMember>, CustomParameterMember>, MethodMember<CustomParameterMember>, CustomParameterMember>(xmlPath, assemblyQuery, apiQuery)
                .ToList();
            return Json(typeMembers, JsonRequestBehavior.AllowGet);
        }

        public class TypeAndMethod
        {
            public TypeInfo TypeValue { get; set; }
            public MethodInfo MethodValue { get; set; }
        }

    }
}