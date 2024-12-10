using System;
using System.Runtime.InteropServices;

namespace AcClient {
    public unsafe struct ClientMagicSystem {
        // Struct:
        public ClientSystem a0;
        public Turbine_RefCount m_cTurbineRefCount;
        public CSpellTable* spellTable;
        public SpellComponentTable* spellComponentTable;
        public UInt32 selectedSpell;
        public HashTable<UInt32, PTR<Graphic>> m_hashSpellIconTable;
        public HashTable<UInt32, PTR<Graphic>> m_hashSpellComponentIconTable;
        public override string ToString() => $"a0(ClientSystem):{a0}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, spellTable:->(CSpellTable*)0x{(int)spellTable:X8}, spellComponentTable:->(SpellComponenTable*)0x{(int)spellComponentTable:X8}, selectedSpell:{selectedSpell:X8}, m_hashSpellIconTable(HashTable<UInt32,Graphic*,1>):{m_hashSpellIconTable}, m_hashSpellComponentIconTable(HashTable<UInt32,Graphic*,1>):{m_hashSpellComponentIconTable}";

        // Functions:

        // ClientMagicSystem.GetSpellComponentTable:
        public SpellComponentTable* GetSpellComponentTable() => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, SpellComponentTable*>)0x00567C10)(ref this); // .text:00566E70 ; SpellComponentTable *__thiscal ClientMagicSystem::GetSpellComponentTable(ClientMagicSystem *this) .text:00566E70 ?GetSpellComponentTable@ClientMagicSystem@@QAEPAVSpellComponentTable@@XZ

        // ClientMagicSystem.InqSpellBase:
        public Byte InqSpellBase(UInt32 _spellID, CSpellBase* _spellBase) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, CSpellBase*, Byte>)0x00567EB0)(ref this, _spellID, _spellBase); // .text:0567110 ; bool __thiscall ClientMagicSystem::InqSpellBase(ClientMagicSystem *this, unsigned int _spellID, CSpellBase *_spellBase) .text:00567110 ?InqSpellBase@ClientMagicSystem@@QAE_NKAAVCSpellBase@@@Z

        // ClientMagicSystem.Handle_Magic__RemoveMultipleEnchantments:
        public UInt32 Handle_Magic__RemoveMultipleEnchantments(PackableList<UInt32>* eidList, Byte fNotify) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, PackableList<UInt32>*, Byte, UInt32>)0x005697D0)(ref this, eidList, fNotify); // .text:00568A30 ; unsigned int __thiscall ClientMagicSystem::Handle_Magic__RemoveMultipleEnchantments(ClientMagicSystem *this, PackableList<unsigned long> *eidList, bool fNotify) text:00568A30 ?Handle_Magic__RemoveMultipleEnchantments@ClientMagicSystem@@QAEKAAV?$PackableList@K@@_N@Z

        // ClientMagicSystem.GetSpellDescription:
        public AC1Legacy.PStringBase<char>* GetSpellDescription(AC1Legacy.PStringBase<char>* result, UInt32 _spellID) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, AC1Legacy.PStringBase<char>*, UInt32, AC1Legacy.PStringBase<char>*>)0x00567F60)(ref this, result, _spellID); // .text:005671C0 ; AC1Legacy::PStringBase<char> *__thiscall ClientMagicSystem::GetSpellDescription(ClientMagicSystem *this, AC1Legacy::PStrngBase<char> *result, unsigned int _spellID) .text:005671C0 ?GetSpellDescription@ClientMagicSystem@@QAE?AV?$PStringBase@D@AC1Legacy@@K@Z

        // ClientMagicSystem.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, void>)0x00569BD0)(ref this); // .text:00568E30 ; void __thiscall ClientMagicSystem::ClientMagicSystem(ClientMagicSystem *this) text:00568E30 ??0ClientMagicSystem@@QAE@XZ

        // ClientMagicSystem.OnEndCharacterSession:
        public void OnEndCharacterSession() => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, void>)0x00567CF0)(ref this); // .text:00566F50 ; void __thiscall ClientMagicSystem::OnEndCharacterSession(ClientagicSystem *this) .text:00566F50 ?OnEndCharacterSession@ClientMagicSystem@@MAEXXZ

        // ClientMagicSystem.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, TResult*, Turbine_GUID*, void**, TResult*>)0x0057D00)(ref this, result, i_rcInterface, o_ppvInterface); // .text:00566F60 ; TResult *__thiscall ClientMagicSystem::QueryInterface(ClientMagicSystem *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_pvInterface) .text:00566F60 ?QueryInterface@ClientMagicSystem@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // ClientMagicSystem.GetSpellName:
        public AC1Legacy.PStringBase<char>* GetSpellName(AC1Legacy.PStringBase<char>* result, UInt32 _spellID) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, AC1Legacy.PStringBase<char>*, UInt32, AC1Legacy.PStringBase<char>*>)0x00567EF0)(ref this, result, _spellID); // .text:00567150 ; AC1Legacy::PStringBase<char> *__thiscall ClientMagicSystem::GetSpellName(ClientMagicSystem *this, AC1Legacy::PStringBase<char> result, unsigned int _spellID) .text:00567150 ?GetSpellName@ClientMagicSystem@@QAE?AV?$PStringBase@D@AC1Legacy@@K@Z

        // ClientMagicSystem.GetSpellIcon:
        public Graphic* GetSpellIcon(UInt32 _spellID) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, Graphic*>)0x00569990)(ref this, _spellID); // .text:00568BF0 ; Graphic *__thiscall ClientMagicystem::GetSpellIcon(ClientMagicSystem *this, unsigned int _spellID) .text:00568BF0 ?GetSpellIcon@ClientMagicSystem@@QAEPAVGraphic@@K@Z

        // ClientMagicSystem.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32>)0x00569DD0)(ref this); // .text:00569030 ; unsigned int __thiscall ClientMagicSystem::Release(ClientMagicSystem *thi) .text:00569030 ?Release@ClientMagicSystem@@UBEKXZ

        // ClientMagicSystem.Handle_Magic__RemoveSpell:
        public UInt32 Handle_Magic__RemoveSpell(UInt32 spell_id) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, UInt32>)0x00568630)(ref this, spell_id); // .text:00567890 ; unsigned int __thiscal ClientMagicSystem::Handle_Magic__RemoveSpell(ClientMagicSystem *this, unsigned int spell_id) .text:00567890 ?Handle_Magic__RemoveSpell@ClientMagicSystem@@QAEKK@Z

        // ClientMagicSystem.NotifyOfEnchantmentRemoval:
        public Byte NotifyOfEnchantmentRemoval(UInt32 eid) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, Byte>)0x00569460)(ref this, eid); // .text:005686C0 ; bool __thiscall ClientMagicSystem::otifyOfEnchantmentRemoval(ClientMagicSystem *this, unsigned int eid) .text:005686C0 ?NotifyOfEnchantmentRemoval@ClientMagicSystem@@IAE_NK@Z

        // ClientMagicSystem.Handle_Magic__RemoveEnchantment:
        public UInt32 Handle_Magic__RemoveEnchantment(UInt32 eid, Byte fNotify) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, Byte, UInt32>)0x005696F0)(ref this, eid, fNotify); // .text:00568950; unsigned int __thiscall ClientMagicSystem::Handle_Magic__RemoveEnchantment(ClientMagicSystem *this, unsigned int eid, bool fNotify) .text:00568950 ?Handle_Magic__RemoveEnchantment@ClientMagicSystem@@QAEKK_N@Z

        // ClientMagicSystem.Handle_Magic__UpdateSpell:
        public UInt32 Handle_Magic__UpdateSpell(UInt32 spell_id) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, UInt32>)0x00568590)(ref this, spell_id); // .text:005677F0 ; unsigned int __thiscal ClientMagicSystem::Handle_Magic__UpdateSpell(ClientMagicSystem *this, unsigned int spell_id) .text:005677F0 ?Handle_Magic__UpdateSpell@ClientMagicSystem@@QAEKK@Z

        // ClientMagicSystem.Handle_Magic__UpdateMultipleEnchantments:
        public UInt32 Handle_Magic__UpdateMultipleEnchantments(PackableList<Enchantment>* list) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, PackableList<Enchantment>*, UInt32>)0x00568780)(ref this, list); // .text:005679E0 ; unsigned int __thiscall ClientMagicSystem::Handle_Magic__UpdateMultipleEnchantments(ClientMagicSystem *this, PackableList<Enchantment> *list) .text:005679E0 ?Handle_Magic__UpdateMultiplenchantments@ClientMagicSystem@@QAEKAAV?$PackableList@VEnchantment@@@@@Z

        // ClientMagicSystem.AddRef:
        public UInt32 AddRef() => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32>)0x00509440)(ref this); // .text:00508970 ; unsigned int __thiscall ClientMagicSystem::AddRef(ClientTradeSystem *this).text:00508970 ?AddRef@ClientMagicSystem@@UBEKXZ

        // ClientMagicSystem.FreeHandsAndCastSpell:
        public void FreeHandsAndCastSpell(UInt32 _spellID, UInt32 _targetID) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, UInt32, void>)0x00567C90)(ref this, _spellID, _targetID); // .text:0056EF0 ; void __thiscall ClientMagicSystem::FreeHandsAndCastSpell(ClientMagicSystem *this, unsigned int _spellID, unsigned int _targetID) .text:00566EF0 ?FreeHandsAndCastSpell@ClientMagicSystem@@QAEXKK@Z

        // ClientMagicSystem.CompositeSpellComponentIcon:
        public void CompositeSpellComponentIcon(UInt32 _componentID, Graphic* icon) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, Graphic*, void>)0x005684C0)(ref this, _componentID, icon); // .txt:00567720 ; void __thiscall ClientMagicSystem::CompositeSpellComponentIcon(ClientMagicSystem *this, IDClass<_tagDataID,32,0> _componentID, Graphic *icon) .text:00567720 ?CompositeSpellComponentIcon@ClientMagiSystem@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@PAVGraphic@@@Z

        // ClientMagicSystem.CastSpell:
        public static void CastSpell(UInt32 _spellID, Byte _targetIsSelected) => ((delegate* unmanaged[Cdecl]<UInt32, Byte, void>)0x00568DE0)(_spellID, _targetIsSelected); // .text:00568040 ; void __cdecl ClientMagcSystem::CastSpell(unsigned int _spellID, bool _targetIsSelected) .text:00568040 ?CastSpell@ClientMagicSystem@@SAXK_N@Z

        // ClientMagicSystem.Handle_Magic__DispelMultipleEnchantments:
        public UInt32 Handle_Magic__DispelMultipleEnchantments(PackableList<UInt32>* eidList) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, PackableList<UInt32>*, UInt32>)0x005698C0)(ref this, eidList);// .text:00568B20 ; unsigned int __thiscall ClientMagicSystem::Handle_Magic__DispelMultipleEnchantments(ClientMagicSystem *this, PackableList<unsigned long> *eidList) .text:00568B20 ?Handle_Magic__DispelMultiplEnchantments@ClientMagicSystem@@QAEKAAV?$PackableList@K@@@Z

        // ClientMagicSystem.Handle_Magic__UpdateEnchantment:
        public UInt32 Handle_Magic__UpdateEnchantment(Enchantment* enchant) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, Enchantment*, UInt32>)0x005686D0)(ref this, enchant); // .text:00567930 ; unsignd int __thiscall ClientMagicSystem::Handle_Magic__UpdateEnchantment(ClientMagicSystem *this, Enchantment *enchant) .text:00567930 ?Handle_Magic__UpdateEnchantment@ClientMagicSystem@@QAEKABVEnchantment@@@Z

        // ClientMagicSystem.Handle_Magic__PurgeBadEnchantments:
        public UInt32 Handle_Magic__PurgeBadEnchantments() => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32>)0x005688A0)(ref this); // .text:00567B00 ; unsigned int __thiscall ClientMagicSystem::Hanle_Magic__PurgeBadEnchantments(ClientMagicSystem *this) .text:00567B00 ?Handle_Magic__PurgeBadEnchantments@ClientMagicSystem@@QAEKXZ

        // ClientMagicSystem.AreSpellComponentsRequired:
        public Byte AreSpellComponentsRequired() => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, Byte>)0x00568930)(ref this); // .text:00567B90 ; bool __thiscall ClientMagicSystem::AreSpellComponentsRequied(ClientMagicSystem *this) .text:00567B90 ?AreSpellComponentsRequired@ClientMagicSystem@@QBE_NXZ

        // ClientMagicSystem.Handle_Magic__PurgeEnchantments:
        public UInt32 Handle_Magic__PurgeEnchantments() => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32>)0x00568810)(ref this); // .text:00567A70 ; unsigned int __thiscall ClientMagicSystem::HandleMagic__PurgeEnchantments(ClientMagicSystem *this) .text:00567A70 ?Handle_Magic__PurgeEnchantments@ClientMagicSystem@@QAEKXZ

        // ClientMagicSystem.GetMagicSystem:
        public static ClientMagicSystem* GetMagicSystem() => ((delegate* unmanaged[Cdecl]<ClientMagicSystem*>)0x00567C00)(); // .text:00566E60 ; ClientMagicSystem *__cdecl ClientMagicSystem::GetMagicSystem() .text:0566E60 ?GetMagicSystem@ClientMagicSystem@@SAPAV1@XZ

        // ClientMagicSystem.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, void>)0x00567C40)(ref this); // .text:00566EA0 ; void __thiscall ClientMagicSystem::OnShutdown(ClientMagicSystem *this) .tet:00566EA0 ?OnShutdown@ClientMagicSystem@@MAEXXZ

        // ClientMagicSystem.ObjectCompatibleWithSpellTargetType:
        public static Byte ObjectCompatibleWithSpellTargetType(UInt32 _targetID, UInt32 _targetType, Byte _quiet) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte, Byte>)0x00567FD0)(_targetID, _targetType, _quiet); // .text:00567230 ; bool __cdecl ClientMagicSystem::ObjectCompatibleWithSpellTargetType(unsigned int _targetID, unsigned int _targetType, bool _quiet) .text:00567230 ?ObjectCompatibleWithSpellTargetType@ClintMagicSystem@@SA_NKK_N@Z

        // ClientMagicSystem.GetSpellComponentIcon:
        public Graphic* GetSpellComponentIcon(UInt32 _componentID) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, Graphic*>)0x00569A50)(ref this, _componentID); // .text:00568CB0 ; Graphic *__thicall ClientMagicSystem::GetSpellComponentIcon(ClientMagicSystem *this, IDClass<_tagDataID,32,0> _componentID) .text:00568CB0 ?GetSpellComponentIcon@ClientMagicSystem@@QAEPAVGraphic@@V?$IDClass@U_tagDataID@@$0CA$0A@@@@Z

        // ClientMagicSystem.Handle_Magic__DispelEnchantment:
        public UInt32 Handle_Magic__DispelEnchantment(UInt32 eid) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, UInt32>)0x005698B0)(ref this, eid); // .text:00568B10 ; unsigned int __thiscall ClentMagicSystem::Handle_Magic__DispelEnchantment(ClientMagicSystem *this, unsigned int eid) .text:00568B10 ?Handle_Magic__DispelEnchantment@ClientMagicSystem@@QAEKK@Z

        // ClientMagicSystem.CompositeSpellIcon:
        public void CompositeSpellIcon(UInt32 _spellID, Graphic* icon) => ((delegate* unmanaged[Thiscall]<ref ClientMagicSystem, UInt32, Graphic*, void>)0x005682F0)(ref this, _spellID, icon); // .text:00567550 ; vod __thiscall ClientMagicSystem::CompositeSpellIcon(ClientMagicSystem *this, unsigned int _spellID, Graphic *icon) .text:00567550 ?CompositeSpellIcon@ClientMagicSystem@@QAEXKPAVGraphic@@@Z

        // ClientMagicSystem.ObjectCompatibleWithSpell:
        public static Byte ObjectCompatibleWithSpell(UInt32 _targetID, UInt32 _spellID, Byte _quiet, Byte _displayCastMessage) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte, Byte, Byte>)0x005689D0)(_targetID, _spellID, _quiet, _displayCastMessage); // .text:00567C30 ; bool __cdecl ClientMagicSystem::ObjectCompatibleWithSpell(unsigned int _targetID, unsigned int _spellID, bool _quiet, bool _displayCastMessage) .text00567C30 ?ObjectCompatibleWithSpell@ClientMagicSystem@@SA_NKK_N0@Z

        // ClientMagicSystem.GetAppropriateSpellFormula:
        public static SpellFormula* GetAppropriateSpellFormula(SpellFormula* result, CSpellBase* sBase) => ((delegate* unmanaged[Cdecl]<SpellFormula*, CSpellBase*, SpellFormula*>)0x00568AF0)(result, sBase); // .tex:00567D50 ; SpellFormula *__cdecl ClientMagicSystem::GetAppropriateSpellFormula(SpellFormula *result, CSpellBase *sBase) .text:00567D50 ?GetAppropriateSpellFormula@ClientMagicSystem@@SA?AVSpellFormula@@ABVCSpelBase@@@Z

        // Globals:
        public static ClientMagicSystem* s_pMagicSystem = *(ClientMagicSystem**)0x0087144C; // .data:0087043C ; ClientMagicSystem *ClientMagicSystem::s_pMagicSystem .data:0087043C ?s_pMagicSystem@ClientMagicSystem@@1PAV1@A
        public static UInt32* targetingSpell = (UInt32*)0x00871450; // .data:00870440 ; UInt32 ClientMagicSystem::targetingSpell .data:00870440 ?targetingSpell@ClientMagicSystem@@1KA
        public static RGBAColor* s_NullColor = (RGBAColor*)0x00871460; // .data:00870450 ; RGBAColor ClientMagicSystem::s_NullColor .data:00870450 ?s_NullColor@ClientMagicSystem@@1VRGBAColor@@A
    }
    public unsafe struct SpellBookPage {
        // Struct:
        public PackObj a0;
        public Single _casting_likelihood;
        public override string ToString() => $"_casting_likelihood:{_casting_likelihood:n5}";

        // Functions:

        // SpellBookPage.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellBookPage, void**, UInt32, UInt32>)0x005CD180)(ref this, addr, size); // .text:005CC230 ; unsigned int __thiscall SpellBookPage::Pack(SpellBookPage *this, void **addr, unsigned int size) .text:005CC230 ?Pack@SpellBookPage@@UAEIAAPAXI@Z

        // SpellBookPage.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellBookPage, void**, UInt32, int>)0x005CD1B0)(ref this, addr, size); // .text:005CC260 ; int __thiscall SpellBookPage::UnPack(SpellBookPage *this, void **addr, unsigned int size) .text:005CC260 ?UnPack@SpellBookPage@@UAEHAAPAXI@Z
    }
    public unsafe struct CSpellBook {
        // Struct:
        public PackObj a0;
        public PackableHashTable<UInt32, SpellBookPage> _spellbook;
        public override string ToString() => $"_spellbook(PackableHashTable<UInt32,SpellBookPage>):{_spellbook}";

        // Functions:

        // CSpellBook.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CSpellBook, void>)0x00596A80)(ref this); // .text:00595B80 ; void __thiscall CSpellBook::CSpellBook(CSpellBook *this) .text:00595B80 ??0CSpellBook@@QAE@XZ

        // CSpellBook.AddSpell:
        public int AddSpell(UInt32 newSpell, SpellBookPage* page) => ((delegate* unmanaged[Thiscall]<ref CSpellBook, UInt32, SpellBookPage*, int>)0x00596790)(ref this, newSpell, page); // .text:00595890 ; int __thiscall CSpellBook::AddSpell(CSpellBook *this, const unsigned int newSpell, SpellBookPage *page) .text:00595890 ?AddSpell@CSpellBook@@QAEHKABVSpellBookPage@@@Z

        // CSpellBook.Exists:
        public int Exists(UInt32 newSpell) => ((delegate* unmanaged[Thiscall]<ref CSpellBook, UInt32, int>)0x00596420)(ref this, newSpell); // .text:00595520 ; int __thiscall CSpellBook::Exists(CSpellBook *this, const unsigned int newSpell) .text:00595520 ?Exists@CSpellBook@@QBEHK@Z

        // CSpellBook.Prune:
        public void Prune() => ((delegate* unmanaged[Thiscall]<ref CSpellBook, void>)0x005967E0)(ref this); // .text:005958E0 ; void __thiscall CSpellBook::Prune(CSpellBook *this) .text:005958E0 ?Prune@CSpellBook@@AAEXXZ

        // CSpellBook.RemoveSpell:
        public int RemoveSpell(UInt32 newSpell, SpellBookPage* page) => ((delegate* unmanaged[Thiscall]<ref CSpellBook, UInt32, SpellBookPage*, int>)0x005967C0)(ref this, newSpell, page); // .text:005958C0 ; int __thiscall CSpellBook::RemoveSpell(CSpellBook *this, const unsigned int newSpell, SpellBookPage *page) .text:005958C0 ?RemoveSpell@CSpellBook@@QAEHKAAVSpellBookPage@@@Z

        // CSpellBook.TranscribeSpells:
        public int TranscribeSpells(PackableList<UInt32>* list) => ((delegate* unmanaged[Thiscall]<ref CSpellBook, PackableList<UInt32>*, int>)0x00596470)(ref this, list); // .text:00595570 ; int __thiscall CSpellBook::TranscribeSpells(CSpellBook *this, PackableList<unsigned long> *list) .text:00595570 ?TranscribeSpells@CSpellBook@@QBEHAAV?$PackableList@K@@@Z

        // CSpellBook.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CSpellBook, void**, UInt32, int>)0x00596AB0)(ref this, addr, size); // .text:00595BB0 ; int __thiscall CSpellBook::UnPack(CSpellBook *this, void **addr, unsigned int size) .text:00595BB0 ?UnPack@CSpellBook@@UAEHAAPAXI@Z
    }

    public unsafe struct Enchantment {
        // Struct:
        public PackObj a0;
        public UInt32 _id;
        public UInt32 m_SpellSetID;
        public UInt32 _spell_category;
        public int _power_level;
        public Double _start_time;
        public Double _duration;
        public UInt32 _caster;
        public Single _degrade_modifier;
        public Single _degrade_limit;
        public Double _last_time_degraded;
        public StatMod _smod;
        public override string ToString() => $"a0(PackObj):{a0}, _id:{_id:X8}, m_SpellSetID:{m_SpellSetID:X8}, _spell_category:{_spell_category:X8}, _power_level(int):{_power_level}, _start_time:{_start_time:n5}, _duration:{_duration:n5}, _caster:{_caster:X8}, _degrade_modifier:{_degrade_modifier:n5}, _degrade_limit:{_degrade_limit:n5}, _last_time_degraded:{_last_time_degraded:n5}, _smod(StatMod):{_smod}";

        // Functions:

        // Enchantment.__Ctor:
        public void __Ctor(Enchantment* __that) => ((delegate* unmanaged[Thiscall]<ref Enchantment, Enchantment*, void>)0x004B8A00)(ref this, __that); // .text:004B7DE0 ; void __thiscall Enchantment::Enchantment(Enchantment *this, Enchantment *__that) .text:004B7DE0 ??0Enchantment@@QAE@ABV0@@Z

        // Enchantment.__Ctor:
        public void __Ctor(UInt32 spid) => ((delegate* unmanaged[Thiscall]<ref Enchantment, UInt32, void>)0x005CBE30)(ref this, spid); // .text:005CAF00 ; void __thiscall Enchantment::Enchantment(Enchantment *this, const unsigned int spid) .text:005CAF00 ??0Enchantment@@QAE@K@Z

        // Enchantment.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Enchantment, void>)0x005CBDD0)(ref this); // .text:005CAEA0 ; void __thiscall Enchantment::Enchantment(Enchantment *this) .text:005CAEA0 ??0Enchantment@@QAE@XZ

        // Enchantment.operator_equals:
        // public Enchantment* operator_equals() => ((delegate* unmanaged[Thiscall]<ref Enchantment, Enchantment*>)0xDEADBEEF)(ref this); // .text:004B74F0 ; public: class Enchantment & __thiscall Enchantment::operator=(class Enchantment const &) .text:004B74F0 ??4Enchantment@@QAEAAV0@ABV0@@Z

        // Enchantment.AffectsAttackSkills:
        public int AffectsAttackSkills(UInt32 key) => ((delegate* unmanaged[Thiscall]<ref Enchantment, UInt32, int>)0x005CBD10)(ref this, key); // .text:005CADE0 ; int __thiscall Enchantment::AffectsAttackSkills(Enchantment *this, unsigned int key) .text:005CADE0 ?AffectsAttackSkills@Enchantment@@QBEHK@Z

        // Enchantment.AffectsDefenseSkills:
        public int AffectsDefenseSkills(UInt32 key) => ((delegate* unmanaged[Thiscall]<ref Enchantment, UInt32, int>)0x005CBD60)(ref this, key); // .text:005CAE30 ; int __thiscall Enchantment::AffectsDefenseSkills(Enchantment *this, unsigned int key) .text:005CAE30 ?AffectsDefenseSkills@Enchantment@@QBEHK@Z

        // Enchantment.Duel:
        public int Duel(Enchantment* challenger) => ((delegate* unmanaged[Thiscall]<ref Enchantment, Enchantment*, int>)0x005CBC10)(ref this, challenger); // .text:005CACE0 ; int __thiscall Enchantment::Duel(Enchantment *this, Enchantment *challenger) .text:005CACE0 ?Duel@Enchantment@@QBEHABV1@@Z

        // Enchantment.Enchant:
        public int Enchant(Single* value) => ((delegate* unmanaged[Thiscall]<ref Enchantment, Single*, int>)0x005CBC40)(ref this, value); // .text:005CAD10 ; int __thiscall Enchantment::Enchant(Enchantment *this, float *value) .text:005CAD10 ?Enchant@Enchantment@@QAEHAAM@Z

        // Enchantment.Enchant:
        public int Enchant(EnchantedQualityDetails* value) => ((delegate* unmanaged[Thiscall]<ref Enchantment, EnchantedQualityDetails*, int>)0x005CBC80)(ref this, value); // .text:005CAD50 ; int __thiscall Enchantment::Enchant(Enchantment *this, EnchantedQualityDetails *value) .text:005CAD50 ?Enchant@Enchantment@@QAEHAAUEnchantedQualityDetails@@@Z

        // Enchantment.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref Enchantment, UInt32>)0x005CBCF0)(ref this); // .text:005CADC0 ; unsigned int __thiscall Enchantment::GetPackSize(Enchantment *this) .text:005CADC0 ?GetPackSize@Enchantment@@UAEIXZ

        // Enchantment.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Enchantment, void**, UInt32, UInt32>)0x005CBEA0)(ref this, addr, size); // .text:005CAF70 ; unsigned int __thiscall Enchantment::Pack(Enchantment *this, void **addr, unsigned int size) .text:005CAF70 ?Pack@Enchantment@@UAEIAAPAXI@Z

        // Enchantment.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Enchantment, void**, UInt32, int>)0x005CBF70)(ref this, addr, size); // .text:005CB040 ; int __thiscall Enchantment::UnPack(Enchantment *this, void **addr, unsigned int size) .text:005CB040 ?UnPack@Enchantment@@UAEHAAPAXI@Z
    }

    public unsafe struct CEnchantmentRegistry {
        // Struct:
        public PackObj a0;
        public PackableList<Enchantment>* _mult_list;
        public PackableList<Enchantment>* _add_list;
        public PackableList<Enchantment>* _cooldown_list;
        public Enchantment* _vitae;
        public UInt32 m_cHelpfulEnchantments;
        public UInt32 m_cHarmfulEnchantments;
        public override string ToString() => $"a0(PackObj):{a0}, _mult_list:->(PackableList<Enchantment>*)0x{(int)_mult_list:X8}, _add_list:->(PackableList<Enchantment>*)0x{(int)_add_list:X8}, _cooldown_list:->(PackableList<Enchantment>*)0x{(int)_cooldown_list:X8}, _vitae:->(Enchantment*)0x{(int)_vitae:X8}, m_cHelpfulEnchantments:{m_cHelpfulEnchantments:X8}, m_cHarmfulEnchantments:{m_cHarmfulEnchantments:X8}";

        // Functions:

        // CEnchantmentRegistry.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, void>)0x00594820)(ref this); // .text:005939B0 ; void __thiscall CEnchantmentRegistry::CEnchantmentRegistry(CEnchantmentRegistry *this) .text:005939B0 ??0CEnchantmentRegistry@@QAE@XZ

        // CEnchantmentRegistry.AddEnchantmentToList:
        // public int AddEnchantmentToList(Enchantment* to_update, PackableList<Enchantment>** list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, Enchantment*, PackableList<Enchantment>**, int>)0xDEADBEEF)(ref this, to_update, list); // .text:00593DF0 ; int __thiscall CEnchantmentRegistry::AddEnchantmentToList(CEnchantmentRegistry *this, Enchantment *to_update, PackableList<Enchantment> **list) .text:00593DF0 ?AddEnchantmentToList@CEnchantmentRegistry@@IAEHABVEnchantment@@AAPAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.AttemptToReplaceSpellInList:
        // public int AttemptToReplaceSpellInList(Enchantment* spell, PackableList<Enchantment>** list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, Enchantment*, PackableList<Enchantment>**, int>)0xDEADBEEF)(ref this, spell, list); // .text:00593D00 ; int __thiscall CEnchantmentRegistry::AttemptToReplaceSpellInList(CEnchantmentRegistry *this, Enchantment *spell, PackableList<Enchantment> **list) .text:00593D00 ?AttemptToReplaceSpellInList@CEnchantmentRegistry@@IAEHABVEnchantment@@AAPAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.Clear:
        public void Clear() => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, void>)0x00594840)(ref this); // .text:005939D0 ; void __thiscall CEnchantmentRegistry::Clear(CEnchantmentRegistry *this) .text:005939D0 ?Clear@CEnchantmentRegistry@@IAEXXZ

        // CEnchantmentRegistry.CountSpellsInList:
        // public void CountSpellsInList(PackableList<Enchantment>* list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<Enchantment>*, void>)0xDEADBEEF)(ref this, list); // .text:00593CD0 ; void __thiscall CEnchantmentRegistry::CountSpellsInList(CEnchantmentRegistry *this, PackableList<Enchantment> *list) .text:00593CD0 ?CountSpellsInList@CEnchantmentRegistry@@IAEXPAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.CullEnchantmentsFromList:
        // public int CullEnchantmentsFromList(PackableList<Enchantment>* list, UInt32 type, UInt32 key, PackableList<Enchantment>* affecting) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<Enchantment>*, UInt32, UInt32, PackableList<Enchantment>*, int>)0xDEADBEEF)(ref this, list, type, key, affecting); // .text:00594470 ; int __thiscall CEnchantmentRegistry::CullEnchantmentsFromList(CEnchantmentRegistry *this, PackableList<Enchantment> *list, const unsigned int type, const unsigned int key, PackableList<Enchantment> *affecting) .text:00594470 ?CullEnchantmentsFromList@CEnchantmentRegistry@@IBEHPAV?$PackableList@VEnchantment@@@@KKAAV2@@Z

        // CEnchantmentRegistry.Duel:
        // public int Duel(Enchantment* challenger, PackableList<Enchantment>* list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, Enchantment*, PackableList<Enchantment>*, int>)0xDEADBEEF)(ref this, challenger, list); // .text:005942B0 ; int __thiscall CEnchantmentRegistry::Duel(CEnchantmentRegistry *this, Enchantment *challenger, PackableList<Enchantment> *list) .text:005942B0 ?Duel@CEnchantmentRegistry@@IBEHABVEnchantment@@AAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.Enchant:
        public int Enchant(PackableList<Enchantment>* affecting, Single* val) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<Enchantment>*, Single*, int>)0x005949C0)(ref this, affecting, val); // .text:00593B50 ; int __thiscall CEnchantmentRegistry::Enchant(CEnchantmentRegistry *this, PackableList<Enchantment> *affecting, float *val) .text:00593B50 ?Enchant@CEnchantmentRegistry@@IBEHAAV?$PackableList@VEnchantment@@@@AAM@Z

        // CEnchantmentRegistry.Enchant:
        public int Enchant(PackableList<Enchantment>* affecting, EnchantedQualityDetails* val) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<Enchantment>*, EnchantedQualityDetails*, int>)0x005949F0)(ref this, affecting, val); // .text:00593B80 ; int __thiscall CEnchantmentRegistry::Enchant(CEnchantmentRegistry *this, PackableList<Enchantment> *affecting, EnchantedQualityDetails *val) .text:00593B80 ?Enchant@CEnchantmentRegistry@@IBEHAAV?$PackableList@VEnchantment@@@@AAUEnchantedQualityDetails@@@Z

        // CEnchantmentRegistry.EnchantAttribute2nd:
        // public int EnchantAttribute2nd(UInt32 stype, UInt32* val) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, UInt32*, int>)0xDEADBEEF)(ref this, stype, val); // .text:00594670 ; int __thiscall CEnchantmentRegistry::EnchantAttribute2nd(CEnchantmentRegistry *this, unsigned int stype, unsigned int *val) .text:00594670 ?EnchantAttribute2nd@CEnchantmentRegistry@@QBEHKAAK@Z

        // CEnchantmentRegistry.EnchantAttribute:
        // public int EnchantAttribute(UInt32 stype, UInt32* val) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, UInt32*, int>)0xDEADBEEF)(ref this, stype, val); // .text:00594570 ; int __thiscall CEnchantmentRegistry::EnchantAttribute(CEnchantmentRegistry *this, unsigned int stype, unsigned int *val) .text:00594570 ?EnchantAttribute@CEnchantmentRegistry@@QBEHKAAK@Z

        // CEnchantmentRegistry.EnchantFloat:
        public int EnchantFloat(UInt32 stype, Double* val) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, Double*, int>)0x00595820)(ref this, stype, val); // .text:005949B0 ; int __thiscall CEnchantmentRegistry::EnchantFloat(CEnchantmentRegistry *this, unsigned int stype, long double *val) .text:005949B0 ?EnchantFloat@CEnchantmentRegistry@@QBEHKAAN@Z

        // CEnchantmentRegistry.EnchantInt:
        public int EnchantInt(UInt32 stype, int* val, int allow_negative) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, int*, int, int>)0x00595710)(ref this, stype, val, allow_negative); // .text:005948A0 ; int __thiscall CEnchantmentRegistry::EnchantInt(CEnchantmentRegistry *this, unsigned int stype, int *val, int allow_negative) .text:005948A0 ?EnchantInt@CEnchantmentRegistry@@QBEHKAAJH@Z

        // CEnchantmentRegistry.EnchantSkill:
        public int EnchantSkill(UInt32 stype, int* val) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, int*, int>)0x00595620)(ref this, stype, val); // .text:005947B0 ; int __thiscall CEnchantmentRegistry::EnchantSkill(CEnchantmentRegistry *this, unsigned int stype, int *val) .text:005947B0 ?EnchantSkill@CEnchantmentRegistry@@QBEHKAAJ@Z

        // CEnchantmentRegistry.GetEnchantmentsInEffect:
        public int GetEnchantmentsInEffect(PackableList<Enchantment>* retval) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<Enchantment>*, int>)0x005953B0)(ref this, retval); // .text:00594540 ; int __thiscall CEnchantmentRegistry::GetEnchantmentsInEffect(CEnchantmentRegistry *this, PackableList<Enchantment> *retval) .text:00594540 ?GetEnchantmentsInEffect@CEnchantmentRegistry@@QBEHAAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.GetEnchantmentsInEffectFromList:
        // public int GetEnchantmentsInEffectFromList(PackableList<Enchantment>* list, PackableList<Enchantment>* retval) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<Enchantment>*, PackableList<Enchantment>*, int>)0xDEADBEEF)(ref this, list, retval); // .text:00594430 ; int __thiscall CEnchantmentRegistry::GetEnchantmentsInEffectFromList(CEnchantmentRegistry *this, PackableList<Enchantment> *list, PackableList<Enchantment> *retval) .text:00594430 ?GetEnchantmentsInEffectFromList@CEnchantmentRegistry@@IBEHPAV?$PackableList@VEnchantment@@@@AAV2@@Z

        // CEnchantmentRegistry.GetFloatEnchantmentDetails:
        public int GetFloatEnchantmentDetails(UInt32 stype, EnchantedQualityDetails* val) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, EnchantedQualityDetails*, int>)0x00595900)(ref this, stype, val); // .text:00594A90 ; int __thiscall CEnchantmentRegistry::GetFloatEnchantmentDetails(CEnchantmentRegistry *this, unsigned int stype, EnchantedQualityDetails *val) .text:00594A90 ?GetFloatEnchantmentDetails@CEnchantmentRegistry@@QBEHKAAUEnchantedQualityDetails@@@Z

        // CEnchantmentRegistry.GetVitaeValue:
        public Single GetVitaeValue() => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, Single>)0x00594790)(ref this); // .text:00593990 ; float __thiscall CEnchantmentRegistry::GetVitaeValue(CEnchantmentRegistry *this) .text:00593990 ?GetVitaeValue@CEnchantmentRegistry@@QBEMXZ

        // CEnchantmentRegistry.InqVitae:
        public int InqVitae(Enchantment* vitae) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, Enchantment*, int>)0x00594770)(ref this, vitae); // .text:00593970 ; int __thiscall CEnchantmentRegistry::InqVitae(CEnchantmentRegistry *this, Enchantment *vitae) .text:00593970 ?InqVitae@CEnchantmentRegistry@@QBEHAAVEnchantment@@@Z

        // CEnchantmentRegistry.IsEnchanted:
        public int IsEnchanted(UInt32 spell) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, int>)0x00594DF0)(ref this, spell); // .text:00593F80 ; int __thiscall CEnchantmentRegistry::IsEnchanted(CEnchantmentRegistry *this, const unsigned int spell) .text:00593F80 ?IsEnchanted@CEnchantmentRegistry@@QBEHK@Z

        // CEnchantmentRegistry.IsEnchantmentInList:
        public int IsEnchantmentInList(UInt32 spell, PackableList<Enchantment>* list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, PackableList<Enchantment>*, int>)0x00594A70)(ref this, spell, list); // .text:00593C00 ; int __thiscall CEnchantmentRegistry::IsEnchantmentInList(CEnchantmentRegistry *this, const unsigned int spell, PackableList<Enchantment> *list) .text:00593C00 ?IsEnchantmentInList@CEnchantmentRegistry@@IBEHKPBV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.OnCooldown:
        // public int OnCooldown(UInt32 cooldown_id, Double* time_left) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, Double*, int>)0xDEADBEEF)(ref this, cooldown_id, time_left); // .text:005943C0 ; int __thiscall CEnchantmentRegistry::OnCooldown(CEnchantmentRegistry *this, const unsigned int cooldown_id, long double *time_left) .text:005943C0 ?OnCooldown@CEnchantmentRegistry@@QBEHKAAN@Z

        // CEnchantmentRegistry.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, void**, UInt32, UInt32>)0x005948F0)(ref this, addr, size); // .text:00593A80 ; unsigned int __thiscall CEnchantmentRegistry::Pack(CEnchantmentRegistry *this, void **addr, unsigned int size) .text:00593A80 ?Pack@CEnchantmentRegistry@@UAEIAAPAXI@Z

        // CEnchantmentRegistry.PurgeBadEnchantmentList:
        public int PurgeBadEnchantmentList(PackableList<Enchantment>* list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<Enchantment>*, int>)0x00595B80)(ref this, list); // .text:00594D10 ; int __thiscall CEnchantmentRegistry::PurgeBadEnchantmentList(CEnchantmentRegistry *this, PackableList<Enchantment> *list) .text:00594D10 ?PurgeBadEnchantmentList@CEnchantmentRegistry@@IAEHPAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.PurgeBadEnchantments:
        public int PurgeBadEnchantments() => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, int>)0x00595C70)(ref this); // .text:00594E00 ; int __thiscall CEnchantmentRegistry::PurgeBadEnchantments(CEnchantmentRegistry *this) .text:00594E00 ?PurgeBadEnchantments@CEnchantmentRegistry@@QAEHXZ

        // CEnchantmentRegistry.PurgeEnchantmentList:
        public int PurgeEnchantmentList(PackableList<Enchantment>* list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<Enchantment>*, int>)0x00595AC0)(ref this, list); // .text:00594C50 ; int __thiscall CEnchantmentRegistry::PurgeEnchantmentList(CEnchantmentRegistry *this, PackableList<Enchantment> *list) .text:00594C50 ?PurgeEnchantmentList@CEnchantmentRegistry@@IAEHPAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.PurgeEnchantments:
        public int PurgeEnchantments() => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, int>)0x00595C50)(ref this); // .text:00594DE0 ; int __thiscall CEnchantmentRegistry::PurgeEnchantments(CEnchantmentRegistry *this) .text:00594DE0 ?PurgeEnchantments@CEnchantmentRegistry@@QAEHXZ

        // CEnchantmentRegistry.RemoveEnchantment:
        // public int RemoveEnchantment(UInt32 eid) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, int>)0xDEADBEEF)(ref this, eid); // .text:005944E0 ; int __thiscall CEnchantmentRegistry::RemoveEnchantment(CEnchantmentRegistry *this, const unsigned int eid) .text:005944E0 ?RemoveEnchantment@CEnchantmentRegistry@@QAEHK@Z

        // CEnchantmentRegistry.RemoveEnchantmentFromList:
        // public int RemoveEnchantmentFromList(UInt32 eid, PackableList<Enchantment>* list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, PackableList<Enchantment>*, int>)0xDEADBEEF)(ref this, eid, list); // .text:00594360 ; int __thiscall CEnchantmentRegistry::RemoveEnchantmentFromList(CEnchantmentRegistry *this, const unsigned int eid, PackableList<Enchantment> *list) .text:00594360 ?RemoveEnchantmentFromList@CEnchantmentRegistry@@IAEHKPAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.RemoveEnchantments:
        public int RemoveEnchantments(PackableList<UInt32>* to_remove) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<UInt32>*, int>)0x005959B0)(ref this, to_remove); // .text:00594B40 ; int __thiscall CEnchantmentRegistry::RemoveEnchantments(CEnchantmentRegistry *this, PackableList<unsigned long> *to_remove) .text:00594B40 ?RemoveEnchantments@CEnchantmentRegistry@@QAEHAAV?$PackableList@K@@@Z

        // CEnchantmentRegistry.ReplaceEnchantmentInList:
        public int ReplaceEnchantmentInList(Enchantment* new_guy, PackableList<Enchantment>* list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, Enchantment*, PackableList<Enchantment>*, int>)0x00594A20)(ref this, new_guy, list); // .text:00593BB0 ; int __thiscall CEnchantmentRegistry::ReplaceEnchantmentInList(CEnchantmentRegistry *this, Enchantment *new_guy, PackableList<Enchantment> *list) .text:00593BB0 ?ReplaceEnchantmentInList@CEnchantmentRegistry@@IAEHABVEnchantment@@PAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, void**, UInt32, int>)0x00594E60)(ref this, addr, size); // .text:00593FF0 ; int __thiscall CEnchantmentRegistry::UnPack(CEnchantmentRegistry *this, void **addr, unsigned int size) .text:00593FF0 ?UnPack@CEnchantmentRegistry@@UAEHAAPAXI@Z

        // CEnchantmentRegistry.UpdateEnchantment:
        // public int UpdateEnchantment(Enchantment* to_update) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, Enchantment*, int>)0xDEADBEEF)(ref this, to_update); // .text:00593E70 ; int __thiscall CEnchantmentRegistry::UpdateEnchantment(CEnchantmentRegistry *this, Enchantment *to_update) .text:00593E70 ?UpdateEnchantment@CEnchantmentRegistry@@QAEHABVEnchantment@@@Z

        // CEnchantmentRegistry.UpdateEnchantmentList:
        public int UpdateEnchantmentList(PackableList<Enchantment>* to_update_list) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, PackableList<Enchantment>*, int>)0x00594DC0)(ref this, to_update_list); // .text:00593F50 ; int __thiscall CEnchantmentRegistry::UpdateEnchantmentList(CEnchantmentRegistry *this, PackableList<Enchantment> *to_update_list) .text:00593F50 ?UpdateEnchantmentList@CEnchantmentRegistry@@QAEHAAV?$PackableList@VEnchantment@@@@@Z

        // CEnchantmentRegistry.UpdateSpellTotals:
        // public int UpdateSpellTotals(UInt32 spell, int iDelta) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32, int, int>)0xDEADBEEF)(ref this, spell, iDelta); // .text:00593C40 ; int __thiscall CEnchantmentRegistry::UpdateSpellTotals(CEnchantmentRegistry *this, unsigned int spell, int iDelta) .text:00593C40 ?UpdateSpellTotals@CEnchantmentRegistry@@IAEHKJ@Z

        // CEnchantmentRegistry.UpdateVitae:
        public int UpdateVitae(Enchantment* vitae) => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, Enchantment*, int>)0x00594890)(ref this, vitae); // .text:00593A20 ; int __thiscall CEnchantmentRegistry::UpdateVitae(CEnchantmentRegistry *this, Enchantment *vitae) .text:00593A20 ?UpdateVitae@CEnchantmentRegistry@@QAEHABVEnchantment@@@Z

        // CEnchantmentRegistry.pack_size:
        public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref CEnchantmentRegistry, UInt32>)0x005947B0)(ref this); // .text:006B7800 ; unsigned int __thiscall CEnchantmentRegistry::pack_size(GenericQualitiesData *this) .text:006B7800 ?pack_size@CEnchantmentRegistry@@QAEIXZ
    }

    public unsafe struct CRegionDesc {
        public SerializeUsingPackDBObj a0;

        public uint region_number;
        public AC1Legacy.PStringBase<byte> region_name;

        public uint version;
        public int minimize_pal;
        public uint parts_mask;
    }

    public unsafe struct CSpellTable {
        // Struct:
        public SerializeUsingPackDBObj a0;
        public PackableHashTable<UInt32, CSpellBase> _spellBaseHash;
        public PHashTable<UInt32, SpellSet> m_SpellSetHash;
        public override string ToString() => $"a0(SerializeUsingPackDBObj):{a0}, _spellBaseHash(PackableHashTable<UInt32,CSpellBase>):{_spellBaseHash}, m_SpellSetHash(PHashTable<UInt32,SpellSet>):{m_SpellSetHash}";

        // Functions:

        // CSpellTable.__Ctor:
        public void __Ctor(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref CSpellTable, UInt32, void>)0x005993E0)(ref this, did); // .text:00598440 ; void __thiscall CSpellTable::CSpellTable(CSpellTable *this, IDClass<_tagDataID,32,0> did) .text:00598440 ??0CSpellTable@@QAE@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CSpellTable.Allocator:
        public static DBObj* Allocator() => ((delegate* unmanaged[Cdecl]<DBObj*>)0x0058B700)(); // .text:0058A8D0 ; DBObj *__cdecl CSpellTable::Allocator() .text:0058A8D0 ?Allocator@CSpellTable@@SAPAVDBObj@@XZ

        // CSpellTable.GetSpellBase:
        public CSpellBase* GetSpellBase(UInt32 key) => ((delegate* unmanaged[Thiscall]<ref CSpellTable, UInt32, CSpellBase*>)0x00594980)(ref this, key); // .text:00593B10 ; CSpellBase *__thiscall CSpellTable::GetSpellBase(CSpellTable *this, const unsigned int key) .text:00593B10 ?GetSpellBase@CSpellTable@@QBEPBVCSpellBase@@K@Z

        // CSpellTable.GetSubDataIDs:
        public void GetSubDataIDs(QualifiedDataIDArray* id_array) => ((delegate* unmanaged[Thiscall]<ref CSpellTable, QualifiedDataIDArray*, void>)0x005986E0)(ref this, id_array); // .text:00597770 ; void __thiscall CSpellTable::GetSubDataIDs(CSpellTable *this, QualifiedDataIDArray *id_array) .text:00597770 ?GetSubDataIDs@CSpellTable@@MBEXAAVQualifiedDataIDArray@@@Z

        // CSpellTable.InqSpellBase:
        public int InqSpellBase(UInt32 key, CSpellBase* sbase) => ((delegate* unmanaged[Thiscall]<ref CSpellTable, UInt32, CSpellBase*, int>)0x00567E50)(ref this, key, sbase); // .text:005670B0 ; int __thiscall CSpellTable::InqSpellBase(CSpellTable *this, const unsigned int key, CSpellBase *sbase) .text:005670B0 ?InqSpellBase@CSpellTable@@QBEHKAAVCSpellBase@@@Z

        // CSpellTable.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CSpellTable, void**, UInt32, UInt32>)0x00598450)(ref this, addr, size); // .text:005974E0 ; unsigned int __thiscall CSpellTable::Pack(CSpellTable *this, void **addr, unsigned int size) .text:005974E0 ?Pack@CSpellTable@@UAEIAAPAXI@Z

        // CSpellTable.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CSpellTable, void**, UInt32, int>)0x005984C0)(ref this, addr, size); // .text:00597550 ; int __thiscall CSpellTable::UnPack(CSpellTable *this, void **addr, unsigned int size) .text:00597550 ?UnPack@CSpellTable@@UAEHAAPAXI@Z
    }

    public unsafe struct CSpellBase {
        // Struct:
        public PackObj a0;
        public AC1Legacy.PStringBase<byte> _name;
        public AC1Legacy.PStringBase<byte> _desc;
        public UInt32 _school;
        public UInt32 _iconID;
        public UInt32 _category;
        public UInt32 _bitfield;
        public int _base_mana;
        public int _mana_mod;
        public Single _base_range_constant;
        public Single _base_range_mod;
        public int _power;
        public Single _spell_economy_mod;
        public UInt32 _formula_version;
        public Single _component_loss;
        public SpellFormula _formula;
        public PScriptType _caster_effect;
        public PScriptType _target_effect;
        public PScriptType _fizzle_effect;
        public Double _recovery_interval;
        public Single _recovery_amount;
        public int _display_order;
        public UInt32 _non_component_target_type;
        public MetaSpell _meta_spell;
        public override string ToString() => $"a0(PackObj):{a0}, _name:{_name}, _desc:{_desc}, _school:{_school:X8}, _iconID:{_iconID:X8}, _category:{_category:X8}, _bitfield:{_bitfield:X8}, _base_mana(int):{_base_mana}, _mana_mod(int):{_mana_mod}, _base_range_constant:{_base_range_constant:n5}, _base_range_mod:{_base_range_mod:n5}, _power(int):{_power}, _spell_economy_mod:{_spell_economy_mod:n5}, _formula_version:{_formula_version:X8}, _component_loss:{_component_loss:n5}, _formula(SpellFormula):{_formula}, _caster_effect(PScriptType):{_caster_effect}, _target_effect(PScriptType):{_target_effect}, _fizzle_effect(PScriptType):{_fizzle_effect}, _recovery_interval:{_recovery_interval:n5}, _recovery_amount:{_recovery_amount:n5}, _display_order(int):{_display_order}, _non_component_target_type:{_non_component_target_type:X8}, _meta_spell(MetaSpell):{_meta_spell}";

        // Functions:

        // CSpellBase.__Ctor:
        public void __Ctor(CSpellBase* from) => ((delegate* unmanaged[Thiscall]<ref CSpellBase, CSpellBase*, void>)0x00597CD0)(ref this, from); // .text:00596DD0 ; void __thiscall CSpellBase::CSpellBase(CSpellBase *this, CSpellBase *from) .text:00596DD0 ??0CSpellBase@@QAE@ABV0@@Z

        // CSpellBase.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CSpellBase, void>)0x0048B420)(ref this); // .text:0048B140 ; void __thiscall CSpellBase::CSpellBase(CSpellBase *this) .text:0048B140 ??0CSpellBase@@QAE@XZ

        // CSpellBase.operator_equals:
        public CSpellBase* operator_equals() => ((delegate* unmanaged[Thiscall]<ref CSpellBase, CSpellBase*>)0x005979D0)(ref this); // .text:00596AD0 ; public: class CSpellBase & __thiscall CSpellBase::operator=(class CSpellBase const &) .text:00596AD0 ??4CSpellBase@@QAEAAV0@ABV0@@Z

        // CSpellBase.InqCustomizedSpellFormula:
        public SpellFormula* InqCustomizedSpellFormula(SpellFormula* result, AC1Legacy.PStringBase<char>* account_name) => ((delegate* unmanaged[Thiscall]<ref CSpellBase, SpellFormula*, AC1Legacy.PStringBase<char>*, SpellFormula*>)0x00597F70)(ref this, result, account_name); // .text:00597000 ; SpellFormula *__thiscall CSpellBase::InqCustomizedSpellFormula(CSpellBase *this, SpellFormula *result, AC1Legacy::PStringBase<char> *account_name) .text:00597000 ?InqCustomizedSpellFormula@CSpellBase@@QBE?AVSpellFormula@@ABV?$PStringBase@D@AC1Legacy@@@Z

        // CSpellBase.InqDescription:
        public AC1Legacy.PStringBase<char>* InqDescription(AC1Legacy.PStringBase<char>* result) => ((delegate* unmanaged[Thiscall]<ref CSpellBase, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*>)0x00597DB0)(ref this, result); // .text:00596E40 ; AC1Legacy::PStringBase<char> *__thiscall CSpellBase::InqDescription(CSpellBase *this, AC1Legacy::PStringBase<char> *result) .text:00596E40 ?InqDescription@CSpellBase@@QBE?AV?$PStringBase@D@AC1Legacy@@XZ

        // CSpellBase.InqDuration:
        public Double InqDuration() => ((delegate* unmanaged[Thiscall]<ref CSpellBase, Double>)0x005979A0)(ref this); // .text:00596AA0 ; long double __thiscall CSpellBase::InqDuration(CSpellBase *this) .text:00596AA0 ?InqDuration@CSpellBase@@QBENXZ

        // CSpellBase.InqScarabOnlyFormula:
        public SpellFormula* InqScarabOnlyFormula(SpellFormula* result) => ((delegate* unmanaged[Thiscall]<ref CSpellBase, SpellFormula*, SpellFormula*>)0x00597FC0)(ref this, result); // .text:00597050 ; SpellFormula *__thiscall CSpellBase::InqScarabOnlyFormula(CSpellBase *this, SpellFormula *result) .text:00597050 ?InqScarabOnlyFormula@CSpellBase@@QBE?AVSpellFormula@@XZ

        // CSpellBase.InqSkillForSpell:
        public UInt32 InqSkillForSpell() => ((delegate* unmanaged[Thiscall]<ref CSpellBase, UInt32>)0x00597950)(ref this); // .text:00596A50 ; unsigned int __thiscall CSpellBase::InqSkillForSpell(CSpellBase *this) .text:00596A50 ?InqSkillForSpell@CSpellBase@@QBEKXZ

        // CSpellBase.InqSpellFormula:
        public SpellFormula* InqSpellFormula(SpellFormula* result) => ((delegate* unmanaged[Thiscall]<ref CSpellBase, SpellFormula*, SpellFormula*>)0x00597E20)(ref this, result); // .text:00596EB0 ; SpellFormula *__thiscall CSpellBase::InqSpellFormula(CSpellBase *this, SpellFormula *result) .text:00596EB0 ?InqSpellFormula@CSpellBase@@QBE?AVSpellFormula@@XZ

        // CSpellBase.InqSpellLevelByRoughHeuristic:
        public UInt32 InqSpellLevelByRoughHeuristic() => ((delegate* unmanaged[Thiscall]<ref CSpellBase, UInt32>)0x005981D0)(ref this); // .text:00597260 ; unsigned int __thiscall CSpellBase::InqSpellLevelByRoughHeuristic(CSpellBase *this) .text:00597260 ?InqSpellLevelByRoughHeuristic@CSpellBase@@QBEKXZ

        // CSpellBase.InqTargetType:
        public UInt32 InqTargetType() => ((delegate* unmanaged[Thiscall]<ref CSpellBase, UInt32>)0x005981A0)(ref this); // .text:00597230 ; unsigned int __thiscall CSpellBase::InqTargetType(CSpellBase *this) .text:00597230 ?InqTargetType@CSpellBase@@QBEKXZ

        // CSpellBase.IsUntargeted:
        public int IsUntargeted() => ((delegate* unmanaged[Thiscall]<ref CSpellBase, int>)0x00598410)(ref this); // .text:005974A0 ; int __thiscall CSpellBase::IsUntargeted(CSpellBase *this) .text:005974A0 ?IsUntargeted@CSpellBase@@QBEHXZ

        // CSpellBase.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CSpellBase, void**, UInt32, UInt32>)0x00597B70)(ref this, addr, size); // .text:00596C70 ; unsigned int __thiscall CSpellBase::Pack(CSpellBase *this, void **addr, unsigned int size) .text:00596C70 ?Pack@CSpellBase@@UAEIAAPAXI@Z

        // CSpellBase.SchoolEnumToName:
        public static AC1Legacy.PStringBase<char>* SchoolEnumToName(AC1Legacy.PStringBase<char>* result, UInt32 school) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, AC1Legacy.PStringBase<char>*>)0x00598370)(result, school); // .text:00597400 ; AC1Legacy::PStringBase<char> *__cdecl CSpellBase::SchoolEnumToName(AC1Legacy::PStringBase<char> *result, const unsigned int school) .text:00597400 ?SchoolEnumToName@CSpellBase@@SA?AV?$PStringBase@D@AC1Legacy@@K@Z

        // CSpellBase.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CSpellBase, void**, UInt32, int>)0x00598200)(ref this, addr, size); // .text:00597290 ; int __thiscall CSpellBase::UnPack(CSpellBase *this, void **addr, unsigned int size) .text:00597290 ?UnPack@CSpellBase@@UAEHAAPAXI@Z

        // CSpellBase.packed_size:
        public UInt32 packed_size() => ((delegate* unmanaged[Thiscall]<ref CSpellBase, UInt32>)0x00597B00)(ref this); // .text:00596C00 ; unsigned int __thiscall CSpellBase::packed_size(CSpellBase *this) .text:00596C00 ?packed_size@CSpellBase@@AAEIXZ
    }



    public unsafe struct SpellFormula {
        // Struct:
        public PackObj PackObj;
        public fixed UInt32 _comps[8];
        public override string ToString() => $"PackObj(PackObj):{PackObj}, _comps:{_comps[0]:X8}";


        // Functions:

        // SpellFormula.Complete:
        public int Complete() => ((delegate* unmanaged[Thiscall]<ref SpellFormula, int>)0x005BD950)(ref this); // .text:005BC880 ; int __thiscall SpellFormula::Complete(SpellFormula *this) .text:005BC880 ?Complete@SpellFormula@@QBEHXZ

        // SpellFormula.Decrypt:
        public int Decrypt(UInt32 key) => ((delegate* unmanaged[Thiscall]<ref SpellFormula, UInt32, int>)0x005BDAC0)(ref this, key); // .text:005BC9F0 ; int __thiscall SpellFormula::Decrypt(SpellFormula *this, const unsigned int key) .text:005BC9F0 ?Decrypt@SpellFormula@@QAEHK@Z

        // SpellFormula.FindMostPowerfulPowerComponent:
        public UInt32 FindMostPowerfulPowerComponent(UInt32* power_lvl) => ((delegate* unmanaged[Thiscall]<ref SpellFormula, UInt32*, UInt32>)0x005BDA20)(ref this, power_lvl); // .text:005BC950 ; unsigned int __thiscall SpellFormula::FindMostPowerfulPowerComponent(SpellFormula *this, unsigned int *power_lvl) .text:005BC950 ?FindMostPowerfulPowerComponent@SpellFormula@@QBEKAAK@Z

        // SpellFormula.GetNumSpellComponents:
        public int GetNumSpellComponents() => ((delegate* unmanaged[Thiscall]<ref SpellFormula, int>)0x005BD990)(ref this); // .text:005BC8C0 ; int __thiscall SpellFormula::GetNumSpellComponents(SpellFormula *this) .text:005BC8C0 ?GetNumSpellComponents@SpellFormula@@QBEJXZ

        // SpellFormula.GetPowerLevelOfPowerComponent:
        public UInt32 GetPowerLevelOfPowerComponent() => ((delegate* unmanaged[Thiscall]<ref SpellFormula, UInt32>)0x005BDA10)(ref this); // .text:005BC940 ; unsigned int __thiscall SpellFormula::GetPowerLevelOfPowerComponent(SpellFormula *this) .text:005BC940 ?GetPowerLevelOfPowerComponent@SpellFormula@@QBEKXZ

        // SpellFormula.GetTargetingType:
        public UInt32 GetTargetingType() => ((delegate* unmanaged[Thiscall]<ref SpellFormula, UInt32>)0x005BD9E0)(ref this); // .text:005BC910 ; unsigned int __thiscall SpellFormula::GetTargetingType(SpellFormula *this) .text:005BC910 ?GetTargetingType@SpellFormula@@QBEKXZ

        // SpellFormula.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellFormula, void**, UInt32, UInt32>)0x005BDB30)(ref this, addr, size); // .text:005BCA60 ; unsigned int __thiscall SpellFormula::Pack(SpellFormula *this, void **addr, unsigned int size) .text:005BCA60 ?Pack@SpellFormula@@UAEIAAPAXI@Z

        // SpellFormula.RandomizeForName:
        public int RandomizeForName(AC1Legacy.PStringBase<char>* account_name, int spell_version) => ((delegate* unmanaged[Thiscall]<ref SpellFormula, AC1Legacy.PStringBase<char>*, int, int>)0x005BE120)(ref this, account_name, spell_version); // .text:005BD050 ; int __thiscall SpellFormula::RandomizeForName(SpellFormula *this, AC1Legacy::PStringBase<char> *account_name, const int spell_version) .text:005BD050 ?RandomizeForName@SpellFormula@@QAEHABV?$PStringBase@D@AC1Legacy@@J@Z

        // SpellFormula.RandomizeVersion1:
        public int RandomizeVersion1(AC1Legacy.PStringBase<char>* account_name) => ((delegate* unmanaged[Thiscall]<ref SpellFormula, AC1Legacy.PStringBase<char>*, int>)0x005BDC40)(ref this, account_name); // .text:005BCB70 ; int __thiscall SpellFormula::RandomizeVersion1(SpellFormula *this, AC1Legacy::PStringBase<char> *account_name) .text:005BCB70 ?RandomizeVersion1@SpellFormula@@IAEHABV?$PStringBase@D@AC1Legacy@@@Z

        // SpellFormula.RandomizeVersion2:
        public int RandomizeVersion2(AC1Legacy.PStringBase<char>* account_name) => ((delegate* unmanaged[Thiscall]<ref SpellFormula, AC1Legacy.PStringBase<char>*, int>)0x005BDE10)(ref this, account_name); // .text:005BCD40 ; int __thiscall SpellFormula::RandomizeVersion2(SpellFormula *this, AC1Legacy::PStringBase<char> *account_name) .text:005BCD40 ?RandomizeVersion2@SpellFormula@@IAEHABV?$PStringBase@D@AC1Legacy@@@Z

        // SpellFormula.RandomizeVersion3:
        public int RandomizeVersion3(AC1Legacy.PStringBase<char>* account_name) => ((delegate* unmanaged[Thiscall]<ref SpellFormula, AC1Legacy.PStringBase<char>*, int>)0x005BDEF0)(ref this, account_name); // .text:005BCE20 ; int __thiscall SpellFormula::RandomizeVersion3(SpellFormula *this, AC1Legacy::PStringBase<char> *account_name) .text:005BCE20 ?RandomizeVersion3@SpellFormula@@IAEHABV?$PStringBase@D@AC1Legacy@@@Z

        // SpellFormula.SetComponent:
        public int SetComponent(int num, UInt32 comp) => ((delegate* unmanaged[Thiscall]<ref SpellFormula, int, UInt32, int>)0x005BD970)(ref this, num, comp); // .text:005BC8A0 ; int __thiscall SpellFormula::SetComponent(SpellFormula *this, const int num, const unsigned int comp) .text:005BC8A0 ?SetComponent@SpellFormula@@QAEHJK@Z

        // SpellFormula.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellFormula, void**, UInt32, int>)0x005BDBB0)(ref this, addr, size); // .text:005BCAE0 ; int __thiscall SpellFormula::UnPack(SpellFormula *this, void **addr, unsigned int size) .text:005BCAE0 ?UnPack@SpellFormula@@UAEHAAPAXI@Z
    }
    public unsafe struct MetaSpell {
        // Struct:
        public PackObj PackObj;
        public SpellType _sp_type;
        public Spell* _spell;
        public override string ToString() => $"PackObj(PackObj):{PackObj}, _sp_type(SpellType):{_sp_type}, _spell:->(Spell*)0x{(Int32)_spell:X8}";


        // Functions:

        // MetaSpell.__Ctor:
        // public static delegate* unmanaged[Thiscall]<MetaSpell*> __Ctor = (delegate* unmanaged[Thiscall]<MetaSpell*>)0xDEADBEEF; // .text:00598770 ; void __thiscall MetaSpell::MetaSpell(MetaSpell *this) .text:00598770 ??0MetaSpell@@QAE@XZ

        // MetaSpell.InqDuration:
        // public static delegate* unmanaged[Thiscall]<MetaSpell*, Double> InqDuration = (delegate* unmanaged[Thiscall]<MetaSpell*, Double>)0xDEADBEEF; // .text:00598790 ; long Double __thiscall MetaSpell::InqDuration(MetaSpell *this) .text:00598790 ?InqDuration@MetaSpell@@QBENXZ

        // MetaSpell.Pack:
        // public static delegate* unmanaged[Thiscall]<MetaSpell*,void**,UInt32, UInt32> Pack = (delegate* unmanaged[Thiscall]<MetaSpell*,void**,UInt32, UInt32>)0xDEADBEEF; // .text:005987B0 ; UInt32 __thiscall MetaSpell::Pack(MetaSpell *this, void **addr, UInt32 size) .text:005987B0 ?Pack@MetaSpell@@UAEIAAPAXI@Z

        // MetaSpell.UnPack:
        // public static delegate* unmanaged[Thiscall]<MetaSpell*,void**,UInt32, Int32> UnPack = (delegate* unmanaged[Thiscall]<MetaSpell*,void**,UInt32, Int32>)0xDEADBEEF; // .text:00598810 ; Int32 __thiscall MetaSpell::UnPack(MetaSpell *this, void **addr, UInt32 size) .text:00598810 ?UnPack@MetaSpell@@UAEHAAPAXI@Z

        // MetaSpell.__Dtor:
        // public static delegate* unmanaged[Thiscall]<MetaSpell*> __Dtor = (delegate* unmanaged[Thiscall]<MetaSpell*>)0xDEADBEEF; // .text:005988F0 ; void __thiscall MetaSpell::~MetaSpell(MetaSpell *this) .text:005988F0 ??1MetaSpell@@UAE@XZ

        // MetaSpell.operator=:
        // public static delegate* unmanaged[Thiscall]<MetaSpell*, MetaSpell*> operator= = (delegate* unmanaged[Thiscall]<MetaSpell*, MetaSpell*>)0xDEADBEEF; // .text:00598920 ; public: class MetaSpell & __thiscall MetaSpell::operator=(class MetaSpell const &) .text:00598920 ??4MetaSpell@@QAEAAV0@ABV0@@Z

        // MetaSpell.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<MetaSpell*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<MetaSpell*,UInt32, void*>)0xDEADBEEF; // .text:00598980 ; void *__thiscall MetaSpell::`vector deleting destructor'(MetaSpell *this, UInt32) .text:00598980 ??_EMetaSpell@@UAEPAXI@Z
    }
    public unsafe struct Spell {
        // Struct:
        public PackObj a0;
        public UInt32 _spell_id;
        public override string ToString() => $"a0(PackObj):{a0}, _spell_id:{_spell_id:X8}";

        // Functions:

        // Spell.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Spell, void>)0xDEADBEEF)(ref this); // .text:00598880 ; void __thiscall Spell::Spell(Spell *this) .text:00598880 ??0Spell@@QAE@XZ

        // Spell.operator_equals:
        public Spell* operator_equals() => ((delegate* unmanaged[Thiscall]<ref Spell, Spell*>)0x00599700)(ref this); // .text:00598760 ; public: virtual class Spell & __thiscall Spell::operator=(class Spell const &) .text:00598760 ??4Spell@@UAEAAV0@ABV0@@Z

        // Spell.BuildSpell:
        public static Spell* BuildSpell(SpellType sp_type) => ((delegate* unmanaged[Cdecl]<SpellType, Spell*>)0x00599540)(sp_type); // .text:005985A0 ; Spell *__cdecl Spell::BuildSpell(SpellType sp_type) .text:005985A0 ?BuildSpell@Spell@@SAPAV1@W4SpellType@@@Z

        // Spell.InqDuration:
        // public Double InqDuration() => ((delegate* unmanaged[Thiscall]<ref Spell, Double>)0xDEADBEEF)(ref this); // .text:00598890 ; long double __thiscall Spell::InqDuration(Spell *this) .text:00598890 ?InqDuration@Spell@@UBENXZ

        // Spell.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Spell, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005988A0 ; unsigned int __thiscall Spell::Pack(Spell *this, void **addr, unsigned int size) .text:005988A0 ?Pack@Spell@@UAEIAAPAXI@Z

        // Spell.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Spell, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005988C0 ; int __thiscall Spell::UnPack(Spell *this, void **addr, unsigned int size) .text:005988C0 ?UnPack@Spell@@UAEHAAPAXI@Z
    }

    public unsafe struct SpellSet {
        // Struct:
        public PackObj a0;
        public PList<SpellSetTierList> m_countTiers;
        public override string ToString() => $"a0(PackObj):{a0}, m_countTiers(PList<SpellSetTierList>):{m_countTiers}";

        // Functions:

        // SpellSet.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref SpellSet, void>)0x00598F20)(ref this); // .text:00597FF0 ; void __thiscall SpellSet::SpellSet(SpellSet *this) .text:00597FF0 ??0SpellSet@@QAE@XZ

        // SpellSet.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref SpellSet, UInt32>)0x005BE240)(ref this); // .text:005BD170 ; unsigned int __thiscall SpellSet::GetPackSize(SpellSet *this) .text:005BD170 ?GetPackSize@SpellSet@@UAEIXZ

        // SpellSet.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellSet, void**, UInt32, UInt32>)0x005BE260)(ref this, addr, size); // .text:005BD190 ; unsigned int __thiscall SpellSet::Pack(SpellSet *this, void **addr, unsigned int size) .text:005BD190 ?Pack@SpellSet@@UAEIAAPAXI@Z

        // SpellSet.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellSet, void**, UInt32, int>)0x005BE290)(ref this, addr, size); // .text:005BD1C0 ; int __thiscall SpellSet::UnPack(SpellSet *this, void **addr, unsigned int size) .text:005BD1C0 ?UnPack@SpellSet@@UAEHAAPAXI@Z
    }

    public unsafe struct SpellSetTierList {
        // Struct:
        public PackObj a0;
        public UInt32 m_PieceCount;
        public PList<UInt32> m_SpellList;
        public override string ToString() => $"a0(PackObj):{a0}, m_PieceCount:{m_PieceCount:X8}, m_SpellList(PList<UInt32>):{m_SpellList}";

        // Functions:

        // SpellSetTierList.__Ctor:
        public void __Ctor(SpellSetTierList* from) => ((delegate* unmanaged[Thiscall]<ref SpellSetTierList, SpellSetTierList*, void>)0x005BE2C0)(ref this, from); // .text:005BD1F0 ; void __thiscall SpellSetTierList::SpellSetTierList(SpellSetTierList *this, SpellSetTierList *from) .text:005BD1F0 ??0SpellSetTierList@@QAE@ABV0@@Z

        // SpellSetTierList.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref SpellSetTierList, UInt32>)0x005BE1A0)(ref this); // .text:005BD0D0 ; unsigned int __thiscall SpellSetTierList::GetPackSize(SpellSetTierList *this) .text:005BD0D0 ?GetPackSize@SpellSetTierList@@UAEIXZ

        // SpellSetTierList.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellSetTierList, void**, UInt32, UInt32>)0x005BE1C0)(ref this, addr, size); // .text:005BD0F0 ; unsigned int __thiscall SpellSetTierList::Pack(SpellSetTierList *this, void **addr, unsigned int size) .text:005BD0F0 ?Pack@SpellSetTierList@@UAEIAAPAXI@Z

        // SpellSetTierList.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellSetTierList, void**, UInt32, int>)0x005BE200)(ref this, addr, size); // .text:005BD130 ; int __thiscall SpellSetTierList::UnPack(SpellSetTierList *this, void **addr, unsigned int size) .text:005BD130 ?UnPack@SpellSetTierList@@UAEHAAPAXI@Z
    }



    /// <summary>
    /// gmSpellcastingUI* mine = (gmSpellcastingUI*)GlobalEventHandler.geh->ResolveHandler(5100110);
    /// </summary>
    public unsafe struct gmSpellcastingUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public UIElement_Panel* m_spellcastPanel;
        public UIElement_Text* m_spellName;
        public UIElement_Button* m_spellcastButton;
        public UIElement* m_endowmentIcon;
        public UIElement* m_endowmentIcon_Overlay;
        public UIElement* m_endowmentIcon_Underlay;
        public UIElement* m_endowmentIcon_Selected;
        public UIElement* m_spellcastBackground;
        public sbyte m_endowmentPresent;
        public UInt32 m_endowmentItemID;
        public UInt32 m_endowmentSpellID;
        public int m_subMenus;
        //public SpellCastSubMenu m_subMenus_1;
        //public SpellCastSubMenu m_subMenus_2;
        //public SpellCastSubMenu m_subMenus_3;
        //public SpellCastSubMenu m_subMenus_4;
        //public SpellCastSubMenu m_subMenus_5;
        //public SpellCastSubMenu m_subMenus_6;
        //public SpellCastSubMenu m_subMenus_7; // , m_subMenus_0:{m_subMenus_0}, m_subMenus_1:{m_subMenus_1}
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_spellcastPanel:->(UIElement_Panel*)0x{(int)m_spellcastPanel:X8}, m_spellName:->(UIElement_Text*)0x{(int)m_spellName:X8}, m_spellcastButton:->(UIElement_Button*)0x{(int)m_spellcastButton:X8}, m_endowmentIcon:->(UIElement*)0x{(int)m_endowmentIcon:X8}, m_endowmentIcon_Overlay:->(UIElement*)0x{(int)m_endowmentIcon_Overlay:X8}, m_endowmentIcon_Underlay:->(UIElement*)0x{(int)m_endowmentIcon_Underlay:X8}, m_endowmentIcon_Selected:->(UIElement*)0x{(int)m_endowmentIcon_Selected:X8}, m_spellcastBackground:->(UIElement*)0x{(int)m_spellcastBackground:X8}, m_endowmentPresent:{m_endowmentPresent:X2}, m_endowmentItemID:{m_endowmentItemID:X8}, m_endowmentSpellID:{m_endowmentSpellID:X8}";

        // Functions:

        // gmSpellcastingUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, LayoutDesc*, ElementDesc*, void>)0x004C6830)(ref this, _layout, _full_desc); // .text:004C5C40 ; void __thiscall gmSpellcastingUI::gmSpellcastingUI(gmSpellcastingUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004C5C40 ??0gmSpellcastingUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmSpellcastingUI.AddSpellShortcut:
        public void AddSpellShortcut(UInt32 i_spellID, int _pos, Byte allowReplace) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UInt32, int, Byte, void>)0x004C7F10)(ref this, i_spellID, _pos, allowReplace); // .text:004C7320 ; void __thiscall gmSpellcastingUI::AddSpellShortcut(gmSpellcastingUI *this, unsigned int i_spellID, int _pos, bool allowReplace) .text:004C7320 ?AddSpellShortcut@gmSpellcastingUI@@IAEXKH_N@Z

        // gmSpellcastingUI.Cast:
        public void Cast() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C6C40)(ref this); // .text:004C6050 ; void __thiscall gmSpellcastingUI::Cast(gmSpellcastingUI *this) .text:004C6050 ?Cast@gmSpellcastingUI@@IAEXXZ

        // gmSpellcastingUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x004C6BF0)(_layout, _full_desc); // .text:004C6000 ; UIElement *__cdecl gmSpellcastingUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004C6000 ?Create@gmSpellcastingUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmSpellcastingUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UInt32, UIElement*>)0x004C6650)(ref this, i_eType); // .text:004C5A60 ; UIElement *__thiscall gmSpellcastingUI::DynamicCast(gmSpellcastingUI *this, unsigned int i_eType) .text:004C5A60 ?DynamicCast@gmSpellcastingUI@@UAEPAVUIElement@@K@Z

        // gmSpellcastingUI.GetNextTabID:
        public UInt32 GetNextTabID(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UInt32, UInt32>)0x004C6400)(ref this, _id); // .text:004C5810 ; unsigned int __thiscall gmSpellcastingUI::GetNextTabID(gmSpellcastingUI *this, unsigned int _id) .text:004C5810 ?GetNextTabID@gmSpellcastingUI@@IAEKK@Z

        // gmSpellcastingUI.GetOpenSubMenuIndex:
        public int GetOpenSubMenuIndex() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, int>)0x004C6500)(ref this); // .text:004C5910 ; int __thiscall gmSpellcastingUI::GetOpenSubMenuIndex(gmSpellcastingUI *this) .text:004C5910 ?GetOpenSubMenuIndex@gmSpellcastingUI@@QAEHXZ

        // gmSpellcastingUI.GetPrevTabID:
        public UInt32 GetPrevTabID(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UInt32, UInt32>)0x004C6480)(ref this, _id); // .text:004C5890 ; unsigned int __thiscall gmSpellcastingUI::GetPrevTabID(gmSpellcastingUI *this, unsigned int _id) .text:004C5890 ?GetPrevTabID@gmSpellcastingUI@@IAEKK@Z

        // gmSpellcastingUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UInt32>)0x004C6670)(ref this); // .text:004C5A80 ; unsigned int __thiscall gmSpellcastingUI::GetUIElementType(gmSpellcastingUI *this) .text:004C5A80 ?GetUIElementType@gmSpellcastingUI@@UBEKXZ

        // gmSpellcastingUI.HandleDropRelease:
        public void HandleDropRelease(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UIElementMessageInfo*, void>)0x004C8520)(ref this, i_rMsg); // .text:004C7930 ; void __thiscall gmSpellcastingUI::HandleDropRelease(gmSpellcastingUI *this, UIElementMessageInfo *i_rMsg) .text:004C7930 ?HandleDropRelease@gmSpellcastingUI@@IAEXABUUIElementMessageInfo@@@Z

        // gmSpellcastingUI.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UIElementMessageInfo*, UIElementMessageListenResult>)0x004C86A0)(ref this, i_rMsg); // .text:004C7AB0 ; UIElementMessageListenResult __thiscall gmSpellcastingUI::ListenToElementMessage(gmSpellcastingUI *this, UIElementMessageInfo *i_rMsg) .text:004C7AB0 ?ListenToElementMessage@gmSpellcastingUI@@MAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmSpellcastingUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C68F0)(ref this); // .text:004C5D00 ; void __thiscall gmSpellcastingUI::PostInit(gmSpellcastingUI *this) .text:004C5D00 ?PostInit@gmSpellcastingUI@@UAEXXZ

        // gmSpellcastingUI.RecvNotice_AddSpellShortcut:
        public void RecvNotice_AddSpellShortcut(UInt32 i_spellID) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UInt32, void>)0x004C8660)(ref this, i_spellID); // .text:004C7A70 ; void __thiscall gmSpellcastingUI::RecvNotice_AddSpellShortcut(gmSpellcastingUI *this, unsigned int i_spellID) .text:004C7A70 ?RecvNotice_AddSpellShortcut@gmSpellcastingUI@@MAEXK@Z

        // gmSpellcastingUI.RecvNotice_CastCurrentSpell:
        public void RecvNotice_CastCurrentSpell() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C6FF0)(ref this); // .text:004C6400 ; void __thiscall gmSpellcastingUI::RecvNotice_CastCurrentSpell(gmSpellcastingUI *this) .text:004C6400 ?RecvNotice_CastCurrentSpell@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_CastQuickslotSpell:
        public void RecvNotice_CastQuickslotSpell(int i_slot) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, int, void>)0x004C84A0)(ref this, i_slot); // .text:004C78B0 ; void __thiscall gmSpellcastingUI::RecvNotice_CastQuickslotSpell(gmSpellcastingUI *this, int i_slot) .text:004C78B0 ?RecvNotice_CastQuickslotSpell@gmSpellcastingUI@@MAEXJ@Z

        // gmSpellcastingUI.RecvNotice_FirstSpellSelection:
        public void RecvNotice_FirstSpellSelection() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C8390)(ref this); // .text:004C77A0 ; void __thiscall gmSpellcastingUI::RecvNotice_FirstSpellSelection(gmSpellcastingUI *this) .text:004C77A0 ?RecvNotice_FirstSpellSelection@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_FirstSpellTab:
        public void RecvNotice_FirstSpellTab() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C8330)(ref this); // .text:004C7740 ; void __thiscall gmSpellcastingUI::RecvNotice_FirstSpellTab(gmSpellcastingUI *this) .text:004C7740 ?RecvNotice_FirstSpellTab@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_ItemListBeginDrag:
        public void RecvNotice_ItemListBeginDrag(UIElement* i_itemList, int i_slotNum) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UIElement*, int, void>)0x004C7F50)(ref this, i_itemList, i_slotNum); // .text:004C7360 ; void __thiscall gmSpellcastingUI::RecvNotice_ItemListBeginDrag(gmSpellcastingUI *this, UIElement *i_itemList, int i_slotNum) .text:004C7360 ?RecvNotice_ItemListBeginDrag@gmSpellcastingUI@@MAEXABVUIElement@@J@Z

        // gmSpellcastingUI.RecvNotice_LastSpellSelection:
        public void RecvNotice_LastSpellSelection() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C8410)(ref this); // .text:004C7820 ; void __thiscall gmSpellcastingUI::RecvNotice_LastSpellSelection(gmSpellcastingUI *this) .text:004C7820 ?RecvNotice_LastSpellSelection@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_LastSpellTab:
        public void RecvNotice_LastSpellTab() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C8360)(ref this); // .text:004C7770 ; void __thiscall gmSpellcastingUI::RecvNotice_LastSpellTab(gmSpellcastingUI *this) .text:004C7770 ?RecvNotice_LastSpellTab@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_NextSpellSelection:
        public void RecvNotice_NextSpellSelection() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C8050)(ref this); // .text:004C7460 ; void __thiscall gmSpellcastingUI::RecvNotice_NextSpellSelection(gmSpellcastingUI *this) .text:004C7460 ?RecvNotice_NextSpellSelection@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_NextSpellTab:
        public void RecvNotice_NextSpellTab() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C7FD0)(ref this); // .text:004C73E0 ; void __thiscall gmSpellcastingUI::RecvNotice_NextSpellTab(gmSpellcastingUI *this) .text:004C73E0 ?RecvNotice_NextSpellTab@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_PlayerDescReceived:
        public void RecvNotice_PlayerDescReceived(CACQualities* i_playerDesc, CPlayerModule* i_playerModule) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, CACQualities*, CPlayerModule*, void>)0x004C7590)(ref this, i_playerDesc, i_playerModule); // .text:004C69A0 ; void __thiscall gmSpellcastingUI::RecvNotice_PlayerDescReceived(gmSpellcastingUI *this, CACQualities *i_playerDesc, CPlayerModule *i_playerModule) .text:004C69A0 ?RecvNotice_PlayerDescReceived@gmSpellcastingUI@@MAEXABVCACQualities@@ABVCPlayerModule@@@Z

        // gmSpellcastingUI.RecvNotice_PrevSpellSelection:
        public void RecvNotice_PrevSpellSelection() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C81C0)(ref this); // .text:004C75D0 ; void __thiscall gmSpellcastingUI::RecvNotice_PrevSpellSelection(gmSpellcastingUI *this) .text:004C75D0 ?RecvNotice_PrevSpellSelection@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_PrevSpellTab:
        public void RecvNotice_PrevSpellTab() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C8010)(ref this); // .text:004C7420 ; void __thiscall gmSpellcastingUI::RecvNotice_PrevSpellTab(gmSpellcastingUI *this) .text:004C7420 ?RecvNotice_PrevSpellTab@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_RemoveSpellShortcut:
        public void RecvNotice_RemoveSpellShortcut(UInt32 i_spellID) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UInt32, void>)0x004C75C0)(ref this, i_spellID); // .text:004C69D0 ; void __thiscall gmSpellcastingUI::RecvNotice_RemoveSpellShortcut(gmSpellcastingUI *this, unsigned int i_spellID) .text:004C69D0 ?RecvNotice_RemoveSpellShortcut@gmSpellcastingUI@@MAEXK@Z

        // gmSpellcastingUI.RecvNotice_SelectionChanged:
        public void RecvNotice_SelectionChanged() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C7E60)(ref this); // .text:004C7270 ; void __thiscall gmSpellcastingUI::RecvNotice_SelectionChanged(gmSpellcastingUI *this) .text:004C7270 ?RecvNotice_SelectionChanged@gmSpellcastingUI@@MAEXXZ

        // gmSpellcastingUI.RecvNotice_ServerSaysMoveItem:
        public void RecvNotice_ServerSaysMoveItem(UInt32 i_itemID, UInt32 i_oldContainer, UInt32 i_oldWielder, UInt32 i_oldLocation, UInt32 i_newContainer, int i_place, UInt32 i_newWielder, UInt32 i_newLocation) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x004C7EC0)(ref this, i_itemID, i_oldContainer, i_oldWielder, i_oldLocation, i_newContainer, i_place, i_newWielder, i_newLocation); // .text:004C72D0 ; void __thiscall gmSpellcastingUI::RecvNotice_ServerSaysMoveItem(gmSpellcastingUI *this, unsigned int i_itemID, unsigned int i_oldContainer, unsigned int i_oldWielder, unsigned int i_oldLocation, unsigned int i_newContainer, int i_place, unsigned int i_newWielder, unsigned int i_newLocation) .text:004C72D0 ?RecvNotice_ServerSaysMoveItem@gmSpellcastingUI@@MAEXKKKKKHKK@Z

        // gmSpellcastingUI.RecvNotice_SetCombatMode:
        public void RecvNotice_SetCombatMode(COMBAT_MODE i_eCombatMode) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, COMBAT_MODE, void>)0x004C7E70)(ref this, i_eCombatMode); // .text:004C7280 ; void __thiscall gmSpellcastingUI::RecvNotice_SetCombatMode(gmSpellcastingUI *this, COMBAT_MODE i_eCombatMode) .text:004C7280 ?RecvNotice_SetCombatMode@gmSpellcastingUI@@MAEXW4COMBAT_MODE@@@Z

        // gmSpellcastingUI.RecvNotice_SpellRemoved:
        public void RecvNotice_SpellRemoved(UInt32 i_eSpellID) => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, UInt32, void>)0x004C75F0)(ref this, i_eSpellID); // .text:004C6A00 ; void __thiscall gmSpellcastingUI::RecvNotice_SpellRemoved(gmSpellcastingUI *this, unsigned int i_eSpellID) .text:004C6A00 ?RecvNotice_SpellRemoved@gmSpellcastingUI@@MAEXK@Z

        // gmSpellcastingUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004C6C20)(); // .text:004C6030 ; void __cdecl gmSpellcastingUI::Register() .text:004C6030 ?Register@gmSpellcastingUI@@SAXXZ

        // gmSpellcastingUI.UpdateCastButtonTooltip:
        public void UpdateCastButtonTooltip() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C7620)(ref this); // .text:004C6A30 ; void __thiscall gmSpellcastingUI::UpdateCastButtonTooltip(gmSpellcastingUI *this) .text:004C6A30 ?UpdateCastButtonTooltip@gmSpellcastingUI@@IAEXXZ

        // gmSpellcastingUI.UpdateEndowmentIcon:
        public void UpdateEndowmentIcon() => ((delegate* unmanaged[Thiscall]<ref gmSpellcastingUI, void>)0x004C6D10)(ref this); // .text:004C6120 ; void __thiscall gmSpellcastingUI::UpdateEndowmentIcon(gmSpellcastingUI *this) .text:004C6120 ?UpdateEndowmentIcon@gmSpellcastingUI@@IAEXXZ
    }

    public unsafe struct SpellCastSubMenu {
        // Struct:
        public ItemListDragHandler a0;
        public UIElement_ItemList* m_spellItemList;
        public UIElement* m_spellTabElement;
        public UInt32 m_selectedSpellID;
        public UInt32 m_numSpells;
        public int m_tabIndex;
        public Byte m_endowmentSelected;
        public override string ToString() => $"a0(ItemListDragHandler):{a0}, m_spellItemList:->(UIElement_ItemList*)0x{(int)m_spellItemList:X8}, m_spellTabElement:->(UIElement*)0x{(int)m_spellTabElement:X8}, m_selectedSpellID:{m_selectedSpellID:X8}, m_numSpells:{m_numSpells:X8}, m_tabIndex(int):{m_tabIndex}, m_endowmentSelected:{m_endowmentSelected:X2}";

        // Functions:

        // SpellCastSubMenu.SelectSpellFromIndex:
        public Byte SelectSpellFromIndex(int index) => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, int, Byte>)0x004C6780)(ref this, index); // .text:004C5B90 ; bool __thiscall SpellCastSubMenu::SelectSpellFromIndex(SpellCastSubMenu *this, int index) .text:004C5B90 ?SelectSpellFromIndex@SpellCastSubMenu@@IAE_NH@Z

        // SpellCastSubMenu.UpdateShortcutOverlays:
        public void UpdateShortcutOverlays() => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, void>)0x004C67D0)(ref this); // .text:004C5BE0 ; void __thiscall SpellCastSubMenu::UpdateShortcutOverlays(SpellCastSubMenu *this) .text:004C5BE0 ?UpdateShortcutOverlays@SpellCastSubMenu@@IAEXXZ

        // SpellCastSubMenu.RemoveSpellFromPlayerModule:
        public void RemoveSpellFromPlayerModule(UInt32 _spellID) => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, UInt32, void>)0x004C7000)(ref this, _spellID); // .text:004C6410 ; void __thiscall SpellCastSubMenu::RemoveSpellFromPlayerModule(SpellCastSubMenu *this, unsigned int _spellID) .text:004C6410 ?RemoveSpellFromPlayerModule@SpellCastSubMenu@@IAEXK@Z

        // SpellCastSubMenu.AddSpellToPlayerModule:
        public void AddSpellToPlayerModule(UInt32 _spellID, UInt32 _pos) => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, UInt32, UInt32, void>)0x004C70B0)(ref this, _spellID, _pos); // .text:004C64C0 ; void __thiscall SpellCastSubMenu::AddSpellToPlayerModule(SpellCastSubMenu *this, unsigned int _spellID, unsigned int _pos) .text:004C64C0 ?AddSpellToPlayerModule@SpellCastSubMenu@@IAEXKK@Z

        // SpellCastSubMenu.UpdateFromPlayerModule:
        public void UpdateFromPlayerModule() => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, void>)0x004C7160)(ref this); // .text:004C6570 ; void __thiscall SpellCastSubMenu::UpdateFromPlayerModule(SpellCastSubMenu *this) .text:004C6570 ?UpdateFromPlayerModule@SpellCastSubMenu@@IAEXXZ

        // SpellCastSubMenu.RemoveSpellFromMenu:
        public int RemoveSpellFromMenu(UInt32 _spellID) => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, UInt32, int>)0x004C74E0)(ref this, _spellID); // .text:004C68F0 ; int __thiscall SpellCastSubMenu::RemoveSpellFromMenu(SpellCastSubMenu *this, unsigned int _spellID) .text:004C68F0 ?RemoveSpellFromMenu@SpellCastSubMenu@@IAEHK@Z

        // SpellCastSubMenu.OnItemListDragOver:
        public Byte OnItemListDragOver(UIElement_UIItem* _catchElement, UInt32 _dropItemID, UInt32 _dropSpellID, DropItemFlags _dropFlags) => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, UIElement_UIItem*, UInt32, UInt32, DropItemFlags, Byte>)0x004C6580)(ref this, _catchElement, _dropItemID, _dropSpellID, _dropFlags); // .text:004C5990 ; bool __thiscall SpellCastSubMenu::OnItemListDragOver(SpellCastSubMenu *this, UIElement_UIItem *_catchElement, unsigned int _dropItemID, unsigned int _dropSpellID, DropItemFlags _dropFlags) .text:004C5990 ?OnItemListDragOver@SpellCastSubMenu@@MAE_NPAVUIElement_UIItem@@KKW4DropItemFlags@@@Z

        // SpellCastSubMenu.SetSelected:
        public void SetSelected(UInt32 _selectedSpellID) => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, UInt32, void>)0x004C66F0)(ref this, _selectedSpellID); // .text:004C5B00 ; void __thiscall SpellCastSubMenu::SetSelected(SpellCastSubMenu *this, unsigned int _selectedSpellID) .text:004C5B00 ?SetSelected@SpellCastSubMenu@@IAEXK@Z

        // SpellCastSubMenu.AddFavorite:
        public void AddFavorite(UInt32 _spellID, int _pos, Byte allowReplace) => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, UInt32, int, Byte, void>)0x004C7C50)(ref this, _spellID, _pos, allowReplace); // .text:004C7060 ; void __thiscall SpellCastSubMenu::AddFavorite(SpellCastSubMenu *this, unsigned int _spellID, int _pos, bool allowReplace) .text:004C7060 ?AddFavorite@SpellCastSubMenu@@IAEXKH_N@Z

        // SpellCastSubMenu.Init:
        public void Init(UIElement* parent, UInt32 elementID, UInt32 tabID, int index) => ((delegate* unmanaged[Thiscall]<ref SpellCastSubMenu, UIElement*, UInt32, UInt32, int, void>)0x004C6680)(ref this, parent, elementID, tabID, index); // .text:004C5A90 ; void __thiscall SpellCastSubMenu::Init(SpellCastSubMenu *this, UIElement *parent, unsigned int elementID, unsigned int tabID, int index) .text:004C5A90 ?Init@SpellCastSubMenu@@QAEXPAVUIElement@@KKH@Z
    }




    public unsafe struct ComponentTracker {
        public SpellComponentTable* spellComponentTable;
        public DLList<ComponentData>* componentLists_0;
        public DLList<ComponentData>* componentLists_1;
        public DLList<ComponentData>* componentLists_2;
        public DLList<ComponentData>* componentLists_3;
        public DLList<ComponentData>* componentLists_4;
        public DLList<ComponentData>* componentLists_5;
        public DLList<ComponentData>* componentLists_6;
        public HashTable<UInt32, UInt32> objectIDHash;
        public HashSet<UInt32> classIDHash;
        public override string ToString() => $"spellComponentTable:->(SpellComponentTable*)0x{(int)spellComponentTable:X8}, componentLists_0:{(int)componentLists_0:X8}, objectIDHash(HashTable<UInt32,UInt32,0>):{objectIDHash}, classIDHash(HashSet<UInt32 >):{classIDHash}";

        // Functions:

        // ComponentTracker.__Ctor:
        public void __Ctor(SpellComponentTable* _spellComponentTable) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, SpellComponentTable*, void>)0x005875A0)(ref this, _spellComponentTable); // .text:00586770 ; void __thiscall ComponentTracker::ComponentTracker(ComponentTracker *this, SpellComponentTable *_spellComponentTable) .text:00586770 ??0ComponentTracker@@QAE@PAVSpellComponentTable@@@Z

        // ComponentTracker.AddComponent:
        public void AddComponent(ACCWeenieObject* _weenObj) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, ACCWeenieObject*, void>)0x00587850)(ref this, _weenObj); // .text:00586A20 ; void __thiscall ComponentTracker::AddComponent(ComponentTracker *this, ACCWeenieObject *_weenObj) .text:00586A20 ?AddComponent@ComponentTracker@@AAEXPAVACCWeenieObject@@@Z

        // ComponentTracker.ComponentIsOwned:
        public int ComponentIsOwned(UInt32 _classID) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, UInt32, int>)0x005872B0)(ref this, _classID); // .text:00586480 ; int __thiscall ComponentTracker::ComponentIsOwned(ComponentTracker *this, IDClass<_tagDataID,32,0> _classID) .text:00586480 ?ComponentIsOwned@ComponentTracker@@QAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // ComponentTracker.DetermineComponentCategory:
        public SpellComponentCategory DetermineComponentCategory(UInt32 wcid) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, UInt32, SpellComponentCategory>)0x00586D80)(ref this, wcid); // .text:00585F50 ; SpellComponentCategory __thiscall ComponentTracker::DetermineComponentCategory(ComponentTracker *this, IDClass<_tagDataID,32,0> wcid) .text:00585F50 ?DetermineComponentCategory@ComponentTracker@@QAE?AW4SpellComponentCategory@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // ComponentTracker.GetCompNameFromWCID:
        public void GetCompNameFromWCID(UInt32 wcid, AC1Legacy.PStringBase<char>* name) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, UInt32, AC1Legacy.PStringBase<char>*, void>)0x00586EC0)(ref this, wcid, name); // .text:00586090 ; void __thiscall ComponentTracker::GetCompNameFromWCID(ComponentTracker *this, IDClass<_tagDataID,32,0> wcid, AC1Legacy::PStringBase<char> *name) .text:00586090 ?GetCompNameFromWCID@ComponentTracker@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAV?$PStringBase@D@AC1Legacy@@@Z

        // ComponentTracker.GetNumComponent:
        public void GetNumComponent(UInt32 wcid, int* num) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, UInt32, int*, void>)0x00586E10)(ref this, wcid, num); // .text:00585FE0 ; void __thiscall ComponentTracker::GetNumComponent(ComponentTracker *this, IDClass<_tagDataID,32,0> wcid, int *num) .text:00585FE0 ?GetNumComponent@ComponentTracker@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAJ@Z

        // ComponentTracker.InsertNewComponentData:
        public void InsertNewComponentData(ACCWeenieObject* _weenObj, DLList<ComponentData>* _list, ComponentData* _after) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, ACCWeenieObject*, DLList<ComponentData>*, ComponentData*, void>)0x005877F0)(ref this, _weenObj, _list, _after); // .text:005869C0 ; void __thiscall ComponentTracker::InsertNewComponentData(ComponentTracker *this, ACCWeenieObject *_weenObj, DLList<ComponentData> *_list, ComponentData *_after) .text:005869C0 ?InsertNewComponentData@ComponentTracker@@AAEXPAVACCWeenieObject@@PAV?$DLList@VComponentData@@@@PAVComponentData@@@Z

        // ComponentTracker.ObjectIsOwnedComponent:
        public int ObjectIsOwnedComponent(UInt32 _objectID, UInt32* _classID) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, UInt32, UInt32*, int>)0x00587010)(ref this, _objectID, _classID); // .text:005861E0 ; int __thiscall ComponentTracker::ObjectIsOwnedComponent(ComponentTracker *this, unsigned int _objectID, IDClass<_tagDataID,32,0> *_classID) .text:005861E0 ?ObjectIsOwnedComponent@ComponentTracker@@QAEHKAAV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // ComponentTracker.RemoveComponent:
        public void RemoveComponent(ACCWeenieObject* _weenObj) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, ACCWeenieObject*, void>)0x00587980)(ref this, _weenObj); // .text:00586B50 ; void __thiscall ComponentTracker::RemoveComponent(ComponentTracker *this, ACCWeenieObject *_weenObj) .text:00586B50 ?RemoveComponent@ComponentTracker@@AAEXPAVACCWeenieObject@@@Z

        // ComponentTracker.UpdateComponent:
        public void UpdateComponent(ACCWeenieObject* _weenObj, ComponentTrackerUpdate* _change) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, ACCWeenieObject*, ComponentTrackerUpdate*, void>)0x00587C10)(ref this, _weenObj, _change); // .text:00586DE0 ; void __thiscall ComponentTracker::UpdateComponent(ComponentTracker *this, ACCWeenieObject *_weenObj, ComponentTrackerUpdate *_change) .text:00586DE0 ?UpdateComponent@ComponentTracker@@QAEXPAVACCWeenieObject@@AAW4ComponentTrackerUpdate@@@Z

        // ComponentTracker.UpdateComponentStackSize:
        public void UpdateComponentStackSize(ACCWeenieObject* _weenObj, ComponentTrackerUpdate* _change) => ((delegate* unmanaged[Thiscall]<ref ComponentTracker, ACCWeenieObject*, ComponentTrackerUpdate*, void>)0x00587610)(ref this, _weenObj, _change); // .text:005867E0 ; void __thiscall ComponentTracker::UpdateComponentStackSize(ComponentTracker *this, ACCWeenieObject *_weenObj, ComponentTrackerUpdate *_change) .text:005867E0 ?UpdateComponentStackSize@ComponentTracker@@AAEXPAVACCWeenieObject@@AAW4ComponentTrackerUpdate@@@Z

    };
    public unsafe struct ComponentData {
        // Struct:
        public DLListData a0;
        public UInt32 classID;
        public AC1Legacy.PStringBase<char> componentName;
        public UInt32 componentIconID;
        public HashTable<UInt32, UInt32> objects;
        public UInt32 numItems;
        public override string ToString() => $"a0(DLListData):{a0}, classID:{classID:X8}, componentName:{componentName}, componentIconID:{componentIconID:X8}, objects(HashTable<UInt32,UInt32,0>):{objects}, numItems:{numItems:X8}";

        // Functions:

        // ComponentData.__Ctor:
        public void __Ctor(ACCWeenieObject* _weenObj) => ((delegate* unmanaged[Thiscall]<ref ComponentData, ACCWeenieObject*, void>)0x00587660)(ref this, _weenObj); // .text:00586830 ; void __thiscall ComponentData::ComponentData(ComponentData *this, ACCWeenieObject *_weenObj) .text:00586830 ??0ComponentData@@QAE@PAVACCWeenieObject@@@Z

        // ComponentData.AddItem:
        public void AddItem(ACCWeenieObject* _weenObj) => ((delegate* unmanaged[Thiscall]<ref ComponentData, ACCWeenieObject*, void>)0x00587440)(ref this, _weenObj); // .text:00586610 ; void __thiscall ComponentData::AddItem(ComponentData *this, ACCWeenieObject *_weenObj) .text:00586610 ?AddItem@ComponentData@@QAEXPAVACCWeenieObject@@@Z

        // ComponentData.GetFirstObjectID:
        public UInt32 GetFirstObjectID() => ((delegate* unmanaged[Thiscall]<ref ComponentData, UInt32>)0x00586D60)(ref this); // .text:00585F30 ; unsigned int __thiscall ComponentData::GetFirstObjectID(ComponentData *this) .text:00585F30 ?GetFirstObjectID@ComponentData@@QBEKXZ

        // ComponentData.RemoveItem:
        public void RemoveItem(ACCWeenieObject* _weenObj) => ((delegate* unmanaged[Thiscall]<ref ComponentData, ACCWeenieObject*, void>)0x005874B0)(ref this, _weenObj); // .text:00586680 ; void __thiscall ComponentData::RemoveItem(ComponentData *this, ACCWeenieObject *_weenObj) .text:00586680 ?RemoveItem@ComponentData@@QAEXPAVACCWeenieObject@@@Z

        // ComponentData.UpdateStackSize:
        public void UpdateStackSize(ACCWeenieObject* _weenObj, ComponentTrackerUpdate* _change) => ((delegate* unmanaged[Thiscall]<ref ComponentData, ACCWeenieObject*, ComponentTrackerUpdate*, void>)0x00587500)(ref this, _weenObj, _change); // .text:005866D0 ; void __thiscall ComponentData::UpdateStackSize(ComponentData *this, ACCWeenieObject *_weenObj, ComponentTrackerUpdate *_change) .text:005866D0 ?UpdateStackSize@ComponentData@@QAEXPAVACCWeenieObject@@AAW4ComponentTrackerUpdate@@@Z
    }
    public unsafe struct SpellComponentTable {
        // Struct:
        public SerializeUsingPackDBObj a0;
        public PackableHashTable<UInt32, SpellComponentBase> _spellComponentBaseHash;
        public override string ToString() => $"a0(SerializeUsingPackDBObj):{a0}, _spellComponentBaseHash(PackableHashTable<UInt32,SpellComponentBase>):{_spellComponentBaseHash}";

        // Functions:

        // SpellComponentTable.__Ctor:
        public void __Ctor(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref SpellComponentTable, UInt32, void>)0x005BD840)(ref this, did); // .text:005BC770 ; void __thiscall SpellComponentTable::SpellComponentTable(SpellComponentTable *this, IDClass<_tagDataID,32,0> did) .text:005BC770 ??0SpellComponentTable@@QAE@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // SpellComponentTable.Allocate:
        // (ERR) .text:005BD940 ; public: virtual class DBObj * __thiscall SpellComponentTable::Allocate(void)const .text:005BD940 ?Allocate@SpellComponentTable@@UBEPAVDBObj@@XZ

        // SpellComponentTable.Allocator:
        public static DBObj* Allocator() => ((delegate* unmanaged[Cdecl]<DBObj*>)0x0058B730)(); // .text:0058A900 ; DBObj *__cdecl SpellComponentTable::Allocator() .text:0058A900 ?Allocator@SpellComponentTable@@SAPAVDBObj@@XZ

        // SpellComponentTable.GetSubDataIDs:
        public void GetSubDataIDs(QualifiedDataIDArray* id_array) => ((delegate* unmanaged[Thiscall]<ref SpellComponentTable, QualifiedDataIDArray*, void>)0x005BD410)(ref this, id_array); // .text:005BC340 ; void __thiscall SpellComponentTable::GetSubDataIDs(SpellComponentTable *this, QualifiedDataIDArray *id_array) .text:005BC340 ?GetSubDataIDs@SpellComponentTable@@MBEXAAVQualifiedDataIDArray@@@Z

        // SpellComponentTable.GetTargetTypeFromComponentID:
        public static UInt32 GetTargetTypeFromComponentID(UInt32 scid) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32>)0x005BD070)(scid); // .text:005BBF50 ; unsigned int __cdecl SpellComponentTable::GetTargetTypeFromComponentID(const unsigned int scid) .text:005BBF50 ?GetTargetTypeFromComponentID@SpellComponentTable@@SAKK@Z

        // SpellComponentTable.InqSpellComponentBase:
        public int InqSpellComponentBase(UInt32 key, SpellComponentBase* sbase) => ((delegate* unmanaged[Thiscall]<ref SpellComponentTable, UInt32, SpellComponentBase*, int>)0x0048A1F0)(ref this, key, sbase); // .text:00489EC0 ; int __thiscall SpellComponentTable::InqSpellComponentBase(SpellComponentTable *this, const unsigned int key, SpellComponentBase *sbase) .text:00489EC0 ?InqSpellComponentBase@SpellComponentTable@@QAEHKAAVSpellComponentBase@@@Z

        // SpellComponentTable.SCIDtoWCID:
        public static UInt32* SCIDtoWCID(UInt32* result, UInt32 scid) => ((delegate* unmanaged[Cdecl]<UInt32*, UInt32, UInt32*>)0x005BD3C0)(result, scid); // .text:005BC2F0 ; IDClass<_tagDataID,32,0> *__cdecl SpellComponentTable::SCIDtoWCID(IDClass<_tagDataID,32,0> *result, const unsigned int scid) .text:005BC2F0 ?SCIDtoWCID@SpellComponentTable@@SA?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // SpellComponentTable.SchoolOfMagic2WCID:
        public static UInt32* SchoolOfMagic2WCID(UInt32* result, UInt32 scid) => ((delegate* unmanaged[Cdecl]<UInt32*, UInt32, UInt32*>)0x005BD2C0)(result, scid); // .text:005BC1F0 ; IDClass<_tagDataID,32,0> *__cdecl SpellComponentTable::SchoolOfMagic2WCID(IDClass<_tagDataID,32,0> *result, unsigned int scid) .text:005BC1F0 ?SchoolOfMagic2WCID@SpellComponentTable@@SA?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // SpellComponentTable.WCIDtoSCID:
        public static UInt32 WCIDtoSCID(UInt32 wcid) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32>)0x005BD310)(wcid); // .text:005BC240 ; unsigned int __cdecl SpellComponentTable::WCIDtoSCID(IDClass<_tagDataID,32,0> wcid) .text:005BC240 ?WCIDtoSCID@SpellComponentTable@@SAKV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z
    }
    public unsafe struct SpellComponentBase {
        // Struct:
        public PackObj a0;
        public AC1Legacy.PStringBase<char> _name;
        public SpellComponentCategory _category;
        public UInt32 _iconID;
        public SpellComponentType _type;
        public UInt32 _gesture;
        public Single _time;
        public AC1Legacy.PStringBase<char> _text;
        public Single _CDM;
        public override string ToString() => $"a0(PackObj):{a0}, _name:{_name}, _category(SpellComponentCategory):{_category}, _iconID:{_iconID:X8}, _type(SpellComponentType):{_type}, _gesture:{_gesture:X8}, _time:{_time:n5}, _text:{_text}, _CDM:{_CDM:n5}";

        // Functions:

        // SpellComponentBase.__Ctor:
        public void __Ctor(SpellComponentBase* __that) => ((delegate* unmanaged[Thiscall]<ref SpellComponentBase, SpellComponentBase*, void>)0x005BD360)(ref this, __that); // .text:005BC290 ; void __thiscall SpellComponentBase::SpellComponentBase(SpellComponentBase *this, SpellComponentBase *__that) .text:005BC290 ??0SpellComponentBase@@QAE@ABV0@@Z

        // SpellComponentBase.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref SpellComponentBase, void>)0xDEADBEEF)(ref this); // .text:00489BB0 ; void __thiscall SpellComponentBase::SpellComponentBase(SpellComponentBase *this) .text:00489BB0 ??0SpellComponentBase@@QAE@XZ

        // SpellComponentBase.operator_equals:
        // public SpellComponentBase* operator_equals() => ((delegate* unmanaged[Thiscall]<ref SpellComponentBase, SpellComponentBase*>)0xDEADBEEF)(ref this); // .text:00489E20 ; public: class SpellComponentBase & __thiscall SpellComponentBase::operator=(class SpellComponentBase const &) .text:00489E20 ??4SpellComponentBase@@QAEAAV0@ABV0@@Z

        // SpellComponentBase.Init:
        public void Init() => ((delegate* unmanaged[Thiscall]<ref SpellComponentBase, void>)0x005BCF60)(ref this); // .text:005BBDD0 ; void __thiscall SpellComponentBase::Init(SpellComponentBase *this) .text:005BBDD0 ?Init@SpellComponentBase@@QAEXXZ

        // SpellComponentBase.InqName:
        public AC1Legacy.PStringBase<char>* InqName(AC1Legacy.PStringBase<char>* result) => ((delegate* unmanaged[Thiscall]<ref SpellComponentBase, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*>)0x00597D40)(ref this, result); // .text:005BBEE0 ; AC1Legacy::PStringBase<char> *__thiscall SpellComponentBase::InqName(SpellComponentBase *this, AC1Legacy::PStringBase<char> *result) .text:005BBEE0 ?InqName@SpellComponentBase@@QBE?AV?$PStringBase@D@AC1Legacy@@XZ

        // SpellComponentBase.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellComponentBase, void**, UInt32, UInt32>)0x005BCEB0)(ref this, addr, size); // .text:005BBD20 ; unsigned int __thiscall SpellComponentBase::Pack(SpellComponentBase *this, void **addr, unsigned int size) .text:005BBD20 ?Pack@SpellComponentBase@@UAEIAAPAXI@Z

        // SpellComponentBase.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SpellComponentBase, void**, UInt32, int>)0x005BCFA0)(ref this, addr, size); // .text:005BBE10 ; int __thiscall SpellComponentBase::UnPack(SpellComponentBase *this, void **addr, unsigned int size) .text:005BBE10 ?UnPack@SpellComponentBase@@UAEHAAPAXI@Z
    }



}