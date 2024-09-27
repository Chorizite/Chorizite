//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
namespace MagicHat.ACProtocol.Enums {
    /// <summary>
    /// The EmoteType identifies the type of emote action
    /// </summary>
    public enum EmoteType : uint {
        Invalid_EmoteType = 0x00,

        Invalid_VendorEmoteType = 0x00,

        Act_EmoteType = 0x01,

        AwardXP_EmoteType = 0x02,

        Give_EmoteType = 0x03,

        MoveHome_EmoteType = 0x04,

        Motion_EmoteType = 0x05,

        Move_EmoteType = 0x06,

        PhysScript_EmoteType = 0x07,

        Say_EmoteType = 0x08,

        Sound_EmoteType = 0x09,

        Tell_EmoteType = 0x0A,

        Turn_EmoteType = 0x0B,

        TurnToTarget_EmoteType = 0x0C,

        TextDirect_EmoteType = 0x0D,

        CastSpell_EmoteType = 0x0E,

        Activate_EmoteType = 0x0F,

        WorldBroadcast_EmoteType = 0x10,

        LocalBroadcast_EmoteType = 0x11,

        DirectBroadcast_EmoteType = 0x12,

        CastSpellInstant_EmoteType = 0x13,

        UpdateQuest_EmoteType = 0x14,

        InqQuest_EmoteType = 0x15,

        StampQuest_EmoteType = 0x16,

        StartEvent_EmoteType = 0x17,

        StopEvent_EmoteType = 0x18,

        BLog_EmoteType = 0x19,

        AdminSpam_EmoteType = 0x1A,

        TeachSpell_EmoteType = 0x1B,

        AwardSkillXP_EmoteType = 0x1C,

        AwardSkillPoints_EmoteType = 0x1D,

        InqQuestSolves_EmoteType = 0x1E,

        EraseQuest_EmoteType = 0x1F,

        DecrementQuest_EmoteType = 0x20,

        IncrementQuest_EmoteType = 0x21,

        AddCharacterTitle_EmoteType = 0x22,

        InqBoolStat_EmoteType = 0x23,

        InqIntStat_EmoteType = 0x24,

        InqFloatStat_EmoteType = 0x25,

        InqStringStat_EmoteType = 0x26,

        InqAttributeStat_EmoteType = 0x27,

        InqRawAttributeStat_EmoteType = 0x28,

        InqSecondaryAttributeStat_EmoteType = 0x29,

        InqRawSecondaryAttributeStat_EmoteType = 0x2A,

        InqSkillStat_EmoteType = 0x2B,

        InqRawSkillStat_EmoteType = 0x2C,

        InqSkillTrained_EmoteType = 0x2D,

        InqSkillSpecialized_EmoteType = 0x2E,

        AwardTrainingCredits_EmoteType = 0x2F,

        InflictVitaePenalty_EmoteType = 0x30,

        AwardLevelProportionalXP_EmoteType = 0x31,

        AwardLevelProportionalSkillXP_EmoteType = 0x32,

        InqEvent_EmoteType = 0x33,

        ForceMotion_EmoteType = 0x34,

        SetIntStat_EmoteType = 0x35,

        IncrementIntStat_EmoteType = 0x36,

        DecrementIntStat_EmoteType = 0x37,

        CreateTreasure_EmoteType = 0x38,

        ResetHomePosition_EmoteType = 0x39,

        InqFellowQuest_EmoteType = 0x3A,

        InqFellowNum_EmoteType = 0x3B,

        UpdateFellowQuest_EmoteType = 0x3C,

        StampFellowQuest_EmoteType = 0x3D,

        AwardNoShareXP_EmoteType = 0x3E,

        SetSanctuaryPosition_EmoteType = 0x3F,

        TellFellow_EmoteType = 0x40,

        FellowBroadcast_EmoteType = 0x41,

        LockFellow_EmoteType = 0x42,

        Goto_EmoteType = 0x43,

        PopUp_EmoteType = 0x44,

        SetBoolStat_EmoteType = 0x45,

        SetQuestCompletions_EmoteType = 0x46,

        InqNumCharacterTitles_EmoteType = 0x47,

        Generate_EmoteType = 0x48,

        PetCastSpellOnOwner_EmoteType = 0x49,

        TakeItems_EmoteType = 0x4A,

        InqYesNo_EmoteType = 0x4B,

        InqOwnsItems_EmoteType = 0x4C,

        DeleteSelf_EmoteType = 0x4D,

        KillSelf_EmoteType = 0x4E,

        UpdateMyQuest_EmoteType = 0x4F,

        InqMyQuest_EmoteType = 0x50,

        StampMyQuest_EmoteType = 0x51,

        InqMyQuestSolves_EmoteType = 0x52,

        EraseMyQuest_EmoteType = 0x53,

        DecrementMyQuest_EmoteType = 0x54,

        IncrementMyQuest_EmoteType = 0x55,

        SetMyQuestCompletions_EmoteType = 0x56,

        MoveToPos_EmoteType = 0x57,

        LocalSignal_EmoteType = 0x58,

        InqPackSpace_EmoteType = 0x59,

        RemoveVitaePenalty_EmoteType = 0x5A,

        SetEyeTexture_EmoteType = 0x5B,

        SetEyePalette_EmoteType = 0x5C,

        SetNoseTexture_EmoteType = 0x5D,

        SetNosePalette_EmoteType = 0x5E,

        SetMouthTexture_EmoteType = 0x5F,

        SetMouthPalette_EmoteType = 0x60,

        SetHeadObject_EmoteType = 0x61,

        SetHeadPalette_EmoteType = 0x62,

        TeleportTarget_EmoteType = 0x63,

        TeleportSelf_EmoteType = 0x64,

        StartBarber_EmoteType = 0x65,

        InqQuestBitsOn_EmoteType = 0x66,

        InqQuestBitsOff_EmoteType = 0x67,

        InqMyQuestBitsOn_EmoteType = 0x68,

        InqMyQuestBitsOff_EmoteType = 0x69,

        SetQuestBitsOn_EmoteType = 0x6A,

        SetQuestBitsOff_EmoteType = 0x6B,

        SetMyQuestBitsOn_EmoteType = 0x6C,

        SetMyQuestBitsOff_EmoteType = 0x6D,

        UntrainSkill_EmoteType = 0x6E,

        SetAltRacialSkills_EmoteType = 0x6F,

        SpendLuminance_EmoteType = 0x70,

        AwardLuminance_EmoteType = 0x71,

        InqInt64Stat_EmoteType = 0x72,

        SetInt64Stat_EmoteType = 0x73,

        OpenMe_EmoteType = 0x74,

        CloseMe_EmoteType = 0x75,

        SetFloatStat_EmoteType = 0x76,

        AddContract_EmoteType = 0x77,

        RemoveContract_EmoteType = 0x78,

        InqContractsFull_EmoteType = 0x79,

    };
}
