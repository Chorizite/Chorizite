
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MagicHat.ACProtocol.SourceGen.Models {
    public class ACDataType : ACBaseModel {
        public string Name { get; set; }
        public string Primitive { get; set; }
        public string ParentType { get; private set; }
        public string BaseType { get; set; }
        public string Param { get; set; }
        public string Text { get; set; }
        public string Size { get; set; }
        public bool IsTemplated { get; set; }

        public ACDataType(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        public static ACDataType FromXElement(ACBaseModel parent, XElement element) {
            var name = (string)element.Attribute("name");
            var primitive = ((string)element.Attribute("primitive"));
            var parentType = ((string)element.Attribute("parent"));
            var baseType = ((string)element.Attribute("baseType"));
            var param = ((string)element.Attribute("param"));
            var text = ((string)element.Attribute("text"));
            var templated = ((string)element.Attribute("templated"));
            var size = ((string)element.Attribute("size"));

            return new ACDataType(parent, element) {
                Name = name,
                Primitive = primitive,
                ParentType = parentType,
                BaseType = baseType,
                Param = param,
                Text = text,
                IsTemplated = !string.IsNullOrWhiteSpace(templated),
                Size = size
            };
        }
    }
}
