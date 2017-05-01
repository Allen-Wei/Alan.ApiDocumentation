using Alan.ApiDocumentation.Attributes;
using Alan.ApiDocumentation.Interfaces;
using Alan.ApiDocumentation.Models;
using Alan.ApiDocumentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.Models
{
    public class MethodMember<TParameter> : IRawMethodMemberNode<TParameter>, IApiMethodMemberNode
        where TParameter : new()
    {

        /// <summary>
        /// 综述
        /// </summary>
        [RawMember("summary")]
        public String Summary { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [RawMember("author")]
        public String Author { get; set; }

        /// <summary>
        /// 返回值
        /// </summary>
        [RawMember("returns")]
        public String Returns { get; set; }

        public List<TParameter> ParameterMembers { get; set; }

        [RawMember("name")]
        public String Name { private get; set; }

        public string GetXmlMemberName()
        {
            return this.Name;
        }

        public virtual string GetParameterTagName()
        {
            return "param";
        }

        public String HttpMethod { get; set; }
        public String RelativeUrl { get; set; }
        public List<ApiParaDescEntity> ParametersInfo { get; set; }
        public void SetParameterMembers(IEnumerable<TParameter> parameterNodes)
        {
            this.ParameterMembers = parameterNodes.ToList();
        }

        public void SetApiInfo(ApiDescriptionEntity api)
        {
            this.HttpMethod = api.HttpMethod;
            this.RelativeUrl = api.RelativeUrl;
            this.ParametersInfo = api.Parameters.ToList();
        }
    }
}
