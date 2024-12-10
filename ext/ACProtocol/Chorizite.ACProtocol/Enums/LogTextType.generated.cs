//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;

namespace Chorizite.ACProtocol.Enums {
    /// <summary>
    /// The LogTextType indicates the kind of text going to the chat area.
    /// </summary>
    public enum LogTextType : uint {
        Default = 0x00,

        Speech = 0x02,

        Tell = 0x03,

        SpeechDirectSend = 0x04,

        System = 0x05,

        Combat = 0x06,

        Magic = 0x07,

        Channel = 0x08,

        ChannelSend = 0x09,

        Social = 0x0A,

        SocialSend = 0x0B,

        Emote = 0x0C,

        Advancement = 0x0D,

        Abuse = 0x0E,

        Help = 0x0F,

        Appraisal = 0x10,

        Spellcasting = 0x11,

        Allegiance = 0x12,

        Fellowship = 0x13,

        WorldBroadcast = 0x14,

        CombatEnemy = 0x15,

        CombatSelf = 0x16,

        Recall = 0x17,

        Craft = 0x18,

        Salvaging = 0x19,

        AdminTell = 0x1F,

    };
}
