using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Chat types
    /// </summary>
    public enum ChatType : uint {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        Default = 0x0,
        All = 0x1,
        Speech = 0x2,
        SpeechDirect = 0x3,
        SpeechDirectSend = 0x4,
        SystemSvent = 0x5,
        Combat = 0x6,
        Magic = 0x7,
        Channel = 0x8,
        ChannelSend = 0x9,
        Social = 0xA,
        SocialSend = 0xB,
        Emote = 0xC,
        Advancement = 0xD,
        AbuseChannel = 0xE,
        HelpChannel = 0xF,
        Appraisal = 0x10,
        MagicCasting = 0x11,
        Allegience = 0x12,
        Fellowship = 0x13,
        WorldBroadcast = 0x14,
        CombatEnemy = 0x15,
        CombatSelf = 0x16,
        Recall = 0x17,
        Craft = 0x18,
        Salvaging = 0x19,
        Transient = 0x1A,
        General = 0x1B,
        Trade = 0x1C,
        LFG = 0x1D,
        Roleplay = 0x1E,
        AdminTell = 0x1F,
        Olthoi = 0x20,
        Society = 0x21
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    };
}
