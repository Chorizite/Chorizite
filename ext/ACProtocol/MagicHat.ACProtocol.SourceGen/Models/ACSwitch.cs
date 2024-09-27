using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MagicHat.ACProtocol.SourceGen.Models {
    public class ACSwitch : ACBaseModel {
        public string Name { get; set; }

        public List<ACSwitchCase> Cases { get; set; } = new List<ACSwitchCase>();

        public ACSwitch(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        internal static ACSwitch FromXElement(ACBaseModel parent, XElement element) {
            var name = (string)element.Attribute("name");
            var cases = new List<ACSwitchCase>();
            
            var acs = new ACSwitch(parent, element) {
                Name = ACDataMember.FirstCharToUpper(name)
            };

            var nodes = element.XPathSelectElements("./case");
            foreach (var node in nodes) {
                var scase = ACSwitchCase.FromXElement(acs, node);
                acs.Cases.Add(scase);
                acs.Children.AddRange(scase.Children);
            }

            return acs;
        }
    }
}
