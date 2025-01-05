﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chorizite.Common.Enums {
    public enum ClientAction {
        PlayerOption_DisplayTimeStamps = 0x10000092,
        PlayerOption_SalvageMultiple = 0x10000093,
        Ready = 0x10000094,
        Crouch = 0x10000095,
        Sitting = 0x10000096,
        Sleeping = 0x10000097,
        AFKState = 0x10000098,
        Akimbo = 0x10000099,
        ATOYOT = 0x1000009A,
        AkimboState = 0x1000009B,
        AtEaseState = 0x1000009C,
        Beckon = 0x1000009D,
        BeSeeingYou = 0x1000009E,
        BlowKiss = 0x1000009F,
        BowDeep = 0x100000A0,
        BowDeepState = 0x100000A1,
        Cheer = 0x100000A2,
        ClapHands = 0x100000A3,
        ClapHandsState = 0x100000A4,
        Cringe = 0x100000A5,
        CrossArmsState = 0x100000A6,
        Cry = 0x100000A7,
        CurtseyState = 0x100000A8,
        DrudgeDance = 0x100000A9,
        DrudgeDanceState = 0x100000AA,
        HaveASeat = 0x100000AB,
        HaveASeatState = 0x100000AC,
        HeartyLaugh = 0x100000AD,
        Helper = 0x100000AE,
        Kneel = 0x100000AF,
        KneelState = 0x100000B0,
        Knock = 0x100000B1,
        Laugh = 0x100000B2,
        LeanState = 0x100000B3,
        MeditateState = 0x100000B4,
        MimeDrink = 0x100000B5,
        MimeEat = 0x100000B6,
        Mock = 0x100000B7,
        Nod = 0x100000B8,
        NudgeLeft = 0x100000B9,
        NudgeRight = 0x100000BA,
        Plead = 0x100000BB,
        PleadState = 0x100000BC,
        Point = 0x100000BD,
        PointState = 0x100000BE,
        PointDown = 0x100000BF,
        PointDownState = 0x100000C0,
        ToggleCasPanel = 0x10000001,
        PointLeft = 0x100000C1,
        ToggleAdminPanel = 0x10000002,
        PointLeftState = 0x100000C2,
        ToggleAbusePanel = 0x10000003,
        PointRight = 0x100000C3,
        ToggleBookPanel = 0x10000004,
        PointRightState = 0x100000C4,
        ToggleCharacterInfoPanel = 0x10000005,
        PossumState = 0x100000C5,
        TogglePositiveEffectsPanel = 0x10000006,
        Pray = 0x100000C6,
        ToggleNegativeEffectsPanel = 0x10000007,
        PrayState = 0x100000C7,
        ToggleExaminationPanel = 0x10000008,
        ReadState = 0x100000C8,
        ToggleLinkStatusPanel = 0x10000009,
        Salute = 0x100000C9,
        ToggleMiniGamePanel = 0x1000000A,
        SaluteState = 0x100000CA,
        ToggleUrgentAssistancePanel = 0x1000000B,
        ScanHorizon = 0x100000CB,
        ToggleVitaePanel = 0x1000000C,
        ScratchHead = 0x100000CC,
        ToggleSocialPanel = 0x1000000D,
        ScratchHeadState = 0x100000CD,
        ToggleAllegiancePanel = 0x1000000E,
        ShakeFist = 0x100000CE,
        ToggleFellowshipPanel = 0x1000000F,
        ShakeFistState = 0x100000CF,
        ToggleSpellManagementPanel = 0x10000010,
        ShakeHead = 0x100000D0,
        ToggleSpellbookPanel = 0x10000011,
        Shiver = 0x100000D1,
        ToggleSpellComponentsPanel = 0x10000012,
        ShiverState = 0x100000D2,
        ToggleSkillManagementPanel = 0x10000013,
        Shoo = 0x100000D3,
        ToggleAttributesPanel = 0x10000014,
        Shrug = 0x100000D4,
        ToggleSkillsPanel = 0x10000015,
        SitState = 0x100000D5,
        ToggleWorldPanel = 0x10000016,
        SitBackState = 0x100000D6,
        ToggleMapPanel = 0x10000017,
        SitCrossleggedState = 0x100000D7,
        ToggleHousePanel = 0x10000018,
        Slouch = 0x100000D8,
        ToggleInventoryPanel = 0x10000019,
        SlouchState = 0x100000D9,
        ToggleOptionsPanel = 0x1000001A,
        SmackHead = 0x100000DA,
        ToggleGameplayOptionsPanel = 0x1000001B,
        SnowAngelState = 0x100000DB,
        ToggleCharacterOptionsPanel = 0x1000001C,
        Spit = 0x100000DC,
        ToggleConfigOptionsPanel = 0x1000001D,
        Surrender = 0x100000DD,
        ToggleRadarPanel = 0x1000001E,
        SurrenderState = 0x100000DE,
        ToggleKeyboardPanel = 0x1000001F,
        TalktotheHandState = 0x100000DF,
        MonarchReply = 0x10000020,
        TapFoot = 0x100000E0,
        PatronReply = 0x10000021,
        TapFootState = 0x100000E1,
        Reply = 0x10000022,
        Teapot = 0x100000E2,
        EnterChatMode = 0x10000023,
        ThinkerState = 0x100000E3,
        ToggleChatEntry = 0x10000024,
        WarmHands = 0x100000E4,
        USE = 0x10000025,
        Wave = 0x100000E5,
        LOGOUT = 0x10000026,
        WaveState = 0x100000E6,
        EXITGAME = 0x10000027,
        WaveLow = 0x100000E7,
        START_COMMAND = 0x10000028,
        WaveHigh = 0x100000E8,
        START_ALIAS = 0x10000029,
        Winded = 0x100000E9,
        SelectionSelf = 0x1000002A,
        WindedState = 0x100000EA,
        SelectionExamine = 0x1000002B,
        Woah = 0x100000EB,
        SelectionPickUp = 0x1000002C,
        WoahState = 0x100000EC,
        SelectionSplitStack = 0x1000002D,
        YawnStretch = 0x100000ED,
        SelectionPreviousSelection = 0x1000002E,
        YMCA = 0x100000EE,
        SelectionClosestCompassItem = 0x1000002F,
        SelectionPreviousCompassItem = 0x10000030,
        CombatDecreaseMissileAccuracy = 0x100000EF,
        SelectionNextCompassItem = 0x10000031,
        CombatIncreaseMissileAccuracy = 0x100000F0,
        SelectionClosestItem = 0x10000032,
        CombatAimLow = 0x100000F1,
        SelectionPreviousItem = 0x10000033,
        CombatAimMedium = 0x100000F2,
        SelectionNextItem = 0x10000034,
        CombatAimHigh = 0x100000F3,
        SelectionClosestMonster = 0x10000035,
        SelectionPreviousMonster = 0x10000036,
        SelectionNextMonster = 0x10000037,
        SelectionLastAttacker = 0x10000038,
        SelectionClosestPlayer = 0x10000039,
        SelectionPreviousPlayer = 0x1000003A,
        SelectionNextPlayer = 0x1000003B,
        SelectionPreviousFellow = 0x1000003C,
        SelectionNextFellow = 0x1000003D,
        SelectionUseClosestUnopenedCorpse = 0x1000003E,
        SelectionUseNextUnopenedCorpse = 0x1000003F,
        SelectionGive = 0x10000040,
        SelectionDrop = 0x10000041,
        UseQuickSlot_1 = 0x10000042,
        UseQuickSlot_2 = 0x10000043,
        CombatFirstSpell = 0x10000102,
        UseQuickSlot_3 = 0x10000044,
        CombatLastSpell = 0x10000103,
        UseQuickSlot_4 = 0x10000045,
        CombatFirstSpellTab = 0x10000104,
        UseQuickSlot_5 = 0x10000046,
        CombatLastSpellTab = 0x10000105,
        UseQuickSlot_6 = 0x10000047,
        UseQuickSlot_7 = 0x10000048,
        UseQuickSlot_8 = 0x10000049,
        UseQuickSlot_9 = 0x1000004A,
        UseQuickSlot_10 = 0x1000004B,
        UseQuickSlot_11 = 0x1000004C,
        UseQuickSlot_12 = 0x1000004D,
        SelectQuickSlot_1 = 0x1000004E,
        CreateShortcut = 0x1000010D,
        PlayerOption_HearGeneralChat = 0x1000010E,
        SelectQuickSlot_2 = 0x1000004F,
        PlayerOption_HearTradeChat = 0x1000010F,
        SelectQuickSlot_3 = 0x10000050,
        PlayerOption_HearLFGChat = 0x10000110,
        SelectQuickSlot_4 = 0x10000051,
        SelectQuickSlot_5 = 0x10000052,
        PlayerOption_HearRoleplayChat = 0x10000112,
        SelectQuickSlot_6 = 0x10000053,
        SelectQuickSlot_7 = 0x10000054,
        ToggleChatOptionsPanel = 0x10000113,
        SelectQuickSlot_8 = 0x10000055,
        ToggleFloatingChatWindow1 = 0x10000114,
        SelectQuickSlot_9 = 0x10000056,
        ToggleFloatingChatWindow2 = 0x10000115,
        SelectQuickSlot_10 = 0x10000057,
        ToggleFloatingChatWindow3 = 0x10000116,
        SelectQuickSlot_11 = 0x10000058,
        ToggleFloatingChatWindow4 = 0x10000117,
        SelectQuickSlot_12 = 0x10000059,
        ToggleFriendsPanel = 0x10000118,
        CombatToggleCombat = 0x1000005A,
        TellSelected = 0x10000119,
        CombatDecreaseAttackPower = 0x1000005B,
        ToggleCharacterTitlePanel = 0x1000011A,
        PlayerOption_DisplayNumberCharacterTitles = 0x1000011B,
        CombatIncreaseAttackPower = 0x1000005C,
        CombatLowAttack = 0x1000005D,
        SelectionMoveToMainPack = 0x1000011C,
        PlayerOption_MainPackPreferred = 0x1000011D,
        CombatMediumAttack = 0x1000005E,
        PlayerOption_LeadMissileTargets = 0x1000011E,
        CombatHighAttack = 0x1000005F,
        PlayerOption_UseFastMissiles = 0x1000011F,
        CombatCastCurrentSpell = 0x10000060,
        PlayerOption_FilterLanguage = 0x10000120,
        CombatPrevSpell = 0x10000061,
        CombatNextSpell = 0x10000062,
        SelectionClosestUnopenedCorpse = 0x10000121,
        CombatPrevSpellTab = 0x10000063,
        SelectionNextUnopenedCorpse = 0x10000122,
        PlayerOption_ConfirmVolatileRareUse = 0x10000123,
        CombatNextSpellTab = 0x10000064,
        ToggleSquelchPanel = 0x10000124,
        UseSpellSlot_1 = 0x10000065,
        PlayerOption_HearSocietyChat = 0x10000125,
        UseSpellSlot_2 = 0x10000066,
        UseSpellSlot_3 = 0x10000067,
        ToggleQuestManagementPanel = 0x10000127,
        UseSpellSlot_4 = 0x10000068,
        ToggleJournalPanel = 0x10000128,
        UseSpellSlot_5 = 0x10000069,
        TogglePageListPanel = 0x10000129,
        UseSpellSlot_6 = 0x1000006A,
        PlayerOption_ShowHelm = 0x1000012A,
        UseSpellSlot_7 = 0x1000006B,
        UseSpellSlot_8 = 0x1000006C,
        PlayerOption_DisableDistanceFog = 0x1000012C,
        UseSpellSlot_9 = 0x1000006D,
        PlayerOption_UseMouseTurning = 0x1000012D,
        UseSpellSlot_10 = 0x1000006E,
        ToggleContractsPanel = 0x1000012E,
        UseSpellSlot_11 = 0x1000006F,
        PlayerOption_ShowCloak = 0x1000012F,
        UseSpellSlot_12 = 0x10000070,
        ToggleFloatingExaminationWindow = 0x10000130,
        PlayerOption_AutoRepeatAttack = 0x10000071,
        PlayerOption_IgnoreAllegianceRequests = 0x10000072,
        ToggleOptionsMenu = 0x10000131,
        PlayerOption_IgnoreFellowshipRequests = 0x10000073,
        UseQuickSlot_13 = 0x10000132,
        PlayerOption_IgnoreTradeRequests = 0x10000074,
        UseQuickSlot_14 = 0x10000133,
        PlayerOption_DisableMostWeatherEffects = 0x10000075,
        UseQuickSlot_15 = 0x10000134,
        PlayerOption_PersistentAtDay = 0x10000076,
        UseQuickSlot_16 = 0x10000135,
        PlayerOption_AllowGive = 0x10000077,
        UseQuickSlot_17 = 0x10000136,
        PlayerOption_ViewCombatTarget = 0x10000078,
        UseQuickSlot_18 = 0x10000137,
        PlayerOption_ShowTooltips = 0x10000079,
        SelectQuickSlot_13 = 0x10000138,
        PlayerOption_UseDeception = 0x1000007A,
        SelectQuickSlot_14 = 0x10000139,
        PlayerOption_ToggleRun = 0x1000007B,
        SelectQuickSlot_15 = 0x1000013A,
        PlayerOption_StayInChatMode = 0x1000007C,
        SelectQuickSlot_16 = 0x1000013B,
        PlayerOption_AdvancedCombatUI = 0x1000007D,
        SelectQuickSlot_17 = 0x1000013C,
        PlayerOption_AutoTarget = 0x1000007E,
        SelectQuickSlot_18 = 0x1000013D,
        PlayerOption_VividTargetingIndicator = 0x1000007F,
        PlayerOption_SideBySideVitals = 0x1000013E,
        PlayerOption_HearPKDeaths = 0x1000013F,
        PlayerOption_FellowshipShareXP = 0x10000080,
        PlayerOption_AcceptLootPermits = 0x10000081,
        PlayerOption_FellowshipShareLoot = 0x10000082,
        PlayerOption_FellowshipAutoAcceptRequests = 0x10000083,
        PlayerOption_CoordinatesOnRadar = 0x10000085,
        PlayerOption_SpellDuration = 0x10000086,
        PlayerOption_DisableHouseRestrictionEffects = 0x10000087,
        PlayerOption_DragItemOnPlayerOpensSecureTrade = 0x10000088,
        PlayerOption_DisplayAllegianceLogonNotifications = 0x10000089,
        PlayerOption_UseChargeAttack = 0x1000008A,
        PlayerOption_UseCraftSuccessDialog = 0x1000008B,
        PlayerOption_HearAllegianceChat = 0x1000008C,
        PlayerOption_DisplayDateOfBirth = 0x1000008D,
        PlayerOption_DisplayAge = 0x1000008E,
        PlayerOption_DisplayChessRank = 0x1000008F,
        PlayerOption_DisplayFishingSkill = 0x10000090,
        PlayerOption_DisplayNumberDeaths = 0x10000091,
    }
}