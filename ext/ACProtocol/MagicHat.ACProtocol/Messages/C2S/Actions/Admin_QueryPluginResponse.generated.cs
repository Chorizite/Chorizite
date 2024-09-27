using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Admin Returns plugin info
    /// </summary>
    public class Admin_QueryPluginResponse : ACGameAction {
        public uint Context;

        public bool Success;

        public string PluginName;

        public string PluginAuthor;

        public string PluginEmail;

        public string PluginWebpage;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Context = reader.ReadUInt32();
            Success = reader.ReadBool();
            PluginName = reader.ReadString16L();
            PluginAuthor = reader.ReadString16L();
            PluginEmail = reader.ReadString16L();
            PluginWebpage = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Context);
            writer.Write(Success);
            writer.Write(PluginName);
            writer.Write(PluginAuthor);
            writer.Write(PluginEmail);
            writer.Write(PluginWebpage);
        }

    }

}
