﻿using Alan.ApiDocumentation.Attributes;
using Alan.ApiDocumentation.Demonstration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alan.ApiDocumentation.Demonstration.Controllers
{

    /// <summary>
    /// 个人信息
    /// </summary>
    public class PersonController : Controller
    {

        /// <summary>
        /// 获取个人姓名
        /// </summary>
        /// <author>Bill Gates</author>
        /// <param name="id">Person id</param>
        /// <returns>
        /// {
        ///     success: false,
        ///     message: string/错误消息,
        ///     data: {
        ///         Id: int/帖子Id, 
        ///         IsGlobalOnTop: bool/是否全局置顶,  
        ///         IsOnTop: bool/是否分类置顶, 
        ///         PostContent: string/帖子内容
        ///     }
        /// }
        /// </returns>
        [ApiMethodMember("Person/GetFullName", "Get")]
        [HttpGet]
        public ActionResult GetFullName(int id)
        {
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增个人
        /// </summary>
        /// <param name="person">个人信息</param>
        /// <author>Alan Wei</author>
        /// <returns></returns>
        [ApiMethodMember("Person/AddPerosn", "POST")]
        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            return null;
        }
    }
}