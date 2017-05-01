using Alan.ApiDocumentation.Attributes;
using Alan.ApiDocumentation.Interfaces;
using Alan.ApiDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alan.ApiDocumentation.Models
{
    public class ParameterMember : IGeneralRawMemberNode
    {

        [RawMember("name")]
        public String Name {  get; set; }
        [RawMember(RawMemberNode.NODE_VALUE_ATTRIBUTE_NAME)]
        public String Value { get; set; }

        public string GetXmlMemberName()
        {
            return this.Name;
        }
    }
}