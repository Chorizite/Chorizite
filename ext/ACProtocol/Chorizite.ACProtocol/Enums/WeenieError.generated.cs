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
    /// Set of predefined error messages
    /// </summary>
    public enum WeenieError : uint {
        None = 0x0000,

        NoMem = 0x0001,

        BadParam = 0x0002,

        DivZero = 0x0003,

        SegV = 0x0004,

        Unimplemented = 0x0005,

        UnknownMessageType = 0x0006,

        NoAnimationTable = 0x0007,

        NoPhysicsObject = 0x0008,

        NoBookieObject = 0x0009,

        NoWslObject = 0x000A,

        NoMotionInterpreter = 0x000B,

        UnhandledSwitch = 0x000C,

        DefaultConstructorCalled = 0x000D,

        InvalidCombatManeuver = 0x000E,

        BadCast = 0x000F,

        MissingQuality = 0x0010,

        MissingDatabaseObject = 0x0012,

        NoCallbackSet = 0x0013,

        CorruptQuality = 0x0014,

        BadContext = 0x0015,

        NoEphseqManager = 0x0016,

        BadMovementEvent = 0x0017,

        CannotCreateNewObject = 0x0018,

        NoControllerObject = 0x0019,

        CannotSendEvent = 0x001A,

        PhysicsCantTransition = 0x001B,

        PhysicsMaxDistanceExceeded = 0x001C,

        YoureTooBusy = 0x001D,

        CannotSendMessage = 0x001F,

        IllegalInventoryTransaction = 0x0020,

        ExternalWeenieObject = 0x0021,

        InternalWeenieObject = 0x0022,

        MotionFailure = 0x0023,

        YouCantJumpWhileInTheAir = 0x0024,

        InqCylSphereFailure = 0x0025,

        ThatIsNotAValidCommand = 0x0026,

        CarryingItem = 0x0027,

        Frozen = 0x0028,

        Stuck = 0x0029,

        YouAreTooEncumbered = 0x002A,

        BadContain = 0x002C,

        BadParent = 0x002D,

        BadDrop = 0x002E,

        BadRelease = 0x002F,

        MsgBadMsg = 0x0030,

        MsgUnpackFailed = 0x0031,

        MsgNoMsg = 0x0032,

        MsgUnderflow = 0x0033,

        MsgOverflow = 0x0034,

        MsgCallbackFailed = 0x0035,

        ActionCancelled = 0x0036,

        ObjectGone = 0x0037,

        NoObject = 0x0038,

        CantGetThere = 0x0039,

        Dead = 0x003A,

        ILeftTheWorld = 0x003B,

        ITeleported = 0x003C,

        YouChargedTooFar = 0x003D,

        YouAreTooTiredToDoThat = 0x003E,

        CantCrouchInCombat = 0x003F,

        CantSitInCombat = 0x0040,

        CantLieDownInCombat = 0x0041,

        CantChatEmoteInCombat = 0x0042,

        NoMtableData = 0x0043,

        CantChatEmoteNotStanding = 0x0044,

        TooManyActions = 0x0045,

        Hidden = 0x0046,

        GeneralMovementFailure = 0x0047,

        YouCantJumpFromThisPosition = 0x0048,

        CantJumpLoadedDown = 0x0049,

        YouKilledYourself = 0x004A,

        MsgResponseFailure = 0x004B,

        ObjectIsStatic = 0x004C,

        InvalidPkStatus = 0x004D,

        InvalidXpAmount = 0x03E9,

        InvalidPpCalculation = 0x03EA,

        InvalidCpCalculation = 0x03EB,

        UnhandledStatAnswer = 0x03EC,

        HeartAttack = 0x03ED,

        TheContainerIsClosed = 0x03EE,

        InvalidInventoryLocation = 0x03F0,

        ChangeCombatModeFailure = 0x03F1,

        FullInventoryLocation = 0x03F2,

        ConflictingInventoryLocation = 0x03F3,

        ItemNotPending = 0x03F4,

        BeWieldedFailure = 0x03F5,

        BeDroppedFailure = 0x03F6,

        YouAreTooFatiguedToAttack = 0x03F7,

        YouAreOutOfAmmunition = 0x03F8,

        YourAttackMisfired = 0x03F9,

        YouveAttemptedAnImpossibleSpellPath = 0x03FA,

        MagicIncompleteAnimList = 0x03FB,

        MagicInvalidSpellType = 0x03FC,

        MagicInqPositionAndVelocityFailure = 0x03FD,

        YouDontKnowThatSpell = 0x03FE,

        IncorrectTargetType = 0x03FF,

        YouDontHaveAllTheComponents = 0x0400,

        YouDontHaveEnoughManaToCast = 0x0401,

        YourSpellFizzled = 0x0402,

        YourSpellTargetIsMissing = 0x0403,

        YourProjectileSpellMislaunched = 0x0404,

        MagicSpellbookAddSpellFailure = 0x0405,

        MagicTargetOutOfRange = 0x0406,

        YourSpellCannotBeCastOutside = 0x0407,

        YourSpellCannotBeCastInside = 0x0408,

        MagicGeneralFailure = 0x0409,

        YouAreUnpreparedToCastASpell = 0x040A,

        YouveAlreadySwornAllegiance = 0x040B,

        CantSwearAllegianceInsufficientXp = 0x040C,

        AllegianceIgnoringRequests = 0x040D,

        AllegianceSquelched = 0x040E,

        AllegianceMaxDistanceExceeded = 0x040F,

        AllegianceIllegalLevel = 0x0410,

        AllegianceBadCreation = 0x0411,

        AllegiancePatronBusy = 0x0412,

        YouAreNotInAllegiance = 0x0414,

        AllegianceRemoveHierarchyFailure = 0x0415,

        FellowshipIgnoringRequests = 0x0417,

        FellowshipSquelched = 0x0418,

        FellowshipMaxDistanceExceeded = 0x0419,

        FellowshipMember = 0x041A,

        FellowshipIllegalLevel = 0x041B,

        FellowshipRecruitBusy = 0x041C,

        YouMustBeLeaderOfFellowship = 0x041D,

        YourFellowshipIsFull = 0x041E,

        FellowshipNameIsNotPermitted = 0x041F,

        LevelTooLow = 0x0420,

        LevelTooHigh = 0x0421,

        ThatChannelDoesntExist = 0x0422,

        YouCantUseThatChannel = 0x0423,

        YouAreAlreadyOnThatChannel = 0x0424,

        YouAreNotOnThatChannel = 0x0425,

        AttunedItem = 0x0426,

        YouCannotMergeDifferentStacks = 0x0427,

        YouCannotMergeEnchantedItems = 0x0428,

        YouMustControlAtLeastOneStack = 0x0429,

        CurrentlyAttacking = 0x042A,

        MissileAttackNotOk = 0x042B,

        TargetNotAcquired = 0x042C,

        ImpossibleShot = 0x042D,

        BadWeaponSkill = 0x042E,

        UnwieldFailure = 0x042F,

        LaunchFailure = 0x0430,

        ReloadFailure = 0x0431,

        UnableToMakeCraftReq = 0x0432,

        CraftAnimationFailed = 0x0433,

        YouCantCraftWithThatNumberOfItems = 0x0434,

        CraftGeneralErrorUiMsg = 0x0435,

        CraftGeneralErrorNoUiMsg = 0x0436,

        YouDoNotPassCraftingRequirements = 0x0437,

        YouDoNotHaveAllTheNecessaryItems = 0x0438,

        NotAllTheItemsAreAvailable = 0x0439,

        YouMustBeInPeaceModeToTrade = 0x043A,

        YouAreNotTrainedInThatTradeSkill = 0x043B,

        YourHandsMustBeFree = 0x043C,

        YouCannotLinkToThatPortal = 0x043D,

        YouHaveSolvedThisQuestTooRecently = 0x043E,

        YouHaveSolvedThisQuestTooManyTimes = 0x043F,

        QuestUnknown = 0x0440,

        QuestTableCorrupt = 0x0441,

        QuestBad = 0x0442,

        QuestDuplicate = 0x0443,

        QuestUnsolved = 0x0444,

        ItemRequiresQuestToBePickedUp = 0x0445,

        QuestSolvedTooLongAgo = 0x0446,

        TradeIgnoringRequests = 0x044C,

        TradeSquelched = 0x044D,

        TradeMaxDistanceExceeded = 0x044E,

        TradeAlreadyTrading = 0x044F,

        TradeBusy = 0x0450,

        TradeClosed = 0x0451,

        TradeExpired = 0x0452,

        TradeItemBeingTraded = 0x0453,

        TradeNonEmptyContainer = 0x0454,

        TradeNonCombatMode = 0x0455,

        TradeIncomplete = 0x0456,

        TradeStampMismatch = 0x0457,

        TradeUnopened = 0x0458,

        TradeEmpty = 0x0459,

        TradeAlreadyAccepted = 0x045A,

        TradeOutOfSync = 0x045B,

        PKsMayNotUsePortal = 0x045C,

        NonPKsMayNotUsePortal = 0x045D,

        HouseAbandoned = 0x045E,

        HouseEvicted = 0x045F,

        HouseAlreadyOwned = 0x0460,

        HouseBuyFailed = 0x0461,

        HouseRentFailed = 0x0462,

        Hooked = 0x0463,

        MagicInvalidPosition = 0x0465,

        YouMustHaveDarkMajestyToUsePortal = 0x0466,

        InvalidAmmoType = 0x0467,

        SkillTooLow = 0x0468,

        YouHaveUsedAllTheHooks = 0x0469,

        TradeAiDoesntWant = 0x046A,

        HookHouseNotOwned = 0x046B,

        YouMustCompleteQuestToUsePortal = 0x0474,

        HouseNoAllegiance = 0x047E,

        YouMustOwnHouseToUseCommand = 0x047F,

        YourMonarchDoesNotOwnAMansionOrVilla = 0x0480,

        YourMonarchsHouseIsNotAMansionOrVilla = 0x0481,

        YourMonarchHasClosedTheMansion = 0x0482,

        YouMustBeMonarchToPurchaseDwelling = 0x048A,

        AllegianceTimeout = 0x048D,

        YourOfferOfAllegianceWasIgnored = 0x048E,

        ConfirmationInProgress = 0x048F,

        YouMustBeAMonarchToUseCommand = 0x0490,

        YouMustSpecifyCharacterToBoot = 0x0491,

        YouCantBootYourself = 0x0492,

        ThatCharacterDoesNotExist = 0x0493,

        ThatPersonIsNotInYourAllegiance = 0x0494,

        CantBreakFromPatronNotInAllegiance = 0x0495,

        YourAllegianceHasBeenDissolved = 0x0496,

        YourPatronsAllegianceHasBeenBroken = 0x0497,

        YouHaveMovedTooFar = 0x0498,

        TeleToInvalidPosition = 0x0499,

        MustHaveDarkMajestyToUse = 0x049A,

        YouFailToLinkWithLifestone = 0x049B,

        YouWanderedTooFarToLinkWithLifestone = 0x049C,

        YouSuccessfullyLinkWithLifestone = 0x049D,

        YouMustLinkToLifestoneToRecall = 0x049E,

        YouFailToRecallToLifestone = 0x049F,

        YouFailToLinkWithPortal = 0x04A0,

        YouSuccessfullyLinkWithPortal = 0x04A1,

        YouFailToRecallToPortal = 0x04A2,

        YouMustLinkToPortalToRecall = 0x04A3,

        YouFailToSummonPortal = 0x04A4,

        YouMustLinkToPortalToSummonIt = 0x04A5,

        YouFailToTeleport = 0x04A6,

        YouHaveBeenTeleportedTooRecently = 0x04A7,

        YouMustBeAnAdvocateToUsePortal = 0x04A8,

        PortalAisNotAllowed = 0x04A9,

        PlayersMayNotUsePortal = 0x04AA,

        YouAreNotPowerfulEnoughToUsePortal = 0x04AB,

        YouAreTooPowerfulToUsePortal = 0x04AC,

        YouCannotRecallPortal = 0x04AD,

        YouCannotSummonPortal = 0x04AE,

        LockAlreadyUnlocked = 0x04AF,

        YouCannotLockOrUnlockThat = 0x04B0,

        YouCannotLockWhatIsOpen = 0x04B1,

        KeyDoesntFitThisLock = 0x04B2,

        LockUsedTooRecently = 0x04B3,

        YouArentTrainedInLockpicking = 0x04B4,

        AllegianceInfoEmptyName = 0x04B5,

        AllegianceInfoSelf = 0x04B6,

        AllegianceInfoTooRecent = 0x04B7,

        AbuseNoSuchCharacter = 0x04B8,

        AbuseReportedSelf = 0x04B9,

        AbuseComplaintHandled = 0x04BA,

        YouDoNotOwnThatSalvageTool = 0x04BD,

        YouDoNotOwnThatItem = 0x04BE,

        MaterialCannotBeCreated = 0x04C1,

        ItemsAttemptingToSalvageIsInvalid = 0x04C2,

        YouCannotSalvageItemsInTrading = 0x04C3,

        YouMustBeHouseGuestToUsePortal = 0x04C4,

        YourAllegianceRankIsTooLowToUseMagic = 0x04C5,

        YourArcaneLoreIsTooLowToUseMagic = 0x04C7,

        ItemDoesntHaveEnoughMana = 0x04C8,

        YouHaveBeenInPKBattleTooRecently = 0x04CC,

        TradeAiRefuseEmote = 0x04CD,

        YouFailToAlterSkill = 0x04D0,

        FellowshipDeclined = 0x04DB,

        FellowshipTimeout = 0x04DC,

        YouHaveFailedToAlterAttributes = 0x04DD,

        CannotTransferAttributesWhileWieldingItem = 0x04E0,

        YouHaveSucceededTransferringAttributes = 0x04E1,

        HookIsDuplicated = 0x04E2,

        ItemIsWrongTypeForHook = 0x04E3,

        HousingChestIsDuplicated = 0x04E4,

        HookWillBeDeleted = 0x04E5,

        HousingChestWillBeDeleted = 0x04E6,

        CannotSwearAllegianceWhileOwningMansion = 0x04E7,

        YouCantDoThatWhileInTheAir = 0x04EB,

        CannotChangePKStatusWhileRecovering = 0x04EC,

        AdvocatesCannotChangePKStatus = 0x04ED,

        LevelTooLowToChangePKStatusWithObject = 0x04EE,

        LevelTooHighToChangePKStatusWithObject = 0x04EF,

        YouFeelAHarshDissonance = 0x04F0,

        YouArePKAgain = 0x04F1,

        YouAreTemporarilyNoLongerPK = 0x04F2,

        PKLiteMayNotUsePortal = 0x04F3,

        YouArentTrainedInHealing = 0x04FC,

        YouDontOwnThatHealingKit = 0x04FD,

        YouCantHealThat = 0x04FE,

        YouArentReadyToHeal = 0x0500,

        YouCanOnlyHealPlayers = 0x0501,

        LifestoneMagicProtectsYou = 0x0502,

        PortalEnergyProtectsYou = 0x0503,

        YouAreNonPKAgain = 0x0504,

        YoureTooCloseToYourSanctuary = 0x0505,

        CantDoThatTradeInProgress = 0x0506,

        OnlyNonPKsMayEnterPKLite = 0x0507,

        YouAreNowPKLite = 0x0508,

        YouDoNotBelongToAFellowship = 0x050F,

        UsingMaxHooksSilent = 0x0511,

        YouAreNowUsingMaxHooks = 0x0512,

        YouAreNoLongerUsingMaxHooks = 0x0513,

        YouAreNotPermittedToUseThatHook = 0x0516,

        LockedFellowshipCannotRecruitYou = 0x0519,

        ActivationNotAllowedNotOwner = 0x051A,

        TurbineChatIsEnabled = 0x051D,

        YouCannotAddPeopleToHearList = 0x0520,

        YouAreNowDeafTo_Screams = 0x0523,

        YouCanHearAllPlayersOnceAgain = 0x0524,

        YouChickenOut = 0x0526,

        YouCanPossiblySucceed = 0x0527,

        FellowshipIsLocked = 0x0528,

        TradeComplete = 0x0529,

        NotASalvageTool = 0x052A,

        CharacterNotAvailable = 0x052B,

        YouMustWaitToPurchaseHouse = 0x0532,

        YouDoNotHaveAuthorityInAllegiance = 0x0535,

        YouHaveMaxAccountsBanned = 0x0540,

        YouHaveMaxAllegianceOfficers = 0x0545,

        YourAllegianceOfficersHaveBeenCleared = 0x0546,

        YouCannotJoinChannelsWhileGagged = 0x0548,

        YouAreNoLongerAllegianceOfficer = 0x054A,

        YourAllegianceDoesNotHaveHometown = 0x054C,

        HookItemNotUsable_CannotOpen = 0x054E,

        HookItemNotUsable_CanOpen = 0x054F,

        MissileOutOfRange = 0x0550,

        MustPurchaseThroneOfDestinyToUseFunction = 0x0552,

        MustPurchaseThroneOfDestinyToUseItem = 0x0553,

        MustPurchaseThroneOfDestinyToUsePortal = 0x0554,

        MustPurchaseThroneOfDestinyToAccessQuest = 0x0555,

        YouFailedToCompleteAugmentation = 0x0556,

        AugmentationUsedTooManyTimes = 0x0557,

        AugmentationTypeUsedTooManyTimes = 0x0558,

        AugmentationNotEnoughExperience = 0x0559,

        ExitTrainingAcademyToUseCommand = 0x055D,

        OnlyPKsMayUseCommand = 0x055F,

        OnlyPKLiteMayUseCommand = 0x0560,

        MaxFriendsExceeded = 0x0561,

        ThatCharacterNotOnYourFriendsList = 0x0563,

        OnlyHouseOwnerCanUseCommand = 0x0564,

        InvalidAllegianceNameCantBeEmpty = 0x0565,

        InvalidAllegianceNameTooLong = 0x0566,

        InvalidAllegianceNameBadCharacters = 0x0567,

        InvalidAllegianceNameInappropriate = 0x0568,

        InvalidAllegianceNameAlreadyInUse = 0x0569,

        AllegianceNameCleared = 0x056B,

        InvalidAllegianceNameSameName = 0x056C,

        InvalidOfficerLevel = 0x056F,

        AllegianceOfficerTitleIsNotAppropriate = 0x0570,

        AllegianceNameIsTooLong = 0x0571,

        AllegianceOfficerTitlesCleared = 0x0572,

        AllegianceTitleHasIllegalChars = 0x0573,

        YouHaveNotPreApprovedVassals = 0x0579,

        YouHaveClearedPreApprovedVassal = 0x057C,

        CharIsAlreadyGagged = 0x057D,

        CharIsNotCurrentlyGagged = 0x057E,

        YourAllegianceChatPrivilegesRestored = 0x0581,

        TooManyUniqueItems = 0x0584,

        HeritageRequiresSpecificArmor = 0x0585,

        ArmorRequiresSpecificHeritage = 0x0586,

        OlthoiCannotInteractWithThat = 0x0587,

        OlthoiCannotUseLifestones = 0x0588,

        OlthoiVendorLooksInHorror = 0x0589,

        OlthoiCannotJoinFellowship = 0x058B,

        OlthoiCannotJoinAllegiance = 0x058C,

        YouCannotUseThatItem = 0x058D,

        ThisPersonWillNotInteractWithYou = 0x058E,

        OnlyOlthoiMayUsePortal = 0x058F,

        OlthoiMayNotUsePortal = 0x0590,

        YouMayNotUsePortalWithVitae = 0x0591,

        YouMustBeTwoWeeksOldToUsePortal = 0x0592,

        OlthoiCanOnlyRecallToLifestone = 0x0593,

        ContractError = 0x0594,

    };
}
