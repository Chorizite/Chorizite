using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System;
using MagicHat.ACProtocol.SourceGen.Models;
using System.Xml.XPath;
using System.Linq;

namespace MagicHat.ACProtocol.SourceGen {

    public class MessagesReader {
        private string messagesXmlPath;
        public XElement Xml; 

        public static Dictionary<string, string> ACPrimitiveAliases = new Dictionary<string, string>();
        public Dictionary<string, string> ACTypeAliases => ACPrimitiveAliases;
        public Dictionary<string, ACDataType> ACTemplatedTypes = new Dictionary<string, ACDataType>();
        public Dictionary<string, ACPrimitive> ACPrimitives = new Dictionary<string, ACPrimitive>();
        public Dictionary<string, ACEnum> ACEnums = new Dictionary<string, ACEnum>();
        public Dictionary<string, ACDataType> ACDataTypes = new Dictionary<string, ACDataType>();
        public Dictionary<string, ACMessage> ACMessagesS2C = new Dictionary<string, ACMessage>();
        public Dictionary<string, ACMessage> ACMessagesC2S = new Dictionary<string, ACMessage>();
        public Dictionary<string, ACMessage> GameActions = new Dictionary<string, ACMessage>();
        public Dictionary<string, ACMessage> GameEvents = new Dictionary<string, ACMessage>();

        public static Dictionary<string, string> PrimitiveTypeLookup = new Dictionary<string, string>() {
            { "byte", "System.Byte" },
            { "short", "System.Int16" },
            { "ushort", "System.UInt16" },
            { "int", "System.Int32" },
            { "uint", "System.UInt32" },
        };

        public MessagesReader(string messagesXmlPath) {

            using (var stream = new FileStream(messagesXmlPath, FileMode.Open)) {
                Xml = XElement.Load(stream);
            }

            ACPrimitiveAliases.Clear();

            ParsePrimitives();
            ParseEnums();
            ParseTypes();
            ParseFragmentTypes();
            ParseActionsEvents();
        }

        /// <summary>
        /// Converts an ACData type to its primitive type
        /// </summary>
        /// <param name="type">the type to convert</param>
        /// <returns>a primitive type string</returns>
        public static string SimplifyType(string type) {
            while (ACPrimitiveAliases.ContainsKey(type))
                type = ACPrimitiveAliases[type];
            return type;
        }

        /// <summary>
        /// Converts an ac primitive to its system data type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string SimplifyPrimitive(string type) {
            while (ACPrimitiveAliases.ContainsKey(type))
                type = ACPrimitiveAliases[type];

            if (PrimitiveTypeLookup.ContainsKey(type))
                type = PrimitiveTypeLookup[type];

            return type;
        }

        private void ParsePrimitives() {
            var nodes = Xml.XPathSelectElements("/datatypes/types/type[@primitive='true']");
            foreach (var node in nodes) {
                var acPrimitive = ACPrimitive.FromXElement(null, node);
                ACPrimitives.Add(acPrimitive.Name, acPrimitive);
            }
        }

        private void ParseEnums() {
            var nodes = Xml.XPathSelectElements("/enums/enum");
            foreach (var node in nodes) {
                if (node.Attribute("name")?.Value == "MessageType") {
                    // split these into Message / Action / Events.
                    // actions are ordered fragments (F7B1) that are C2S
                    // events are ordered fragments (F7B0) that are S2C
                    var allMessageTypes = new ACEnum(null, node);

					var messageTypes = new ACEnum("MessageType", "Unordered message opcodes");
					messageTypes.Values = allMessageTypes.Values.Where(v => {
						var opcode = v.Value;
						var messageDef = Xml.XPathSelectElement($"/messages/message[@type='{opcode}']");
						return messageDef?.Attribute("ordered")?.Value?.ToLower() != "true";
					}).ToList();
                    ACEnums.Add(messageTypes.Name, messageTypes);

					var actionTypes = new ACEnum("GameAction", "Ordered C2S game action opcodes. These are contained within 0xF7B1 message types.");
					actionTypes.Values = allMessageTypes.Values.Where(v => {
						var opcode = v.Value;
						var messageDef = Xml.XPathSelectElement($"/messages/message[@type='{opcode}']");
						return messageDef?.Attribute("ordered")?.Value?.ToLower() == "true" && messageDef.Attribute("direction")?.Value?.ToLower() == "c2s";
					}).ToList();
					ACEnums.Add(actionTypes.Name, actionTypes);

					var eventTypes = new ACEnum("GameEvent", "Ordered S2C game event opcodes. These are contained within 0xF7B0 message types.");
					eventTypes.Values = allMessageTypes.Values.Where(v => {
						var opcode = v.Value;
						var messageDef = Xml.XPathSelectElement($"/messages/message[@type='{opcode}']");
						return messageDef?.Attribute("ordered")?.Value?.ToLower() == "true" && messageDef.Attribute("direction")?.Value?.ToLower() == "s2c";
					}).ToList();
					ACEnums.Add(eventTypes.Name, eventTypes);
				}
                else {
                    var acEnum = new ACEnum(null, node);
                    ACEnums.Add(acEnum.Name, acEnum);
                }
            }
        }

        private void ParseTypes() {
            var nodes = Xml.XPathSelectElements("/types/type");
            foreach (var node in nodes) {
                var acDataType = ACDataType.FromXElement(null, node);

                if (!string.IsNullOrWhiteSpace(acDataType.ParentType)) {
                    if (!acDataType.IsTemplated)
                    {
                        ACPrimitiveAliases.Add(acDataType.Name, SimplifyType(acDataType.ParentType));
                    }
                    else {
                        ACTemplatedTypes.Add(acDataType.Name, acDataType);
                    }
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(acDataType.Primitive)) {
                    if (acDataType.Primitive != "true")
                        ACPrimitiveAliases.Add(acDataType.Name, SimplifyType(acDataType.Primitive));
                    continue;
                }

                ACDataTypes.Add(acDataType.Name, acDataType);
            }
        }

        private void ParseActionsEvents()
        {
            var actions = Xml.XPathSelectElements("/gameactions/type");
            foreach (var node in actions)
            {
                var acMessage = ACMessage.FromXElement(null, node);
                var opcode = UInt32.Parse(acMessage.Type.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

                GameActions.Add(acMessage.Name, acMessage);
            }
            var events = Xml.XPathSelectElements("/gameevents/type");
            foreach (var node in events)
            {
                var acMessage = ACMessage.FromXElement(null, node);
                var opcode = UInt32.Parse(acMessage.Type.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

                GameEvents.Add(acMessage.Name, acMessage);
            }
        }

        private void ParseFragmentTypes()
        {
            var incoming = Xml.XPathSelectElements("/messages/s2c/type");
            foreach (var node in incoming)
            {
                var acMessage = ACMessage.FromXElement(null, node);
                var opcode = UInt32.Parse(acMessage.Type.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

                ACMessagesS2C.Add(acMessage.Name, acMessage);
            }

            var outgoing = Xml.XPathSelectElements("/messages/c2s/type");
            foreach (var node in outgoing)
            {
                var acMessage = ACMessage.FromXElement(null, node);
                var opcode = UInt32.Parse(acMessage.Type.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

                ACMessagesC2S.Add(acMessage.Name, acMessage);
            }
        }
    }
}