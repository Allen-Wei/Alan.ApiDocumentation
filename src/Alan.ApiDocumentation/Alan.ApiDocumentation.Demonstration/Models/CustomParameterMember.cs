using Alan.ApiDocumentation.Attributes;
using Alan.ApiDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alan.ApiDocumentation.Demonstration.Models
{
    public class CustomParameterMember : ParameterMember
    {
        [RawMember("is-required")]
        public bool IsRequired { get; set; }
    }
}