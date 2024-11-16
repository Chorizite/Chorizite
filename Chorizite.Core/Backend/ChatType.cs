using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend {
    /// <summary>
    /// Chat types
    /// </summary>
    public enum ChatType : uint {
        Default = 0x0,
        AllChannels = 0x1,
        Speech = 0x2,
        SpeechDirect = 0x3,
        SpeechDirectSend = 0x4,
        SystemSvent = 0x5,
        Combat = 0x6,
        Magic = 0x7,
        Channel = 0x8,
        ChannelCend = 0x9,
        SocialChannel = 0xA,
        SocialChannelSend = 0xB,
        Emote = 0xC,
        Advancement = 0xD,
        AbuseChannel = 0xE,
        HelpChannel = 0xF,
        AppraisalChannel = 0x10,
        MagicCastingChannel = 0x11,
        AllegienceChannel = 0x12,
        FellowshipChannel = 0x13,
        World_broadcast = 0x14,
        CombatEnemy = 0x15,
        CombatSelf = 0x16,
        Recall = 0x17,
        Craft = 0x18,
        Salvaging = 0x19,
        Transient = 0x1A,
        GeneralChannel = 0x1B,
        TradeChannel = 0x1C,
        LFGChannel = 0x1D,
        RoleplayChannel = 0x1E,
        AdminTell = 0x1F,
        Olthoi = 0x20,
        Society = 0x21
    };
}
