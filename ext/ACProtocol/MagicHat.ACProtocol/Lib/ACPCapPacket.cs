using System;
using System.Collections.Generic;
using System.Text;
using MagicHat.ACProtocol.Lib.PCap;
using MagicHat.ACProtocol.Packets;

namespace MagicHat.ACProtocol.Lib {
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
