using System;
using Alan.ApiDocumentation.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alan.ApiDocumentation.Models;
using Alan.ApiDocumentation.Utils;
using Alan.ApiDocumentation.Interfaces;

namespace Alan.ApiDocumentation.Models
{
    public class TypeMember<TMethod, TParameter> : IGeneralRawMemberNode, IRawTypeMemberNode<TMethod, TParameter>
        where TMethod: IRawMethodMemberNode<TParameter>, new()
        where TParameter : new()
    {

        [RawMember("summary")]
        public String Summary { get; set; }

        [RawMember("name")]
        public String Name { private get; set; }


        public List<TMethod> MethodMembers
        {
            get; set;
        }

        public string GetXmlMemberName()
        {
            return this.Name;
        }
    }
}
