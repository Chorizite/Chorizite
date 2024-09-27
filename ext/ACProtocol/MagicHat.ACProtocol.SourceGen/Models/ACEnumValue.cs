using System;
using System.Xml.Linq;

namespace MagicHat.ACProtocol.SourceGen.Models {
    public class ACEnumValue : ACBaseModel {
        public string Name {
            get {
                var name = (string)Element.Attribute("name");
                return string.IsNullOrWhiteSpace(name) ? "u_" + Value : name;
            }
        }
        public string Value { get => (string)Element.Attribute("value"); }
        public string Text { get => (string)Element.Attribute("text"); }

        public ACEnumValue(ACBaseModel parent, XElement element) : base(parent, element) {

        }
    }
}