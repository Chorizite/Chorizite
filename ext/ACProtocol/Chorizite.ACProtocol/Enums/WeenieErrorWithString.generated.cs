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
    /// Set of predefined error messages that accept interpolated string argument
    /// </summary>
    public enum WeenieErrorWithString : uint {
        IsTooBusyToAcceptGifts = 0x001E,

        CannotCarryAnymore = 0x002B,

        YouFailToAffect_YouCannotAffectAnyone = 0x004E,

        YouFailToAffect_TheyCannotBeHarmed = 0x004F,

        YouFailToAffect_WithBeneficialSpells = 0x0050,

        YouFailToAffect_YouAreNotPK = 0x0051,

        YouFailToAffect_TheyAreNotPK = 0x0052,

        YouFailToAffect_NotSamePKType = 0x0053,

        YouFailToAffect_AcrossHouseBoundary = 0x0054,

        IsNotAcceptingGiftsRightNow = 0x03EF,

        IsAlreadyOneOfYourFollowers = 0x0413,

        CannotHaveAnyMoreVassals = 0x0416,

        DoesntKnowWhatToDoWithThat = 0x046A,

        YouMustBeAboveLevel_ToBuyHouse = 0x0488,

        YouMustBeAtOrBelowLevel_ToBuyHouse = 0x0489,

        YouMustBeAboveAllegianceRank_ToBuyHouse = 0x048B,

        YouMustBeAtOrBelowAllegianceRank_ToBuyHouse = 0x048C,

        The_WasNotSuitableForSalvaging = 0x04BF,

        The_ContainseTheWrongMaterial = 0x04C0,

        YouMustBe_ToUseItemMagic = 0x04C6,

        Your_IsTooLowToUseItemMagic = 0x04C9,

        Only_MayUseItemMagic = 0x04CA,

        YouMustSpecialize_ToUseItemMagic = 0x04CB,

        AiRefuseItemDuringEmote = 0x04CE,

        CannotAcceptStackedItems = 0x04CF,

        Your_SkillMustBeTrained = 0x04D1,

        NotEnoughSkillCreditsToSpecialize = 0x04D2,

        TooMuchXPToRecoverFromSkill = 0x04D3,

        Your_SkillIsAlreadyUntrained = 0x04D4,

        CannotLowerSkillWhileWieldingItem = 0x04D5,

        YouHaveSucceededSpecializing_Skill = 0x04D6,

        YouHaveSucceededUnspecializing_Skill = 0x04D7,

        YouHaveSucceededUntraining_Skill = 0x04D8,

        CannotUntrain_SkillButRecoveredXP = 0x04D9,

        TooManyCreditsInSpecializedSkills = 0x04DA,

        AttributeTransferFromTooLow = 0x04DE,

        AttributeTransferToTooHigh = 0x04DF,

        ItemUnusableOnHook_CannotOpen = 0x04E8,

        ItemUnusableOnHook_CanOpen = 0x04E9,

        ItemOnlyUsableOnHook = 0x04EA,

        FailsToAffectYou_TheyCannotAffectAnyone = 0x04F4,

        FailsToAffectYou_YouCannotBeHarmed = 0x04F5,

        FailsToAffectYou_TheyAreNotPK = 0x04F6,

        FailsToAffectYou_YouAreNotPK = 0x04F7,

        FailsToAffectYou_NotSamePKType = 0x04F8,

        FailsToAffectYouAcrossHouseBoundary = 0x04F9,

        IsAnInvalidTarget = 0x04FA,

        YouAreInvalidTargetForSpellOf_ = 0x04FB,

        IsAtFullHealth = 0x04FF,

        HasNoSpellTargets = 0x0509,

        YouHaveNoTargetsForSpellOf_ = 0x050A,

        IsNowOpenFellowship = 0x050B,

        IsNowClosedFellowship = 0x050C,

        IsNowLeaderOfFellowship = 0x050D,

        YouHavePassedFellowshipLeadershipTo_ = 0x050E,

        MaxNumberOf_Hooked = 0x0510,

        MaxNumberOf_HookedUntilOneIsRemoved = 0x0514,

        NoLongerMaxNumberOf_Hooked = 0x0515,

        IsNotCloseEnoughToYourLevel = 0x0517,

        LockedFellowshipCannotRecruit_ = 0x0518,

        YouHaveEnteredThe_Channel = 0x051B,

        YouHaveLeftThe_Channel = 0x051C,

        WillNotReceiveMessage = 0x051E,

        MessageBlocked_ = 0x051F,

        HasBeenAddedToHearList = 0x0521,

        HasBeenRemovedFromHearList = 0x0522,

        FailToRemove_FromLoudList = 0x0525,

        YouCannotOpenLockedFellowship = 0x0528,

        YouAreNowSnoopingOn_ = 0x052C,

        YouAreNoLongerSnoopingOn_ = 0x052D,

        YouFailToSnoopOn_ = 0x052E,

        AttemptedToSnoopOnYou = 0x052F,

        IsAlreadyBeingSnoopedOn = 0x0530,

        IsInLimbo = 0x0531,

        YouHaveBeenBootedFromAllegianceChat = 0x0533,

        HasBeenBootedFromAllegianceChat = 0x0534,

        AccountOf_IsAlreadyBannedFromAllegiance = 0x0536,

        AccountOf_IsNotBannedFromAllegiance = 0x0537,

        AccountOf_WasNotUnbannedFromAllegiance = 0x0538,

        AccountOf_IsBannedFromAllegiance = 0x0539,

        AccountOf_IsUnbannedFromAllegiance = 0x053A,

        ListOfBannedCharacters = 0x053B,

        IsBannedFromAllegiance = 0x053E,

        YouAreBannedFromAllegiance = 0x053F,

        IsNowAllegianceOfficer = 0x0541,

        ErrorSetting_AsAllegianceOfficer = 0x0542,

        IsNoLongerAllegianceOfficer = 0x0543,

        ErrorRemoving_AsAllegianceOFficer = 0x0544,

        YouMustWait_BeforeCommunicating = 0x0547,

        YourAllegianceOfficerStatusChanged = 0x0549,

        IsAlreadyAllegianceOfficerOfThatLevel = 0x054B,

        The_IsCurrentlyInUse = 0x54D,

        YouAreNotListeningTo_Channel = 0x0551,

        AugmentationSkillNotTrained = 0x055A,

        YouSuccededAcquiringAugmentation = 0x055B,

        YouSucceededRecoveringXPFromSkill_AugmentationNotUntrainable = 0x055C,

        AFK = 0x055E,

        IsAlreadyOnYourFriendsList = 0x0562,

        YouMayOnlyChangeAllegianceNameOnceEvery24Hours = 0x056A,

        IsTheMonarchAndCannotBePromotedOrDemoted = 0x056D,

        ThatLevelOfAllegianceOfficerIsNowKnownAs_ = 0x056E,

        YourAllegianceIsCurrently_ = 0x0574,

        YourAllegianceIsNow_ = 0x0575,

        YouCannotAcceptAllegiance_YourAllegianceIsLocked = 0x0576,

        YouCannotSwearAllegiance_AllegianceOf_IsLocked = 0x0577,

        YouHavePreApproved_ToJoinAllegiance = 0x0578,

        IsAlreadyMemberOfYourAllegiance = 0x057A,

        HasBeenPreApprovedToJoinYourAllegiance = 0x057B,

        YourAllegianceChatPrivilegesRemoved = 0x057F,

        IsTemporarilyGaggedInAllegianceChat = 0x0580,

        YourAllegianceChatPrivilegesRestoredBy_ = 0x0582,

        YouRestoreAllegianceChatPrivilegesTo_ = 0x0583,

        CowersFromYou = 0x058A,

    };
}
