using Alan.ApiDocumentation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ApiDocumentation.AssemblyApi
{
    internal class TypeAndMethod
    {
#if NET40
        public Type TypeValue { get; set; }
#else
        public TypeInfo TypeValue { get; set; }
#endif
        public MethodInfo MethodValue { get; set; }
        public ApiMethodMemberAttribute MethodAttribute { get; set; }
    }
}
