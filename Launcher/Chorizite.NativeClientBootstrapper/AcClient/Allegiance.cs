//go run parse.go full AllegianceRankData:AllegianceData:AllegianceNode:AllegianceHierarchy:AllegianceProfile:AllegianceAppraisalProfile:CAllegianceProfile:CAllegianceHierarchy:CAllegianceData:CAllegianceNode:ClientAllegianceSystem:gmAllegianceUI:AllegianceSystem

using System;
//go run parse.go full AllegianceSystem
namespace AcClient {
    public unsafe struct AllegianceRankData {
        // Struct:
        public PackObj a0;
        public UInt32 _id;
        public UInt32 _rank;
        public override string ToString() => $"_id:{_id:X8}, _rank:{_rank:X8}";
    }
    public unsafe struct AllegianceData {
        // Struct:
        public PackObj a0;
        public UInt32 _id;
        public AC1Legacy.PStringBase<char> _name;
        public UInt32 _gender;
        public UInt32 _hg;
        public UInt32 _rank;
        public UInt32 _level;
        public UInt32 _bitfield;
        public UInt32 _cp_tithed;
        public UInt32 _cp_cached;
        public UInt32 _loyalty;
        public UInt32 _leadership;
        public int _time_online;
        public int _allegiance_age;
        public override string ToString() => $"_id:{_id:X8}, _name:{_name}, _gender:{_gender}, _hg:{_hg}, _rank:{_rank}, _level:{_level}, _bitfield:{_bitfield:X8}, _cp_tithed:{_cp_tithed}, _cp_cached:{_cp_cached}, _loyalty:{_loyalty}, _leadership:{_leadership}, _time_online:{_time_online}, _allegiance_age:{_allegiance_age}";

        // Functions:

        // AllegianceData.__Ctor:
        public void __Ctor(AllegianceData* rhs) => ((delegate* unmanaged[Thiscall]<ref AllegianceData, AllegianceData*, void>)0x005B78E0)(ref this, rhs); // .text:005B67F0 ; void __thiscall AllegianceData::AllegianceData(AllegianceData *this, AllegianceData *rhs) .text:005B67F0 ??0AllegianceData@@QAE@ABV0@@Z

        // AllegianceData.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref AllegianceData, void>)0x005B7670)(ref this); // .text:005B6580 ; void __thiscall AllegianceData::AllegianceData(AllegianceData *this) .text:005B6580 ??0AllegianceData@@QAE@XZ

        // AllegianceData.operator_equals:
        public AllegianceData* operator_equals() => ((delegate* unmanaged[Thiscall]<ref AllegianceData, AllegianceData*>)0x005B7740)(ref this); // .text:005B6650 ; public: class AllegianceData & __thiscall AllegianceData::operator=(class AllegianceData const &) .text:005B6650 ??4AllegianceData@@QAEAAV0@ABV0@@Z

        // AllegianceData.GetFullName:
        public int GetFullName(AC1Legacy.PStringBase<char>* name) => ((delegate* unmanaged[Thiscall]<ref AllegianceData, AC1Legacy.PStringBase<char>*, int>)0x005B7A40)(ref this, name); // .text:005B6950 ; int __thiscall AllegianceData::GetFullName(AllegianceData *this, AC1Legacy::PStringBase<char> *name) .text:005B6950 ?GetFullName@AllegianceData@@QBEHAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceData.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref AllegianceData, UInt32>)0x005B77E0)(ref this); // .text:005B66F0 ; unsigned int __thiscall AllegianceData::GetPackSize(AllegianceData *this) .text:005B66F0 ?GetPackSize@AllegianceData@@UAEIXZ

        // AllegianceData.GetTitle:
        public int GetTitle(AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Thiscall]<ref AllegianceData, AC1Legacy.PStringBase<char>*, int>)0x005B7620)(ref this, title); // .text:005B6530 ; int __thiscall AllegianceData::GetTitle(AllegianceData *this, AC1Legacy::PStringBase<char> *title) .text:005B6530 ?GetTitle@AllegianceData@@QBEHAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceData.IsLoggedIn:
        public int IsLoggedIn() => ((delegate* unmanaged[Thiscall]<ref AllegianceData, int>)0x005B7640)(ref this); // .text:005B6550 ; int __thiscall AllegianceData::IsLoggedIn(AllegianceData *this) .text:005B6550 ?IsLoggedIn@AllegianceData@@QBEHXZ

        // AllegianceData.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AllegianceData, void**, UInt32, UInt32>)0x005B7800)(ref this, addr, size); // .text:005B6710 ; unsigned int __thiscall AllegianceData::Pack(AllegianceData *this, void **addr, unsigned int size) .text:005B6710 ?Pack@AllegianceData@@UAEIAAPAXI@Z

        // AllegianceData.SetMayPassupExperience:
        public void SetMayPassupExperience(int bMayPassupExperience) => ((delegate* unmanaged[Thiscall]<ref AllegianceData, int, void>)0x005B7650)(ref this, bMayPassupExperience); // .text:005B6560 ; void __thiscall AllegianceData::SetMayPassupExperience(AllegianceData *this, int bMayPassupExperience) .text:005B6560 ?SetMayPassupExperience@AllegianceData@@QAEXH@Z

        // AllegianceData.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AllegianceData, void**, UInt32, int>)0x005B7940)(ref this, addr, size); // .text:005B6850 ; int __thiscall AllegianceData::UnPack(AllegianceData *this, void **addr, unsigned int size) .text:005B6850 ?UnPack@AllegianceData@@UAEHAAPAXI@Z
    }
    public unsafe struct AllegianceNode {
        // Struct:
        public PackObj a0;
        public AllegianceNode* _patron;
        public AllegianceNode* _peer;
        public AllegianceNode* _vassal;
        public AllegianceData _data;
        public override string ToString() => $"_patron:->(AllegianceNode*)0x{(int)_patron:X8}, _peer:->(AllegianceNode*)0x{(int)_peer:X8}, _vassal:->(AllegianceNode*)0x{(int)_vassal:X8}, _data(AllegianceData):{_data}";

        // Functions:

        // AllegianceNode.__Ctor:
        public void __Ctor(AllegianceData* data) => ((delegate* unmanaged[Thiscall]<ref AllegianceNode, AllegianceData*, void>)0x005BA150)(ref this, data); // .text:005B9010 ; void __thiscall AllegianceNode::AllegianceNode(AllegianceNode *this, AllegianceData *data) .text:005B9010 ??0AllegianceNode@@QAE@ABVAllegianceData@@@Z

        // AllegianceNode.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AllegianceNode, void**, UInt32, UInt32>)0x005BA130)(ref this, addr, size); // .text:005B8FF0 ; unsigned int __thiscall AllegianceNode::Pack(AllegianceNode *this, void **addr, unsigned int size) .text:005B8FF0 ?Pack@AllegianceNode@@UAEIAAPAXI@Z

        // AllegianceNode.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AllegianceNode, void**, UInt32, int>)0x005BA140)(ref this, addr, size); // .text:005B9000 ; int __thiscall AllegianceNode::UnPack(AllegianceNode *this, void **addr, unsigned int size) .text:005B9000 ?UnPack@AllegianceNode@@UAEHAAPAXI@Z
    }
    public unsafe struct AllegianceHierarchy {
        // Struct:
        public PackObj a0;
        public AllegianceVersion m_oldVersion;
        public AllegianceNode* m_pMonarch;
        public UInt32 m_total;
        public int m_monarchBroadcastTime;
        public int m_spokesBroadcastTime;
        public UInt32 m_monarchBroadcastsToday;
        public UInt32 m_spokesBroadcastsToday;
        public AC1Legacy.PStringBase<char> m_motd;
        public AC1Legacy.PStringBase<char> m_motdSetBy;
        public AC1Legacy.PStringBase<char> m_AllegianceName;
        public int m_NameLastSetTime;
        public UInt32 m_chatRoomID;
        public PHashTable<UInt32, UInt32> m_AllegianceOfficers;
        public PSmartArray<AC1Legacy.PStringBase<char>> m_OfficerTitles;
        public Position m_BindPoint;
        public int m_isLocked;
        public UInt32 m_ApprovedVassal;
        public override string ToString() => $"m_oldVersion:{m_oldVersion}, m_pMonarch:->(AllegianceNode*)0x{(int)m_pMonarch:X8}, m_total:{m_total:X8}, m_monarchBroadcastTime(int):{m_monarchBroadcastTime}, m_spokesBroadcastTime:{m_spokesBroadcastTime}, m_monarchBroadcastsToday:{m_monarchBroadcastsToday}, m_spokesBroadcastsToday:{m_spokesBroadcastsToday}, m_motd:{m_motd}, m_motdSetBy:{m_motdSetBy}, m_AllegianceName:{m_AllegianceName}, m_NameLastSetTime(int):{m_NameLastSetTime}, m_chatRoomID:{m_chatRoomID:X8}, m_AllegianceOfficers(PHashTable<UInt32,UInt32>):{m_AllegianceOfficers}, m_OfficerTitles(PSmartArray<AC1Legacy.PStringBase<char>>):{m_OfficerTitles}, m_BindPoint(Position):{m_BindPoint}, m_isLocked(int):{m_isLocked}, m_ApprovedVassal:{m_ApprovedVassal:X8}";

        // Functions:

        // AllegianceHierarchy.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, void>)0xDEADBEEF)(ref this); // .text:005B77F0 ; void __thiscall AllegianceHierarchy::AllegianceHierarchy(AllegianceHierarchy *this) .text:005B77F0 ??0AllegianceHierarchy@@QAE@XZ

        // AllegianceHierarchy.operator_equals:
        public int operator_equals(int a1) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, int, int>)0x005B8AD0)(ref this, a1); // .text:005B7990 ; int __thiscall AllegianceHierarchy::operator=(AllegianceHierarchy *this, int) .text:005B7990 ??4AllegianceHierarchy@@QAEAAV0@ABV0@@Z

        // AllegianceHierarchy.Add:
        public int Add(UInt32 patron, AllegianceData* new_data) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, UInt32, AllegianceData*, int>)0x005B7FD0)(ref this, patron, new_data); // .text:005B6E90 ; int __thiscall AllegianceHierarchy::Add(AllegianceHierarchy *this, const unsigned int patron, AllegianceData *new_data) .text:005B6E90 ?Add@AllegianceHierarchy@@QAEHKABVAllegianceData@@@Z

        // AllegianceHierarchy.Clear:
        // public void Clear(AllegianceNode** node) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, AllegianceNode**, void>)0xDEADBEEF)(ref this, node); // .text:005B6C20 ; void __thiscall AllegianceHierarchy::Clear(AllegianceHierarchy *this, AllegianceNode **node) .text:005B6C20 ?Clear@AllegianceHierarchy@@IAEXAAPAVAllegianceNode@@@Z

        // AllegianceHierarchy.Clear:
        public void Clear() => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, void>)0x005B8550)(ref this); // .text:005B7410 ; void __thiscall AllegianceHierarchy::Clear(AllegianceHierarchy *this) .text:005B7410 ?Clear@AllegianceHierarchy@@QAEXXZ

        // AllegianceHierarchy.Copy:
        // public int Copy(AllegianceNode* node, int copy_node) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, AllegianceNode*, int, int>)0xDEADBEEF)(ref this, node, copy_node); // .text:005B6F50 ; int __thiscall AllegianceHierarchy::Copy(AllegianceHierarchy *this, AllegianceNode *node, int copy_node) .text:005B6F50 ?Copy@AllegianceHierarchy@@IAEHPAVAllegianceNode@@H@Z

        // AllegianceHierarchy.GetFirstVassal:
        public UInt32 GetFirstVassal(UInt32 id, AllegianceData* retval) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, UInt32, AllegianceData*, UInt32>)0x005B7F00)(ref this, id, retval); // .text:005B6E10 ; unsigned int __thiscall AllegianceHierarchy::GetFirstVassal(AllegianceHierarchy *this, unsigned int id, AllegianceData *retval) .text:005B6E10 ?GetFirstVassal@AllegianceHierarchy@@QBEKKAAVAllegianceData@@@Z

        // AllegianceHierarchy.GetMonarchID:
        public UInt32 GetMonarchID() => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, UInt32>)0x005B7E10)(ref this); // .text:005B6D20 ; unsigned int __thiscall AllegianceHierarchy::GetMonarchID(AllegianceHierarchy *this) .text:005B6D20 ?GetMonarchID@AllegianceHierarchy@@QBEKXZ

        // AllegianceHierarchy.GetNextVassal:
        public UInt32 GetNextVassal(UInt32 vassal_id, AllegianceData* retval) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, UInt32, AllegianceData*, UInt32>)0x005B7F40)(ref this, vassal_id, retval); // .text:005B6E50 ; unsigned int __thiscall AllegianceHierarchy::GetNextVassal(AllegianceHierarchy *this, unsigned int vassal_id, AllegianceData *retval) .text:005B6E50 ?GetNextVassal@AllegianceHierarchy@@QBEKKAAVAllegianceData@@@Z

        // AllegianceHierarchy.GetNodePackSize:
        // public UInt32 GetNodePackSize(AllegianceNode* node) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, AllegianceNode*, UInt32>)0xDEADBEEF)(ref this, node); // .text:005B6C80 ; unsigned int __thiscall AllegianceHierarchy::GetNodePackSize(AllegianceHierarchy *this, AllegianceNode *node) .text:005B6C80 ?GetNodePackSize@AllegianceHierarchy@@IAEIPAVAllegianceNode@@@Z

        // AllegianceHierarchy.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, UInt32>)0x005B8100)(ref this); // .text:005B6FC0 ; unsigned int __thiscall AllegianceHierarchy::GetPackSize(AllegianceHierarchy *this) .text:005B6FC0 ?GetPackSize@AllegianceHierarchy@@UAEIXZ

        // AllegianceHierarchy.GetPatron:
        public UInt32 GetPatron(UInt32 id, AllegianceData* retval) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, UInt32, AllegianceData*, UInt32>)0x005B7EC0)(ref this, id, retval); // .text:005B6DD0 ; unsigned int __thiscall AllegianceHierarchy::GetPatron(AllegianceHierarchy *this, const unsigned int id, AllegianceData *retval) .text:005B6DD0 ?GetPatron@AllegianceHierarchy@@QBEKKAAVAllegianceData@@@Z

        // AllegianceHierarchy.LookUp:
        public int LookUp(UInt32 id, AllegianceData* retval) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, UInt32, AllegianceData*, int>)0x005B7E90)(ref this, id, retval); // .text:005B6DA0 ; int __thiscall AllegianceHierarchy::LookUp(AllegianceHierarchy *this, const unsigned int id, AllegianceData *retval) .text:005B6DA0 ?LookUp@AllegianceHierarchy@@QBEHKAAVAllegianceData@@@Z

        // AllegianceHierarchy.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, void**, UInt32, UInt32>)0x005B81A0)(ref this, addr, size); // .text:005B7060 ; unsigned int __thiscall AllegianceHierarchy::Pack(AllegianceHierarchy *this, void **addr, unsigned int size) .text:005B7060 ?Pack@AllegianceHierarchy@@UAEIAAPAXI@Z

        // AllegianceHierarchy.PackNode:
        public UInt32 PackNode(AllegianceNode* node, void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, AllegianceNode*, void**, UInt32, UInt32>)0x005B7E20)(ref this, node, addr, size); // .text:005B6D30 ; unsigned int __thiscall AllegianceHierarchy::PackNode(AllegianceHierarchy *this, AllegianceNode *node, void **addr, unsigned int size) .text:005B6D30 ?PackNode@AllegianceHierarchy@@IAEIPAVAllegianceNode@@AAPAXI@Z

        // AllegianceHierarchy.Search:
        public AllegianceNode* Search(UInt32 id, AllegianceNode* node) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, UInt32, AllegianceNode*, AllegianceNode*>)0x005B7DD0)(ref this, id, node); // .text:005B6CE0 ; AllegianceNode *__thiscall AllegianceHierarchy::Search(AllegianceHierarchy *this, const unsigned int id, AllegianceNode *node) .text:005B6CE0 ?Search@AllegianceHierarchy@@IAEPAVAllegianceNode@@KPAV2@@Z

        // AllegianceHierarchy.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AllegianceHierarchy, void**, UInt32, int>)0x005B8660)(ref this, addr, size); // .text:005B7520 ; int __thiscall AllegianceHierarchy::UnPack(AllegianceHierarchy *this, void **addr, unsigned int size) .text:005B7520 ?UnPack@AllegianceHierarchy@@UAEHAAPAXI@Z
    }
    public unsafe struct AllegianceProfile {
        // Struct:
        public PackObj a0;
        public AllegianceHierarchy _allegiance;
        public UInt32 _total_members;
        public UInt32 _total_vassals;
        public override string ToString() => $"_allegiance(AllegianceHierarchy):{_allegiance}, _total_members:{_total_members:X8}, _total_vassals:{_total_vassals:X8}";

        // Functions:

        // AllegianceProfile.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, void>)0xDEADBEEF)(ref this); // .text:005B6B10 ; void __thiscall AllegianceProfile::AllegianceProfile(AllegianceProfile *this) .text:005B6B10 ??0AllegianceProfile@@QAE@XZ

        // AllegianceProfile.operator_equals:
        public AllegianceProfile* operator_equals() => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, AllegianceProfile*>)0x005B7B10)(ref this); // .text:005B6A20 ; public: class AllegianceProfile & __thiscall AllegianceProfile::operator=(class AllegianceProfile const &) .text:005B6A20 ??4AllegianceProfile@@QAEAAV0@ABV0@@Z

        // AllegianceProfile.Clear:
        public void Clear() => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, void>)0x005B7B50)(ref this); // .text:005B6A60 ; void __thiscall AllegianceProfile::Clear(AllegianceProfile *this) .text:005B6A60 ?Clear@AllegianceProfile@@QAEXXZ

        // AllegianceProfile.GetData:
        public int GetData(UInt32 id, AllegianceData* retval) => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, UInt32, AllegianceData*, int>)0x005B7BD0)(ref this, id, retval); // .text:005B6AE0 ; int __thiscall AllegianceProfile::GetData(AllegianceProfile *this, unsigned int id, AllegianceData *retval) .text:005B6AE0 ?GetData@AllegianceProfile@@QBEHKAAVAllegianceData@@@Z

        // AllegianceProfile.GetFirstVassal:
        public UInt32 GetFirstVassal(UInt32 id, AllegianceData* retval) => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, UInt32, AllegianceData*, UInt32>)0x005B7BB0)(ref this, id, retval); // .text:005B6AC0 ; unsigned int __thiscall AllegianceProfile::GetFirstVassal(AllegianceProfile *this, unsigned int id, AllegianceData *retval) .text:005B6AC0 ?GetFirstVassal@AllegianceProfile@@QBEKKAAVAllegianceData@@@Z

        // AllegianceProfile.GetMonarch:
        public UInt32 GetMonarch(AllegianceData* retval) => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, AllegianceData*, UInt32>)0x005B7B70)(ref this, retval); // .text:005B6A80 ; unsigned int __thiscall AllegianceProfile::GetMonarch(AllegianceProfile *this, AllegianceData *retval) .text:005B6A80 ?GetMonarch@AllegianceProfile@@QBEKAAVAllegianceData@@@Z

        // AllegianceProfile.GetNextVassal:
        public UInt32 GetNextVassal(UInt32 vassal_id, AllegianceData* retval) => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, UInt32, AllegianceData*, UInt32>)0x005B7BC0)(ref this, vassal_id, retval); // .text:005B6AD0 ; unsigned int __thiscall AllegianceProfile::GetNextVassal(AllegianceProfile *this, unsigned int vassal_id, AllegianceData *retval) .text:005B6AD0 ?GetNextVassal@AllegianceProfile@@QBEKKAAVAllegianceData@@@Z

        // AllegianceProfile.GetPackSize:
        // public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, UInt32>)0xDEADBEEF)(ref this); // .text:005B6AF0 ; unsigned int __thiscall AllegianceProfile::GetPackSize(AllegianceProfile *this) .text:005B6AF0 ?GetPackSize@AllegianceProfile@@MAEIXZ

        // AllegianceProfile.GetPatron:
        public UInt32 GetPatron(UInt32 id, AllegianceData* retval) => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, UInt32, AllegianceData*, UInt32>)0x005B7BA0)(ref this, id, retval); // .text:005B6AB0 ; unsigned int __thiscall AllegianceProfile::GetPatron(AllegianceProfile *this, unsigned int id, AllegianceData *retval) .text:005B6AB0 ?GetPatron@AllegianceProfile@@QBEKKAAVAllegianceData@@@Z

        // AllegianceProfile.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005B6B40 ; unsigned int __thiscall AllegianceProfile::Pack(AllegianceProfile *this, void **addr, unsigned int size) .text:005B6B40 ?Pack@AllegianceProfile@@UAEIAAPAXI@Z

        // AllegianceProfile.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AllegianceProfile, void**, UInt32, int>)0x005B7C80)(ref this, addr, size); // .text:005B6B90 ; int __thiscall AllegianceProfile::UnPack(AllegianceProfile *this, void **addr, unsigned int size) .text:005B6B90 ?UnPack@AllegianceProfile@@UAEHAAPAXI@Z
    }
    public unsafe struct AllegianceAppraisalProfile {
        // Struct:
        public PackObj a0;
        public AC1Legacy.PStringBase<char> m_AllegianceName;
        public AC1Legacy.PStringBase<char> _mtitle;
        public AC1Legacy.PStringBase<char> _ptitle;
        public int _followers;
        public override string ToString() => $"m_AllegianceName:{m_AllegianceName}, _mtitle:{_mtitle}, _ptitle:{_ptitle}, _followers(int):{_followers}";
    }
    public unsafe struct CAllegianceProfile {
        // Struct:
        public AllegianceProfile a0;
        public override string ToString() => a0.ToString();

        // Functions:

        // CAllegianceProfile.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CAllegianceProfile, void>)0x0059A080)(ref this); // .text:005990E0 ; void __thiscall CAllegianceProfile::CAllegianceProfile(CAllegianceProfile *this) .text:005990E0 ??0CAllegianceProfile@@QAE@XZ
    }
    public unsafe struct CAllegianceHierarchy {
        // Struct:
        public AllegianceHierarchy a0;
        public override string ToString() => a0.ToString();
    }
    public unsafe struct CAllegianceData {
        // Struct:
        public AllegianceData a0;
        public override string ToString() => a0.ToString();

        // Functions:

        // CAllegianceData.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CAllegianceData, void>)0x0059A040)(ref this); // .text:005990A0 ; void __thiscall CAllegianceData::CAllegianceData(CAllegianceData *this) .text:005990A0 ??0CAllegianceData@@QAE@XZ
    }
    public unsafe struct CAllegianceNode {
        // Struct:
        public AllegianceNode a0;
        public override string ToString() => a0.ToString();
    }
    public unsafe struct ClientAllegianceSystem {
        // Struct:
        public ClientSystem a0;
        public Turbine_RefCount m_cTurbineRefCount;
        public CAllegianceProfile m_allegianceProfile;
        public override string ToString() => $"a0(ClientSystem):{a0}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, m_allegianceProfile(CAllegianceProfile):{m_allegianceProfile}";

        // Functions:

        // ClientAllegianceSystem.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ClientAllegianceSystem, void>)0x0056AEF0)(ref this); // .text:0056A150 ; void __thiscall ClientAllegianceSystem::ClientAllegianceSystem(ClientAllegianceSystem *this) .text:0056A150 ??0ClientAllegianceSystem@@QAE@XZ

        // ClientAllegianceSystem.GetAllegianceSystem:
        public static ClientAllegianceSystem* GetAllegianceSystem() => ((delegate* unmanaged[Cdecl]<ClientAllegianceSystem*>)0x0056AD30)(); // .text:00569F90 ; ClientAllegianceSystem *__cdecl ClientAllegianceSystem::GetAllegianceSystem() .text:00569F90 ?GetAllegianceSystem@ClientAllegianceSystem@@SAPAV1@XZ

        // ClientAllegianceSystem.Handle_Allegiance__AllegianceInfoResponseEvent:
        public UInt32 Handle_Allegiance__AllegianceInfoResponseEvent(UInt32 target, CAllegianceProfile* prof) => ((delegate* unmanaged[Thiscall]<ref ClientAllegianceSystem, UInt32, CAllegianceProfile*, UInt32>)0x0056AF70)(ref this, target, prof); // .text:0056A1D0 ; unsigned int __thiscall ClientAllegianceSystem::Handle_Allegiance__AllegianceInfoResponseEvent(ClientAllegianceSystem *this, unsigned int target, CAllegianceProfile *prof) .text:0056A1D0 ?Handle_Allegiance__AllegianceInfoResponseEvent@ClientAllegianceSystem@@QAEKKABVCAllegianceProfile@@@Z

        // ClientAllegianceSystem.Handle_Allegiance__AllegianceLoginNotificationEvent:
        public UInt32 Handle_Allegiance__AllegianceLoginNotificationEvent(UInt32 member, int bNowLoggedIn) => ((delegate* unmanaged[Thiscall]<ref ClientAllegianceSystem, UInt32, int, UInt32>)0x0056AD90)(ref this, member, bNowLoggedIn); // .text:00569FF0 ; unsigned int __thiscall ClientAllegianceSystem::Handle_Allegiance__AllegianceLoginNotificationEvent(ClientAllegianceSystem *this, unsigned int member, int bNowLoggedIn) .text:00569FF0 ?Handle_Allegiance__AllegianceLoginNotificationEvent@ClientAllegianceSystem@@QAEKKH@Z

        // ClientAllegianceSystem.Handle_Allegiance__AllegianceUpdate:
        public UInt32 Handle_Allegiance__AllegianceUpdate(CAllegianceProfile* prof, UInt32 rank) => ((delegate* unmanaged[Thiscall]<ref ClientAllegianceSystem, CAllegianceProfile*, UInt32, UInt32>)0x0056AEC0)(ref this, prof, rank); // .text:0056A120 ; unsigned int __thiscall ClientAllegianceSystem::Handle_Allegiance__AllegianceUpdate(ClientAllegianceSystem *this, CAllegianceProfile *prof, unsigned int rank) .text:0056A120 ?Handle_Allegiance__AllegianceUpdate@ClientAllegianceSystem@@QAEKABVCAllegianceProfile@@K@Z

        // ClientAllegianceSystem.Handle_Allegiance__AllegianceUpdateAborted:
        public UInt32 Handle_Allegiance__AllegianceUpdateAborted(UInt32 etype) => ((delegate* unmanaged[Thiscall]<ref ClientAllegianceSystem, UInt32, UInt32>)0x0056AD70)(ref this, etype); // .text:00569FD0 ; unsigned int __thiscall ClientAllegianceSystem::Handle_Allegiance__AllegianceUpdateAborted(ClientAllegianceSystem *this, const unsigned int etype) .text:00569FD0 ?Handle_Allegiance__AllegianceUpdateAborted@ClientAllegianceSystem@@QAEKK@Z

        // ClientAllegianceSystem.OnEndCharacterSession:
        public void OnEndCharacterSession() => ((delegate* unmanaged[Thiscall]<ref ClientAllegianceSystem, void>)0x0056AD40)(ref this); // .text:00569FA0 ; void __thiscall ClientAllegianceSystem::OnEndCharacterSession(ClientAllegianceSystem *this) .text:00569FA0 ?OnEndCharacterSession@ClientAllegianceSystem@@MAEXXZ

        // ClientAllegianceSystem.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref ClientAllegianceSystem, void>)0x0056AD50)(ref this); // .text:00569FB0 ; void __thiscall ClientAllegianceSystem::OnShutdown(ClientAllegianceSystem *this) .text:00569FB0 ?OnShutdown@ClientAllegianceSystem@@MAEXXZ

        // ClientAllegianceSystem.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref ClientAllegianceSystem, TResult*, Turbine_GUID*, void**, TResult*>)0x0056ADF0)(ref this, result, i_rcInterface, o_ppvInterface); // .text:0056A050 ; TResult *__thiscall ClientAllegianceSystem::QueryInterface(ClientAllegianceSystem *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:0056A050 ?QueryInterface@ClientAllegianceSystem@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // ClientAllegianceSystem.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref ClientAllegianceSystem, UInt32>)0x0056AF40)(ref this); // .text:0056A1A0 ; unsigned int __thiscall ClientAllegianceSystem::Release(ClientAllegianceSystem *this) .text:0056A1A0 ?Release@ClientAllegianceSystem@@UBEKXZ

        // Globals:
        public static ClientAllegianceSystem* s_pAllegianceSystem = *(ClientAllegianceSystem**)0x008715BC; // .data:008705AC ; ClientAllegianceSystem *ClientAllegianceSystem::s_pAllegianceSystem .data:008705AC ?s_pAllegianceSystem@ClientAllegianceSystem@@1PAV1@A
    }


    /// <summary>
    /// gmAllegianceUI* mine = (gmAllegianceUI*)GlobalEventHandler.geh->ResolveHandler(5100037);
    /// </summary>
    public unsafe struct gmAllegianceUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public QualityChangeHandler a2;
        public Byte m_bAwaitingUpdate;
        public UInt32 m_iidSelectedVassal;
        public UInt32 m_iidPossibleNewPatron;
        public UInt32 m_iidPossibleKickedVassal;
        public UInt32 m_uiAcceptSwearServerContextID;
        public UIElement_Text* m_pAllegianceName;
        public UIElement_Text* m_pPlayerFollowers;
        public UIElement_Text* m_pPlayerRank;
        public UIElement* m_pMonarchField;
        public UIElement_Text* m_pMonarchLabel;
        public UIElement_Text* m_pMonarchName;
        public UIElement_Text* m_pMonarchFollowers;
        public UIElement* m_pPatronField;
        public UIElement_Text* m_pPatronName;
        public UIElement_ListBox* m_pVassalListBox;
        public UIElement_Button* m_pSwearButton;
        public UIElement_Button* m_pBreakButton;
        public UIElement_Button* m_pKickButton;
        public UInt32 m_swearContext;
        public UInt32 m_acceptSwearContext;
        public UInt32 m_breakContext;
        public UInt32 m_kickContext;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, a2(QualityChangeHandler):{a2}, m_bAwaitingUpdate:{m_bAwaitingUpdate:X2}, m_iidSelectedVassal:{m_iidSelectedVassal:X8}, m_iidPossibleNewPatron:{m_iidPossibleNewPatron:X8}, m_iidPossibleKickedVassal:{m_iidPossibleKickedVassal:X8}, m_uiAcceptSwearServerContextID:{m_uiAcceptSwearServerContextID:X8}, m_pAllegianceName:->(UIElement_Text*)0x{(int)m_pAllegianceName:X8}, m_pPlayerFollowers:->(UIElement_Text*)0x{(int)m_pPlayerFollowers:X8}, m_pPlayerRank:->(UIElement_Text*)0x{(int)m_pPlayerRank:X8}, m_pMonarchField:->(UIElement*)0x{(int)m_pMonarchField:X8}, m_pMonarchLabel:->(UIElement_Text*)0x{(int)m_pMonarchLabel:X8}, m_pMonarchName:->(UIElement_Text*)0x{(int)m_pMonarchName:X8}, m_pMonarchFollowers:->(UIElement_Text*)0x{(int)m_pMonarchFollowers:X8}, m_pPatronField:->(UIElement*)0x{(int)m_pPatronField:X8}, m_pPatronName:->(UIElement_Text*)0x{(int)m_pPatronName:X8}, m_pVassalListBox:->(UIElement_ListBox*)0x{(int)m_pVassalListBox:X8}, m_pSwearButton:->(UIElement_Button*)0x{(int)m_pSwearButton:X8}, m_pBreakButton:->(UIElement_Button*)0x{(int)m_pBreakButton:X8}, m_pKickButton:->(UIElement_Button*)0x{(int)m_pKickButton:X8}, m_swearContext:{m_swearContext:X8}, m_acceptSwearContext:{m_acceptSwearContext:X8}, m_breakContext:{m_breakContext:X8}, m_kickContext:{m_kickContext:X8}";

        // Functions:

        // gmAllegianceUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, LayoutDesc*, ElementDesc*, void>)0x00490E20)(ref this, _layout, _full_desc); // .text:00490B40 ; void __thiscall gmAllegianceUI::gmAllegianceUI(gmAllegianceUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:00490B40 ??0gmAllegianceUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmAllegianceUI.CloseAcceptSwearConfirmationDialog:
        public Byte CloseAcceptSwearConfirmationDialog(Byte i_bConfirm) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, Byte, Byte>)0x00490D30)(ref this, i_bConfirm); // .text:00490A50 ; bool __thiscall gmAllegianceUI::CloseAcceptSwearConfirmationDialog(gmAllegianceUI *this, bool i_bConfirm) .text:00490A50 ?CloseAcceptSwearConfirmationDialog@gmAllegianceUI@@IAE_N_N@Z

        // gmAllegianceUI.CloseBreakConfirmationDialog:
        public Byte CloseBreakConfirmationDialog(Byte i_bConfirm) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, Byte, Byte>)0x00490D70)(ref this, i_bConfirm); // .text:00490A90 ; bool __thiscall gmAllegianceUI::CloseBreakConfirmationDialog(gmAllegianceUI *this, bool i_bConfirm) .text:00490A90 ?CloseBreakConfirmationDialog@gmAllegianceUI@@IAE_N_N@Z

        // gmAllegianceUI.CloseKickConfirmationDialog:
        public Byte CloseKickConfirmationDialog(Byte i_bConfirm) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, Byte, Byte>)0x00490DE0)(ref this, i_bConfirm); // .text:00490B00 ; bool __thiscall gmAllegianceUI::CloseKickConfirmationDialog(gmAllegianceUI *this, bool i_bConfirm) .text:00490B00 ?CloseKickConfirmationDialog@gmAllegianceUI@@IAE_N_N@Z

        // gmAllegianceUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x00490FF0)(_layout, _full_desc); // .text:00490D10 ; UIElement *__cdecl gmAllegianceUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:00490D10 ?Create@gmAllegianceUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmAllegianceUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, UInt32, UIElement*>)0x00490EF0)(ref this, i_eType); // .text:00490C10 ; UIElement *__thiscall gmAllegianceUI::DynamicCast(gmAllegianceUI *this, unsigned int i_eType) .text:00490C10 ?DynamicCast@gmAllegianceUI@@UAEPAVUIElement@@K@Z

        // gmAllegianceUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, UInt32>)0x00490F10)(ref this); // .text:00490C30 ; unsigned int __thiscall gmAllegianceUI::GetUIElementType(gmAllegianceUI *this) .text:00490C30 ?GetUIElementType@gmAllegianceUI@@UBEKXZ

        // gmAllegianceUI.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, UIElementMessageInfo*, UIElementMessageListenResult>)0x00493310)(ref this, i_rMsg); // .text:00493030 ; UIElementMessageListenResult __thiscall gmAllegianceUI::ListenToElementMessage(gmAllegianceUI *this, UIElementMessageInfo *i_rMsg) .text:00493030 ?ListenToElementMessage@gmAllegianceUI@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmAllegianceUI.ListenToGlobalMessage:
        public void ListenToGlobalMessage(UInt32 i_messageID, int i_data_int) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, UInt32, int, void>)0x00490B90)(ref this, i_messageID, i_data_int); // .text:004908B0 ; void __thiscall gmAllegianceUI::ListenToGlobalMessage(gmAllegianceUI *this, unsigned int i_messageID, int i_data_int) .text:004908B0 ?ListenToGlobalMessage@gmAllegianceUI@@UAEXKJ@Z

        // gmAllegianceUI.MakeAcceptSwearConfirmationDialog:
        public Byte MakeAcceptSwearConfirmationDialog(PStringBase<char> i_strRequestor, UInt32 i_uiServerContextID) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, PStringBase<char>, UInt32, Byte>)0x00492C70)(ref this, i_strRequestor, i_uiServerContextID); // .text:00492990 ; bool __thiscall gmAllegianceUI::MakeAcceptSwearConfirmationDialog(gmAllegianceUI *this, PStringBase<char> i_strRequestor, unsigned int i_uiServerContextID) .text:00492990 ?MakeAcceptSwearConfirmationDialog@gmAllegianceUI@@IAE_NV?$PStringBase@D@@K@Z

        // gmAllegianceUI.MakeBreakConfirmationDialog:
        public Byte MakeBreakConfirmationDialog() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, Byte>)0x00492ED0)(ref this); // .text:00492BF0 ; bool __thiscall gmAllegianceUI::MakeBreakConfirmationDialog(gmAllegianceUI *this) .text:00492BF0 ?MakeBreakConfirmationDialog@gmAllegianceUI@@IAE_NXZ

        // gmAllegianceUI.MakeKickConfirmationDialog:
        public Byte MakeKickConfirmationDialog() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, Byte>)0x004930F0)(ref this); // .text:00492E10 ; bool __thiscall gmAllegianceUI::MakeKickConfirmationDialog(gmAllegianceUI *this) .text:00492E10 ?MakeKickConfirmationDialog@gmAllegianceUI@@IAE_NXZ

        // gmAllegianceUI.MakeSwearConfirmationDialog:
        public Byte MakeSwearConfirmationDialog() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, Byte>)0x00492A90)(ref this); // .text:004927B0 ; bool __thiscall gmAllegianceUI::MakeSwearConfirmationDialog(gmAllegianceUI *this) .text:004927B0 ?MakeSwearConfirmationDialog@gmAllegianceUI@@IAE_NXZ

        // gmAllegianceUI.OnQualityRemoved:
        public void OnQualityRemoved(CWeenieObject* cwobj, StatType stype, UInt32 senum) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, CWeenieObject*, StatType, UInt32, void>)0x00491090)(ref this, cwobj, stype, senum); // .text:00490DB0 ; void __thiscall gmAllegianceUI::OnQualityRemoved(gmAllegianceUI *this, CWeenieObject *cwobj, StatType stype, unsigned int senum) .text:00490DB0 ?OnQualityRemoved@gmAllegianceUI@@UAEXPAVCWeenieObject@@W4StatType@@K@Z

        // gmAllegianceUI.OnVisibilityChanged:
        public void OnVisibilityChanged(Byte i_bVisible) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, Byte, void>)0x00491520)(ref this, i_bVisible); // .text:00491240 ; void __thiscall gmAllegianceUI::OnVisibilityChanged(gmAllegianceUI *this, bool i_bVisible) .text:00491240 ?OnVisibilityChanged@gmAllegianceUI@@MAEX_N@Z

        // gmAllegianceUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00491170)(ref this); // .text:00490E90 ; void __thiscall gmAllegianceUI::PostInit(gmAllegianceUI *this) .text:00490E90 ?PostInit@gmAllegianceUI@@UAEXXZ

        // gmAllegianceUI.RecvNotice_AbortConfirmationRequest:
        public void RecvNotice_AbortConfirmationRequest(int confirmationType, UInt32 context) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, int, UInt32, void>)0x00491060)(ref this, confirmationType, context); // .text:00490D80 ; void __thiscall gmAllegianceUI::RecvNotice_AbortConfirmationRequest(gmAllegianceUI *this, int confirmationType, unsigned int context) .text:00490D80 ?RecvNotice_AbortConfirmationRequest@gmAllegianceUI@@UAEXJK@Z

        // gmAllegianceUI.RecvNotice_AllegianceLogin:
        public void RecvNotice_AllegianceLogin(UInt32 i_iidMember, Byte i_bNowLoggedIn) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, UInt32, Byte, void>)0x00492500)(ref this, i_iidMember, i_bNowLoggedIn); // .text:00492220 ; void __thiscall gmAllegianceUI::RecvNotice_AllegianceLogin(gmAllegianceUI *this, unsigned int i_iidMember, bool i_bNowLoggedIn) .text:00492220 ?RecvNotice_AllegianceLogin@gmAllegianceUI@@UAEXK_N@Z

        // gmAllegianceUI.RecvNotice_AllegianceUpdate:
        public void RecvNotice_AllegianceUpdate(CAllegianceProfile* i_prof, UInt32 i_uiRank) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, CAllegianceProfile*, UInt32, void>)0x00492A60)(ref this, i_prof, i_uiRank); // .text:00492780 ; void __thiscall gmAllegianceUI::RecvNotice_AllegianceUpdate(gmAllegianceUI *this, CAllegianceProfile *i_prof, unsigned int i_uiRank) .text:00492780 ?RecvNotice_AllegianceUpdate@gmAllegianceUI@@UAEXABVCAllegianceProfile@@K@Z

        // gmAllegianceUI.RecvNotice_AllegianceUpdateAborted:
        public void RecvNotice_AllegianceUpdateAborted(UInt32 i_etype) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, UInt32, void>)0x00492A70)(ref this, i_etype); // .text:00492790 ; void __thiscall gmAllegianceUI::RecvNotice_AllegianceUpdateAborted(gmAllegianceUI *this, unsigned int i_etype) .text:00492790 ?RecvNotice_AllegianceUpdateAborted@gmAllegianceUI@@UAEXK@Z

        // gmAllegianceUI.RecvNotice_CloseDialog:
        public void RecvNotice_CloseDialog(UInt32 context, PropertyCollection* data) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, UInt32, PropertyCollection*, void>)0x00492340)(ref this, context, data); // .text:00492060 ; void __thiscall gmAllegianceUI::RecvNotice_CloseDialog(gmAllegianceUI *this, unsigned int context, PropertyCollection *data) .text:00492060 ?RecvNotice_CloseDialog@gmAllegianceUI@@UAEXKABVPropertyCollection@@@Z

        // gmAllegianceUI.RecvNotice_EnchantmentsChanged:
        public void RecvNotice_EnchantmentsChanged() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00492330)(ref this); // .text:00492050 ; void __thiscall gmAllegianceUI::RecvNotice_EnchantmentsChanged(gmAllegianceUI *this) .text:00492050 ?RecvNotice_EnchantmentsChanged@gmAllegianceUI@@UAEXXZ

        // gmAllegianceUI.RecvNotice_PlayerDescReceived:
        public void RecvNotice_PlayerDescReceived(CACQualities* i_playerDesc, CPlayerModule* i_playerModule) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, CACQualities*, CPlayerModule*, void>)0x00491020)(ref this, i_playerDesc, i_playerModule); // .text:00490D40 ; void __thiscall gmAllegianceUI::RecvNotice_PlayerDescReceived(gmAllegianceUI *this, CACQualities *i_playerDesc, CPlayerModule *i_playerModule) .text:00490D40 ?RecvNotice_PlayerDescReceived@gmAllegianceUI@@UAEXABVCACQualities@@ABVCPlayerModule@@@Z

        // gmAllegianceUI.RecvNotice_SelectionChanged:
        public void RecvNotice_SelectionChanged() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00491050)(ref this); // .text:00490D70 ; void __thiscall gmAllegianceUI::RecvNotice_SelectionChanged(gmAllegianceUI *this) .text:00490D70 ?RecvNotice_SelectionChanged@gmAllegianceUI@@UAEXXZ

        // gmAllegianceUI.RecvNotice_SwearAllegianceRequest:
        public void RecvNotice_SwearAllegianceRequest(AC1Legacy.PStringBase<char>* i_strRequestor, UInt32 i_uiContext) => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, AC1Legacy.PStringBase<char>*, UInt32, void>)0x004933F0)(ref this, i_strRequestor, i_uiContext); // .text:00493110 ; void __thiscall gmAllegianceUI::RecvNotice_SwearAllegianceRequest(gmAllegianceUI *this, AC1Legacy::PStringBase<char> *i_strRequestor, unsigned int i_uiContext) .text:00493110 ?RecvNotice_SwearAllegianceRequest@gmAllegianceUI@@UAEXABV?$PStringBase@D@AC1Legacy@@K@Z

        // gmAllegianceUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004914D0)(); // .text:004911F0 ; void __cdecl gmAllegianceUI::Register() .text:004911F0 ?Register@gmAllegianceUI@@SAXXZ

        // gmAllegianceUI.Update:
        public void Update() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00492950)(ref this); // .text:00492670 ; void __thiscall gmAllegianceUI::Update(gmAllegianceUI *this) .text:00492670 ?Update@gmAllegianceUI@@IAEXXZ

        // gmAllegianceUI.UpdateBreakButton:
        public void UpdateBreakButton() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00490CB0)(ref this); // .text:004909D0 ; void __thiscall gmAllegianceUI::UpdateBreakButton(gmAllegianceUI *this) .text:004909D0 ?UpdateBreakButton@gmAllegianceUI@@IAEXXZ

        // gmAllegianceUI.UpdateMonarchData:
        public void UpdateMonarchData() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00491E20)(ref this); // .text:00491B40 ; void __thiscall gmAllegianceUI::UpdateMonarchData(gmAllegianceUI *this) .text:00491B40 ?UpdateMonarchData@gmAllegianceUI@@IAEXXZ

        // gmAllegianceUI.UpdatePatronData:
        public void UpdatePatronData() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00491AA0)(ref this); // .text:004917C0 ; void __thiscall gmAllegianceUI::UpdatePatronData(gmAllegianceUI *this) .text:004917C0 ?UpdatePatronData@gmAllegianceUI@@IAEXXZ

        // gmAllegianceUI.UpdatePlayerData:
        public void UpdatePlayerData() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00491610)(ref this); // .text:00491330 ; void __thiscall gmAllegianceUI::UpdatePlayerData(gmAllegianceUI *this) .text:00491330 ?UpdatePlayerData@gmAllegianceUI@@IAEXXZ

        // gmAllegianceUI.UpdateSwearButton:
        public void UpdateSwearButton() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00490BC0)(ref this); // .text:004908E0 ; void __thiscall gmAllegianceUI::UpdateSwearButton(gmAllegianceUI *this) .text:004908E0 ?UpdateSwearButton@gmAllegianceUI@@IAEXXZ

        // gmAllegianceUI.UpdateVassalsData:
        public void UpdateVassalsData() => ((delegate* unmanaged[Thiscall]<ref gmAllegianceUI, void>)0x00492620)(ref this); // .text:00492340 ; void __thiscall gmAllegianceUI::UpdateVassalsData(gmAllegianceUI *this) .text:00492340 ?UpdateVassalsData@gmAllegianceUI@@IAEXXZ
    }
    public unsafe struct AllegianceSystem {
        // Struct:

        // Functions:

        // AllegianceSystem.GetAluvianFemaleTitle:
        // public static int GetAluvianFemaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B7CD0 ; int __cdecl AllegianceSystem::GetAluvianFemaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B7CD0 ?GetAluvianFemaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetAluvianMaleTitle:
        // public static int GetAluvianMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B7BC0 ; int __cdecl AllegianceSystem::GetAluvianMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B7BC0 ?GetAluvianMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetEmpyreanFemaleTitle:
        // public static int GetEmpyreanFemaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8AA0 ; int __cdecl AllegianceSystem::GetEmpyreanFemaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8AA0 ?GetEmpyreanFemaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetEmpyreanMaleTitle:
        // public static int GetEmpyreanMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8990 ; int __cdecl AllegianceSystem::GetEmpyreanMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8990 ?GetEmpyreanMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetGearknightMaleTitle:
        // public static int GetGearknightMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8660 ; int __cdecl AllegianceSystem::GetGearknightMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8660 ?GetGearknightMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetGharundimFemaleTitle:
        // public static int GetGharundimFemaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B7EF0 ; int __cdecl AllegianceSystem::GetGharundimFemaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B7EF0 ?GetGharundimFemaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetGharundimMaleTitle:
        // public static int GetGharundimMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B7DE0 ; int __cdecl AllegianceSystem::GetGharundimMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B7DE0 ?GetGharundimMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetLugianMaleTitle:
        // public static int GetLugianMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8880 ; int __cdecl AllegianceSystem::GetLugianMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8880 ?GetLugianMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetShadowboundFemaleTitle:
        // public static int GetShadowboundFemaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8550 ; int __cdecl AllegianceSystem::GetShadowboundFemaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8550 ?GetShadowboundFemaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetShadowboundMaleTitle:
        // public static int GetShadowboundMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8440 ; int __cdecl AllegianceSystem::GetShadowboundMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8440 ?GetShadowboundMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetShoFemaleTitle:
        // public static int GetShoFemaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8110 ; int __cdecl AllegianceSystem::GetShoFemaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8110 ?GetShoFemaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetShoMaleTitle:
        // public static int GetShoMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8000 ; int __cdecl AllegianceSystem::GetShoMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8000 ?GetShoMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetTitle:
        public static int GetTitle(UInt32 rank, UInt32 hg, UInt32 g, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, AC1Legacy.PStringBase<char>*, int>)0x005B9F10)(rank, hg, g, title); // .text:005B8DD0 ; int __cdecl AllegianceSystem::GetTitle(unsigned int rank, unsigned int hg, unsigned int g, AC1Legacy::PStringBase<char> *title) .text:005B8DD0 ?GetTitle@AllegianceSystem@@SAHKKKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetTumerokMaleTitle:
        // public static int GetTumerokMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8770 ; int __cdecl AllegianceSystem::GetTumerokMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8770 ?GetTumerokMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetUndeadFemaleTitle:
        // public static int GetUndeadFemaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8CC0 ; int __cdecl AllegianceSystem::GetUndeadFemaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8CC0 ?GetUndeadFemaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetUndeadMaleTitle:
        // public static int GetUndeadMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8BB0 ; int __cdecl AllegianceSystem::GetUndeadMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8BB0 ?GetUndeadMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetViamontianFemaleTitle:
        // public static int GetViamontianFemaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8330 ; int __cdecl AllegianceSystem::GetViamontianFemaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8330 ?GetViamontianFemaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AllegianceSystem.GetViamontianMaleTitle:
        // public static int GetViamontianMaleTitle(UInt32 rank, AC1Legacy.PStringBase<char>* title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(rank, title); // .text:005B8220 ; int __cdecl AllegianceSystem::GetViamontianMaleTitle(unsigned int rank, AC1Legacy::PStringBase<char> *title) .text:005B8220 ?GetViamontianMaleTitle@AllegianceSystem@@KAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // Globals:
        // public static Single* MinVassalToBankAllegianceXPMod = (Single*)0xDEADBEEF; // .data:008EF420 ; float AllegianceSystem::MinVassalToBankAllegianceXPMod .data:008EF420 ?MinVassalToBankAllegianceXPMod@AllegianceSystem@@1MA
        // public static UInt32* AbsoluteMaxVassals = (UInt32*)0xDEADBEEF; // .data:008216D8 ; unsigned int AllegianceSystem::AbsoluteMaxVassals .data:008216D8 ?AbsoluteMaxVassals@AllegianceSystem@@1KA
        // public static Single* MinVassalToBankEarnedXPMod = (Single*)0xDEADBEEF; // .data:008216E4 ; float AllegianceSystem::MinVassalToBankEarnedXPMod .data:008216E4 ?MinVassalToBankEarnedXPMod@AllegianceSystem@@1MA
        // public static Single* MaxVassalToBankAllegianceXPMod = (Single*)0xDEADBEEF; // .data:008216EC ; float AllegianceSystem::MaxVassalToBankAllegianceXPMod .data:008216EC ?MaxVassalToBankAllegianceXPMod@AllegianceSystem@@1MA
        // public static UInt32* MinEffectiveLeadership = (UInt32*)0xDEADBEEF; // .data:008EF41C ; unsigned int AllegianceSystem::MinEffectiveLeadership .data:008EF41C ?MinEffectiveLeadership@AllegianceSystem@@1KA
        // public static Single* MaxBankToPatronAllegianceXPMod = (Single*)0xDEADBEEF; // .data:008216F4 ; float AllegianceSystem::MaxBankToPatronAllegianceXPMod .data:008216F4 ?MaxBankToPatronAllegianceXPMod@AllegianceSystem@@1MA
        // public static UInt32* MinEffectiveLoyalty = (UInt32*)0xDEADBEEF; // .data:008EF418 ; unsigned int AllegianceSystem::MinEffectiveLoyalty .data:008EF418 ?MinEffectiveLoyalty@AllegianceSystem@@1KA
        // public static UInt32* MaxEffectiveLoyalty = (UInt32*)0xDEADBEEF; // .data:008216DC ; unsigned int AllegianceSystem::MaxEffectiveLoyalty .data:008216DC ?MaxEffectiveLoyalty@AllegianceSystem@@1KA
        // public static UInt32* MaxEffectiveLeadership = (UInt32*)0xDEADBEEF; // .data:008216E0 ; unsigned int AllegianceSystem::MaxEffectiveLeadership .data:008216E0 ?MaxEffectiveLeadership@AllegianceSystem@@1KA
        // public static Single* MaxVassalToBankEarnedXPMod = (Single*)0xDEADBEEF; // .data:008216E8 ; float AllegianceSystem::MaxVassalToBankEarnedXPMod .data:008216E8 ?MaxVassalToBankEarnedXPMod@AllegianceSystem@@1MA
        // public static Single* MinBankToPatronAllegianceXPMod = (Single*)0xDEADBEEF; // .data:008216F0 ; float AllegianceSystem::MinBankToPatronAllegianceXPMod .data:008216F0 ?MinBankToPatronAllegianceXPMod@AllegianceSystem@@1MA
    }


}