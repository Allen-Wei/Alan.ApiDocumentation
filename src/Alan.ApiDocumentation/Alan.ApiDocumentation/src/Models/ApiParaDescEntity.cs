using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.Models
{
    public class ApiParaDescEntity
    {
        /// <summary>
        /// 实例化接口参数信息
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="type">参数类型</param>
        public ApiParaDescEntity(String name, String type)
        {
            this.ParamName = name;
            this.ParamType = type;
        }
        /// <summary>
        /// 参数名称
        /// </summary>
        public String ParamName { get; private set; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public String ParamType { get; private set; }

        /// <summary>
        /// 实例化接口参数信息
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="type">参数类型</param>
        /// <returns></returns>
        public static ApiParaDescEntity Init(String name, String type)
        {
            return new ApiParaDescEntity(name, type);
        }
    }
}
