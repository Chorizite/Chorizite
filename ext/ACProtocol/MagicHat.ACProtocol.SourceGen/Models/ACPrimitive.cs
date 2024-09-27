using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MagicHat.ACProtocol.SourceGen.Models {
    public class ACPrimitive : ACBaseModel {
        public string Name { get; set; }
        public ushort Size { get; set; }

        public ACPrimitive(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        public static ACPrimitive FromXElement(ACBaseModel parent, XElement element) {
            return new ACPrimitive(parent, element) {
                Name = ACDataMember.FirstCharToUpper((string)element.Attribute("name")),
                Size = Convert.ToUInt16((string)element.Attribute("size")),
            };
        }
    }
}
