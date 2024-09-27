using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MagicHat.ACProtocol.SourceGen.Models {
    public class ACMaskMap : ACBaseModel {
        public string Name { get; set; }
        public string Text { get; set; }
        public string XOR { get; set; }
        public List<ACMask> Masks { get; set; } = new List<ACMask>();

        public uint MaskSource {
            get => (uint)Parent.Element.Attribute(Name);
        }

        public ACMaskMap(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        internal static ACMaskMap FromXElement(ACBaseModel parent, XElement element) {
            var name = (string)element.Attribute("name");
            var text = (string)element.Attribute("text");
            var xor = (string)element.Attribute("xor");

            var maskMap = new ACMaskMap(parent, element) {
                Name = ACDataMember.FirstCharToUpper(name),
                Text = text,
                XOR = xor
            };

            var maskNodes = element.XPathSelectElements("./mask");

            foreach (var maskNode in maskNodes) {
                var mask = ACMask.FromXElement(maskMap, maskNode);
                maskMap.Masks.Add(mask);
                maskMap.Children.AddRange(mask.Children);
            }

            return maskMap;
        }
    }
}
