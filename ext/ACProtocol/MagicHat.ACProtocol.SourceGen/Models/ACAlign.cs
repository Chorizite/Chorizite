using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagicHat.ACProtocol.SourceGen.Models {
    public class ACAlign : ACBaseModel {

        public string Type { get; set; }

        public ACAlign(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        internal static ACAlign FromXElement(ACBaseModel parent, XElement element) {
            var type = (string)element.Attribute("type");

            return new ACAlign(parent, element) {
                Type = type
            };
        }
    }
}
