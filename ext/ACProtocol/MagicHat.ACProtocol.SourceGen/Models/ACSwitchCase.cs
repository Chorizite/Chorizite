using System.Xml.Linq;

namespace MagicHat.ACProtocol.SourceGen.Models {
    public class ACSwitchCase : ACBaseModel {
        public string Value { get; set; }
        public string Text { get; set; }

        public ACSwitchCase(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        internal static ACSwitchCase FromXElement(ACBaseModel parent, XElement element) {
            var value = (string)element.Attribute("value");
            var text = (string)element.Attribute("text");

            return new ACSwitchCase(parent, element) {
                Value = value,
                Text = text
            };
        }
    }
}