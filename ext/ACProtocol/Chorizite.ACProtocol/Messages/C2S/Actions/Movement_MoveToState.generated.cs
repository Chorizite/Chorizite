using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Move to state data
    /// </summary>
    public class Movement_MoveToState : ACGameAction {
        /// <summary>
        /// set of move to data, currently not in client, may not be used?
        /// </summary>
        public MoveToStatePack MoveToState;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            MoveToState = new MoveToStatePack();
            MoveToState.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            MoveToState.Write(writer);
        }

    }

}
