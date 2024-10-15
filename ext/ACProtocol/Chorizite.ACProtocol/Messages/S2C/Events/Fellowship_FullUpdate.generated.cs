using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Create or join a fellowship
    /// </summary>
    public class Fellowship_FullUpdate : ACGameEvent {
        /// <summary>
        /// Full set of fellowship information
        /// </summary>
        public Fellowship Fellowship;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Fellowship = new Fellowship();
            Fellowship.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            Fellowship.Write(writer);
        }

    }

}
