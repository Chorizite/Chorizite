using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Chorizite.ACProtocol.SourceGen.Models {
    public class ACIf : ACBaseModel {
        public string Text { get; set; }
        public string Test { get; set; }

        public List<ACBaseModel> TrueMembers { get; set; } = new List<ACBaseModel>();
        public List<ACBaseModel> FalseMembers { get; set; } = new List<ACBaseModel>();

        public ACIf(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        internal static ACIf FromXElement(ACBaseModel parent, XElement element) {
            var text = (string)element.Attribute("text");
            var test = ACDataMember.FirstCharToUpper((string)element.Attribute("test"));

            var acif = new ACIf(parent, element) {
                Text = text,
                Test = test
            };

            acif.TrueMembers = acif.ParseChildren(element.XPathSelectElement("./true"));
            acif.FalseMembers = acif.ParseChildren(element.XPathSelectElement("./false"));

            acif.Children.AddRange(acif.TrueMembers);
            acif.Children.AddRange(acif.FalseMembers);

            return acif;
        }
    }
}
