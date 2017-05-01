using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Alan.ApiDocumentation.Attributes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Alan.ApiDocumentation.Interfaces;
using Alan.ApiDocumentation.Utils;

namespace Alan.ApiDocumentation.Models
{
    public class RawMemberNode
    {
        public const String NODE_VALUE_ATTRIBUTE_NAME = "node-value";
        public String TagName { get; private set; }
        private RawMemberNode()
        {
            this.Attributes = new Dictionary<string, string>();
            this.ChildNodes = new List<RawMemberNode>();
        }
        public IDictionary<String, String> Attributes { get; private set; }

        public IEnumerable<RawMemberNode> ChildNodes { get; private set; }
        public String Value { get; set; }

        private static RawMemberNode ToRawNode(XElement ele)
        {
            if (ele == null) return null;

            var node = new RawMemberNode();
            if (ele.HasAttributes)
                node.Attributes = ele.Attributes().ToDictionary(att => att.Name.LocalName, att => att.Value);
            if (ele.HasElements)
                node.ChildNodes = ele.Elements().Select(child => ToRawNode(child));
            else
                node.Value = ele.Value;
            node.TagName = ele.Name.LocalName;

            return node;
        }

        public static IEnumerable<RawMemberNode> Parse(String xmlPath)
        {
            String xml = File.ReadAllText(xmlPath);
            var xele = XDocument.Parse(xml);
            var members = xele.Root.Element("members");
            IEnumerable<XElement> nodes = members.Elements("member");
            return nodes.Select(ToRawNode);
        }


        public static IEnumerable<TType> Parse<TType, TMethod, TParameter>(
            String xmlPath,
           Func<TType, bool> typeMemberCallback,
            Func<TMethod, bool> methodMemberCallback)
            where TType : IRawTypeMemberNode<TMethod, TParameter>, new()
            where TMethod : IRawMethodMemberNode<TParameter>, new()
            where TParameter : new()
        {
            List<GeneralRawMemberNode> nodes = Parse(xmlPath)
                .Select(GeneralRawMemberNode.Init)
                .ToList();

            var typeNodes = nodes.Where(node => node.IsType())
                .Select(node => new { typeMember = node.ToModel<TType>(), node })
                .ToList();

            List<TType> typeMembers = new List<TType>();

            foreach (var item in typeNodes)
            {
                List<GeneralRawMemberNode> methodNodes = nodes.Where(node => node.IsMethod() && node.GetFullTypeName() == item.node.GetFullTypeName()).ToList();
                List<TMethod> methodMembers = new List<TMethod>();
                foreach (GeneralRawMemberNode methodNode in methodNodes)
                {
                    TMethod method = methodNode.ToModel<TMethod>();
                    var childNodes = methodNode.GetRawNode().ChildNodes.Where(t => t.TagName == method.GetParameterTagName()).ToList();
                    List<TParameter> parameters = childNodes.Select(child => child.ToModel<TParameter>()).ToList();
                    method.SetParameterMembers(parameters);

                    if (methodMemberCallback != null)
                        if (methodMemberCallback(method) == false)
                            continue;
                    methodMembers.Add(method);
                }
                item.typeMember.MethodMembers = methodMembers;

                if (typeMemberCallback != null)
                    if (typeMemberCallback(item.typeMember) == false)
                        continue;

                typeMembers.Add(item.typeMember);
            }

            return typeMembers;
        }


        public static IEnumerable<TType> Parse<TType, TMethod, TParameter>(
            String xmlPath,
           params IApiQueryable[] queryables)
            where TType : IRawTypeMemberNode<TMethod, TParameter>, new()
            where TMethod : IApiMethodMemberNode, IRawMethodMemberNode<TParameter>, new()
            where TParameter : new()
        {
            List<ApiDescriptionEntity> apis = queryables.Select(query => query.GetApis())
                .Aggregate(new List<ApiDescriptionEntity>(), (pre, next) => { pre.AddRange(next); return pre; })
                .ToList();

            return Parse<TType, TMethod, TParameter>(xmlPath: xmlPath,
                typeMemberCallback: typeMember => typeMember.MethodMembers?.Count > 0,
                methodMemberCallback: method =>
                {
                    var api = apis.FirstOrDefault(a => a.MethodId == method.GetNameId());
                    if (api == null) return false;
                    method.SetApiInfo(api);
                    return true;
                });
        }

        public T ToModel<T>(T model)
        {
            var validProperty = from property in typeof(T).GetProperties()
                                let attribute = property.GetCustomAttributes<RawMemberAttribute>(true).FirstOrDefault()
                                where attribute != null && property.CanWrite
                                select new { attribute, property };

            foreach (var pair in validProperty)
            {
                String key = pair.attribute.XmlName;
                String value;
                if (!this.Attributes.TryGetValue(key, out value))
                {
                    var childNode = this.ChildNodes.FirstOrDefault(child => child.TagName == key);
                    value = childNode?.Value;
                }
                if (pair.attribute.XmlName == NODE_VALUE_ATTRIBUTE_NAME)
                    value = this.Value;

                if (value == null) continue;

                value = value.Trim(' ').Trim('\n').Trim(' ');
                object convertedValue = Convert.ChangeType(value, pair.property.PropertyType);
                pair.property.SetValue(model, convertedValue, null);

            }

            return model;
        }


        public T ToModel<T>()
            where T : new()
        {
            return this.ToModel<T>(new T());
        }

    }
}
