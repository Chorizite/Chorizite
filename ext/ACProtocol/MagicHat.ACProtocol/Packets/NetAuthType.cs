using System;
using System.Collections.Generic;
using System.Text;

namespace MagicHat.ACProtocol.Packets {
	public enum NetAuthType : uint {
		Undef = 0x00000000,
		Account = 0x00000001,
		AccountPassword = 0x00000002,
		GlsTicket = 0x40000002
	}
}
