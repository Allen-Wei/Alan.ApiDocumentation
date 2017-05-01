using Alan.ApiDocumentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.Interfaces
{
    public interface IRawTypeMemberNode<TMethod, TParameter>
        where TMethod : IRawMethodMemberNode<TParameter>, new()
        where TParameter : new()
    {
        List<TMethod> MethodMembers { get; set; }
    }
}
