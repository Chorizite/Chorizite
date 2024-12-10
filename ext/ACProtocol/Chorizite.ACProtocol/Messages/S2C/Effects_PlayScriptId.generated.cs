using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Instructs the client to play a script. (Not seen so far, maybe prefered PlayScriptType)
    /// </summary>
    public class Effects_PlayScriptId : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF754;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Effects_PlayScriptId;

        /// <summary>
        /// Id of the object to play the script
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Id of script to be played
        /// </summary>
        public uint ScriptId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ScriptId = reader.ReadPackedDWORD();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(ScriptId);
        }

    }

}
