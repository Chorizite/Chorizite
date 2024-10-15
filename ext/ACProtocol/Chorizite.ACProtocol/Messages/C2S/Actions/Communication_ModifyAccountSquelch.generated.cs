using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Changes an account squelch
    /// </summary>
    public class Communication_ModifyAccountSquelch : ACGameAction {
        /// <summary>
        /// 0 = unsquelch, 1 = squelch
        /// </summary>
        public bool Add;

        /// <summary>
        /// The character who&#39;s acount should be squelched
        /// </summary>
        public string CharacterName;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Add = reader.ReadBool();
            CharacterName = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Add);
            writer.Write(CharacterName);
        }

    }

}
