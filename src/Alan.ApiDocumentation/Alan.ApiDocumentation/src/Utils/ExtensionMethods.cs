using Alan.ApiDocumentation.Attributes;
using Alan.ApiDocumentation.Models;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Alan.ApiDocumentation.Interfaces;

namespace Alan.ApiDocumentation.Utils
{
    public static class ExtensionMethods
    {
        public static bool HasValidMemberName(this IGeneralRawMemberNode member)
        {
            var name = member.GetXmlMemberName();
            if (String.IsNullOrWhiteSpace(name)) return false;
            if (name.Length <= 2) return false;

            return Regex.IsMatch(member.GetXmlMemberName(), @"^\w:");
        }
        public static char GetNamePrefix(this IGeneralRawMemberNode member)
        {
            if (member.HasValidMemberName())
                return Char.Parse(member.GetXmlMemberName().Substring(0, 1));

            return ' ';
        }
        public static String GetNameId(this IGeneralRawMemberNode member)
        {
            if (!member.HasValidMemberName()) return null;

            var name = member.GetXmlMemberName();
            if (member.IsMethod() && name.IndexOf(')') < 0)
                name += "()";
            return name.Substring(2);
        }
        public static String GetFullName(this IGeneralRawMemberNode member)
        {
            var name = member.GetNameId();
            if (name == null) return null;

            var leftBrackedIndex = name.IndexOf("(");
            if (leftBrackedIndex < 0) return name.Substring(2);
            return name.Substring(2, leftBrackedIndex - 2);
        }

        public static bool IsMethod(this IGeneralRawMemberNode member)
        {
            return member.GetNamePrefix() == 'M';
        }
        public static bool IsType(this IGeneralRawMemberNode member)
        {
            return member.GetNamePrefix() == 'T';
        }
        public static bool IsProperty(this IGeneralRawMemberNode member)
        {
            return member.GetNamePrefix() == 'P';
        }

        public static String GetFullTypeName(this IGeneralRawMemberNode member)
        {
            var fullName = member.GetFullName();
            if (String.IsNullOrWhiteSpace(fullName)) return null;
            if (member.IsType()) return fullName;
            if (member.IsMethod() || member.IsProperty())
            {
                var parts = fullName.Split('.');
                return String.Join(".", parts.Take(parts.Length - 1));
            }
            return null;
        }

        public static String[] GetParamtersTypes(this IGeneralRawMemberNode member)
        {
            var name = member.GetNameId();
            if (name == null) return null;

            if (!member.IsMethod()) return null;
            var leftBracketIndex = name.IndexOf("(");
            if (leftBracketIndex < 0) return new String[0];
            var paramters = name.Substring(leftBracketIndex + 1).TrimEnd(')');
            if (String.IsNullOrWhiteSpace(paramters)) return new String[0];
            return paramters.Split(',');
        }

#if NET40

        /// <summary>
        /// 获取自定义 Attribute(.Net Framework 4.0 版本)
        /// </summary>
        /// <typeparam name="T">自定义的 Attribute</typeparam>
        /// <param name="element">元素</param>
        /// <param name="inherit">是否获取继承得到的 Attribute</param>
        /// <returns></returns>
        public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element, bool inherit)
            where T : Attribute
        {
            IEnumerable<T> query = from attribute in element.GetCustomAttributes(inherit)
                                   let converted = attribute as T
                                   where converted != null
                                   select converted;
            return query;
        }

#endif
    }
}
