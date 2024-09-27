using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Updates a contract data
    /// </summary>
    public class Social_SendClientContractTracker : ACGameEvent {
        public ContractTracker ContractTracker;

        public bool DeleteContract;

        public bool SetAsDisplayContract;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ContractTracker = new ContractTracker();
            ContractTracker.Read(reader);
            DeleteContract = reader.ReadBool();
            SetAsDisplayContract = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            ContractTracker.Write(writer);
            writer.Write(DeleteContract);
            writer.Write(SetAsDisplayContract);
        }

    }

}
