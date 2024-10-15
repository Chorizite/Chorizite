using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Types;

namespace Chorizite.ACProtocol.Messages {
    /// <summary>
    /// AC fragment message base class.
    /// </summary>
    public abstract class ACMessage : IACDataType {
        /// <summary>
        /// The opcode of this message
        /// </summary>
        public abstract uint OpCode { get; }

        /// <summary>
        /// The direction of this message. Either server to client or client to server
        /// </summary>
        public abstract MessageDirection MessageDirection { get; }

        public virtual void Read(BinaryReader reader) {
            //Header = new ACFragmentHeader(reader);
        }

        public virtual void Write(BinaryWriter writer) {
            //Header.Write(writer);
        }
    }
}
