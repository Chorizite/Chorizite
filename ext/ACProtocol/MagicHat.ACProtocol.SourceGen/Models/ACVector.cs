using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MagicHat.ACProtocol.SourceGen.Models {
    public class ACVector : ACBaseModel {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }

        public string TypeDeclaration {
            get {
				var typeDeclaration = "";
				var typeBase = "";
				if (Children.Count == 1) {
					var member = (Children[0] as ACDataMember);
					typeBase = MessagesReader.SimplifyType(member.MemberType);
					if (Parent is ACDataType && (Parent as ACDataType).IsTemplated)
						typeDeclaration = (Parent as ACDataType).BaseType + "<" + typeBase + ">";
					else
						typeDeclaration = "PackableList<" + typeBase + ">";
				}
				else if (Children.Count == 2) {
					var member1 = (Children[0] as ACDataMember);
					var member2 = (Children[1] as ACDataMember);
					if (Parent is ACDataType && (Parent as ACDataType).IsTemplated)
						typeDeclaration = (Parent as ACDataType).BaseType;
					else
						typeDeclaration = "PackableHashTable";
					var keyType = MessagesReader.SimplifyType(member1.MemberType);
					var valueType = MessagesReader.SimplifyType(member2.MemberType);
					typeDeclaration += "<" + keyType + ", " + valueType + ">";
				}
				else {
					// create a new sub type to hold this vector
					typeBase = Name[0].ToString().ToUpper() + string.Join("", Name.TrimEnd(new char[] { 's' }).Skip(1));
					typeBase += "VectorItem";
					typeDeclaration = "PackableList<" + typeBase + ">";
				}
				return typeDeclaration;
			}
        }

        public ACVector(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        public static ACVector FromXElement(ACBaseModel parent, XElement element) {
            return new ACVector(parent, element) {
                Name = ACDataMember.FirstCharToUpper((string)element.Attribute("name")),
                Type = (string)element.Attribute("type"),
                Length = ACDataMember.FirstCharToUpper((string)element.Attribute("length")),
                Text = (string)element.Attribute("text")
            };
        }
    }
}