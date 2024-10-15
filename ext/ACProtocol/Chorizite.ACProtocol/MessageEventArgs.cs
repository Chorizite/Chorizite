using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;

namespace Chorizite.ACProtocol {
    /// <summary>
    /// Contains data about a Fragment
    /// </summary>
    public class MessageEventArgs {
        /// <summary>
        /// Direction the Message was sent in (S2C or C2S)
        /// </summary>
        public MessageDirection Direction { get; }

        /// <summary>
        /// The message opcode
        /// </summary>
        public uint OpCode { get; }

        /// <summary>
        /// The actual Message data
        /// </summary>
        public ACMessage Message { get; }

        public MessageEventArgs(MessageDirection direction, uint opCode, ACMessage message) {
            Direction = direction;
            OpCode = opCode;
            Message = message;
        }
    }

    /// <summary>
    /// Contains data about a Server To Client Message
    /// </summary>
    public class S2CMessageEventArgs : MessageEventArgs {
        /// <summary>
        /// The actual Message data
        /// </summary>
        public new ACS2CMessage Message { get; }

        /// <summary>
        /// The type of S2C message
        /// </summary>
        public S2CMessageType MessageType { get; }

        public S2CMessageEventArgs(S2CMessageType messageType, ACS2CMessage message) : base(MessageDirection.ServerToClient, (uint)messageType, message) {
            Message = message;
            MessageType = messageType;
        }
    }

    /// <summary>
    /// Contains data about a Client To Server Message
    /// </summary>
    public class C2SMessageEventArgs : MessageEventArgs {
        /// <summary>
        /// The actual Message data
        /// </summary>
        public new ACC2SMessage Message { get; }

        /// <summary>
        /// The type of C2S message
        /// </summary>
        public C2SMessageType MessageType { get; }

        public C2SMessageEventArgs(C2SMessageType messageType, ACC2SMessage message) : base(MessageDirection.ClientToServer, (uint)messageType, message) {
            Message = message;
            MessageType = messageType;
        }
    }

    /// <summary>
    /// Contains data about a game event
    /// </summary>
    public class GameEventEventArgs : S2CMessageEventArgs {
        /// <summary>
        /// The actual game event data
        /// </summary>
        public new ACGameEvent Message { get; }

        /// <summary>
        /// The type of game event
        /// </summary>
        public GameEventType EventType { get; }

        public GameEventEventArgs(GameEventType eventType, ACGameEvent message) : base(S2CMessageType.Ordered_GameEvent, message) {
            Message = message;
            EventType = eventType;
        }
    }

    /// <summary>
    /// Contains data about a game action
    /// </summary>
    public class GameActionEventArgs : C2SMessageEventArgs {
        /// <summary>
        /// The actual game event data
        /// </summary>
        public new ACGameAction Message { get; }

        /// <summary>
        /// The type of game event
        /// </summary>
        public GameActionType ActionType { get; }

        public GameActionEventArgs(GameActionType actionType, ACGameAction message) : base(C2SMessageType.Ordered_GameAction, message) {
            Message = message;
            ActionType = actionType;
        }
    }

    /// <summary>
    /// Contains data about an unknown fragment
    /// </summary>
    public class UnknownMessageEventArgs {
        public MessageDirection Direction { get; }
        public uint OpCode { get; }
        public byte[] RawData { get; }

        public UnknownMessageEventArgs(MessageDirection direction, uint opCode, byte[] rawData) {
            Direction = direction;
            OpCode = opCode;
            RawData = rawData;
        }
    }
}
