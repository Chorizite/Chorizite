using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chorizite.ACProtocol.SourceGen.Models {
    public class ACSubMember : ACBaseModel {
        public string Text { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Shift { get; set; }
        public string And { get; set; }

        public ACSubMember(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        internal static ACSubMember FromXElement(ACBaseModel parent, XElement element) {
            var text = (string)element.Attribute("text");
            var name = (string)element.Attribute("name");
            var type = (string)element.Attribute("type");
            var value = (string)element.Attribute("value");
            var shift = (string)element.Attribute("shift");
            var and = (string)element.Attribute("and");

            return new ACSubMember(parent, element) {
                Name = ACDataMember.FirstCharToUpper(name),
                Text = text,
                Type = type,
                Value = value,
                Shift = shift,
                And = and
            };
        }
    }
}
