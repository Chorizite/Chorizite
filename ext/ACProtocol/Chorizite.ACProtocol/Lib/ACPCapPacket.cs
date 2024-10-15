using System;
using System.Collections.Generic;
using System.Text;
using Chorizite.ACProtocol.Lib.PCap;
using Chorizite.ACProtocol.Packets;

namespace Chorizite.ACProtocol.Lib {
    public class ACPCapPacket {
        public PCapPacket PCapPacket { get; }

        public ACPacket ACPacket { get; }
		public int Id { get; internal set; }

		public ACPCapPacket(PCapPacket pcapPacket, ACPacket acPacket) {
            PCapPacket = pcapPacket;
            ACPacket = acPacket;
        }
    }
}
