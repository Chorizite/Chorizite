using System;

namespace AcClient {
    public unsafe struct ClientCharGenState {
        // Struct:
        public CharGenState CharGenState;
        public Palette* grayFacePal;
        public Palette* trueFacePal;
        public Int32 trueFacePalChangeNum;
        public override string ToString() => $"CharGenState(CharGenState):{CharGenState}, grayFacePal:->(Palette*)0x{(Int32)grayFacePal:X8}, trueFacePal:->(Palette*)0x{(Int32)trueFacePal:X8}, trueFacePalChangeNum:{trueFacePalChangeNum}";


        // Functions:

        // ClientCharGenState.__Ctor:
        public static delegate* unmanaged[Thiscall]<ClientCharGenState*> __Ctor = (delegate* unmanaged[Thiscall]<ClientCharGenState*>)0x00564660; // .text:005638C0 ; void __thiscall ClientCharGenState::ClientCharGenState(ClientCharGenState *this) .text:005638C0 ??0ClientCharGenState@@QAE@XZ

        // ClientCharGenState.__Dtor:
        public static delegate* unmanaged[Thiscall]<ClientCharGenState*> __Dtor = (delegate* unmanaged[Thiscall]<ClientCharGenState*>)0x00564700; // .text:00563960 ; void __thiscall ClientCharGenState::~ClientCharGenState(ClientCharGenState *this) .text:00563960 ??1ClientCharGenState@@QAE@XZ

        // ClientCharGenState.GetColorFromPal:
        public static delegate* unmanaged[Thiscall]<ClientCharGenState*, UInt32, Int32, UInt32> GetColorFromPal = (delegate* unmanaged[Thiscall]<ClientCharGenState*, UInt32, Int32, UInt32>)0x00564730; // .text:00563990 ; UInt32 __thiscall ClientCharGenState::GetColorFromPal(ClientCharGenState *this, IDClass<_tagDataID,32,0> _palID, Int32 _colorNum) .text:00563990 ?GetColorFromPal@ClientCharGenState@@QAEKV?$IDClass@U_tagDataID@@$0CA@$0A@@@H@Z

        // ClientCharGenState.UpdateTrueFacePal:
        public static delegate* unmanaged[Thiscall]<ClientCharGenState*> UpdateTrueFacePal = (delegate* unmanaged[Thiscall]<ClientCharGenState*>)0x005647C0; // .text:00563A20 ; void __thiscall ClientCharGenState::UpdateTrueFacePal(ClientCharGenState *this) .text:00563A20 ?UpdateTrueFacePal@ClientCharGenState@@UAEXXZ
    }
    public unsafe struct CharGenState {
        // Struct:
        public Vtbl* vfptr;
        public ACCharGenResult CharGenResult;
        public Int32 beginRequest;
        public Int32 heritageGroupFrozen;
        public Int32 sexFrozen;
        public Int32 appearanceFrozen;
        public Int32 clothingFrozen;
        public UInt32 mHeritageGroup;
        public UInt32 mGender;
        public Int32 eyesStrip;
        public Int32 noseStrip;
        public Int32 mouthStrip;
        public Int32 hairColor;
        public Int32 eyeColor;
        public Int32 hairStyle;
        public Int32 headgearStyle;
        public Int32 headgearColor;
        public Int32 shirtStyle;
        public Int32 shirtColor;
        public Int32 trousersStyle;
        public Int32 trousersColor;
        public Int32 footwearStyle;
        public Int32 footwearColor;
        public Int32 numHeadgearColors;
        public Int32 numShirtColors;
        public Int32 numTrousersColors;
        public Int32 numFootwearColors;
        public UInt32* headgearPaletteTemplateIDs;
        public UInt32* shirtPaletteTemplateIDs;
        public UInt32* trousersPaletteTemplateIDs;
        public UInt32* footwearPaletteTemplateIDs;
        public UInt32* headgearPalSetIDs;
        public UInt32* shirtPalSetIDs;
        public UInt32* trousersPalSetIDs;
        public UInt32* footwearPalSetIDs;
        public Double skinShade;
        public Double hairShade;
        public Double headgearShade;
        public Double shirtShade;
        public Double trousersShade;
        public Double footwearShade;
        public Method_CG method;
        public AdvancedMethod_CG advancedMethod;
        public Int32 template_;
        public Int32 strength;
        public Int32 endurance;
        public Int32 coordination;
        public Int32 quickness;
        public Int32 focus;
        public Int32 self;
        public Int32 totalAtrbCredits;
        public Int32 remainingAtrbCredits;
        public Int32 atrbMin;
        public Int32 atrbMax;
        public Int32 totalNumSkills;
        public SKILL_ADVANCEMENT_CLASS* skillLevels;
        public Int32 totalSkillCredits;
        public Int32 remainingSkillCredits;
        public Int32* spellKnown;
        public _List<PTR<SkillRecord>> skillRecordList;
        public fixed Char name[33];
        public Int32 linkingWord;
        public Int32 startArea;
        public UInt32 setupID;
        public UInt32 animID;
        public Int32 setupChanged;
        public Int32 slot;
        public fixed Char password[20];
        public CG_VERIFICATION_RESPONSE verificationState;
        public Int32 createAsAdmin;
        public Int32 createAsEnvoy;
        public fixed Int32 bAttribLocked[7];
        public SkillTable* skillTable;
        public Attribute2ndTable* attribute2ndTable;
        public EnterChargen enterChargen;
        public ACCharGenData* CharGenData;
        public override string ToString() => $"vfptr:->(CharGenStateVtbl*)0x{(Int32)vfptr:X8}, CharGenResult(ACCharGenResult):{CharGenResult}, beginRequest:{beginRequest}, heritageGroupFrozen:{heritageGroupFrozen}, sexFrozen:{sexFrozen}, appearanceFrozen:{appearanceFrozen}, clothingFrozen:{clothingFrozen}, mHeritageGroup:{mHeritageGroup:X8}, mGender:{mGender:X8}, eyesStrip:{eyesStrip}, noseStrip:{noseStrip}, mouthStrip:{mouthStrip}, hairColor:{hairColor}, eyeColor:{eyeColor}, hairStyle:{hairStyle}, headgearStyle:{headgearStyle}, headgearColor:{headgearColor}, shirtStyle:{shirtStyle}, shirtColor:{shirtColor}, trousersStyle:{trousersStyle}, trousersColor:{trousersColor}, footwearStyle:{footwearStyle}, footwearColor:{footwearColor}, numHeadgearColors:{numHeadgearColors}, numShirtColors:{numShirtColors}, numTrousersColors:{numTrousersColors}, numFootwearColors:{numFootwearColors}, headgearPaletteTemplateIDs:->(UInt32*)0x{(Int32)headgearPaletteTemplateIDs:X8}, shirtPaletteTemplateIDs:->(UInt32*)0x{(Int32)shirtPaletteTemplateIDs:X8}, trousersPaletteTemplateIDs:->(UInt32*)0x{(Int32)trousersPaletteTemplateIDs:X8}, footwearPaletteTemplateIDs:->(UInt32*)0x{(Int32)footwearPaletteTemplateIDs:X8}, headgearPalSetIDs:->(UInt32*)0x{(Int32)headgearPalSetIDs:X8}, shirtPalSetIDs:->(UInt32*)0x{(Int32)shirtPalSetIDs:X8}, trousersPalSetIDs:->(UInt32*)0x{(Int32)trousersPalSetIDs:X8}, footwearPalSetIDs:->(UInt32*)0x{(Int32)footwearPalSetIDs:X8}, skinShade:{skinShade:n5}, hairShade:{hairShade:n5}, headgearShade:{headgearShade:n5}, shirtShade:{shirtShade:n5}, trousersShade:{trousersShade:n5}, footwearShade:{footwearShade:n5}, method(Method_CG):{method}, advancedMethod(AdvancedMethod_CG):{advancedMethod}, template_:{template_}, strength:{strength}, endurance:{endurance}, coordination:{coordination}, quickness:{quickness}, focus:{focus}, self:{self}, totalAtrbCredits:{totalAtrbCredits}, remainingAtrbCredits:{remainingAtrbCredits}, atrbMin:{atrbMin}, atrbMax:{atrbMax}, totalNumSkills:{totalNumSkills}, skillLevels:->(SKILL_ADVANCEMENT_CLASS*)0x{(Int32)skillLevels:X8}, totalSkillCredits:{totalSkillCredits}, remainingSkillCredits:{remainingSkillCredits}, spellKnown:->(Int32*)0x{(Int32)spellKnown:X8}, skillRecordList(List<SkillRecord*>):{skillRecordList}, name[33]:{name[33]}, linkingWord:{linkingWord}, startArea:{startArea}, setupID:{setupID:X8}, animID:{animID:X8}, setupChanged:{setupChanged}, slot:{slot}, password[20]:{password[20]}, verificationState(CG_VERIFICATION_RESPONSE):{verificationState}, createAsAdmin:{createAsAdmin}, createAsEnvoy:{createAsEnvoy}, bAttribLocked[7]:{bAttribLocked[7]}, skillTable:->(SkillTable*)0x{(Int32)skillTable:X8}, attribute2ndTable:->(Attribute2ndTable*)0x{(Int32)attribute2ndTable:X8}, enterChargen(EnterChargen):{enterChargen}, CharGenData:->(ACCharGenData*)0x{(Int32)CharGenData:X8}";

        public unsafe struct Vtbl {
            // Struct:
            public static delegate* unmanaged[Thiscall]<CharGenState*> UpdateTrueFacePal; //   void (__thiscall *UpdateTrueFacePal)(CharGenState *this);
            public static delegate* unmanaged[Thiscall]<CharGenState*, Double> GetRandomReal; //   long Double (__thiscall *GetRandomReal)(CharGenState *this);
        }

        // Functions:

        // CharGenState.SetCoordination:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32> SetCoordination = (delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32>)0xDEADBEEF; // .text:005C4760 ; Int32 __thiscall CharGenState::SetCoordination(CharGenState *this, Int32 _coordination, Int32 _balance) .text:005C4760 ?SetCoordination@CharGenState@@QAEHHH@Z

        // CharGenState.GetBaldState:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32> GetBaldState = (delegate* unmanaged[Thiscall]<CharGenState*, Int32>)0x005C6280; // .text:005C52A0 ; Int32 __thiscall CharGenState::GetBaldState(CharGenState *this) .text:005C52A0 ?GetBaldState@CharGenState@@QAEHXZ

        // CharGenState.RandomizeFootwear:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> RandomizeFootwear = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C6070 ; void __thiscall CharGenState::RandomizeFootwear(CharGenState *this) .text:005C6070 ?RandomizeFootwear@CharGenState@@QAEXXZ

        // CharGenState.SetHeritageGroup:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32> SetHeritageGroup = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32>)0xDEADBEEF; // .text:005C67A0 ; void __thiscall CharGenState::SetHeritageGroup(CharGenState *this, UInt32 heritageGroup) .text:005C67A0 ?SetHeritageGroup@CharGenState@@QAEXK@Z

        // CharGenState.RandomizeCharacter:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Byte> RandomizeCharacter = (delegate* unmanaged[Thiscall]<CharGenState*, Byte>)0x005C7D60; // .text:005C6D80 ; void __thiscall CharGenState::RandomizeCharacter(CharGenState *this, bool hasThroneOfDestiny) .text:005C6D80 ?RandomizeCharacter@CharGenState@@QAEX_N@Z

        // CharGenState.SetSkillLevel:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32,SKILL_ADVANCEMENT_CLASS, Int32> SetSkillLevel = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32,SKILL_ADVANCEMENT_CLASS, Int32>)0xDEADBEEF; // .text:005C3C20 ; Int32 __thiscall CharGenState::SetSkillLevel(CharGenState *this, UInt32 _skillNum, SKILL_ADVANCEMENT_CLASS _skillLevel) .text:005C3C20 ?SetSkillLevel@CharGenState@@QAEHKW4SKILL_ADVANCEMENT_CLASS@@@Z

        // CharGenState.ApplyTemplate:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> ApplyTemplate = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C5080 ; void __thiscall CharGenState::ApplyTemplate(CharGenState *this) .text:005C5080 ?ApplyTemplate@CharGenState@@QAEXXZ

        // CharGenState.Reset:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> Reset = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C68A0 ; void __thiscall CharGenState::Reset(CharGenState *this) .text:005C68A0 ?Reset@CharGenState@@QAEXXZ

        // CharGenState.GetAttributeName:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32,Char*> GetAttributeName = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32,Char*>)0xDEADBEEF; // .text:005C3A20 ; void __thiscall CharGenState::GetAttributeName(CharGenState *this, UInt32 _attr, Char *o_string) .text:005C3A20 ?GetAttributeName@CharGenState@@QAEXKPAD@Z

        // CharGenState.SetName:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Char*> SetName = (delegate* unmanaged[Thiscall]<CharGenState*,Char*>)0xDEADBEEF; // .text:005C3D10 ; void __thiscall CharGenState::SetName(CharGenState *this, const Char *_name) .text:005C3D10 ?SetName@CharGenState@@QAEXPBD@Z

        // CharGenState.GetTrousersPalSetID:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32*,Int32, UInt32*> GetTrousersPalSetID = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32*,Int32, UInt32*>)0xDEADBEEF; // .text:005C3DB0 ; IDClass<_tagDataID,32,0> *__thiscall CharGenState::GetTrousersPalSetID(CharGenState *this, IDClass<_tagDataID,32,0> *result, Int32 _num) .text:005C3DB0 ?GetTrousersPalSetID@CharGenState@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@H@Z

        // CharGenState.SetQuickness:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32> SetQuickness = (delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32>)0xDEADBEEF; // .text:005C47E0 ; Int32 __thiscall CharGenState::SetQuickness(CharGenState *this, Int32 _quickness, Int32 _balance) .text:005C47E0 ?SetQuickness@CharGenState@@QAEHHH@Z

        // CharGenState.SetFootwearStyle:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32, Int32> SetFootwearStyle = (delegate* unmanaged[Thiscall]<CharGenState*,Int32, Int32>)0xDEADBEEF; // .text:005C56C0 ; Int32 __thiscall CharGenState::SetFootwearStyle(CharGenState *this, Int32 _footwearStyle) .text:005C56C0 ?SetFootwearStyle@CharGenState@@QAEHH@Z

        // CharGenState.SetTemplate:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32> SetTemplate = (delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32>)0xDEADBEEF; // .text:005C5A60 ; Int32 __thiscall CharGenState::SetTemplate(CharGenState *this, Int32 _template, Int32 _apply) .text:005C5A60 ?SetTemplate@CharGenState@@QAEHHH@Z

        // CharGenState.RandomizeTemplate:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> RandomizeTemplate = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C6500 ; void __thiscall CharGenState::RandomizeTemplate(CharGenState *this) .text:005C6500 ?RandomizeTemplate@CharGenState@@QAEXXZ

        // CharGenState.GetRandomReal:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Double> GetRandomReal = (delegate* unmanaged[Thiscall]<CharGenState*, Double>)0x005646E0; // .text:00563940 ; long Double __thiscall CharGenState::GetRandomReal(CharGenState *this) .text:00563940 ?GetRandomReal@CharGenState@@MBENXZ

        // CharGenState.SetSkinShade:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Double, Double> SetSkinShade = (delegate* unmanaged[Thiscall]<CharGenState*, Double, Double>)0x005C4830; // .text:005C3850 ; long Double __thiscall CharGenState::SetSkinShade(CharGenState *this, long Double _skinShade) .text:005C3850 ?SetSkinShade@CharGenState@@QAENN@Z

        // CharGenState.GetAttribute:
        public static delegate* unmanaged[Thiscall]<CharGenState*, UInt32, Int32> GetAttribute = (delegate* unmanaged[Thiscall]<CharGenState*, UInt32, Int32>)0x005C4990; // .text:005C39B0 ; Int32 __thiscall CharGenState::GetAttribute(CharGenState *this, UInt32 _attr) .text:005C39B0 ?GetAttribute@CharGenState@@QAEHK@Z

        // CharGenState.GetCharGenResult:
        // public static delegate* unmanaged[Thiscall]<CharGenState*, ACCharGenResult*> GetCharGenResult = (delegate* unmanaged[Thiscall]<CharGenState*, ACCharGenResult*>)0xDEADBEEF; // .text:005C4030 ; ACCharGenResult *__thiscall CharGenState::GetCharGenResult(CharGenState *this) .text:005C4030 ?GetCharGenResult@CharGenState@@QAEPAVACCharGenResult@@XZ

        // CharGenState.SetSelf:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32> SetSelf = (delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32>)0xDEADBEEF; // .text:005C48E0 ; Int32 __thiscall CharGenState::SetSelf(CharGenState *this, Int32 _self, Int32 _balance) .text:005C48E0 ?SetSelf@CharGenState@@QAEHHH@Z

        // CharGenState.RandomizeClothing:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32> RandomizeClothing = (delegate* unmanaged[Thiscall]<CharGenState*,Int32>)0xDEADBEEF; // .text:005C6770 ; void __thiscall CharGenState::RandomizeClothing(CharGenState *this, Int32 _excludeCurrent) .text:005C6770 ?RandomizeClothing@CharGenState@@QAEXH@Z

        // CharGenState.GetFootwearPalSetID:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32*,Int32, UInt32*> GetFootwearPalSetID = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32*,Int32, UInt32*>)0xDEADBEEF; // .text:005C3DD0 ; IDClass<_tagDataID,32,0> *__thiscall CharGenState::GetFootwearPalSetID(CharGenState *this, IDClass<_tagDataID,32,0> *result, Int32 _num) .text:005C3DD0 ?GetFootwearPalSetID@CharGenState@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@H@Z

        // CharGenState.ResetSkillLevels:
        public static delegate* unmanaged[Thiscall]<CharGenState*> ResetSkillLevels = (delegate* unmanaged[Thiscall]<CharGenState*>)0x005C5390; // .text:005C43B0 ; void __thiscall CharGenState::ResetSkillLevels(CharGenState *this) .text:005C43B0 ?ResetSkillLevels@CharGenState@@QAEXXZ

        // CharGenState.FitTemplateToCharacter:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> FitTemplateToCharacter = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C6130 ; void __thiscall CharGenState::FitTemplateToCharacter(CharGenState *this) .text:005C6130 ?FitTemplateToCharacter@CharGenState@@QAEXXZ

        // CharGenState.GetFootwearPaletteTemplateID:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32, UInt32> GetFootwearPaletteTemplateID = (delegate* unmanaged[Thiscall]<CharGenState*, Int32, UInt32>)0x005C4960; // .text:005C3980 ; UInt32 __thiscall CharGenState::GetFootwearPaletteTemplateID(CharGenState *this, Int32 _num) .text:005C3980 ?GetFootwearPaletteTemplateID@CharGenState@@QAEKH@Z

        // CharGenState.SetSlot:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32> SetSlot = (delegate* unmanaged[Thiscall]<CharGenState*, Int32>)0x005C4D40; // .text:005C3D60 ; void __thiscall CharGenState::SetSlot(CharGenState *this, Int32 _slot) .text:005C3D60 ?SetSlot@CharGenState@@QAEXH@Z

        // CharGenState.BalanceAttributes:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32> BalanceAttributes = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32>)0xDEADBEEF; // .text:005C3DF0 ; void __thiscall CharGenState::BalanceAttributes(CharGenState *this, UInt32 _fixedAtrb) .text:005C3DF0 ?BalanceAttributes@CharGenState@@QAEXK@Z

        // CharGenState.SetHeadgearStyle:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32, Int32> SetHeadgearStyle = (delegate* unmanaged[Thiscall]<CharGenState*,Int32, Int32>)0xDEADBEEF; // .text:005C5350 ; Int32 __thiscall CharGenState::SetHeadgearStyle(CharGenState *this, Int32 _headgearStyle) .text:005C5350 ?SetHeadgearStyle@CharGenState@@QAEHH@Z

        // CharGenState.RandomizeStartArea:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> RandomizeStartArea = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C59E0 ; void __thiscall CharGenState::RandomizeStartArea(CharGenState *this) .text:005C59E0 ?RandomizeStartArea@CharGenState@@QAEXXZ

        // CharGenState.ResetAttributeLock:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> ResetAttributeLock = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C3BC0 ; void __thiscall CharGenState::ResetAttributeLock(CharGenState *this) .text:005C3BC0 ?ResetAttributeLock@CharGenState@@QAEXXZ

        // CharGenState.SetHairColor:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32, Int32> SetHairColor = (delegate* unmanaged[Thiscall]<CharGenState*, Int32, Int32>)0x005C4890; // .text:005C38B0 ; Int32 __thiscall CharGenState::SetHairColor(CharGenState *this, Int32 _hairColor) .text:005C38B0 ?SetHairColor@CharGenState@@QAEHH@Z

        // CharGenState.RandomizeShirt:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> RandomizeShirt = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C5EF0 ; void __thiscall CharGenState::RandomizeShirt(CharGenState *this) .text:005C5EF0 ?RandomizeShirt@CharGenState@@QAEXXZ

        // CharGenState.ConstrainAllByGender:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> ConstrainAllByGender = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C5B80 ; void __thiscall CharGenState::ConstrainAllByGender(CharGenState *this) .text:005C5B80 ?ConstrainAllByGender@CharGenState@@QAEXXZ

        // CharGenState.ConstrainAllByHeritage:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> ConstrainAllByHeritage = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C6590 ; void __thiscall CharGenState::ConstrainAllByHeritage(CharGenState *this) .text:005C6590 ?ConstrainAllByHeritage@CharGenState@@QAEXXZ

        // CharGenState.__Ctor:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> __Ctor = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C6A50 ; void __thiscall CharGenState::CharGenState(CharGenState *this) .text:005C6A50 ??0CharGenState@@IAE@XZ

        // CharGenState.SetVerificationState:
        public static delegate* unmanaged[Thiscall]<CharGenState*, CG_VERIFICATION_RESPONSE> SetVerificationState = (delegate* unmanaged[Thiscall]<CharGenState*, CG_VERIFICATION_RESPONSE>)0x005C4780; // .text:005C37A0 ; void __thiscall CharGenState::SetVerificationState(CharGenState *this, CG_VERIFICATION_RESPONSE _verificationState) .text:005C37A0 ?SetVerificationState@CharGenState@@QAEXW4CG_VERIFICATION_RESPONSE@@@Z

        // CharGenState.GetVerificationState:
        public static delegate* unmanaged[Thiscall]<CharGenState*, CG_VERIFICATION_RESPONSE> GetVerificationState = (delegate* unmanaged[Thiscall]<CharGenState*, CG_VERIFICATION_RESPONSE>)0x005C4790; // .text:005C37B0 ; CG_VERIFICATION_RESPONSE __thiscall CharGenState::GetVerificationState(CharGenState *this) .text:005C37B0 ?GetVerificationState@CharGenState@@QAE?AW4CG_VERIFICATION_RESPONSE@@XZ

        // CharGenState.GetTrousersPaletteTemplateID:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32, UInt32> GetTrousersPaletteTemplateID = (delegate* unmanaged[Thiscall]<CharGenState*, Int32, UInt32>)0x005C4930; // .text:005C3950 ; UInt32 __thiscall CharGenState::GetTrousersPaletteTemplateID(CharGenState *this, Int32 _num) .text:005C3950 ?GetTrousersPaletteTemplateID@CharGenState@@QAEKH@Z

        // CharGenState.SetFocus:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32> SetFocus = (delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32>)0xDEADBEEF; // .text:005C4860 ; Int32 __thiscall CharGenState::SetFocus(CharGenState *this, Int32 _focus, Int32 _balance) .text:005C4860 ?SetFocus@CharGenState@@QAEHHH@Z

        // CharGenState.GetSetupID:
        public static delegate* unmanaged[Thiscall]<CharGenState*, UInt32*, UInt32*> GetSetupID = (delegate* unmanaged[Thiscall]<CharGenState*, UInt32*, UInt32*>)0x005C6A70; // .text:005C5A90 ; IDClass<_tagDataID,32,0> *__thiscall CharGenState::GetSetupID(CharGenState *this, IDClass<_tagDataID,32,0> *result) .text:005C5A90 ?GetSetupID@CharGenState@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // CharGenState.UpdateRemainingSkillCredits:
        public static delegate* unmanaged[Thiscall]<CharGenState*> UpdateRemainingSkillCredits = (delegate* unmanaged[Thiscall]<CharGenState*>)0x005C47A0; // .text:005C37C0 ; void __thiscall CharGenState::UpdateRemainingSkillCredits(CharGenState *this) .text:005C37C0 ?UpdateRemainingSkillCredits@CharGenState@@QAEXXZ

        // CharGenState.SetHairShade:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Double, Double> SetHairShade = (delegate* unmanaged[Thiscall]<CharGenState*, Double, Double>)0x005C4860; // .text:005C3880 ; long Double __thiscall CharGenState::SetHairShade(CharGenState *this, long Double _hairShade) .text:005C3880 ?SetHairShade@CharGenState@@QAENN@Z

        // CharGenState.GetSkillLevel:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32, SKILL_ADVANCEMENT_CLASS> GetSkillLevel = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32, SKILL_ADVANCEMENT_CLASS>)0xDEADBEEF; // .text:005C3C00 ; SKILL_ADVANCEMENT_CLASS __thiscall CharGenState::GetSkillLevel(CharGenState *this, UInt32 skill) .text:005C3C00 ?GetSkillLevel@CharGenState@@QAE?AW4SKILL_ADVANCEMENT_CLASS@@K@Z

        // CharGenState.GetHeadgearPalSetID:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32*,Int32, UInt32*> GetHeadgearPalSetID = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32*,Int32, UInt32*>)0xDEADBEEF; // .text:005C3D70 ; IDClass<_tagDataID,32,0> *__thiscall CharGenState::GetHeadgearPalSetID(CharGenState *this, IDClass<_tagDataID,32,0> *result, Int32 _num) .text:005C3D70 ?GetHeadgearPalSetID@CharGenState@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@H@Z

        // CharGenState.GetSkillScore:
        public static delegate* unmanaged[Thiscall]<CharGenState*, UInt32, Int32> GetSkillScore = (delegate* unmanaged[Thiscall]<CharGenState*, UInt32, Int32>)0x005C5B30; // .text:005C4B50 ; Int32 __thiscall CharGenState::GetSkillScore(CharGenState *this, UInt32 skill) .text:005C4B50 ?GetSkillScore@CharGenState@@QAEHK@Z

        // CharGenState.RandomizeTrousers:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> RandomizeTrousers = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C5FB0 ; void __thiscall CharGenState::RandomizeTrousers(CharGenState *this) .text:005C5FB0 ?RandomizeTrousers@CharGenState@@QAEXXZ

        // CharGenState.SetGender:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32> SetGender = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32>)0xDEADBEEF; // .text:005C64A0 ; void __thiscall CharGenState::SetGender(CharGenState *this, UInt32 gender) .text:005C64A0 ?SetGender@CharGenState@@QAEXK@Z

        // CharGenState.GetShirtPaletteTemplateID:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32, UInt32> GetShirtPaletteTemplateID = (delegate* unmanaged[Thiscall]<CharGenState*, Int32, UInt32>)0x005C4900; // .text:005C3920 ; UInt32 __thiscall CharGenState::GetShirtPaletteTemplateID(CharGenState *this, Int32 _num) .text:005C3920 ?GetShirtPaletteTemplateID@CharGenState@@QAEKH@Z

        // CharGenState.LockAttribute:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32,Int32> LockAttribute = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32,Int32>)0xDEADBEEF; // .text:005C3BE0 ; void __thiscall CharGenState::LockAttribute(CharGenState *this, UInt32 _attr, Int32 _lock) .text:005C3BE0 ?LockAttribute@CharGenState@@QAEXKH@Z

        // CharGenState.__Dtor:
        public static delegate* unmanaged[Thiscall]<CharGenState*> __Dtor = (delegate* unmanaged[Thiscall]<CharGenState*>)0x005C5DB0; // .text:005C4DD0 ; void __thiscall CharGenState::~CharGenState(CharGenState *this) .text:005C4DD0 ??1CharGenState@@IAE@XZ

        // CharGenState.SetShirtStyle:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32, Int32> SetShirtStyle = (delegate* unmanaged[Thiscall]<CharGenState*,Int32, Int32>)0xDEADBEEF; // .text:005C5480 ; Int32 __thiscall CharGenState::SetShirtStyle(CharGenState *this, Int32 _shirtStyle) .text:005C5480 ?SetShirtStyle@CharGenState@@QAEHH@Z

        // CharGenState.SetTrousersStyle:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32, Int32> SetTrousersStyle = (delegate* unmanaged[Thiscall]<CharGenState*,Int32, Int32>)0xDEADBEEF; // .text:005C55A0 ; Int32 __thiscall CharGenState::SetTrousersStyle(CharGenState *this, Int32 _trousersStyle) .text:005C55A0 ?SetTrousersStyle@CharGenState@@QAEHH@Z

        // CharGenState.GetRandomInt:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32, Int32, Int32> GetRandomInt = (delegate* unmanaged[Thiscall]<CharGenState*, Int32, Int32, Int32>)0x005646C0; // .text:00563920 ; Int32 __thiscall CharGenState::GetRandomInt(CharGenState *this, Int32 range, Int32 exclude) .text:00563920 ?GetRandomInt@CharGenState@@MBEHHH@Z

        // CharGenState.SetEndurance:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32> SetEndurance = (delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32>)0xDEADBEEF; // .text:005C46E0 ; Int32 __thiscall CharGenState::SetEndurance(CharGenState *this, Int32 _endurance, Int32 _balance) .text:005C46E0 ?SetEndurance@CharGenState@@QAEHHH@Z

        // CharGenState.GetRandomInt:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32, Int32> GetRandomInt_ = (delegate* unmanaged[Thiscall]<CharGenState*, Int32, Int32>)0x005646B0; // .text:00563910 ; Int32 __thiscall CharGenState::GetRandomInt(CharGenState *this, Int32 range) .text:00563910 ?GetRandomInt@CharGenState@@MBEHH@Z

        // CharGenState.SetEyeColor:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32, Int32> SetEyeColor = (delegate* unmanaged[Thiscall]<CharGenState*, Int32, Int32>)0x005C48B0; // .text:005C38D0 ; Int32 __thiscall CharGenState::SetEyeColor(CharGenState *this, Int32 _eyeColor) .text:005C38D0 ?SetEyeColor@CharGenState@@QAEHH@Z

        // CharGenState.GetShirtPalSetID:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32*,Int32, UInt32*> GetShirtPalSetID = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32*,Int32, UInt32*>)0xDEADBEEF; // .text:005C3D90 ; IDClass<_tagDataID,32,0> *__thiscall CharGenState::GetShirtPalSetID(CharGenState *this, IDClass<_tagDataID,32,0> *result, Int32 _num) .text:005C3D90 ?GetShirtPalSetID@CharGenState@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@H@Z

        // CharGenState.SetStartArea:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32> SetStartArea = (delegate* unmanaged[Thiscall]<CharGenState*,Int32>)0xDEADBEEF; // .text:005C4000 ; void __thiscall CharGenState::SetStartArea(CharGenState *this, Int32 _startArea) .text:005C4000 ?SetStartArea@CharGenState@@QAEXH@Z

        // CharGenState.StoreColorInformation:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,UInt32,Int32*,UInt32**,UInt32**,Sex_CG*> StoreColorInformation = (delegate* unmanaged[Thiscall]<CharGenState*,UInt32,Int32*,UInt32**,UInt32**,Sex_CG*>)0xDEADBEEF; // .text:005C44D0 ; void __thiscall CharGenState::StoreColorInformation(CharGenState *this, IDClass<_tagDataID,32,0> _clothingTableID, Int32 *_numColors, UInt32 **_paletteTemplateIDs, IDClass<_tagDataID,32,0> **_palSetIDs, Sex_CG *_curSX) .text:005C44D0 ?StoreColorInformation@CharGenState@@IAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAHAAPAKAAPAV2@AAVSex_CG@@@Z

        // CharGenState.SetStrength:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32> SetStrength = (delegate* unmanaged[Thiscall]<CharGenState*,Int32,Int32, Int32>)0xDEADBEEF; // .text:005C4660 ; Int32 __thiscall CharGenState::SetStrength(CharGenState *this, Int32 _strength, Int32 _balance) .text:005C4660 ?SetStrength@CharGenState@@QAEHHH@Z

        // CharGenState.ApplyDefaultTemplate:
        public static delegate* unmanaged[Thiscall]<CharGenState*> ApplyDefaultTemplate = (delegate* unmanaged[Thiscall]<CharGenState*>)0x005C5970; // .text:005C4990 ; void __thiscall CharGenState::ApplyDefaultTemplate(CharGenState *this) .text:005C4990 ?ApplyDefaultTemplate@CharGenState@@QAEXXZ

        // CharGenState.RandomizeAppearance:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32> RandomizeAppearance = (delegate* unmanaged[Thiscall]<CharGenState*,Int32>)0xDEADBEEF; // .text:005C4F10 ; void __thiscall CharGenState::RandomizeAppearance(CharGenState *this, Int32 restrict_hair) .text:005C4F10 ?RandomizeAppearance@CharGenState@@QAEXH@Z

        // CharGenState.RandomizeSkills:
        // public static delegate* unmanaged[Thiscall]<CharGenState*> RandomizeSkills = (delegate* unmanaged[Thiscall]<CharGenState*>)0xDEADBEEF; // .text:005C57E0 ; void __thiscall CharGenState::RandomizeSkills(CharGenState *this) .text:005C57E0 ?RandomizeSkills@CharGenState@@QAEXXZ

        // CharGenState.RandomizeHeadgear:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Int32> RandomizeHeadgear = (delegate* unmanaged[Thiscall]<CharGenState*,Int32>)0xDEADBEEF; // .text:005C5E10 ; void __thiscall CharGenState::RandomizeHeadgear(CharGenState *this, Int32 _excludeCurrent) .text:005C5E10 ?RandomizeHeadgear@CharGenState@@QAEXH@Z

        // CharGenState.GetHeadgearPaletteTemplateID:
        public static delegate* unmanaged[Thiscall]<CharGenState*, Int32, UInt32> GetHeadgearPaletteTemplateID = (delegate* unmanaged[Thiscall]<CharGenState*, Int32, UInt32>)0x005C48D0; // .text:005C38F0 ; UInt32 __thiscall CharGenState::GetHeadgearPaletteTemplateID(CharGenState *this, Int32 _num) .text:005C38F0 ?GetHeadgearPaletteTemplateID@CharGenState@@QAEKH@Z

        // CharGenState.GetAbsRemainingCredits:
        public static delegate* unmanaged[Thiscall]<CharGenState*, UInt32, Int32> GetAbsRemainingCredits = (delegate* unmanaged[Thiscall]<CharGenState*, UInt32, Int32>)0x005C4B00; // .text:005C3B20 ; Int32 __thiscall CharGenState::GetAbsRemainingCredits(CharGenState *this, UInt32 _curAtrb) .text:005C3B20 ?GetAbsRemainingCredits@CharGenState@@QAEHK@Z

        // CharGenState.RandomizeHeritageGroup:
        // public static delegate* unmanaged[Thiscall]<CharGenState*,Byte> RandomizeHeritageGroup = (delegate* unmanaged[Thiscall]<CharGenState*,Byte>)0xDEADBEEF; // .text:005C6A20 ; void __thiscall CharGenState::RandomizeHeritageGroup(CharGenState *this, bool hasThroneOfDestiny) .text:005C6A20 ?RandomizeHeritageGroup@CharGenState@@QAEX_N@Z
    }
    public unsafe struct ACCharGenData {
        // Struct:
        public CharGenData CharGenData;
        public SmartArray<ACCharGenStartArea> mStartAreaList;
        public HashTable<UInt32, HeritageGroup_CG> mHeritageGroupList;
        public override string ToString() => $"CharGenData(CharGenData):{CharGenData}, mStartAreaList(SmartArray<ACCharGenStartArea,1>):{mStartAreaList}, mHeritageGroupList(HashTable<UInt32,HeritageGroup_CG,0>):{mHeritageGroupList}";


        // Functions:

        // ACCharGenData.__scaDelDtor:
        public static delegate* unmanaged[Thiscall]<ACCharGenData*, UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<ACCharGenData*, UInt32, void*>)0x005C4760; // .text:005C3780 ; void *__thiscall ACCharGenData::`scalar deleting destructor'(ACCharGenData *this, UInt32) .text:005C3780 ??_GACCharGenData@@UAEPAXI@Z

        // ACCharGenData.FormatName:
        public static delegate* unmanaged[Cdecl]<Char*> FormatName = (delegate* unmanaged[Cdecl]<Char*>)0x005BE6A0; // .text:005BD5D0 ; void __cdecl ACCharGenData::FormatName(Char *_name) .text:005BD5D0 ?FormatName@ACCharGenData@@SAXPAD@Z

        // ACCharGenData.GetHG:
        public static delegate* unmanaged[Thiscall]<ACCharGenData*, HeritageGroup_CG*, UInt32, HeritageGroup_CG*> GetHG = (delegate* unmanaged[Thiscall]<ACCharGenData*, HeritageGroup_CG*, UInt32, HeritageGroup_CG*>)0x005C3380; // .text:005C23A0 ; HeritageGroup_CG *__thiscall ACCharGenData::GetHG(ACCharGenData *this, HeritageGroup_CG *result, UInt32 heritage) .text:005C23A0 ?GetHG@ACCharGenData@@QBE?BVHeritageGroup_CG@@K@Z

        // ACCharGenData.GetSkillTrainedCost:
        public static delegate* unmanaged[Thiscall]<ACCharGenData*, Int32, UInt32, UInt32, Int32> GetSkillTrainedCost = (delegate* unmanaged[Thiscall]<ACCharGenData*, Int32, UInt32, UInt32, Int32>)0x005C36B0; // .text:005C26D0 ; Int32 __thiscall ACCharGenData::GetSkillTrainedCost(ACCharGenData *this, Int32 _skillID, UInt32 heritage, UInt32 gender) .text:005C26D0 ?GetSkillTrainedCost@ACCharGenData@@QBEHHKK@Z

        // ACCharGenData.GetEyeStripIndexFromID:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Byte,Byte, UInt32> GetEyeStripIndexFromID = (delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Byte,Byte, UInt32>)0xDEADBEEF; // .text:005C2F00 ; UInt32 __thiscall ACCharGenData::GetEyeStripIndexFromID(ACCharGenData *this, const UInt32 heritage, const UInt32 gender, IDClass<_tagDataID,32,0> id, const bool use_alternate_texture, const bool bald) .text:005C2F00 ?GetEyeStripIndexFromID@ACCharGenData@@QAEKKKV?$IDClass@U_tagDataID@@$0CA@$0A@@@_N1@Z

        // ACCharGenData.GetMouthStripIndexFromID:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Byte, UInt32> GetMouthStripIndexFromID = (delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Byte, UInt32>)0xDEADBEEF; // .text:005C3190 ; UInt32 __thiscall ACCharGenData::GetMouthStripIndexFromID(ACCharGenData *this, const UInt32 heritage, const UInt32 gender, IDClass<_tagDataID,32,0> id, const bool use_alternate_texture) .text:005C3190 ?GetMouthStripIndexFromID@ACCharGenData@@QAEKKKV?$IDClass@U_tagDataID@@$0CA@$0A@@@_N@Z

        // ACCharGenData.GetEyeColorFromID:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,UInt32*> GetEyeColorFromID = (delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,UInt32*>)0xDEADBEEF; // .text:005C3500 ; void __thiscall ACCharGenData::GetEyeColorFromID(ACCharGenData *this, const UInt32 heritage, const UInt32 gender, IDClass<_tagDataID,32,0> id, UInt32 *color) .text:005C3500 ?GetEyeColorFromID@ACCharGenData@@QAEXKKV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAK@Z

        // ACCharGenData.Serialize:
        public static delegate* unmanaged[Thiscall]<ACCharGenData*, Archive*> Serialize = (delegate* unmanaged[Thiscall]<ACCharGenData*, Archive*>)0x005C46B0; // .text:005C36D0 ; void __thiscall ACCharGenData::Serialize(ACCharGenData *this, Archive *io_archive) .text:005C36D0 ?Serialize@ACCharGenData@@UAEXAAVArchive@@@Z

        // ACCharGenData.Allocator:
        // (ERR) .text:0058B690 ; public: static class DBObj * __cdecl ACCharGenData::Allocator(void) .text:0058B690 ?Allocator@ACCharGenData@@SAPAVDBObj@@XZ

        // ACCharGenData.GetStartingPosition:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,CharGenResult*,Position*, Int32> GetStartingPosition = (delegate* unmanaged[Thiscall]<ACCharGenData*,CharGenResult*,Position*, Int32>)0xDEADBEEF; // .text:005C1380 ; Int32 __thiscall ACCharGenData::GetStartingPosition(ACCharGenData *this, CharGenResult *cgr, Position *pos) .text:005C1380 ?GetStartingPosition@ACCharGenData@@UBEHABVCharGenResult@@AAVPosition@@@Z

        // ACCharGenData.GenerateBaseAppearanceData:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,ACCharGenResult*,CharAppearanceData*,ObjDesc*, Int32> GenerateBaseAppearanceData = (delegate* unmanaged[Thiscall]<ACCharGenData*,ACCharGenResult*,CharAppearanceData*,ObjDesc*, Int32>)0xDEADBEEF; // .text:005C28D0 ; Int32 __thiscall ACCharGenData::GenerateBaseAppearanceData(ACCharGenData *this, ACCharGenResult *_cgr, CharAppearanceData *_cad, ObjDesc *_objDesc) .text:005C28D0 ?GenerateBaseAppearanceData@ACCharGenData@@QBEHABVACCharGenResult@@AAVCharAppearanceData@@AAVObjDesc@@@Z

        // ACCharGenData.GetSkinShadeFromID:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Double*> GetSkinShadeFromID = (delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Double*>)0xDEADBEEF; // .text:005C32B0 ; void __thiscall ACCharGenData::GetSkinShadeFromID(ACCharGenData *this, const UInt32 heritage, const UInt32 gender, IDClass<_tagDataID,32,0> id, long Double *shade) .text:005C32B0 ?GetSkinShadeFromID@ACCharGenData@@QAEXKKV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAN@Z

        // ACCharGenData.GetHairIndexFromID:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Byte, UInt32> GetHairIndexFromID = (delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Byte, UInt32>)0xDEADBEEF; // .text:005C2DD0 ; UInt32 __thiscall ACCharGenData::GetHairIndexFromID(ACCharGenData *this, const UInt32 heritage, const UInt32 gender, IDClass<_tagDataID,32,0> id, const bool bald) .text:005C2DD0 ?GetHairIndexFromID@ACCharGenData@@QAEKKKV?$IDClass@U_tagDataID@@$0CA@$0A@@@_N@Z

        // ACCharGenData.GetNoseStripIndexFromID:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Byte, UInt32> GetNoseStripIndexFromID = (delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,Byte, UInt32>)0xDEADBEEF; // .text:005C3070 ; UInt32 __thiscall ACCharGenData::GetNoseStripIndexFromID(ACCharGenData *this, const UInt32 heritage, const UInt32 gender, IDClass<_tagDataID,32,0> id, const bool use_alternate_texture) .text:005C3070 ?GetNoseStripIndexFromID@ACCharGenData@@QAEKKKV?$IDClass@U_tagDataID@@$0CA@$0A@@@_N@Z

        // ACCharGenData.GetHairColorFromID:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,UInt32*,Double*> GetHairColorFromID = (delegate* unmanaged[Thiscall]<ACCharGenData*,UInt32,UInt32,UInt32,UInt32*,Double*>)0xDEADBEEF; // .text:005C33A0 ; void __thiscall ACCharGenData::GetHairColorFromID(ACCharGenData *this, const UInt32 heritage, const UInt32 gender, IDClass<_tagDataID,32,0> id, UInt32 *color, long Double *shade) .text:005C33A0 ?GetHairColorFromID@ACCharGenData@@QAEXKKV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAKAAN@Z

        // ACCharGenData.__Dtor:
        public static delegate* unmanaged[Thiscall]<ACCharGenData*> __Dtor = (delegate* unmanaged[Thiscall]<ACCharGenData*>)0x005C4620; // .text:005C3640 ; void __thiscall ACCharGenData::~ACCharGenData(ACCharGenData *this) .text:005C3640 ??1ACCharGenData@@UAE@XZ

        // ACCharGenData.Allocate:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*, DBObj*> Allocate = (delegate* unmanaged[Thiscall]<ACCharGenData*, DBObj*>)0xDEADBEEF; // .text:005C3770 ; DBObj *__thiscall ACCharGenData::Allocate(ACCharGenData *this) .text:005C3770 ?Allocate@ACCharGenData@@UBEPAVDBObj@@XZ

        // ACCharGenData.GetSubDataIDs:
        // public static delegate* unmanaged[Thiscall]<ACCharGenData*,QualifiedDataIDArray*> GetSubDataIDs = (delegate* unmanaged[Thiscall]<ACCharGenData*,QualifiedDataIDArray*>)0xDEADBEEF; // .text:005C0EA0 ; void __thiscall ACCharGenData::GetSubDataIDs(ACCharGenData *this, QualifiedDataIDArray *id_array) .text:005C0EA0 ?GetSubDataIDs@ACCharGenData@@UBEXAAVQualifiedDataIDArray@@@Z

        // ACCharGenData.GetSkillSpecializedCost:
        public static delegate* unmanaged[Thiscall]<ACCharGenData*, Int32, UInt32, UInt32, Int32> GetSkillSpecializedCost = (delegate* unmanaged[Thiscall]<ACCharGenData*, Int32, UInt32, UInt32, Int32>)0x005C37B0; // .text:005C27D0 ; Int32 __thiscall ACCharGenData::GetSkillSpecializedCost(ACCharGenData *this, Int32 _skillID, UInt32 heritage, UInt32 gender) .text:005C27D0 ?GetSkillSpecializedCost@ACCharGenData@@QBEHHKK@Z

        // ACCharGenData.__Ctor:
        public static delegate* unmanaged[Thiscall]<ACCharGenData*> __Ctor = (delegate* unmanaged[Thiscall]<ACCharGenData*>)0x005C45E0; // .text:005C3600 ; void __thiscall ACCharGenData::ACCharGenData(ACCharGenData *this) .text:005C3600 ??0ACCharGenData@@QAE@XZ
    }
    public unsafe struct CharGenData {
        // Struct:
        public DBObj DBObj;
        public override string ToString() => $"DBObj(DBObj):{DBObj}";


        // Functions:

        // CharGenData.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<CharGenData*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<CharGenData*, UInt32, void*>)0x005BE4C0; // .text:005BD3F0 ; void *__thiscall CharGenData::`vector deleting destructor'(CharGenData *this, UInt32) .text:005BD3F0 ??_ECharGenData@@UAEPAXI@Z
    }






    public unsafe struct ACCharGenStartArea {
        // Struct:
        public Vtbl* vfptr;
        public PStringBase<Char> name;
        public SmartArray<Position> mPositionList;
        public override string ToString() => $"vfptr:->(ACCharGenStartAreaVtbl*)0x{(Int32)vfptr:X8}, name(PStringBase<Char>):{name}, mPositionList(SmartArray<Position,1>):{mPositionList}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<ACCharGenStartArea*, Archive*> Serialize; //   void (__thiscall *Serialize)(ACCharGenStartArea *this, Archive *);
        }


        // Functions:

        // ACCharGenStartArea.Serialize:
        // public static delegate* unmanaged[Thiscall]<ACCharGenStartArea*,Archive*> Serialize = (delegate* unmanaged[Thiscall]<ACCharGenStartArea*,Archive*>)0xDEADBEEF; // .text:005C0E70 ; void __thiscall ACCharGenStartArea::Serialize(ACCharGenStartArea *this, Archive *io_archive) .text:005C0E70 ?Serialize@ACCharGenStartArea@@UAEXAAVArchive@@@Z

        // ACCharGenStartArea.__Ctor:
        // public static delegate* unmanaged[Thiscall]<ACCharGenStartArea*> __Ctor = (delegate* unmanaged[Thiscall]<ACCharGenStartArea*>)0xDEADBEEF; // .text:005BE9F0 ; void __thiscall ACCharGenStartArea::ACCharGenStartArea(ACCharGenStartArea *this) .text:005BE9F0 ??0ACCharGenStartArea@@QAE@XZ

        // ACCharGenStartArea.__Dtor:
        // public static delegate* unmanaged[Thiscall]<ACCharGenStartArea*> __Dtor = (delegate* unmanaged[Thiscall]<ACCharGenStartArea*>)0xDEADBEEF; // .text:005BEA20 ; void __thiscall ACCharGenStartArea::~ACCharGenStartArea(ACCharGenStartArea *this) .text:005BEA20 ??1ACCharGenStartArea@@QAE@XZ

        // ACCharGenStartArea.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<ACCharGenStartArea*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<ACCharGenStartArea*, UInt32, void*>)0x005BFC20; // .text:005BECC0 ; void *__thiscall ACCharGenStartArea::`vector deleting destructor'(ACCharGenStartArea *this, UInt32) .text:005BECC0 ??_EACCharGenStartArea@@QAEPAXI@Z

        // ACCharGenStartArea.operator=:
        // public static delegate* unmanaged[Thiscall]<ACCharGenStartArea*, ACCharGenStartArea*> operator= = (delegate* unmanaged[Thiscall]<ACCharGenStartArea*, ACCharGenStartArea*>)0xDEADBEEF; // .text:005C0BB0 ; public: class ACCharGenStartArea & __thiscall ACCharGenStartArea::operator=(class ACCharGenStartArea const &) .text:005C0BB0 ??4ACCharGenStartArea@@QAEAAV0@ABV0@@Z

        // ACCharGenStartArea.__Ctor:
        // public static delegate* unmanaged[Thiscall]<ACCharGenStartArea*,ACCharGenStartArea*> __Ctor = (delegate* unmanaged[Thiscall]<ACCharGenStartArea*,ACCharGenStartArea*>)0xDEADBEEF; // .text:005C0E30 ; void __thiscall ACCharGenStartArea::ACCharGenStartArea(ACCharGenStartArea *this, ACCharGenStartArea *__that) .text:005C0E30 ??0ACCharGenStartArea@@QAE@ABV0@@Z
    }




    public unsafe struct ACCharGenResult {
        // Struct:
        public CharGenResult CharGenResult;
        public UInt32 heritageGroup;
        public UInt32 gender;
        public Int32 eyesStrip;
        public Int32 noseStrip;
        public Int32 mouthStrip;
        public Int32 hairColor;
        public Int32 eyeColor;
        public Int32 hairStyle;
        public Int32 headgearStyle;
        public Int32 shirtStyle;
        public Int32 trousersStyle;
        public Int32 footwearStyle;
        public UInt32 headgearColor;
        public UInt32 shirtColor;
        public UInt32 trousersColor;
        public UInt32 footwearColor;
        public Double skinShade;
        public Double hairShade;
        public Double headgearShade;
        public Double shirtShade;
        public Double trousersShade;
        public Double footwearShade;
        public Int32 templateNum;
        public Int32 strength;
        public Int32 endurance;
        public Int32 coordination;
        public Int32 quickness;
        public Int32 focus;
        public Int32 self;
        public Int32 numSkills;
        public SKILL_ADVANCEMENT_CLASS* skillAdvancementClasses;
        public AC1Legacy.PStringBase<Char> name;
        public Int32 slot;
        public UInt32 classID;
        public UInt32 startArea;
        public Int32 isAdmin;
        public Int32 isEnvoy;
        public override string ToString() => $"CharGenResult(CharGenResult):{CharGenResult}, heritageGroup:{heritageGroup:X8}, gender:{gender:X8}, eyesStrip:{eyesStrip}, noseStrip:{noseStrip}, mouthStrip:{mouthStrip}, hairColor:{hairColor}, eyeColor:{eyeColor}, hairStyle:{hairStyle}, headgearStyle:{headgearStyle}, shirtStyle:{shirtStyle}, trousersStyle:{trousersStyle}, footwearStyle:{footwearStyle}, headgearColor:{headgearColor:X8}, shirtColor:{shirtColor:X8}, trousersColor:{trousersColor:X8}, footwearColor:{footwearColor:X8}, skinShade:{skinShade:n5}, hairShade:{hairShade:n5}, headgearShade:{headgearShade:n5}, shirtShade:{shirtShade:n5}, trousersShade:{trousersShade:n5}, footwearShade:{footwearShade:n5}, templateNum:{templateNum}, strength:{strength}, endurance:{endurance}, coordination:{coordination}, quickness:{quickness}, focus:{focus}, self:{self}, numSkills:{numSkills}, skillAdvancementClasses:->(SKILL_ADVANCEMENT_CLASS*)0x{(Int32)skillAdvancementClasses:X8}, name:{name}, slot:{slot}, classID:{classID:X8}, startArea:{startArea:X8}, isAdmin:{isAdmin}, isEnvoy:{isEnvoy}";


        // Functions:

        // ACCharGenResult.GetName:
        // public static delegate* unmanaged[Thiscall]<ACCharGenResult*, AC1Legacy.PStringBase<Char>*> GetName = (delegate* unmanaged[Thiscall]<ACCharGenResult*, AC1Legacy.PStringBase<Char>*>)0xDEADBEEF; // .text:005C7110 ; AC1Legacy::PStringBase<Char> *__thiscall ACCharGenResult::GetName(ACCharGenResult *this) .text:005C7110 ?GetName@ACCharGenResult@@UBEABV?$PStringBase@D@AC1Legacy@@XZ

        // ACCharGenResult.GetSlot:
        // public static delegate* unmanaged[Thiscall]<ACCharGenResult*, Int32> GetSlot = (delegate* unmanaged[Thiscall]<ACCharGenResult*, Int32>)0xDEADBEEF; // .text:005C7120 ; Int32 __thiscall ACCharGenResult::GetSlot(ACCharGenResult *this) .text:005C7120 ?GetSlot@ACCharGenResult@@UBEJXZ

        // ACCharGenResult.__Dtor:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*> __Dtor = (delegate* unmanaged[Thiscall]<ACCharGenResult*>)0x005C8190; // .text:005C71B0 ; void __thiscall ACCharGenResult::~ACCharGenResult(ACCharGenResult *this) .text:005C71B0 ??1ACCharGenResult@@UAE@XZ

        // ACCharGenResult.GetPackSize:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, UInt32> GetPackSize = (delegate* unmanaged[Thiscall]<ACCharGenResult*, UInt32>)0x005C84C0; // .text:005C74E0 ; UInt32 __thiscall ACCharGenResult::GetPackSize(ACCharGenResult *this) .text:005C74E0 ?GetPackSize@ACCharGenResult@@UAEIXZ

        // ACCharGenResult.CG_UnPack:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, void**, Char*, Int32> CG_UnPack = (delegate* unmanaged[Thiscall]<ACCharGenResult*, void**, Char*, Int32>)0x005C85B0; // .text:005C75D0 ; Int32 __thiscall ACCharGenResult::CG_UnPack(ACCharGenResult *this, void **buffer_vpr, Char *end) .text:005C75D0 ?CG_UnPack@ACCharGenResult@@QAEHAAPAXPAE@Z

        // ACCharGenResult.VerifyCharacterGenerationResult:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, Int32, Int32> VerifyCharacterGenerationResult = (delegate* unmanaged[Thiscall]<ACCharGenResult*, Int32, Int32>)0x005C90C0; // .text:005C80E0 ; Int32 __thiscall ACCharGenResult::VerifyCharacterGenerationResult(ACCharGenResult *this, const Int32 has_throne_of_destiny) .text:005C80E0 ?VerifyCharacterGenerationResult@ACCharGenResult@@UAEHH@Z

        // ACCharGenResult.SetName:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, AC1Legacy.PStringBase<Char>*> SetName = (delegate* unmanaged[Thiscall]<ACCharGenResult*, AC1Legacy.PStringBase<Char>*>)0x005C8140; // .text:005C7160 ; void __thiscall ACCharGenResult::SetName(ACCharGenResult *this, AC1Legacy::PStringBase<Char> *newname) .text:005C7160 ?SetName@ACCharGenResult@@UAEXABV?$PStringBase@D@AC1Legacy@@@Z

        // ACCharGenResult.CG_Pack:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, void**, Char*> CG_Pack = (delegate* unmanaged[Thiscall]<ACCharGenResult*, void**, Char*>)0x005C81E0; // .text:005C7200 ; void __thiscall ACCharGenResult::CG_Pack(ACCharGenResult *this, void **buffer_vpr, Char *end) .text:005C7200 ?CG_Pack@ACCharGenResult@@QAEXAAPAXPAE@Z

        // ACCharGenResult.VerifyCharacterGenerationResult:
        public static delegate* unmanaged[Cdecl]<ACCharGenResult*, ACCharGenResult*, Int32, Int32> VerifyCharacterGenerationResult_ = (delegate* unmanaged[Cdecl]<ACCharGenResult*, ACCharGenResult*, Int32, Int32>)0x005C89D0; // .text:005C79F0 ; Int32 __cdecl ACCharGenResult::VerifyCharacterGenerationResult(ACCharGenResult *this, ACCharGenResult *cgr, const Int32 has_throne_of_destiny) .text:005C79F0 ?VerifyCharacterGenerationResult@ACCharGenResult@@SAHABV1@H@Z

        // ACCharGenResult.__Ctor:
        // public static delegate* unmanaged[Thiscall]<ACCharGenResult*> __Ctor = (delegate* unmanaged[Thiscall]<ACCharGenResult*>)0xDEADBEEF; // .text:005C7030 ; void __thiscall ACCharGenResult::ACCharGenResult(ACCharGenResult *this) .text:005C7030 ??0ACCharGenResult@@QAE@XZ

        // ACCharGenResult.IsEnvoy:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, Int32> IsEnvoy = (delegate* unmanaged[Thiscall]<ACCharGenResult*, Int32>)0x005C8110; // .text:005C7130 ; Int32 __thiscall ACCharGenResult::IsEnvoy(ACCharGenResult *this) .text:005C7130 ?IsEnvoy@ACCharGenResult@@UBEHXZ

        // ACCharGenResult.GetClassID:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, UInt32*, UInt32*> GetClassID = (delegate* unmanaged[Thiscall]<ACCharGenResult*, UInt32*, UInt32*>)0x005C8130; // .text:005C7150 ; IDClass<_tagDataID,32,0> *__thiscall ACCharGenResult::GetClassID(ACCharGenResult *this, IDClass<_tagDataID,32,0> *result) .text:005C7150 ?GetClassID@ACCharGenResult@@UBE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // ACCharGenResult.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<ACCharGenResult*, UInt32, void*>)0x005C84F0; // .text:005C7510 ; void *__thiscall ACCharGenResult::`vector deleting destructor'(ACCharGenResult *this, UInt32) .text:005C7510 ??_EACCharGenResult@@UAEPAXI@Z

        // ACCharGenResult.Pack:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, void**, UInt32, UInt32> Pack = (delegate* unmanaged[Thiscall]<ACCharGenResult*, void**, UInt32, UInt32>)0x005C8550; // .text:005C7570 ; UInt32 __thiscall ACCharGenResult::Pack(ACCharGenResult *this, void **addr, UInt32 size) .text:005C7570 ?Pack@ACCharGenResult@@UAEIAAPAXI@Z

        // ACCharGenResult.UnPack:
        public static delegate* unmanaged[Thiscall]<ACCharGenResult*, void**, UInt32, Int32> UnPack = (delegate* unmanaged[Thiscall]<ACCharGenResult*, void**, UInt32, Int32>)0x005C89B0; // .text:005C79D0 ; Int32 __thiscall ACCharGenResult::UnPack(ACCharGenResult *this, void **addr, UInt32 size) .text:005C79D0 ?UnPack@ACCharGenResult@@UAEHAAPAXI@Z
    }
    public unsafe struct CharGenResult {
        // Struct:
        public PackObj PackObj;
        public override string ToString() => $"PackObj(PackObj):{PackObj}";

    }
    public unsafe struct HeritageGroup_CG {
        // Struct:
        public Vtbl* vfptr;
        public PStringBase<Char> name;
        public UInt32 iconImage;
        public UInt32 setupID;
        public UInt32 environmentSetupID;
        public Int32 numAttributeCredits;
        public Int32 numSkillCredits;
        public SmartArray<UInt32> mPrimaryStartAreaList;
        public SmartArray<UInt32> mSecondaryStartAreaList;
        public SmartArray<Skill_CG> mSkillList;
        public SmartArray<Template_CG> mTemplateList;
        public HashTable<UInt32, Sex_CG> mGenderList;
        public override string ToString() => $"vfptr:->(HeritageGroup_CGVtbl*)0x{(Int32)vfptr:X8}, name(PStringBase<Char>):{name}, iconImage:{iconImage:X8}, setupID:{setupID:X8}, environmentSetupID:{environmentSetupID:X8}, numAttributeCredits:{numAttributeCredits}, numSkillCredits:{numSkillCredits}, mPrimaryStartAreaList(SmartArray<UInt32,1>):{mPrimaryStartAreaList}, mSecondaryStartAreaList(SmartArray<UInt32,1>):{mSecondaryStartAreaList}, mSkillList(SmartArray<Skill_CG,1>):{mSkillList}, mTemplateList(SmartArray<Template_CG,1>):{mTemplateList}, mGenderList(HashTable<UInt32,Sex_CG,0>):{mGenderList}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<HeritageGroup_CG*, Archive*> Serialize; //   void (__thiscall *Serialize)(HeritageGroup_CG *this, Archive *);
        }


        // Functions:

        // HeritageGroup_CG.Serialize:
        // public static delegate* unmanaged[Thiscall]<HeritageGroup_CG*,Archive*> Serialize = (delegate* unmanaged[Thiscall]<HeritageGroup_CG*,Archive*>)0xDEADBEEF; // .text:005C2100 ; void __thiscall HeritageGroup_CG::Serialize(HeritageGroup_CG *this, Archive *io_archive) .text:005C2100 ?Serialize@HeritageGroup_CG@@UAEXAAVArchive@@@Z

        // HeritageGroup_CG.operator=:
        // public static delegate* unmanaged[Thiscall]<HeritageGroup_CG*, HeritageGroup_CG*> operator= = (delegate* unmanaged[Thiscall]<HeritageGroup_CG*, HeritageGroup_CG*>)0xDEADBEEF; // .text:005C2240 ; public: class HeritageGroup_CG & __thiscall HeritageGroup_CG::operator=(class HeritageGroup_CG const &) .text:005C2240 ??4HeritageGroup_CG@@QAEAAV0@ABV0@@Z

        // HeritageGroup_CG.__Ctor:
        // public static delegate* unmanaged[Thiscall]<HeritageGroup_CG*,HeritageGroup_CG*> __Ctor = (delegate* unmanaged[Thiscall]<HeritageGroup_CG*,HeritageGroup_CG*>)0xDEADBEEF; // .text:005C22E0 ; void __thiscall HeritageGroup_CG::HeritageGroup_CG(HeritageGroup_CG *this, HeritageGroup_CG *__that) .text:005C22E0 ??0HeritageGroup_CG@@QAE@ABV0@@Z

        // HeritageGroup_CG.__Dtor:
        public static delegate* unmanaged[Thiscall]<HeritageGroup_CG*> __Dtor = (delegate* unmanaged[Thiscall]<HeritageGroup_CG*>)0x0047E300; // .text:0047DF50 ; void __thiscall HeritageGroup_CG::~HeritageGroup_CG(HeritageGroup_CG *this) .text:0047DF50 ??1HeritageGroup_CG@@QAE@XZ

        // HeritageGroup_CG.GetSubDataIDs:
        // public static delegate* unmanaged[Thiscall]<HeritageGroup_CG*,QualifiedDataIDArray*> GetSubDataIDs = (delegate* unmanaged[Thiscall]<HeritageGroup_CG*,QualifiedDataIDArray*>)0xDEADBEEF; // .text:005C05D0 ; void __thiscall HeritageGroup_CG::GetSubDataIDs(HeritageGroup_CG *this, QualifiedDataIDArray *id_array) .text:005C05D0 ?GetSubDataIDs@HeritageGroup_CG@@QBEXAAVQualifiedDataIDArray@@@Z

        // HeritageGroup_CG.GetSX:
        public static delegate* unmanaged[Thiscall]<HeritageGroup_CG*, Sex_CG*, UInt32, Sex_CG*> GetSX = (delegate* unmanaged[Thiscall]<HeritageGroup_CG*, Sex_CG*, UInt32, Sex_CG*>)0x005C2B30; // .text:005C1BC0 ; Sex_CG *__thiscall HeritageGroup_CG::GetSX(HeritageGroup_CG *this, Sex_CG *result, UInt32 gender) .text:005C1BC0 ?GetSX@HeritageGroup_CG@@QBE?BVSex_CG@@K@Z

        // HeritageGroup_CG.__Ctor:
        // public static delegate* unmanaged[Thiscall]<HeritageGroup_CG*> __Ctor = (delegate* unmanaged[Thiscall]<HeritageGroup_CG*>)0xDEADBEEF; // .text:005C2080 ; void __thiscall HeritageGroup_CG::HeritageGroup_CG(HeritageGroup_CG *this) .text:005C2080 ??0HeritageGroup_CG@@QAE@XZ
    }
    public unsafe struct Sex_CG {
        // Struct:
        public Vtbl* vfptr;
        public PStringBase<Char> name;
        public Int32 scaling;
        public UInt32 setup;
        public UInt32 soundTable;
        public UInt32 iconImage;
        public ObjDesc objDesc;
        public UInt32 physicsTable;
        public UInt32 motionTable;
        public UInt32 combatTable;
        public UInt32 basePalette;
        public UInt32 skinPalSet;
        public SmartArray<UInt32> mHairColorList;
        public SmartArray<HairStyle_CG> mHairStyleList;
        public SmartArray<UInt32> mEyeColorList;
        public SmartArray<EyesStrip_CG> mEyeStripList;
        public SmartArray<FaceStrip_CG> mNoseStripList;
        public SmartArray<FaceStrip_CG> mMouthStripList;
        public SmartArray<Style_CG> mHeadgearList;
        public SmartArray<Style_CG> mShirtList;
        public SmartArray<Style_CG> mPantsList;
        public SmartArray<Style_CG> mFootwearList;
        public SmartArray<UInt32> mClothingColorsList;
        public override string ToString() => $"vfptr:->(Sex_CGVtbl*)0x{(Int32)vfptr:X8}, name(PStringBase<Char>):{name}, scaling:{scaling}, setup:{setup:X8}, soundTable:{soundTable:X8}, iconImage:{iconImage:X8}, objDesc(ObjDesc):{objDesc}, physicsTable:{physicsTable:X8}, motionTable:{motionTable:X8}, combatTable:{combatTable:X8}, basePalette:{basePalette:X8}, skinPalSet:{skinPalSet:X8}, mHairColorList(SmartArray<UInt32,1>):{mHairColorList}, mHairStyleList(SmartArray<HairStyle_CG,1>):{mHairStyleList}, mEyeColorList(SmartArray<UInt32,1>):{mEyeColorList}, mEyeStripList(SmartArray<EyesStrip_CG,1>):{mEyeStripList}, mNoseStripList(SmartArray<FaceStrip_CG,1>):{mNoseStripList}, mMouthStripList(SmartArray<FaceStrip_CG,1>):{mMouthStripList}, mHeadgearList(SmartArray<Style_CG,1>):{mHeadgearList}, mShirtList(SmartArray<Style_CG,1>):{mShirtList}, mPantsList(SmartArray<Style_CG,1>):{mPantsList}, mFootwearList(SmartArray<Style_CG,1>):{mFootwearList}, mClothingColorsList(SmartArray<UInt32,1>):{mClothingColorsList}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<Sex_CG*, Archive*> Serialize; //   void (__thiscall *Serialize)(Sex_CG *this, Archive *);
        }


        // Functions:

        // Sex_CG.Serialize:
        // public static delegate* unmanaged[Thiscall]<Sex_CG*,Archive*> Serialize = (delegate* unmanaged[Thiscall]<Sex_CG*,Archive*>)0xDEADBEEF; // .text:005C1600 ; void __thiscall Sex_CG::Serialize(Sex_CG *this, Archive *io_archive) .text:005C1600 ?Serialize@Sex_CG@@UAEXAAVArchive@@@Z

        // Sex_CG.__Dtor:
        public static delegate* unmanaged[Thiscall]<Sex_CG*> __Dtor = (delegate* unmanaged[Thiscall]<Sex_CG*>)0x0047DAA0; // .text:0047D6F0 ; void __thiscall Sex_CG::~Sex_CG(Sex_CG *this) .text:0047D6F0 ??1Sex_CG@@QAE@XZ

        // Sex_CG.GetSubDataIDs:
        // public static delegate* unmanaged[Thiscall]<Sex_CG*,QualifiedDataIDArray*> GetSubDataIDs = (delegate* unmanaged[Thiscall]<Sex_CG*,QualifiedDataIDArray*>)0xDEADBEEF; // .text:005BF3A0 ; void __thiscall Sex_CG::GetSubDataIDs(Sex_CG *this, QualifiedDataIDArray *id_array) .text:005BF3A0 ?GetSubDataIDs@Sex_CG@@QBEXAAVQualifiedDataIDArray@@@Z

        // Sex_CG.__Ctor:
        // public static delegate* unmanaged[Thiscall]<Sex_CG*> __Ctor = (delegate* unmanaged[Thiscall]<Sex_CG*>)0xDEADBEEF; // .text:005C02C0 ; void __thiscall Sex_CG::Sex_CG(Sex_CG *this) .text:005C02C0 ??0Sex_CG@@QAE@XZ

        // Sex_CG.operator=:
        // public static delegate* unmanaged[Thiscall]<Sex_CG*, Sex_CG*> operator= = (delegate* unmanaged[Thiscall]<Sex_CG*, Sex_CG*>)0xDEADBEEF; // .text:005C0F00 ; public: class Sex_CG & __thiscall Sex_CG::operator=(class Sex_CG const &) .text:005C0F00 ??4Sex_CG@@QAEAAV0@ABV0@@Z

        // Sex_CG.__Ctor:
        // public static delegate* unmanaged[Thiscall]<Sex_CG*,Sex_CG*> __Ctor = (delegate* unmanaged[Thiscall]<Sex_CG*,Sex_CG*>)0xDEADBEEF; // .text:005C1480 ; void __thiscall Sex_CG::Sex_CG(Sex_CG *this, Sex_CG *__that) .text:005C1480 ??0Sex_CG@@QAE@ABV0@@Z
    }
    public unsafe struct HairStyle_CG {
        // Struct:
        public Vtbl* vfptr;
        public UInt32 iconImage;
        public Byte bald;
        public UInt32 alternateSetup;
        public ObjDesc objDesc;
        public override string ToString() => $"vfptr:->(HairStyle_CGVtbl*)0x{(Int32)vfptr:X8}, iconImage:{iconImage:X8}, bald:{bald:X2}, alternateSetup:{alternateSetup:X8}, objDesc(ObjDesc):{objDesc}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<HairStyle_CG*, Archive*> Serialize; //   void (__thiscall *Serialize)(HairStyle_CG *this, Archive *);
        }


        // Functions:

        // HairStyle_CG.__Ctor:
        // public static delegate* unmanaged[Thiscall]<HairStyle_CG*,HairStyle_CG*> __Ctor = (delegate* unmanaged[Thiscall]<HairStyle_CG*,HairStyle_CG*>)0xDEADBEEF; // .text:004DE370 ; void __thiscall HairStyle_CG::HairStyle_CG(HairStyle_CG *this, HairStyle_CG *__that) .text:004DE370 ??0HairStyle_CG@@QAE@ABV0@@Z

        // HairStyle_CG.__Ctor:
        public static delegate* unmanaged[Thiscall]<HairStyle_CG*> __Ctor = (delegate* unmanaged[Thiscall]<HairStyle_CG*>)0x005BEB20; // .text:005BDA50 ; void __thiscall HairStyle_CG::HairStyle_CG(HairStyle_CG *this) .text:005BDA50 ??0HairStyle_CG@@QAE@XZ

        // HairStyle_CG.Serialize:
        public static delegate* unmanaged[Thiscall]<HairStyle_CG*, Archive*> Serialize = (delegate* unmanaged[Thiscall]<HairStyle_CG*, Archive*>)0x005BEB50; // .text:005BDA80 ; void __thiscall HairStyle_CG::Serialize(HairStyle_CG *this, Archive *io_archive) .text:005BDA80 ?Serialize@HairStyle_CG@@UAEXAAVArchive@@@Z
    }
    public unsafe struct Skill_CG {
        // Struct:
        public Vtbl* vfptr;
        public Int32 skillNum;
        public Int32 normalCost;
        public Int32 primaryCost;
        public override string ToString() => $"vfptr:->(Skill_CGVtbl*)0x{(Int32)vfptr:X8}, skillNum:{skillNum}, normalCost:{normalCost}, primaryCost:{primaryCost}";

        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<Skill_CG*, Archive*> Serialize; //   void (__thiscall *Serialize)(Skill_CG *this, Archive *);
        }

        // Functions:

        // Skill_CG.__Ctor:
        public static delegate* unmanaged[Thiscall]<Skill_CG*> __Ctor = (delegate* unmanaged[Thiscall]<Skill_CG*>)0x005BE4F0; // .text:005BD420 ; void __thiscall Skill_CG::Skill_CG(Skill_CG *this) .text:005BD420 ??0Skill_CG@@QAE@XZ

        // Skill_CG.Serialize:
        public static delegate* unmanaged[Thiscall]<Skill_CG*, Archive*> Serialize = (delegate* unmanaged[Thiscall]<Skill_CG*, Archive*>)0x005BEA90; // .text:005BD9C0 ; void __thiscall Skill_CG::Serialize(Skill_CG *this, Archive *io_archive) .text:005BD9C0 ?Serialize@Skill_CG@@UAEXAAVArchive@@@Z
    }

    public unsafe struct EyesStrip_CG {
        // Struct:
        public Vtbl* vfptr;
        public UInt32 iconImage;
        public UInt32 iconImage_Bald;
        public ObjDesc objDesc;
        public ObjDesc objDesc_Bald;
        public override string ToString() => $"vfptr:->(EyesStrip_CGVtbl*)0x{(Int32)vfptr:X8}, iconImage:{iconImage:X8}, iconImage_Bald:{iconImage_Bald:X8}, objDesc(ObjDesc):{objDesc}, objDesc_Bald(ObjDesc):{objDesc_Bald}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<EyesStrip_CG*, Archive*> Serialize; //   void (__thiscall *Serialize)(EyesStrip_CG *this, Archive *);
        }


        // Functions:

        // EyesStrip_CG.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<EyesStrip_CG*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<EyesStrip_CG*,UInt32, void*>)0xDEADBEEF; // .text:0047CC00 ; void *__thiscall EyesStrip_CG::`vector deleting destructor'(EyesStrip_CG *this, UInt32) .text:0047CC00 ??_EEyesStrip_CG@@QAEPAXI@Z

        // EyesStrip_CG.operator=:
        public static delegate* unmanaged[Thiscall]<EyesStrip_CG*, EyesStrip_CG*> operator_equals = (delegate* unmanaged[Thiscall]<EyesStrip_CG*, EyesStrip_CG*>)0x005BE5E0; // .text:005BD510 ; public: class EyesStrip_CG & __thiscall EyesStrip_CG::operator=(class EyesStrip_CG const &) .text:005BD510 ??4EyesStrip_CG@@QAEAAV0@ABV0@@Z

        // EyesStrip_CG.__Ctor:
        public static delegate* unmanaged[Thiscall]<EyesStrip_CG*> __Ctor = (delegate* unmanaged[Thiscall]<EyesStrip_CG*>)0x005BEBD0; // .text:005BDB00 ; void __thiscall EyesStrip_CG::EyesStrip_CG(EyesStrip_CG *this) .text:005BDB00 ??0EyesStrip_CG@@QAE@XZ

        // EyesStrip_CG.Serialize:
        public static delegate* unmanaged[Thiscall]<EyesStrip_CG*, Archive*> Serialize = (delegate* unmanaged[Thiscall]<EyesStrip_CG*, Archive*>)0x005BEC00; // .text:005BDB30 ; void __thiscall EyesStrip_CG::Serialize(EyesStrip_CG *this, Archive *io_archive) .text:005BDB30 ?Serialize@EyesStrip_CG@@UAEXAAVArchive@@@Z
    }
    public unsafe struct FaceStrip_CG {
        // Struct:
        public Vtbl* vfptr;
        public UInt32 iconImage;
        public ObjDesc objDesc;
        public override string ToString() => $"vfptr:->(FaceStrip_CGVtbl*)0x{(Int32)vfptr:X8}, iconImage:{iconImage:X8}, objDesc(ObjDesc):{objDesc}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<FaceStrip_CG*, Archive*> Serialize; //   void (__thiscall *Serialize)(FaceStrip_CG *this, Archive *);
        }


        // Functions:

        // FaceStrip_CG.__Ctor:
        public static delegate* unmanaged[Thiscall]<FaceStrip_CG*> __Ctor = (delegate* unmanaged[Thiscall]<FaceStrip_CG*>)0x005BEC80; // .text:005BDBB0 ; void __thiscall FaceStrip_CG::FaceStrip_CG(FaceStrip_CG *this) .text:005BDBB0 ??0FaceStrip_CG@@QAE@XZ

        // FaceStrip_CG.Serialize:
        public static delegate* unmanaged[Thiscall]<FaceStrip_CG*, Archive*> Serialize = (delegate* unmanaged[Thiscall]<FaceStrip_CG*, Archive*>)0x005BECA0; // .text:005BDBD0 ; void __thiscall FaceStrip_CG::Serialize(FaceStrip_CG *this, Archive *io_archive) .text:005BDBD0 ?Serialize@FaceStrip_CG@@UAEXAAVArchive@@@Z
    }
    public unsafe struct Style_CG {
        // Struct:
        public Vtbl* vfptr;
        public PStringBase<Char> name;
        public UInt32 clothingTable;
        public UInt32 weenieDefault;
        public override string ToString() => $"vfptr:->(Style_CGVtbl*)0x{(Int32)vfptr:X8}, name(PStringBase<Char>):{name}, clothingTable:{clothingTable:X8}, weenieDefault:{weenieDefault:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<Style_CG*, Archive*> Serialize; //   void (__thiscall *Serialize)(Style_CG *this, Archive *);
        }


        // Functions:

        // Style_CG.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<Style_CG*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<Style_CG*,UInt32, void*>)0xDEADBEEF; // .text:0047D360 ; void *__thiscall Style_CG::`vector deleting destructor'(Style_CG *this, UInt32) .text:0047D360 ??_EStyle_CG@@QAEPAXI@Z

        // Style_CG.operator=:
        public static delegate* unmanaged[Thiscall]<Style_CG*, Style_CG*> operator_equals = (delegate* unmanaged[Thiscall]<Style_CG*, Style_CG*>)0x005BED30; // .text:005BDC60 ; public: class Style_CG & __thiscall Style_CG::operator=(class Style_CG const &) .text:005BDC60 ??4Style_CG@@QAEAAV0@ABV0@@Z

        // Style_CG.__Ctor:
        // public static delegate* unmanaged[Thiscall]<Style_CG*> __Ctor = (delegate* unmanaged[Thiscall]<Style_CG*>)0xDEADBEEF; // .text:005BEA80 ; void __thiscall Style_CG::Style_CG(Style_CG *this) .text:005BEA80 ??0Style_CG@@QAE@XZ

        // Style_CG.__Ctor:
        // public static delegate* unmanaged[Thiscall]<Style_CG*,Style_CG*> __Ctor = (delegate* unmanaged[Thiscall]<Style_CG*,Style_CG*>)0xDEADBEEF; // .text:005BEAC0 ; void __thiscall Style_CG::Style_CG(Style_CG *this, Style_CG *_style) .text:005BEAC0 ??0Style_CG@@QAE@AAV0@@Z

        // Style_CG.Serialize:
        // public static delegate* unmanaged[Thiscall]<Style_CG*,Archive*> Serialize = (delegate* unmanaged[Thiscall]<Style_CG*,Archive*>)0xDEADBEEF; // .text:005C03E0 ; void __thiscall Style_CG::Serialize(Style_CG *this, Archive *io_archive) .text:005C03E0 ?Serialize@Style_CG@@UAEXAAVArchive@@@Z
    }
    public unsafe struct Template_CG {
        // Struct:
        public Vtbl* vfptr;
        public PStringBase<Char> name;
        public UInt32 iconImage;
        public UInt32 titleID;
        public Int32 strength;
        public Int32 endurance;
        public Int32 coordination;
        public Int32 quickness;
        public Int32 focus;
        public Int32 self;
        public SmartArray<Int32> mNormalSkillsList;
        public SmartArray<Int32> mPrimarySkillsList;
        public override string ToString() => $"vfptr:->(Template_CGVtbl*)0x{(Int32)vfptr:X8}, name(PStringBase<Char>):{name}, iconImage:{iconImage:X8}, titleID:{titleID:X8}, strength:{strength}, endurance:{endurance}, coordination:{coordination}, quickness:{quickness}, focus:{focus}, self:{self}, mNormalSkillsList(SmartArray<Int32,1>):{mNormalSkillsList}, mPrimarySkillsList(SmartArray<Int32,1>):{mPrimarySkillsList}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<Template_CG*, Archive*> Serialize; //   void (__thiscall *Serialize)(Template_CG *this, Archive *);
        }


        // Functions:

        // Template_CG.__Dtor:
        // public static delegate* unmanaged[Thiscall]<Template_CG*> __Dtor = (delegate* unmanaged[Thiscall]<Template_CG*>)0xDEADBEEF; // .text:0047D420 ; void __thiscall Template_CG::~Template_CG(Template_CG *this) .text:0047D420 ??1Template_CG@@QAE@XZ

        // Template_CG.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<Template_CG*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<Template_CG*,UInt32, void*>)0xDEADBEEF; // .text:0047D600 ; void *__thiscall Template_CG::`vector deleting destructor'(Template_CG *this, UInt32) .text:0047D600 ??_ETemplate_CG@@QAEPAXI@Z

        // Template_CG.__Ctor:
        // public static delegate* unmanaged[Thiscall]<Template_CG*> __Ctor = (delegate* unmanaged[Thiscall]<Template_CG*>)0xDEADBEEF; // .text:005BEB30 ; void __thiscall Template_CG::Template_CG(Template_CG *this) .text:005BEB30 ??0Template_CG@@QAE@XZ

        // Template_CG.operator=:
        // public static delegate* unmanaged[Thiscall]<Template_CG*, Template_CG*> operator= = (delegate* unmanaged[Thiscall]<Template_CG*, Template_CG*>)0xDEADBEEF; // .text:005BFE30 ; public: class Template_CG & __thiscall Template_CG::operator=(class Template_CG const &) .text:005BFE30 ??4Template_CG@@QAEAAV0@ABV0@@Z

        // Template_CG.Serialize:
        // public static delegate* unmanaged[Thiscall]<Template_CG*,Archive*> Serialize = (delegate* unmanaged[Thiscall]<Template_CG*,Archive*>)0xDEADBEEF; // .text:005C0450 ; void __thiscall Template_CG::Serialize(Template_CG *this, Archive *io_archive) .text:005C0450 ?Serialize@Template_CG@@UAEXAAVArchive@@@Z

        // Template_CG.__Ctor:
        // public static delegate* unmanaged[Thiscall]<Template_CG*,Template_CG*> __Ctor = (delegate* unmanaged[Thiscall]<Template_CG*,Template_CG*>)0xDEADBEEF; // .text:005C4D10 ; void __thiscall Template_CG::Template_CG(Template_CG *this, Template_CG *__that) .text:005C4D10 ??0Template_CG@@QAE@ABV0@@Z
    }

    public unsafe struct gmCharGenMainUI {
        // Struct:
        public UIMainFramework a0;
        public gmNoticeHandler a1;
        public CPlayerSystem* m_pPlayerSystem;
        public UIElement* m_rootField;
        public UIElement* m_ProgressBar;
        public UIElement* m_MainMenu;
        public UIElement* m_pMasterPage;
        public gmCGHeritagePage* m_pHeritagePage;
        public gmCGProfessionPage* m_pProfessionPage;
        public gmCGSkillsPage* m_pSkillsPage;
        public gmCGAppearancePage* m_pAppearancePage;
        public gmCGTownPage* m_pTownPage;
        public gmCGSummaryPage* m_pSummaryPage;
        public UIElement_Button* m_pHeritageButton;
        public UIElement_Button* m_pProfessionButton;
        public UIElement_Button* m_pSkillsButton;
        public UIElement_Button* m_pAppearanceButton;
        public UIElement_Button* m_pTownButton;
        public UIElement_Button* m_pSummaryButton;
        public UIElement_Button* m_pLeftButton;
        public UIElement_Button* m_pRightButton;
        public UIElement_Button* m_pFinishButton;
        public UIElement_Button* m_pHelpButton;
        public UIElement_Button* m_pExitButton;
        public UIElement_Button* m_pRandomButton;
        public gmCharGenMainUI.ECGProgress m_eProgressState;
        public Byte m_bAwaitingCharSetForLogin;
        public UInt32 m_uiExitContext;
        public UInt32 m_uiPleaseWaitContext;
        public UInt32 m_uiErrorMessageContext;
        public UInt32 m_uiCreditWarningContext;
        public UInt32 m_uiRandomizeWarningContext;
        public UInt32 m_uiToDRequiredMessage;
        public override string ToString() => $"a0(UIMainFramework):{a0}, a1(gmNoticeHandler):{a1}, m_pPlayerSystem:->(CPlayerSystem*)0x{(int)m_pPlayerSystem:X8}, m_rootField:->(UIElement*)0x{(int)m_rootField:X8}, m_ProgressBar:->(UIElement*)0x{(int)m_ProgressBar:X8}, m_MainMenu:->(UIElement*)0x{(int)m_MainMenu:X8}, m_pMasterPage:->(UIElement*)0x{(int)m_pMasterPage:X8}, m_pHeritagePage:->(gmCGHeritagePage*)0x{(int)m_pHeritagePage:X8}, m_pProfessionPage:->(gmCGProfessionPage*)0x{(int)m_pProfessionPage:X8}, m_pSkillsPage:->(gmCGSkillsPage*)0x{(int)m_pSkillsPage:X8}, m_pAppearancePage:->(gmCGAppearancePage*)0x{(int)m_pAppearancePage:X8}, m_pTownPage:->(gmCGTownPage*)0x{(int)m_pTownPage:X8}, m_pSummaryPage:->(gmCGSummaryPage*)0x{(int)m_pSummaryPage:X8}, m_pHeritageButton:->(UIElement_Button*)0x{(int)m_pHeritageButton:X8}, m_pProfessionButton:->(UIElement_Button*)0x{(int)m_pProfessionButton:X8}, m_pSkillsButton:->(UIElement_Button*)0x{(int)m_pSkillsButton:X8}, m_pAppearanceButton:->(UIElement_Button*)0x{(int)m_pAppearanceButton:X8}, m_pTownButton:->(UIElement_Button*)0x{(int)m_pTownButton:X8}, m_pSummaryButton:->(UIElement_Button*)0x{(int)m_pSummaryButton:X8}, m_pLeftButton:->(UIElement_Button*)0x{(int)m_pLeftButton:X8}, m_pRightButton:->(UIElement_Button*)0x{(int)m_pRightButton:X8}, m_pFinishButton:->(UIElement_Button*)0x{(int)m_pFinishButton:X8}, m_pHelpButton:->(UIElement_Button*)0x{(int)m_pHelpButton:X8}, m_pExitButton:->(UIElement_Button*)0x{(int)m_pExitButton:X8}, m_pRandomButton:->(UIElement_Button*)0x{(int)m_pRandomButton:X8}, m_eProgressState(gmCharGenMainUI.ECGProgress):{m_eProgressState}, m_bAwaitingCharSetForLogin:{m_bAwaitingCharSetForLogin:X2}, m_uiExitContext:{m_uiExitContext:X8}, m_uiPleaseWaitContext:{m_uiPleaseWaitContext:X8}, m_uiErrorMessageContext:{m_uiErrorMessageContext:X8}, m_uiCreditWarningContext:{m_uiCreditWarningContext:X8}, m_uiRandomizeWarningContext:{m_uiRandomizeWarningContext:X8}, m_uiToDRequiredMessage:{m_uiToDRequiredMessage:X8}";
        // Enums:
        public enum ECGProgress : UInt32 {
            ECG_INVALID = 0x0,
            ECG_HERTAGE = 0x1,
            ECG_PROFESSION = 0x2,
            ECG_SKILLS = 0x3,
            ECG_APPEARANCE = 0x4,
            ECG_TOWN = 0x5,
            ECG_SUMMARY = 0x6,
        };

        // Functions:

        // gmCharGenMainUI.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, void>)0x004E8B40)(ref this); // .text:004E7EB0 ; void __thiscall gmCharGenMainUI::gmCharGenMainUI(gmCharGenMainUI *this) .text:004E7EB0 ??0gmCharGenMainUI@@QAE@XZ

        // gmCharGenMainUI.CloseRandomizeWarningDialog:
        public Byte CloseRandomizeWarningDialog(Byte i_bConfirm) => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, Byte, Byte>)0x004E9090)(ref this, i_bConfirm); // .text:004E8400 ; bool __thiscall gmCharGenMainUI::CloseRandomizeWarningDialog(gmCharGenMainUI *this, bool i_bConfirm) .text:004E8400 ?CloseRandomizeWarningDialog@gmCharGenMainUI@@IAE_N_N@Z

        // gmCharGenMainUI.Create:
        public static UIMainFramework* Create() => ((delegate* unmanaged[Cdecl]<UIMainFramework*>)0x004E9070)(); // .text:004E83E0 ; UIMainFramework *__cdecl gmCharGenMainUI::Create() .text:004E83E0 ?Create@gmCharGenMainUI@@SAPAVUIMainFramework@@XZ

        // gmCharGenMainUI.DoExit:
        public Byte DoExit() => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, Byte>)0x004E92E0)(ref this); // .text:004E8650 ; bool __thiscall gmCharGenMainUI::DoExit(gmCharGenMainUI *this) .text:004E8650 ?DoExit@gmCharGenMainUI@@IAE_NXZ

        // gmCharGenMainUI.DoFinish:
        public Byte DoFinish(Byte _bCreditCheck) => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, Byte, Byte>)0x004E9E00)(ref this, _bCreditCheck); // .text:004E9170 ; bool __thiscall gmCharGenMainUI::DoFinish(gmCharGenMainUI *this, bool _bCreditCheck) .text:004E9170 ?DoFinish@gmCharGenMainUI@@IAE_N_N@Z

        // gmCharGenMainUI.DoRandom:
        public void DoRandom() => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, void>)0x004E8A00)(ref this); // .text:004E7D70 ; void __thiscall gmCharGenMainUI::DoRandom(gmCharGenMainUI *this) .text:004E7D70 ?DoRandom@gmCharGenMainUI@@IAEXXZ

        // gmCharGenMainUI.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, UIElementMessageInfo*, UIElementMessageListenResult>)0x004EA0E0)(ref this, i_rMsg); // .text:004E9450 ; UIElementMessageListenResult __thiscall gmCharGenMainUI::ListenToElementMessage(gmCharGenMainUI *this, UIElementMessageInfo *i_rMsg) .text:004E9450 ?ListenToElementMessage@gmCharGenMainUI@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmCharGenMainUI.ListenToGlobalMessage:
        public void ListenToGlobalMessage(UInt32 i_messageID, int i_data_int) => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, UInt32, int, void>)0x004E9C90)(ref this, i_messageID, i_data_int); // .text:004E9000 ; void __thiscall gmCharGenMainUI::ListenToGlobalMessage(gmCharGenMainUI *this, unsigned int i_messageID, int i_data_int) .text:004E9000 ?ListenToGlobalMessage@gmCharGenMainUI@@UAEXKJ@Z

        // gmCharGenMainUI.MakeCreditWarningDialog:
        public Byte MakeCreditWarningDialog() => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, Byte>)0x004E9500)(ref this); // .text:004E8870 ; bool __thiscall gmCharGenMainUI::MakeCreditWarningDialog(gmCharGenMainUI *this) .text:004E8870 ?MakeCreditWarningDialog@gmCharGenMainUI@@IAE_NXZ

        // gmCharGenMainUI.MakeErrorMessageDialog:
        public Byte MakeErrorMessageDialog(StringInfo* siError) => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, StringInfo*, Byte>)0x004E9940)(ref this, siError); // .text:004E8CB0 ; bool __thiscall gmCharGenMainUI::MakeErrorMessageDialog(gmCharGenMainUI *this, StringInfo *siError) .text:004E8CB0 ?MakeErrorMessageDialog@gmCharGenMainUI@@IAE_NABVStringInfo@@@Z

        // gmCharGenMainUI.MakeRandomizeWarningDialog:
        public Byte MakeRandomizeWarningDialog() => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, Byte>)0x004E9720)(ref this); // .text:004E8A90 ; bool __thiscall gmCharGenMainUI::MakeRandomizeWarningDialog(gmCharGenMainUI *this) .text:004E8A90 ?MakeRandomizeWarningDialog@gmCharGenMainUI@@IAE_NXZ

        // gmCharGenMainUI.MakeToDWarningDialog:
        public Byte MakeToDWarningDialog() => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, Byte>)0x004E9AD0)(ref this); // .text:004E8E40 ; bool __thiscall gmCharGenMainUI::MakeToDWarningDialog(gmCharGenMainUI *this) .text:004E8E40 ?MakeToDWarningDialog@gmCharGenMainUI@@QAE_NXZ

        // gmCharGenMainUI.RecvNotice_CharGenVerificationResponse:
        public void RecvNotice_CharGenVerificationResponse(CG_VERIFICATION_RESPONSE i_rsvp) => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, CG_VERIFICATION_RESPONSE, void>)0x004E9CC0)(ref this, i_rsvp); // .text:004E9030 ; void __thiscall gmCharGenMainUI::RecvNotice_CharGenVerificationResponse(gmCharGenMainUI *this, CG_VERIFICATION_RESPONSE i_rsvp) .text:004E9030 ?RecvNotice_CharGenVerificationResponse@gmCharGenMainUI@@UAEXW4CG_VERIFICATION_RESPONSE@@@Z

        // gmCharGenMainUI.RecvNotice_CloseDialog:
        public void RecvNotice_CloseDialog(UInt32 context, PropertyCollection* data) => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, UInt32, PropertyCollection*, void>)0x004EA410)(ref this, context, data); // .text:004E9780 ; void __thiscall gmCharGenMainUI::RecvNotice_CloseDialog(gmCharGenMainUI *this, unsigned int context, PropertyCollection *data) .text:004E9780 ?RecvNotice_CloseDialog@gmCharGenMainUI@@UAEXKABVPropertyCollection@@@Z

        // gmCharGenMainUI.Register:
        public static void Register(UInt32 mode) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x004E90D0)(mode); // .text:004E8440 ; void __cdecl gmCharGenMainUI::Register(unsigned int mode) .text:004E8440 ?Register@gmCharGenMainUI@@SAXK@Z

        // gmCharGenMainUI.SetProgressState:
        public void SetProgressState(gmCharGenMainUI.ECGProgress eState) => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, gmCharGenMainUI.ECGProgress, void>)0x004E86A0)(ref this, eState); // .text:004E7A10 ; void __thiscall gmCharGenMainUI::SetProgressState(gmCharGenMainUI *this, gmCharGenMainUI::ECGProgress eState) .text:004E7A10 ?SetProgressState@gmCharGenMainUI@@QAEXW4ECGProgress@1@@Z

        // gmCharGenMainUI.Update:
        public void Update() => ((delegate* unmanaged[Thiscall]<ref gmCharGenMainUI, void>)0x004E90F0)(ref this); // .text:004E8460 ; void __thiscall gmCharGenMainUI::Update(gmCharGenMainUI *this) .text:004E8460 ?Update@gmCharGenMainUI@@UAEXXZ
    }
    public unsafe struct gmCGHeritagePage {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public CPlayerSystem* m_pPlayerSystem;
        public gmCharGenMainUI* m_pMainFramework;
        public UIElement_Button* m_pAluButton;
        public UIElement_Button* m_pGhuButton;
        public UIElement_Button* m_pShoButton;
        public UIElement_Button* m_pViaButton;
        public UIElement_Button* m_pShadButton;
        public UIElement_Button* m_pPenButton;
        public UIElement_Button* m_pGearButton;
        public UIElement_Button* m_pUndButton;
        public UIElement_Button* m_pEmpButton;
        public UIElement_Button* m_pAunTButton;
        public UIElement_Button* m_pLugButton;
        public UIElement_Button* m_pOlthoiButton;
        public UIElement_Button* m_pOlthoiAcidButton;
        public UIElement_Text* m_pText;
        public UIElement* m_pBackground;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_pPlayerSystem:->(CPlayerSystem*)0x{(int)m_pPlayerSystem:X8}, m_pMainFramework:->(gmCharGenMainUI*)0x{(int)m_pMainFramework:X8}, m_pAluButton:->(UIElement_Button*)0x{(int)m_pAluButton:X8}, m_pGhuButton:->(UIElement_Button*)0x{(int)m_pGhuButton:X8}, m_pShoButton:->(UIElement_Button*)0x{(int)m_pShoButton:X8}, m_pViaButton:->(UIElement_Button*)0x{(int)m_pViaButton:X8}, m_pShadButton:->(UIElement_Button*)0x{(int)m_pShadButton:X8}, m_pPenButton:->(UIElement_Button*)0x{(int)m_pPenButton:X8}, m_pGearButton:->(UIElement_Button*)0x{(int)m_pGearButton:X8}, m_pUndButton:->(UIElement_Button*)0x{(int)m_pUndButton:X8}, m_pEmpButton:->(UIElement_Button*)0x{(int)m_pEmpButton:X8}, m_pAunTButton:->(UIElement_Button*)0x{(int)m_pAunTButton:X8}, m_pLugButton:->(UIElement_Button*)0x{(int)m_pLugButton:X8}, m_pOlthoiButton:->(UIElement_Button*)0x{(int)m_pOlthoiButton:X8}, m_pOlthoiAcidButton:->(UIElement_Button*)0x{(int)m_pOlthoiAcidButton:X8}, m_pText:->(UIElement_Text*)0x{(int)m_pText:X8}, m_pBackground:->(UIElement*)0x{(int)m_pBackground:X8}";

        // Functions:

        // gmCGHeritagePage.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmCGHeritagePage, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:004830A0 ; void __thiscall gmCGHeritagePage::gmCGHeritagePage(gmCGHeritagePage *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004830A0 ??0gmCGHeritagePage@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGHeritagePage.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:00483160 ; UIElement *__cdecl gmCGHeritagePage::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:00483160 ?Create@gmCGHeritagePage@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGHeritagePage.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmCGHeritagePage, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:00483130 ; UIElement *__thiscall gmCGHeritagePage::DynamicCast(gmCGHeritagePage *this, unsigned int i_eType) .text:00483130 ?DynamicCast@gmCGHeritagePage@@UAEPAVUIElement@@K@Z

        // gmCGHeritagePage.GetUIElementType:
        // public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmCGHeritagePage, UInt32>)0xDEADBEEF)(ref this); // .text:00483150 ; unsigned int __thiscall gmCGHeritagePage::GetUIElementType(gmCGHeritagePage *this) .text:00483150 ?GetUIElementType@gmCGHeritagePage@@UBEKXZ

        // gmCGHeritagePage.InitializePage:
        public void InitializePage(gmCharGenMainUI* _pMain) => ((delegate* unmanaged[Thiscall]<ref gmCGHeritagePage, gmCharGenMainUI*, void>)0x00483DD0)(ref this, _pMain); // .text:00483A10 ; void __thiscall gmCGHeritagePage::InitializePage(gmCGHeritagePage *this, gmCharGenMainUI *_pMain) .text:00483A10 ?InitializePage@gmCGHeritagePage@@QAEXPAVgmCharGenMainUI@@@Z

        // gmCGHeritagePage.ListenToElementMessage:
        // public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmCGHeritagePage, UIElementMessageInfo*, UIElementMessageListenResult>)0xDEADBEEF)(ref this, i_rMsg); // .text:00483860 ; UIElementMessageListenResult __thiscall gmCGHeritagePage::ListenToElementMessage(gmCGHeritagePage *this, UIElementMessageInfo *i_rMsg) .text:00483860 ?ListenToElementMessage@gmCGHeritagePage@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmCGHeritagePage.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004835B0)(); // .text:004831F0 ; void __cdecl gmCGHeritagePage::Register() .text:004831F0 ?Register@gmCGHeritagePage@@SAXXZ

        // gmCGHeritagePage.Update:
        // public void Update() => ((delegate* unmanaged[Thiscall]<ref gmCGHeritagePage, void>)0xDEADBEEF)(ref this); // .text:00483210 ; void __thiscall gmCGHeritagePage::Update(gmCGHeritagePage *this) .text:00483210 ?Update@gmCGHeritagePage@@QAEXXZ
    }
    public unsafe struct gmCGProfessionPage {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public CPlayerSystem* m_pPlayerSystem;
        public gmCharGenMainUI* m_pMainFramework;
        public UIElement_Text* m_pAvailableValue;
        public UIElement_Text* m_pHealthValue;
        public UIElement_Text* m_pStaminaValue;
        public UIElement_Text* m_pManaValue;
        public UIElement_Text* m_pTextBox;
        public UIElement_Button* m_pCurProfButton;
        public fixed int m_tSliderArray[7];
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_pPlayerSystem:->(CPlayerSystem*)0x{(int)m_pPlayerSystem:X8}, m_pMainFramework:->(gmCharGenMainUI*)0x{(int)m_pMainFramework:X8}, m_pAvailableValue:->(UIElement_Text*)0x{(int)m_pAvailableValue:X8}, m_pHealthValue:->(UIElement_Text*)0x{(int)m_pHealthValue:X8}, m_pStaminaValue:->(UIElement_Text*)0x{(int)m_pStaminaValue:X8}, m_pManaValue:->(UIElement_Text*)0x{(int)m_pManaValue:X8}, m_pTextBox:->(UIElement_Text*)0x{(int)m_pTextBox:X8}, m_pCurProfButton:->(UIElement_Button*)0x{(int)m_pCurProfButton:X8}, m_tSliderArray[7](fixed int):{m_tSliderArray[7]}";
        public unsafe struct tagSlider {
            public UIElement* pAttribField;
            public UIElement_Button* pLockButton;
            public UIElement_Text* pAttribText;
            public UIElement_Scrollbar* pSlider;
            public UIElement_Text* pAttibValue;
            public Byte bLocked;
            public override string ToString() => $"pAttribField:->(UIElement*)0x{(int)pAttribField:X8}, pLockButton:->(UIElement_Button*)0x{(int)pLockButton:X8}, pAttribText:->(UIElement_Text*)0x{(int)pAttribText:X8}, pSlider:->(UIElement_Scrollbar*)0x{(int)pSlider:X8}, pAttibValue:->(UIElement_Text*)0x{(int)pAttibValue:X8}, bLocked:{bLocked:X2}";
        }
        // Enums:
        public enum EProfession : UInt32 {
            ECG_CUSTOM = 0x0,
            ECG_BOWHUNTER = 0x1,
            ECG_SWASHBUCKLER = 0x2,
            ECG_LIFECASTER = 0x3,
            ECG_WARMAGE = 0x4,
            ECG_WAYFARER = 0x5,
            ECG_SOLDIER = 0x6,
        };

        // Functions:

        // gmCGProfessionPage.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:00481EA0 ; void __thiscall gmCGProfessionPage::gmCGProfessionPage(gmCGProfessionPage *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:00481EA0 ??0gmCGProfessionPage@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGProfessionPage.ClearLocks:
        // public void ClearLocks() => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, void>)0xDEADBEEF)(ref this); // .text:004820D0 ; void __thiscall gmCGProfessionPage::ClearLocks(gmCGProfessionPage *this) .text:004820D0 ?ClearLocks@gmCGProfessionPage@@IAEXXZ

        // gmCGProfessionPage.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:00481F60 ; UIElement *__cdecl gmCGProfessionPage::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:00481F60 ?Create@gmCGProfessionPage@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGProfessionPage.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:00481F30 ; UIElement *__thiscall gmCGProfessionPage::DynamicCast(gmCGProfessionPage *this, unsigned int i_eType) .text:00481F30 ?DynamicCast@gmCGProfessionPage@@UAEPAVUIElement@@K@Z

        // gmCGProfessionPage.GetSliderIndex:
        // public int GetSliderIndex(UIElement* pSlider) => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, UIElement*, int>)0xDEADBEEF)(ref this, pSlider); // .text:00481F90 ; int __thiscall gmCGProfessionPage::GetSliderIndex(gmCGProfessionPage *this, UIElement *pSlider) .text:00481F90 ?GetSliderIndex@gmCGProfessionPage@@IAEHPAVUIElement@@@Z

        // gmCGProfessionPage.GetUIElementType:
        // public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, UInt32>)0xDEADBEEF)(ref this); // .text:00481F50 ; unsigned int __thiscall gmCGProfessionPage::GetUIElementType(gmCGProfessionPage *this) .text:00481F50 ?GetUIElementType@gmCGProfessionPage@@UBEKXZ

        // gmCGProfessionPage.InitializePage:
        public void InitializePage(gmCharGenMainUI* _pMain) => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, gmCharGenMainUI*, void>)0x00483110)(ref this, _pMain); // .text:00482D50 ; void __thiscall gmCGProfessionPage::InitializePage(gmCGProfessionPage *this, gmCharGenMainUI *_pMain) .text:00482D50 ?InitializePage@gmCGProfessionPage@@QAEXPAVgmCharGenMainUI@@@Z

        // gmCGProfessionPage.ListenToElementMessage:
        // public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, UIElementMessageInfo*, UIElementMessageListenResult>)0xDEADBEEF)(ref this, i_rMsg); // .text:004829C0 ; UIElementMessageListenResult __thiscall gmCGProfessionPage::ListenToElementMessage(gmCGProfessionPage *this, UIElementMessageInfo *i_rMsg) .text:004829C0 ?ListenToElementMessage@gmCGProfessionPage@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmCGProfessionPage.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x00482550)(); // .text:00482190 ; void __cdecl gmCGProfessionPage::Register() .text:00482190 ?Register@gmCGProfessionPage@@SAXXZ

        // gmCGProfessionPage.SetAttribValue:
        // public void SetAttribValue(UIElement* pSlider, int iPos) => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, UIElement*, int, void>)0xDEADBEEF)(ref this, pSlider, iPos); // .text:00482890 ; void __thiscall gmCGProfessionPage::SetAttribValue(gmCGProfessionPage *this, UIElement *pSlider, int iPos) .text:00482890 ?SetAttribValue@gmCGProfessionPage@@IAEXPAVUIElement@@H@Z

        // gmCGProfessionPage.SetLock:
        // public void SetLock(UIElement* pSlider) => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, UIElement*, void>)0xDEADBEEF)(ref this, pSlider); // .text:00482000 ; void __thiscall gmCGProfessionPage::SetLock(gmCGProfessionPage *this, UIElement *pSlider) .text:00482000 ?SetLock@gmCGProfessionPage@@IAEXPAVUIElement@@@Z

        // gmCGProfessionPage.Update:
        // public void Update() => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, void>)0xDEADBEEF)(ref this); // .text:00482830 ; void __thiscall gmCGProfessionPage::Update(gmCGProfessionPage *this) .text:00482830 ?Update@gmCGProfessionPage@@QAEXXZ

        // gmCGProfessionPage.UpdateAttributeValues:
        // public void UpdateAttributeValues() => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, void>)0xDEADBEEF)(ref this); // .text:00482450 ; void __thiscall gmCGProfessionPage::UpdateAttributeValues(gmCGProfessionPage *this) .text:00482450 ?UpdateAttributeValues@gmCGProfessionPage@@IAEXXZ

        // gmCGProfessionPage.UpdateProfession:
        // public void UpdateProfession() => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, void>)0xDEADBEEF)(ref this); // .text:004821B0 ; void __thiscall gmCGProfessionPage::UpdateProfession(gmCGProfessionPage *this) .text:004821B0 ?UpdateProfession@gmCGProfessionPage@@IAEXXZ

        // gmCGProfessionPage.UpdateToDefaultAttributes:
        // public void UpdateToDefaultAttributes() => ((delegate* unmanaged[Thiscall]<ref gmCGProfessionPage, void>)0xDEADBEEF)(ref this); // .text:00482860 ; void __thiscall gmCGProfessionPage::UpdateToDefaultAttributes(gmCGProfessionPage *this) .text:00482860 ?UpdateToDefaultAttributes@gmCGProfessionPage@@QAEXXZ
    }
    public unsafe struct gmCGSkillsPage {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public gmCGSkillsPage.tagSkillRecord m_tConstInit;
        public UIElement* m_pSpecEntry;
        public UIElement* m_pTrainedEntry;
        public UIElement* m_pUseableUntrainedEntry;
        public UIElement* m_pUnuseableUntrainedEntry;
        public UIElement_Text* m_pCreditsMeter;
        public UIElement_Text* m_pInfoBoxTitle;
        public UIElement_Text* m_pInfoBoxText;
        public CPlayerSystem* m_pPlayerSystem;
        public gmCharGenMainUI* m_pMainFramework;
        public UIElement_ListBox* m_pSkillsListBox;
        public HashTable<UInt32, gmCGSkillsPage.tagSkillRecord> m_hashSkills;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_tConstInit(gmCGSkillsPage.tagSkillRecord):{m_tConstInit}, m_pSpecEntry:->(UIElement*)0x{(int)m_pSpecEntry:X8}, m_pTrainedEntry:->(UIElement*)0x{(int)m_pTrainedEntry:X8}, m_pUseableUntrainedEntry:->(UIElement*)0x{(int)m_pUseableUntrainedEntry:X8}, m_pUnuseableUntrainedEntry:->(UIElement*)0x{(int)m_pUnuseableUntrainedEntry:X8}, m_pCreditsMeter:->(UIElement_Text*)0x{(int)m_pCreditsMeter:X8}, m_pInfoBoxTitle:->(UIElement_Text*)0x{(int)m_pInfoBoxTitle:X8}, m_pInfoBoxText:->(UIElement_Text*)0x{(int)m_pInfoBoxText:X8}, m_pPlayerSystem:->(CPlayerSystem*)0x{(int)m_pPlayerSystem:X8}, m_pMainFramework:->(gmCharGenMainUI*)0x{(int)m_pMainFramework:X8}, m_pSkillsListBox:->(UIElement_ListBox*)0x{(int)m_pSkillsListBox:X8}, m_hashSkills(HashTable<UInt32,gmCGSkillsPage.tagSkillRecord,0>):{m_hashSkills}";
        public unsafe struct tagSkillRecord {
            public UIElement* pEntry;
            public UIElement_Text* pUpCostText;
            public UIElement_Text* pDownCostText;
            public UIElement_Text* pSkillLevelText;
            public UIElement_Button* pSkillUpButton;
            public UIElement_Button* pSkillDownButton;
            public PStringBase<UInt16> strName;
            public PStringBase<UInt16> strDesc;
            public PStringBase<UInt16> strFormula;
            public int iSkillID;
            public int iSkillLevel;
            public int iTrainCost;
            public int iSpecCost;
            public int iMinlevel;
            public Byte bUntrainable;
            public Byte bUnspecializable;
            public SKILL_ADVANCEMENT_CLASS saCurClass;
            public SkillFormula formSkill;
            public override string ToString() => $"pEntry:->(UIElement*)0x{(int)pEntry:X8}, pUpCostText:->(UIElement_Text*)0x{(int)pUpCostText:X8}, pDownCostText:->(UIElement_Text*)0x{(int)pDownCostText:X8}, pSkillLevelText:->(UIElement_Text*)0x{(int)pSkillLevelText:X8}, pSkillUpButton:->(UIElement_Button*)0x{(int)pSkillUpButton:X8}, pSkillDownButton:->(UIElement_Button*)0x{(int)pSkillDownButton:X8}, strName:{strName}, strDesc:{strDesc}, strFormula:{strFormula}, iSkillID(int):{iSkillID}, iSkillLevel(int):{iSkillLevel}, iTrainCost(int):{iTrainCost}, iSpecCost(int):{iSpecCost}, iMinlevel(int):{iMinlevel}, bUntrainable:{bUntrainable:X2}, bUnspecializable:{bUnspecializable:X2}, saCurClass(SKILL_ADVANCEMENT_CLASS):{saCurClass}, formSkill(SkillFormula):{formSkill}";
        }

        // Functions:

        // gmCGSkillsPage.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:00481640 ; void __thiscall gmCGSkillsPage::gmCGSkillsPage(gmCGSkillsPage *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:00481640 ??0gmCGSkillsPage@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGSkillsPage.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:00481770 ; UIElement *__cdecl gmCGSkillsPage::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:00481770 ?Create@gmCGSkillsPage@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGSkillsPage.DecreaseSkillLevel:
        // public void DecreaseSkillLevel(UIElement* pEntry) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, UIElement*, void>)0xDEADBEEF)(ref this, pEntry); // .text:00480D60 ; void __thiscall gmCGSkillsPage::DecreaseSkillLevel(gmCGSkillsPage *this, UIElement *pEntry) .text:00480D60 ?DecreaseSkillLevel@gmCGSkillsPage@@IAEXPAVUIElement@@@Z

        // gmCGSkillsPage.DoSkillRecords:
        // public void DoSkillRecords() => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, void>)0xDEADBEEF)(ref this); // .text:004817E0 ; void __thiscall gmCGSkillsPage::DoSkillRecords(gmCGSkillsPage *this) .text:004817E0 ?DoSkillRecords@gmCGSkillsPage@@IAEXXZ

        // gmCGSkillsPage.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:004816B0 ; UIElement *__thiscall gmCGSkillsPage::DynamicCast(gmCGSkillsPage *this, unsigned int i_eType) .text:004816B0 ?DynamicCast@gmCGSkillsPage@@UAEPAVUIElement@@K@Z

        // gmCGSkillsPage.GetUIElementType:
        // public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, UInt32>)0xDEADBEEF)(ref this); // .text:004816D0 ; unsigned int __thiscall gmCGSkillsPage::GetUIElementType(gmCGSkillsPage *this) .text:004816D0 ?GetUIElementType@gmCGSkillsPage@@UBEKXZ

        // gmCGSkillsPage.IncreaseSkillLevel:
        // public void IncreaseSkillLevel(UIElement* pEntry) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, UIElement*, void>)0xDEADBEEF)(ref this, pEntry); // .text:00480CA0 ; void __thiscall gmCGSkillsPage::IncreaseSkillLevel(gmCGSkillsPage *this, UIElement *pEntry) .text:00480CA0 ?IncreaseSkillLevel@gmCGSkillsPage@@IAEXPAVUIElement@@@Z

        // gmCGSkillsPage.InitializePage:
        public void InitializePage(gmCharGenMainUI* _pMain) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, gmCharGenMainUI*, void>)0x00482190)(ref this, _pMain); // .text:00481DD0 ; void __thiscall gmCGSkillsPage::InitializePage(gmCGSkillsPage *this, gmCharGenMainUI *_pMain) .text:00481DD0 ?InitializePage@gmCGSkillsPage@@QAEXPAVgmCharGenMainUI@@@Z

        // gmCGSkillsPage.InsertEntrySorted:
        // public void InsertEntrySorted(gmCGSkillsPage.tagSkillRecord* tRec, UIElement* pAfter, UIElement* pBefore) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, gmCGSkillsPage.tagSkillRecord*, UIElement*, UIElement*, void>)0xDEADBEEF)(ref this, tRec, pAfter, pBefore); // .text:00480A40 ; void __thiscall gmCGSkillsPage::InsertEntrySorted(gmCGSkillsPage *this, gmCGSkillsPage::tagSkillRecord *tRec, UIElement *pAfter, UIElement *pBefore) .text:00480A40 ?InsertEntrySorted@gmCGSkillsPage@@IAEXAAUtagSkillRecord@1@PAVUIElement@@1@Z

        // gmCGSkillsPage.ListenToElementMessage:
        // public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, UIElementMessageInfo*, UIElementMessageListenResult>)0xDEADBEEF)(ref this, i_rMsg); // .text:004814C0 ; UIElementMessageListenResult __thiscall gmCGSkillsPage::ListenToElementMessage(gmCGSkillsPage *this, UIElementMessageInfo *i_rMsg) .text:004814C0 ?ListenToElementMessage@gmCGSkillsPage@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmCGSkillsPage.MakeSkillFormula:
        // public void MakeSkillFormula(gmCGSkillsPage.tagSkillRecord* tRec) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, gmCGSkillsPage.tagSkillRecord*, void>)0xDEADBEEF)(ref this, tRec); // .text:00480E10 ; void __thiscall gmCGSkillsPage::MakeSkillFormula(gmCGSkillsPage *this, gmCGSkillsPage::tagSkillRecord *tRec) .text:00480E10 ?MakeSkillFormula@gmCGSkillsPage@@IAEXAAUtagSkillRecord@1@@Z

        // gmCGSkillsPage.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, void>)0x00480750)(ref this); // .text:0047C100 ; void __thiscall gmCGSkillsPage::PostInit(gmCGTownPage *this) .text:0047C100 ?PostInit@gmCGSkillsPage@@UAEXXZ

        // gmCGSkillsPage.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x00481B80)(); // .text:004817C0 ; void __cdecl gmCGSkillsPage::Register() .text:004817C0 ?Register@gmCGSkillsPage@@SAXXZ

        // gmCGSkillsPage.SetSkillText:
        // public void SetSkillText(gmCGSkillsPage.tagSkillRecord* tRec) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, gmCGSkillsPage.tagSkillRecord*, void>)0xDEADBEEF)(ref this, tRec); // .text:00480600 ; void __thiscall gmCGSkillsPage::SetSkillText(gmCGSkillsPage *this, gmCGSkillsPage::tagSkillRecord *tRec) .text:00480600 ?SetSkillText@gmCGSkillsPage@@IAEXAAUtagSkillRecord@1@@Z

        // gmCGSkillsPage.ShowSkillsText:
        // public void ShowSkillsText(UIElement* pEntry) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, UIElement*, void>)0xDEADBEEF)(ref this, pEntry); // .text:00481250 ; void __thiscall gmCGSkillsPage::ShowSkillsText(gmCGSkillsPage *this, UIElement *pEntry) .text:00481250 ?ShowSkillsText@gmCGSkillsPage@@IAEXPAVUIElement@@@Z

        // gmCGSkillsPage.Update:
        // public void Update() => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, void>)0xDEADBEEF)(ref this); // .text:00481DC0 ; void __thiscall gmCGSkillsPage::Update(gmCGSkillsPage *this) .text:00481DC0 ?Update@gmCGSkillsPage@@QAEXXZ

        // gmCGSkillsPage.UpdateAllTrainingValues:
        // public void UpdateAllTrainingValues() => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, void>)0xDEADBEEF)(ref this); // .text:00480950 ; void __thiscall gmCGSkillsPage::UpdateAllTrainingValues(gmCGSkillsPage *this) .text:00480950 ?UpdateAllTrainingValues@gmCGSkillsPage@@IAEXXZ

        // gmCGSkillsPage.UpdateCreditsMeter:
        // public void UpdateCreditsMeter() => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, void>)0xDEADBEEF)(ref this); // .text:004808F0 ; void __thiscall gmCGSkillsPage::UpdateCreditsMeter(gmCGSkillsPage *this) .text:004808F0 ?UpdateCreditsMeter@gmCGSkillsPage@@IAEXXZ

        // gmCGSkillsPage.UpdateSkillEntry:
        // public void UpdateSkillEntry(gmCGSkillsPage.tagSkillRecord* tRec) => ((delegate* unmanaged[Thiscall]<ref gmCGSkillsPage, gmCGSkillsPage.tagSkillRecord*, void>)0xDEADBEEF)(ref this, tRec); // .text:00480BF0 ; void __thiscall gmCGSkillsPage::UpdateSkillEntry(gmCGSkillsPage *this, gmCGSkillsPage::tagSkillRecord *tRec) .text:00480BF0 ?UpdateSkillEntry@gmCGSkillsPage@@IAEXAAUtagSkillRecord@1@@Z
    }
    public unsafe struct gmCGAppearancePage {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public CPlayerSystem* m_pPlayerSystem;
        public gmCharGenMainUI* m_pMainFramework;
        public UIElement_Button* m_pFemaleButton;
        public UIElement_Button* m_pMaleButton;
        public UIElement_Button* m_pFaceButton;
        public UIElement_Button* m_pClothesButton;
        public UIElement_Button* m_pZoomInButton;
        public UIElement_Button* m_pZoomOutButton;
        public UIElement_Button* m_pRotateClockButton;
        public UIElement_Button* m_pRotateCounterClockButton;
        public UIElement_Button* m_pHairSpin;
        public UIElement_Button* m_pEyesSpin;
        public UIElement_Button* m_pNoseSpin;
        public UIElement_Button* m_pMouthSpin;
        public UIElement_Button* m_pSkinSpin;
        public UIElement_Button* m_pHeadgearSpin;
        public UIElement_Button* m_pShirtSpin;
        public UIElement_Button* m_pTrousersSpin;
        public UIElement_Button* m_pFootwearSpin;
        public UIElement_Scrollbar* m_pShadeScroll;
        public UIElement* m_pFaceChoices;
        public UIElement* m_pClothesChoices;
        public UIElement* m_pGradCircle;
        public Graphic* m_pGradGraphic;
        public Graphic* m_pGradPlug;
        public UIElement* m_pCurSelection;
        public UIElement_Viewport* m_pViewport;
        public gmCG3DView* m_p3DView;
        public int m_iCurColor;
        public int m_iPartIndex;
        public int m_iHoldheadgear;
        public Byte m_bShouldZoomAnimate;
        public Byte m_bRotating;
        public Byte m_bZoomedIn;
        public AC1Legacy.Vector3 m_vectTargPosition;
        public AC1Legacy.Vector3 m_vectStartPosition;
        public AC1Legacy.Vector3 m_vectCurPosition;
        public AC1Legacy.Vector3 m_vectTargDirection;
        public AC1Legacy.Vector3 m_vectStartDirection;
        public AC1Legacy.Vector3 m_vectCurDirection;
        public Single m_fCurHeading;
        public Single m_fTargHeading;
        public Double m_dAnimStartTime;
        public Double m_dAnimDuration;
        public Double m_dLastRotateTime;
        public Double m_dRotationPerSec;
        public UInt32 m_LastHeritageGroup;
        public gmCGAppearancePage.ERotateDirection m_eRotateDir;
        public gmCGAppearancePage.EType m_eCurType;
        public fixed int m_tChoices[9];
        public gmCGAppearancePage.EParts m_eCurPart;
        public fixed int m_tColorWheel[9];
        public gmCGAppearancePage.EGender m_eGender;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_pPlayerSystem:->(CPlayerSystem*)0x{(int)m_pPlayerSystem:X8}, m_pMainFramework:->(gmCharGenMainUI*)0x{(int)m_pMainFramework:X8}, m_pFemaleButton:->(UIElement_Button*)0x{(int)m_pFemaleButton:X8}, m_pMaleButton:->(UIElement_Button*)0x{(int)m_pMaleButton:X8}, m_pFaceButton:->(UIElement_Button*)0x{(int)m_pFaceButton:X8}, m_pClothesButton:->(UIElement_Button*)0x{(int)m_pClothesButton:X8}, m_pZoomInButton:->(UIElement_Button*)0x{(int)m_pZoomInButton:X8}, m_pZoomOutButton:->(UIElement_Button*)0x{(int)m_pZoomOutButton:X8}, m_pRotateClockButton:->(UIElement_Button*)0x{(int)m_pRotateClockButton:X8}, m_pRotateCounterClockButton:->(UIElement_Button*)0x{(int)m_pRotateCounterClockButton:X8}, m_pHairSpin:->(UIElement_Button*)0x{(int)m_pHairSpin:X8}, m_pEyesSpin:->(UIElement_Button*)0x{(int)m_pEyesSpin:X8}, m_pNoseSpin:->(UIElement_Button*)0x{(int)m_pNoseSpin:X8}, m_pMouthSpin:->(UIElement_Button*)0x{(int)m_pMouthSpin:X8}, m_pSkinSpin:->(UIElement_Button*)0x{(int)m_pSkinSpin:X8}, m_pHeadgearSpin:->(UIElement_Button*)0x{(int)m_pHeadgearSpin:X8}, m_pShirtSpin:->(UIElement_Button*)0x{(int)m_pShirtSpin:X8}, m_pTrousersSpin:->(UIElement_Button*)0x{(int)m_pTrousersSpin:X8}, m_pFootwearSpin:->(UIElement_Button*)0x{(int)m_pFootwearSpin:X8}, m_pShadeScroll:->(UIElement_Scrollbar*)0x{(int)m_pShadeScroll:X8}, m_pFaceChoices:->(UIElement*)0x{(int)m_pFaceChoices:X8}, m_pClothesChoices:->(UIElement*)0x{(int)m_pClothesChoices:X8}, m_pGradCircle:->(UIElement*)0x{(int)m_pGradCircle:X8}, m_pGradGraphic:->(Graphic*)0x{(int)m_pGradGraphic:X8}, m_pGradPlug:->(Graphic*)0x{(int)m_pGradPlug:X8}, m_pCurSelection:->(UIElement*)0x{(int)m_pCurSelection:X8}, m_pViewport:->(UIElement_Viewport*)0x{(int)m_pViewport:X8}, m_p3DView:->(gmCG3DView*)0x{(int)m_p3DView:X8}, m_iCurColor(int):{m_iCurColor}, m_iPartIndex(int):{m_iPartIndex}, m_iHoldheadgear(int):{m_iHoldheadgear}, m_bShouldZoomAnimate:{m_bShouldZoomAnimate:X2}, m_bRotating:{m_bRotating:X2}, m_bZoomedIn:{m_bZoomedIn:X2}, m_vectTargPosition(AC1Legacy.Vector3):{m_vectTargPosition}, m_vectStartPosition(AC1Legacy.Vector3):{m_vectStartPosition}, m_vectCurPosition(AC1Legacy.Vector3):{m_vectCurPosition}, m_vectTargDirection(AC1Legacy.Vector3):{m_vectTargDirection}, m_vectStartDirection(AC1Legacy.Vector3):{m_vectStartDirection}, m_vectCurDirection(AC1Legacy.Vector3):{m_vectCurDirection}, m_fCurHeading:{m_fCurHeading:n5}, m_fTargHeading:{m_fTargHeading:n5}, m_dAnimStartTime:{m_dAnimStartTime:n5}, m_dAnimDuration:{m_dAnimDuration:n5}, m_dLastRotateTime:{m_dLastRotateTime:n5}, m_dRotationPerSec:{m_dRotationPerSec:n5}, m_LastHeritageGroup:{m_LastHeritageGroup:X8}, m_eRotateDir(gmCGAppearancePage.ERotateDirection):{m_eRotateDir}, m_eCurType(gmCGAppearancePage.EType):{m_eCurType}, m_tChoices[9](fixed int):{m_tChoices[9]}, m_eCurPart(gmCGAppearancePage.EParts):{m_eCurPart}, m_tColorWheel[9](fixed int):{m_tColorWheel[9]}, m_eGender(gmCGAppearancePage.EGender):{m_eGender}";
        public unsafe struct tagChoices {
            public int iNumChoices;
            public int iCurrentChoice;
            public int iNumColors;
            public int iCurrentColor;
            public Double dShade;
            public override string ToString() => $"iNumChoices(int):{iNumChoices}, iCurrentChoice(int):{iCurrentChoice}, iNumColors(int):{iNumColors}, iCurrentColor(int):{iCurrentColor}, dShade:{dShade:n5}";
        }
        public unsafe struct tagColorWheel {
            public UInt32 iRed;
            public UInt32 iGreen;
            public UInt32 iBlue;
            public UIElement* pColor;
            public UIElement* pPointer;
            public Graphic* pGraphic;
            public gmCGAppearancePage.EParts ePart;
            public override string ToString() => $"iRed:{iRed:X8}, iGreen:{iGreen:X8}, iBlue:{iBlue:X8}, pColor:->(UIElement*)0x{(int)pColor:X8}, pPointer:->(UIElement*)0x{(int)pPointer:X8}, pGraphic:->(Graphic*)0x{(int)pGraphic:X8}, ePart(gmCGAppearancePage.EParts):{ePart}";
        }
        public enum EParts : UInt32 {
            ECG_PARTS_INVALID = 0x0,
            ECG_PARTS_HAIR = 0x1,
            ECG_PARTS_EYES = 0x2,
            ECG_PARTS_NOSE = 0x3,
            ECG_PARTS_MOUTH = 0x4,
            ECG_PARTS_SKIN = 0x5,
            ECG_PARTS_HEADGEAR = 0x6,
            ECG_PARTS_SHIRT = 0x7,
            ECG_PARTS_TROUSERS = 0x8,
            ECG_PARTS_FOOTWEAR = 0x9,
        };
        public enum ERotateDirection : UInt32 {
            ECG_ROTATE_INVALID = 0x0,
            ECG_ROTATE_CLOCKWISE = 0x1,
            ECG_ROTATE_COUNTERCLOCKWISE = 0x2,
        };
        public enum EGender : UInt32 {
            ECG_GENDER_INVALID = 0x0,
            ECG_GENDER_FEMALE = 0x1,
            ECG_GENDER_MALE = 0x2,
        };

        // Enums:
        public enum EType : UInt32 {
            ECG_CHOICE_INVALID = 0x0,
            ECG_CHOICE_FACE = 0x1,
            ECG_CHOICE_CLOTHES = 0x2,
        };

        // Functions:

        // gmCGAppearancePage.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:0047CCC0 ; void __thiscall gmCGAppearancePage::gmCGAppearancePage(gmCGAppearancePage *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0047CCC0 ??0gmCGAppearancePage@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGAppearancePage.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:0047CEA0 ; UIElement *__cdecl gmCGAppearancePage::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:0047CEA0 ?Create@gmCGAppearancePage@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGAppearancePage.DoColorSpots:
        // public void DoColorSpots(int _iPart) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, int, void>)0xDEADBEEF)(ref this, _iPart); // .text:0047D850 ; void __thiscall gmCGAppearancePage::DoColorSpots(gmCGAppearancePage *this, int _iPart) .text:0047D850 ?DoColorSpots@gmCGAppearancePage@@IAEXH@Z

        // gmCGAppearancePage.DoGradDisk:
        // public void DoGradDisk(Byte _bUsePlug) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, Byte, void>)0xDEADBEEF)(ref this, _bUsePlug); // .text:0047DA90 ; void __thiscall gmCGAppearancePage::DoGradDisk(gmCGAppearancePage *this, bool _bUsePlug) .text:0047DA90 ?DoGradDisk@gmCGAppearancePage@@IAEX_N@Z

        // gmCGAppearancePage.DoRotation:
        // public void DoRotation() => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, void>)0xDEADBEEF)(ref this); // .text:0047CA80 ; void __thiscall gmCGAppearancePage::DoRotation(gmCGAppearancePage *this) .text:0047CA80 ?DoRotation@gmCGAppearancePage@@IAEXXZ

        // gmCGAppearancePage.DoZoomAnimation:
        // public void DoZoomAnimation() => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, void>)0xDEADBEEF)(ref this); // .text:0047C960 ; void __thiscall gmCGAppearancePage::DoZoomAnimation(gmCGAppearancePage *this) .text:0047C960 ?DoZoomAnimation@gmCGAppearancePage@@IAEXXZ

        // gmCGAppearancePage.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, UInt32, UIElement*>)0x0047CBC0)(ref this, i_eType); // .text:0047C810 ; UIElement *__thiscall gmCGAppearancePage::DynamicCast(gmCGAppearancePage *this, unsigned int i_eType) .text:0047C810 ?DynamicCast@gmCGAppearancePage@@UAEPAVUIElement@@K@Z

        // gmCGAppearancePage.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, UInt32>)0x0047CBE0)(ref this); // .text:0047C830 ; unsigned int __thiscall gmCGAppearancePage::GetUIElementType(gmCGAppearancePage *this) .text:0047C830 ?GetUIElementType@gmCGAppearancePage@@UBEKXZ

        // gmCGAppearancePage.InitializePage:
        public void InitializePage(gmCharGenMainUI* _pMain) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, gmCharGenMainUI*, void>)0x00480180)(ref this, _pMain); // .text:0047FDD0 ; void __thiscall gmCGAppearancePage::InitializePage(gmCGAppearancePage *this, gmCharGenMainUI *_pMain) .text:0047FDD0 ?InitializePage@gmCGAppearancePage@@QAEXPAVgmCharGenMainUI@@@Z

        // gmCGAppearancePage.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, UIElementMessageInfo*, UIElementMessageListenResult>)0x0047F2E0)(ref this, i_rMsg); // .text:0047EF30 ; UIElementMessageListenResult __thiscall gmCGAppearancePage::ListenToElementMessage(gmCGAppearancePage *this, UIElementMessageInfo *i_rMsg) .text:0047EF30 ?ListenToElementMessage@gmCGAppearancePage@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmCGAppearancePage.ListenToGlobalMessage:
        public void ListenToGlobalMessage(UInt32 _messageID, int _data_int) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, UInt32, int, void>)0x0047D280)(ref this, _messageID, _data_int); // .text:0047CED0 ; void __thiscall gmCGAppearancePage::ListenToGlobalMessage(gmCGAppearancePage *this, unsigned int _messageID, int _data_int) .text:0047CED0 ?ListenToGlobalMessage@gmCGAppearancePage@@UAEXKJ@Z

        // gmCGAppearancePage.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, void>)0x0047CB80)(ref this); // .text:0047C7D0 ; void __thiscall gmCGAppearancePage::PostInit(gmCGAppearancePage *this) .text:0047C7D0 ?PostInit@gmCGAppearancePage@@UAEXXZ

        // gmCGAppearancePage.RecvNotice_PlayerObjDescChanged:
        public void RecvNotice_PlayerObjDescChanged() => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, void>)0x0047CBF0)(ref this); // .text:0047C840 ; void __thiscall gmCGAppearancePage::RecvNotice_PlayerObjDescChanged(gmCGAppearancePage *this) .text:0047C840 ?RecvNotice_PlayerObjDescChanged@gmCGAppearancePage@@UAEXXZ

        // gmCGAppearancePage.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x0047D840)(); // .text:0047D490 ; void __cdecl gmCGAppearancePage::Register() .text:0047D490 ?Register@gmCGAppearancePage@@SAXXZ

        // gmCGAppearancePage.Rotate:
        // public void Rotate(gmCGAppearancePage.ERotateDirection _eDir) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, gmCGAppearancePage.ERotateDirection, void>)0xDEADBEEF)(ref this, _eDir); // .text:0047CB50 ; void __thiscall gmCGAppearancePage::Rotate(gmCGAppearancePage *this, gmCGAppearancePage::ERotateDirection _eDir) .text:0047CB50 ?Rotate@gmCGAppearancePage@@IAEXW4ERotateDirection@1@@Z

        // gmCGAppearancePage.SetChoice:
        // public void SetChoice(gmCGAppearancePage.EType _eType) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, gmCGAppearancePage.EType, void>)0xDEADBEEF)(ref this, _eType); // .text:0047D4B0 ; void __thiscall gmCGAppearancePage::SetChoice(gmCGAppearancePage *this, gmCGAppearancePage::EType _eType) .text:0047D4B0 ?SetChoice@gmCGAppearancePage@@IAEXW4EType@1@@Z

        // gmCGAppearancePage.SetColor:
        // public void SetColor(int _iColor) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, int, void>)0xDEADBEEF)(ref this, _iColor); // .text:0047DD50 ; void __thiscall gmCGAppearancePage::SetColor(gmCGAppearancePage *this, int _iColor) .text:0047DD50 ?SetColor@gmCGAppearancePage@@IAEXH@Z

        // gmCGAppearancePage.SetSelection:
        // public void SetSelection(gmCGAppearancePage.EParts _ePart) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, gmCGAppearancePage.EParts, void>)0xDEADBEEF)(ref this, _ePart); // .text:0047E260 ; void __thiscall gmCGAppearancePage::SetSelection(gmCGAppearancePage *this, gmCGAppearancePage::EParts _ePart) .text:0047E260 ?SetSelection@gmCGAppearancePage@@IAEXW4EParts@1@@Z

        // gmCGAppearancePage.SetShade:
        // public void SetShade(Double _dShade) => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, Double, void>)0xDEADBEEF)(ref this, _dShade); // .text:0047C860 ; void __thiscall gmCGAppearancePage::SetShade(gmCGAppearancePage *this, long double _dShade) .text:0047C860 ?SetShade@gmCGAppearancePage@@IAEXN@Z

        // gmCGAppearancePage.SetupParts:
        // public void SetupParts() => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, void>)0xDEADBEEF)(ref this); // .text:0047E020 ; void __thiscall gmCGAppearancePage::SetupParts(gmCGAppearancePage *this) .text:0047E020 ?SetupParts@gmCGAppearancePage@@QAEXXZ

        // gmCGAppearancePage.Update:
        // public void Update() => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, void>)0xDEADBEEF)(ref this); // .text:0047E8F0 ; void __thiscall gmCGAppearancePage::Update(gmCGAppearancePage *this) .text:0047E8F0 ?Update@gmCGAppearancePage@@QAEXXZ

        // gmCGAppearancePage.ZoomIn:
        // public void ZoomIn() => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, void>)0xDEADBEEF)(ref this); // .text:0047CF00 ; void __thiscall gmCGAppearancePage::ZoomIn(gmCGAppearancePage *this) .text:0047CF00 ?ZoomIn@gmCGAppearancePage@@IAEXXZ

        // gmCGAppearancePage.ZoomOut:
        // public void ZoomOut() => ((delegate* unmanaged[Thiscall]<ref gmCGAppearancePage, void>)0xDEADBEEF)(ref this); // .text:0047D050 ; void __thiscall gmCGAppearancePage::ZoomOut(gmCGAppearancePage *this) .text:0047D050 ?ZoomOut@gmCGAppearancePage@@IAEXXZ
    }
    public unsafe struct gmCGTownPage {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public CPlayerSystem* m_pPlayerSystem;
        public gmCharGenMainUI* m_pMainFramework;
        public UIElement_Button* m_pSanamarButton;
        public UIElement_Button* m_pHoltButton;
        public UIElement_Button* m_pYaraqButton;
        public UIElement_Button* m_pShoushiButton;
        public UIElement_Text* m_pTextBox;
        public gmCGTownPage.ETown m_eCurTown;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_pPlayerSystem:->(CPlayerSystem*)0x{(int)m_pPlayerSystem:X8}, m_pMainFramework:->(gmCharGenMainUI*)0x{(int)m_pMainFramework:X8}, m_pSanamarButton:->(UIElement_Button*)0x{(int)m_pSanamarButton:X8}, m_pHoltButton:->(UIElement_Button*)0x{(int)m_pHoltButton:X8}, m_pYaraqButton:->(UIElement_Button*)0x{(int)m_pYaraqButton:X8}, m_pShoushiButton:->(UIElement_Button*)0x{(int)m_pShoushiButton:X8}, m_pTextBox:->(UIElement_Text*)0x{(int)m_pTextBox:X8}, m_eCurTown(gmCGTownPage.ETown):{m_eCurTown}";
        // Enums:
        public enum ETown : UInt32 {
            ECG_TOWN_INVALID = 0x0,
            ECG_TOWN_HOLTBURG = 0x1,
            ECG_TOWN_SHOUSHI = 0x2,
            ECG_TOWN_YARAQ = 0x3,
            ECG_TOWN_SANAMAR = 0x4,
        };

        // Functions:

        // gmCGTownPage.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x0047C4C0)(_layout, _full_desc); // .text:0047C110 ; UIElement *__cdecl gmCGTownPage::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:0047C110 ?Create@gmCGTownPage@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGTownPage.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmCGTownPage, UInt32, UIElement*>)0x0047C490)(ref this, i_eType); // .text:0047C0D0 ; UIElement *__thiscall gmCGTownPage::DynamicCast(gmCGTownPage *this, unsigned int i_eType) .text:0047C0D0 ?DynamicCast@gmCGTownPage@@UAEPAVUIElement@@K@Z

        // gmCGTownPage.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmCGTownPage, UInt32>)0x0047C4B0)(ref this); // .text:0047C0F0 ; unsigned int __thiscall gmCGTownPage::GetUIElementType(gmCGTownPage *this) .text:0047C0F0 ?GetUIElementType@gmCGTownPage@@UBEKXZ

        // gmCGTownPage.InitializePage:
        public void InitializePage(gmCharGenMainUI* _pMain) => ((delegate* unmanaged[Thiscall]<ref gmCGTownPage, gmCharGenMainUI*, void>)0x0047CA80)(ref this, _pMain); // .text:0047C6D0 ; void __thiscall gmCGTownPage::InitializePage(gmCGTownPage *this, gmCharGenMainUI *_pMain) .text:0047C6D0 ?InitializePage@gmCGTownPage@@QAEXPAVgmCharGenMainUI@@@Z

        // gmCGTownPage.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmCGTownPage, UIElementMessageInfo*, UIElementMessageListenResult>)0x0047C830)(ref this, i_rMsg); // .text:0047C480 ; UIElementMessageListenResult __thiscall gmCGTownPage::ListenToElementMessage(gmCGTownPage *this, UIElementMessageInfo *i_rMsg) .text:0047C480 ?ListenToElementMessage@gmCGTownPage@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmCGTownPage.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x0047C580)(); // .text:0047C1D0 ; void __cdecl gmCGTownPage::Register() .text:0047C1D0 ?Register@gmCGTownPage@@SAXXZ

        // gmCGTownPage.SetTown:
        // public void SetTown(gmCGTownPage.ETown _eTown) => ((delegate* unmanaged[Thiscall]<ref gmCGTownPage, gmCGTownPage.ETown, void>)0xDEADBEEF)(ref this, _eTown); // .text:0047C360 ; void __thiscall gmCGTownPage::SetTown(gmCGTownPage *this, gmCGTownPage::ETown _eTown) .text:0047C360 ?SetTown@gmCGTownPage@@IAEXW4ETown@1@@Z

        // gmCGTownPage.SetTownString:
        public void SetTownString(gmCGTownPage.ETown _eTown) => ((delegate* unmanaged[Thiscall]<ref gmCGTownPage, gmCGTownPage.ETown, void>)0x0047C5A0)(ref this, _eTown); // .text:0047C1F0 ; void __thiscall gmCGTownPage::SetTownString(gmCGTownPage *this, gmCGTownPage::ETown _eTown) .text:0047C1F0 ?SetTownString@gmCGTownPage@@IAEXW4ETown@1@@Z

        // gmCGTownPage.Update:
        // public void Update() => ((delegate* unmanaged[Thiscall]<ref gmCGTownPage, void>)0xDEADBEEF)(ref this); // .text:0047C460 ; void __thiscall gmCGTownPage::Update(gmCGTownPage *this) .text:0047C460 ?Update@gmCGTownPage@@QAEXXZ
    }
    public unsafe struct gmCGSummaryPage {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public CPlayerSystem* m_pPlayerSystem;
        public gmCharGenMainUI* m_pMainFramework;
        public UIElement_ListBox* m_pSummaryListbix;
        public UIElement_Text* m_pNameText;
        public UIElement_Text* m_pHowToText;
        public UIElement_Scrollbar* m_pScoll;
        public UIElement_Viewport* m_pViewport;
        public gmCG3DView* m_p3DView;
        public Byte m_bNameEntered;
        public UInt32 m_uiErrorMessageContext;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_pPlayerSystem:->(CPlayerSystem*)0x{(int)m_pPlayerSystem:X8}, m_pMainFramework:->(gmCharGenMainUI*)0x{(int)m_pMainFramework:X8}, m_pSummaryListbix:->(UIElement_ListBox*)0x{(int)m_pSummaryListbix:X8}, m_pNameText:->(UIElement_Text*)0x{(int)m_pNameText:X8}, m_pHowToText:->(UIElement_Text*)0x{(int)m_pHowToText:X8}, m_pScoll:->(UIElement_Scrollbar*)0x{(int)m_pScoll:X8}, m_pViewport:->(UIElement_Viewport*)0x{(int)m_pViewport:X8}, m_p3DView:->(gmCG3DView*)0x{(int)m_p3DView:X8}, m_bNameEntered:{m_bNameEntered:X2}, m_uiErrorMessageContext:{m_uiErrorMessageContext:X8}";

        // Functions:

        // gmCGSummaryPage.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, LayoutDesc*, ElementDesc*, void>)0x0047B030)(ref this, _layout, _full_desc); // .text:0047AC70 ; void __thiscall gmCGSummaryPage::gmCGSummaryPage(gmCGSummaryPage *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0047AC70 ??0gmCGSummaryPage@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGSummaryPage.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x0047B110)(_layout, _full_desc); // .text:0047AD50 ; UIElement *__cdecl gmCGSummaryPage::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:0047AD50 ?Create@gmCGSummaryPage@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmCGSummaryPage.DoNameLimitDialog:
        public void DoNameLimitDialog() => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, void>)0x0047C140)(ref this); // .text:0047BD80 ; void __thiscall gmCGSummaryPage::DoNameLimitDialog(gmCGSummaryPage *this) .text:0047BD80 ?DoNameLimitDialog@gmCGSummaryPage@@IAEXXZ

        // gmCGSummaryPage.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, UInt32, UIElement*>)0x0047B0A0)(ref this, i_eType); // .text:0047ACE0 ; UIElement *__thiscall gmCGSummaryPage::DynamicCast(gmCGSummaryPage *this, unsigned int i_eType) .text:0047ACE0 ?DynamicCast@gmCGSummaryPage@@UAEPAVUIElement@@K@Z

        // gmCGSummaryPage.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, UInt32>)0x0047B0C0)(ref this); // .text:0047AD00 ; unsigned int __thiscall gmCGSummaryPage::GetUIElementType(gmCGSummaryPage *this) .text:0047AD00 ?GetUIElementType@gmCGSummaryPage@@UBEKXZ

        // gmCGSummaryPage.InitializePage:
        public void InitializePage(gmCharGenMainUI* _pMain) => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, gmCharGenMainUI*, void>)0x0047BFB0)(ref this, _pMain); // .text:0047BBF0 ; void __thiscall gmCGSummaryPage::InitializePage(gmCGSummaryPage *this, gmCharGenMainUI *_pMain) .text:0047BBF0 ?InitializePage@gmCGSummaryPage@@QAEXPAVgmCharGenMainUI@@@Z

        // gmCGSummaryPage.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, UIElementMessageInfo*, UIElementMessageListenResult>)0x0047C300)(ref this, i_rMsg); // .text:0047BF40 ; UIElementMessageListenResult __thiscall gmCGSummaryPage::ListenToElementMessage(gmCGSummaryPage *this, UIElementMessageInfo *i_rMsg) .text:0047BF40 ?ListenToElementMessage@gmCGSummaryPage@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmCGSummaryPage.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, void>)0x0047B0D0)(ref this); // .text:0047AD10 ; void __thiscall gmCGSummaryPage::PostInit(gmCGSummaryPage *this) .text:0047AD10 ?PostInit@gmCGSummaryPage@@UAEXXZ

        // gmCGSummaryPage.RecvNotice_CloseDialog:
        public void RecvNotice_CloseDialog(UInt32 context, PropertyCollection* data) => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, UInt32, PropertyCollection*, void>)0x0047B140)(ref this, context, data); // .text:0047AD80 ; void __thiscall gmCGSummaryPage::RecvNotice_CloseDialog(gmCGSummaryPage *this, unsigned int context, PropertyCollection *data) .text:0047AD80 ?RecvNotice_CloseDialog@gmCGSummaryPage@@UAEXKABVPropertyCollection@@@Z

        // gmCGSummaryPage.Register:
        // public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:0047AE00 ; void __cdecl gmCGSummaryPage::Register() .text:0047AE00 ?Register@gmCGSummaryPage@@SAXXZ

        // gmCGSummaryPage.SetHowToText:
        public void SetHowToText() => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, void>)0x0047B1E0)(ref this); // .text:0047AE20 ; void __thiscall gmCGSummaryPage::SetHowToText(gmCGSummaryPage *this) .text:0047AE20 ?SetHowToText@gmCGSummaryPage@@IAEXXZ

        // gmCGSummaryPage.SetSummaryText:
        public void SetSummaryText() => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, void>)0x0047B590)(ref this); // .text:0047B1D0 ; void __thiscall gmCGSummaryPage::SetSummaryText(gmCGSummaryPage *this) .text:0047B1D0 ?SetSummaryText@gmCGSummaryPage@@IAEXXZ

        // gmCGSummaryPage.Update:
        public void Update() => ((delegate* unmanaged[Thiscall]<ref gmCGSummaryPage, void>)0x0047BE60)(ref this); // .text:0047BAA0 ; void __thiscall gmCGSummaryPage::Update(gmCGSummaryPage *this) .text:0047BAA0 ?Update@gmCGSummaryPage@@QAEXXZ
    }
    public unsafe struct gmCG3DView {
        // Struct:
        public CPlayerSystem* m_pPlayerSystem;
        public UIElement_Viewport* m_pViewport;
        public CPhysicsObj* m_pPlayerObject;
        public CPhysicsObj* m_pbgObject;
        public UInt32 m_didAnimation;
        public UInt32 m_didAnimationRest;
        public fixed int m_didAnimArray[5];
        public Double m_dLastAnimTime;
        public UInt32 m_bgSetupID;
        public UInt32 m_alternateSetupID;
        public Single m_fHeading;
        public UInt32 m_SetupID;
        public Vector3 m_vectPosition;
        public Vector3 m_vectDirection;
        public override string ToString() => $"m_pPlayerSystem:->(CPlayerSystem*)0x{(int)m_pPlayerSystem:X8}, m_pViewport:->(UIElement_Viewport*)0x{(int)m_pViewport:X8}, m_pPlayerObject:->(CPhysicsObj*)0x{(int)m_pPlayerObject:X8}, m_pbgObject:->(CPhysicsObj*)0x{(int)m_pbgObject:X8}, m_didAnimation:{m_didAnimation:X8}, m_didAnimationRest:{m_didAnimationRest:X8}, m_didAnimArray[5](fixed int):{m_didAnimArray[5]}, m_dLastAnimTime:{m_dLastAnimTime:n5}, m_bgSetupID:{m_bgSetupID:X8}, m_alternateSetupID:{m_alternateSetupID:X8}, m_fHeading:{m_fHeading:n5}, m_SetupID:{m_SetupID:X8}, m_vectPosition(Vector3):{m_vectPosition}, m_vectDirection(Vector3):{m_vectDirection}";

        // Functions:

        // gmCG3DView.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref gmCG3DView, void>)0x004EF310)(ref this); // .text:004EE680 ; void __thiscall gmCG3DView::gmCG3DView(gmCG3DView *this) .text:004EE680 ??0gmCG3DView@@QAE@XZ

        // gmCG3DView.Initialize:
        public void Initialize(UIElement_Viewport* _pViewport) => ((delegate* unmanaged[Thiscall]<ref gmCG3DView, UIElement_Viewport*, void>)0x004EF3F0)(ref this, _pViewport); // .text:004EE760 ; void __thiscall gmCG3DView::Initialize(gmCG3DView *this, UIElement_Viewport *_pViewport) .text:004EE760 ?Initialize@gmCG3DView@@QAEXPAVUIElement_Viewport@@@Z

        // gmCG3DView.SetCamera:
        public void SetCamera(AC1Legacy.Vector3* _vectPosition, AC1Legacy.Vector3* _vectDirection) => ((delegate* unmanaged[Thiscall]<ref gmCG3DView, AC1Legacy.Vector3*, AC1Legacy.Vector3*, void>)0x004EF240)(ref this, _vectPosition, _vectDirection); // .text:004EE5B0 ; void __thiscall gmCG3DView::SetCamera(gmCG3DView *this, AC1Legacy::Vector3 *_vectPosition, AC1Legacy::Vector3 *_vectDirection) .text:004EE5B0 ?SetCamera@gmCG3DView@@QAEXABVVector3@AC1Legacy@@0@Z

        // gmCG3DView.SetPlayerHeading:
        public void SetPlayerHeading(Single _fHeading) => ((delegate* unmanaged[Thiscall]<ref gmCG3DView, Single, void>)0x004EF220)(ref this, _fHeading); // .text:004EE590 ; void __thiscall gmCG3DView::SetPlayerHeading(gmCG3DView *this, float _fHeading) .text:004EE590 ?SetPlayerHeading@gmCG3DView@@QAEXM@Z

        // gmCG3DView.StartAnimation:
        public void StartAnimation() => ((delegate* unmanaged[Thiscall]<ref gmCG3DView, void>)0x004EF290)(ref this); // .text:004EE600 ; void __thiscall gmCG3DView::StartAnimation(gmCG3DView *this) .text:004EE600 ?StartAnimation@gmCG3DView@@QAEXXZ

        // gmCG3DView.StopAnimation:
        public void StopAnimation() => ((delegate* unmanaged[Thiscall]<ref gmCG3DView, void>)0x004EF2D0)(ref this); // .text:004EE640 ; void __thiscall gmCG3DView::StopAnimation(gmCG3DView *this) .text:004EE640 ?StopAnimation@gmCG3DView@@QAEXXZ

        // gmCG3DView.Update:
        public void Update() => ((delegate* unmanaged[Thiscall]<ref gmCG3DView, void>)0x004EF660)(ref this); // .text:004EE9D0 ; void __thiscall gmCG3DView::Update(gmCG3DView *this) .text:004EE9D0 ?Update@gmCG3DView@@QAEXXZ
    }


}