using AcClient;
using System;
using System.Collections.Generic;

namespace AcClient {

    public unsafe struct Interface {
        // Struct:
        public Interface.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(Interface.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<Interface*, _GUID*, void**, int> IUnknown_QueryInterface; // HRESULT (__stdcall *IUnknown_QueryInterface)(Interface *this, _GUID *, void **);
            public static delegate* unmanaged[Thiscall]<Interface*, UInt32> IUnknown_AddRef; // unsigned int (__stdcall *IUnknown_AddRef)(Interface *this);
            public static delegate* unmanaged[Thiscall]<Interface*, UInt32> IUnknown_Release; // unsigned int (__stdcall *IUnknown_Release)(Interface *this);
            public static delegate* unmanaged[Thiscall]<Interface*, TResult*, Turbine_GUID*, void**, TResult*> QueryInterface; // TResult *(__thiscall *QueryInterface)(Interface *this, TResult *result, Turbine_GUID *, void **);
            public static delegate* unmanaged[Thiscall]<Interface*, UInt32> AddRef; // unsigned int (__thiscall *AddRef)(Interface *this);
            public static delegate* unmanaged[Thiscall]<Interface*, UInt32> Release; // unsigned int (__thiscall *Release)(Interface *this);
        }

        // Functions:

        // Interface.IUnknown_AddRef:
        public UInt32 IUnknown_AddRef() => ((delegate* unmanaged[Thiscall]<ref Interface, UInt32>)0x00401C10)(ref this); // .text:00401AE0 ; unsigned int __stdcall Interface::IUnknown_AddRef(Interface *this) .text:00401AE0 ?IUnknown_AddRef@Interface@@MAGKXZ

        // Interface.IUnknown_QueryInterface:
        public int IUnknown_QueryInterface(_GUID* iid, void** ppvObject) => ((delegate* unmanaged[Thiscall]<ref Interface, _GUID*, void**, int>)0x00401BF0)(ref this, iid, ppvObject); // .text:00401AC0 ; HRESULT __stdcall Interface::IUnknown_QueryInterface(Interface *this, _GUID *iid, void **ppvObject) .text:00401AC0 ?IUnknown_QueryInterface@Interface@@MAGJABU_GUID@@PAPAX@Z

        // Interface.IUnknown_Release:
        public UInt32 IUnknown_Release() => ((delegate* unmanaged[Thiscall]<ref Interface, UInt32>)0x00401C20)(ref this); // .text:00401AF0 ; unsigned int __stdcall Interface::IUnknown_Release(Interface *this) .text:00401AF0 ?IUnknown_Release@Interface@@MAGKXZ
    }




    public unsafe struct SerializeUsingPackDBObj {
        // Struct:
        public DBObj DBObj;
        public PackObj PackObj;
        public override string ToString() => $"DBObj(DBObj):{DBObj}, PackObj(PackObj):{PackObj}";


        // Functions:

        // SerializeUsingPackDBObj.Serialize:
        public static delegate* unmanaged[Thiscall]<SerializeUsingPackDBObj*, Archive*> Serialize = (delegate* unmanaged[Thiscall]<SerializeUsingPackDBObj*, Archive*>)0x004F80D0; // .text:004F7490 ; void __thiscall SerializeUsingPackDBObj::Serialize(SerializeUsingPackDBObj *this, Archive *io_archive) .text:004F7490 ?Serialize@SerializeUsingPackDBObj@@UAEXAAVArchive@@@Z

        // SerializeUsingPackDBObj.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<SerializeUsingPackDBObj*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<SerializeUsingPackDBObj*,UInt32, void*>)0xDEADBEEF; // .text:004F7540 ; void *__thiscall SerializeUsingPackDBObj::`vector deleting destructor'(SerializeUsingPackDBObj *this, UInt32) .text:004F7540 ??_ESerializeUsingPackDBObj@@WDA@AEPAXI@Z

        // SerializeUsingPackDBObj.__Dtor:
        // public static delegate* unmanaged[Thiscall]<SerializeUsingPackDBObj*> __Dtor = (delegate* unmanaged[Thiscall]<SerializeUsingPackDBObj*>)0xDEADBEEF; // .text:004F7550 ; void __thiscall SerializeUsingPackDBObj::~SerializeUsingPackDBObj(SerializeUsingPackDBObj *this) .text:004F7550 ??1SerializeUsingPackDBObj@@UAE@XZ

        // SerializeUsingPackDBObj.__scaDelDtor:
        // public static delegate* unmanaged[Thiscall]<SerializeUsingPackDBObj*,UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<SerializeUsingPackDBObj*,UInt32, void*>)0xDEADBEEF; // .text:004F7B60 ; void *__thiscall SerializeUsingPackDBObj::`scalar deleting destructor'(SerializeUsingPackDBObj *this, UInt32) .text:004F7B60 ??_GSerializeUsingPackDBObj@@UAEPAXI@Z
    }

    public unsafe struct StreamPackObj {
        public PackObj packObj;
    };

    public unsafe struct PackObj {
        // Struct:
        public PackObj.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(PackObj.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<PackObj*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(PackObj *this, unsigned int);
        }

        // Functions:

        // PackObj.ALIGN_PTR:
        public static int ALIGN_PTR(void** ptr, UInt32* size) => ((delegate* unmanaged[Cdecl]<void**, UInt32*, int>)0x00500610)(ptr, size); // .text:004FFAF0 ; int __cdecl PackObj::ALIGN_PTR(void **ptr, unsigned int *size) .text:004FFAF0 ?ALIGN_PTR@PackObj@@SAHAAPAXAAI@Z

        // PackObj.ALIGN_PTR:
        public static UInt32 ALIGN_PTR(void** ptr) => ((delegate* unmanaged[Cdecl]<void**, UInt32>)0x004FD1B0)(ptr); // .text:004FC610 ; unsigned int __cdecl PackObj::ALIGN_PTR(void **ptr) .text:004FC610 ?ALIGN_PTR@PackObj@@SAIAAPAX@Z

        // PackObj.GET_SIZE_LEFT:
        public static UInt32 GET_SIZE_LEFT(void* addr, void* start, UInt32 size) => ((delegate* unmanaged[Cdecl]<void*, void*, UInt32, UInt32>)0x00526D90)(addr, start, size); // .text:00526190 ; unsigned int __cdecl PackObj::GET_SIZE_LEFT(void *addr, void *start, unsigned int size) .text:00526190 ?GET_SIZE_LEFT@PackObj@@SAIPAX0I@Z

        // PackObj.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref PackObj, UInt32>)0x00401090)(ref this); // .text:00401090 ; unsigned int __thiscall PackObj::GetPackSize(PackObj *this) .text:00401090 ?GetPackSize@PackObj@@UBEIXZ

        // PackObj.UNPACK_TYPE:
        public static int UNPACK_TYPE(int* data_r, void** buffer_vpr, UInt32* size_r) => ((delegate* unmanaged[Cdecl]<int*, void**, UInt32*, int>)0x004FD180)(data_r, buffer_vpr, size_r); // .text:004FC5E0 ; int __cdecl PackObj::UNPACK_TYPE(int *data_r, void **buffer_vpr, unsigned int *size_r) .text:004FC5E0 ?UNPACK_TYPE@PackObj@@SAHAAHAAPAXAAI@Z

        // PackObj.VERIFY_ADDR:
        public static int VERIFY_ADDR(void* addr, void* start, UInt32 size) => ((delegate* unmanaged[Cdecl]<void*, void*, UInt32, int>)0x00526DB0)(addr, start, size); // .text:005261B0 ; int __cdecl PackObj::VERIFY_ADDR(void *addr, void *start, unsigned int size) .text:005261B0 ?VERIFY_ADDR@PackObj@@SAHPAX0I@Z
    }



    public unsafe struct Turbine_RefCount {
        public _Vtbl* vfptr;
        public UInt32 m_cRef;
        public override string ToString() => $"m_cRef:{m_cRef:X8}";


        // Functions:

        // Turbine_RefCount.__scaDelDtor:
        public static delegate* unmanaged[Thiscall]<Turbine_RefCount*, UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<Turbine_RefCount*, UInt32, void*>)0x00401C30; // .text:00401B00 ; void *__thiscall Turbine_RefCount::`scalar deleting destructor'(Turbine_RefCount *this, UInt32) .text:00401B00 ??_GTurbine_RefCount@@UAEPAXI@Z

    };

    public unsafe struct DBObj {
        // Struct:
        public Interface a0;
        public UInt32 m_dataCategory;
        public Byte m_bLoaded;
        public Double m_timeStamp;
        public DBObj* m_pNext;
        public DBObj* m_pLast;
        public DBOCache* m_pMaintainer;
        public int m_numLinks;
        public UInt32 m_DID;
        public Byte m_AllowedInFreeList;
        public override string ToString() => $"a0(_Interface):{a0}, m_dataCategory:{m_dataCategory:X8}, m_bLoaded:{m_bLoaded:X2}, m_timeStamp:{m_timeStamp:n5}, m_pNext:->(DBObj*)0x{(int)m_pNext:X8}, m_pLast:->(DBObj*)0x{(int)m_pLast:X8}, m_pMaintainer:->(DBOCache*)0x{(int)m_pMaintainer:X8}, m_numLinks(int):{m_numLinks}, m_DID:{m_DID:X8}, m_AllowedInFreeList:{m_AllowedInFreeList:X2}";

        // Functions:

        // DBObj.__Ctor:
        public void __Ctor(UInt32 id) => ((delegate* unmanaged[Thiscall]<ref DBObj, UInt32, void>)0x00415460)(ref this, id); // .text:004151C0 ; void __thiscall DBObj::DBObj(DBObj *this, IDClass<_tagDataID,32,0> id) .text:004151C0 ??0DBObj@@IAE@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DBObj.AddRef:
        public UInt32 AddRef() => ((delegate* unmanaged[Thiscall]<ref DBObj, UInt32>)0x004153D0)(ref this); // .text:00415130 ; unsigned int __thiscall DBObj::AddRef(DBObj *this) .text:00415130 ?AddRef@DBObj@@UBEKXZ

        // DBObj.AddToDataGraph:
        public void AddToDataGraph() => ((delegate* unmanaged[Thiscall]<ref DBObj, void>)0x004153C0)(ref this); // .text:00415120 ; void __thiscall DBObj::AddToDataGraph(DBObj *this) .text:00415120 ?AddToDataGraph@DBObj@@QBEXXZ

        // DBObj.FillDataGraph:
        public void FillDataGraph(IDataGraph* graph) => ((delegate* unmanaged[Thiscall]<ref DBObj, IDataGraph*, void>)0x00415760)(ref this, graph); // .text:004154C0 ; void __thiscall DBObj::FillDataGraph(DBObj *this, IDataGraph *graph) .text:004154C0 ?FillDataGraph@DBObj@@UBEXAAVIDataGraph@@@Z

        // DBObj.Get:
        public static DBObj* Get(QualifiedDataID* qdid) => ((delegate* unmanaged[Cdecl]<QualifiedDataID*, DBObj*>)0x00415430)(qdid); // .text:00415190 ; DBObj *__cdecl DBObj::Get(QualifiedDataID *qdid) .text:00415190 ?Get@DBObj@@KAPAV1@ABUQualifiedDataID@@@Z

        // DBObj.GetByEnum:
        public static DBObj* GetByEnum(int enum_id, int enum_group, UInt32 MyType) => ((delegate* unmanaged[Cdecl]<int, int, UInt32, DBObj*>)0x00415730)(enum_id, enum_group, MyType); // .text:00415490 ; DBObj *__cdecl DBObj::GetByEnum(int enum_id, int enum_group, unsigned int MyType) .text:00415490 ?GetByEnum@DBObj@@KAPAV1@JJK@Z

        // DBObj.GetDIDByEnum:
        public static UInt32* GetDIDByEnum(UInt32* result, int enum_id, int enum_group) => ((delegate* unmanaged[Cdecl]<UInt32*, int, int, UInt32*>)0x00415640)(result, enum_id, enum_group); // .text:004153A0 ; IDClass<_tagDataID,32,0> *__cdecl DBObj::GetDIDByEnum(IDClass<_tagDataID,32,0> *result, int enum_id, int enum_group) .text:004153A0 ?GetDIDByEnum@DBObj@@SA?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@JJ@Z

        // DBObj.InitLoad:
        public static Byte InitLoad() => ((delegate* unmanaged[Cdecl]<Byte>)0x004154A0)(); // .text:00415200 ; bool __cdecl DBObj::InitLoad() .text:00415200 ?InitLoad@DBObj@@UAE_NXZ

        // DBObj.PreFetch:
        public static CACHE_OBJECT_CODES PreFetch(QualifiedDataID* qdid) => ((delegate* unmanaged[Cdecl]<QualifiedDataID*, CACHE_OBJECT_CODES>)0x00415450)(qdid); // .text:004151B0 ; CACHE_OBJECT_CODES __cdecl DBObj::PreFetch(QualifiedDataID *qdid) .text:004151B0 ?PreFetch@DBObj@@SA?AW4CACHE_OBJECT_CODES@@ABUQualifiedDataID@@@Z

        // DBObj.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppObject) => ((delegate* unmanaged[Thiscall]<ref DBObj, TResult*, Turbine_GUID*, void**, TResult*>)0x004154C0)(ref this, result, i_rcInterface, o_ppObject); // .text:00415220 ; TResult *__thiscall DBObj::QueryInterface(DBObj *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppObject) .text:00415220 ?QueryInterface@DBObj@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // DBObj.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref DBObj, UInt32>)0x00415400)(ref this); // .text:00415160 ; unsigned int __thiscall DBObj::Release(DBObj *this) .text:00415160 ?Release@DBObj@@UBEKXZ

        // DBObj.ReloadFromDisk:
        public Byte ReloadFromDisk() => ((delegate* unmanaged[Thiscall]<ref DBObj, Byte>)0x00415520)(ref this); // .text:00415280 ; bool __thiscall DBObj::ReloadFromDisk(DBObj *this) .text:00415280 ?ReloadFromDisk@DBObj@@UBE_NXZ

        // DBObj.Remove:
        public static void Remove(DBObj* pObj) => ((delegate* unmanaged[Cdecl]<DBObj*, void>)0x00415610)(pObj); // .text:00415370 ; void __cdecl DBObj::Remove(DBObj *pObj) .text:00415370 ?Remove@DBObj@@SAXPBV1@@Z

        // DBObj.SaveToDisk:
        public Byte SaveToDisk(PreprocHeader* header) => ((delegate* unmanaged[Thiscall]<ref DBObj, PreprocHeader*, Byte>)0x00415550)(ref this, header); // .text:004152B0 ; bool __thiscall DBObj::SaveToDisk(DBObj *this, PreprocHeader *header) .text:004152B0 ?SaveToDisk@DBObj@@UBE_NABVPreprocHeader@@@Z

        // DBObj.Serialize:
        public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref DBObj, Archive*, void>)0x00415590)(ref this, io_archive); // .text:004152F0 ; void __thiscall DBObj::Serialize(DBObj *this, Archive *io_archive) .text:004152F0 ?Serialize@DBObj@@UAEXAAVArchive@@@Z
    }

    public unsafe struct DBOCache {
        // Struct:
        public DBOCache.Vtbl* vfptr;
        public AutoGrowHashTable<UInt32, PTR<DBObj>> m_ObjTable;
        public UInt32 m_dbtype;
        public HashTable<UInt32, Single> m_fidelityTable;
        public Byte m_fCanKeepFreeObjs;
        public Byte m_fKeepFreeObjs;
        public Byte m_bFreelistActive;
        public FreelistDef m_freelistDef;
        public DBObj* m_pOldestFree;
        public DBObj* m_pYoungestFree;
        public UInt32 m_nFree;
        public UInt32 m_nTotalCount;
        public static delegate* unmanaged[Cdecl]<DBObj*> m_pfnAllocator; // DBObj *(__cdecl *m_pfnAllocator)();
        public override string ToString() => $"vfptr:->(DBOCache.Vtbl*)0x{(int)vfptr:X8}, m_ObjTable(AutoGrowHashTable<UInt32,DBObj*>):{m_ObjTable}, m_dbtype:{m_dbtype:X8}, m_fidelityTable(HashTable<UInt32,Single,0>):{m_fidelityTable}, m_fCanKeepFreeObjs:{m_fCanKeepFreeObjs:X2}, m_fKeepFreeObjs:{m_fKeepFreeObjs:X2}, m_bFreelistActive:{m_bFreelistActive:X2}, m_freelistDef(FreelistDef):{m_freelistDef}, m_pOldestFree:->(DBObj*)0x{(int)m_pOldestFree:X8}, m_pYoungestFree:->(DBObj*)0x{(int)m_pYoungestFree:X8}, m_nFree:{m_nFree:X8}, m_nTotalCount:{m_nTotalCount:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<DBOCache*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(DBOCache *this, unsigned int);
            public fixed byte gap4[8];
            public static delegate* unmanaged[Thiscall]<DBOCache*, UInt32, _Collection*> GetCollection; // struct Collection *(__thiscall *GetCollection)(DBOCache *this, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<DBOCache*, _Collection*, Byte> SetCollection; // bool (__thiscall *SetCollection)(DBOCache *this, struct Collection *);
            public static delegate* unmanaged[Thiscall]<DBOCache*, UInt32, UInt32> Release; // unsigned int (__thiscall *Release)(DBOCache *this, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<DBOCache*, DBObj*, Byte> AddObj; // bool (__thiscall *AddObj)(DBOCache *this, DBObj *);
            public static delegate* unmanaged[Thiscall]<DBOCache*, UInt32, Byte> RemoveObj; // bool (__thiscall *RemoveObj)(DBOCache *this, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<DBOCache*, Byte> CanLoadFromDisk; // bool (__thiscall *CanLoadFromDisk)(DBOCache *this);
            public static delegate* unmanaged[Thiscall]<DBOCache*, Byte> CanRequestFromNet; // bool (__thiscall *CanRequestFromNet)(DBOCache *this);
            public static delegate* unmanaged[Thiscall]<DBOCache*, void> FlushFreeObjects; // void (__thiscall *FlushFreeObjects)(DBOCache *this);
            public static delegate* unmanaged[Thiscall]<DBOCache*, PreprocHeader*, DBObj*, Byte> SaveObjectToDisk; // bool (__thiscall *SaveObjectToDisk)(DBOCache *this, PreprocHeader *, DBObj *);
            public static delegate* unmanaged[Thiscall]<DBOCache*, UInt32, Byte> ReloadObject; // bool (__thiscall *ReloadObject)(DBOCache *this, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<DBOCache*, void> LastWords; // void (__thiscall *LastWords)(DBOCache *this);
            public static delegate* unmanaged[Thiscall]<DBOCache*, DBObj*, Byte> AddObj_Internal; // bool (__thiscall *AddObj_Internal)(DBOCache *this, DBObj *);
            public static delegate* unmanaged[Thiscall]<DBOCache*, DBObj*, void> RemoveObj_Internal; // void (__thiscall *RemoveObj_Internal)(DBOCache *this, DBObj *);
            public static delegate* unmanaged[Thiscall]<DBOCache*, DBObj*, void> FreeObject; // void (__thiscall *FreeObject)(DBOCache *this, DBObj *);
            public static delegate* unmanaged[Thiscall]<DBOCache*, DBObj*, void> DestroyObj; // void (__thiscall *DestroyObj)(DBOCache *this, DBObj *);
            public static delegate* unmanaged[Thiscall]<DBOCache*, DBObj*, void> FreelistAdd; // void (__thiscall *FreelistAdd)(DBOCache *this, DBObj *);
            public static delegate* unmanaged[Thiscall]<DBOCache*, DBObj*, void> FreelistRemove; // void (__thiscall *FreelistRemove)(DBOCache *this, DBObj *);
            public static delegate* unmanaged[Thiscall]<DBOCache*, DBObj*> FreelistRemoveOldest; // DBObj *(__thiscall *FreelistRemoveOldest)(DBOCache *this);
        }

        // Functions:

        // DBOCache.__Ctor:
        // public void __Ctor(DBObj* a1, __cdecl* _allocator, UInt32 _dbtype) => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*, __cdecl*, UInt32, void>)0xDEADBEEF)(ref this, a1, _allocator, _dbtype); // .text:00417260 ; void __thiscall DBOCache::DBOCache(DBOCache *this, DBObj *(__cdecl *_allocator)(), unsigned int _dbtype) .text:00417260 ??0DBOCache@@QAE@P6APAVDBObj@@XZK@Z

        // DBOCache.AddObj:
        public Byte AddObj(DBObj* obj_p) => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*, Byte>)0x00416950)(ref this, obj_p); // .text:004166B0 ; bool __thiscall DBOCache::AddObj(DBOCache *this, DBObj *obj_p) .text:004166B0 ?AddObj@DBOCache@@UAE_NPAVDBObj@@@Z

        // DBOCache.AddObj_Internal:
        // public Byte AddObj_Internal(DBObj* object_p) => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*, Byte>)0xDEADBEEF)(ref this, object_p); // .text:00417130 ; bool __thiscall DBOCache::AddObj_Internal(DBOCache *this, DBObj *object_p) .text:00417130 ?AddObj_Internal@DBOCache@@MAE_NPAVDBObj@@@Z

        // DBOCache.DestroyObj:
        public void DestroyObj(DBObj* object_p) => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*, void>)0x00416C80)(ref this, object_p); // .text:00416A30 ; void __thiscall DBOCache::DestroyObj(DBOCache *this, DBObj *object_p) .text:00416A30 ?DestroyObj@DBOCache@@MAEXPAVDBObj@@@Z

        // DBOCache.FlushFreeObjects:
        public void FlushFreeObjects() => ((delegate* unmanaged[Thiscall]<ref DBOCache, void>)0x00416B10)(ref this); // .text:00416870 ; void __thiscall DBOCache::FlushFreeObjects(DBOCache *this) .text:00416870 ?FlushFreeObjects@DBOCache@@UAEXXZ

        // DBOCache.FreeObject:
        public void FreeObject(DBObj* object_p) => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*, void>)0x004169A0)(ref this, object_p); // .text:00416700 ; void __thiscall DBOCache::FreeObject(DBOCache *this, DBObj *object_p) .text:00416700 ?FreeObject@DBOCache@@MAEXPAVDBObj@@@Z

        // DBOCache.FreelistAdd:
        public void FreelistAdd(DBObj* object_p) => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*, void>)0x00416B50)(ref this, object_p); // .text:004168B0 ; void __thiscall DBOCache::FreelistAdd(DBOCache *this, DBObj *object_p) .text:004168B0 ?FreelistAdd@DBOCache@@MAEXPAVDBObj@@@Z

        // DBOCache.FreelistRemove:
        public void FreelistRemove(DBObj* object_p) => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*, void>)0x004169F0)(ref this, object_p); // .text:00416750 ; void __thiscall DBOCache::FreelistRemove(DBOCache *this, DBObj *object_p) .text:00416750 ?FreelistRemove@DBOCache@@MAEXPAVDBObj@@@Z

        // DBOCache.FreelistRemoveOldest:
        public DBObj* FreelistRemoveOldest() => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*>)0x00416A50)(ref this); // .text:004167B0 ; DBObj *__thiscall DBOCache::FreelistRemoveOldest(DBOCache *this) .text:004167B0 ?FreelistRemoveOldest@DBOCache@@MAEPAVDBObj@@XZ

        // DBOCache.GetFreeObj:
        public DBObj* GetFreeObj() => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*>)0x00416A70)(ref this); // .text:004167D0 ; DBObj *__thiscall DBOCache::GetFreeObj(DBOCache *this) .text:004167D0 ?GetFreeObj@DBOCache@@UAEPAVDBObj@@XZ

        // DBOCache.GetIfInMemory:
        public DBObj* GetIfInMemory(Byte a1) => ((delegate* unmanaged[Thiscall]<ref DBOCache, Byte, DBObj*>)0x00416EB0)(ref this, a1); // .text:00416C60 ; public: virtual class DBObj * __thiscall DBOCache::GetIfInMemory(class IDClass<struct _tagDataID, 32, 0>, bool) .text:00416C60 ?GetIfInMemory@DBOCache@@UAEPAVDBObj@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@_N@Z

        // DBOCache.GetIfUsing:
        public DBObj* GetIfUsing(UInt32 id) => ((delegate* unmanaged[Thiscall]<ref DBOCache, UInt32, DBObj*>)0x00416F40)(ref this, id); // .text:00416CF0 ; DBObj *__thiscall DBOCache::GetIfUsing(DBOCache *this, IDClass<_tagDataID,32,0> id) .text:00416CF0 ?GetIfUsing@DBOCache@@QAEPAVDBObj@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DBOCache.IsInMemory:
        public Byte IsInMemory(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref DBOCache, UInt32, Byte>)0x00416C50)(ref this, did); // .text:00416A00 ; bool __thiscall DBOCache::IsInMemory(DBOCache *this, IDClass<_tagDataID,32,0> did) .text:00416A00 ?IsInMemory@DBOCache@@QAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DBOCache.KeepFreeObjects:
        public Byte KeepFreeObjects(Byte keep_f) => ((delegate* unmanaged[Thiscall]<ref DBOCache, Byte, Byte>)0x00416970)(ref this, keep_f); // .text:004166D0 ; bool __thiscall DBOCache::KeepFreeObjects(DBOCache *this, bool keep_f) .text:004166D0 ?KeepFreeObjects@DBOCache@@QAE_N_N@Z

        // DBOCache.Release:
        public UInt32 Release(UInt32 id) => ((delegate* unmanaged[Thiscall]<ref DBOCache, UInt32, UInt32>)0x00416FA0)(ref this, id); // .text:00416D50 ; unsigned int __thiscall DBOCache::Release(DBOCache *this, IDClass<_tagDataID,32,0> id) .text:00416D50 ?Release@DBOCache@@UAEKV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DBOCache.ReloadObject:
        public Byte ReloadObject(UInt32 id) => ((delegate* unmanaged[Thiscall]<ref DBOCache, UInt32, Byte>)0x00416B30)(ref this, id); // .text:00416890 ; bool __thiscall DBOCache::ReloadObject(DBOCache *this, IDClass<_tagDataID,32,0> id) .text:00416890 ?ReloadObject@DBOCache@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DBOCache.RemoveObj:
        public Byte RemoveObj(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref DBOCache, UInt32, Byte>)0x00416E40)(ref this, did); // .text:00416BF0 ; bool __thiscall DBOCache::RemoveObj(DBOCache *this, IDClass<_tagDataID,32,0> did) .text:00416BF0 ?RemoveObj@DBOCache@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DBOCache.RemoveObj_Internal:
        // public void RemoveObj_Internal(DBObj* object_p) => ((delegate* unmanaged[Thiscall]<ref DBOCache, DBObj*, void>)0xDEADBEEF)(ref this, object_p); // .text:004171B0 ; void __thiscall DBOCache::RemoveObj_Internal(DBOCache *this, DBObj *object_p) .text:004171B0 ?RemoveObj_Internal@DBOCache@@MAEXPAVDBObj@@@Z

        // DBOCache.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref DBOCache, void>)0x00416AC0)(ref this); // .text:00416820 ; void __thiscall DBOCache::UseTime(DBOCache *this) .text:00416820 ?UseTime@DBOCache@@QAEXXZ
    }
    public unsafe struct _Collection {
    }

    public unsafe struct PreprocHeader {
        // Struct:
        public PStringBase<Char> header_data_0;
        public PStringBase<Char> header_data_1;
        public PStringBase<Char> header_data_2;
        public PStringBase<Char> header_data_3;
        public override string ToString() => $"{header_data_0},{header_data_1},{header_data_2},{header_data_3}";
    }
    public unsafe struct FreelistDef {
        // Struct:
        public Byte m_bRecycle;
        public Byte m_bShrink;
        public UInt32 m_nIdealSize;
        public UInt32 m_nMaxSize;
        public override string ToString() => $"m_bRecycle:{m_bRecycle:X2}, m_bShrink:{m_bShrink:X2}, m_nIdealSize:{m_nIdealSize:X8}, m_nMaxSize:{m_nMaxSize:X8}";

    }
    public unsafe struct IDataGraph {
        // Struct:
        public IDataGraph.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(IDataGraph.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, Byte> add_did; // bool (__thiscall *add_did)(IDataGraph *this, IDClass<_tagDataID,32,0>);
            public fixed byte gap4[4];
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, Byte> remove_did; // bool (__thiscall *remove_did)(IDataGraph *this, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, Byte> add_iid; // bool (__thiscall *add_iid)(IDataGraph *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, UInt32, Byte> add_iid_iid_link; // bool (__thiscall *add_iid_iid_link)(IDataGraph *this, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, UInt32, Byte> add_iid_did_link; // bool (__thiscall *add_iid_did_link)(IDataGraph *this, unsigned int, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, Byte> remove_iid; // bool (__thiscall *remove_iid)(IDataGraph *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, DataKey*, Byte> add; // bool (__thiscall *add)(IDataGraph *this, struct DataKey *);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, DataKey*, DataKey*, Byte> add_link; // bool (__thiscall *add_link)(IDataGraph *this, struct DataKey *, struct DataKey *);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, DataKey*, Byte> remove; // bool (__thiscall *remove)(IDataGraph *this, struct DataKey *);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, DataKey*, DataKey*, Byte> remove_link; // bool (__thiscall *remove_link)(IDataGraph *this, struct DataKey *, struct DataKey *);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, UInt32, Byte> check_did_link; // bool (__thiscall *check_did_link)(IDataGraph *this, IDClass<_tagDataID,32,0>, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, UInt32, Byte> check_iid_link; // bool (__thiscall *check_iid_link)(IDataGraph *this, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, UInt32, Byte> check_iid_did_link; // bool (__thiscall *check_iid_did_link)(IDataGraph *this, unsigned int, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<IDataGraph*, UInt32, UInt32, Byte> check_ancestor_did; // bool (__thiscall *check_ancestor_did)(IDataGraph *this, IDClass<_tagDataID,32,0>, IDClass<_tagDataID,32,0>);
        }
    }
    public unsafe struct DataKey {
    }



    public unsafe struct Archive {
        // Struct:
        public Archive.Vtbl* vfptr;
        public UInt32 m_flags;
        public TResult m_hrError;
        public SmartBuffer m_buffer;
        public UInt32 m_currOffset;
        public HashTable<UInt32, PTR<Interface>>* m_pcUserDataHash;
        public IArchiveVersionStack* m_pVersionStack;
        public override string ToString() => $"vfptr:->(Archive.Vtbl*)0x{(int)vfptr:X8}, m_flags:{m_flags:X8}, m_hrError(TResult):{m_hrError}, m_buffer(SmartBuffer):{m_buffer}, m_currOffset:{m_currOffset:X8}, m_pcUserDataHash:->(HashTable<UInt32,Interface*,0>*)0x{(int)m_pcUserDataHash:X8}, m_pVersionStack:->(IArchiveVersionStack*)0x{(int)m_pVersionStack:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<Archive*, ArchiveInitializer*, SmartBuffer*, void> InitForPacking; // void (__thiscall *InitForPacking)(Archive *this, ArchiveInitializer *, SmartBuffer *);
            public static delegate* unmanaged[Thiscall]<Archive*, ArchiveInitializer*, SmartBuffer*, void> InitForUnpacking; // void (__thiscall *InitForUnpacking)(Archive *this, ArchiveInitializer *, SmartBuffer *);
            public static delegate* unmanaged[Thiscall]<Archive*, Byte, void> SetCheckpointing; // void (__thiscall *SetCheckpointing)(Archive *this, bool);
            public static delegate* unmanaged[Thiscall]<Archive*, void> InitVersionStack; // void (__thiscall *InitVersionStack)(Archive *this);
            public static delegate* unmanaged[Thiscall]<Archive*, void> CreateVersionStack; // void (__thiscall *CreateVersionStack)(Archive *this);
        }
        public unsafe struct tagSetCurrentCoreVersion {
            public ArchiveInitializer a0;
            public override string ToString() => $"a0(ArchiveInitializer):{a0}";
        }
        public unsafe struct SetVersionRow {
            public ArchiveInitializer a0;
            public ArchiveVersionRow* m_rInitialData;
            public override string ToString() => $"a0(ArchiveInitializer):{a0}, m_rInitialData:->(ArchiveVersionRow*)0x{(int)m_rInitialData:X8}";
        }
        // Enums:
        public enum tagUnpacking : UInt32 {
            Unpacking = 0x0,
        };
        public enum tagPacking : UInt32 {
            Packing = 0x0,
        };

        // Functions:

        // Archive.CheckAlignment:
        public void CheckAlignment(UInt32 i_objectSize) => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32, void>)0x0040AD10)(ref this, i_objectSize); // .text:0040A9B0 ; void __thiscall Archive::CheckAlignment(Archive *this, unsigned int i_objectSize) .text:0040A9B0 ?CheckAlignment@Archive@@QAEXI@Z

        // Archive.CreateVersionStack:
        public void CreateVersionStack() => ((delegate* unmanaged[Thiscall]<ref Archive, void>)0x0040AEF0)(ref this); // .text:0040AB90 ; void __thiscall Archive::CreateVersionStack(Archive *this) .text:0040AB90 ?CreateVersionStack@Archive@@MAEXXZ

        // Archive.GetBytes:
        public char* GetBytes(UInt32 i_size) => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32, char*>)0x0040ACF0)(ref this, i_size); // .text:0040A990 ; char *__thiscall Archive::GetBytes(Archive *this, unsigned int i_size) .text:0040A990 ?GetBytes@Archive@@QAEPAEI@Z

        // Archive.GetRemainingBuffer:
        public SmartBuffer* GetRemainingBuffer(SmartBuffer* result) => ((delegate* unmanaged[Thiscall]<ref Archive, SmartBuffer*, SmartBuffer*>)0x0040A920)(ref this, result); // .text:0040A5C0 ; SmartBuffer *__thiscall Archive::GetRemainingBuffer(Archive *this, SmartBuffer *result) .text:0040A5C0 ?GetRemainingBuffer@Archive@@QAE?AVSmartBuffer@@XZ

        // Archive.GetSerializedBuffer:
        public SmartBuffer* GetSerializedBuffer(SmartBuffer* result) => ((delegate* unmanaged[Thiscall]<ref Archive, SmartBuffer*, SmartBuffer*>)0x0040A900)(ref this, result); // .text:0040A5A0 ; SmartBuffer *__thiscall Archive::GetSerializedBuffer(Archive *this, SmartBuffer *result) .text:0040A5A0 ?GetSerializedBuffer@Archive@@QAE?AVSmartBuffer@@XZ

        // Archive.GetSizeLeft:
        public UInt32 GetSizeLeft() => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32>)0x0040A8F0)(ref this); // .text:0040A590 ; unsigned int __thiscall Archive::GetSizeLeft(Archive *this) .text:0040A590 ?GetSizeLeft@Archive@@QBEIXZ

        // Archive.GetSizeUsed:
        public UInt32 GetSizeUsed() => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32>)0x0040A8D0)(ref this); // .text:0040A570 ; unsigned int __thiscall Archive::GetSizeUsed(Archive *this) .text:0040A570 ?GetSizeUsed@Archive@@QBEIXZ

        // Archive.GetVersionByToken:
        public UInt32 GetVersionByToken(UInt32 i_tokVersion) => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32, UInt32>)0x0040A960)(ref this, i_tokVersion); // .text:0040A600 ; unsigned int __thiscall Archive::GetVersionByToken(Archive *this, unsigned int i_tokVersion) .text:0040A600 ?GetVersionByToken@Archive@@QBEKK@Z

        // Archive.GetVersionRowByHandle:
        public Byte GetVersionRowByHandle(UInt32 i_hVersion, ArchiveVersionRow** o_pVersionRow) => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32, ArchiveVersionRow**, Byte>)0x0040AB90)(ref this, i_hVersion, o_pVersionRow); // .text:0040A830 ; bool __thiscall Archive::GetVersionRowByHandle(Archive *this, IDClass<_tagVersionHandle,32,0> i_hVersion, ArchiveVersionRow **o_pVersionRow) .text:0040A830 ?GetVersionRowByHandle@Archive@@QAE_NV?$IDClass@U_tagVersionHandle@@$0CA@$0A@@@AAPBVArchiveVersionRow@@@Z

        // Archive.InitForPacking:
        public void InitForPacking(ArchiveInitializer* i_rInitializer, SmartBuffer* i_buffer) => ((delegate* unmanaged[Thiscall]<ref Archive, ArchiveInitializer*, SmartBuffer*, void>)0x0040AFB0)(ref this, i_rInitializer, i_buffer); // .text:0040AC50 ; void __thiscall Archive::InitForPacking(Archive *this, ArchiveInitializer *i_rInitializer, SmartBuffer *i_buffer) .text:0040AC50 ?InitForPacking@Archive@@UAEXABVArchiveInitializer@@ABVSmartBuffer@@@Z

        // Archive.InitForUnpacking:
        public void InitForUnpacking(ArchiveInitializer* i_rInitializer, SmartBuffer* i_buffer) => ((delegate* unmanaged[Thiscall]<ref Archive, ArchiveInitializer*, SmartBuffer*, void>)0x0040B020)(ref this, i_rInitializer, i_buffer); // .text:0040ACC0 ; void __thiscall Archive::InitForUnpacking(Archive *this, ArchiveInitializer *i_rInitializer, SmartBuffer *i_buffer) .text:0040ACC0 ?InitForUnpacking@Archive@@UAEXABVArchiveInitializer@@ABVSmartBuffer@@@Z

        // Archive.InitVersionStack:
        public void InitVersionStack() => ((delegate* unmanaged[Thiscall]<ref Archive, void>)0x0040A940)(ref this); // .text:0040A5E0 ; void __thiscall Archive::InitVersionStack(Archive *this) .text:0040A5E0 ?InitVersionStack@Archive@@MAEXXZ

        // Archive.IsWordAligned:
        public Byte IsWordAligned() => ((delegate* unmanaged[Thiscall]<ref Archive, Byte>)0x0040AA60)(ref this); // .text:0040A700 ; bool __thiscall Archive::IsWordAligned(Archive *this) .text:0040A700 ?IsWordAligned@Archive@@QBE_NXZ

        // Archive.PeekBytes:
        public char* PeekBytes(UInt32 i_position, UInt32 i_size) => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32, UInt32, char*>)0x0040AC70)(ref this, i_position, i_size); // .text:0040A910 ; char *__thiscall Archive::PeekBytes(Archive *this, unsigned int i_position, unsigned int i_size) .text:0040A910 ?PeekBytes@Archive@@QAEPAEII@Z

        // Archive.PushVersionRow:
        public UInt32* PushVersionRow(UInt32* result, ArchiveVersionRow* i_rInitialData) => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32*, ArchiveVersionRow*, UInt32*>)0x0040AB30)(ref this, result, i_rInitialData); // .text:0040A7D0 ; IDClass<_tagVersionHandle,32,0> *__thiscall Archive::PushVersionRow(Archive *this, IDClass<_tagVersionHandle,32,0> *result, ArchiveVersionRow *i_rInitialData) .text:0040A7D0 ?PushVersionRow@Archive@@QAE?AV?$IDClass@U_tagVersionHandle@@$0CA@$0A@@@ABVArchiveVersionRow@@@Z

        // Archive.PushVersionRow:
        public UInt32* PushVersionRow(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32*, UInt32*>)0x0040AAD0)(ref this, result); // .text:0040A770 ; IDClass<_tagVersionHandle,32,0> *__thiscall Archive::PushVersionRow(Archive *this, IDClass<_tagVersionHandle,32,0> *result) .text:0040A770 ?PushVersionRow@Archive@@QAE?AV?$IDClass@U_tagVersionHandle@@$0CA@$0A@@@XZ

        // Archive.RaiseError:
        public void RaiseError() => ((delegate* unmanaged[Thiscall]<ref Archive, void>)0x0040AA50)(ref this); // .text:0040A6F0 ; void __thiscall Archive::RaiseError(Archive *this) .text:0040A6F0 ?RaiseError@Archive@@QAEXXZ

        // Archive.ReleaseUserData:
        public void ReleaseUserData() => ((delegate* unmanaged[Thiscall]<ref Archive, void>)0x0040AF20)(ref this); // .text:0040ABC0 ; void __thiscall Archive::ReleaseUserData(Archive *this) .text:0040ABC0 ?ReleaseUserData@Archive@@IAEXXZ

        // Archive.SetCheckpointing:
        public void SetCheckpointing(Byte _checkpointing) => ((delegate* unmanaged[Thiscall]<ref Archive, Byte, void>)0x0040A9D0)(ref this, _checkpointing); // .text:0040A670 ; void __thiscall Archive::SetCheckpointing(Archive *this, bool _checkpointing) .text:0040A670 ?SetCheckpointing@Archive@@UAEX_N@Z

        // Archive.SetCurrentPosition:
        public void SetCurrentPosition(UInt32 i_position) => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32, void>)0x0040A8E0)(ref this, i_position); // .text:0040A580 ; void __thiscall Archive::SetCurrentPosition(Archive *this, unsigned int i_position) .text:0040A580 ?SetCurrentPosition@Archive@@QAEXI@Z

        // Archive.SetDBLoader:
        public void SetDBLoader(Byte _using_DBLoader) => ((delegate* unmanaged[Thiscall]<ref Archive, Byte, void>)0x0040AA10)(ref this, _using_DBLoader); // .text:0040A6B0 ; void __thiscall Archive::SetDBLoader(Archive *this, bool _using_DBLoader) .text:0040A6B0 ?SetDBLoader@Archive@@QAEX_N@Z

        // Archive.SetVersionByToken:
        public Byte SetVersionByToken(UInt32 i_tokVersion, UInt32 i_iVersion) => ((delegate* unmanaged[Thiscall]<ref Archive, UInt32, UInt32, Byte>)0x0040AA70)(ref this, i_tokVersion, i_iVersion); // .text:0040A710 ; bool __thiscall Archive::SetVersionByToken(Archive *this, unsigned int i_tokVersion, unsigned int i_iVersion) .text:0040A710 ?SetVersionByToken@Archive@@QAE_NKK@Z

        // Archive.SetWordAligned:
        public void SetWordAligned(Byte _aligned) => ((delegate* unmanaged[Thiscall]<ref Archive, Byte, void>)0x0040AA30)(ref this, _aligned); // .text:0040A6D0 ; void __thiscall Archive::SetWordAligned(Archive *this, bool _aligned) .text:0040A6D0 ?SetWordAligned@Archive@@QAEX_N@Z

        // Archive.UsingDBLoader:
        public Byte UsingDBLoader() => ((delegate* unmanaged[Thiscall]<ref Archive, Byte>)0x0040A9F0)(ref this); // .text:0040A690 ; bool __thiscall Archive::UsingDBLoader(Archive *this) .text:0040A690 ?UsingDBLoader@Archive@@QBE_NXZ

        // Globals:
        public static Archive.tagSetCurrentCoreVersion* SetCurrentCoreVersion = (Archive.tagSetCurrentCoreVersion*)0x008183B8; // .data:008173B8 ; Archive::tagSetCurrentCoreVersion Archive::SetCurrentCoreVersion .data:008173B8 ?SetCurrentCoreVersion@Archive@@2VtagSetCurrentCoreVersion@1@A
    }

    public unsafe struct IArchiveVersionStack {
        public Interface a0;
        public override string ToString() => a0.ToString();
    };
    public unsafe struct SmartBuffer {
        // Struct:
        public UInt32 m_startOffset;
        public UInt32 m_size;
        public GrowBuffer* m_masterBuffer;
        public override string ToString() => $"m_startOffset:{m_startOffset:X8}, m_size:{m_size:X8}, m_masterBuffer:->(GrowBuffer*)0x{(int)m_masterBuffer:X8}";

        // Functions:

        // SmartBuffer.__Ctor:
        public void __Ctor(SmartBuffer* i_rhs) => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, SmartBuffer*, void>)0x00406F60)(ref this, i_rhs); // .text:00406C60 ; void __thiscall SmartBuffer::SmartBuffer(SmartBuffer *this, SmartBuffer *i_rhs) .text:00406C60 ??0SmartBuffer@@QAE@ABV0@@Z

        // SmartBuffer.__Ctor:
        public void __Ctor(void* i_addr, UInt32 i_size) => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, void*, UInt32, void>)0x00407060)(ref this, i_addr, i_size); // .text:00406D60 ; void __thiscall SmartBuffer::SmartBuffer(SmartBuffer *this, void *i_addr, unsigned int i_size) .text:00406D60 ??0SmartBuffer@@QAE@PAXI@Z

        // SmartBuffer.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, void>)0x00406D60)(ref this); // .text:00406A60 ; void __thiscall SmartBuffer::SmartBuffer(SmartBuffer *this) .text:00406A60 ??0SmartBuffer@@QAE@XZ

        // SmartBuffer.operator_equals:
        public SmartBuffer* operator_equals() => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, SmartBuffer*>)0x004070D0)(ref this); // .text:00406DD0 ; public: class SmartBuffer & __thiscall SmartBuffer::operator=(class SmartBuffer const &) .text:00406DD0 ??4SmartBuffer@@QAEAAV0@ABV0@@Z

        // SmartBuffer.Borrow:
        public void Borrow(char* i_addr, UInt32 i_size) => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, char*, UInt32, void>)0x004073B0)(ref this, i_addr, i_size); // .text:004070B0 ; void __thiscall SmartBuffer::Borrow(SmartBuffer *this, char *i_addr, unsigned int i_size) .text:004070B0 ?Borrow@SmartBuffer@@QAEXPAEI@Z

        // SmartBuffer.CanGrow:
        public Byte CanGrow() => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, Byte>)0x00406D70)(ref this); // .text:00406A70 ; bool __thiscall SmartBuffer::CanGrow(SmartBuffer *this) .text:00406A70 ?CanGrow@SmartBuffer@@QBE_NXZ

        // SmartBuffer.Clone:
        public SmartBuffer* Clone(SmartBuffer* result) => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, SmartBuffer*, SmartBuffer*>)0x004073F0)(ref this, result); // .text:004070F0 ; SmartBuffer *__thiscall SmartBuffer::Clone(SmartBuffer *this, SmartBuffer *result) .text:004070F0 ?Clone@SmartBuffer@@QBE?AV1@XZ

        // SmartBuffer.CreateNewMasterBuffer:
        public void CreateNewMasterBuffer() => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, void>)0x004071E0)(ref this); // .text:00406EE0 ; void __thiscall SmartBuffer::CreateNewMasterBuffer(SmartBuffer *this) .text:00406EE0 ?CreateNewMasterBuffer@SmartBuffer@@QAEXXZ

        // SmartBuffer.GetBuffer:
        public char* GetBuffer() => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, char*>)0x00406D80)(ref this); // .text:00406A80 ; const char *__thiscall SmartBuffer::GetBuffer(SmartBuffer *this) .text:00406A80 ?GetBuffer@SmartBuffer@@QAEPAEXZ

        // SmartBuffer.GetShareCount:
        public UInt32 GetShareCount() => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, UInt32>)0x00406DC0)(ref this); // .text:00406AC0 ; unsigned int __thiscall SmartBuffer::GetShareCount(SmartBuffer *this) .text:00406AC0 ?GetShareCount@SmartBuffer@@QBEKXZ

        // SmartBuffer.GetSize:
        public UInt32 GetSize() => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, UInt32>)0x00406DB0)(ref this); // .text:00406AB0 ; unsigned int __thiscall SmartBuffer::GetSize(SmartBuffer *this) .text:00406AB0 ?GetSize@SmartBuffer@@QBEIXZ

        // SmartBuffer.MakeWindow:
        public SmartBuffer* MakeWindow(SmartBuffer* result, UInt32 i_start) => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, SmartBuffer*, UInt32, SmartBuffer*>)0x00407390)(ref this, result, i_start); // .text:00407090 ; SmartBuffer *__thiscall SmartBuffer::MakeWindow(SmartBuffer *this, SmartBuffer *result, unsigned int i_start) .text:00407090 ?MakeWindow@SmartBuffer@@QAE?AV1@I@Z

        // SmartBuffer.MakeWindow:
        public SmartBuffer* MakeWindow(SmartBuffer* result, UInt32 i_start, UInt32 i_size) => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, SmartBuffer*, UInt32, UInt32, SmartBuffer*>)0x00407140)(ref this, result, i_start, i_size); // .text:00406E40 ; SmartBuffer *__thiscall SmartBuffer::MakeWindow(SmartBuffer *this, SmartBuffer *result, unsigned int i_start, unsigned int i_size) .text:00406E40 ?MakeWindow@SmartBuffer@@QAE?AV1@II@Z

        // SmartBuffer.Orphan:
        public char* Orphan() => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, char*>)0x00406D90)(ref this); // .text:00406A90 ; char *__thiscall SmartBuffer::Orphan(SmartBuffer *this) .text:00406A90 ?Orphan@SmartBuffer@@QAEPAEXZ

        // SmartBuffer.ReconfigureAllocation:
        public void ReconfigureAllocation(UInt32 i_sizeNeeded, UInt32 i_dwBehaviorBits) => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, UInt32, UInt32, void>)0x004074B0)(ref this, i_sizeNeeded, i_dwBehaviorBits); // .text:004071B0 ; void __thiscall SmartBuffer::ReconfigureAllocation(SmartBuffer *this, unsigned int i_sizeNeeded, unsigned int i_dwBehaviorBits) .text:004071B0 ?ReconfigureAllocation@SmartBuffer@@QAEXIK@Z

        // SmartBuffer.ReleaseMasterBuffer:
        public void ReleaseMasterBuffer() => ((delegate* unmanaged[Thiscall]<ref SmartBuffer, void>)0x00406F90)(ref this); // .text:00406C90 ; void __thiscall SmartBuffer::ReleaseMasterBuffer(SmartBuffer *this) .text:00406C90 ?ReleaseMasterBuffer@SmartBuffer@@QAEXXZ
    }
    public unsafe struct GrowBuffer {
        // Struct:
        public Turbine_RefCount a0;
        public byte* m_data;
        public UInt32 m_size;
        public Byte m_ownsBuffer;
        public Byte m_bCanResize;
        public Byte m_bAllocateFromFreelist;
        public override string ToString() => $"a0(Turbine_RefCount):{a0}, m_data:->(char*)0x{(int)m_data:X8}, m_size:{m_size:X8}, m_ownsBuffer:{m_ownsBuffer:X2}, m_bCanResize:{m_bCanResize:X2}, m_bAllocateFromFreelist:{m_bAllocateFromFreelist:X2}";
        public unsafe struct FreeGrowBuffer {
            public byte* pData;
            public UInt32 cbSize;
            public override string ToString() => $"pData:->(char*)0x{(int)pData:X8}, cbSize:{cbSize:X8}";
        }

        // Functions:

        // GrowBuffer.FreeBuffer:
        public void FreeBuffer() => ((delegate* unmanaged[Thiscall]<ref GrowBuffer, void>)0x00406E80)(ref this); // .text:00406B80 ; void __thiscall GrowBuffer::FreeBuffer(GrowBuffer *this) .text:00406B80 ?FreeBuffer@GrowBuffer@@AAEXXZ

        // GrowBuffer.GetGoodSize:
        public UInt32 GetGoodSize(UInt32 i_sizeNeeded) => ((delegate* unmanaged[Thiscall]<ref GrowBuffer, UInt32, UInt32>)0x00406E20)(ref this, i_sizeNeeded); // .text:00406B20 ; unsigned int __thiscall GrowBuffer::GetGoodSize(GrowBuffer *this, unsigned int i_sizeNeeded) .text:00406B20 ?GetGoodSize@GrowBuffer@@QAEII@Z

        // GrowBuffer.GrowExact:
        public void GrowExact(UInt32 i_exactSize) => ((delegate* unmanaged[Thiscall]<ref GrowBuffer, UInt32, void>)0x00407250)(ref this, i_exactSize); // .text:00406F50 ; void __thiscall GrowBuffer::GrowExact(GrowBuffer *this, unsigned int i_exactSize) .text:00406F50 ?GrowExact@GrowBuffer@@QAEXI@Z

        // Globals:
        public static CSpinLock* m_pFreeListLock = *(CSpinLock**)0x00837798; // .data:00836798 ; CSpinLock<1048576,0> *GrowBuffer::m_pFreeListLock .data:00836798 ?m_pFreeListLock@GrowBuffer@@0PAV?$CSpinLock@$0BAAAAA@$0A@@@A
        public static UInt32* m_nFreeListEntries = (UInt32*)0x0083779C; // .data:0083679C ; unsigned int GrowBuffer::m_nFreeListEntries .data:0083679C ?m_nFreeListEntries@GrowBuffer@@0KA
        //public static `void __thiscall* GrowExact(unsigned int)'.`3'.`local static guard'{3}' = (`void __thiscall*)0x008377A0; // .data:008367A0 ; `public: void __thiscall GrowBuffer::GrowExact(unsigned int)'::`3'::`local static guard'{3}' .data:008367A0 ??_B?2??GrowExact@GrowBuffer@@QAEXI@Z@52
        public static GrowBuffer.FreeGrowBuffer** m_FreeList = (GrowBuffer.FreeGrowBuffer**)0x00837758; // .data:00836758 ; GrowBuffer::FreeGrowBuffer GrowBuffer::m_FreeList[8] .data:00836758 ?m_FreeList@GrowBuffer@@0PAUFreeGrowBuffer@1@A
    }
    public unsafe struct ArchiveVersionRow {
        // Struct:
        public ArchiveVersionRow.Vtbl* vfptr;
        public PrimitiveInplaceArray<ArchiveVersionRow.VersionEntry> m_aVersions;
        public override string ToString() => $"vfptr:->(ArchiveVersionRow.Vtbl*)0x{(int)vfptr:X8}, m_aVersions(PrimitiveInplaceArray<ArchiveVersionRow.VersionEntry,8,1>):{m_aVersions}";
        public unsafe struct VersionEntry {
            public UInt32 tokVersion;
            public UInt32 iVersion;
            public override string ToString() => $"tokVersion:{tokVersion:X8}, iVersion:{iVersion:X8}";
        }
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<ArchiveVersionRow*, UInt32, UInt32> GetVersionByToken; // unsigned int (__thiscall *GetVersionByToken)(ArchiveVersionRow *this, unsigned int);
        }

        // Functions:

        // ArchiveVersionRow.GetVersionByToken:
        public UInt32 GetVersionByToken(UInt32 i_tokVersion) => ((delegate* unmanaged[Thiscall]<ref ArchiveVersionRow, UInt32, UInt32>)0x004103B0)(ref this, i_tokVersion); // .text:004100F0 ; unsigned int __thiscall ArchiveVersionRow::GetVersionByToken(ArchiveVersionRow *this, unsigned int i_tokVersion) .text:004100F0 ?GetVersionByToken@ArchiveVersionRow@@UBEKK@Z

        // ArchiveVersionRow.SerializeFooter:
        public Byte SerializeFooter(UInt32 i_hSerialize, Archive* io_rcArchive) => ((delegate* unmanaged[Thiscall]<ref ArchiveVersionRow, UInt32, Archive*, Byte>)0x004106F0)(ref this, i_hSerialize, io_rcArchive); // .text:00410430 ; bool __thiscall ArchiveVersionRow::SerializeFooter(ArchiveVersionRow *this, unsigned int i_hSerialize, Archive *io_rcArchive) .text:00410430 ?SerializeFooter@ArchiveVersionRow@@QAE_NKAAVArchive@@@Z

        // ArchiveVersionRow.SerializeHeader:
        public UInt32 SerializeHeader(Archive* io_rcArchive) => ((delegate* unmanaged[Thiscall]<ref ArchiveVersionRow, Archive*, UInt32>)0x00410630)(ref this, io_rcArchive); // .text:00410370 ; unsigned int __thiscall ArchiveVersionRow::SerializeHeader(ArchiveVersionRow *this, Archive *io_rcArchive) .text:00410370 ?SerializeHeader@ArchiveVersionRow@@QAEKAAVArchive@@@Z

        // ArchiveVersionRow.SerializeRow:
        public void SerializeRow(Archive* io_rcArchive) => ((delegate* unmanaged[Thiscall]<ref ArchiveVersionRow, Archive*, void>)0x00410590)(ref this, io_rcArchive); // .text:004102D0 ; void __thiscall ArchiveVersionRow::SerializeRow(ArchiveVersionRow *this, Archive *io_rcArchive) .text:004102D0 ?SerializeRow@ArchiveVersionRow@@IAEXAAVArchive@@@Z

        // ArchiveVersionRow.SetVersion:
        public Byte SetVersion(UInt32 i_tokVersion, UInt32 i_iVersion) => ((delegate* unmanaged[Thiscall]<ref ArchiveVersionRow, UInt32, UInt32, Byte>)0x00410500)(ref this, i_tokVersion, i_iVersion); // .text:00410240 ; bool __thiscall ArchiveVersionRow::SetVersion(ArchiveVersionRow *this, unsigned int i_tokVersion, unsigned int i_iVersion) .text:00410240 ?SetVersion@ArchiveVersionRow@@QAE_NKK@Z
    }
    public unsafe struct AutoStoreVersionArchive {
        // Struct:
        public Archive a0;
        public AutoStoreVersionArchive.tagSerializeVersionRow m_SerializeVersionRow;
        public Byte m_bOnSerializingDoneCalled;
        public override string ToString() => $"a0(Archive):{a0}, m_SerializeVersionRow(AutoStoreVersionArchive.tagSerializeVersionRow):{m_SerializeVersionRow}, m_bOnSerializingDoneCalled:{m_bOnSerializingDoneCalled:X2}";
        public unsafe struct tagSerializeVersionRow {
            public ArchiveInitializer a0;
            public UInt32 m_hSerialize;
            public UInt32 m_hVersionRow;
            public ArchiveVersionRow m_rowInitialData;
            public override string ToString() => $"a0(ArchiveInitializer):{a0}, m_hSerialize:{m_hSerialize:X8}, m_hVersionRow(IDClass<_tagVersionHandle,32,0>):{m_hVersionRow}, m_rowInitialData(ArchiveVersionRow):{m_rowInitialData}";
        }

        // Functions:

        // AutoStoreVersionArchive.__Ctor:
        // public void __Ctor(Archive.tagUnpacking __formal, SmartBuffer* buff) => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, Archive.tagUnpacking, SmartBuffer*, void>)0xDEADBEEF)(ref this, __formal, buff); // .text:00446780 ; void __thiscall AutoStoreVersionArchive::AutoStoreVersionArchive(AutoStoreVersionArchive *this, Archive::tagUnpacking __formal, SmartBuffer *buff) .text:00446780 ??0AutoStoreVersionArchive@@QAE@W4tagUnpacking@Archive@@ABVSmartBuffer@@@Z

        // AutoStoreVersionArchive.__Ctor:
        public void __Ctor(Archive.tagUnpacking __formal, void* addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, Archive.tagUnpacking, void*, UInt32, void>)0x005D62C0)(ref this, __formal, addr, size); // .text:005D5170 ; void __thiscall AutoStoreVersionArchive::AutoStoreVersionArchive(AutoStoreVersionArchive *this, Archive::tagUnpacking __formal, void *addr, unsigned int size) .text:005D5170 ??0AutoStoreVersionArchive@@QAE@W4tagUnpacking@Archive@@PAXI@Z

        // AutoStoreVersionArchive.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, void>)0x0044CE60)(ref this); // .text:0044CCA0 ; void __thiscall AutoStoreVersionArchive::AutoStoreVersionArchive(AutoStoreVersionArchive *this) .text:0044CCA0 ??0AutoStoreVersionArchive@@QAE@XZ

        // AutoStoreVersionArchive.InitForPacking:
        // public void InitForPacking(ArchiveInitializer* i_rInitializer, SmartBuffer* i_buffer) => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, ArchiveInitializer*, SmartBuffer*, void>)0xDEADBEEF)(ref this, i_rInitializer, i_buffer); // .text:00446570 ; void __thiscall AutoStoreVersionArchive::InitForPacking(AutoStoreVersionArchive *this, ArchiveInitializer *i_rInitializer, SmartBuffer *i_buffer) .text:00446570 ?InitForPacking@AutoStoreVersionArchive@@MAEXABVArchiveInitializer@@ABVSmartBuffer@@@Z

        // AutoStoreVersionArchive.InitForPacking:
        // public void InitForPacking(ArchiveVersionRow* i_rowInitialData, SmartBuffer* i_buffer) => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, ArchiveVersionRow*, SmartBuffer*, void>)0xDEADBEEF)(ref this, i_rowInitialData, i_buffer); // .text:00446700 ; void __thiscall AutoStoreVersionArchive::InitForPacking(AutoStoreVersionArchive *this, ArchiveVersionRow *i_rowInitialData, SmartBuffer *i_buffer) .text:00446700 ?InitForPacking@AutoStoreVersionArchive@@UAEXABVArchiveVersionRow@@ABVSmartBuffer@@@Z

        // AutoStoreVersionArchive.InitForPacking:
        // public void InitForPacking(SmartBuffer* i_buffer) => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, SmartBuffer*, void>)0xDEADBEEF)(ref this, i_buffer); // .text:00446590 ; void __thiscall AutoStoreVersionArchive::InitForPacking(AutoStoreVersionArchive *this, SmartBuffer *i_buffer) .text:00446590 ?InitForPacking@AutoStoreVersionArchive@@UAEXABVSmartBuffer@@@Z

        // AutoStoreVersionArchive.InitForPacking:
        // public void InitForPacking(UInt32 i_iCoreVersion, SmartBuffer* i_buffer) => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, UInt32, SmartBuffer*, void>)0xDEADBEEF)(ref this, i_iCoreVersion, i_buffer); // .text:00446680 ; void __thiscall AutoStoreVersionArchive::InitForPacking(AutoStoreVersionArchive *this, unsigned int i_iCoreVersion, SmartBuffer *i_buffer) .text:00446680 ?InitForPacking@AutoStoreVersionArchive@@UAEXKABVSmartBuffer@@@Z

        // AutoStoreVersionArchive.InitForUnpacking:
        // public void InitForUnpacking(ArchiveInitializer* i_rInitializer, SmartBuffer* i_buffer) => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, ArchiveInitializer*, SmartBuffer*, void>)0xDEADBEEF)(ref this, i_rInitializer, i_buffer); // .text:00446580 ; void __thiscall AutoStoreVersionArchive::InitForUnpacking(AutoStoreVersionArchive *this, ArchiveInitializer *i_rInitializer, SmartBuffer *i_buffer) .text:00446580 ?InitForUnpacking@AutoStoreVersionArchive@@MAEXABVArchiveInitializer@@ABVSmartBuffer@@@Z

        // AutoStoreVersionArchive.InitForUnpacking:
        public void InitForUnpacking(SmartBuffer* i_buffer) => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, SmartBuffer*, void>)0x00446770)(ref this, i_buffer); // .text:00446610 ; void __thiscall AutoStoreVersionArchive::InitForUnpacking(AutoStoreVersionArchive *this, SmartBuffer *i_buffer) .text:00446610 ?InitForUnpacking@AutoStoreVersionArchive@@UAEXABVSmartBuffer@@@Z

        // AutoStoreVersionArchive.OnSerializingDone:
        // public void OnSerializingDone() => ((delegate* unmanaged[Thiscall]<ref AutoStoreVersionArchive, void>)0xDEADBEEF)(ref this); // .text:0065D850 ; void __thiscall AutoStoreVersionArchive::OnSerializingDone(AutoStoreVersionArchive *this) .text:0065D850 ?OnSerializingDone@AutoStoreVersionArchive@@QAEXXZ
    }
    public unsafe struct ArchiveInitializer {
        // Struct:
        public ArchiveInitializer.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(ArchiveInitializer.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<ArchiveInitializer*, Archive*, Byte> InitializeArchive; // bool (__thiscall *InitializeArchive)(ArchiveInitializer *this, Archive *);
        }
    }
    public unsafe struct CLCache {
        // Struct:
        public ThreadedCache a0;
        public CPluginManagerTemplate<CDDDStatusPlugin> a1;
        public SmartArray<PTR<DiskController>> m_DatFiles;
        public Byte m_fReadOnly;
        public Byte m_fEngineOnly;
        public UInt32 m_ridDDDRegion;
        public _E0971427BCD5BF40126DFC935D5F9371 m_DDDState;
        public SmartArray<MissingIteration> m_MissingIters;
        public AutoGrowHashTable<QualifiedDataID, PTR<MissingIteration>> m_PendingDownloads;
        public HashTable<UInt64, PTR<DiskController>> m_DatFileByIDTable;
        public SmartArray<QualifiedDataID> m_EarlySaves;
        public UInt32 m_cbEarlySaves;
        public UInt32 m_eNameRuleLanguage;
        public NIList<NetBlob>* m_pNetQueue;
        public PStringBase<UInt16> m_strDatFilePath;
        public override string ToString() => $"a0(ThreadedCache):{a0}, a1(CPluginManagerTemplate<CDDDStatusPlugin>):{a1}, m_DatFiles(SmartArray<DiskController*,1>):{m_DatFiles}, m_fReadOnly:{m_fReadOnly:X2}, m_fEngineOnly:{m_fEngineOnly:X2}, m_ridDDDRegion:{m_ridDDDRegion:X8}, m_DDDState(_E0971427BCD5BF40126DFC935D5F9371):{m_DDDState}, m_MissingIters(SmartArray<MissingIteration,1>):{m_MissingIters}, m_PendingDownloads(AutoGrowHashTable<QualifiedDataID,MissingIteration*>):{m_PendingDownloads}, m_DatFileByIDTable(HashTable<UInt64,DiskController*,0>):{m_DatFileByIDTable}, m_EarlySaves(SmartArray<QualifiedDataID,1>):{m_EarlySaves}, m_cbEarlySaves:{m_cbEarlySaves:X8}, m_eNameRuleLanguage:{m_eNameRuleLanguage:X8}, m_pNetQueue:->(NIList<NetBlob*>*)0x{(int)m_pNetQueue:X8}, m_strDatFilePath:{m_strDatFilePath}";
        public unsafe struct CAsyncBeginDDDRequest {
            public AsyncCache.CAsyncRequest a0;
            public override string ToString() => $"a0(AsyncCache.CAsyncRequest):{a0}";
        }
        // Enums:
        public enum CCLCacheAsyncOperation : UInt32 {
            opAsyncBeginDDD = 0x3,
            opCLCacheNextAsyncOperation = 0x4,
        };
        public enum DatFileIndex : UInt32 {
            PortalDatIndex = 0x0,
            LocalDatIndex = 0x1,
            CellDatIndex = 0x2,
            HighResDatIndex = 0x3,
            nDatFiles = 0x4,
        };

        // Functions:

        // CLCache.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CLCache, void>)0x004FCF90)(ref this); // .text:004FC3F0 ; void __thiscall CLCache::CLCache(CLCache *this) .text:004FC3F0 ??0CLCache@@QAE@XZ

        // CLCache.AdoptAndDeliverMessage:
        public TResult* AdoptAndDeliverMessage(TResult* result, FakeMessageData* i_FMD) => ((delegate* unmanaged[Thiscall]<ref CLCache, TResult*, FakeMessageData*, TResult*>)0x004F85B0)(ref this, result, i_FMD); // .text:004F7950 ; TResult *__thiscall CLCache::AdoptAndDeliverMessage(CLCache *this, TResult *result, FakeMessageData *i_FMD) .text:004F7950 ?AdoptAndDeliverMessage@CLCache@@IAE?AVTResult@@AAVFakeMessageData@@@Z

        // CLCache.AsyncGetFromOtherSources:
        public Byte AsyncGetFromOtherSources(QualifiedDataID* qdid, DBOCache* pObjCache) => ((delegate* unmanaged[Thiscall]<ref CLCache, QualifiedDataID*, DBOCache*, Byte>)0x004F8C50)(ref this, qdid, pObjCache); // .text:004F8010 ; bool __thiscall CLCache::AsyncGetFromOtherSources(CLCache *this, QualifiedDataID *qdid, DBOCache *pObjCache) .text:004F8010 ?AsyncGetFromOtherSources@CLCache@@MAE_NABUQualifiedDataID@@PAVDBOCache@@@Z

        // CLCache.AsyncSaveDDDMessage:
        public AsyncContext* AsyncSaveDDDMessage(AsyncContext* result, DDD_DataMessage* pEvent) => ((delegate* unmanaged[Thiscall]<ref CLCache, AsyncContext*, DDD_DataMessage*, AsyncContext*>)0x004F8E90)(ref this, result, pEvent); // .text:004F82F0 ; AsyncContext *__thiscall CLCache::AsyncSaveDDDMessage(CLCache *this, AsyncContext *result, DDD_DataMessage *pEvent) .text:004F82F0 ?AsyncSaveDDDMessage@CLCache@@MAE?AVAsyncContext@@PBVDDD_DataMessage@@@Z

        // CLCache.BlockingGet:
        // (ERR) .text:004F7F50 ; public: virtual class DBObj * __thiscall CLCache::BlockingGet(unsigned long,struct QualifiedDataID const &) .text:004F7F50 ?BlockingGet@CLCache@@UAEPAVDBObj@@KABUQualifiedDataID@@@Z

        // CLCache.GetDiskController:
        public DiskController* GetDiskController(QualifiedDataID* qdid, UInt64 idRequestedDatFile) => ((delegate* unmanaged[Thiscall]<ref CLCache, QualifiedDataID*, UInt64, DiskController*>)0x004F9B40)(ref this, qdid, idRequestedDatFile); // .text:004F8FA0 ; DiskController *__thiscall CLCache::GetDiskController(CLCache *this, QualifiedDataID *qdid, unsigned __int64 idRequestedDatFile) .text:004F8FA0 ?GetDiskController@CLCache@@MAEPAVDiskController@@ABUQualifiedDataID@@_K@Z

        // CLCache.Init:
        public Byte Init(PStringBase<char>* data_filename, Byte read_only_f, Byte cell_lru_f, Byte portal_lru_f, Byte engine_only_f, UInt32 local_lang_i, int region_i) => ((delegate* unmanaged[Thiscall]<ref CLCache, PStringBase<char>*, Byte, Byte, Byte, Byte, UInt32, int, Byte>)0x004FA8B0)(ref this, data_filename, read_only_f, cell_lru_f, portal_lru_f, engine_only_f, local_lang_i, region_i); // .text:004F9D10 ; bool __thiscall CLCache::Init(CLCache *this, PStringBase<char> *data_filename, bool read_only_f, bool cell_lru_f, bool portal_lru_f, bool engine_only_f, unsigned int local_lang_i, int region_i) .text:004F9D10 ?Init@CLCache@@UAE_NABV?$PStringBase@D@@_N111KJ@Z

        // CLCache.Init_Internal:
        public void Init_Internal() => ((delegate* unmanaged[Thiscall]<ref CLCache, void>)0x004FB850)(ref this); // .text:004FACB0 ; void __thiscall CLCache::Init_Internal(CLCache *this) .text:004FACB0 ?Init_Internal@CLCache@@MAEXXZ

        // CLCache.InqDatIDStamp:
        public Byte InqDatIDStamp(DatIDStamp* id_vstamp) => ((delegate* unmanaged[Thiscall]<ref CLCache, DatIDStamp*, Byte>)0x004F8570)(ref this, id_vstamp); // .text:004F7910 ; bool __thiscall CLCache::InqDatIDStamp(CLCache *this, DatIDStamp *id_vstamp) .text:004F7910 ?InqDatIDStamp@CLCache@@MBE_NAAVDatIDStamp@@@Z

        // CLCache.IsDatFileLoaded:
        public Byte IsDatFileLoaded(UInt64 idDatFile) => ((delegate* unmanaged[Thiscall]<ref CLCache, UInt64, Byte>)0x004F9C30)(ref this, idDatFile); // .text:004F9090 ; bool __thiscall CLCache::IsDatFileLoaded(CLCache *this, unsigned __int64 idDatFile) .text:004F9090 ?IsDatFileLoaded@CLCache@@UBE_N_K@Z

        // CLCache.LoadHighResDat:
        public void LoadHighResDat() => ((delegate* unmanaged[Thiscall]<ref CLCache, void>)0x004FADF0)(ref this); // .text:004FA250 ; void __thiscall CLCache::LoadHighResDat(CLCache *this) .text:004FA250 ?LoadHighResDat@CLCache@@IAEXXZ

        // CLCache.NotifyDDDEvent:
        public void NotifyDDDEvent(DDDEvent EventNum, UInt32 nBytes) => ((delegate* unmanaged[Thiscall]<ref CLCache, DDDEvent, UInt32, void>)0x004F8CB0)(ref this, EventNum, nBytes); // .text:004F8070 ; void __thiscall CLCache::NotifyDDDEvent(CLCache *this, DDDEvent EventNum, unsigned int nBytes) .text:004F8070 ?NotifyDDDEvent@CLCache@@IAEXW4DDDEvent@@I@Z

        // CLCache.OnBeginDDD:
        public void OnBeginDDD(DDD_BeginDDDMessage* pEvent) => ((delegate* unmanaged[Thiscall]<ref CLCache, DDD_BeginDDDMessage*, void>)0x004FA660)(ref this, pEvent); // .text:004F9AC0 ; void __thiscall CLCache::OnBeginDDD(CLCache *this, DDD_BeginDDDMessage *pEvent) .text:004F9AC0 ?OnBeginDDD@CLCache@@IAEXPBVDDD_BeginDDDMessage@@@Z

        // CLCache.OnBeginDDDRequestFinished:
        public void OnBeginDDDRequestFinished(CLCache.CAsyncBeginDDDRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref CLCache, CLCache.CAsyncBeginDDDRequest*, void>)0x004FB4E0)(ref this, pReq); // .text:004FA940 ; void __thiscall CLCache::OnBeginDDDRequestFinished(CLCache *this, CLCache::CAsyncBeginDDDRequest *pReq) .text:004FA940 ?OnBeginDDDRequestFinished@CLCache@@MAEXPAUCAsyncBeginDDDRequest@1@@Z

        // CLCache.OnEndDDD:
        public void OnEndDDD() => ((delegate* unmanaged[Thiscall]<ref CLCache, void>)0x004FB450)(ref this); // .text:004FA8B0 ; void __thiscall CLCache::OnEndDDD(CLCache *this) .text:004FA8B0 ?OnEndDDD@CLCache@@IAEXXZ

        // CLCache.OnRequestFinished:
        public void OnRequestFinished(AsyncCache.CAsyncRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref CLCache, AsyncCache.CAsyncRequest*, void>)0x004F7FA0)(ref this, pReq); // .text:004F7360 ; void __thiscall CLCache::OnRequestFinished(CLCache *this, AsyncCache::CAsyncRequest *pReq) .text:004F7360 ?OnRequestFinished@CLCache@@MAEXPAUCAsyncRequest@AsyncCache@@@Z

        // CLCache.OnSaveRequestFinished:
        public void OnSaveRequestFinished(CAsyncSaveRequest* pSaveReq) => ((delegate* unmanaged[Thiscall]<ref CLCache, CAsyncSaveRequest*, void>)0x004FCEB0)(ref this, pSaveReq); // .text:004FC310 ; void __thiscall CLCache::OnSaveRequestFinished(CLCache *this, CAsyncSaveRequest *pSaveReq) .text:004FC310 ?OnSaveRequestFinished@CLCache@@MAEXPAUCAsyncSaveRequest@@@Z

        // CLCache.OnServerInterrogation:
        public void OnServerInterrogation(DDD_InterrogationMessage* pEvent) => ((delegate* unmanaged[Thiscall]<ref CLCache, DDD_InterrogationMessage*, void>)0x004FAF80)(ref this, pEvent); // .text:004FA3E0 ; void __thiscall CLCache::OnServerInterrogation(CLCache *this, DDD_InterrogationMessage *pEvent) .text:004FA3E0 ?OnServerInterrogation@CLCache@@IAEXPBVDDD_InterrogationMessage@@@Z

        // CLCache.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rInterfaceType, void** o_ppOutInterface) => ((delegate* unmanaged[Thiscall]<ref CLCache, TResult*, Turbine_GUID*, void**, TResult*>)0x004F8380)(ref this, result, i_rInterfaceType, o_ppOutInterface); // .text:004F7720 ; TResult *__thiscall CLCache::QueryInterface(CLCache *this, TResult *result, Turbine_GUID *i_rInterfaceType, void **o_ppOutInterface) .text:004F7720 ?QueryInterface@CLCache@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // CLCache.ReloadObject:
        // (ERR) .text:004F7F60 ; public: virtual bool __thiscall CLCache::ReloadObject(class IDClass<struct _tagDataID,32,0>,unsigned long) .text:004F7F60 ?ReloadObject@CLCache@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // CLCache.RemovePendingDownload:
        public Byte RemovePendingDownload(QualifiedDataID* qdid) => ((delegate* unmanaged[Thiscall]<ref CLCache, QualifiedDataID*, Byte>)0x004FB290)(ref this, qdid); // .text:004FA6F0 ; bool __thiscall CLCache::RemovePendingDownload(CLCache *this, QualifiedDataID *qdid) .text:004FA6F0 ?RemovePendingDownload@CLCache@@IAE_NABUQualifiedDataID@@@Z

        // CLCache.ResetCache:
        public void ResetCache() => ((delegate* unmanaged[Thiscall]<ref CLCache, void>)0x004F7F40)(ref this); // .text:004F7300 ; void __thiscall CLCache::ResetCache(CLCache *this) .text:004F7300 ?ResetCache@CLCache@@UAEXXZ

        // CLCache.SetLanguageInternal:
        public Byte SetLanguageInternal(UInt32 language_l, Byte engine_only) => ((delegate* unmanaged[Thiscall]<ref CLCache, UInt32, Byte, Byte>)0x004F95F0)(ref this, language_l, engine_only); // .text:004F8A50 ; bool __thiscall CLCache::SetLanguageInternal(CLCache *this, unsigned int language_l, bool engine_only) .text:004F8A50 ?SetLanguageInternal@CLCache@@MAE_NK_N@Z

        // CLCache.SetNetQueue:
        public void SetNetQueue(NIList<NetBlob>* pQueue) => ((delegate* unmanaged[Thiscall]<ref CLCache, NIList<NetBlob>*, void>)0x004F7F70)(ref this, pQueue); // .text:004F7330 ; void __thiscall CLCache::SetNetQueue(CLCache *this, NIList<NetBlob *> *pQueue) .text:004F7330 ?SetNetQueue@CLCache@@QAEXPAV?$NIList@PAVNetBlob@@@@@Z

        // CLCache.SetRegion:
        public Byte SetRegion(UInt32 rid) => ((delegate* unmanaged[Thiscall]<ref CLCache, UInt32, Byte>)0x004F92D0)(ref this, rid); // .text:004F8730 ; bool __thiscall CLCache::SetRegion(CLCache *this, unsigned int rid) .text:004F8730 ?SetRegion@CLCache@@UAE_NK@Z

        // CLCache.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref CLCache, void>)0x004FCBE0)(ref this); // .text:004FC040 ; void __thiscall CLCache::UseTime(CLCache *this) .text:004FC040 ?UseTime@CLCache@@UAEXXZ

        // CLCache.WorkerExecuteBeginDDDRequest:
        public void WorkerExecuteBeginDDDRequest(CLCache.CAsyncBeginDDDRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref CLCache, CLCache.CAsyncBeginDDDRequest*, void>)0x004F8430)(ref this, pReq); // .text:004F77D0 ; void __thiscall CLCache::WorkerExecuteBeginDDDRequest(CLCache *this, CLCache::CAsyncBeginDDDRequest *pReq) .text:004F77D0 ?WorkerExecuteBeginDDDRequest@CLCache@@MAEXPAUCAsyncBeginDDDRequest@1@@Z

        // CLCache.WorkerExecuteRequest:
        public void WorkerExecuteRequest(AsyncCache.CAsyncRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref CLCache, AsyncCache.CAsyncRequest*, void>)0x004F7F80)(ref this, pReq); // .text:004F7340 ; void __thiscall CLCache::WorkerExecuteRequest(CLCache *this, AsyncCache::CAsyncRequest *pReq) .text:004F7340 ?WorkerExecuteRequest@CLCache@@MAEXPAUCAsyncRequest@AsyncCache@@@Z
    }
    public unsafe struct FakeMessageData {
        // Struct:
        public FakeMessageData.Vtbl* vfptr;
        public UInt32 m_et;
        public override string ToString() => $"vfptr:->(FakeMessageData.Vtbl*)0x{(int)vfptr:X8}, m_et:{m_et:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<FakeMessageData*, Archive*, void> Serialize; // void (__thiscall *Serialize)(FakeMessageData *this, Archive *);
        }

        // Functions:

        // FakeMessageData.Serialize:
        public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref FakeMessageData, Archive*, void>)0x004F8310)(ref this, io_archive); // .text:004F76B0 ; void __thiscall FakeMessageData::Serialize(FakeMessageData *this, Archive *io_archive) .text:004F76B0 ?Serialize@FakeMessageData@@UAEXAAVArchive@@@Z
    }
    public unsafe struct DDD_BeginDDDMessage {
        // Struct:
        public FakeMessageData a0;
        public UInt32 m_cbDataExpected;
        public SmartArray<MissingIteration> m_MissingIterations;
        public override string ToString() => $"a0(FakeMessageData):{a0}, m_cbDataExpected:{m_cbDataExpected:X8}, m_MissingIterations(SmartArray<MissingIteration,1>):{m_MissingIterations}";

        // Functions:

        // DDD_BeginDDDMessage.Serialize:
        public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref DDD_BeginDDDMessage, Archive*, void>)0x004FA6E0)(ref this, io_archive); // .text:004F9B40 ; void __thiscall DDD_BeginDDDMessage::Serialize(DDD_BeginDDDMessage *this, Archive *io_archive) .text:004F9B40 ?Serialize@DDD_BeginDDDMessage@@UAEXAAVArchive@@@Z
    }
    public unsafe struct MissingIteration {
        // Struct:
        public MissingIteration.Vtbl* vfptr;
        public UInt64 idDatFile;
        public int idIteration;
        public SmartArray<QualifiedDataID> IDsToDownload;
        public SmartArray<QualifiedDataID> IDsToPurge;
        public override string ToString() => $"vfptr:->(MissingIteration.Vtbl*)0x{(int)vfptr:X8}, idDatFile(UInt64):{idDatFile}, idIteration(int):{idIteration}, IDsToDownload(SmartArray<QualifiedDataID,1>):{IDsToDownload}, IDsToPurge(SmartArray<QualifiedDataID,1>):{IDsToPurge}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<MissingIteration*, Archive*, void> Serialize; // void (__thiscall *Serialize)(MissingIteration *this, Archive *);
        }

        // Functions:

        // MissingIteration.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref MissingIteration, void>)0x004F8CF0)(ref this); // .text:004F8170 ; void __thiscall MissingIteration::MissingIteration(MissingIteration *this) .text:004F8170 ??0MissingIteration@@QAE@XZ

        // MissingIteration.operator_equals:
        public MissingIteration* operator_equals() => ((delegate* unmanaged[Thiscall]<ref MissingIteration, MissingIteration*>)0x004F9AE0)(ref this); // .text:004F8F40 ; public: class MissingIteration & __thiscall MissingIteration::operator=(class MissingIteration const &) .text:004F8F40 ??4MissingIteration@@QAEAAV0@ABV0@@Z

        // MissingIteration.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref MissingIteration, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:006717B0 ; void __thiscall MissingIteration::Serialize(MissingIteration *this, Archive *io_archive) .text:006717B0 ?Serialize@MissingIteration@@UAEXAAVArchive@@@Z
    }

    public unsafe struct DDD_InterrogationMessage {
        // Struct:
        public FakeMessageData a0;
        public UInt32 m_dwServersRegion;
        public UInt32 m_NameRuleLanguage;
        public UInt32 m_dwProductID;
        public SmartArray<UInt32> m_SupportedLanguages;
        public override string ToString() => $"a0(FakeMessageData):{a0}, m_dwServersRegion:{m_dwServersRegion:X8}, m_NameRuleLanguage:{m_NameRuleLanguage:X8}, m_dwProductID:{m_dwProductID:X8}, m_SupportedLanguages(SmartArray<UInt32,1>):{m_SupportedLanguages}";

        // Functions:

        // DDD_InterrogationMessage.Serialize:
        public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref DDD_InterrogationMessage, Archive*, void>)0x004F9190)(ref this, io_archive); // .text:004F85F0 ; void __thiscall DDD_InterrogationMessage::Serialize(DDD_InterrogationMessage *this, Archive *io_archive) .text:004F85F0 ?Serialize@DDD_InterrogationMessage@@UAEXAAVArchive@@@Z
    }

    public unsafe struct DDD_DataMessage {
        // Struct:
        public FakeMessageData a0;
        public UInt64 m_idDatFile;
        public QualifiedDataID m_qdid;
        public Cache_Pack_t m_cpData;
        public int m_idIteration;
        public Byte m_bCompressed;
        public override string ToString() => $"a0(FakeMessageData):{a0}, m_idDatFile(UInt64):{m_idDatFile}, m_qdid(QualifiedDataID):{m_qdid}, m_cpData(Cache_Pack_t):{m_cpData}, m_idIteration(int):{m_idIteration}, m_bCompressed:{m_bCompressed:X2}";

        // Functions:

        // DDD_DataMessage.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref DDD_DataMessage, void>)0xDEADBEEF)(ref this); // .text:004F76F0 ; void __thiscall DDD_DataMessage::DDD_DataMessage(DDD_DataMessage *this) .text:004F76F0 ??0DDD_DataMessage@@QAE@XZ

        // DDD_DataMessage.GetCompressedSize:
        public UInt32 GetCompressedSize() => ((delegate* unmanaged[Thiscall]<ref DDD_DataMessage, UInt32>)0x004F7F20)(ref this); // .text:004F72E0 ; unsigned int __thiscall DDD_DataMessage::GetCompressedSize(DDD_DataMessage *this) .text:004F72E0 ?GetCompressedSize@DDD_DataMessage@@QBEIXZ

        // DDD_DataMessage.Serialize:
        public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref DDD_DataMessage, Archive*, void>)0x004F8820)(ref this, io_archive); // .text:004F7BE0 ; void __thiscall DDD_DataMessage::Serialize(DDD_DataMessage *this, Archive *io_archive) .text:004F7BE0 ?Serialize@DDD_DataMessage@@UAEXAAVArchive@@@Z
    }


    public unsafe struct Cache_Pack_t {
        // Struct:
        public int m_dwOffset;
        public UInt32 m_iVersion;
        public SmartBuffer m_buff;
        public override string ToString() => $"m_dwOffset(int):{m_dwOffset}, m_iVersion:{m_iVersion:X8}, m_buff(SmartBuffer):{m_buff}";

        // Functions:

        // Cache_Pack_t.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Cache_Pack_t, void>)0xDEADBEEF)(ref this); // .text:00417350 ; void __thiscall Cache_Pack_t::Cache_Pack_t(Cache_Pack_t *this) .text:00417350 ??0Cache_Pack_t@@QAE@XZ

        // Cache_Pack_t.operator_equals:
        // public Cache_Pack_t* operator_equals() => ((delegate* unmanaged[Thiscall]<ref Cache_Pack_t, Cache_Pack_t*>)0xDEADBEEF)(ref this); // .text:004173F0 ; public: class Cache_Pack_t & __thiscall Cache_Pack_t::operator=(class Cache_Pack_t const &) .text:004173F0 ??4Cache_Pack_t@@QAEAAV0@ABV0@@Z

        // Cache_Pack_t.GetDataSize:
        // public UInt32 GetDataSize() => ((delegate* unmanaged[Thiscall]<ref Cache_Pack_t, UInt32>)0xDEADBEEF)(ref this); // .text:00417390 ; unsigned int __thiscall Cache_Pack_t::GetDataSize(Cache_Pack_t *this) .text:00417390 ?GetDataSize@Cache_Pack_t@@QBEKXZ

        // Cache_Pack_t.GetPackBufferPtr:
        // public char* GetPackBufferPtr() => ((delegate* unmanaged[Thiscall]<ref Cache_Pack_t, char*>)0xDEADBEEF)(ref this); // .text:00417370 ; char *__thiscall Cache_Pack_t::GetPackBufferPtr(Cache_Pack_t *this) .text:00417370 ?GetPackBufferPtr@Cache_Pack_t@@QAEPAEXZ

        // Cache_Pack_t.SerializeOrWindow:
        public void SerializeOrWindow(Archive* io_rcArchive) => ((delegate* unmanaged[Thiscall]<ref Cache_Pack_t, Archive*, void>)0x004F88C0)(ref this, io_rcArchive); // .text:004F7C80 ; void __thiscall Cache_Pack_t::SerializeOrWindow(Cache_Pack_t *this, Archive *io_rcArchive) .text:004F7C80 ?SerializeOrWindow@Cache_Pack_t@@QAEXAAVArchive@@@Z

        // Cache_Pack_t.UpdatePackedSize:
        // public void UpdatePackedSize(SmartBuffer* i_buff) => ((delegate* unmanaged[Thiscall]<ref Cache_Pack_t, SmartBuffer*, void>)0xDEADBEEF)(ref this, i_buff); // .text:006704A0 ; void __thiscall Cache_Pack_t::UpdatePackedSize(Cache_Pack_t *this, SmartBuffer *i_buff) .text:006704A0 ?UpdatePackedSize@Cache_Pack_t@@QAEXABVSmartBuffer@@@Z
    }
    public unsafe struct ThreadedCache {
        // Struct:
        public DBCache a0;
        public PortalThread a1;
        public LFQueue<PTR<AsyncCache.CAsyncRequest>> m_WorkerThreadJobQueue;
        public LFQueue<PTR<AsyncCache.CAsyncRequest>> m_WorkerThreadReplyQueue;
        public PortalEvent m_evtWorkerHasJobs;
        public override string ToString() => $"a0(DBCache):{a0}, a1(PortalThread):{a1}, m_WorkerThreadJobQueue(LFQueue<AsyncCache.CAsyncRequest*>):{m_WorkerThreadJobQueue}, m_WorkerThreadReplyQueue(LFQueue<AsyncCache.CAsyncRequest*>):{m_WorkerThreadReplyQueue}, m_evtWorkerHasJobs(PortalEvent):{m_evtWorkerHasJobs}";

        // Functions:

        // ThreadedCache.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, void>)0xDEADBEEF)(ref this); // .text:00677AF0 ; void __thiscall ThreadedCache::ThreadedCache(ThreadedCache *this) .text:00677AF0 ??0ThreadedCache@@QAE@XZ

        // ThreadedCache.AsyncGetInternal:
        // public void AsyncGetInternal(CAsyncGetRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, CAsyncGetRequest*, void>)0xDEADBEEF)(ref this, pReq); // .text:00677A30 ; void __thiscall ThreadedCache::AsyncGetInternal(ThreadedCache *this, CAsyncGetRequest *pReq) .text:00677A30 ?AsyncGetInternal@ThreadedCache@@IAEXPAUCAsyncGetRequest@@@Z

        // ThreadedCache.EnqueueAsyncRequest:
        public void EnqueueAsyncRequest(AsyncCache.CAsyncRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, AsyncCache.CAsyncRequest*, void>)0x00678C60)(ref this, pReq); // .text:00677C00 ; void __thiscall ThreadedCache::EnqueueAsyncRequest(ThreadedCache *this, AsyncCache::CAsyncRequest *pReq) .text:00677C00 ?EnqueueAsyncRequest@ThreadedCache@@MAEXPAUCAsyncRequest@AsyncCache@@@Z

        // ThreadedCache.PutOnWorkerThreadJobQueue:
        // public void PutOnWorkerThreadJobQueue(AsyncCache.CAsyncRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, AsyncCache.CAsyncRequest*, void>)0xDEADBEEF)(ref this, pReq); // .text:00677980 ; void __thiscall ThreadedCache::PutOnWorkerThreadJobQueue(ThreadedCache *this, AsyncCache::CAsyncRequest *pReq) .text:00677980 ?PutOnWorkerThreadJobQueue@ThreadedCache@@IAEXPAUCAsyncRequest@AsyncCache@@@Z

        // ThreadedCache.SetShutdown:
        public Byte SetShutdown(Byte shut_f) => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, Byte, Byte>)0x006785E0)(ref this, shut_f); // .text:00677580 ; bool __thiscall ThreadedCache::SetShutdown(ThreadedCache *this, bool shut_f) .text:00677580 ?SetShutdown@ThreadedCache@@UAE_N_N@Z

        // ThreadedCache.Startup:
        public int Startup() => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, int>)0x00678960)(ref this); // .text:00677900 ; int __thiscall ThreadedCache::Startup(ThreadedCache *this) .text:00677900 ?Startup@ThreadedCache@@MAEHXZ

        // ThreadedCache.StopThread:
        public void StopThread() => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, void>)0x00678610)(ref this); // .text:006775B0 ; void __thiscall ThreadedCache::StopThread(ThreadedCache *this) .text:006775B0 ?StopThread@ThreadedCache@@UAEXXZ

        // ThreadedCache.UseTime:
        // public void UseTime() => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, void>)0xDEADBEEF)(ref this); // .text:006779B0 ; void __thiscall ThreadedCache::UseTime(ThreadedCache *this) .text:006779B0 ?UseTime@ThreadedCache@@UAEXXZ

        // ThreadedCache.WakeForTheReaper:
        public void WakeForTheReaper() => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, void>)0x00678630)(ref this); // .text:006775D0 ; void __thiscall ThreadedCache::WakeForTheReaper(ThreadedCache *this) .text:006775D0 ?WakeForTheReaper@ThreadedCache@@MAEXXZ

        // ThreadedCache.WorkerExecuteGetRequest:
        public void WorkerExecuteGetRequest(CAsyncGetRequest* pGetReq) => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, CAsyncGetRequest*, void>)0x00678640)(ref this, pGetReq); // .text:006775E0 ; void __thiscall ThreadedCache::WorkerExecuteGetRequest(ThreadedCache *this, CAsyncGetRequest *pGetReq) .text:006775E0 ?WorkerExecuteGetRequest@ThreadedCache@@MAEXPAUCAsyncGetRequest@@@Z

        // ThreadedCache.WorkerExecutePurgeRequest:
        public void WorkerExecutePurgeRequest(CAsyncPurgeRequest* pPurgeReq) => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, CAsyncPurgeRequest*, void>)0x00678670)(ref this, pPurgeReq); // .text:00677610 ; void __thiscall ThreadedCache::WorkerExecutePurgeRequest(ThreadedCache *this, CAsyncPurgeRequest *pPurgeReq) .text:00677610 ?WorkerExecutePurgeRequest@ThreadedCache@@MAEXPAUCAsyncPurgeRequest@@@Z

        // ThreadedCache.WorkerExecuteRequest:
        public void WorkerExecuteRequest(AsyncCache.CAsyncRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, AsyncCache.CAsyncRequest*, void>)0x006785B0)(ref this, pReq); // .text:00677550 ; void __thiscall ThreadedCache::WorkerExecuteRequest(ThreadedCache *this, AsyncCache::CAsyncRequest *pReq) .text:00677550 ?WorkerExecuteRequest@ThreadedCache@@MAEXPAUCAsyncRequest@AsyncCache@@@Z

        // ThreadedCache.WorkerExecuteSaveRequest:
        public void WorkerExecuteSaveRequest(CAsyncSaveRequest* pSaveReq) => ((delegate* unmanaged[Thiscall]<ref ThreadedCache, CAsyncSaveRequest*, void>)0x006786A0)(ref this, pSaveReq); // .text:00677640 ; void __thiscall ThreadedCache::WorkerExecuteSaveRequest(ThreadedCache *this, CAsyncSaveRequest *pSaveReq) .text:00677640 ?WorkerExecuteSaveRequest@ThreadedCache@@MAEXPAUCAsyncSaveRequest@@@Z
    }
    public unsafe struct PortalEvent {
        // Struct:
        public void* eventHandle_;
        public override string ToString() => $"eventHandle_:->(void*)0x{(int)eventHandle_:X8}";

        // Functions:

        // PortalEvent.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref PortalEvent, void>)0xDEADBEEF)(ref this); // .text:0065DAE0 ; void __thiscall PortalEvent::PortalEvent(PortalEvent *this) .text:0065DAE0 ??0PortalEvent@@QAE@XZ

        // PortalEvent.Signal:
        // public Byte Signal() => ((delegate* unmanaged[Thiscall]<ref PortalEvent, Byte>)0xDEADBEEF)(ref this); // .text:0065DB20 ; bool __thiscall PortalEvent::Signal(PortalEvent *this) .text:0065DB20 ?Signal@PortalEvent@@QAE_NXZ

        // PortalEvent.WaitForSignal:
        // public Byte WaitForSignal(UInt32 milliseconds) => ((delegate* unmanaged[Thiscall]<ref PortalEvent, UInt32, Byte>)0xDEADBEEF)(ref this, milliseconds); // .text:0065DB30 ; bool __thiscall PortalEvent::WaitForSignal(PortalEvent *this, unsigned int milliseconds) .text:0065DB30 ?WaitForSignal@PortalEvent@@QAE_NK@Z
    }
    public unsafe struct PortalThread {
        // Struct:
        public PortalThread.Vtbl* vfptr;
        public void* m_hThread;
        public UInt32 m_idThread;
        public Byte m_fThreadRunning;
        public Byte m_fShouldExit;
        public Byte m_fThreadHasEverRun;
        public override string ToString() => $"vfptr:->(PortalThread.Vtbl*)0x{(int)vfptr:X8}, m_hThread:->(void*)0x{(int)m_hThread:X8}, m_idThread:{m_idThread:X8}, m_fThreadRunning:{m_fThreadRunning:X2}, m_fShouldExit:{m_fShouldExit:X2}, m_fThreadHasEverRun:{m_fThreadHasEverRun:X2}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<PortalThread*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(PortalThread *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<PortalThread*, int> Startup; // int (__thiscall *Startup)(PortalThread *this);
            public static delegate* unmanaged[Thiscall]<PortalThread*, Byte, void> SetShouldExit; // void (__thiscall *SetShouldExit)(PortalThread *this, bool);
            public static delegate* unmanaged[Thiscall]<PortalThread*, void> WakeForTheReaper; // void (__thiscall *WakeForTheReaper)(PortalThread *this);
        }

        // Functions:

        // PortalThread.__Ctor:
        // public void __Ctor(UInt32 i_defaultStackSize) => ((delegate* unmanaged[Thiscall]<ref PortalThread, UInt32, void>)0xDEADBEEF)(ref this, i_defaultStackSize); // .text:0065DA90 ; void __thiscall PortalThread::PortalThread(PortalThread *this, unsigned int i_defaultStackSize) .text:0065DA90 ??0PortalThread@@QAE@I@Z

        // PortalThread.Join:
        // public Byte Join() => ((delegate* unmanaged[Thiscall]<ref PortalThread, Byte>)0xDEADBEEF)(ref this); // .text:0065D9E0 ; bool __thiscall PortalThread::Join(PortalThread *this) .text:0065D9E0 ?Join@PortalThread@@QAE_NXZ

        // PortalThread.Resume:
        // public Byte Resume() => ((delegate* unmanaged[Thiscall]<ref PortalThread, Byte>)0xDEADBEEF)(ref this); // .text:0065D9A0 ; bool __thiscall PortalThread::Resume(PortalThread *this) .text:0065D9A0 ?Resume@PortalThread@@QAE_NXZ

        // PortalThread.SetShouldExit:
        public void SetShouldExit(Byte fExit) => ((delegate* unmanaged[Thiscall]<ref PortalThread, Byte, void>)0x004FCB90)(ref this, fExit); // .text:004FBFF0 ; void __thiscall PortalThread::SetShouldExit(PortalThread *this, bool fExit) .text:004FBFF0 ?SetShouldExit@PortalThread@@UAEX_N@Z

        // PortalThread._portal_startup:
        // public UInt32 _portal_startup() => ((delegate* unmanaged[Thiscall]<ref PortalThread, UInt32>)0xDEADBEEF)(ref this); // .text:0065DA50 ; unsigned int __stdcall PortalThread::_portal_startup(void *i_lpdwparam) .text:0065DA50 ?_portal_startup@PortalThread@@SGKPAX@Z
    }
    public unsafe struct DBCache {
        // Struct:
        public Interface a0;
        public AsyncCache a1;
        public Turbine_RefCount m_cTurbineRefCount;
        public UInt32 m_MasterMapID;
        public UInt32 m_CurrentRegion;
        public UInt32 m_LocalLanguage;
        public Byte m_bRuntime;
        public Byte m_bIsClient;
        public Byte m_bIsServer;
        public IDataGraph* m_pDataGraph;
        public override string ToString() => $"a0(Interface):{a0}, a1(AsyncCache):{a1}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, m_MasterMapID:{m_MasterMapID:X8}, m_CurrentRegion:{m_CurrentRegion:X8}, m_LocalLanguage:{m_LocalLanguage:X8}, m_bRuntime:{m_bRuntime:X2}, m_bIsClient:{m_bIsClient:X2}, m_bIsServer:{m_bIsServer:X2}, m_pDataGraph:->(IDataGraph*)0x{(int)m_pDataGraph:X8}";

        // Functions:

        // DBCache.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref DBCache, void>)0x00415320)(ref this); // .text:00415080 ; void __thiscall DBCache::DBCache(DBCache *this) .text:00415080 ??0DBCache@@QAE@XZ

        // DBCache.AddRef:
        public UInt32 AddRef() => ((delegate* unmanaged[Thiscall]<ref DBCache, UInt32>)0x00415270)(ref this); // .text:00414FD0 ; unsigned int __thiscall DBCache::AddRef(DBCache *this) .text:00414FD0 ?AddRef@DBCache@@UBEKXZ

        // DBCache.AddToDataGraph:
        public static void AddToDataGraph(DBObj* obj) => ((delegate* unmanaged[Cdecl]<DBObj*, void>)0x00413DE0)(obj); // .text:00413B30 ; void __cdecl DBCache::AddToDataGraph(DBObj *obj) .text:00413B30 ?AddToDataGraph@DBCache@@SAXPBVDBObj@@@Z

        // DBCache.AskForLastWords:
        public void AskForLastWords() => ((delegate* unmanaged[Thiscall]<ref DBCache, void>)0x00414480)(ref this); // .text:00414180 ; void __thiscall DBCache::AskForLastWords(DBCache *this) .text:00414180 ?AskForLastWords@DBCache@@UAEXXZ

        // DBCache.DestroyObjectCaches:
        public void DestroyObjectCaches() => ((delegate* unmanaged[Thiscall]<ref DBCache, void>)0x00415040)(ref this); // .text:00414CE0 ; void __thiscall DBCache::DestroyObjectCaches(DBCache *this) .text:00414CE0 ?DestroyObjectCaches@DBCache@@MAEXXZ

        // DBCache.FlushFreeObjects:
        public void FlushFreeObjects(UInt32 db_type) => ((delegate* unmanaged[Thiscall]<ref DBCache, UInt32, void>)0x004144E0)(ref this, db_type); // .text:004141E0 ; void __thiscall DBCache::FlushFreeObjects(DBCache *this, unsigned int db_type) .text:004141E0 ?FlushFreeObjects@DBCache@@QAEXK@Z

        // DBCache.Get:
        public static DBObj* Get(UInt32 did, UInt32 dbtype) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, DBObj*>)0x00413B80)(did, dbtype); // .text:004138D0 ; DBObj *__cdecl DBCache::Get(IDClass<_tagDataID,32,0> did, unsigned int dbtype) .text:004138D0 ?Get@DBCache@@SAPAVDBObj@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // DBCache.GetCurrentRegion:
        public static Byte GetCurrentRegion(UInt32* region_num) => ((delegate* unmanaged[Cdecl]<UInt32*, Byte>)0x00413A50)(region_num); // .text:004137A0 ; bool __cdecl DBCache::GetCurrentRegion(unsigned int *region_num) .text:004137A0 ?GetCurrentRegion@DBCache@@SA_NAAK@Z

        // DBCache.GetDBOCache:
        public static DBOCache* GetDBOCache(UInt32 dbtype) => ((delegate* unmanaged[Cdecl]<UInt32, DBOCache*>)0x00414590)(dbtype); // .text:00414290 ; DBOCache *__cdecl DBCache::GetDBOCache(unsigned int dbtype) .text:00414290 ?GetDBOCache@DBCache@@SAPAVDBOCache@@K@Z

        // DBCache.GetDBOCache:
        public DBOCache* GetDBOCache() => ((delegate* unmanaged[Thiscall]<ref DBCache, DBOCache*>)0x004146B0)(ref this); // .text:004143B0 ; DBOCache *__thiscall DBCache::GetDBOCache(QualifiedDataID *qdid) .text:004143B0 ?GetDBOCache@DBCache@@UAEPAVDBOCache@@ABUQualifiedDataID@@@Z

        // DBCache.GetDIDFromEnum:
        public UInt32* GetDIDFromEnum(UInt32* result, int enum_id, int enum_group) => ((delegate* unmanaged[Thiscall]<ref DBCache, UInt32*, int, int, UInt32*>)0x00413BF0)(ref this, result, enum_id, enum_group); // .text:00413940 ; IDClass<_tagDataID,32,0> *__thiscall DBCache::GetDIDFromEnum(DBCache *this, IDClass<_tagDataID,32,0> *result, int enum_id, int enum_group) .text:00413940 ?GetDIDFromEnum@DBCache@@UAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@JJ@Z

        // DBCache.GetDIDFromEnumStatic:
        public static UInt32* GetDIDFromEnumStatic(UInt32* result, int enum_id, int enum_group) => ((delegate* unmanaged[Cdecl]<UInt32*, int, int, UInt32*>)0x00413BC0)(result, enum_id, enum_group); // .text:00413910 ; IDClass<_tagDataID,32,0> *__cdecl DBCache::GetDIDFromEnumStatic(IDClass<_tagDataID,32,0> *result, int enum_id, int enum_group) .text:00413910 ?GetDIDFromEnumStatic@DBCache@@SA?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@JJ@Z

        // DBCache.GetFromEnum:
        public DBObj* GetFromEnum(int enum_id, int enum_group, UInt32 dbtype) => ((delegate* unmanaged[Thiscall]<ref DBCache, int, int, UInt32, DBObj*>)0x00413CC0)(ref this, enum_id, enum_group, dbtype); // .text:00413A10 ; DBObj *__thiscall DBCache::GetFromEnum(DBCache *this, int enum_id, int enum_group, unsigned int dbtype) .text:00413A10 ?GetFromEnum@DBCache@@UAEPAVDBObj@@JJK@Z

        // DBCache.GetFromEnumStatic:
        public static DBObj* GetFromEnumStatic(int enum_id, int enum_group, UInt32 cache_index) => ((delegate* unmanaged[Cdecl]<int, int, UInt32, DBObj*>)0x00413A00)(enum_id, enum_group, cache_index); // .text:00413750 ; DBObj *__cdecl DBCache::GetFromEnumStatic(int enum_id, int enum_group, unsigned int cache_index) .text:00413750 ?GetFromEnumStatic@DBCache@@SAPAVDBObj@@JJK@Z

        // DBCache.GetLocalLanguage:
        public static UInt32 GetLocalLanguage() => ((delegate* unmanaged[Cdecl]<UInt32>)0x00413B00)(); // .text:00413850 ; unsigned int __cdecl DBCache::GetLocalLanguage() .text:00413850 ?GetLocalLanguage@DBCache@@SAKXZ

        // DBCache.Init:
        public Byte Init(Byte _bRequireProjectSettings, PStringBase<char>* i_strSearchPath) => ((delegate* unmanaged[Thiscall]<ref DBCache, Byte, PStringBase<char>*, Byte>)0x004141E0)(ref this, _bRequireProjectSettings, i_strSearchPath); // .text:00413EE0 ; bool __thiscall DBCache::Init(DBCache *this, bool _bRequireProjectSettings, PStringBase<char> *i_strSearchPath) .text:00413EE0 ?Init@DBCache@@IAE_N_NABV?$PStringBase@D@@@Z

        // DBCache.IsClient:
        public static Byte IsClient() => ((delegate* unmanaged[Cdecl]<Byte>)0x00413A90)(); // .text:004137E0 ; bool __cdecl DBCache::IsClient() .text:004137E0 ?IsClient@DBCache@@SA_NXZ

        // DBCache.IsLoader:
        public Byte IsLoader() => ((delegate* unmanaged[Thiscall]<ref DBCache, Byte>)0x006A1050)(ref this); // .text:006A0230 ; bool __thiscall DBCache::IsLoader(gmNoticeHandler *this) .text:006A0230 ?IsLoader@DBCache@@UBE_NXZ

        // DBCache.IsRunTime:
        public static Byte IsRunTime() => ((delegate* unmanaged[Cdecl]<Byte>)0x00413A70)(); // .text:004137C0 ; bool __cdecl DBCache::IsRunTime() .text:004137C0 ?IsRunTime@DBCache@@SA_NXZ

        // DBCache.IsServer:
        public static Byte IsServer() => ((delegate* unmanaged[Cdecl]<Byte>)0x00413AB0)(); // .text:00413800 ; bool __cdecl DBCache::IsServer() .text:00413800 ?IsServer@DBCache@@SA_NXZ

        // DBCache.KeepFreeObjects:
        public Byte KeepFreeObjects(Byte keep_f, UInt32 db_type) => ((delegate* unmanaged[Thiscall]<ref DBCache, Byte, UInt32, Byte>)0x00414620)(ref this, keep_f, db_type); // .text:00414320 ; bool __thiscall DBCache::KeepFreeObjects(DBCache *this, bool keep_f, unsigned int db_type) .text:00414320 ?KeepFreeObjects@DBCache@@QAE_N_NK@Z

        // DBCache.PreFetch:
        public CACHE_OBJECT_CODES PreFetch(QualifiedDataID* qdid) => ((delegate* unmanaged[Thiscall]<ref DBCache, QualifiedDataID*, CACHE_OBJECT_CODES>)0x00414FE0)(ref this, qdid); // .text:00414C80 ; CACHE_OBJECT_CODES __thiscall DBCache::PreFetch(DBCache *this, QualifiedDataID *qdid) .text:00414C80 ?PreFetch@DBCache@@UAE?AW4CACHE_OBJECT_CODES@@ABUQualifiedDataID@@@Z

        // DBCache.PreFetchStatic:
        public static CACHE_OBJECT_CODES PreFetchStatic(QualifiedDataID* qdid) => ((delegate* unmanaged[Cdecl]<QualifiedDataID*, CACHE_OBJECT_CODES>)0x00413A30)(qdid); // .text:00413780 ; CACHE_OBJECT_CODES __cdecl DBCache::PreFetchStatic(QualifiedDataID *qdid) .text:00413780 ?PreFetchStatic@DBCache@@SA?AW4CACHE_OBJECT_CODES@@ABUQualifiedDataID@@@Z

        // DBCache.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppObject) => ((delegate* unmanaged[Thiscall]<ref DBCache, TResult*, Turbine_GUID*, void**, TResult*>)0x00415210)(ref this, result, i_rcInterface, o_ppObject); // .text:00414F70 ; TResult *__thiscall DBCache::QueryInterface(DBCache *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppObject) .text:00414F70 ?QueryInterface@DBCache@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // DBCache.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref DBCache, UInt32>)0x00415280)(ref this); // .text:00414FE0 ; unsigned int __thiscall DBCache::Release(DBCache *this) .text:00414FE0 ?Release@DBCache@@UBEKXZ

        // DBCache.ReloadObject:
        public Byte ReloadObject(UInt32 did, UInt32 dbtype) => ((delegate* unmanaged[Thiscall]<ref DBCache, UInt32, UInt32, Byte>)0x00413D20)(ref this, did, dbtype); // .text:00413A70 ; bool __thiscall DBCache::ReloadObject(DBCache *this, IDClass<_tagDataID,32,0> did, unsigned int dbtype) .text:00413A70 ?ReloadObject@DBCache@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // DBCache.ResetCache:
        public void ResetCache() => ((delegate* unmanaged[Thiscall]<ref DBCache, void>)0x004139D0)(ref this); // .text:00413720 ; void __thiscall DBCache::ResetCache(DBCache *this) .text:00413720 ?ResetCache@DBCache@@UAEXXZ

        // DBCache.SetLocalLanguage:
        public static Byte SetLocalLanguage(UInt32 language_l, Byte engine_only) => ((delegate* unmanaged[Cdecl]<UInt32, Byte, Byte>)0x00413AE0)(language_l, engine_only); // .text:00413830 ; bool __cdecl DBCache::SetLocalLanguage(unsigned int language_l, bool engine_only) .text:00413830 ?SetLocalLanguage@DBCache@@SA_NK_N@Z

        // DBCache.SetMasterMapDID:
        public UInt32* SetMasterMapDID(UInt32* result, UInt32 master_id) => ((delegate* unmanaged[Thiscall]<ref DBCache, UInt32*, UInt32, UInt32*>)0x00413B60)(ref this, result, master_id); // .text:004138B0 ; IDClass<_tagDataID,32,0> *__thiscall DBCache::SetMasterMapDID(DBCache *this, IDClass<_tagDataID,32,0> *result, IDClass<_tagDataID,32,0> master_id) .text:004138B0 ?SetMasterMapDID@DBCache@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@V2@@Z

        // DBCache.SetRegion:
        public Byte SetRegion(UInt32 rid) => ((delegate* unmanaged[Thiscall]<ref DBCache, UInt32, Byte>)0x00413AD0)(ref this, rid); // .text:00413820 ; bool __thiscall DBCache::SetRegion(DBCache *this, unsigned int rid) .text:00413820 ?SetRegion@DBCache@@UAE_NK@Z

        // DBCache.SetShutdown:
        public Byte SetShutdown(Byte shut_f) => ((delegate* unmanaged[Thiscall]<ref DBCache, Byte, Byte>)0x004152B0)(ref this, shut_f); // .text:00415010 ; bool __thiscall DBCache::SetShutdown(DBCache *this, bool shut_f) .text:00415010 ?SetShutdown@DBCache@@UAE_N_N@Z

        // DBCache.UnloadCellData:
        public Byte UnloadCellData() => ((delegate* unmanaged[Thiscall]<ref DBCache, Byte>)0x004143F0)(ref this); // .text:004140F0 ; bool __thiscall DBCache::UnloadCellData(DBCache *this) .text:004140F0 ?UnloadCellData@DBCache@@UAE_NXZ

        // DBCache.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref DBCache, void>)0x00414390)(ref this); // .text:00414090 ; void __thiscall DBCache::UseTime(DBCache *this) .text:00414090 ?UseTime@DBCache@@UAEXXZ

        // Globals:
        public static DBCache** s_pCache = (DBCache**)0x00837BAC; // .data:00836BAC ; DBCache *DBCache::s_pCache .data:00836BAC ?s_pCache@DBCache@@0PAV1@A
        public static int* s_EngDataPackVer = (int*)0x008185E8; // .data:008175E8 ; int DBCache::s_EngDataPackVer .data:008175E8 ?s_EngDataPackVer@DBCache@@1JA
                                                                // public static int* s_EngCellPackVer = (int*)0xDEADBEEF; // .data:008175EC ; int DBCache::s_EngCellPackVer .data:008175EC ?s_EngCellPackVer@DBCache@@1JA
        public static int* s_GameDataPackVer = (int*)0x008185F0; // .data:008175F0 ; int DBCache::s_GameDataPackVer .data:008175F0 ?s_GameDataPackVer@DBCache@@1JA
        public static int* s_GameCellPackVer = (int*)0x008185F4; // .data:008175F4 ; int DBCache::s_GameCellPackVer .data:008175F4 ?s_GameCellPackVer@DBCache@@1JA
        public static int* s_GameDidPackVer = (int*)0x008185F8; // .data:008175F8 ; int DBCache::s_GameDidPackVer .data:008175F8 ?s_GameDidPackVer@DBCache@@1JA
                                                                // public static HashTable<UInt32,DBOCache*,0>* s_ObjCache = (HashTable<UInt32,DBOCache*,0>*)0xDEADBEEF; // .data:00817608 ; HashTable<unsigned long,DBOCache *,0> DBCache::s_ObjCache .data:00817608 ?s_ObjCache@DBCache@@1V?$HashTable@KPAVDBOCache@@$0A@@@A
                                                                // public static Byte* s_bCacheInitialized = (Byte*)0xDEADBEEF; // .data:00836BA8 ; bool DBCache::s_bCacheInitialized .data:00836BA8 ?s_bCacheInitialized@DBCache@@1_NA
    }

    public unsafe struct LFQueue<T> where T : unmanaged {
        // Struct:
        public T* buckets_;
        public int numBuckets_;
        public volatile int m_dwProducerBucketIndex;
        public volatile int m_dwConsumerBucketIndex;
        public _List<T> m_backupList;
        public int m_dwBackupListLen;
        public SharedCriticalSection m_backupListCritSec;
        public override string ToString() => $"buckets_:->(WinInetAsyncHttpClient.HttpDownloadEvent**)0x{(int)buckets_:X8}, numBuckets_(int):{numBuckets_}, m_dwProducerBucketIndex(volatile int):{m_dwProducerBucketIndex}, m_dwConsumerBucketIndex(volatile int):{m_dwConsumerBucketIndex}, m_backupList(List<WinInetAsyncHttpClient.HttpDownloadEvent*>):{m_backupList}, m_dwBackupListLen(int):{m_dwBackupListLen}, m_backupListCritSec(SharedCriticalSection):{m_backupListCritSec}";

        // Functions:

        // LFQueue.Consume<AsyncCache::CAsyncRequest *>:
        // public Byte Consume(AsyncCache.CAsyncRequest** retVal) => ((delegate* unmanaged[Thiscall]<ref LFQueue<T>, AsyncCache.CAsyncRequest**, Byte>)0xDEADBEEF)(ref this, retVal); // .text:00677830 ; bool __thiscall LFQueue<AsyncCache::CAsyncRequest *>::Consume(LFQueue<AsyncCache::CAsyncRequest *> *this, AsyncCache::CAsyncRequest **retVal) .text:00677830 ?Consume@?$LFQueue@PAUCAsyncRequest@AsyncCache@@@@QAE_NAAPAUCAsyncRequest@AsyncCache@@@Z

        // LFQueue.Produce<AsyncCache::CAsyncRequest *>:
        // public void Produce(AsyncCache.CAsyncRequest* toAdd) => ((delegate* unmanaged[Thiscall]<ref LFQueue<T>, AsyncCache.CAsyncRequest*, void>)0xDEADBEEF)(ref this, toAdd); // .text:006776D0 ; void __thiscall LFQueue<AsyncCache::CAsyncRequest *>::Produce(LFQueue<AsyncCache::CAsyncRequest *> *this, AsyncCache::CAsyncRequest *toAdd) .text:006776D0 ?Produce@?$LFQueue@PAUCAsyncRequest@AsyncCache@@@@QAEXPAUCAsyncRequest@AsyncCache@@@Z
    }
    public unsafe struct SharedCriticalSection {
        // Struct:
        public SharedCriticalSection.Vtbl* vfptr;
        public _RTL_CRITICAL_SECTION myCritSection_;
        public UInt32 lockHolder_;
        public int lockCount_;
        public override string ToString() => $"vfptr:->(SharedCriticalSection.Vtbl*)0x{(int)vfptr:X8}, myCritSection_(_RTL_CRITICAL_SECTION):{myCritSection_}, lockHolder_:{lockHolder_:X8}, lockCount_(int):{lockCount_}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<SharedCriticalSection*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(SharedCriticalSection *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<SharedCriticalSection*, void> EnterCriticalSection; // void (__thiscall *EnterCriticalSection)(SharedCriticalSection *this);
        }

        // Functions:

        // SharedCriticalSection.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref SharedCriticalSection, void>)0x0065E8B0)(ref this); // .text:0065D8B0 ; void __thiscall SharedCriticalSection::SharedCriticalSection(SharedCriticalSection *this) .text:0065D8B0 ??0SharedCriticalSection@@QAE@XZ

        // SharedCriticalSection.EnterCriticalSection:
        // public void EnterCriticalSection() => ((delegate* unmanaged[Thiscall]<ref SharedCriticalSection, void>)0xDEADBEEF)(ref this); // .text:0065D8F0 ; void __thiscall SharedCriticalSection::EnterCriticalSection(SharedCriticalSection *this) .text:0065D8F0 ?EnterCriticalSection@SharedCriticalSection@@UAEXXZ

        // SharedCriticalSection.LeaveCriticalSection:
        public void LeaveCriticalSection() => ((delegate* unmanaged[Thiscall]<ref SharedCriticalSection, void>)0x0065E910)(ref this); // .text:0065D910 ; void __thiscall SharedCriticalSection::LeaveCriticalSection(SharedCriticalSection *this) .text:0065D910 ?LeaveCriticalSection@SharedCriticalSection@@QAEXXZ
    }
    public unsafe struct _RTL_CRITICAL_SECTION {
        // Struct:
        public _RTL_CRITICAL_SECTION_DEBUG* DebugInfo;
        public int LockCount;
        public int RecursionCount;
        public void* OwningThread;
        public void* LockSemaphore;
        public UInt32 SpinCount;
        public override string ToString() => $"DebugInfo:->(_RTL_CRITICAL_SECTION_DEBUG*)0x{(int)DebugInfo:X8}, LockCount(int):{LockCount}, RecursionCount(int):{RecursionCount}, OwningThread:->(void*)0x{(int)OwningThread:X8}, LockSemaphore:->(void*)0x{(int)LockSemaphore:X8}, SpinCount:{SpinCount:X8}";
    }
    public unsafe struct _RTL_CRITICAL_SECTION_DEBUG {
        // Struct:
        public UInt16 Type;
        public UInt16 CreatorBackTraceIndex;
        public _RTL_CRITICAL_SECTION* CriticalSection;
        public _LIST_ENTRY ProcessLocksList;
        public UInt32 EntryCount;
        public UInt32 ContentionCount;
        public fixed int Spare[2];
        public override string ToString() => $"Type:{Type:X4}, CreatorBackTraceIndex:{CreatorBackTraceIndex:X4}, CriticalSection:->(_RTL_CRITICAL_SECTION*)0x{(int)CriticalSection:X8}, ProcessLocksList(_LIST_ENTRY):{ProcessLocksList}, EntryCount:{EntryCount:X8}, ContentionCount:{ContentionCount:X8}, Spare[0]{Spare[0]}, Spare[1]{Spare[1]}";
    }
    public unsafe struct _LIST_ENTRY {
        // Struct:
        public _LIST_ENTRY* Flink;
        public _LIST_ENTRY* Blink;
        public override string ToString() => $"Flink:->(_LIST_ENTRY*)0x{(int)Flink:X8}, Blink:->(_LIST_ENTRY*)0x{(int)Blink:X8}";
    }


    public unsafe struct AsyncCache {
        // Struct:
        public AsyncCache.Vtbl* vfptr;
        public TDynamicCircularArray<PTR<AsyncCache.CCallbackHandler>> m_PendingCallbacks;
        public AutoGrowHashTable<QualifiedDataID, PTR<CAsyncGetRequest>> m_PendingGets;
        public AutoGrowHashTable<AsyncContext, PTR<AsyncCache.CCallbackHandler>> m_BusyCallbacks;
        public UInt32 dwNextCallbackHandle;
        public Byte m_bCallingPendingCallbacks;
        public override string ToString() => $"vfptr:->(AsyncCache.Vtbl*)0x{(int)vfptr:X8}, m_PendingCallbacks(TDynamicCircularArray<AsyncCache.CCallbackHandler*>):{m_PendingCallbacks}, m_PendingGets(AutoGrowHashTable<QualifiedDataID,CAsyncGetRequest*>):{m_PendingGets}, m_BusyCallbacks(AutoGrowHashTable<AsyncContext,AsyncCache.CCallbackHandler*>):{m_BusyCallbacks}, dwNextCallbackHandle:{dwNextCallbackHandle:X8}, m_bCallingPendingCallbacks:{m_bCallingPendingCallbacks:X2}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<AsyncCache*, UInt32, QualifiedDataID*, DBObj*> BlockingGet; // DBObj *(__thiscall *BlockingGet)(AsyncCache *this, unsigned int, QualifiedDataID *);
            public fixed byte gap4[16];
            public static delegate* unmanaged[Thiscall]<AsyncCache*, AsyncContext*, UInt32, QualifiedDataID*, AsyncCacheCallback*, UInt32, AsyncContext*> AsyncGet; // AsyncContext *(__thiscall *AsyncGet)(AsyncCache *this, AsyncContext *result, unsigned int, QualifiedDataID *, AsyncCacheCallback *, unsigned int);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, AsyncContext*, UInt32, QualifiedDataIDArray*, AsyncCacheCallback*, UInt32, void> AsyncGetImmediate; // void (__thiscall *AsyncGetImmediate)(AsyncCache *this, AsyncContext *, unsigned int, QualifiedDataIDArray *, AsyncCacheCallback *, unsigned int);
            public int padding;
            public int ___u3;
            /*
             union _057219C29536B16641D5FD4644809F83
{
  AsyncContext *(__thiscall *AsyncPurge)(AsyncCache *this, AsyncContext *result, QualifiedDataIDArray *, AsyncCacheCallback *, unsigned int);
  AsyncContext *(__thiscall *AsyncPurge)(AsyncCache *this, AsyncContext *result, QualifiedDataID *, AsyncCacheCallback *, unsigned int);
};

            */
            public static delegate* unmanaged[Thiscall]<AsyncCache*, AsyncContext*, QualifiedDataID*, Cache_Pack_t*, UInt64, AsyncCacheCallback*, UInt32, AsyncContext*> AsyncSave; // AsyncContext *(__thiscall *AsyncSave)(AsyncCache *this, AsyncContext *result, QualifiedDataID *, Cache_Pack_t *, unsigned __int64, AsyncCacheCallback *, unsigned int);
            public fixed byte gap28[8];
            public int ___u5;
            /*
             union _5292DD2149E0F06195D8716AB1932F6B
{
  bool (__thiscall *AddToAsyncGet)(AsyncCache *this, unsigned int, QualifiedDataIDArray *, void *);
  bool (__thiscall *AddToAsyncGet)(AsyncCache *this, AsyncContext, SmartArray<_STL::pair<unsigned long,QualifiedDataIDArray>,1> *);
  bool (__thiscall *AddToAsyncGet)(AsyncCache *this, AsyncContext, unsigned int, QualifiedDataIDArray *);
};

            */
            public static delegate* unmanaged[Thiscall]<AsyncCache*, AsyncContext, void> ReleaseContext; // void (__thiscall *ReleaseContext)(AsyncCache *this, AsyncContext);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, DBOCache*> GetDBOCache; // DBOCache *(__thiscall *GetDBOCache)(AsyncCache *this, QualifiedDataID *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, Byte> IsOnDisk; // bool (__thiscall *IsOnDisk)(AsyncCache *this, QualifiedDataID *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataIDArray*, Byte> AreOnDisk; // bool (__thiscall *AreOnDisk)(AsyncCache *this, QualifiedDataIDArray *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, void> UseTime; // void (__thiscall *UseTime)(AsyncCache *this) __declspec(align(8));
            public static delegate* unmanaged[Thiscall]<AsyncCache*, CAsyncGetRequest*, void> HashAndEnqueue; // void (__thiscall *HashAndEnqueue)(AsyncCache *this, CAsyncGetRequest *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, AsyncCache.CAsyncRequest*, void> EnqueueAsyncRequest; // void (__thiscall *EnqueueAsyncRequest)(AsyncCache *this, AsyncCache::CAsyncRequest *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, CAsyncGetRequest*, CAsyncGetRequest*, void> UnhashPendingGet; // void (__thiscall *UnhashPendingGet)(AsyncCache *this, CAsyncGetRequest *, CAsyncGetRequest *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, void> FlushPendingRequests; // void (__thiscall *FlushPendingRequests)(AsyncCache *this);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, AsyncCache.CAsyncRequest*, void> OnRequestFinished; // void (__thiscall *OnRequestFinished)(AsyncCache *this, AsyncCache::CAsyncRequest *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, CAsyncGetRequest*, void> OnGetRequestFinished; // void (__thiscall *OnGetRequestFinished)(AsyncCache *this, CAsyncGetRequest *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, CAsyncSaveRequest*, void> OnSaveRequestFinished; // void (__thiscall *OnSaveRequestFinished)(AsyncCache *this, CAsyncSaveRequest *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, CAsyncPurgeRequest*, void> OnPurgeRequestFinished; // void (__thiscall *OnPurgeRequestFinished)(AsyncCache *this, CAsyncPurgeRequest *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, AsyncCache.CAsyncRequest*, void> NotifyCallback; // void (__thiscall *NotifyCallback)(AsyncCache *this, AsyncCache::CAsyncRequest *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, CAsyncGetRequest*, void> OnAsyncGetFinished; // void (__thiscall *OnAsyncGetFinished)(AsyncCache *this, CAsyncGetRequest *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, void> CallPendingCallbacks; // void (__thiscall *CallPendingCallbacks)(AsyncCache *this);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, DBOCache*, DBObj*> BlockingGetFromDisk; // DBObj *(__thiscall *BlockingGetFromDisk)(AsyncCache *this, QualifiedDataID *, DBOCache *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, DBObj*, QualifiedDataID*, DBOCache*, Byte> BlockingLoadInto; // bool (__thiscall *BlockingLoadInto)(AsyncCache *this, DBObj *, QualifiedDataID *, DBOCache *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, DBObj*, Cache_Pack_t*, Byte> SerializeFromCachePack; // bool (__thiscall *SerializeFromCachePack)(AsyncCache *this, DBObj *, Cache_Pack_t *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, DBOCache*, DBObj*> GetIfInMemory; // DBObj *(__thiscall *GetIfInMemory)(AsyncCache *this, QualifiedDataID *, DBOCache *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, DBOCache*, DBObj*> GetFreeObj; // DBObj *(__thiscall *GetFreeObj)(AsyncCache *this, QualifiedDataID *, DBOCache *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, DBOCache*, Byte> AsyncGetFromOtherSources; // bool (__thiscall *AsyncGetFromOtherSources)(AsyncCache *this, QualifiedDataID *, DBOCache *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, void> OnAsyncGetFromOtherSourcesFailed; // void (__thiscall *OnAsyncGetFromOtherSourcesFailed)(AsyncCache *this, QualifiedDataID *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, DBObj*, DBOCache*, Byte> AddObjToDBOCache; // bool (__thiscall *AddObjToDBOCache)(AsyncCache *this, DBObj *, DBOCache *);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, UInt64, DiskController*> GetDiskController; // DiskController *(__thiscall *GetDiskController)(AsyncCache *this, QualifiedDataID *, unsigned __int64);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, Cache_Pack_t*, UInt64, Byte> LoadData; // bool (__thiscall *LoadData)(AsyncCache *this, QualifiedDataID *, Cache_Pack_t *, unsigned __int64);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, Cache_Pack_t*, UInt64, Byte> SaveData; // bool (__thiscall *SaveData)(AsyncCache *this, QualifiedDataID *, Cache_Pack_t *, unsigned __int64);
            public static delegate* unmanaged[Thiscall]<AsyncCache*, QualifiedDataID*, UInt64, Byte> PurgeData; // bool (__thiscall *PurgeData)(AsyncCache *this, QualifiedDataID *, unsigned __int64);
            public override string ToString() => $"gap4[16](fixed int):{gap4[16]}, ___u3(__declspec(align(8)) _057219C29536B16641D5FD4644809F83):{___u3}, gap28[8](fixed int):{gap28[8]}, ___u5(_5292DD2149E0F06195D8716AB1932F6B):{___u5}";
        }
        public unsafe struct CCallbackHandler {
            public Turbine_RefCount a0;
            public int m_nRequestsPending;
            public AsyncCacheCallback* m_pCallbackPlugin;
            public AsyncResult m_AccumulatedResults;
            public UInt32 m_dwUser1;
            public SmartArray<PTR<AsyncCache.CAsyncRequest>> m_TopLevelReqs;
            public AsyncContext m_hContext;
            public Byte m_bContextFinished;
            public override string ToString() => $"a0(Turbine_RefCount):{a0}, m_nRequestsPending(int):{m_nRequestsPending}, m_pCallbackPlugin:->(AsyncCacheCallback*)0x{(int)m_pCallbackPlugin:X8}, m_AccumulatedResults(AsyncResult):{m_AccumulatedResults}, m_dwUser1:{m_dwUser1:X8}, m_TopLevelReqs(SmartArray<AsyncCache.CAsyncRequest*,1>):{m_TopLevelReqs}, m_hContext(AsyncContext):{m_hContext}, m_bContextFinished:{m_bContextFinished:X2}";
        }
        public unsafe struct CAsyncRequest {
            public Turbine_RefCount a0;
            public AsyncResult Result;
            public AsyncCache.AsyncOperation eOp; // union unsigned int Op;
            public QualifiedDataID qdid;
            public SmartArray<AsyncCache.CAsyncRequest.CCallbackWrapper> m_pCallbacks;
            public DBObj* m_pObj;
            public override string ToString() => $"a0(Turbine_RefCount):{a0}, Result(AsyncResult):{Result}, eOp(AsyncCache.AsyncOperation):{eOp}, qdid(QualifiedDataID):{qdid}, m_pCallbacks(SmartArray<AsyncCache.CAsyncRequest.CCallbackWrapper,1>):{m_pCallbacks}, m_pObj:->(DBObj*)0x{(int)m_pObj:X8}";
            public unsafe struct CCallbackWrapper {
                public AsyncCache.CCallbackHandler* pCallbackHandler;
                public UInt32 dwTimesFinished;
            }

        }
        public unsafe struct CCallbackWrapper {
            public AsyncCache.CCallbackHandler* pCallbackHandler;
            public UInt32 dwTimesFinished;
            public override string ToString() => $"pCallbackHandler:->(AsyncCache.CCallbackHandler*)0x{(int)pCallbackHandler:X8}, dwTimesFinished:{dwTimesFinished:X8}";
        }
        // Enums:
        public enum AsyncOperation : UInt32 {
            opAsyncGet = 0x0,
            opAsyncPurge = 0x1,
            opAsyncSave = 0x2,
            opAsyncCacheNextAsyncOperation = 0x3,
        };

        // Functions:

        // AsyncCache.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref AsyncCache, void>)0x0041A210)(ref this); // .text:00419F50 ; void __thiscall AsyncCache::AsyncCache(AsyncCache *this) .text:00419F50 ??0AsyncCache@@QAE@XZ

        // AsyncCache.AddObjToDBOCache:
        public Byte AddObjToDBOCache(DBObj* pObj, DBOCache* pObjCache) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, DBObj*, DBOCache*, Byte>)0x00417720)(ref this, pObj, pObjCache); // .text:00417470 ; bool __thiscall AsyncCache::AddObjToDBOCache(AsyncCache *this, DBObj *pObj, DBOCache *pObjCache) .text:00417470 ?AddObjToDBOCache@AsyncCache@@MAE_NPAVDBObj@@PAVDBOCache@@@Z

        // AsyncCache.AddToAsyncGet:
        public Byte AddToAsyncGet(UInt32 type, QualifiedDataIDArray* qdids, void* hInternal) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, UInt32, QualifiedDataIDArray*, void*, Byte>)0x00419FF0)(ref this, type, qdids, hInternal); // .text:00419D90 ; bool __thiscall AsyncCache::AddToAsyncGet(AsyncCache *this, unsigned int type, QualifiedDataIDArray *qdids, void *hInternal) .text:00419D90 ?AddToAsyncGet@AsyncCache@@UAE_NKABVQualifiedDataIDArray@@PAX@Z

        // AsyncCache.AddToAsyncGet:
        public Byte AddToAsyncGet(AsyncContext context, SmartArray<_STL.Pair<UInt32, QualifiedDataIDArray>>* qdids) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext, SmartArray<_STL.Pair<UInt32, QualifiedDataIDArray>>*, Byte>)0x00418EC0)(ref this, context, qdids); // .text:00418C60 ; bool __thiscall AsyncCache::AddToAsyncGet(AsyncCache *this, AsyncContext context, SmartArray<_STL::pair<unsigned long,QualifiedDataIDArray>,1> *qdids) .text:00418C60 ?AddToAsyncGet@AsyncCache@@UAE_NVAsyncContext@@ABV?$SmartArray@U?$pair@KVQualifiedDataIDArray@@@_STL@@$00@@@Z

        // AsyncCache.AddToAsyncGet:
        public Byte AddToAsyncGet(AsyncContext context, UInt32 type, QualifiedDataIDArray* qdids) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext, UInt32, QualifiedDataIDArray*, Byte>)0x00418CF0)(ref this, context, type, qdids); // .text:00418A90 ; bool __thiscall AsyncCache::AddToAsyncGet(AsyncCache *this, AsyncContext context, unsigned int type, QualifiedDataIDArray *qdids) .text:00418A90 ?AddToAsyncGet@AsyncCache@@UAE_NVAsyncContext@@KABVQualifiedDataIDArray@@@Z

        // AsyncCache.AllocateCallback:
        // public AsyncCache.CCallbackHandler* AllocateCallback(AsyncCacheCallback* pCallbackPlugin, UInt32 dwUser1, UInt32 nRequests) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncCacheCallback*, UInt32, UInt32, AsyncCache.CCallbackHandler*>)0xDEADBEEF)(ref this, pCallbackPlugin, dwUser1, nRequests); // .text:00419330 ; AsyncCache::CCallbackHandler *__thiscall AsyncCache::AllocateCallback(AsyncCache *this, AsyncCacheCallback *pCallbackPlugin, unsigned int dwUser1, unsigned int nRequests) .text:00419330 ?AllocateCallback@AsyncCache@@IAEPAVCCallbackHandler@1@PAVAsyncCacheCallback@@KK@Z

        // AsyncCache.AreOnDisk:
        public Byte AreOnDisk(QualifiedDataIDArray* qdids) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataIDArray*, Byte>)0x00417F60)(ref this, qdids); // .text:00417CB0 ; bool __thiscall AsyncCache::AreOnDisk(AsyncCache *this, QualifiedDataIDArray *qdids) .text:00417CB0 ?AreOnDisk@AsyncCache@@UAE_NABVQualifiedDataIDArray@@@Z

        // AsyncCache.AsyncGet:
        public AsyncContext* AsyncGet(AsyncContext* result, UInt32 type, QualifiedDataID* qdid, AsyncCacheCallback* pCallbackPlugin, UInt32 dwUser1) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext*, UInt32, QualifiedDataID*, AsyncCacheCallback*, UInt32, AsyncContext*>)0x00419640)(ref this, result, type, qdid, pCallbackPlugin, dwUser1); // .text:00419440 ; AsyncContext *__thiscall AsyncCache::AsyncGet(AsyncCache *this, AsyncContext *result, unsigned int type, QualifiedDataID *qdid, AsyncCacheCallback *pCallbackPlugin, unsigned int dwUser1) .text:00419440 ?AsyncGet@AsyncCache@@UAE?AVAsyncContext@@KABUQualifiedDataID@@PAVAsyncCacheCallback@@K@Z

        // AsyncCache.AsyncGet:
        public AsyncContext* AsyncGet(AsyncContext* result, UInt32 type, QualifiedDataIDArray* qdids, AsyncCacheCallback* pCallbackPlugin, UInt32 dwUser1) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext*, UInt32, QualifiedDataIDArray*, AsyncCacheCallback*, UInt32, AsyncContext*>)0x004196F0)(ref this, result, type, qdids, pCallbackPlugin, dwUser1); // .text:004194F0 ; AsyncContext *__thiscall AsyncCache::AsyncGet(AsyncCache *this, AsyncContext *result, unsigned int type, QualifiedDataIDArray *qdids, AsyncCacheCallback *pCallbackPlugin, unsigned int dwUser1) .text:004194F0 ?AsyncGet@AsyncCache@@UAE?AVAsyncContext@@KABVQualifiedDataIDArray@@PAVAsyncCacheCallback@@K@Z

        // AsyncCache.AsyncGetFromOtherSources:
        public Byte AsyncGetFromOtherSources(Single i_nMin, Single i_nMax) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, Single, Single, Byte>)0x006A1040)(ref this, i_nMin, i_nMax); // .text:006A0220 ; bool __thiscall AsyncCache::AsyncGetFromOtherSources(UIPreferenceItem *this, const float i_nMin, const float i_nMax) .text:006A0220 ?AsyncGetFromOtherSources@AsyncCache@@MAE_NABUQualifiedDataID@@PAVDBOCache@@@Z

        // AsyncCache.AsyncGetImmediate:
        public void AsyncGetImmediate(AsyncContext* o_context, UInt32 type, QualifiedDataIDArray* qdids, AsyncCacheCallback* pCallbackPlugin, UInt32 dwUser1) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext*, UInt32, QualifiedDataIDArray*, AsyncCacheCallback*, UInt32, void>)0x00417EA0)(ref this, o_context, type, qdids, pCallbackPlugin, dwUser1); // .text:00417BF0 ; void __thiscall AsyncCache::AsyncGetImmediate(AsyncCache *this, AsyncContext *o_context, unsigned int type, QualifiedDataIDArray *qdids, AsyncCacheCallback *pCallbackPlugin, unsigned int dwUser1) .text:00417BF0 ?AsyncGetImmediate@AsyncCache@@UAEXAAVAsyncContext@@KABVQualifiedDataIDArray@@PAVAsyncCacheCallback@@K@Z

        // AsyncCache.AsyncPurge:
        public AsyncContext* AsyncPurge(AsyncContext* result, QualifiedDataID* qdid, AsyncCacheCallback* pCallbackPlugin, UInt32 dwUser1) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext*, QualifiedDataID*, AsyncCacheCallback*, UInt32, AsyncContext*>)0x00419850)(ref this, result, qdid, pCallbackPlugin, dwUser1); // .text:00419650 ; AsyncContext *__thiscall AsyncCache::AsyncPurge(AsyncCache *this, AsyncContext *result, QualifiedDataID *qdid, AsyncCacheCallback *pCallbackPlugin, unsigned int dwUser1) .text:00419650 ?AsyncPurge@AsyncCache@@UAE?AVAsyncContext@@ABUQualifiedDataID@@PAVAsyncCacheCallback@@K@Z

        // AsyncCache.AsyncPurge:
        public AsyncContext* AsyncPurge(AsyncContext* result, QualifiedDataIDArray* qdids, AsyncCacheCallback* pCallbackPlugin, UInt32 dwUser1) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext*, QualifiedDataIDArray*, AsyncCacheCallback*, UInt32, AsyncContext*>)0x00419940)(ref this, result, qdids, pCallbackPlugin, dwUser1); // .text:00419740 ; AsyncContext *__thiscall AsyncCache::AsyncPurge(AsyncCache *this, AsyncContext *result, QualifiedDataIDArray *qdids, AsyncCacheCallback *pCallbackPlugin, unsigned int dwUser1) .text:00419740 ?AsyncPurge@AsyncCache@@UAE?AVAsyncContext@@ABVQualifiedDataIDArray@@PAVAsyncCacheCallback@@K@Z

        // AsyncCache.AsyncSave:
        public AsyncContext* AsyncSave(AsyncContext* result, QualifiedDataID* qdid, Cache_Pack_t* pack_buf, UInt64 idDestination, AsyncCacheCallback* pCallbackPlugin, UInt32 dwUser1) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext*, QualifiedDataID*, Cache_Pack_t*, UInt64, AsyncCacheCallback*, UInt32, AsyncContext*>)0x004199A0)(ref this, result, qdid, pack_buf, idDestination, pCallbackPlugin, dwUser1); // .text:004197A0 ; AsyncContext *__thiscall AsyncCache::AsyncSave(AsyncCache *this, AsyncContext *result, QualifiedDataID *qdid, Cache_Pack_t *pack_buf, unsigned __int64 idDestination, AsyncCacheCallback *pCallbackPlugin, unsigned int dwUser1) .text:004197A0 ?AsyncSave@AsyncCache@@UAE?AVAsyncContext@@ABUQualifiedDataID@@AAVCache_Pack_t@@_KPAVAsyncCacheCallback@@K@Z

        // AsyncCache.BlockingGet:
        public DBObj* BlockingGet(UInt32 type, QualifiedDataID* qdid) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, UInt32, QualifiedDataID*, DBObj*>)0x004188D0)(ref this, type, qdid); // .text:00418670 ; DBObj *__thiscall AsyncCache::BlockingGet(AsyncCache *this, unsigned int type, QualifiedDataID *qdid) .text:00418670 ?BlockingGet@AsyncCache@@UAEPAVDBObj@@KABUQualifiedDataID@@@Z

        // AsyncCache.BlockingGetFromDisk:
        public DBObj* BlockingGetFromDisk(QualifiedDataID* qdid, DBOCache* pObjCache) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataID*, DBOCache*, DBObj*>)0x00417CF0)(ref this, qdid, pObjCache); // .text:00417A40 ; DBObj *__thiscall AsyncCache::BlockingGetFromDisk(AsyncCache *this, QualifiedDataID *qdid, DBOCache *pObjCache) .text:00417A40 ?BlockingGetFromDisk@AsyncCache@@MAEPAVDBObj@@ABUQualifiedDataID@@PAVDBOCache@@@Z

        // AsyncCache.BlockingLoadInto:
        public Byte BlockingLoadInto(DBObj* pObj, QualifiedDataID* qdid, DBOCache* pObjCache) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, DBObj*, QualifiedDataID*, DBOCache*, Byte>)0x00417C60)(ref this, pObj, qdid, pObjCache); // .text:004179B0 ; bool __thiscall AsyncCache::BlockingLoadInto(AsyncCache *this, DBObj *pObj, QualifiedDataID *qdid, DBOCache *pObjCache) .text:004179B0 ?BlockingLoadInto@AsyncCache@@MAE_NPAVDBObj@@ABUQualifiedDataID@@PAVDBOCache@@@Z

        // AsyncCache.BlockingPurge:
        public Byte BlockingPurge(QualifiedDataID* qdid) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataID*, Byte>)0x00417860)(ref this, qdid); // .text:004175B0 ; bool __thiscall AsyncCache::BlockingPurge(AsyncCache *this, QualifiedDataID *qdid) .text:004175B0 ?BlockingPurge@AsyncCache@@UAE_NABUQualifiedDataID@@@Z

        // AsyncCache.BlockingSave:
        public Byte BlockingSave(QualifiedDataID* qdid, Cache_Pack_t* pack_buf) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataID*, Cache_Pack_t*, Byte>)0x00417880)(ref this, qdid, pack_buf); // .text:004175D0 ; bool __thiscall AsyncCache::BlockingSave(AsyncCache *this, QualifiedDataID *qdid, Cache_Pack_t *pack_buf) .text:004175D0 ?BlockingSave@AsyncCache@@UAE_NABUQualifiedDataID@@AAVCache_Pack_t@@@Z

        // AsyncCache.CallPendingCallbacks:
        public void CallPendingCallbacks() => ((delegate* unmanaged[Thiscall]<ref AsyncCache, void>)0x00417BC0)(ref this); // .text:00417910 ; void __thiscall AsyncCache::CallPendingCallbacks(AsyncCache *this) .text:00417910 ?CallPendingCallbacks@AsyncCache@@MAEXXZ

        // AsyncCache.CreateContext:
        public AsyncContext* CreateContext(AsyncContext* result, AsyncCacheCallback* i_pcCallbackPlugin, UInt32 i_dwUser) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext*, AsyncCacheCallback*, UInt32, AsyncContext*>)0x004195F0)(ref this, result, i_pcCallbackPlugin, i_dwUser); // .text:004193F0 ; AsyncContext *__thiscall AsyncCache::CreateContext(AsyncCache *this, AsyncContext *result, AsyncCacheCallback *i_pcCallbackPlugin, unsigned int i_dwUser) .text:004193F0 ?CreateContext@AsyncCache@@UAE?AVAsyncContext@@PAVAsyncCacheCallback@@K@Z

        // AsyncCache.EnqueueAsyncRequest:
        public void EnqueueAsyncRequest(AsyncCache.CAsyncRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncCache.CAsyncRequest*, void>)0x00417960)(ref this, pReq); // .text:004176B0 ; void __thiscall AsyncCache::EnqueueAsyncRequest(AsyncCache *this, AsyncCache::CAsyncRequest *pReq) .text:004176B0 ?EnqueueAsyncRequest@AsyncCache@@MAEXPAUCAsyncRequest@1@@Z

        // AsyncCache.FilterSubDataIDs:
        // public void FilterSubDataIDs(QualifiedDataIDArray* io_qdids, UInt32 i_type) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataIDArray*, UInt32, void>)0xDEADBEEF)(ref this, io_qdids, i_type); // .text:00418F10 ; void __thiscall AsyncCache::FilterSubDataIDs(AsyncCache *this, QualifiedDataIDArray *io_qdids, unsigned int i_type) .text:00418F10 ?FilterSubDataIDs@AsyncCache@@IAEXAAVQualifiedDataIDArray@@K@Z

        // AsyncCache.FlushPendingRequests:
        public void FlushPendingRequests() => ((delegate* unmanaged[Thiscall]<ref AsyncCache, void>)0x00419C40)(ref this); // .text:00419A40 ; void __thiscall AsyncCache::FlushPendingRequests(AsyncCache *this) .text:00419A40 ?FlushPendingRequests@AsyncCache@@MAEXXZ

        // AsyncCache.FormGetRequest:
        // public CAsyncGetRequest* FormGetRequest(CAsyncGetRequest* pParentReq, UInt32 type, QualifiedDataID* qdid) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, CAsyncGetRequest*, UInt32, QualifiedDataID*, CAsyncGetRequest*>)0xDEADBEEF)(ref this, pParentReq, type, qdid); // .text:004184A0 ; CAsyncGetRequest *__thiscall AsyncCache::FormGetRequest(AsyncCache *this, CAsyncGetRequest *pParentReq, unsigned int type, QualifiedDataID *qdid) .text:004184A0 ?FormGetRequest@AsyncCache@@IAEPAUCAsyncGetRequest@@PAU2@KABUQualifiedDataID@@@Z

        // AsyncCache.GetFreeObj:
        public DBObj* GetFreeObj(QualifiedDataID* qdid, DBOCache* pObjCache) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataID*, DBOCache*, DBObj*>)0x00417770)(ref this, qdid, pObjCache); // .text:004174C0 ; DBObj *__thiscall AsyncCache::GetFreeObj(AsyncCache *this, QualifiedDataID *qdid, DBOCache *pObjCache) .text:004174C0 ?GetFreeObj@AsyncCache@@MAEPAVDBObj@@ABUQualifiedDataID@@PAVDBOCache@@@Z

        // AsyncCache.GetIfInMemory:
        public DBObj* GetIfInMemory(DBOCache* pObjCache) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, DBOCache*, DBObj*>)0x00417740)(ref this, pObjCache); // .text:00417490 ; DBObj *__thiscall AsyncCache::GetIfInMemory(QualifiedDataID *qdid, DBOCache *pObjCache) .text:00417490 ?GetIfInMemory@AsyncCache@@MAEPAVDBObj@@ABUQualifiedDataID@@PAVDBOCache@@@Z

        // AsyncCache.HashAndEnqueue:
        public void HashAndEnqueue(CAsyncGetRequest* pGetReq) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, CAsyncGetRequest*, void>)0x00419AA0)(ref this, pGetReq); // .text:004198A0 ; void __thiscall AsyncCache::HashAndEnqueue(AsyncCache *this, CAsyncGetRequest *pGetReq) .text:004198A0 ?HashAndEnqueue@AsyncCache@@MAEXPAUCAsyncGetRequest@@@Z

        // AsyncCache.IsOnDisk:
        public Byte IsOnDisk(QualifiedDataID* qdid) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataID*, Byte>)0x00418840)(ref this, qdid); // .text:004185E0 ; bool __thiscall AsyncCache::IsOnDisk(AsyncCache *this, QualifiedDataID *qdid) .text:004185E0 ?IsOnDisk@AsyncCache@@UAE_NABUQualifiedDataID@@@Z

        // AsyncCache.IsWaitingFor:
        // public Byte IsWaitingFor(CAsyncGetRequest* pGetFrom, CAsyncGetRequest* pGetTo) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, CAsyncGetRequest*, CAsyncGetRequest*, Byte>)0xDEADBEEF)(ref this, pGetFrom, pGetTo); // .text:00419B10 ; bool __thiscall AsyncCache::IsWaitingFor(AsyncCache *this, CAsyncGetRequest *pGetFrom, CAsyncGetRequest *pGetTo) .text:00419B10 ?IsWaitingFor@AsyncCache@@IAE_NPAUCAsyncGetRequest@@0@Z

        // AsyncCache.LoadData:
        public Byte LoadData(QualifiedDataID* qdid, Cache_Pack_t* Buf, UInt64 idDatFile) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataID*, Cache_Pack_t*, UInt64, Byte>)0x004177A0)(ref this, qdid, Buf, idDatFile); // .text:004174F0 ; bool __thiscall AsyncCache::LoadData(AsyncCache *this, QualifiedDataID *qdid, Cache_Pack_t *Buf, unsigned __int64 idDatFile) .text:004174F0 ?LoadData@AsyncCache@@MAE_NABUQualifiedDataID@@AAVCache_Pack_t@@_K@Z

        // AsyncCache.NotifyCallback:
        public void NotifyCallback(AsyncCache.CAsyncRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncCache.CAsyncRequest*, void>)0x00418510)(ref this, pReq); // .text:004182B0 ; void __thiscall AsyncCache::NotifyCallback(AsyncCache *this, AsyncCache::CAsyncRequest *pReq) .text:004182B0 ?NotifyCallback@AsyncCache@@MAEXPAUCAsyncRequest@1@@Z

        // AsyncCache.OnAsyncGetFinished:
        public void OnAsyncGetFinished(CAsyncGetRequest* pGetReq) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, CAsyncGetRequest*, void>)0x00417A30)(ref this, pGetReq); // .text:00417780 ; void __thiscall AsyncCache::OnAsyncGetFinished(AsyncCache *this, CAsyncGetRequest *pGetReq) .text:00417780 ?OnAsyncGetFinished@AsyncCache@@MAEXPAUCAsyncGetRequest@@@Z

        // AsyncCache.OnAsyncGetFromOtherSourcesFailed:
        public void OnAsyncGetFromOtherSourcesFailed(QualifiedDataID* qdid) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataID*, void>)0x004189D0)(ref this, qdid); // .text:00418770 ; void __thiscall AsyncCache::OnAsyncGetFromOtherSourcesFailed(AsyncCache *this, QualifiedDataID *qdid) .text:00418770 ?OnAsyncGetFromOtherSourcesFailed@AsyncCache@@MAEXABUQualifiedDataID@@@Z

        // AsyncCache.OnGetRequestFinished:
        public void OnGetRequestFinished(CAsyncGetRequest* pGetReq) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, CAsyncGetRequest*, void>)0x00419330)(ref this, pGetReq); // .text:00419130 ; void __thiscall AsyncCache::OnGetRequestFinished(AsyncCache *this, CAsyncGetRequest *pGetReq) .text:00419130 ?OnGetRequestFinished@AsyncCache@@MAEXPAUCAsyncGetRequest@@@Z

        // AsyncCache.OnPurgeRequestFinished:
        public void OnPurgeRequestFinished(CAsyncPurgeRequest* pPurgeReq) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, CAsyncPurgeRequest*, void>)0x00417700)(ref this, pPurgeReq); // .text:00417450 ; void __thiscall AsyncCache::OnPurgeRequestFinished(AsyncCache *this, CAsyncPurgeRequest *pPurgeReq) .text:00417450 ?OnPurgeRequestFinished@AsyncCache@@MAEXPAUCAsyncPurgeRequest@@@Z

        // AsyncCache.OnRequestFinished:
        public void OnRequestFinished(AsyncCache.CAsyncRequest* pReq) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncCache.CAsyncRequest*, void>)0x004176D0)(ref this, pReq); // .text:00417420 ; void __thiscall AsyncCache::OnRequestFinished(AsyncCache *this, AsyncCache::CAsyncRequest *pReq) .text:00417420 ?OnRequestFinished@AsyncCache@@MAEXPAUCAsyncRequest@1@@Z

        // AsyncCache.OnSaveRequestFinished:
        public void OnSaveRequestFinished(CAsyncSaveRequest* pSaveReq) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, CAsyncSaveRequest*, void>)0x004187A0)(ref this, pSaveReq); // .text:00418540 ; void __thiscall AsyncCache::OnSaveRequestFinished(AsyncCache *this, CAsyncSaveRequest *pSaveReq) .text:00418540 ?OnSaveRequestFinished@AsyncCache@@MAEXPAUCAsyncSaveRequest@@@Z

        // AsyncCache.PurgeData:
        public Byte PurgeData(QualifiedDataID* qdid, UInt64 idDatFile) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataID*, UInt64, Byte>)0x004177E0)(ref this, qdid, idDatFile); // .text:00417530 ; bool __thiscall AsyncCache::PurgeData(AsyncCache *this, QualifiedDataID *qdid, unsigned __int64 idDatFile) .text:00417530 ?PurgeData@AsyncCache@@MAE_NABUQualifiedDataID@@_K@Z

        // AsyncCache.ReleaseContext:
        public void ReleaseContext(AsyncContext hContext) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, AsyncContext, void>)0x00419BC0)(ref this, hContext); // .text:004199C0 ; void __thiscall AsyncCache::ReleaseContext(AsyncCache *this, AsyncContext hContext) .text:004199C0 ?ReleaseContext@AsyncCache@@UAEXVAsyncContext@@@Z

        // AsyncCache.SaveData:
        public Byte SaveData(QualifiedDataID* qdid, Cache_Pack_t* Buf, UInt64 idDatFile) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, QualifiedDataID*, Cache_Pack_t*, UInt64, Byte>)0x00417820)(ref this, qdid, Buf, idDatFile); // .text:00417570 ; bool __thiscall AsyncCache::SaveData(AsyncCache *this, QualifiedDataID *qdid, Cache_Pack_t *Buf, unsigned __int64 idDatFile) .text:00417570 ?SaveData@AsyncCache@@MAE_NABUQualifiedDataID@@AAVCache_Pack_t@@_K@Z

        // AsyncCache.SerializeFromCachePack:
        public Byte SerializeFromCachePack(DBObj* io_pObj, Cache_Pack_t* i_cpData) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, DBObj*, Cache_Pack_t*, Byte>)0x00417AC0)(ref this, io_pObj, i_cpData); // .text:00417810 ; bool __thiscall AsyncCache::SerializeFromCachePack(AsyncCache *this, DBObj *io_pObj, Cache_Pack_t *i_cpData) .text:00417810 ?SerializeFromCachePack@AsyncCache@@MAE_NPAVDBObj@@AAVCache_Pack_t@@@Z

        // AsyncCache.UnhashPendingGet:
        public void UnhashPendingGet(CAsyncGetRequest* pGetReq, CAsyncGetRequest* pParentReq) => ((delegate* unmanaged[Thiscall]<ref AsyncCache, CAsyncGetRequest*, CAsyncGetRequest*, void>)0x00419AF0)(ref this, pGetReq, pParentReq); // .text:004198F0 ; void __thiscall AsyncCache::UnhashPendingGet(AsyncCache *this, CAsyncGetRequest *pGetReq, CAsyncGetRequest *pParentReq) .text:004198F0 ?UnhashPendingGet@AsyncCache@@MAEXPAUCAsyncGetRequest@@0@Z

        // AsyncCache.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref AsyncCache, void>)0x00417710)(ref this); // .text:00417460 ; void __thiscall AsyncCache::UseTime(AsyncCache *this) .text:00417460 ?UseTime@AsyncCache@@UAEXXZ
    }
    public unsafe struct TDynamicCircularArray<T> where T : unmanaged {
        // Struct:
        public Vtbl vfptr;
        public AsyncCache.CCallbackHandler** A;
        public UInt32 first;
        public UInt32 next;
        public UInt32 count;
        public UInt32 max;
        public UInt32 growsize;
        public override string ToString() => $"vfptr(Vtbl):{vfptr}, A:->(AsyncCache.CCallbackHandler**)0x{(int)A:X8}, first:{first:X8}, next:{next:X8}, count:{count:X8}, max:{max:X8}, growsize:{growsize:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<TDynamicCircularArray<T>*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<TDynamicCircularArray<T>*, AsyncCache.CCallbackHandler**, UInt32> Add; // unsigned int (__thiscall *Add)(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this, AsyncCache::CCallbackHandler **);
            public static delegate* unmanaged[Thiscall]<TDynamicCircularArray<T>*, UInt32, void> Remove; // void (__thiscall *Remove)(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<TDynamicCircularArray<T>*, UInt32, AsyncCache.CCallbackHandler*> RemoveAndReturn; // AsyncCache::CCallbackHandler *(__thiscall *RemoveAndReturn)(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<TDynamicCircularArray<T>*, void> Clear; // void (__thiscall *Clear)(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this);
        }

        // Functions:

        // TDynamicCircularArray.Add<AsyncCache::CCallbackHandler *>:
        public UInt32 Add(T a2) => ((delegate* unmanaged[Thiscall]<ref TDynamicCircularArray<T>, T, UInt32>)0x00413FB0)(ref this, a2); // .text:00413D00 ; unsigned int __thiscall TDynamicCircularArray<AsyncCache::CCallbackHandler *>::Add(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this, AsyncCache::CCallbackHandler *const *T) .text:00413D00 ?Add@?$TDynamicCircularArray@PAVCCallbackHandler@AsyncCache@@@@UAEIABQAVCCallbackHandler@AsyncCache@@@Z

        // TDynamicCircularArray.Clear<AsyncCache::CCallbackHandler *>:
        public void Clear() => ((delegate* unmanaged[Thiscall]<ref TDynamicCircularArray<T>, void>)0x00413B20)(ref this); // .text:00413870 ; void __thiscall TDynamicCircularArray<AsyncCache::CCallbackHandler *>::Clear(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this) .text:00413870 ?Clear@?$TDynamicCircularArray@PAVCCallbackHandler@AsyncCache@@@@UAEXXZ

        // TDynamicCircularArray.Move<AsyncCache::CCallbackHandler *>:
        public void Move(UInt32 To, UInt32 From, UInt32 N) => ((delegate* unmanaged[Thiscall]<ref TDynamicCircularArray<T>, UInt32, UInt32, UInt32, void>)0x004140E0)(ref this, To, From, N); // .text:00413E30 ; void __thiscall TDynamicCircularArray<AsyncCache::CCallbackHandler *>::Move(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this, unsigned int To, unsigned int From, unsigned int N) .text:00413E30 ?Move@?$TDynamicCircularArray@PAVCCallbackHandler@AsyncCache@@@@IAEXIII@Z

        // TDynamicCircularArray.Remove<AsyncCache::CCallbackHandler *>:
        public void Remove(UInt32 Index) => ((delegate* unmanaged[Thiscall]<ref TDynamicCircularArray<T>, UInt32, void>)0x00414050)(ref this, Index); // .text:00413DA0 ; void __thiscall TDynamicCircularArray<AsyncCache::CCallbackHandler *>::Remove(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this, unsigned int Index) .text:00413DA0 ?Remove@?$TDynamicCircularArray@PAVCCallbackHandler@AsyncCache@@@@UAEXI@Z

        // TDynamicCircularArray.RemoveAndReturn<AsyncCache::CCallbackHandler *>:
        public AsyncCache.CCallbackHandler* RemoveAndReturn(UInt32 Index) => ((delegate* unmanaged[Thiscall]<ref TDynamicCircularArray<T>, UInt32, AsyncCache.CCallbackHandler*>)0x00414160)(ref this, Index); // .text:00413EB0 ; AsyncCache::CCallbackHandler *__thiscall TDynamicCircularArray<AsyncCache::CCallbackHandler *>::RemoveAndReturn(TDynamicCircularArray<AsyncCache::CCallbackHandler *> *this, unsigned int Index) .text:00413EB0 ?RemoveAndReturn@?$TDynamicCircularArray@PAVCCallbackHandler@AsyncCache@@@@UAEPAVCCallbackHandler@AsyncCache@@I@Z
    }

    public unsafe struct CAsyncPurgeRequest {
        // Struct:
        public AsyncCache.CAsyncRequest a0;
        public override string ToString() => $"a0(AsyncCache.CAsyncRequest):{a0}";
    }

    public unsafe struct CAsyncGetRequest {
        // Struct:
        /*
        public AsyncCache.CAsyncRequest a0;
        public UInt32 GSDIType;
        public SmartArray<PTR<CAsyncGetRequest>> RequestsWaitingForMe;
        public SmartArray<PTR<CAsyncGetRequest>> RequestsImWaitingFor;
        public Cache_Pack_t Buf;
        public int nGetsRemaining;
        public DBOCache* pObjCache;
        public UInt32 m_dwGetRequestFlags;
        public override string ToString() => $"a0(AsyncCache.CAsyncRequest):{a0}, GSDIType:{GSDIType:X8}, RequestsWaitingForMe(SmartArray<CAsyncGetRequest*,1>):{RequestsWaitingForMe}, RequestsImWaitingFor(SmartArray<CAsyncGetRequest*,1>):{RequestsImWaitingFor}, Buf(Cache_Pack_t):{Buf}, nGetsRemaining(int):{nGetsRemaining}, pObjCache:->(DBOCache*)0x{(int)pObjCache:X8}, m_dwGetRequestFlags:{m_dwGetRequestFlags:X8}";
        */
        // Functions:

        // CAsyncGetRequest.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CAsyncGetRequest, void>)0xDEADBEEF)(ref this); // .text:004181B0 ; void __thiscall CAsyncGetRequest::CAsyncGetRequest(CAsyncGetRequest *this) .text:004181B0 ??0CAsyncGetRequest@@QAE@XZ

        // CAsyncGetRequest.ReleaseDBObj:
        // public void ReleaseDBObj() => ((delegate* unmanaged[Thiscall]<ref CAsyncGetRequest, void>)0xDEADBEEF)(ref this); // .text:00417660 ; void __thiscall CAsyncGetRequest::ReleaseDBObj(CAsyncGetRequest *this) .text:00417660 ?ReleaseDBObj@CAsyncGetRequest@@UAEXXZ

        // CAsyncGetRequest.bAllDependanciesDone:
        // public Byte bAllDependanciesDone() => ((delegate* unmanaged[Thiscall]<ref CAsyncGetRequest, Byte>)0xDEADBEEF)(ref this); // .text:00418040 ; bool __thiscall CAsyncGetRequest::bAllDependanciesDone(CAsyncGetRequest *this) .text:00418040 ?bAllDependanciesDone@CAsyncGetRequest@@UBE_NXZ
    }
    public unsafe struct CAsyncSaveRequest {
        // Struct:
        public AsyncCache.CAsyncRequest a0;
        public Cache_Pack_t Buf;
        public UInt64 idTargetDatFile;
        public UInt32 dwDiskControllerSaveFlags;
        public UInt32 idIteration;
        public DiskController* pDisk;
        public override string ToString() => $"a0(AsyncCache.CAsyncRequest):{a0}, Buf(Cache_Pack_t):{Buf}, idTargetDatFile(UInt64):{idTargetDatFile}, dwDiskControllerSaveFlags:{dwDiskControllerSaveFlags:X8}, idIteration:{idIteration:X8}, pDisk:->(DiskController*)0x{(int)pDisk:X8}";
    }
    public unsafe struct DiskController {
        // Struct:
        public DiskConBase a0;
        public CLBlockAllocator block_man_m;
        public BTree did_tree_m;
        public PStringBase<char> filename_m;
        public DiskFileInfo_t file_info_m;
        public override string ToString() => $"a0(DiskConBase):{a0}, block_man_m(CLBlockAllocator):{block_man_m}, did_tree_m(BTree):{did_tree_m}, filename_m(PStringBase<char>):{filename_m}, file_info_m(DiskFileInfo_t):{file_info_m}";

        // Functions:

        // DiskController.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref DiskController, void>)0x00671F80)(ref this); // .text:00670FE0 ; void __thiscall DiskController::DiskController(DiskController *this) .text:00670FE0 ??0DiskController@@QAE@XZ

        // DiskController.AttemptToCompress:
        // public Byte AttemptToCompress(Cache_Pack_t* i_cpUncompressed, Cache_Pack_t* o_cpCompressed) => ((delegate* unmanaged[Thiscall]<ref DiskController, Cache_Pack_t*, Cache_Pack_t*, Byte>)0xDEADBEEF)(ref this, i_cpUncompressed, o_cpCompressed); // .text:00670630 ; bool __thiscall DiskController::AttemptToCompress(DiskController *this, Cache_Pack_t *i_cpUncompressed, Cache_Pack_t *o_cpCompressed) .text:00670630 ?AttemptToCompress@DiskController@@MAE_NABVCache_Pack_t@@AAV2@@Z

        // DiskController.CheckRoom:
        // public Byte CheckRoom(int size_l) => ((delegate* unmanaged[Thiscall]<ref DiskController, int, Byte>)0xDEADBEEF)(ref this, size_l); // .text:00670790 ; bool __thiscall DiskController::CheckRoom(DiskController *this, int size_l) .text:00670790 ?CheckRoom@DiskController@@IAE_NJ@Z

        // DiskController.Close:
        public Byte Close() => ((delegate* unmanaged[Thiscall]<ref DiskController, Byte>)0x00671360)(ref this); // .text:006703C0 ; bool __thiscall DiskController::Close(DiskController *this) .text:006703C0 ?Close@DiskController@@UAE_NXZ

        // DiskController.Decompress:
        // public Byte Decompress(Cache_Pack_t* i_cpCompressed, Cache_Pack_t* o_cpUncompressed) => ((delegate* unmanaged[Thiscall]<ref DiskController, Cache_Pack_t*, Cache_Pack_t*, Byte>)0xDEADBEEF)(ref this, i_cpCompressed, o_cpUncompressed); // .text:00670A80 ; bool __thiscall DiskController::Decompress(DiskController *this, Cache_Pack_t *i_cpCompressed, Cache_Pack_t *o_cpUncompressed) .text:00670A80 ?Decompress@DiskController@@MAE_NABVCache_Pack_t@@AAV2@@Z

        // DiskController.DeleteData:
        public Byte DeleteData(UInt32 did, int idIter) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, int, Byte>)0x00671D00)(ref this, did, idIter); // .text:00670D60 ; bool __thiscall DiskController::DeleteData(DiskController *this, IDClass<_tagDataID,32,0> did, int idIter) .text:00670D60 ?DeleteData@DiskController@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@J@Z

        // DiskController.DeleteDataByMask:
        public Byte DeleteDataByMask(UInt32 MatchID, UInt32 MatchMask) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, UInt32, Byte>)0x006722B0)(ref this, MatchID, MatchMask); // .text:00671310 ; bool __thiscall DiskController::DeleteDataByMask(DiskController *this, IDClass<_tagDataID,32,0> MatchID, IDClass<_tagDataID,32,0> MatchMask) .text:00671310 ?DeleteDataByMask@DiskController@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@0@Z

        // DiskController.GetDatIDStamp:
        public DatIDStamp* GetDatIDStamp(DatIDStamp* result) => ((delegate* unmanaged[Thiscall]<ref DiskController, DatIDStamp*, DatIDStamp*>)0x004F8E10)(ref this, result); // .text:004F8270 ; DatIDStamp *__thiscall DiskController::GetDatIDStamp(DiskController *this, DatIDStamp *result) .text:004F8270 ?GetDatIDStamp@DiskController@@UBE?AVDatIDStamp@@XZ

        // DiskController.GetDataSize:
        // public UInt32 GetDataSize(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, UInt32>)0xDEADBEEF)(ref this, did); // .text:00670940 ; unsigned int __thiscall DiskController::GetDataSize(DiskController *this, IDClass<_tagDataID,32,0> did) .text:00670940 ?GetDataSize@DiskController@@UAEIV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DiskController.GetDatestamp:
        // public int GetDatestamp(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, int>)0xDEADBEEF)(ref this, did); // .text:006707E0 ; int __thiscall DiskController::GetDatestamp(DiskController *this, IDClass<_tagDataID,32,0> did) .text:006707E0 ?GetDatestamp@DiskController@@UAEJV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DiskController.GetFilename:
        public PStringBase<char>* GetFilename() => ((delegate* unmanaged[Thiscall]<ref DiskController, PStringBase<char>*>)0x004F8E30)(ref this); // .text:004F8290 ; PStringBase<char> *__thiscall DiskController::GetFilename(DiskController *this) .text:004F8290 ?GetFilename@DiskController@@UBEABV?$PStringBase@D@@XZ

        // DiskController.GetIsCompressed:
        // public Byte GetIsCompressed(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, Byte>)0xDEADBEEF)(ref this, did); // .text:00670890 ; bool __thiscall DiskController::GetIsCompressed(DiskController *this, IDClass<_tagDataID,32,0> did) .text:00670890 ?GetIsCompressed@DiskController@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DiskController.GetIteration:
        // public int GetIteration(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, int>)0xDEADBEEF)(ref this, did); // .text:006708F0 ; int __thiscall DiskController::GetIteration(DiskController *this, IDClass<_tagDataID,32,0> did) .text:006708F0 ?GetIteration@DiskController@@UAEJV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DiskController.GetMasterMapDID:
        public UInt32* GetMasterMapDID(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32*, UInt32*>)0x004F8E40)(ref this, result); // .text:004F82A0 ; IDClass<_tagDataID,32,0> *__thiscall DiskController::GetMasterMapDID(DiskController *this, IDClass<_tagDataID,32,0> *result) .text:004F82A0 ?GetMasterMapDID@DiskController@@UAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // DiskController.GetMembers:
        // public Byte GetMembers(SmartArray<BTEntry>* o_aMembers) => ((delegate* unmanaged[Thiscall]<ref DiskController, SmartArray<BTEntry>*, Byte>)0xDEADBEEF)(ref this, o_aMembers); // .text:00670400 ; bool __thiscall DiskController::GetMembers(DiskController *this, SmartArray<BTEntry,1> *o_aMembers) .text:00670400 ?GetMembers@DiskController@@UAE_NAAV?$SmartArray@UBTEntry@@$00@@@Z

        // DiskController.GetUncompressedDataSize:
        // public UInt32 GetUncompressedDataSize(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, UInt32>)0xDEADBEEF)(ref this, did); // .text:00670990 ; unsigned int __thiscall DiskController::GetUncompressedDataSize(DiskController *this, IDClass<_tagDataID,32,0> did) .text:00670990 ?GetUncompressedDataSize@DiskController@@UAEIV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DiskController.GetVersion:
        // public int GetVersion(UInt32 did) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, int>)0xDEADBEEF)(ref this, did); // .text:00670830 ; int __thiscall DiskController::GetVersion(DiskController *this, IDClass<_tagDataID,32,0> did) .text:00670830 ?GetVersion@DiskController@@UAEJV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // DiskController.HowmuchFreeSpace:
        public int HowmuchFreeSpace() => ((delegate* unmanaged[Thiscall]<ref DiskController, int>)0x004F8E00)(ref this); // .text:004F8260 ; int __thiscall DiskController::HowmuchFreeSpace(DiskController *this) .text:004F8260 ?HowmuchFreeSpace@DiskController@@UAEJXZ

        // DiskController.InitFile:
        public Byte InitFile(DiskConInitInfo* info_r) => ((delegate* unmanaged[Thiscall]<ref DiskController, DiskConInitInfo*, Byte>)0x006723D0)(ref this, info_r); // .text:00671430 ; bool __thiscall DiskController::InitFile(DiskController *this, DiskConInitInfo *info_r) .text:00671430 ?InitFile@DiskController@@UAE_NAAUDiskConInitInfo@@@Z

        // DiskController.IsMember:
        // public Byte IsMember(UInt32 did, BTEntry* o_pMember) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, BTEntry*, Byte>)0xDEADBEEF)(ref this, did, o_pMember); // .text:00670D10 ; bool __thiscall DiskController::IsMember(DiskController *this, IDClass<_tagDataID,32,0> did, BTEntry *o_pMember) .text:00670D10 ?IsMember@DiskController@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@PAUBTEntry@@@Z

        // DiskController.LoadData:
        // public Byte LoadData(UInt32 gid, Cache_Pack_t* buf_out) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, Cache_Pack_t*, Byte>)0xDEADBEEF)(ref this, gid, buf_out); // .text:00670B80 ; bool __thiscall DiskController::LoadData(DiskController *this, IDClass<_tagDataID,32,0> gid, Cache_Pack_t *buf_out) .text:00670B80 ?LoadData@DiskController@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAVCache_Pack_t@@@Z

        // DiskController.LoadDataEx:
        public Byte LoadDataEx(UInt32 did, Cache_Pack_t* buf_out, BTEntry* ent_out, UInt32 dwFlags) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, Cache_Pack_t*, BTEntry*, UInt32, Byte>)0x00671B60)(ref this, did, buf_out, ent_out, dwFlags); // .text:00670BC0 ; bool __thiscall DiskController::LoadDataEx(DiskController *this, IDClass<_tagDataID,32,0> did, Cache_Pack_t *buf_out, BTEntry *ent_out, unsigned int dwFlags) .text:00670BC0 ?LoadDataEx@DiskController@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAVCache_Pack_t@@AAUBTEntry@@K@Z

        // DiskController.LoadIterationList:
        // public Byte LoadIterationList(CMostlyConsecutiveIntSet* Iters) => ((delegate* unmanaged[Thiscall]<ref DiskController, CMostlyConsecutiveIntSet*, Byte>)0xDEADBEEF)(ref this, Iters); // .text:00670DE0 ; bool __thiscall DiskController::LoadIterationList(DiskController *this, CMostlyConsecutiveIntSet *Iters) .text:00670DE0 ?LoadIterationList@DiskController@@UAE_NAAVCMostlyConsecutiveIntSet@@@Z

        // DiskController.SaveAndCompressData:
        // public Byte SaveAndCompressData(UInt32 id, Cache_Pack_t* buffer, int idIteration) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, Cache_Pack_t*, int, Byte>)0xDEADBEEF)(ref this, id, buffer, idIteration); // .text:00670590 ; bool __thiscall DiskController::SaveAndCompressData(DiskController *this, IDClass<_tagDataID,32,0> id, Cache_Pack_t *buffer, int idIteration) .text:00670590 ?SaveAndCompressData@DiskController@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAVCache_Pack_t@@J@Z

        // DiskController.SaveData:
        // public Byte SaveData(UInt32 id, Cache_Pack_t* buffer, int idIteration) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, Cache_Pack_t*, int, Byte>)0xDEADBEEF)(ref this, id, buffer, idIteration); // .text:00670540 ; bool __thiscall DiskController::SaveData(DiskController *this, IDClass<_tagDataID,32,0> id, Cache_Pack_t *buffer, int idIteration) .text:00670540 ?SaveData@DiskController@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAVCache_Pack_t@@J@Z

        // DiskController.SaveDataEx:
        public Byte SaveDataEx(BTEntry* io_entNew, Cache_Pack_t* i_cpUser, UInt32 dwFlags) => ((delegate* unmanaged[Thiscall]<ref DiskController, BTEntry*, Cache_Pack_t*, UInt32, Byte>)0x00672060)(ref this, io_entNew, i_cpUser, dwFlags); // .text:006710C0 ; bool __thiscall DiskController::SaveDataEx(DiskController *this, BTEntry *io_entNew, Cache_Pack_t *i_cpUser, unsigned int dwFlags) .text:006710C0 ?SaveDataEx@DiskController@@UAE_NAAUBTEntry@@AAVCache_Pack_t@@K@Z

        // DiskController.SaveIterationList:
        // public Byte SaveIterationList(CMostlyConsecutiveIntSet* Iters) => ((delegate* unmanaged[Thiscall]<ref DiskController, CMostlyConsecutiveIntSet*, Byte>)0xDEADBEEF)(ref this, Iters); // .text:00670EE0 ; bool __thiscall DiskController::SaveIterationList(DiskController *this, CMostlyConsecutiveIntSet *Iters) .text:00670EE0 ?SaveIterationList@DiskController@@UAE_NAAVCMostlyConsecutiveIntSet@@@Z

        // DiskController.SavePreCompressedData:
        // public Byte SavePreCompressedData(UInt32 id, Cache_Pack_t* buffer, int idIteration) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32, Cache_Pack_t*, int, Byte>)0xDEADBEEF)(ref this, id, buffer, idIteration); // .text:006705E0 ; bool __thiscall DiskController::SavePreCompressedData(DiskController *this, IDClass<_tagDataID,32,0> id, Cache_Pack_t *buffer, int idIteration) .text:006705E0 ?SavePreCompressedData@DiskController@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAVCache_Pack_t@@J@Z

        // DiskController.SetDatIDStamp:
        // public void SetDatIDStamp(DatIDStamp* stamp) => ((delegate* unmanaged[Thiscall]<ref DiskController, DatIDStamp*, void>)0xDEADBEEF)(ref this, stamp); // .text:00670410 ; void __thiscall DiskController::SetDatIDStamp(DiskController *this, DatIDStamp *stamp) .text:00670410 ?SetDatIDStamp@DiskController@@UAEXAAVDatIDStamp@@@Z

        // DiskController.SetMasterMapDID:
        // public UInt32* SetMasterMapDID(UInt32* result, UInt32 map_id) => ((delegate* unmanaged[Thiscall]<ref DiskController, UInt32*, UInt32, UInt32*>)0xDEADBEEF)(ref this, result, map_id); // .text:00670DA0 ; IDClass<_tagDataID,32,0> *__thiscall DiskController::SetMasterMapDID(DiskController *this, IDClass<_tagDataID,32,0> *result, IDClass<_tagDataID,32,0> map_id) .text:00670DA0 ?SetMasterMapDID@DiskController@@UAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@V2@@Z
    }
    public unsafe struct DiskConBase {
        // Struct:
        public DiskConBase.Vtbl* vfptr;
        public Byte initialized_fm;
        public Byte read_only_fm;
        public Byte expandable_fm;
        public DATFILE_TYPE data_set_lm;
        public UInt32 data_subset_lm;
        public override string ToString() => $"vfptr:->(DiskConBase.Vtbl*)0x{(int)vfptr:X8}, initialized_fm:{initialized_fm:X2}, read_only_fm:{read_only_fm:X2}, expandable_fm:{expandable_fm:X2}, data_set_lm(DATFILE_TYPE):{data_set_lm}, data_subset_lm:{data_subset_lm:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(DiskConBase *this, unsigned int);
            public fixed int gap4[8];
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt32, Cache_Pack_t*, Byte> LoadData; // bool (__thiscall *LoadData)(DiskConBase *this, IDClass<_tagDataID,32,0>, Cache_Pack_t *);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt32, Cache_Pack_t*, int, Byte> SaveData; // bool (__thiscall *SaveData)(DiskConBase *this, IDClass<_tagDataID,32,0>, Cache_Pack_t *, int);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt32, int, Byte> DeleteData; // bool (__thiscall *DeleteData)(DiskConBase *this, IDClass<_tagDataID,32,0>, int);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt32, UInt32, Byte> DeleteDataByMask; // bool (__thiscall *DeleteDataByMask)(DiskConBase *this, IDClass<_tagDataID,32,0>, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt32, BTEntry*, Byte> IsMember; // bool (__thiscall *IsMember)(DiskConBase *this, IDClass<_tagDataID,32,0>, BTEntry *);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, SmartArray<BTEntry>*, Byte> GetMembers; // bool (__thiscall *GetMembers)(DiskConBase *this, SmartArray<BTEntry,1> *);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, int> HowmuchFreeSpace; // int (__thiscall *HowmuchFreeSpace)(DiskConBase *this);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, CMostlyConsecutiveIntSet*, Byte> LoadIterationList; // bool (__thiscall *LoadIterationList)(DiskConBase *this, CMostlyConsecutiveIntSet *);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, CMostlyConsecutiveIntSet*, Byte> SaveIterationList; // bool (__thiscall *SaveIterationList)(DiskConBase *this, CMostlyConsecutiveIntSet *);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, DATFILE_TYPE> GetDataset; // DATFILE_TYPE (__thiscall *GetDataset)(DiskConBase *this);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt32> GetSubset; // unsigned int (__thiscall *GetSubset)(DiskConBase *this);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt64> GetDatFileID; // unsigned __int64 (__thiscall *GetDatFileID)(DiskConBase *this);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, Byte> IsInitialized; // bool (__thiscall *IsInitialized)(DiskConBase *this);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, Byte> IsReadOnly; // bool (__thiscall *IsReadOnly)(DiskConBase *this);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, Byte> IsExpandable; // bool (__thiscall *IsExpandable)(DiskConBase *this);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt32*, UInt32*> GetMasterMapDID; // IDClass<_tagDataID,32,0> *(__thiscall *GetMasterMapDID)(DiskConBase *this, IDClass<_tagDataID,32,0> *result);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, UInt32*, UInt32, UInt32*> SetMasterMapDID; // IDClass<_tagDataID,32,0> *(__thiscall *SetMasterMapDID)(DiskConBase *this, IDClass<_tagDataID,32,0> *result, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, DatIDStamp*, void> SetDatIDStamp; // void (__thiscall *SetDatIDStamp)(DiskConBase *this, DatIDStamp *);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, DatIDStamp*, DatIDStamp*> GetDatIDStamp; // DatIDStamp *(__thiscall *GetDatIDStamp)(DiskConBase *this, DatIDStamp *result);
            public static delegate* unmanaged[Thiscall]<DiskConBase*, PStringBase<char>*> GetFilename; // PStringBase<char> *(__thiscall *GetFilename)(DiskConBase *this);
            public override string ToString() => $"gap4[8](fixed int):{gap4[8]}";
        }

        // Functions:

        // DiskConBase.GetDatFileID:
        public UInt64 GetDatFileID() => ((delegate* unmanaged[Thiscall]<ref DiskConBase, UInt64>)0x004F8DB0)(ref this); // .text:004F8210 ; unsigned __int64 __thiscall DiskConBase::GetDatFileID(DiskConBase *this) .text:004F8210 ?GetDatFileID@DiskConBase@@UBE_KXZ

        // DiskConBase.GetDatIDStamp:
        // public DatIDStamp* GetDatIDStamp(DatIDStamp* result) => ((delegate* unmanaged[Thiscall]<ref DiskConBase, DatIDStamp*, DatIDStamp*>)0xDEADBEEF)(ref this, result); // .text:00670380 ; DatIDStamp *__thiscall DiskConBase::GetDatIDStamp(DiskConBase *this, DatIDStamp *result) .text:00670380 ?GetDatIDStamp@DiskConBase@@UBE?AVDatIDStamp@@XZ

        // DiskConBase.GetMasterMapDID:
        // public UInt32* GetMasterMapDID(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref DiskConBase, UInt32*, UInt32*>)0xDEADBEEF)(ref this, result); // .text:00670520 ; IDClass<_tagDataID,32,0> *__thiscall DiskConBase::GetMasterMapDID(DiskConBase *this, IDClass<_tagDataID,32,0> *result) .text:00670520 ?GetMasterMapDID@DiskConBase@@UAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // DiskConBase.IsExpandable:
        public Byte IsExpandable() => ((delegate* unmanaged[Thiscall]<ref DiskConBase, Byte>)0x004F8DF0)(ref this); // .text:004F8250 ; bool __thiscall DiskConBase::IsExpandable(DiskConBase *this) .text:004F8250 ?IsExpandable@DiskConBase@@UAE_NXZ

        // DiskConBase.IsInitialized:
        public Byte IsInitialized() => ((delegate* unmanaged[Thiscall]<ref DiskConBase, Byte>)0x004F8DD0)(ref this); // .text:004F8230 ; bool __thiscall DiskConBase::IsInitialized(DiskConBase *this) .text:004F8230 ?IsInitialized@DiskConBase@@UAE_NXZ

        // DiskConBase.IsReadOnly:
        public Byte IsReadOnly() => ((delegate* unmanaged[Thiscall]<ref DiskConBase, Byte>)0x004F8DE0)(ref this); // .text:004F8240 ; bool __thiscall DiskConBase::IsReadOnly(DiskConBase *this) .text:004F8240 ?IsReadOnly@DiskConBase@@UAE_NXZ

        // DiskConBase.SaveData:
        // public Byte SaveData(UInt32 id, Cache_Pack_t* buffer, int idIter) => ((delegate* unmanaged[Thiscall]<ref DiskConBase, UInt32, Cache_Pack_t*, int, Byte>)0xDEADBEEF)(ref this, id, buffer, idIter); // .text:00670510 ; bool __thiscall DiskConBase::SaveData(DiskConBase *this, IDClass<_tagDataID,32,0> id, Cache_Pack_t *buffer, int idIter) .text:00670510 ?SaveData@DiskConBase@@UAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAVCache_Pack_t@@J@Z

        // DiskConBase.SetMasterMapDID:
        // public UInt32* SetMasterMapDID(UInt32* result, UInt32 map_id) => ((delegate* unmanaged[Thiscall]<ref DiskConBase, UInt32*, UInt32, UInt32*>)0xDEADBEEF)(ref this, result, map_id); // .text:00670530 ; IDClass<_tagDataID,32,0> *__thiscall DiskConBase::SetMasterMapDID(DiskConBase *this, IDClass<_tagDataID,32,0> *result, IDClass<_tagDataID,32,0> map_id) .text:00670530 ?SetMasterMapDID@DiskConBase@@UAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@V2@@Z
    }

    public unsafe struct BTEntry {
        // Struct:
        //public UInt32 comp_ : 1;
        //public UInt32 resv_ : 15;
        //public UInt32 ver_ : 16;
        public UInt32 compver_;
        public UInt32 GID_;
        public int Offset_;
        public UInt32 size_;
        public int date_;
        public int iter_;
        public override string ToString() => $"compver_:{compver_:X8}, GID_:{GID_:X8}, Offset_(int):{Offset_}, size_:{size_:X8}, date_(int):{date_}, iter_(int):{iter_}";
    }
    public unsafe struct DiskConInitInfo {
        // Struct:
        public PStringBase<char> file;
        public PStringBase<UInt16> path;
        public DATFILE_TYPE data_set_lm;
        public UInt32 data_subset_lm;
        public UInt32 open_flags_lm;
        public int file_size_lm;
        public int block_size_lm;
        public int eng_pack_vnum;
        public int game_pack_vnum;
        public Byte eng_only;
        public override string ToString() => $"file(PStringBase<char>):{file}, path:{path}, data_set_lm(DATFILE_TYPE):{data_set_lm}, data_subset_lm:{data_subset_lm:X8}, open_flags_lm:{open_flags_lm:X8}, file_size_lm(int):{file_size_lm}, block_size_lm(int):{block_size_lm}, eng_pack_vnum(int):{eng_pack_vnum}, game_pack_vnum(int):{game_pack_vnum}, eng_only:{eng_only:X2}";

        // Functions:

        // DiskConInitInfo.__Ctor:
        public void __Ctor(PStringBase<char>* f, PStringBase<UInt16>* p, DATFILE_TYPE ds_l, UInt32 dss_l, UInt32 open_flags, int fs_l, int bs_l, int dat_eng_pack_version_number, int dat_game_pack_version_number, Byte engine_only) => ((delegate* unmanaged[Thiscall]<ref DiskConInitInfo, PStringBase<char>*, PStringBase<UInt16>*, DATFILE_TYPE, UInt32, UInt32, int, int, int, int, Byte, void>)0x004F8720)(ref this, f, p, ds_l, dss_l, open_flags, fs_l, bs_l, dat_eng_pack_version_number, dat_game_pack_version_number, engine_only); // .text:004F7AC0 ; void __thiscall DiskConInitInfo::DiskConInitInfo(DiskConInitInfo *this, PStringBase<char> *f, PStringBase<unsigned short> *p, DATFILE_TYPE ds_l, unsigned int dss_l, unsigned int open_flags, int fs_l, int bs_l, int dat_eng_pack_version_number, int dat_game_pack_version_number, bool engine_only) .text:004F7AC0 ??0DiskConInitInfo@@QAE@ABV?$PStringBase@D@@ABV?$PStringBase@G@@W4DATFILE_TYPE@@KKJJJJ_N@Z
    }
    public unsafe struct DiskFileInfo_t {
        // Struct:
        public int magic_;
        public int iBlockSize_;
        public UInt32 fileSize_;
        public DATFILE_TYPE data_set_lm;
        public UInt32 data_subset_lm;
        public int firstFree_;
        public int finalFree_;
        public int iFreeBlocks_;
        public int btreeRoot_;
        public int young_lru_lm;
        public int old_lru_lm;
        public Byte use_lru_fm;
        public UInt32 master_map_id_m;
        public int eng_pack_vnum;
        public int game_pack_vnum;
        public DatIDStamp id_vnum;
        public override string ToString() => $"magic_(int):{magic_}, iBlockSize_(int):{iBlockSize_}, fileSize_:{fileSize_:X8}, data_set_lm(DATFILE_TYPE):{data_set_lm}, data_subset_lm:{data_subset_lm:X8}, firstFree_(int):{firstFree_}, finalFree_(int):{finalFree_}, iFreeBlocks_(int):{iFreeBlocks_}, btreeRoot_(int):{btreeRoot_}, young_lru_lm(int):{young_lru_lm}, old_lru_lm(int):{old_lru_lm}, use_lru_fm:{use_lru_fm:X2}, master_map_id_m:{master_map_id_m:X8}, eng_pack_vnum(int):{eng_pack_vnum}, game_pack_vnum(int):{game_pack_vnum}, id_vnum(DatIDStamp):{id_vnum}";

        // Functions:

        // DiskFileInfo_t.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref DiskFileInfo_t, void>)0xDEADBEEF)(ref this); // .text:00670440 ; void __thiscall DiskFileInfo_t::DiskFileInfo_t(DiskFileInfo_t *this) .text:00670440 ??0DiskFileInfo_t@@QAE@XZ

        // DiskFileInfo_t.operator_equals:
        // public DiskFileInfo_t* operator_equals() => ((delegate* unmanaged[Thiscall]<ref DiskFileInfo_t, DiskFileInfo_t*>)0xDEADBEEF)(ref this); // .text:00676B90 ; public: struct DiskFileInfo_t & __thiscall DiskFileInfo_t::operator=(struct DiskFileInfo_t const &) .text:00676B90 ??4DiskFileInfo_t@@QAEAAU0@ABU0@@Z

        // DiskFileInfo_t.ClearData:
        // public void ClearData() => ((delegate* unmanaged[Thiscall]<ref DiskFileInfo_t, void>)0xDEADBEEF)(ref this); // .text:00670330 ; void __thiscall DiskFileInfo_t::ClearData(DiskFileInfo_t *this) .text:00670330 ?ClearData@DiskFileInfo_t@@QAEXXZ
    }
    public unsafe struct BTree {
        // Struct:
        public BTMemNode mem_root_node_m;
        public BTMemNode* mem_nodes_pm;
        public int nodesInMem_;
        public int _time_stamp;
        public CLBlockAllocator* pBlkMan_;
        public DiskFileInfo_t* file_info_pm;
        public LRU_List* lru_man_pm;
        public override string ToString() => $"mem_root_node_m(BTMemNode):{mem_root_node_m}, mem_nodes_pm:->(BTMemNode*)0x{(int)mem_nodes_pm:X8}, nodesInMem_(int):{nodesInMem_}, _time_stamp(int):{_time_stamp}, pBlkMan_:->(CLBlockAllocator*)0x{(int)pBlkMan_:X8}, file_info_pm:->(DiskFileInfo_t*)0x{(int)file_info_pm:X8}, lru_man_pm:->(LRU_List*)0x{(int)lru_man_pm:X8}";

        // Functions:

        // BTree.__Ctor:
        // public void __Ctor(CLBlockAllocator* allocator) => ((delegate* unmanaged[Thiscall]<ref BTree, CLBlockAllocator*, void>)0xDEADBEEF)(ref this, allocator); // .text:00671F70 ; void __thiscall BTree::BTree(BTree *this, CLBlockAllocator *allocator) .text:00671F70 ??0BTree@@QAE@PAVCLBlockAllocator@@@Z

        // BTree.AddLeast:
        // public void AddLeast(BTMemNode* pNode, BTEntry* newEntry, int newLink) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, BTEntry*, int, void>)0xDEADBEEF)(ref this, pNode, newEntry, newLink); // .text:00671CE0 ; void __thiscall BTree::AddLeast(BTree *this, BTMemNode *pNode, BTEntry *newEntry, int newLink) .text:00671CE0 ?AddLeast@BTree@@IAEXPAUBTMemNode@@AAUBTEntry@@J@Z

        // BTree.AllocateEmptyNode:
        // public BTMemNode* AllocateEmptyNode() => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*>)0xDEADBEEF)(ref this); // .text:006724B0 ; BTMemNode *__thiscall BTree::AllocateEmptyNode(BTree *this) .text:006724B0 ?AllocateEmptyNode@BTree@@IAEPAUBTMemNode@@XZ

        // BTree.Build_Id_List:
        // public void Build_Id_List(SmartArray<BTEntry>* list_r, BTMemNode* node_p) => ((delegate* unmanaged[Thiscall]<ref BTree, SmartArray<BTEntry>*, BTMemNode*, void>)0xDEADBEEF)(ref this, list_r, node_p); // .text:00673D10 ; void __thiscall BTree::Build_Id_List(BTree *this, SmartArray<BTEntry,1> *list_r, BTMemNode *node_p) .text:00673D10 ?Build_Id_List@BTree@@IAEXAAV?$SmartArray@UBTEntry@@$00@@PAUBTMemNode@@@Z

        // BTree.Build_Id_List:
        // public void Build_Id_List(SmartArray<BTEntry>* list_r, BTMemNode* pNode, UInt32 MinID, UInt32 MaxID) => ((delegate* unmanaged[Thiscall]<ref BTree, SmartArray<BTEntry>*, BTMemNode*, UInt32, UInt32, void>)0xDEADBEEF)(ref this, list_r, pNode, MinID, MaxID); // .text:00673C20 ; void __thiscall BTree::Build_Id_List(BTree *this, SmartArray<BTEntry,1> *list_r, BTMemNode *pNode, IDClass<_tagDataID,32,0> MinID, IDClass<_tagDataID,32,0> MaxID) .text:00673C20 ?Build_Id_List@BTree@@IAEXAAV?$SmartArray@UBTEntry@@$00@@PAUBTMemNode@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@2@Z

        // BTree.CreateTree:
        // public int CreateTree(DiskFileInfo_t* pHeaderInfo) => ((delegate* unmanaged[Thiscall]<ref BTree, DiskFileInfo_t*, int>)0xDEADBEEF)(ref this, pHeaderInfo); // .text:00672010 ; int __thiscall BTree::CreateTree(BTree *this, DiskFileInfo_t *pHeaderInfo) .text:00672010 ?CreateTree@BTree@@QAEJPAUDiskFileInfo_t@@@Z

        // BTree.Delete:
        // public int Delete(UInt32 targetGId, BTMemNode* mem_start_p) => ((delegate* unmanaged[Thiscall]<ref BTree, UInt32, BTMemNode*, int>)0xDEADBEEF)(ref this, targetGId, mem_start_p); // .text:006739B0 ; int __thiscall BTree::Delete(BTree *this, IDClass<_tagDataID,32,0> targetGId, BTMemNode *mem_start_p) .text:006739B0 ?Delete@BTree@@IAEJV?$IDClass@U_tagDataID@@$0CA@$0A@@@PAUBTMemNode@@@Z

        // BTree.DeleteInternalExec:
        // public int DeleteInternalExec(DeleteInternalTransactInfo* pTrIn) => ((delegate* unmanaged[Thiscall]<ref BTree, DeleteInternalTransactInfo*, int>)0xDEADBEEF)(ref this, pTrIn); // .text:00672D60 ; int __thiscall BTree::DeleteInternalExec(BTree *this, DeleteInternalTransactInfo *pTrIn) .text:00672D60 ?DeleteInternalExec@BTree@@IAEJPBVDeleteInternalTransactInfo@@@Z

        // BTree.DeleteInternalTrans:
        // public int DeleteInternalTrans(UInt32 targetGId, UInt32 donorGId, int targetOffset, int donorOffset, int targetIndex, int donorIndex) => ((delegate* unmanaged[Thiscall]<ref BTree, UInt32, UInt32, int, int, int, int, int>)0xDEADBEEF)(ref this, targetGId, donorGId, targetOffset, donorOffset, targetIndex, donorIndex); // .text:00673640 ; int __thiscall BTree::DeleteInternalTrans(BTree *this, IDClass<_tagDataID,32,0> targetGId, IDClass<_tagDataID,32,0> donorGId, int targetOffset, int donorOffset, int targetIndex, int donorIndex) .text:00673640 ?DeleteInternalTrans@BTree@@IAEJV?$IDClass@U_tagDataID@@$0CA@$0A@@@0JJJJ@Z

        // BTree.DeleteLeafExec:
        // public int DeleteLeafExec(DeleteLeafTransactInfo* pTrIn) => ((delegate* unmanaged[Thiscall]<ref BTree, DeleteLeafTransactInfo*, int>)0xDEADBEEF)(ref this, pTrIn); // .text:00672CB0 ; int __thiscall BTree::DeleteLeafExec(BTree *this, DeleteLeafTransactInfo *pTrIn) .text:00672CB0 ?DeleteLeafExec@BTree@@IAEJPBVDeleteLeafTransactInfo@@@Z

        // BTree.DeleteLeafTrans:
        // public int DeleteLeafTrans(BTMemNode* pNode, int index) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, int, int>)0xDEADBEEF)(ref this, pNode, index); // .text:006735E0 ; int __thiscall BTree::DeleteLeafTrans(BTree *this, BTMemNode *pNode, int index) .text:006735E0 ?DeleteLeafTrans@BTree@@IAEJPAUBTMemNode@@J@Z

        // BTree.DescendToAdd:
        // public int DescendToAdd(BTEntry* entry, Cache_Pack_t* pack_buf) => ((delegate* unmanaged[Thiscall]<ref BTree, BTEntry*, Cache_Pack_t*, int>)0xDEADBEEF)(ref this, entry, pack_buf); // .text:006733B0 ; int __thiscall BTree::DescendToAdd(BTree *this, BTEntry *entry, Cache_Pack_t *pack_buf) .text:006733B0 ?DescendToAdd@BTree@@QAEJAAUBTEntry@@AAVCache_Pack_t@@@Z

        // BTree.DescendToDelete:
        // public int DescendToDelete(BTMemNode* pStartNode, UInt32 targetGId, BTMemNode** ppOutNode, int* pOutIndex) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, UInt32, BTMemNode**, int*, int>)0xDEADBEEF)(ref this, pStartNode, targetGId, ppOutNode, pOutIndex); // .text:00673830 ; int __thiscall BTree::DescendToDelete(BTree *this, BTMemNode *pStartNode, IDClass<_tagDataID,32,0> targetGId, BTMemNode **ppOutNode, int *pOutIndex) .text:00673830 ?DescendToDelete@BTree@@IAEJPAUBTMemNode@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@PAPAU2@PAJ@Z

        // BTree.ExtractEntryShift:
        // public int ExtractEntryShift(BTMemNode* pNode, int index, BTEntry* pOutEntry) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, int, BTEntry*, int>)0xDEADBEEF)(ref this, pNode, index, pOutEntry); // .text:00671C50 ; int __thiscall BTree::ExtractEntryShift(BTree *this, BTMemNode *pNode, int index, BTEntry *pOutEntry) .text:00671C50 ?ExtractEntryShift@BTree@@IAEJPAUBTMemNode@@JPAUBTEntry@@@Z

        // BTree.FindMax:
        // public UInt32* FindMax(UInt32* result, BTMemNode* pNode) => ((delegate* unmanaged[Thiscall]<ref BTree, UInt32*, BTMemNode*, UInt32*>)0xDEADBEEF)(ref this, result, pNode); // .text:00672C60 ; IDClass<_tagDataID,32,0> *__thiscall BTree::FindMax(BTree *this, IDClass<_tagDataID,32,0> *result, BTMemNode *pNode) .text:00672C60 ?FindMax@BTree@@IAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@PAUBTMemNode@@@Z

        // BTree.FindMin:
        // public UInt32* FindMin(UInt32* result, BTMemNode* pNode) => ((delegate* unmanaged[Thiscall]<ref BTree, UInt32*, BTMemNode*, UInt32*>)0xDEADBEEF)(ref this, result, pNode); // .text:00672C20 ; IDClass<_tagDataID,32,0> *__thiscall BTree::FindMin(BTree *this, IDClass<_tagDataID,32,0> *result, BTMemNode *pNode) .text:00672C20 ?FindMin@BTree@@IAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@PAUBTMemNode@@@Z

        // BTree.FindNode:
        // public BTMemNode* FindNode(int offset, int* pOutIndex) => ((delegate* unmanaged[Thiscall]<ref BTree, int, int*, BTMemNode*>)0xDEADBEEF)(ref this, offset, pOutIndex); // .text:00672320 ; BTMemNode *__thiscall BTree::FindNode(BTree *this, int offset, int *pOutIndex) .text:00672320 ?FindNode@BTree@@IAEPAUBTMemNode@@JPAJ@Z

        // BTree.Get_Id_List:
        // public Byte Get_Id_List(SmartArray<BTEntry>* list_r) => ((delegate* unmanaged[Thiscall]<ref BTree, SmartArray<BTEntry>*, Byte>)0xDEADBEEF)(ref this, list_r); // .text:00673E20 ; bool __thiscall BTree::Get_Id_List(BTree *this, SmartArray<BTEntry,1> *list_r) .text:00673E20 ?Get_Id_List@BTree@@QAE_NAAV?$SmartArray@UBTEntry@@$00@@@Z

        // BTree.Get_Id_List_Range:
        // public Byte Get_Id_List_Range(SmartArray<BTEntry>* list_r, UInt32 MinID, UInt32 MaxID) => ((delegate* unmanaged[Thiscall]<ref BTree, SmartArray<BTEntry>*, UInt32, UInt32, Byte>)0xDEADBEEF)(ref this, list_r, MinID, MaxID); // .text:00673E40 ; bool __thiscall BTree::Get_Id_List_Range(BTree *this, SmartArray<BTEntry,1> *list_r, IDClass<_tagDataID,32,0> MinID, IDClass<_tagDataID,32,0> MaxID) .text:00673E40 ?Get_Id_List_Range@BTree@@QAE_NAAV?$SmartArray@UBTEntry@@$00@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@1@Z

        // BTree.HasEntry:
        // public Byte HasEntry(UInt32 targetGId, BTMemNode* pNode, int* pOutIndex) => ((delegate* unmanaged[Thiscall]<ref BTree, UInt32, BTMemNode*, int*, Byte>)0xDEADBEEF)(ref this, targetGId, pNode, pOutIndex); // .text:00671D80 ; bool __thiscall BTree::HasEntry(BTree *this, IDClass<_tagDataID,32,0> targetGId, BTMemNode *pNode, int *pOutIndex) .text:00671D80 ?HasEntry@BTree@@IAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@PAUBTMemNode@@PAJ@Z

        // BTree.InsertEntryExec:
        // public int InsertEntryExec(AddObjectTransactInfo* pTrIn, Cache_Pack_t* pack_buf) => ((delegate* unmanaged[Thiscall]<ref BTree, AddObjectTransactInfo*, Cache_Pack_t*, int>)0xDEADBEEF)(ref this, pTrIn, pack_buf); // .text:006726C0 ; int __thiscall BTree::InsertEntryExec(BTree *this, AddObjectTransactInfo *pTrIn, Cache_Pack_t *pack_buf) .text:006726C0 ?InsertEntryExec@BTree@@IAEJPBVAddObjectTransactInfo@@AAVCache_Pack_t@@@Z

        // BTree.InsertEntryTrans:
        // public int InsertEntryTrans(BTMemNode* pNode, BTEntry* entry, Cache_Pack_t* pack_buf) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, BTEntry*, Cache_Pack_t*, int>)0xDEADBEEF)(ref this, pNode, entry, pack_buf); // .text:006732B0 ; int __thiscall BTree::InsertEntryTrans(BTree *this, BTMemNode *pNode, BTEntry *entry, Cache_Pack_t *pack_buf) .text:006732B0 ?InsertEntryTrans@BTree@@IAEJPAUBTMemNode@@AAUBTEntry@@AAVCache_Pack_t@@@Z

        // BTree.LoadTree:
        // public int LoadTree(DiskFileInfo_t* pHeaderInfo) => ((delegate* unmanaged[Thiscall]<ref BTree, DiskFileInfo_t*, int>)0xDEADBEEF)(ref this, pHeaderInfo); // .text:00672150 ; int __thiscall BTree::LoadTree(BTree *this, DiskFileInfo_t *pHeaderInfo) .text:00672150 ?LoadTree@BTree@@QAEJPAUDiskFileInfo_t@@@Z

        // BTree.Lookup:
        // public BTEntry* Lookup(UInt32 id, BTMemNode** ppNode) => ((delegate* unmanaged[Thiscall]<ref BTree, UInt32, BTMemNode**, BTEntry*>)0xDEADBEEF)(ref this, id, ppNode); // .text:00673800 ; BTEntry *__thiscall BTree::Lookup(BTree *this, IDClass<_tagDataID,32,0> id, BTMemNode **ppNode) .text:00673800 ?Lookup@BTree@@QAEPAUBTEntry@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@PAPAUBTMemNode@@@Z

        // BTree.MergeNodesExec:
        // public int MergeNodesExec(MergeNodesTransactInfo* pTrIn) => ((delegate* unmanaged[Thiscall]<ref BTree, MergeNodesTransactInfo*, int>)0xDEADBEEF)(ref this, pTrIn); // .text:006729C0 ; int __thiscall BTree::MergeNodesExec(BTree *this, MergeNodesTransactInfo *pTrIn) .text:006729C0 ?MergeNodesExec@BTree@@IAEJPBVMergeNodesTransactInfo@@@Z

        // BTree.MergeNodesTrans:
        // public int MergeNodesTrans(BTMemNode* pNode, BTMemNode* pLeftKid, BTMemNode* pRightKid, int index) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, BTMemNode*, BTMemNode*, int, int>)0xDEADBEEF)(ref this, pNode, pLeftKid, pRightKid, index); // .text:00673560 ; int __thiscall BTree::MergeNodesTrans(BTree *this, BTMemNode *pNode, BTMemNode *pLeftKid, BTMemNode *pRightKid, int index) .text:00673560 ?MergeNodesTrans@BTree@@IAEJPAUBTMemNode@@00J@Z

        // BTree.RecoverTransaction:
        // public int RecoverTransaction(DiskTransactInfo* pTrIn) => ((delegate* unmanaged[Thiscall]<ref BTree, DiskTransactInfo*, int>)0xDEADBEEF)(ref this, pTrIn); // .text:00673020 ; int __thiscall BTree::RecoverTransaction(BTree *this, DiskTransactInfo *pTrIn) .text:00673020 ?RecoverTransaction@BTree@@QAEJPBVDiskTransactInfo@@@Z

        // BTree.Remove:
        // public Byte Remove(UInt32 target) => ((delegate* unmanaged[Thiscall]<ref BTree, UInt32, Byte>)0xDEADBEEF)(ref this, target); // .text:00673B50 ; bool __thiscall BTree::Remove(BTree *this, IDClass<_tagDataID,32,0> target) .text:00673B50 ?Remove@BTree@@QAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // BTree.RemoveLeast:
        // public BTEntry* RemoveLeast(BTEntry* result, BTMemNode* pNode, int* pOutLink) => ((delegate* unmanaged[Thiscall]<ref BTree, BTEntry*, BTMemNode*, int*, BTEntry*>)0xDEADBEEF)(ref this, result, pNode, pOutLink); // .text:00671E00 ; BTEntry *__thiscall BTree::RemoveLeast(BTree *this, BTEntry *result, BTMemNode *pNode, int *pOutLink) .text:00671E00 ?RemoveLeast@BTree@@IAE?AUBTEntry@@PAUBTMemNode@@PAJ@Z

        // BTree.Restamp_Entry:
        // public void Restamp_Entry(UInt32 gid) => ((delegate* unmanaged[Thiscall]<ref BTree, UInt32, void>)0xDEADBEEF)(ref this, gid); // .text:00671F00 ; void __thiscall BTree::Restamp_Entry(BTree *this, IDClass<_tagDataID,32,0> gid) .text:00671F00 ?Restamp_Entry@BTree@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // BTree.RotateEntryExec:
        // public int RotateEntryExec(RotateEntryTransactInfo* pTrIn) => ((delegate* unmanaged[Thiscall]<ref BTree, RotateEntryTransactInfo*, int>)0xDEADBEEF)(ref this, pTrIn); // .text:00672E80 ; int __thiscall BTree::RotateEntryExec(BTree *this, RotateEntryTransactInfo *pTrIn) .text:00672E80 ?RotateEntryExec@BTree@@IAEJPBVRotateEntryTransactInfo@@@Z

        // BTree.RotateEntryTrans:
        // public int RotateEntryTrans(BTMemNode* pParent, int index, int nodeEntryCount, int siblingEntryCount, Byte fLeftSibling) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, int, int, int, Byte, int>)0xDEADBEEF)(ref this, pParent, index, nodeEntryCount, siblingEntryCount, fLeftSibling); // .text:006736B0 ; int __thiscall BTree::RotateEntryTrans(BTree *this, BTMemNode *pParent, int index, int nodeEntryCount, int siblingEntryCount, bool fLeftSibling) .text:006736B0 ?RotateEntryTrans@BTree@@IAEJPAUBTMemNode@@JJJ_N@Z

        // BTree.SaveDataToFile:
        // public int SaveDataToFile() => ((delegate* unmanaged[Thiscall]<ref BTree, int>)0xDEADBEEF)(ref this); // .text:00672280 ; int __thiscall BTree::SaveDataToFile(BTree *this) .text:00672280 ?SaveDataToFile@BTree@@QAEJXZ

        // BTree.Search:
        // public BTEntry* Search(BTMemNode* pNode, UInt32 GId, BTMemNode** ppNode) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, UInt32, BTMemNode**, BTEntry*>)0xDEADBEEF)(ref this, pNode, GId, ppNode); // .text:006731C0 ; BTEntry *__thiscall BTree::Search(BTree *this, BTMemNode *pNode, IDClass<_tagDataID,32,0> GId, BTMemNode **ppNode) .text:006731C0 ?Search@BTree@@IAEPAUBTEntry@@PAUBTMemNode@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@PAPAU3@@Z

        // BTree.SplitNodeExec:
        // public int SplitNodeExec(SplitNodeTransactInfo* pTrIn) => ((delegate* unmanaged[Thiscall]<ref BTree, SplitNodeTransactInfo*, int>)0xDEADBEEF)(ref this, pTrIn); // .text:00672540 ; int __thiscall BTree::SplitNodeExec(BTree *this, SplitNodeTransactInfo *pTrIn) .text:00672540 ?SplitNodeExec@BTree@@IAEJPBVSplitNodeTransactInfo@@@Z

        // BTree.SplitNodeTrans:
        // public int SplitNodeTrans(BTMemNode* pParent, int splitIndex, BTMemNode* pNode) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, int, BTMemNode*, int>)0xDEADBEEF)(ref this, pParent, splitIndex, pNode); // .text:00673240 ; int __thiscall BTree::SplitNodeTrans(BTree *this, BTMemNode *pParent, int splitIndex, BTMemNode *pNode) .text:00673240 ?SplitNodeTrans@BTree@@IAEJPAUBTMemNode@@J0@Z

        // BTree.Try_Delete_Oldest:
        // public Byte Try_Delete_Oldest() => ((delegate* unmanaged[Thiscall]<ref BTree, Byte>)0xDEADBEEF)(ref this); // .text:00673BD0 ; bool __thiscall BTree::Try_Delete_Oldest(BTree *this) .text:00673BD0 ?Try_Delete_Oldest@BTree@@QAE_NXZ

        // BTree.UpdateNode:
        // public int UpdateNode(BTMemNode* pTarget, BTMemNode* pParent) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, BTMemNode*, int>)0xDEADBEEF)(ref this, pTarget, pParent); // .text:00671E90 ; int __thiscall BTree::UpdateNode(BTree *this, BTMemNode *pTarget, BTMemNode *pParent) .text:00671E90 ?UpdateNode@BTree@@QAEJPAUBTMemNode@@0@Z

        // BTree.UpdateObjectExec:
        // public int UpdateObjectExec(UpdateObjectTransactInfo* pTrIn, Cache_Pack_t* pack_buf) => ((delegate* unmanaged[Thiscall]<ref BTree, UpdateObjectTransactInfo*, Cache_Pack_t*, int>)0xDEADBEEF)(ref this, pTrIn, pack_buf); // .text:00672830 ; int __thiscall BTree::UpdateObjectExec(BTree *this, UpdateObjectTransactInfo *pTrIn, Cache_Pack_t *pack_buf) .text:00672830 ?UpdateObjectExec@BTree@@IAEJPBVUpdateObjectTransactInfo@@AAVCache_Pack_t@@@Z

        // BTree.Update_Data_Trans:
        // public int Update_Data_Trans(BTMemNode* pNode, BTEntry* entry, Cache_Pack_t* pack_buf) => ((delegate* unmanaged[Thiscall]<ref BTree, BTMemNode*, BTEntry*, Cache_Pack_t*, int>)0xDEADBEEF)(ref this, pNode, entry, pack_buf); // .text:00673320 ; int __thiscall BTree::Update_Data_Trans(BTree *this, BTMemNode *pNode, BTEntry *entry, Cache_Pack_t *pack_buf) .text:00673320 ?Update_Data_Trans@BTree@@QAEJPAUBTMemNode@@AAUBTEntry@@AAVCache_Pack_t@@@Z
    }
    public unsafe struct BTMemNode {
        // Struct:
        public int time_stamp_lm;
        public Byte dirty_fm;
        public BTMemNode* ahead_pm;
        public BTMemNode* behind_pm;
        public int offset_m;
        public BTNode node_m;
        public override string ToString() => $"time_stamp_lm(int):{time_stamp_lm}, dirty_fm:{dirty_fm:X2}, ahead_pm:->(BTMemNode*)0x{(int)ahead_pm:X8}, behind_pm:->(BTMemNode*)0x{(int)behind_pm:X8}, offset_m(int):{offset_m}, node_m(BTNode):{node_m}";
    }
    public unsafe struct BTNode {
        // Struct:
        public fixed int NextNode_[62];
        public int NumEntries_;
        public fixed int Entry_[61];
        public override string ToString() => $"NextNode_[62](fixed int):{NextNode_[62]}, NumEntries_(int):{NumEntries_}, Entry_[61](fixed int):{Entry_[61]}";

        // Functions:

        // BTNode.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref BTNode, void>)0xDEADBEEF)(ref this); // .text:00671F20 ; void __thiscall BTNode::BTNode(BTNode *this) .text:00671F20 ??0BTNode@@QAE@XZ
    }
    public unsafe struct CLBlockAllocator {
        // Struct:
        public DiskFileInfo_t* file_info_mp;
        public DiskDev file_man_m;
        public Byte expandable_mf;
        public override string ToString() => $"file_info_mp:->(DiskFileInfo_t*)0x{(int)file_info_mp:X8}, file_man_m(DiskDev):{file_man_m}, expandable_mf:{expandable_mf:X2}";

        // Functions:

        // CLBlockAllocator.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, void>)0xDEADBEEF)(ref this); // .text:00673E80 ; void __thiscall CLBlockAllocator::CLBlockAllocator(CLBlockAllocator *this) .text:00673E80 ??0CLBlockAllocator@@QAE@XZ

        // CLBlockAllocator.ClearTransaction:
        // public int ClearTransaction() => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, int>)0xDEADBEEF)(ref this); // .text:006746E0 ; int __thiscall CLBlockAllocator::ClearTransaction(CLBlockAllocator *this) .text:006746E0 ?ClearTransaction@CLBlockAllocator@@QAEJXZ

        // CLBlockAllocator.Close_Data_File:
        // public int Close_Data_File() => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, int>)0xDEADBEEF)(ref this); // .text:00673EB0 ; int __thiscall CLBlockAllocator::Close_Data_File(CLBlockAllocator *this) .text:00673EB0 ?Close_Data_File@CLBlockAllocator@@QAEJXZ

        // CLBlockAllocator.CreateDataFile:
        // public int CreateDataFile(DiskFileInfo_t* file_info_p, PStringBase<char>* file_name_cp, PStringBase<UInt16>* path_cp, UInt32 open_flags_l) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, DiskFileInfo_t*, PStringBase<char>*, PStringBase<UInt16>*, UInt32, int>)0xDEADBEEF)(ref this, file_info_p, file_name_cp, path_cp, open_flags_l); // .text:006747E0 ; int __thiscall CLBlockAllocator::CreateDataFile(CLBlockAllocator *this, DiskFileInfo_t *file_info_p, PStringBase<char> *file_name_cp, PStringBase<unsigned short> *path_cp, unsigned int open_flags_l) .text:006747E0 ?CreateDataFile@CLBlockAllocator@@QAEJPAUDiskFileInfo_t@@ABV?$PStringBase@D@@ABV?$PStringBase@G@@K@Z

        // CLBlockAllocator.DeleteBlocks:
        // public int DeleteBlocks(int startOffset, int finalOffset, int oldFreeCount, Byte fRefree) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, int, int, int, Byte, int>)0xDEADBEEF)(ref this, startOffset, finalOffset, oldFreeCount, fRefree); // .text:00673FB0 ; int __thiscall CLBlockAllocator::DeleteBlocks(CLBlockAllocator *this, int startOffset, int finalOffset, int oldFreeCount, bool fRefree) .text:00673FB0 ?DeleteBlocks@CLBlockAllocator@@QAEJJJJ_N@Z

        // CLBlockAllocator.ExpandFile:
        // public int ExpandFile(int size_l) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, int, int>)0xDEADBEEF)(ref this, size_l); // .text:006740A0 ; int __thiscall CLBlockAllocator::ExpandFile(CLBlockAllocator *this, int size_l) .text:006740A0 ?ExpandFile@CLBlockAllocator@@QAEJJ@Z

        // CLBlockAllocator.Load_Data:
        // public Byte Load_Data(Cache_Pack_t* buf_out, int offset, Byte bShortRead) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, Cache_Pack_t*, int, Byte, Byte>)0xDEADBEEF)(ref this, buf_out, offset, bShortRead); // .text:006744E0 ; bool __thiscall CLBlockAllocator::Load_Data(CLBlockAllocator *this, Cache_Pack_t *buf_out, int offset, bool bShortRead) .text:006744E0 ?Load_Data@CLBlockAllocator@@QAE_NAAVCache_Pack_t@@J_N@Z

        // CLBlockAllocator.OpenDataFile:
        // public int OpenDataFile(DiskFileInfo_t* pFileInfo, PStringBase<char>* pFileName, PStringBase<UInt16>* pcPathToUse, UInt32 open_flags_l, DiskTransactInfo** pTranInfo) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, DiskFileInfo_t*, PStringBase<char>*, PStringBase<UInt16>*, UInt32, DiskTransactInfo**, int>)0xDEADBEEF)(ref this, pFileInfo, pFileName, pcPathToUse, open_flags_l, pTranInfo); // .text:00674980 ; int __thiscall CLBlockAllocator::OpenDataFile(CLBlockAllocator *this, DiskFileInfo_t *pFileInfo, PStringBase<char> *pFileName, PStringBase<unsigned short> *pcPathToUse, unsigned int open_flags_l, DiskTransactInfo **pTranInfo) .text:00674980 ?OpenDataFile@CLBlockAllocator@@QAEJPAUDiskFileInfo_t@@ABV?$PStringBase@D@@ABV?$PStringBase@G@@KAAPAVDiskTransactInfo@@@Z

        // CLBlockAllocator.ReadTransaction:
        // public int ReadTransaction(DiskTransactInfo** pTranInfo) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, DiskTransactInfo**, int>)0xDEADBEEF)(ref this, pTranInfo); // .text:00674700 ; int __thiscall CLBlockAllocator::ReadTransaction(CLBlockAllocator *this, DiskTransactInfo **pTranInfo) .text:00674700 ?ReadTransaction@CLBlockAllocator@@IAEJAAPAVDiskTransactInfo@@@Z

        // CLBlockAllocator.SaveFileInfo:
        // public int SaveFileInfo() => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, int>)0xDEADBEEF)(ref this); // .text:00673ED0 ; int __thiscall CLBlockAllocator::SaveFileInfo(CLBlockAllocator *this) .text:00673ED0 ?SaveFileInfo@CLBlockAllocator@@QAEJXZ

        // CLBlockAllocator.SaveTransaction:
        // public int SaveTransaction(DiskTransactInfo* pTransInfo) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, DiskTransactInfo*, int>)0xDEADBEEF)(ref this, pTransInfo); // .text:00674640 ; int __thiscall CLBlockAllocator::SaveTransaction(CLBlockAllocator *this, DiskTransactInfo *pTransInfo) .text:00674640 ?SaveTransaction@CLBlockAllocator@@QAEJPAVDiskTransactInfo@@@Z

        // CLBlockAllocator.StoreDataRollback:
        // public int StoreDataRollback(UInt32 dataSize, int startOffset) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, UInt32, int, int>)0xDEADBEEF)(ref this, dataSize, startOffset); // .text:00673EF0 ; int __thiscall CLBlockAllocator::StoreDataRollback(CLBlockAllocator *this, unsigned int dataSize, int startOffset) .text:00673EF0 ?StoreDataRollback@CLBlockAllocator@@QAEJIJ@Z

        // CLBlockAllocator.Store_Data:
        // public int Store_Data(Cache_Pack_t* pack_buf, int startOffset) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, Cache_Pack_t*, int, int>)0xDEADBEEF)(ref this, pack_buf, startOffset); // .text:006741B0 ; int __thiscall CLBlockAllocator::Store_Data(CLBlockAllocator *this, Cache_Pack_t *pack_buf, int startOffset) .text:006741B0 ?Store_Data@CLBlockAllocator@@QAEJAAVCache_Pack_t@@J@Z

        // CLBlockAllocator.Update:
        // public int Update(Cache_Pack_t* pack_buf, int inOffset) => ((delegate* unmanaged[Thiscall]<ref CLBlockAllocator, Cache_Pack_t*, int, int>)0xDEADBEEF)(ref this, pack_buf, inOffset); // .text:00674300 ; int __thiscall CLBlockAllocator::Update(CLBlockAllocator *this, Cache_Pack_t *pack_buf, int inOffset) .text:00674300 ?Update@CLBlockAllocator@@QAEJAAVCache_Pack_t@@J@Z
    }
    public unsafe struct DiskDev {
        // Struct:
        public void* _fd;
        public override string ToString() => $"_fd:->(void*)0x{(int)_fd:X8}";

        // Functions:

        // DiskDev.Close:
        // public int Close() => ((delegate* unmanaged[Thiscall]<ref DiskDev, int>)0xDEADBEEF)(ref this); // .text:00676C10 ; int __thiscall DiskDev::Close(DiskDev *this) .text:00676C10 ?Close@DiskDev@@QAEJXZ

        // DiskDev.Open_File:
        // public int Open_File(PStringBase<UInt16>* file_cp, PStringBase<UInt16>* path_cp, DiskFileInfo_t* header_p, UInt32 open_flags_l) => ((delegate* unmanaged[Thiscall]<ref DiskDev, PStringBase<UInt16>*, PStringBase<UInt16>*, DiskFileInfo_t*, UInt32, int>)0xDEADBEEF)(ref this, file_cp, path_cp, header_p, open_flags_l); // .text:00676D20 ; int __thiscall DiskDev::Open_File(DiskDev *this, PStringBase<unsigned short> *file_cp, PStringBase<unsigned short> *path_cp, DiskFileInfo_t *header_p, unsigned int open_flags_l) .text:00676D20 ?Open_File@DiskDev@@QAEJABV?$PStringBase@G@@0PAUDiskFileInfo_t@@K@Z

        // DiskDev.SyncRead:
        // public int SyncRead(void* buf, UInt32 size, int off) => ((delegate* unmanaged[Thiscall]<ref DiskDev, void*, UInt32, int, int>)0xDEADBEEF)(ref this, buf, size, off); // .text:00676C60 ; int __thiscall DiskDev::SyncRead(DiskDev *this, void *buf, unsigned int size, int off) .text:00676C60 ?SyncRead@DiskDev@@QAEJPAXIJ@Z

        // DiskDev.SyncWrite:
        // public int SyncWrite(void* buf, UInt32 size, int off) => ((delegate* unmanaged[Thiscall]<ref DiskDev, void*, UInt32, int, int>)0xDEADBEEF)(ref this, buf, size, off); // .text:00676CC0 ; int __thiscall DiskDev::SyncWrite(DiskDev *this, void *buf, unsigned int size, int off) .text:00676CC0 ?SyncWrite@DiskDev@@QAEJPAXIJ@Z
    }

    public unsafe struct LRU_List {
        // Struct:
        public Byte initialized_fm;
        public Byte empty_fm;
        public int used_count_lm;
        public HashList<UInt32, Byte> used_table_m;
        public HashSet<UInt32> dead_table_m;
        public LRUB_Mem_t* young_pm;
        public LRUB_Mem_t* old_pm;
        public CLBlockAllocator* block_man_pm;
        public DiskFileInfo_t* file_info_pm;
        public override string ToString() => $"initialized_fm:{initialized_fm:X2}, empty_fm:{empty_fm:X2}, used_count_lm(int):{used_count_lm}, used_table_m(HashList<UInt32,Byte,1>):{used_table_m}, dead_table_m(HashSet<UInt32 >):{dead_table_m}, young_pm:->(LRUB_Mem_t*)0x{(int)young_pm:X8}, old_pm:->(LRUB_Mem_t*)0x{(int)old_pm:X8}, block_man_pm:->(CLBlockAllocator*)0x{(int)block_man_pm:X8}, file_info_pm:->(DiskFileInfo_t*)0x{(int)file_info_pm:X8}";

        // Functions:

        // LRU_List.__Ctor:
        // public void __Ctor(CLBlockAllocator* block_man_p, DiskFileInfo_t* file_info_p) => ((delegate* unmanaged[Thiscall]<ref LRU_List, CLBlockAllocator*, DiskFileInfo_t*, void>)0xDEADBEEF)(ref this, block_man_p, file_info_p); // .text:00675CD0 ; void __thiscall LRU_List::LRU_List(LRU_List *this, CLBlockAllocator *block_man_p, DiskFileInfo_t *file_info_p) .text:00675CD0 ??0LRU_List@@QAE@PAVCLBlockAllocator@@PAUDiskFileInfo_t@@@Z

        // LRU_List.Add_Exec:
        // public Byte Add_Exec(UInt32 target_did) => ((delegate* unmanaged[Thiscall]<ref LRU_List, UInt32, Byte>)0xDEADBEEF)(ref this, target_did); // .text:00674E00 ; bool __thiscall LRU_List::Add_Exec(LRU_List *this, IDClass<_tagDataID,32,0> target_did) .text:00674E00 ?Add_Exec@LRU_List@@IAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // LRU_List.Create_List:
        // public Byte Create_List() => ((delegate* unmanaged[Thiscall]<ref LRU_List, Byte>)0xDEADBEEF)(ref this); // .text:00674B10 ; bool __thiscall LRU_List::Create_List(LRU_List *this) .text:00674B10 ?Create_List@LRU_List@@QAE_NXZ

        // LRU_List.Delete_Exec:
        // public Byte Delete_Exec(LRUDeleteTransactInfo* pTrIn) => ((delegate* unmanaged[Thiscall]<ref LRU_List, LRUDeleteTransactInfo*, Byte>)0xDEADBEEF)(ref this, pTrIn); // .text:00674FD0 ; bool __thiscall LRU_List::Delete_Exec(LRU_List *this, LRUDeleteTransactInfo *pTrIn) .text:00674FD0 ?Delete_Exec@LRU_List@@IAE_NPBVLRUDeleteTransactInfo@@@Z

        // LRU_List.Delete_Trans:
        // public Byte Delete_Trans(LRUB_Mem_t* block_p, Byte clear_f) => ((delegate* unmanaged[Thiscall]<ref LRU_List, LRUB_Mem_t*, Byte, Byte>)0xDEADBEEF)(ref this, block_p, clear_f); // .text:006752A0 ; bool __thiscall LRU_List::Delete_Trans(LRU_List *this, LRUB_Mem_t *block_p, bool clear_f) .text:006752A0 ?Delete_Trans@LRU_List@@IAE_NPAULRUB_Mem_t@@_N@Z

        // LRU_List.Expand_Exec:
        // public Byte Expand_Exec(LRUExpandTransactInfo* pTrIn) => ((delegate* unmanaged[Thiscall]<ref LRU_List, LRUExpandTransactInfo*, Byte>)0xDEADBEEF)(ref this, pTrIn); // .text:00674E90 ; bool __thiscall LRU_List::Expand_Exec(LRU_List *this, LRUExpandTransactInfo *pTrIn) .text:00674E90 ?Expand_Exec@LRU_List@@IAE_NPBVLRUExpandTransactInfo@@@Z

        // LRU_List.Expand_Trans:
        // public Byte Expand_Trans(UInt32 target_did, Byte clear_f) => ((delegate* unmanaged[Thiscall]<ref LRU_List, UInt32, Byte, Byte>)0xDEADBEEF)(ref this, target_did, clear_f); // .text:00675180 ; bool __thiscall LRU_List::Expand_Trans(LRU_List *this, IDClass<_tagDataID,32,0> target_did, bool clear_f) .text:00675180 ?Expand_Trans@LRU_List@@IAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@_N@Z

        // LRU_List.Get_Oldest:
        // public UInt32* Get_Oldest(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref LRU_List, UInt32*, UInt32*>)0xDEADBEEF)(ref this, result); // .text:006754C0 ; IDClass<_tagDataID,32,0> *__thiscall LRU_List::Get_Oldest(LRU_List *this, IDClass<_tagDataID,32,0> *result) .text:006754C0 ?Get_Oldest@LRU_List@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // LRU_List.Load_List:
        // public Byte Load_List() => ((delegate* unmanaged[Thiscall]<ref LRU_List, Byte>)0xDEADBEEF)(ref this); // .text:00674CA0 ; bool __thiscall LRU_List::Load_List(LRU_List *this) .text:00674CA0 ?Load_List@LRU_List@@QAE_NXZ

        // LRU_List.Mark_Deleted:
        // public void Mark_Deleted(UInt32 target_did) => ((delegate* unmanaged[Thiscall]<ref LRU_List, UInt32, void>)0xDEADBEEF)(ref this, target_did); // .text:00675E50 ; void __thiscall LRU_List::Mark_Deleted(LRU_List *this, IDClass<_tagDataID,32,0> target_did) .text:00675E50 ?Mark_Deleted@LRU_List@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // LRU_List.Mark_Used:
        // public void Mark_Used(UInt32 target_did) => ((delegate* unmanaged[Thiscall]<ref LRU_List, UInt32, void>)0xDEADBEEF)(ref this, target_did); // .text:00676160 ; void __thiscall LRU_List::Mark_Used(LRU_List *this, IDClass<_tagDataID,32,0> target_did) .text:00676160 ?Mark_Used@LRU_List@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // LRU_List.Purge_Duplicates:
        // public void Purge_Duplicates(int was_offset_l, int was_index_l) => ((delegate* unmanaged[Thiscall]<ref LRU_List, int, int, void>)0xDEADBEEF)(ref this, was_offset_l, was_index_l); // .text:00675900 ; void __thiscall LRU_List::Purge_Duplicates(LRU_List *this, int was_offset_l, int was_index_l) .text:00675900 ?Purge_Duplicates@LRU_List@@IAEXJJ@Z

        // LRU_List.Write_Added:
        // public Byte Write_Added(UInt32 target_did) => ((delegate* unmanaged[Thiscall]<ref LRU_List, UInt32, Byte>)0xDEADBEEF)(ref this, target_did); // .text:00675890 ; bool __thiscall LRU_List::Write_Added(LRU_List *this, IDClass<_tagDataID,32,0> target_did) .text:00675890 ?Write_Added@LRU_List@@QAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // LRU_List.Write_All_Out:
        // public Byte Write_All_Out() => ((delegate* unmanaged[Thiscall]<ref LRU_List, Byte>)0xDEADBEEF)(ref this); // .text:00675E90 ; bool __thiscall LRU_List::Write_All_Out(LRU_List *this) .text:00675E90 ?Write_All_Out@LRU_List@@QAE_NXZ
    }
    public unsafe struct LRUB_Mem_t {
        // Struct:
        public int offset_lm;
        public int size_lm;
        public int max_lm;
        public int above_lm;
        public int below_lm;
        public LRUB_Info_t* info_pm;
        public UInt32* DIds_pm;
        public char* buffer_cpm;
        public override string ToString() => $"offset_lm(int):{offset_lm}, size_lm(int):{size_lm}, max_lm(int):{max_lm}, above_lm(int):{above_lm}, below_lm(int):{below_lm}, info_pm:->(LRUB_Info_t*)0x{(int)info_pm:X8}, DIds_pm:->(UInt32*)0x{(int)DIds_pm:X8}, buffer_cpm:->(char*)0x{(int)buffer_cpm:X8}";

        // Functions:

        // LRUB_Mem_t.__Ctor:
        // public void __Ctor(LRUB_Mem_t* source) => ((delegate* unmanaged[Thiscall]<ref LRUB_Mem_t, LRUB_Mem_t*, void>)0xDEADBEEF)(ref this, source); // .text:00674A30 ; void __thiscall LRUB_Mem_t::LRUB_Mem_t(LRUB_Mem_t *this, LRUB_Mem_t *source) .text:00674A30 ??0LRUB_Mem_t@@QAE@ABU0@@Z

        // LRUB_Mem_t.__Ctor:
        // public void __Ctor(int block_size_l) => ((delegate* unmanaged[Thiscall]<ref LRUB_Mem_t, int, void>)0xDEADBEEF)(ref this, block_size_l); // .text:00674B60 ; void __thiscall LRUB_Mem_t::LRUB_Mem_t(LRUB_Mem_t *this, int block_size_l) .text:00674B60 ??0LRUB_Mem_t@@QAE@J@Z

        // LRUB_Mem_t.Make_Buffer:
        // public void Make_Buffer(int size_l) => ((delegate* unmanaged[Thiscall]<ref LRUB_Mem_t, int, void>)0xDEADBEEF)(ref this, size_l); // .text:00674AB0 ; void __thiscall LRUB_Mem_t::Make_Buffer(LRUB_Mem_t *this, int size_l) .text:00674AB0 ?Make_Buffer@LRUB_Mem_t@@QAEXJ@Z

        // LRUB_Mem_t.Peek_Above:
        // public UInt32* Peek_Above(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref LRUB_Mem_t, UInt32*, UInt32*>)0xDEADBEEF)(ref this, result); // .text:00674C30 ; IDClass<_tagDataID,32,0> *__thiscall LRUB_Mem_t::Peek_Above(LRUB_Mem_t *this, IDClass<_tagDataID,32,0> *result) .text:00674C30 ?Peek_Above@LRUB_Mem_t@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // LRUB_Mem_t.Remove_Above:
        // public UInt32* Remove_Above(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref LRUB_Mem_t, UInt32*, UInt32*>)0xDEADBEEF)(ref this, result); // .text:00674BE0 ; IDClass<_tagDataID,32,0> *__thiscall LRUB_Mem_t::Remove_Above(LRUB_Mem_t *this, IDClass<_tagDataID,32,0> *result) .text:00674BE0 ?Remove_Above@LRUB_Mem_t@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // LRUB_Mem_t.Remove_Below:
        // public UInt32* Remove_Below(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref LRUB_Mem_t, UInt32*, UInt32*>)0xDEADBEEF)(ref this, result); // .text:00674BA0 ; IDClass<_tagDataID,32,0> *__thiscall LRUB_Mem_t::Remove_Below(LRUB_Mem_t *this, IDClass<_tagDataID,32,0> *result) .text:00674BA0 ?Remove_Below@LRUB_Mem_t@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ
    }
    public unsafe struct LRUB_Info_t {
        // Struct:
        public int link_padding_lm;
        public int younger_lm;
        public int older_lm;
        public int used_lm;
        public override string ToString() => $"link_padding_lm(int):{link_padding_lm}, younger_lm(int):{younger_lm}, older_lm(int):{older_lm}, used_lm(int):{used_lm}";
    }
    public unsafe struct CMostlyConsecutiveIntSet {
        // Struct:
        public CMostlyConsecutiveIntSet.Vtbl* vfptr;
        public SmartArray<int> m_Ints;
        public Byte m_bSorted;
        public override string ToString() => $"vfptr:->(CMostlyConsecutiveIntSet.Vtbl*)0x{(int)vfptr:X8}, m_Ints(SmartArray<int,1>):{m_Ints}, m_bSorted:{m_bSorted:X2}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<CMostlyConsecutiveIntSet*, Archive*, void> Serialize; // void (__thiscall *Serialize)(CMostlyConsecutiveIntSet *this, Archive *);
        }

        // Functions:

        // CMostlyConsecutiveIntSet.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CMostlyConsecutiveIntSet, void>)0x00670FC0)(ref this); // .text:00670020 ; void __thiscall CMostlyConsecutiveIntSet::CMostlyConsecutiveIntSet(CMostlyConsecutiveIntSet *this) .text:00670020 ??0CMostlyConsecutiveIntSet@@QAE@XZ

        // CMostlyConsecutiveIntSet.Add:
        public Byte Add(int NewInt) => ((delegate* unmanaged[Thiscall]<ref CMostlyConsecutiveIntSet, int, Byte>)0x00671280)(ref this, NewInt); // .text:006702E0 ; bool __thiscall CMostlyConsecutiveIntSet::Add(CMostlyConsecutiveIntSet *this, int NewInt) .text:006702E0 ?Add@CMostlyConsecutiveIntSet@@QAE_NH@Z

        // CMostlyConsecutiveIntSet.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref CMostlyConsecutiveIntSet, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:006700A0 ; void __thiscall CMostlyConsecutiveIntSet::Serialize(CMostlyConsecutiveIntSet *this, Archive *io_archive) .text:006700A0 ?Serialize@CMostlyConsecutiveIntSet@@UAEXAAVArchive@@@Z

        // CMostlyConsecutiveIntSet.Sort:
        public void Sort() => ((delegate* unmanaged[Thiscall]<ref CMostlyConsecutiveIntSet, void>)0x00670F20)(ref this); // .text:0066FF80 ; void __thiscall CMostlyConsecutiveIntSet::Sort(CMostlyConsecutiveIntSet *this) .text:0066FF80 ?Sort@CMostlyConsecutiveIntSet@@QAEXXZ
    }

}