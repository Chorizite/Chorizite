using System;
using System.IO;
using System.Net.Sockets;
using Chorizite.ACProtocol.Extensions;

namespace Chorizite.ACProtocol.Packets {
	public class LoginRequestHeader {
		public string ClientVersion;
		public uint Length;
		public NetAuthType NetAuthType;
		public uint Sequence;
		public string Account;
		public string AccountToLoginAs;
		public string Password;
		public string GlsTicket;
		public AuthFlags AuthFlags;

		public LoginRequestHeader() {
			ClientVersion = "";
		}

		public LoginRequestHeader(BinaryReader reader) {
			Console.WriteLine($"\t\tLogin Request Header:");

			ClientVersion = reader.ReadString16L();
			Length = reader.ReadUInt32();
			var start = reader.BaseStream.Position;

			NetAuthType = (NetAuthType)reader.ReadUInt32();
			AuthFlags = (AuthFlags)reader.ReadUInt32();
			Sequence = reader.ReadUInt32();
			Account = reader.ReadString16L();
			AccountToLoginAs = reader.ReadString16L();


			Console.WriteLine($"\t\t\tClient Version: {ClientVersion}");
			Console.WriteLine($"\t\t\tLength: {Length}");
			Console.WriteLine($"\t\t\tNetAuthType: {NetAuthType}");
			Console.WriteLine($"\t\t\tAuthFlags: {AuthFlags}");
			Console.WriteLine($"\t\t\tSequence: {Sequence}");
			Console.WriteLine($"\t\t\tAccount: {Account}");
			Console.WriteLine($"\t\t\tAccountToLoginAs: {AccountToLoginAs}");


			if (NetAuthType == NetAuthType.AccountPassword) {
				Password = reader.ReadString32L(false);
				Console.WriteLine($"\t\t\tPassword: {Password}");
			}
			else if (NetAuthType == NetAuthType.GlsTicket) {
				GlsTicket = reader.ReadString32L(false);
				Console.WriteLine($"\t\t\tGlsTicket: {GlsTicket}");
			}
		}
	}
}