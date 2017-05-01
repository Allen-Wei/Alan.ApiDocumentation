using Alan.ApiDocumentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using Alan.ApiDocumentation.Models;

namespace Alan.ApiDocumentation.WebApi
{
    public class WebApiQueryable : IApiQueryable
    {
        public IEnumerable<ApiDescriptionEntity> GetApis()
        {
            var query = from api in System.Web.Http.GlobalConfiguration.Configuration.Services.GetApiExplorer().ApiDescriptions
                        select ApiDescriptionEntity.Init(
                            api.HttpMethod.ToString(),
                            api.RelativePath,
                            $"{api.ActionDescriptor.ControllerDescriptor.ControllerType}.{api.ActionDescriptor.ActionName}({String.Join(",", api.ActionDescriptor.GetParameters().Select(para => para.ParameterType.FullName))})",
                            api.ActionDescriptor.GetParameters().Select(param => ApiParaDescEntity.Init(param.ParameterName, param.ParameterType.FullName))
                        );

            return query;
        }
    }
}
