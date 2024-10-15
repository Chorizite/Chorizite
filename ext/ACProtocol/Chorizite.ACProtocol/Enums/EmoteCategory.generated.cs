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
    /// The EmoteCategory identifies the category of an emote.
    /// </summary>
    public enum EmoteCategory : uint {
        Invalid_EmoteCategory = 0x00,

        Refuse_EmoteCategory = 0x01,

        Vendor_EmoteCategory = 0x02,

        Death_EmoteCategory = 0x03,

        Portal_EmoteCategory = 0x04,

        HeartBeat_EmoteCategory = 0x05,

        Give_EmoteCategory = 0x06,

        Use_EmoteCategory = 0x07,

        Activation_EmoteCategory = 0x08,

        Generation_EmoteCategory = 0x09,

        PickUp_EmoteCategory = 0x0A,

        Drop_EmoteCategory = 0x0B,

        QuestSuccess_EmoteCategory = 0x0C,

        QuestFailure_EmoteCategory = 0x0D,

        Taunt_EmoteCategory = 0x0E,

        WoundedTaunt_EmoteCategory = 0x0F,

        KillTaunt_EmoteCategory = 0x10,

        NewEnemy_EmoteCategory = 0x11,

        Scream_EmoteCategory = 0x12,

        Homesick_EmoteCategory = 0x13,

        ReceiveCritical_EmoteCategory = 0x14,

        ResistSpell_EmoteCategory = 0x15,

        TestSuccess_EmoteCategory = 0x16,

        TestFailure_EmoteCategory = 0x17,

        HearChat_EmoteCategory = 0x18,

        Wield_EmoteCategory = 0x19,

        UnWield_EmoteCategory = 0x1A,

        EventSuccess_EmoteCategory = 0x1B,

        EventFailure_EmoteCategory = 0x1C,

        TestNoQuality_EmoteCategory = 0x1D,

        QuestNoFellow_EmoteCategory = 0x1E,

        TestNoFellow_EmoteCategory = 0x1F,

        GotoSet_EmoteCategory = 0x20,

        NumFellowsSuccess_EmoteCategory = 0x21,

        NumFellowsFailure_EmoteCategory = 0x22,

        NumCharacterTitlesSuccess_EmoteCategory = 0x23,

        NumCharacterTitlesFailure_EmoteCategory = 0x24,

        ReceiveLocalSignal_EmoteCategory = 0x25,

        ReceiveTalkDirect_EmoteCategory = 0x26,

    };
}
