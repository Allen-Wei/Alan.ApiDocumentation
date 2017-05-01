using Alan.ApiDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.Interfaces
{
    public interface IRawMethodMemberNode<TParameter> : IGeneralRawMemberNode
        where TParameter : new()
    {
        String GetParameterTagName();
        void SetParameterMembers(IEnumerable<TParameter> parameterNodes);
    }
}
