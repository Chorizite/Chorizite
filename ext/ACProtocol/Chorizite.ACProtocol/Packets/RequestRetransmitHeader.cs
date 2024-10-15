using System.Collections.Generic;
using System.IO;

namespace Chorizite.ACProtocol.Packets {
    public class RequestRetransmitHeader {
        public List<uint> SequenceIds = new List<uint>();

        public RequestRetransmitHeader() {
        }

        public RequestRetransmitHeader(BinaryReader reader) {
            var num = reader.ReadUInt32();

            for (var i = 0; i < num; i++) {
                SequenceIds.Add(reader.ReadUInt32());
            }
        }
    }
}