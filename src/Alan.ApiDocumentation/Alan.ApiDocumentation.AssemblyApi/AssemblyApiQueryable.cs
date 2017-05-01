using Alan.ApiDocumentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alan.ApiDocumentation.Models;
using System.Reflection;
using Alan.ApiDocumentation.Attributes;
using Alan.ApiDocumentation.Utils;

namespace Alan.ApiDocumentation.AssemblyApi
{
    public class AssemblyApiQueryable : IApiQueryable
    {
        private Assembly assembly;
        public AssemblyApiQueryable(Assembly assembly)
        {
            this.assembly = assembly;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApiDescriptionEntity> GetApis()
        {

            /**
             * 
             * ref: https://msdn.microsoft.com/en-us/library/system.reflection.assembly.definedtypes(v=vs.110).aspx
             * The DefinedTypes property is comparable to the Assembly.GetTypes method, 
             * except that the DefinedTypes property returns a collection of TypeInfo objects, 
             * and the Assembly.GetTypes method returns an array of Type objects. 
             * 
             * */
#if NET40
            var apis = this.assembly.GetTypes()
                .Select(dt => dt.GetMethods().Select(method => new TypeAndMethod
                {
                    TypeValue = dt,
                    MethodValue = method,
                    MethodAttribute = method.GetCustomAttributes<ApiMethodMemberAttribute>(true).FirstOrDefault()
                }))
                .Aggregate(new List<TypeAndMethod>(), (pre, next) =>
                {
                    pre.AddRange(next);
                    return pre;
                })
                .Where(combined => combined.MethodAttribute != null)
                .Select(combined => new ApiDescriptionEntity
                {
                    MethodId = $"{combined.TypeValue.FullName}.{combined.MethodValue.Name}({String.Join(",", combined.MethodValue.GetParameters().Select(para => para.ParameterType.FullName))})",
                    HttpMethod = combined.MethodAttribute.HttpMethod,
                    Url = combined.MethodAttribute.RelativeUrl
                })
                .ToList();
#else
            var apis = this.assembly.DefinedTypes
                .Select(dt => dt.DeclaredMethods.Select(method => new TypeAndMethod
                {
                    TypeValue = dt,
                    MethodValue = method,
                    MethodAttribute = method.GetCustomAttributes<ApiMethodMemberAttribute>(true).FirstOrDefault()
                }))
                .Aggregate(new List<TypeAndMethod>(), (pre, next) =>
                {
                    pre.AddRange(next);
                    return pre;
                })
                .Where(combined => combined.MethodAttribute != null)
                .Select(combined => new ApiDescriptionEntity
                {
                    MethodId = $"{combined.TypeValue.FullName}.{combined.MethodValue.Name}({String.Join(",", combined.MethodValue.GetParameters().Select(para => para.ParameterType.FullName))})",
                    HttpMethod = combined.MethodAttribute.HttpMethod,
                    Url = combined.MethodAttribute.RelativeUrl
                })
                .ToList();
#endif

            return apis;

        }
    }
}
