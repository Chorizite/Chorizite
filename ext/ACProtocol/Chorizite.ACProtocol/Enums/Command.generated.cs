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
    /// Command types
    /// </summary>
    public enum Command : ushort {
        Invalid = 0x00,

        HoldRun = 0x01,

        HoldSidestep = 0x02,

        Ready = 0x03,

        Stop = 0x04,

        WalkForward = 0x05,

        WalkBackwards = 0x06,

        RunForward = 0x07,

        Fallen = 0x08,

        Interpolating = 0x09,

        Hover = 0x0A,

        On = 0x0B,

        Off = 0x0C,

        TurnRight = 0x0D,

        TurnLeft = 0x0E,

        SideStepRight = 0x0F,

        SideStepLeft = 0x10,

        Dead = 0x11,

        Crouch = 0x12,

        Sitting = 0x13,

        Sleeping = 0x14,

        Falling = 0x15,

        Reload = 0x16,

        Unload = 0x17,

        Pickup = 0x18,

        StoreInBackpack = 0x19,

        Eat = 0x1A,

        Drink = 0x1B,

        Reading = 0x1C,

        JumpCharging = 0x1D,

        AimLevel = 0x1E,

        AimHigh15 = 0x1F,

        AimHigh30 = 0x20,

        AimHigh45 = 0x21,

        AimHigh60 = 0x22,

        AimHigh75 = 0x23,

        AimHigh90 = 0x24,

        AimLow15 = 0x25,

        AimLow30 = 0x26,

        AimLow45 = 0x27,

        AimLow60 = 0x28,

        AimLow75 = 0x29,

        AimLow90 = 0x2A,

        MagicBlast = 0x2B,

        MagicSelfHead = 0x2C,

        MagicSelfHeart = 0x2D,

        MagicBonus = 0x2E,

        MagicClap = 0x2F,

        MagicHarm = 0x30,

        MagicHeal = 0x31,

        MagicThrowMissile = 0x32,

        MagicRecoilMissile = 0x33,

        MagicPenalty = 0x34,

        MagicTransfer = 0x35,

        MagicVision = 0x36,

        MagicEnchantItem = 0x37,

        MagicPortal = 0x38,

        MagicPray = 0x39,

        StopTurning = 0x3A,

        Jump = 0x3B,

        HandCombat = 0x3C,

        NonCombat = 0x3D,

        SwordCombat = 0x3E,

        BowCombat = 0x3F,

        SwordShieldCombat = 0x40,

        CrossbowCombat = 0x41,

        UnusedCombat = 0x42,

        SlingCombat = 0x43,

        TwoHandedSwordCombat = 0x44,

        TwoHandedStaffCombat = 0x45,

        DualWieldCombat = 0x46,

        ThrownWeaponCombat = 0x47,

        Graze = 0x48,

        Magi = 0x49,

        Hop = 0x4A,

        Jumpup = 0x4B,

        Cheer = 0x4C,

        ChestBeat = 0x4D,

        TippedLeft = 0x4E,

        TippedRight = 0x4F,

        FallDown = 0x50,

        Twitch1 = 0x51,

        Twitch2 = 0x52,

        Twitch3 = 0x53,

        Twitch4 = 0x54,

        StaggerBackward = 0x55,

        StaggerForward = 0x56,

        Sanctuary = 0x57,

        ThrustMed = 0x58,

        ThrustLow = 0x59,

        ThrustHigh = 0x5A,

        SlashHigh = 0x5B,

        SlashMed = 0x5C,

        SlashLow = 0x5D,

        BackhandHigh = 0x5E,

        BackhandMed = 0x5F,

        BackhandLow = 0x60,

        Shoot = 0x61,

        AttackHigh1 = 0x62,

        AttackMed1 = 0x63,

        AttackLow1 = 0x64,

        AttackHigh2 = 0x65,

        AttackMed2 = 0x66,

        AttackLow2 = 0x67,

        AttackHigh3 = 0x68,

        AttackMed3 = 0x69,

        AttackLow3 = 0x6A,

        HeadThrow = 0x6B,

        FistSlam = 0x6C,

        BreatheFlame_ = 0x6D,

        SpinAttack = 0x6E,

        MagicPowerUp01 = 0x6F,

        MagicPowerUp02 = 0x70,

        MagicPowerUp03 = 0x71,

        MagicPowerUp04 = 0x72,

        MagicPowerUp05 = 0x73,

        MagicPowerUp06 = 0x74,

        MagicPowerUp07 = 0x75,

        MagicPowerUp08 = 0x76,

        MagicPowerUp09 = 0x77,

        MagicPowerUp10 = 0x78,

        ShakeFist = 0x79,

        Beckon = 0x7A,

        BeSeeingYou = 0x7B,

        BlowKiss = 0x7C,

        BowDeep = 0x7D,

        ClapHands = 0x7E,

        Cry = 0x7F,

        Laugh = 0x80,

        MimeEat = 0x81,

        MimeDrink = 0x82,

        Nod = 0x83,

        Point = 0x84,

        ShakeHead = 0x85,

        Shrug = 0x86,

        Wave = 0x87,

        Akimbo = 0x88,

        HeartyLaugh = 0x89,

        Salute = 0x8A,

        ScratchHead = 0x8B,

        SmackHead = 0x8C,

        TapFoot = 0x8D,

        WaveHigh = 0x8E,

        WaveLow = 0x8F,

        YawnStretch = 0x90,

        Cringe = 0x91,

        Kneel = 0x92,

        Plead = 0x93,

        Shiver = 0x94,

        Shoo = 0x95,

        Slouch = 0x96,

        Spit = 0x97,

        Surrender = 0x98,

        Woah = 0x99,

        Winded = 0x9A,

        YMCA = 0x9B,

        EnterGame = 0x9C,

        ExitGame = 0x9D,

        OnCreation = 0x9E,

        OnDestruction = 0x9F,

        EnterPortal = 0xA0,

        ExitPortal = 0xA1,

        Cancel = 0xA2,

        UseSelected = 0xA3,

        AutosortSelected = 0xA4,

        DropSelected = 0xA5,

        GiveSelected = 0xA6,

        SplitSelected = 0xA7,

        ExamineSelected = 0xA8,

        CreateShortcutToSelected = 0xA9,

        PreviousCompassItem = 0xAA,

        NextCompassItem = 0xAB,

        ClosestCompassItem = 0xAC,

        PreviousSelection = 0xAD,

        LastAttacker = 0xAE,

        PreviousFellow = 0xAF,

        NextFellow = 0xB0,

        ToggleCombat = 0xB1,

        HighAttack = 0xB2,

        MediumAttack = 0xB3,

        LowAttack = 0xB4,

        EnterChat = 0xB5,

        ToggleChat = 0xB6,

        SavePosition = 0xB7,

        OptionsPanel = 0xB8,

        ResetView = 0xB9,

        CameraLeftRotate = 0xBA,

        CameraRightRotate = 0xBB,

        CameraRaise = 0xBC,

        CameraLower = 0xBD,

        CameraCloser = 0xBE,

        CameraFarther = 0xBF,

        FloorView = 0xC0,

        MouseLook = 0xC1,

        PreviousItem = 0xC2,

        NextItem = 0xC3,

        ClosestItem = 0xC4,

        ShiftView = 0xC5,

        MapView = 0xC6,

        AutoRun = 0xC7,

        DecreasePowerSetting = 0xC8,

        IncreasePowerSetting = 0xC9,

        Pray = 0xCA,

        Mock = 0xCB,

        Teapot = 0xCC,

        SpecialAttack1 = 0xCD,

        SpecialAttack2 = 0xCE,

        SpecialAttack3 = 0xCF,

        MissileAttack1 = 0xD0,

        MissileAttack2 = 0xD1,

        MissileAttack3 = 0xD2,

        CastSpell = 0xD3,

        Flatulence = 0xD4,

        FirstPersonView = 0xD5,

        AllegiancePanel = 0xD6,

        FellowshipPanel = 0xD7,

        SpellbookPanel = 0xD8,

        SpellComponentsPanel = 0xD9,

        HousePanel = 0xDA,

        AttributesPanel = 0xDB,

        SkillsPanel = 0xDC,

        MapPanel = 0xDD,

        InventoryPanel = 0xDE,

        Demonet = 0xDF,

        UseMagicStaff = 0xE0,

        UseMagicWand = 0xE1,

        Blink = 0xE2,

        Bite = 0xE3,

        TwitchSubstate1 = 0xE4,

        TwitchSubstate2 = 0xE5,

        TwitchSubstate3 = 0xE6,

        CaptureScreenshotToFile = 0xE7,

        BowNoAmmo = 0xE8,

        CrossBowNoAmmo = 0xE9,

        ShakeFistState = 0xEA,

        PrayState = 0xEB,

        BowDeepState = 0xEC,

        ClapHandsState = 0xED,

        CrossArmsState = 0xEE,

        ShiverState = 0xEF,

        PointState = 0xF0,

        WaveState = 0xF1,

        AkimboState = 0xF2,

        SaluteState = 0xF3,

        ScratchHeadState = 0xF4,

        TapFootState = 0xF5,

        LeanState = 0xF6,

        KneelState = 0xF7,

        PleadState = 0xF8,

        ATOYOT = 0xF9,

        SlouchState = 0xFA,

        SurrenderState = 0xFB,

        WoahState = 0xFC,

        WindedState = 0xFD,

        AutoCreateShortcuts = 0xFE,

        AutoRepeatAttacks = 0xFF,

        AutoTarget = 0x100,

        AdvancedCombatInterface = 0x101,

        IgnoreAllegianceRequests = 0x102,

        IgnoreFellowshipRequests = 0x103,

        InvertMouseLook = 0x104,

        LetPlayersGiveYouItems = 0x105,

        AutoTrackCombatTargets = 0x106,

        DisplayTooltips = 0x107,

        AttemptToDeceivePlayers = 0x108,

        RunAsDefaultMovement = 0x109,

        StayInChatModeAfterSend = 0x10A,

        RightClickToMouseLook = 0x10B,

        VividTargetIndicator = 0x10C,

        SelectSelf = 0x10D,

        SkillHealSelf = 0x10E,

        NextMonster = 0x10F,

        PreviousMonster = 0x110,

        ClosestMonster = 0x111,

        NextPlayer = 0x112,

        PreviousPlayer = 0x113,

        ClosestPlayer = 0x114,

        SnowAngelState = 0x115,

        WarmHands = 0x116,

        CurtseyState = 0x117,

        AFKState = 0x118,

        MeditateState = 0x119,

        TradePanel = 0x11A,

        LogOut = 0x11B,

        DoubleSlashLow = 0x11C,

        DoubleSlashMed = 0x11D,

        DoubleSlashHigh = 0x11E,

        TripleSlashLow = 0x11F,

        TripleSlashMed = 0x120,

        TripleSlashHigh = 0x121,

        DoubleThrustLow = 0x122,

        DoubleThrustMed = 0x123,

        DoubleThrustHigh = 0x124,

        TripleThrustLow = 0x125,

        TripleThrustMed = 0x126,

        TripleThrustHigh = 0x127,

        MagicPowerUp01Purple = 0x128,

        MagicPowerUp02Purple = 0x129,

        MagicPowerUp03Purple = 0x12A,

        MagicPowerUp04Purple = 0x12B,

        MagicPowerUp05Purple = 0x12C,

        MagicPowerUp06Purple = 0x12D,

        MagicPowerUp07Purple = 0x12E,

        MagicPowerUp08Purple = 0x12F,

        MagicPowerUp09Purple = 0x130,

        MagicPowerUp10Purple = 0x131,

        Helper = 0x132,

        Pickup5 = 0x133,

        Pickup10 = 0x134,

        Pickup15 = 0x135,

        Pickup20 = 0x136,

        HouseRecall = 0x137,

        AtlatlCombat = 0x138,

        ThrownShieldCombat = 0x139,

        SitState = 0x13A,

        SitCrossleggedState = 0x13B,

        SitBackState = 0x13C,

        PointLeftState = 0x13D,

        PointRightState = 0x13E,

        TalktotheHandState = 0x13F,

        PointDownState = 0x140,

        DrudgeDanceState = 0x141,

        PossumState = 0x142,

        ReadState = 0x143,

        ThinkerState = 0x144,

        HaveASeatState = 0x145,

        AtEaseState = 0x146,

        NudgeLeft = 0x147,

        NudgeRight = 0x148,

        PointLeft = 0x149,

        PointRight = 0x14A,

        PointDown = 0x14B,

        Knock = 0x14C,

        ScanHorizon = 0x14D,

        DrudgeDance = 0x14E,

        HaveASeat = 0x14F,

        LifestoneRecall = 0x150,

        CharacterOptionsPanel = 0x151,

        SoundAndGraphicsPanel = 0x152,

        HelpfulSpellsPanel = 0x153,

        HarmfulSpellsPanel = 0x154,

        CharacterInformationPanel = 0x155,

        LinkStatusPanel = 0x156,

        VitaePanel = 0x157,

        ShareFellowshipXP = 0x158,

        ShareFellowshipLoot = 0x159,

        AcceptCorpseLooting = 0x15A,

        IgnoreTradeRequests = 0x15B,

        DisableWeather = 0x15C,

        DisableHouseEffect = 0x15D,

        SideBySideVitals = 0x15E,

        ShowRadarCoordinates = 0x15F,

        ShowSpellDurations = 0x160,

        MuteOnLosingFocus = 0x161,

        Fishing = 0x162,

        MarketplaceRecall = 0x163,

        EnterPKLite = 0x164,

        AllegianceChat = 0x165,

        AutomaticallyAcceptFellowshipRequests = 0x166,

        Reply = 0x167,

        MonarchReply = 0x168,

        PatronReply = 0x169,

        ToggleCraftingChanceOfSuccessDialog = 0x16A,

        UseClosestUnopenedCorpse = 0x16B,

        UseNextUnopenedCorpse = 0x16C,

        IssueSlashCommand = 0x16D,

        AllegianceHometownRecall = 0x16E,

        PKArenaRecall = 0x16F,

        OffhandSlashHigh = 0x170,

        OffhandSlashMed = 0x171,

        OffhandSlashLow = 0x172,

        OffhandThrustHigh = 0x173,

        OffhandThrustMed = 0x174,

        OffhandThrustLow = 0x175,

        OffhandDoubleSlashLow = 0x176,

        OffhandDoubleSlashMed = 0x177,

        OffhandDoubleSlashHigh = 0x178,

        OffhandTripleSlashLow = 0x179,

        OffhandTripleSlashMed = 0x17A,

        OffhandTripleSlashHigh = 0x17B,

        OffhandDoubleThrustLow = 0x17C,

        OffhandDoubleThrustMed = 0x17D,

        OffhandDoubleThrustHigh = 0x17E,

        OffhandTripleThrustLow = 0x17F,

        OffhandTripleThrustMed = 0x180,

        OffhandTripleThrustHigh = 0x181,

        OffhandKick = 0x182,

        AttackHigh4 = 0x183,

        AttackMed4 = 0x184,

        AttackLow4 = 0x185,

        AttackHigh5 = 0x186,

        AttackMed5 = 0x187,

        AttackLow5 = 0x188,

        AttackHigh6 = 0x189,

        AttackMed6 = 0x18A,

        AttackLow6 = 0x18B,

        PunchFastHigh = 0x18C,

        PunchFastMed = 0x18D,

        PunchFastLow = 0x18E,

        PunchSlowHigh = 0x18F,

        PunchSlowMed = 0x190,

        PunchSlowLow = 0x191,

        OffhandPunchFastHigh = 0x192,

        OffhandPunchFastMed = 0x193,

        OffhandPunchFastLow = 0x194,

        OffhandPunchSlowHigh = 0x195,

        OffhandPunchSlowMed = 0x196,

        OffhandPunchSlowLow = 0x197,

    };
}
