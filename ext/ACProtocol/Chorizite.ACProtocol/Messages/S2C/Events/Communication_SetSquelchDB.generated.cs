using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Squelch and Filter List
    /// </summary>
    public class Communication_SetSquelchDB : ACGameEvent {
        /// <summary>
        /// The set of squelch information for the user
        /// </summary>
        public SquelchDB SquelchDB;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            SquelchDB = new SquelchDB();
            SquelchDB.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            SquelchDB.Write(writer);
        }

    }

}
