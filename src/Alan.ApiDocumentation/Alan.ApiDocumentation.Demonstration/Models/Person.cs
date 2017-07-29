using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alan.ApiDocumentation.Demonstration.Models
{
    /// <summary>
    /// 个人信息
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 名称
        /// </summary>
        public String FirstName { get; set; }
        /// <summary>
        /// 姓氏
        /// </summary>
        public String LastName { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
    }
}