using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.Models
{
    public class ApiDescriptionEntity
    {
        public String HttpMethod { get; set; }
        public String Url { get; set; }
        public String MethodId{ get; set; }

        //public List<ApiParamDescriptionEntity> Parameters { get; set; }
    }
}
