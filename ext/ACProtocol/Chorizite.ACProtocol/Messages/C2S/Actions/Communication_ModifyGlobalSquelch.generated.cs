using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Changes the global filters, /filter -type as well as /chat and /notell
    /// </summary>
    public class Communication_ModifyGlobalSquelch : ACGameAction {
        /// <summary>
        /// 0 = unsquelch, 1 = squelch
        /// </summary>
        public bool Add;

        /// <summary>
        /// The message type to squelch or unsquelch
        /// </summary>
        public ChatFragmentType Type;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Add = reader.ReadBool();
            Type = (ChatFragmentType)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Add);
            writer.Write((uint)Type);
        }

    }

}
