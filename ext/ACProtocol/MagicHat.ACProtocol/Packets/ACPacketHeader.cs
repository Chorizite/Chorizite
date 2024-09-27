using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Types;

namespace MagicHat.ACProtocol.Packets {
	public class ACPacketHeader {
		public uint Sequence;
		public PacketHeaderFlags Flags;
		public uint Checksum;
		public ushort Id;
		public ushort Time;
		public ushort Size;
		public ushort Iteration;

		public ServerSwitchHeader? ServerSwitch;
		public LogonServerAddrHeader? LogonServerAddr;
		public ReferralHeader? Referral;
		public AckSequenceHeader? AckSequence;
		public LoginRequestHeader? LoginRequest;
		public WorldLoginRequestHeader? WorldLoginRequest;
		public ConnectRequestHeader? ConnectRequest;
		public ConnectResponseHeader? ConnectResponse;
		public NetErrorHeader? NetError;
		public NetErrorDisconnectHeader? NetErrorDisconnect;
		public CICMDCommandHeader? CICMDCommand;
		public TimeSyncHeader? TimeSync;
		public EchoRequestHeader? EchoRequest;
		public EchoResponseHeader? EchoResponse;
		public FlowHeader? Flow;
        public BlobFragments? BlobFragments;

        public ACPacketHeader() {
		
		}

		public ACPacketHeader(BinaryReader reader) {
			Sequence = reader.ReadUInt32();
			Flags = (PacketHeaderFlags)reader.ReadUInt32();
			Checksum = reader.ReadUInt32();
			Id = reader.ReadUInt16();
			Time = reader.ReadUInt16();
			Size = reader.ReadUInt16();
			Iteration = reader.ReadUInt16();

			// optional headers
			if (Flags.HasFlag(PacketHeaderFlags.ServerSwitch)) {
				ServerSwitch = new ServerSwitchHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.LogonServerAddr)) {
				LogonServerAddr = new LogonServerAddrHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.Referral)) {
				Referral = new ReferralHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.AckSequence)) {
				AckSequence = new AckSequenceHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.LoginRequest)) {
				LoginRequest = new LoginRequestHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.WorldLoginRequest)) {
				WorldLoginRequest = new WorldLoginRequestHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.ConnectRequest)) {
				ConnectRequest = new ConnectRequestHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.ConnectResponse)) {
				ConnectResponse = new ConnectResponseHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.NetError)) {
				NetError = new NetErrorHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.NetErrorDisconnect)) {
				NetErrorDisconnect = new NetErrorDisconnectHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.CICMDCommand)) {
				CICMDCommand = new CICMDCommandHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.TimeSync)) {
				TimeSync = new TimeSyncHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.EchoRequest)) {
				EchoRequest = new EchoRequestHeader(reader);
			}
			if (Flags.HasFlag(PacketHeaderFlags.EchoResponse)) {
				EchoResponse = new EchoResponseHeader(reader);
            }
            if (Flags.HasFlag(PacketHeaderFlags.Flow)) {
                Flow = new FlowHeader(reader);
            }
            if (Flags.HasFlag(PacketHeaderFlags.BlobFragments)) {
                BlobFragments = new BlobFragments();
                BlobFragments.Read(reader);
            }
        }
    }
}
