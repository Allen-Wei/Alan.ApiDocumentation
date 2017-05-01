using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.Models
{
    public class ApiDescriptionEntity
    {
        public ApiDescriptionEntity(String httpMethod, String url, String methodId, IEnumerable<ApiParaDescEntity> parameters)
        {
            this.HttpMethod = httpMethod;
            this.RelativeUrl = url;
            this.MethodId = methodId;
            this.Parameters = parameters;
        }
        public static ApiDescriptionEntity Init(String httpMethod, String url, String methodId, IEnumerable<ApiParaDescEntity> parameters)
        {
            return new ApiDescriptionEntity(httpMethod, url, methodId, parameters);
        }

        public String HttpMethod { get; set; }
        public String RelativeUrl { get; set; }
        public String MethodId { get; set; }

        public IEnumerable<ApiParaDescEntity> Parameters { get; set; }
    }
}
