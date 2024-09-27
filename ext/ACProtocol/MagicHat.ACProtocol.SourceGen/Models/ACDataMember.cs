using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MagicHat.ACProtocol.SourceGen.Models {
    public class ACDataMember : ACBaseModel {
        public string Name { get; set; } = "";
        public string MemberType { get; set; } = "";
        public string Text { get; set; } = "";
        public string GenericKey { get; set; } = "";
        public string GenericValue { get; set; } = "";
        public string GenericType { get; set; } = "";

        public List<ACSubMember> SubMembers { get; set; } = new List<ACSubMember>();

        public ACDataMember(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        public static ACDataMember FromXElement(ACBaseModel parent, XElement element) {
            var name = (string)element.Attribute("name");
            var memberType = (string)element.Attribute("type");
            var text = (string)element.Attribute("text");
            var genericKey = (string)element.Attribute("genericKey");
            var genericValue = (string)element.Attribute("genericValue");
            var genericType = (string)element.Attribute("genericType");

            var dataMember = new ACDataMember(parent, element) {
                Name = FirstCharToUpper(name),
                Text = text,
                MemberType = memberType,
                GenericKey = genericKey,
                GenericType = genericType,
                GenericValue = genericValue
            };

            var subMemberNodes = element.XPathSelectElements("./subfield");
            foreach (var valueNode in subMemberNodes) {
                dataMember.SubMembers.Add(ACSubMember.FromXElement(dataMember, valueNode));
            }

            return dataMember;
        }
        public static string FirstCharToUpper(string input) {
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
    }
}