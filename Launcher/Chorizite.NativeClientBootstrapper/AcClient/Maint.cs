using System;
using System.Runtime.InteropServices;

//[UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate void* __vecDelDtor(* This, UInt32 a2); // 
namespace AcClient {

    public unsafe struct CObjectMaint {
        public Interface a0;
        public NoticeHandler a1;
        public Turbine_RefCount m_cTurbineRefCount;
        public Int32 is_active;
        public IntrusiveHashTable<UInt32, CLostCell> lost_cell_table;
        public LongHash<CPhysicsObj> object_table;
        public LongHash<CPhysicsObj> null_object_table;
        public LongHash<CWeenieObject> weenie_object_table;
        public LongHash<CWeenieObject> null_weenie_object_table;
        public HashSet<UInt32> visible_object_table;
        public HashTable<UInt32, Double> destruction_object_table;
        public LongHash<CObjectInventory> object_inventory_table;
        public AC1Legacy.PQueueArray<Double> object_destruction_queue;
        public override string ToString() => $"a0(Interface):{a0}, a1(NoticeHandler):{a1}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, is_active:{is_active}, lost_cell_table(IntrusiveHashTable<UInt32,CLostCell*,0>):{lost_cell_table}, object_table(LongHash<CPhysicsObj>):{object_table}, null_object_table(LongHash<CPhysicsObj>):{null_object_table}, weenie_object_table(LongHash<CWeenieObject>):{weenie_object_table}, null_weenie_object_table(LongHash<CWeenieObject>):{null_weenie_object_table}, visible_object_table(HashSet<UInt32>):{visible_object_table}, destruction_object_table(HashTable<UInt32,Double,0>):{destruction_object_table}, object_inventory_table(LongHash<CObjectInventory>):{object_inventory_table}, object_destruction_queue(AC1Legacy.PQueueArray<Double>):{object_destruction_queue}";

        // Functions:

        // CObjectMaint.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, void>)0x005090A0)(ref this); // .text:005085D0 ; void __thiscall CObjectMaint::CObjectMaint(CObjectMaint *this) .text:005085D0 ??0CObjectMaint@@IAE@XZ

        // CObjectMaint.AddObject:
        public void AddObject(CPhysicsObj* _object) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, CPhysicsObj*, void>)0x00508810)(ref this, _object); // .text:00507CE0 ; void __thiscall CObjectMaint::AddObject(CObjectMaint *this, CPhysicsObj *object) .text:00507CE0 ?AddObject@CObjectMaint@@QAEXPAVCPhysicsObj@@@Z

        // CObjectMaint.AddObjectToBeDestroyed:
        public void AddObjectToBeDestroyed(UInt32 object_id) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, void>)0x00509A40)(ref this, object_id); // .text:00508F70 ; void __thiscall CObjectMaint::AddObjectToBeDestroyed(CObjectMaint *this, unsigned int object_id) .text:00508F70 ?AddObjectToBeDestroyed@CObjectMaint@@QAEXK@Z

        // CObjectMaint.AddWeenieObject:
        public void AddWeenieObject(CWeenieObject* _object) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, CWeenieObject*, void>)0x00508850)(ref this, _object); // .text:00507D20 ; void __thiscall CObjectMaint::AddWeenieObject(CObjectMaint *this, CWeenieObject *object) .text:00507D20 ?AddWeenieObject@CObjectMaint@@QAEXPAVCWeenieObject@@@Z

        // CObjectMaint.CreateObject:
        public CPhysicsObj* CreateObject(UInt32 objectID, VisualDesc* vdesc, PhysicsDesc* physicsdesc, WeenieDesc* wdesc) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, VisualDesc*, PhysicsDesc*, WeenieDesc*, CPhysicsObj*>)0x00509410)(ref this, objectID, vdesc, physicsdesc, wdesc); // .text:00508940 ; CPhysicsObj *__thiscall CObjectMaint::CreateObject(CObjectMaint *this, unsigned int objectID, VisualDesc *vdesc, PhysicsDesc *physicsdesc, WeenieDesc *wdesc) .text:00508940 ?CreateObject@CObjectMaint@@UAEPAVCPhysicsObj@@KPAVVisualDesc@@PAVPhysicsDesc@@PAVWeenieDesc@@@Z

        // CObjectMaint.DeleteObject:
        public void DeleteObject(CPhysicsObj* _object) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, CPhysicsObj*, void>)0x00508F30)(ref this, _object); // .text:00508460 ; void __thiscall CObjectMaint::DeleteObject(CObjectMaint *this, CPhysicsObj *object) .text:00508460 ?DeleteObject@CObjectMaint@@IAEXPAVCPhysicsObj@@@Z

        // CObjectMaint.DeleteObject:
        public int DeleteObject(UInt32 object_id) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, int>)0x00508FA0)(ref this, object_id); // .text:005084D0 ; int __thiscall CObjectMaint::DeleteObject(CObjectMaint *this, unsigned int object_id) .text:005084D0 ?DeleteObject@CObjectMaint@@UAEHK@Z

        // CObjectMaint.DestroyObjects:
        public void DestroyObjects() => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, void>)0x00509700)(ref this); // .text:00508C30 ; void __thiscall CObjectMaint::DestroyObjects(CObjectMaint *this) .text:00508C30 ?DestroyObjects@CObjectMaint@@QAEXXZ

        // CObjectMaint.GetLostCell:
        public CLostCell* GetLostCell(UInt32 cell_id) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, CLostCell*>)0x00508C70)(ref this, cell_id); // .text:005081A0 ; CLostCell *__thiscall CObjectMaint::GetLostCell(CObjectMaint *this, unsigned int cell_id) .text:005081A0 ?GetLostCell@CObjectMaint@@IAEPAVCLostCell@@K@Z

        // CObjectMaint.GetNullObject:
        public CPhysicsObj* GetNullObject(UInt32 object_id, int create_new_object) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, int, CPhysicsObj*>)0x00509AB0)(ref this, object_id, create_new_object); // .text:00508FE0 ; CPhysicsObj *__thiscall CObjectMaint::GetNullObject(CObjectMaint *this, unsigned int object_id, int create_new_object) .text:00508FE0 ?GetNullObject@CObjectMaint@@IAEPAVCPhysicsObj@@KH@Z

        // CObjectMaint.GetNullWeenieObject:
        public CWeenieObject* GetNullWeenieObject(UInt32 object_id, int create_new_object) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, int, CWeenieObject*>)0x00509B60)(ref this, object_id, create_new_object); // .text:00509090 ; CWeenieObject *__thiscall CObjectMaint::GetNullWeenieObject(CObjectMaint *this, unsigned int object_id, int create_new_object) .text:00509090 ?GetNullWeenieObject@CObjectMaint@@IAEPAVCWeenieObject@@KH@Z

        // CObjectMaint.GetObjectA:
        public int GetObjectA(UInt32 object_id, CPhysicsObj** physobj, CWeenieObject** weenieobj) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, CPhysicsObj**, CWeenieObject**, int>)0x00508A40)(ref this, object_id, physobj, weenieobj); // .text:00507F70 ; int __thiscall CObjectMaint::GetObjectA(CObjectMaint *this, unsigned int object_id, CPhysicsObj **physobj, CWeenieObject **weenieobj) .text:00507F70 ?GetObjectA@CObjectMaint@@QAEHKAAPAVCPhysicsObj@@AAPAVCWeenieObject@@@Z

        // CObjectMaint.GetObjectA:
        public CPhysicsObj* GetObjectA(UInt32 object_id) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, CPhysicsObj*>)0x00508890)(ref this, object_id); // .text:00507D60 ; CPhysicsObj *__thiscall CObjectMaint::GetObjectA(CObjectMaint *this, unsigned int object_id) .text:00507D60 ?GetObjectA@CObjectMaint@@QAEPAVCPhysicsObj@@K@Z

        // CObjectMaint.GetObjectInventory:
        public CObjectInventory* GetObjectInventory(UInt32 object_id) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, CObjectInventory*>)0x00508930)(ref this, object_id); // .text:00507E00 ; CObjectInventory *__thiscall CObjectMaint::GetObjectInventory(CObjectMaint *this, unsigned int object_id) .text:00507E00 ?GetObjectInventory@CObjectMaint@@QAEPAVCObjectInventory@@K@Z

        // CObjectMaint.GetWeenieObject:
        public ACCWeenieObject* GetWeenieObject(UInt32 object_id) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, ACCWeenieObject*>)0x005088E0)(ref this, object_id); // .text:00507DB0 ; CWeenieObject *__thiscall CObjectMaint::GetWeenieObject(CObjectMaint *this, unsigned int object_id) .text:00507DB0 ?GetWeenieObject@CObjectMaint@@QAEPAVCWeenieObject@@K@Z

        // CObjectMaint.GotoLostCell:
        public void GotoLostCell(CPhysicsObj* _object, UInt32 new_cell_id) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, CPhysicsObj*, UInt32, void>)0x00508CE0)(ref this, _object, new_cell_id); // .text:00508210 ; void __thiscall CObjectMaint::GotoLostCell(CObjectMaint *this, CPhysicsObj *object, unsigned int new_cell_id) .text:00508210 ?GotoLostCell@CObjectMaint@@QAEXPAVCPhysicsObj@@K@Z

        // CObjectMaint.InitObjCell:
        public void InitObjCell(CObjCell* cell) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, CObjCell*, void>)0x00508D30)(ref this, cell); // .text:00508260 ; void __thiscall CObjectMaint::InitObjCell(CObjectMaint *this, CObjCell *cell) .text:00508260 ?InitObjCell@CObjectMaint@@QAEXPAVCObjCell@@@Z

        // CObjectMaint.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, void>)0x005087C0)(ref this); // .text:00507C90 ; void __thiscall CObjectMaint::OnShutdown(CObjectMaint *this) .text:00507C90 ?OnShutdown@CObjectMaint@@MAEXXZ

        // CObjectMaint.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, TResult*, Turbine_GUID*, void**, TResult*>)0x00508360)(ref this, result, i_rcInterface, o_ppvInterface); // .text:005078B0 ; TResult *__thiscall CObjectMaint::QueryInterface(CObjectMaint *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:005078B0 ?QueryInterface@CObjectMaint@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // CObjectMaint.QueueBlobForObject:
        public void QueueBlobForObject(UInt32 object_id, NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, NetBlob*, void>)0x00509DA0)(ref this, object_id, blob); // .text:005092D0 ; void __thiscall CObjectMaint::QueueBlobForObject(CObjectMaint *this, unsigned int object_id, NetBlob *blob) .text:005092D0 ?QueueBlobForObject@CObjectMaint@@QAEXKPAVNetBlob@@@Z

        // CObjectMaint.QueueBlobForWeenieObject:
        public void QueueBlobForWeenieObject(UInt32 object_id, UInt32 stamp, NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, UInt32, NetBlob*, void>)0x00509DE0)(ref this, object_id, stamp, blob); // .text:00509310 ; void __thiscall CObjectMaint::QueueBlobForWeenieObject(CObjectMaint *this, unsigned int object_id, unsigned int stamp, NetBlob *blob) .text:00509310 ?QueueBlobForWeenieObject@CObjectMaint@@QAEXKIPAVNetBlob@@@Z

        // CObjectMaint.QueueBlobForWeenieObject:
        public void QueueBlobForWeenieObject(UInt32 object_id, NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, NetBlob*, void>)0x00509E10)(ref this, object_id, blob); // .text:00509340 ; void __thiscall CObjectMaint::QueueBlobForWeenieObject(CObjectMaint *this, unsigned int object_id, NetBlob *blob) .text:00509340 ?QueueBlobForWeenieObject@CObjectMaint@@QAEXKPAVNetBlob@@@Z

        // CObjectMaint.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32>)0x00509450)(ref this); // .text:00508980 ; unsigned int __thiscall CObjectMaint::Release(CObjectMaint *this) .text:00508980 ?Release@CObjectMaint@@UBEKXZ

        // CObjectMaint.ReleaseObjCell:
        public void ReleaseObjCell(CObjCell* cell) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, CObjCell*, void>)0x005086E0)(ref this, cell); // .text:00507BB0 ; void __thiscall CObjectMaint::ReleaseObjCell(CObjectMaint *this, CObjCell *cell) .text:00507BB0 ?ReleaseObjCell@CObjectMaint@@QAEXPAVCObjCell@@@Z

        // CObjectMaint.RemoveFromLostCell:
        public void RemoveFromLostCell(CPhysicsObj* _object) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, CPhysicsObj*, void>)0x00508A80)(ref this, _object); // .text:00507FB0 ; void __thiscall CObjectMaint::RemoveFromLostCell(CObjectMaint *this, CPhysicsObj *object) .text:00507FB0 ?RemoveFromLostCell@CObjectMaint@@QAEXPAVCPhysicsObj@@@Z

        // CObjectMaint.RemoveObjectToBeDestroyed:
        public void RemoveObjectToBeDestroyed(UInt32 object_id) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, UInt32, void>)0x00508F10)(ref this, object_id); // .text:00508440 ; void __thiscall CObjectMaint::RemoveObjectToBeDestroyed(CObjectMaint *this, unsigned int object_id) .text:00508440 ?RemoveObjectToBeDestroyed@CObjectMaint@@QAEXK@Z

        // CObjectMaint.SetChildren:
        public void SetChildren(CPhysicsObj* obj, PhysicsDesc* desc) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, CPhysicsObj*, PhysicsDesc*, void>)0x00509E40)(ref this, obj, desc); // .text:00509370 ; void __thiscall CObjectMaint::SetChildren(CObjectMaint *this, CPhysicsObj *obj, PhysicsDesc *desc) .text:00509370 ?SetChildren@CObjectMaint@@QAEXPAVCPhysicsObj@@PAVPhysicsDesc@@@Z

        // CObjectMaint.UnRegisterAllNoticeHandlers:
        public void UnRegisterAllNoticeHandlers(NoticeHandler* _handler) => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, NoticeHandler*, void>)0x00508980)(ref this, _handler); // .text:00507E50 ; void __thiscall CObjectMaint::UnRegisterAllNoticeHandlers(CObjectMaint *this, NoticeHandler *_handler) .text:00507E50 ?UnRegisterAllNoticeHandlers@CObjectMaint@@QAEXPAVNoticeHandler@@@Z

        // CObjectMaint.UpdateVisibleObjectList:
        public void UpdateVisibleObjectList() => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, void>)0x00508E60)(ref this); // .text:00508390 ; void __thiscall CObjectMaint::UpdateVisibleObjectList(CObjectMaint *this) .text:00508390 ?UpdateVisibleObjectList@CObjectMaint@@IAEXXZ

        // CObjectMaint.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref CObjectMaint, void>)0x00509480)(ref this); // .text:005089B0 ; void __thiscall CObjectMaint::UseTime(CObjectMaint *this) .text:005089B0 ?UseTime@CObjectMaint@@QAEXXZ

        // Globals:
        public static CObjectMaint** s_pcInstance = (CObjectMaint**)0x00842ADC; // .data:00841ACC ; CObjectMaint *CObjectMaint::s_pcInstance .data:00841ACC ?s_pcInstance@CObjectMaint@@1PAV1@A
    }
    public unsafe struct ACCObjectMaint {
        // Struct:
        public CObjectMaint a0;
        public ObjDesc* player_objdesc;
        public override string ToString() => $"a0(CObjectMaint):{a0}, player_objdesc:->(ObjDesc*)0x{(int)player_objdesc:X8}";

        // Functions:

        // ACCObjectMaint.CreateObject:
        public CPhysicsObj* CreateObject(UInt32 objectID, VisualDesc* vdesc, PhysicsDesc* physicsdesc, WeenieDesc* wdesc) => ((delegate* unmanaged[Thiscall]<ref ACCObjectMaint, UInt32, VisualDesc*, PhysicsDesc*, WeenieDesc*, CPhysicsObj*>)0x005594B0)(ref this, objectID, vdesc, physicsdesc, wdesc); // .text:00558870 ; CPhysicsObj *__thiscall ACCObjectMaint::CreateObject(ACCObjectMaint *this, unsigned int objectID, VisualDesc *vdesc, PhysicsDesc *physicsdesc, WeenieDesc *wdesc) .text:00558870 ?CreateObject@ACCObjectMaint@@UAEPAVCPhysicsObj@@KPAVVisualDesc@@PAVPhysicsDesc@@PAVWeenieDesc@@@Z

        // ACCObjectMaint.DeleteObject:
        public int DeleteObject(UInt32 object_id) => ((delegate* unmanaged[Thiscall]<ref ACCObjectMaint, UInt32, int>)0x00558330)(ref this, object_id); // .text:005576F0 ; int __thiscall ACCObjectMaint::DeleteObject(ACCObjectMaint *this, unsigned int object_id) .text:005576F0 ?DeleteObject@ACCObjectMaint@@UAEHK@Z

        // ACCObjectMaint.GetPlayerVisualDesc:
        public VisualDesc* GetPlayerVisualDesc() => ((delegate* unmanaged[Thiscall]<ref ACCObjectMaint, VisualDesc*>)0x00558320)(ref this); // .text:005576E0 ; VisualDesc *__thiscall ACCObjectMaint::GetPlayerVisualDesc(ACCObjectMaint *this) .text:005576E0 ?GetPlayerVisualDesc@ACCObjectMaint@@UBEPAVVisualDesc@@XZ

        // ACCObjectMaint.SetPlayerVisualDesc:
        public void SetPlayerVisualDesc(VisualDesc* new_player_vdesc) => ((delegate* unmanaged[Thiscall]<ref ACCObjectMaint, VisualDesc*, void>)0x005582C0)(ref this, new_player_vdesc); // .text:00557680 ; void __thiscall ACCObjectMaint::SetPlayerVisualDesc(ACCObjectMaint *this, VisualDesc *new_player_vdesc) .text:00557680 ?SetPlayerVisualDesc@ACCObjectMaint@@UAEXPAVVisualDesc@@@Z

        // ACCObjectMaint.SetVisualDesc:
        public void SetVisualDesc(CPhysicsObj* _object, VisualDesc* vdesc) => ((delegate* unmanaged[Thiscall]<ref ACCObjectMaint, CPhysicsObj*, VisualDesc*, void>)0x005582A0)(ref this, _object, vdesc); // .text:00557660 ; void __thiscall ACCObjectMaint::SetVisualDesc(ACCObjectMaint *this, CPhysicsObj *object, VisualDesc *vdesc) .text:00557660 ?SetVisualDesc@ACCObjectMaint@@UAEXPAVCPhysicsObj@@PAVVisualDesc@@@Z

        // ACCObjectMaint.SetWeenieDesc:
        public void SetWeenieDesc(CWeenieObject* wobj, WeenieDesc* wdesc, int _recreated) => ((delegate* unmanaged[Thiscall]<ref ACCObjectMaint, CWeenieObject*, WeenieDesc*, int, void>)0x00558660)(ref this, wobj, wdesc, _recreated); // .text:00557A20 ; void __thiscall ACCObjectMaint::SetWeenieDesc(ACCObjectMaint *this, CWeenieObject *wobj, WeenieDesc *wdesc, int _recreated) .text:00557A20 ?SetWeenieDesc@ACCObjectMaint@@UAEXPAVCWeenieObject@@PAVWeenieDesc@@H@Z

        // ACCObjectMaint.StopViewingObjectContents:
        public void StopViewingObjectContents(UInt32 object_id) => ((delegate* unmanaged[Thiscall]<ref ACCObjectMaint, UInt32, void>)0x00559770)(ref this, object_id); // .text:00558B30 ; void __thiscall ACCObjectMaint::StopViewingObjectContents(ACCObjectMaint *this, unsigned int object_id) .text:00558B30 ?StopViewingObjectContents@ACCObjectMaint@@QAEXK@Z

        // ACCObjectMaint.UpdateObjectInventory:
        public void UpdateObjectInventory(UInt32 object_id, PackableList<InventoryPlacement>* new_inv) => ((delegate* unmanaged[Thiscall]<ref ACCObjectMaint, UInt32, PackableList<InventoryPlacement>*, void>)0x0055A190)(ref this, object_id, new_inv); // .text:00559550 ; void __thiscall ACCObjectMaint::UpdateObjectInventory(ACCObjectMaint *this, unsigned int object_id, PackableList<InventoryPlacement> *new_inv) .text:00559550 ?UpdateObjectInventory@ACCObjectMaint@@QAEXKABV?$PackableList@VInventoryPlacement@@@@@Z

        // ACCObjectMaint.ViewObjectContents:
        public void ViewObjectContents(UInt32 object_id, PackableList<ContentProfile>* new_contents) => ((delegate* unmanaged[Thiscall]<ref ACCObjectMaint, UInt32, PackableList<ContentProfile>*, void>)0x005596B0)(ref this, object_id, new_contents); // .text:00558A70 ; void __thiscall ACCObjectMaint::ViewObjectContents(ACCObjectMaint *this, unsigned int object_id, PackableList<ContentProfile> *new_contents) .text:00558A70 ?ViewObjectContents@ACCObjectMaint@@QAEXKABV?$PackableList@VContentProfile@@@@@Z
    }

    public unsafe struct ClientObjMaintSystem {
        // Struct:
        public ClientSystem a0;
        public ACCObjectMaint a1;
        public override string ToString() => $"a0(ClientSystem):{a0}, a1(ACCObjectMaint):{a1}";

        // Functions:

        // ClientObjMaintSystem.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, void>)0x005597B0)(ref this); // .text:00558B70 ; void __thiscall ClientObjMaintSystem::ClientObjMaintSystem(ClientObjMaintSystem *this) .text:00558B70 ??0ClientObjMaintSystem@@IAE@XZ

        // ClientObjMaintSystem.AddRef:
        public UInt32 AddRef() => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, UInt32>)0x0056B950)(ref this); // .text:0056AC10 ; unsigned int __thiscall ClientObjMaintSystem::AddRef(ClientCombatSystem *this) .text:0056AC10 ?AddRef@ClientObjMaintSystem@@UBEKXZ

        // ClientObjMaintSystem.AddRef:
        // public UInt32 AddRef() => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, UInt32>)0xDEADBEEF)(ref this); // .text:00557A00 ; unsigned int __thiscall ClientObjMaintSystem::AddRef(ClientObjMaintSystem *this) .text:00557A00 ?AddRef@ClientObjMaintSystem@@W7BEKXZ

        // ClientObjMaintSystem.Allocate:
        public static ClientObjMaintSystem* Allocate() => ((delegate* unmanaged[Cdecl]<ClientObjMaintSystem*>)0x00559EA0)(); // .text:00559260 ; ClientObjMaintSystem *__cdecl ClientObjMaintSystem::Allocate() .text:00559260 ?Allocate@ClientObjMaintSystem@@SAPAV1@XZ

        // ClientObjMaintSystem.GetPhysicsObject:
        public static CPhysicsObj* GetPhysicsObject(UInt32 i_iid) => ((delegate* unmanaged[Cdecl]<UInt32, CPhysicsObj*>)0x00558410)(i_iid); // .text:005577D0 ; CPhysicsObj *__cdecl ClientObjMaintSystem::GetPhysicsObject(unsigned int i_iid) .text:005577D0 ?GetPhysicsObject@ClientObjMaintSystem@@SAPAVCPhysicsObj@@K@Z

        // ClientObjMaintSystem.GetWeenieObject:
        public static ACCWeenieObject* GetWeenieObject(UInt32 i_iid) => ((delegate* unmanaged[Cdecl]<UInt32, ACCWeenieObject*>)0x005583F0)(i_iid); // .text:005577B0 ; ACCWeenieObject *__cdecl ClientObjMaintSystem::GetWeenieObject(unsigned int i_iid) .text:005577B0 ?GetWeenieObject@ClientObjMaintSystem@@SAPAVACCWeenieObject@@K@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateRemoveBoolEvent:
        public UInt32 Handle_Qualities__PrivateRemoveBoolEvent(char wts, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32>)0x00559F40)(ref this, wts, stype); // .text:00559300 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateRemoveBoolEvent(ClientObjMaintSystem *this, char wts, unsigned int stype) .text:00559300 ?Handle_Qualities__PrivateRemoveBoolEvent@ClientObjMaintSystem@@QAEKEK@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateRemoveDataIDEvent:
        public UInt32 Handle_Qualities__PrivateRemoveDataIDEvent(char wts, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32>)0x0055A000)(ref this, wts, stype); // .text:005593C0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateRemoveDataIDEvent(ClientObjMaintSystem *this, char wts, unsigned int stype) .text:005593C0 ?Handle_Qualities__PrivateRemoveDataIDEvent@ClientObjMaintSystem@@QAEKEK@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateRemoveFloatEvent:
        public UInt32 Handle_Qualities__PrivateRemoveFloatEvent(char wts, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32>)0x00559F80)(ref this, wts, stype); // .text:00559340 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateRemoveFloatEvent(ClientObjMaintSystem *this, char wts, unsigned int stype) .text:00559340 ?Handle_Qualities__PrivateRemoveFloatEvent@ClientObjMaintSystem@@QAEKEK@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateRemoveInstanceIDEvent:
        public UInt32 Handle_Qualities__PrivateRemoveInstanceIDEvent(char wts, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32>)0x0055A040)(ref this, wts, stype); // .text:00559400 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateRemoveInstanceIDEvent(ClientObjMaintSystem *this, char wts, unsigned int stype) .text:00559400 ?Handle_Qualities__PrivateRemoveInstanceIDEvent@ClientObjMaintSystem@@QAEKEK@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateRemoveInt64Event:
        public UInt32 Handle_Qualities__PrivateRemoveInt64Event(char wts, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32>)0x00559F00)(ref this, wts, stype); // .text:005592C0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateRemoveInt64Event(ClientObjMaintSystem *this, char wts, unsigned int stype) .text:005592C0 ?Handle_Qualities__PrivateRemoveInt64Event@ClientObjMaintSystem@@QAEKEK@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateRemoveIntEvent:
        public UInt32 Handle_Qualities__PrivateRemoveIntEvent(char wts, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32>)0x00559EC0)(ref this, wts, stype); // .text:00559280 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateRemoveIntEvent(ClientObjMaintSystem *this, char wts, unsigned int stype) .text:00559280 ?Handle_Qualities__PrivateRemoveIntEvent@ClientObjMaintSystem@@QAEKEK@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateRemovePositionEvent:
        public UInt32 Handle_Qualities__PrivateRemovePositionEvent(char wts, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32>)0x0055A080)(ref this, wts, stype); // .text:00559440 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateRemovePositionEvent(ClientObjMaintSystem *this, char wts, unsigned int stype) .text:00559440 ?Handle_Qualities__PrivateRemovePositionEvent@ClientObjMaintSystem@@QAEKEK@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateRemoveStringEvent:
        public UInt32 Handle_Qualities__PrivateRemoveStringEvent(char wts, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32>)0x00559FC0)(ref this, wts, stype); // .text:00559380 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateRemoveStringEvent(ClientObjMaintSystem *this, char wts, unsigned int stype) .text:00559380 ?Handle_Qualities__PrivateRemoveStringEvent@ClientObjMaintSystem@@QAEKEK@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateAttribute2nd:
        public UInt32 Handle_Qualities__PrivateUpdateAttribute2nd(char wts, UInt32 stype, SecondaryAttribute* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, SecondaryAttribute*, UInt32>)0x00559B20)(ref this, wts, stype, val); // .text:00558EE0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateAttribute2nd(ClientObjMaintSystem *this, char wts, unsigned int stype, SecondaryAttribute *val) .text:00558EE0 ?Handle_Qualities__PrivateUpdateAttribute2nd@ClientObjMaintSystem@@QAEKEKAAVSecondaryAttribute@@@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateAttribute2ndLevel:
        public UInt32 Handle_Qualities__PrivateUpdateAttribute2ndLevel(char wts, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, int, UInt32>)0x00559B50)(ref this, wts, stype, val); // .text:00558F10 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateAttribute2ndLevel(ClientObjMaintSystem *this, char wts, unsigned int stype, int val) .text:00558F10 ?Handle_Qualities__PrivateUpdateAttribute2ndLevel@ClientObjMaintSystem@@QAEKEKJ@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateAttribute:
        public UInt32 Handle_Qualities__PrivateUpdateAttribute(char wts, UInt32 stype, Attribute* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, Attribute*, UInt32>)0x00559AC0)(ref this, wts, stype, val); // .text:00558E80 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateAttribute(ClientObjMaintSystem *this, char wts, unsigned int stype, Attribute *val) .text:00558E80 ?Handle_Qualities__PrivateUpdateAttribute@ClientObjMaintSystem@@QAEKEKAAVAttribute@@@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateAttributeLevel:
        public UInt32 Handle_Qualities__PrivateUpdateAttributeLevel(char wts, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, int, UInt32>)0x00559AF0)(ref this, wts, stype, val); // .text:00558EB0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateAttributeLevel(ClientObjMaintSystem *this, char wts, unsigned int stype, int val) .text:00558EB0 ?Handle_Qualities__PrivateUpdateAttributeLevel@ClientObjMaintSystem@@QAEKEKJ@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateBool:
        public UInt32 Handle_Qualities__PrivateUpdateBool(char wts, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, int, UInt32>)0x00559C70)(ref this, wts, stype, val); // .text:00559030 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateBool(ClientObjMaintSystem *this, char wts, unsigned int stype, int val) .text:00559030 ?Handle_Qualities__PrivateUpdateBool@ClientObjMaintSystem@@QAEKEKH@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateDataID:
        public UInt32 Handle_Qualities__PrivateUpdateDataID(char wts, UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559D00)(ref this, wts, stype, val); // .text:005590C0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateDataID(ClientObjMaintSystem *this, char wts, unsigned int stype, IDClass<_tagDataID,32,0> val) .text:005590C0 ?Handle_Qualities__PrivateUpdateDataID@ClientObjMaintSystem@@QAEKEKV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateFloat:
        public UInt32 Handle_Qualities__PrivateUpdateFloat(char wts, UInt32 stype, Double val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, Double, UInt32>)0x00559CA0)(ref this, wts, stype, val); // .text:00559060 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateFloat(ClientObjMaintSystem *this, char wts, unsigned int stype, long double val) .text:00559060 ?Handle_Qualities__PrivateUpdateFloat@ClientObjMaintSystem@@QAEKEKN@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateInstanceID:
        public UInt32 Handle_Qualities__PrivateUpdateInstanceID(char wts, UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559D30)(ref this, wts, stype, val); // .text:005590F0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateInstanceID(ClientObjMaintSystem *this, char wts, unsigned int stype, unsigned int val) .text:005590F0 ?Handle_Qualities__PrivateUpdateInstanceID@ClientObjMaintSystem@@QAEKEKK@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateInt64:
        public UInt32 Handle_Qualities__PrivateUpdateInt64(char wts, UInt32 stype, Int64 val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, Int64, UInt32>)0x00559C40)(ref this, wts, stype, val); // .text:00559000 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateInt64(ClientObjMaintSystem *this, char wts, unsigned int stype, __int64 val) .text:00559000 ?Handle_Qualities__PrivateUpdateInt64@ClientObjMaintSystem@@QAEKEK_J@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateInt:
        public UInt32 Handle_Qualities__PrivateUpdateInt(char wts, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, int, UInt32>)0x00559C10)(ref this, wts, stype, val); // .text:00558FD0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateInt(ClientObjMaintSystem *this, char wts, unsigned int stype, int val) .text:00558FD0 ?Handle_Qualities__PrivateUpdateInt@ClientObjMaintSystem@@QAEKEKJ@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdatePosition:
        public UInt32 Handle_Qualities__PrivateUpdatePosition(char wts, UInt32 stype, Position* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, Position*, UInt32>)0x00559D60)(ref this, wts, stype, val); // .text:00559120 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdatePosition(ClientObjMaintSystem *this, char wts, unsigned int stype, Position *val) .text:00559120 ?Handle_Qualities__PrivateUpdatePosition@ClientObjMaintSystem@@QAEKEKABVPosition@@@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateSkill:
        public UInt32 Handle_Qualities__PrivateUpdateSkill(char wts, UInt32 stype, Skill* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, Skill*, UInt32>)0x00559B80)(ref this, wts, stype, val); // .text:00558F40 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateSkill(ClientObjMaintSystem *this, char wts, unsigned int stype, Skill *val) .text:00558F40 ?Handle_Qualities__PrivateUpdateSkill@ClientObjMaintSystem@@QAEKEKAAVSkill@@@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateSkillAC:
        public UInt32 Handle_Qualities__PrivateUpdateSkillAC(char wts, UInt32 stype, SKILL_ADVANCEMENT_CLASS val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, SKILL_ADVANCEMENT_CLASS, UInt32>)0x00559BE0)(ref this, wts, stype, val); // .text:00558FA0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateSkillAC(ClientObjMaintSystem *this, char wts, unsigned int stype, SKILL_ADVANCEMENT_CLASS val) .text:00558FA0 ?Handle_Qualities__PrivateUpdateSkillAC@ClientObjMaintSystem@@QAEKEKW4SKILL_ADVANCEMENT_CLASS@@@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateSkillLevel:
        public UInt32 Handle_Qualities__PrivateUpdateSkillLevel(char wts, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, int, UInt32>)0x00559BB0)(ref this, wts, stype, val); // .text:00558F70 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateSkillLevel(ClientObjMaintSystem *this, char wts, unsigned int stype, int val) .text:00558F70 ?Handle_Qualities__PrivateUpdateSkillLevel@ClientObjMaintSystem@@QAEKEKJ@Z

        // ClientObjMaintSystem.Handle_Qualities__PrivateUpdateString:
        public UInt32 Handle_Qualities__PrivateUpdateString(char wts, UInt32 stype, AC1Legacy.PStringBase<char>* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, AC1Legacy.PStringBase<char>*, UInt32>)0x00559CD0)(ref this, wts, stype, val); // .text:00559090 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__PrivateUpdateString(ClientObjMaintSystem *this, char wts, unsigned int stype, AC1Legacy::PStringBase<char> *val) .text:00559090 ?Handle_Qualities__PrivateUpdateString@ClientObjMaintSystem@@QAEKEKAAV?$PStringBase@D@AC1Legacy@@@Z

        // ClientObjMaintSystem.Handle_Qualities__RemoveBoolEvent:
        public UInt32 Handle_Qualities__RemoveBoolEvent(char wts, UInt32 sender, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559DD0)(ref this, wts, sender, stype); // .text:00559190 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__RemoveBoolEvent(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype) .text:00559190 ?Handle_Qualities__RemoveBoolEvent@ClientObjMaintSystem@@QAEKEKK@Z

        // ClientObjMaintSystem.Handle_Qualities__RemoveDataIDEvent:
        public UInt32 Handle_Qualities__RemoveDataIDEvent(char wts, UInt32 sender, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559E30)(ref this, wts, sender, stype); // .text:005591F0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__RemoveDataIDEvent(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype) .text:005591F0 ?Handle_Qualities__RemoveDataIDEvent@ClientObjMaintSystem@@QAEKEKK@Z

        // ClientObjMaintSystem.Handle_Qualities__RemoveFloatEvent:
        public UInt32 Handle_Qualities__RemoveFloatEvent(char wts, UInt32 sender, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559DF0)(ref this, wts, sender, stype); // .text:005591B0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__RemoveFloatEvent(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype) .text:005591B0 ?Handle_Qualities__RemoveFloatEvent@ClientObjMaintSystem@@QAEKEKK@Z

        // ClientObjMaintSystem.Handle_Qualities__RemoveInstanceIDEvent:
        public UInt32 Handle_Qualities__RemoveInstanceIDEvent(char wts, UInt32 sender, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559E50)(ref this, wts, sender, stype); // .text:00559210 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__RemoveInstanceIDEvent(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype) .text:00559210 ?Handle_Qualities__RemoveInstanceIDEvent@ClientObjMaintSystem@@QAEKEKK@Z

        // ClientObjMaintSystem.Handle_Qualities__RemoveInt64Event:
        public UInt32 Handle_Qualities__RemoveInt64Event(char wts, UInt32 sender, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559DB0)(ref this, wts, sender, stype); // .text:00559170 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__RemoveInt64Event(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype) .text:00559170 ?Handle_Qualities__RemoveInt64Event@ClientObjMaintSystem@@QAEKEKK@Z

        // ClientObjMaintSystem.Handle_Qualities__RemoveIntEvent:
        public UInt32 Handle_Qualities__RemoveIntEvent(char wts, UInt32 sender, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559D90)(ref this, wts, sender, stype); // .text:00559150 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__RemoveIntEvent(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype) .text:00559150 ?Handle_Qualities__RemoveIntEvent@ClientObjMaintSystem@@QAEKEKK@Z

        // ClientObjMaintSystem.Handle_Qualities__RemovePositionEvent:
        public UInt32 Handle_Qualities__RemovePositionEvent(char wts, UInt32 sender, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559E70)(ref this, wts, sender, stype); // .text:00559230 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__RemovePositionEvent(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype) .text:00559230 ?Handle_Qualities__RemovePositionEvent@ClientObjMaintSystem@@QAEKEKK@Z

        // ClientObjMaintSystem.Handle_Qualities__RemoveStringEvent:
        public UInt32 Handle_Qualities__RemoveStringEvent(char wts, UInt32 sender, UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32>)0x00559E10)(ref this, wts, sender, stype); // .text:005591D0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__RemoveStringEvent(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype) .text:005591D0 ?Handle_Qualities__RemoveStringEvent@ClientObjMaintSystem@@QAEKEKK@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateAttribute2nd:
        public UInt32 Handle_Qualities__UpdateAttribute2nd(char wts, UInt32 sender, UInt32 stype, SecondaryAttribute* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, SecondaryAttribute*, UInt32>)0x00559900)(ref this, wts, sender, stype, val); // .text:00558CC0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateAttribute2nd(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, SecondaryAttribute *val) .text:00558CC0 ?Handle_Qualities__UpdateAttribute2nd@ClientObjMaintSystem@@QAEKEKKAAVSecondaryAttribute@@@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateAttribute2ndLevel:
        public UInt32 Handle_Qualities__UpdateAttribute2ndLevel(char wts, UInt32 sender, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, int, UInt32>)0x00559920)(ref this, wts, sender, stype, val); // .text:00558CE0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateAttribute2ndLevel(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, int val) .text:00558CE0 ?Handle_Qualities__UpdateAttribute2ndLevel@ClientObjMaintSystem@@QAEKEKKJ@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateAttribute:
        public UInt32 Handle_Qualities__UpdateAttribute(char wts, UInt32 sender, UInt32 stype, Attribute* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, Attribute*, UInt32>)0x005598C0)(ref this, wts, sender, stype, val); // .text:00558C80 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateAttribute(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, Attribute *val) .text:00558C80 ?Handle_Qualities__UpdateAttribute@ClientObjMaintSystem@@QAEKEKKAAVAttribute@@@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateAttributeLevel:
        public UInt32 Handle_Qualities__UpdateAttributeLevel(char wts, UInt32 sender, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, int, UInt32>)0x005598E0)(ref this, wts, sender, stype, val); // .text:00558CA0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateAttributeLevel(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, int val) .text:00558CA0 ?Handle_Qualities__UpdateAttributeLevel@ClientObjMaintSystem@@QAEKEKKJ@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateBool:
        public UInt32 Handle_Qualities__UpdateBool(char wts, UInt32 sender, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, int, UInt32>)0x005599F0)(ref this, wts, sender, stype, val); // .text:00558DB0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateBool(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, int val) .text:00558DB0 ?Handle_Qualities__UpdateBool@ClientObjMaintSystem@@QAEKEKKH@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateDataID:
        public UInt32 Handle_Qualities__UpdateDataID(char wts, UInt32 sender, UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32, UInt32>)0x00559A60)(ref this, wts, sender, stype, val); // .text:00558E20 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateDataID(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, IDClass<_tagDataID,32,0> val) .text:00558E20 ?Handle_Qualities__UpdateDataID@ClientObjMaintSystem@@QAEKEKKV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateFloat:
        public UInt32 Handle_Qualities__UpdateFloat(char wts, UInt32 sender, UInt32 stype, Double val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, Double, UInt32>)0x00559A10)(ref this, wts, sender, stype, val); // .text:00558DD0 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateFloat(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, long double val) .text:00558DD0 ?Handle_Qualities__UpdateFloat@ClientObjMaintSystem@@QAEKEKKN@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateInstanceID:
        public UInt32 Handle_Qualities__UpdateInstanceID(char wts, UInt32 sender, UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32, UInt32>)0x00559A80)(ref this, wts, sender, stype, val); // .text:00558E40 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateInstanceID(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, unsigned int val) .text:00558E40 ?Handle_Qualities__UpdateInstanceID@ClientObjMaintSystem@@QAEKEKKK@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateInt64:
        public UInt32 Handle_Qualities__UpdateInt64(char wts, UInt32 sender, UInt32 stype, Int64 val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, Int64, UInt32>)0x005599C0)(ref this, wts, sender, stype, val); // .text:00558D80 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateInt64(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, __int64 val) .text:00558D80 ?Handle_Qualities__UpdateInt64@ClientObjMaintSystem@@QAEKEKK_J@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateInt:
        public UInt32 Handle_Qualities__UpdateInt(char wts, UInt32 sender, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, int, UInt32>)0x005599A0)(ref this, wts, sender, stype, val); // .text:00558D60 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateInt(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, int val) .text:00558D60 ?Handle_Qualities__UpdateInt@ClientObjMaintSystem@@QAEKEKKJ@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdatePosition:
        public UInt32 Handle_Qualities__UpdatePosition(char wts, UInt32 sender, UInt32 stype, Position* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, Position*, UInt32>)0x00559AA0)(ref this, wts, sender, stype, val); // .text:00558E60 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdatePosition(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, Position *val) .text:00558E60 ?Handle_Qualities__UpdatePosition@ClientObjMaintSystem@@QAEKEKKABVPosition@@@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateSkill:
        public UInt32 Handle_Qualities__UpdateSkill(char wts, UInt32 sender, UInt32 stype, Skill* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, Skill*, UInt32>)0x00559940)(ref this, wts, sender, stype, val); // .text:00558D00 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateSkill(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, Skill *val) .text:00558D00 ?Handle_Qualities__UpdateSkill@ClientObjMaintSystem@@QAEKEKKAAVSkill@@@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateSkillAC:
        public UInt32 Handle_Qualities__UpdateSkillAC(char wts, UInt32 sender, UInt32 stype, SKILL_ADVANCEMENT_CLASS val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, SKILL_ADVANCEMENT_CLASS, UInt32>)0x00559980)(ref this, wts, sender, stype, val); // .text:00558D40 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateSkillAC(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, SKILL_ADVANCEMENT_CLASS val) .text:00558D40 ?Handle_Qualities__UpdateSkillAC@ClientObjMaintSystem@@QAEKEKKW4SKILL_ADVANCEMENT_CLASS@@@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateSkillLevel:
        public UInt32 Handle_Qualities__UpdateSkillLevel(char wts, UInt32 sender, UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, int, UInt32>)0x00559960)(ref this, wts, sender, stype, val); // .text:00558D20 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateSkillLevel(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, int val) .text:00558D20 ?Handle_Qualities__UpdateSkillLevel@ClientObjMaintSystem@@QAEKEKKJ@Z

        // ClientObjMaintSystem.Handle_Qualities__UpdateString:
        public UInt32 Handle_Qualities__UpdateString(char wts, UInt32 sender, UInt32 stype, AC1Legacy.PStringBase<char>* val) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, AC1Legacy.PStringBase<char>*, UInt32>)0x00559A40)(ref this, wts, sender, stype, val); // .text:00558E00 ; unsigned int __thiscall ClientObjMaintSystem::Handle_Qualities__UpdateString(ClientObjMaintSystem *this, char wts, unsigned int sender, unsigned int stype, AC1Legacy::PStringBase<char> *val) .text:00558E00 ?Handle_Qualities__UpdateString@ClientObjMaintSystem@@QAEKEKKAAV?$PStringBase@D@AC1Legacy@@@Z

        // ClientObjMaintSystem.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, void>)0x00559860)(ref this); // .text:00558C20 ; void __thiscall ClientObjMaintSystem::OnShutdown(ClientObjMaintSystem *this) .text:00558C20 ?OnShutdown@ClientObjMaintSystem@@MAEXXZ

        // ClientObjMaintSystem.OnShutdown:
        // public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, void>)0xDEADBEEF)(ref this); // .text:00559250 ; void __thiscall ClientObjMaintSystem::OnShutdown(ClientObjMaintSystem *this) .text:00559250 ?OnShutdown@ClientObjMaintSystem@@O7AEXXZ

        // ClientObjMaintSystem.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, TResult*, Turbine_GUID*, void**, TResult*>)0x00558540)(ref this, result, i_rcInterface, o_ppvInterface); // .text:00557900 ; TResult *__thiscall ClientObjMaintSystem::QueryInterface(ClientObjMaintSystem *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:00557900 ?QueryInterface@ClientObjMaintSystem@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // ClientObjMaintSystem.QueryInterface:
        // public TResult* QueryInterface(TResult* result, Turbine_GUID* a2, void** a3) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, TResult*, Turbine_GUID*, void**, TResult*>)0xDEADBEEF)(ref this, result, a2, a3); // .text:005579F0 ; TResult *__thiscall ClientObjMaintSystem::QueryInterface(ClientObjMaintSystem *this, TResult *result, Turbine_GUID *, void **) .text:005579F0 ?QueryInterface@ClientObjMaintSystem@@W7AE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // ClientObjMaintSystem.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, UInt32>)0x00558490)(ref this); // .text:00557850 ; unsigned int __thiscall ClientObjMaintSystem::Release(ClientObjMaintSystem *this) .text:00557850 ?Release@ClientObjMaintSystem@@UBEKXZ

        // ClientObjMaintSystem.Release:
        // public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, UInt32>)0xDEADBEEF)(ref this); // .text:00557A10 ; unsigned int __thiscall ClientObjMaintSystem::Release(ClientObjMaintSystem *this) .text:00557A10 ?Release@ClientObjMaintSystem@@W7BEKXZ

        // ClientObjMaintSystem.UpdateStackSize:
        public Byte UpdateStackSize(char ts, UInt32 item, UInt32 amount, UInt32 newValue) => ((delegate* unmanaged[Thiscall]<ref ClientObjMaintSystem, char, UInt32, UInt32, UInt32, Byte>)0x005587E0)(ref this, ts, item, amount, newValue); // .text:00557BA0 ; bool __thiscall ClientObjMaintSystem::UpdateStackSize(ClientObjMaintSystem *this, char ts, unsigned int item, unsigned int amount, unsigned int newValue) .text:00557BA0 ?UpdateStackSize@ClientObjMaintSystem@@QAE_NEKKK@Z
    }
}
