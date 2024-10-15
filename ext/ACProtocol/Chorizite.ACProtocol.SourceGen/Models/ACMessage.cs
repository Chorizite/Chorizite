using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Chorizite.ACProtocol.SourceGen.Models {
    public class ACMessage : ACBaseModel {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";

        public bool Ordered { get; set; }

        public string Queue { get; set; } = "";

        public string Text { get; set; } = "";
        public string Direction { get; set; } = "";

        public ACMessage(ACBaseModel parent, XElement element) : base(parent, element) {

        }

        public static ACMessage FromXElement(ACBaseModel parent, XElement element) {
            var name = (string)element.Attribute("name");
            var type = (string)element.Attribute("type");
            var ordered = ((string)element.Attribute("ordered") ?? "").ToLower() == "true";
            var queue = (string)element.Attribute("queue");
            var text = (string)element.Attribute("text");
            var direction = element.Parent.Name.ToString().ToLower();

            if (direction == "gameactions") {
                direction = "c2s";
            }
            if (direction == "gameevents") {
                direction = "s2c";
            }

            var message = new ACMessage(parent, element) {
                Name = name,
                Type = type,
                Ordered = ordered,
                Queue = queue,
                Text = text,
                Direction = direction
            };

            return message;
        }
    }
}