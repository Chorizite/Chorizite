using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Chorizite.ACProtocol.SourceGen.Models {
    public class ACMask : ACBaseModel {
        public string Value { get; set; }

        public ACMask(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        internal static ACMask FromXElement(ACBaseModel parent, XElement element) {
            var value = (string)element.Attribute("value");

            return new ACMask(parent, element) {
                Value = value
            };
        }
    }
}