using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.Attributes
{
    public class RawMemberAttribute : Attribute
    {
        public String XmlName { get; set; }

        /// <summary>
        /// 实体类属性对应得XML节点或属性名称
        /// </summary>
        /// <param name="xmlName">XML节点名称或属性名称</param>
        public RawMemberAttribute(string xmlName)
        {
            this.XmlName = xmlName;
        }
    }
}
