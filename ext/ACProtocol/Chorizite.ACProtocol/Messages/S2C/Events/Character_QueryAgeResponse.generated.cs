using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// QueryAgeResponse: happens when you do /age in the game
    /// </summary>
    public class Character_QueryAgeResponse : ACGameEvent {
        /// <summary>
        /// Name of target, or empty if self
        /// </summary>
        public string TargetName;

        /// <summary>
        /// Your age in the format 1mo 1d 1h 1m 1s
        /// </summary>
        public string Age;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            TargetName = reader.ReadString16L();
            Age = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(TargetName);
            writer.Write(Age);
        }

    }

}
