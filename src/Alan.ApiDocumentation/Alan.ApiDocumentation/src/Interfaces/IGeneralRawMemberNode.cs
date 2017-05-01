using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Alan.ApiDocumentation.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alan.ApiDocumentation.Models;

namespace Alan.ApiDocumentation.Interfaces
{
    public interface IGeneralRawMemberNode
    {
        String GetXmlMemberName();

        //private String _originalName;

        //[XRawMember("name")]
        //public String OriginalName
        //{
        //    get { return this._originalName; }
        //    set
        //    {
        //        if (String.IsNullOrWhiteSpace(value)) return;
        //        /*TODO
        //         * String value = "M:Alan.ApiDocumentation.Demonstration.Api.GenericParameterDemonstrationController.Put(Alan.ApiDocumentation.Demonstration.Api.GenericParameterDemonstrationController.GenericParameter{Alan.ApiDocumentation.Demonstration.Models.Person})";
        //         * Regex.IsMatch(value, @"^\w:([\w_]+\.?)+(\(([\w_]\.,?)*\))?$") //timeout
        //         */
        //        this._originalName = value;
        //    }
        //}
      
    }
}
