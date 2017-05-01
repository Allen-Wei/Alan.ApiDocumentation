using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.Attributes
{

    /// <summary>
    /// 接口方法信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiMethodMemberAttribute : Attribute
    {
        /// <summary>
        /// 注解接口方法
        /// </summary>
        /// <param name="relativeUrl">API的URL地址</param>
        /// <param name="httpMethod">API的HTTP Method</param>
        public ApiMethodMemberAttribute(String relativeUrl, String httpMethod)
        {
            this.RelativeUrl = relativeUrl;
            this.HttpMethod = httpMethod.ToUpper();
        }
        public String RelativeUrl { get; private set; }
        public String HttpMethod { get; private set; }
    }
}
