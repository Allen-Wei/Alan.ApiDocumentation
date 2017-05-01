using Alan.ApiDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.Interfaces
{
    public interface IApiQueryable
    {
        IEnumerable<ApiDescriptionEntity> GetApis();
    }
}
