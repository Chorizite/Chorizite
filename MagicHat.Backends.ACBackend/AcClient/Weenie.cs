//$!go run parse.go full CWeenieObject::NetBlob:TSRecv:TSBlockedEntry:ACCWeenieObject:IconData:PlayerDesc:CACQualities:CSequence:CBaseQualities:CBaseQualitiesVtbl:EnchantedQualityDetails:Attribute:SecondaryAttribute:AttributeCache:Skill:BodyPart:ArmorCache:BodyPartSelectionData:ArmorProfile:Body:StatMod:EventFilter:CreationProfile:Emote:EmoteSet:CEmoteTable:PageData:PageDataList:GeneratorProfile:GeneratorTable:GeneratorRegistryNode:GeneratorRegistry:GeneratorQueueNode:GeneratorQueue::ACWTimeStamper:WTimeStamper:PublicWeenieDesc:WeenieDesc >Weenie.cs
using System;
using System.Runtime.InteropServices;

namespace AcClient {
    public unsafe struct CWeenieObject {
        // Struct:
        public LongHashData a0;
        public NoticeRegistrar a1;
        public Double update_time;
        public NIList<NetBlob>* netblob_list;
        public TSRecv blobOrdering;
        public override string ToString() => $"a0(LongHashData):{a0}, a1(NoticeRegistrar):{a1}, update_time:{update_time:n5}, netblob_list:->(NIList<NetBlob*>*)0x{(int)netblob_list:X8}, blobOrdering(TSRecv):{blobOrdering}";

        // Functions:

        // CWeenieObject.queue_netblob:
        public void queue_netblob(NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref CWeenieObject, NetBlob*, void>)0x00509F50)(ref this, blob); // .text:00509480 ; void __thiscall CWeenieObject::queue_netblob(CWeenieObject *this, NetBlob *blob) .text:00509480 ?queue_netblob@CWeenieObject@@QAEXPAVNetBlob@@@Z

        // CWeenieObject.process_netblobs:
        public void process_netblobs() => ((delegate* unmanaged[Thiscall]<ref CWeenieObject, void>)0x00509FD0)(ref this); // .text:00509500 ; void __thiscall CWeenieObject::process_netblobs(CWeenieObject *this) .text:00509500 ?process_netblobs@CWeenieObject@@UAEXXZ

        // CWeenieObject.ObjectBeingDeleted:
        public void ObjectBeingDeleted() => ((delegate* unmanaged[Thiscall]<ref CWeenieObject, void>)0x0050A0B0)(ref this); // .text:005095E0 ; void __thiscall CWeenieObject::ObjectBeingDeleted(CWeenieObject *this) .text:005095E0 ?ObjectBeingDeleted@CWeenieObject@@UAEXXZ

        // CWeenieObject.`vector deleting destructor'`adjustor{12}' :
        // (ERR) .text:0058D560 ; [thunk]:public: virtual void * __thiscall CWeenieObject::`vector deleting destructor'`adjustor{12}' (unsigned int) .text:0058D560 ??_ECWeenieObject@@WM@AEPAXI@Z

        // CWeenieObject.queue_netblob:
        public void queue_netblob(UInt32 inStamp, NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref CWeenieObject, UInt32, NetBlob*, void>)0x00509F00)(ref this, inStamp, blob); // .text:00509430 ; void __thiscall CWeenieObject::queue_netblob(CWeenieObject *this, unsigned int inStamp, NetBlob *blob) .text:00509430 ?queue_netblob@CWeenieObject@@QAEXIPAVNetBlob@@@Z

        // CWeenieObject.fIsNextBlob:
        public int fIsNextBlob(UInt32 inStamp, NetBlob* pBlob, NetBlob** ppBlobIndicated) => ((delegate* unmanaged[Thiscall]<ref CWeenieObject, UInt32, NetBlob*, NetBlob**, int>)0x00509F30)(ref this, inStamp, pBlob, ppBlobIndicated); // .text:00509460 ; int __thiscall CWeenieObject::fIsNextBlob(CWeenieObject *this, unsigned int inStamp, NetBlob *pBlob, NetBlob **ppBlobIndicated) .text:00509460 ?fIsNextBlob@CWeenieObject@@QAEHIPAVNetBlob@@PAPAV2@@Z

        // Globals:
        public static CObjectMaint** objMaint = (CObjectMaint**)0x00842B98; // .data:00841B88 ; CObjectMaint *CWeenieObject::objMaint .data:00841B88 ?objMaint@CWeenieObject@@1PAVCObjectMaint@@A
    }

    public unsafe struct NetBlob {
        // Struct:
        public Turbine_RefCount a0;
        public PackObj a1;
        public UI64HashData a2;
        public NetBlob.State state_;
        public char* buf_;
        public UInt32 bufSize_;
        public UInt32 cMaxFragments_;
        public UInt32 numFragments_;
        public UInt16 sender_;
        public UInt16 queueID_;
        public UInt32 priority_;
        public NetBlob* waitNext_;
        public UInt64 savedNetBlobID_;
        public override string ToString() => $"a0(Turbine_RefCount):{a0}, a1(PackObj):{a1}, a2(UI64HashData):{a2}, state_(NetBlob.State):{state_}, buf_:->(char*)0x{(int)buf_:X8}, bufSize_:{bufSize_:X8}, cMaxFragments_:{cMaxFragments_:X8}, numFragments_:{numFragments_:X8}, sender_:{sender_:X4}, queueID_:{queueID_:X4}, priority_:{priority_:X8}, waitNext_:->(NetBlob*)0x{(int)waitNext_:X8}, savedNetBlobID_(UInt64):{savedNetBlobID_}";
        // Enums:
        public enum State : UInt32 {
            NETBLOB_FROZEN = 0x0,
            NETBLOB_SENDING = 0x1,
            NETBLOB_RECEIVING = 0x2,
            NETBLOB_RECEIVED = 0x3,
            NETBLOB_FRAGMENTED = 0x4,
            FORCE_State_32_BIT = 0x7FFFFFFF,
        };

        // Functions:

        // NetBlob.GetPackSize:
        // public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref NetBlob, UInt32>)0xDEADBEEF)(ref this); // .text:00549C30 ; unsigned int __thiscall NetBlob::GetPackSize(NetBlob *this) .text:00549C30 ?GetPackSize@NetBlob@@UAEIXZ

        // NetBlob.Fragmentize:
        // public UInt32 Fragmentize(BlobFrag** ppCurFragment) => ((delegate* unmanaged[Thiscall]<ref NetBlob, BlobFrag**, UInt32>)0xDEADBEEF)(ref this, ppCurFragment); // .text:00549CF0 ; unsigned int __thiscall NetBlob::Fragmentize(NetBlob *this, BlobFrag **ppCurFragment) .text:00549CF0 ?Fragmentize@NetBlob@@QAEKPAPAVBlobFrag@@@Z

        // NetBlob.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref NetBlob, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:00549E70 ; int __thiscall NetBlob::UnPack(NetBlob *this, void **addr, unsigned int size) .text:00549E70 ?UnPack@NetBlob@@UAEHAAPAXI@Z

        // NetBlob.ReceiveAddFragment:
        // public void ReceiveAddFragment(BlobFrag* frag) => ((delegate* unmanaged[Thiscall]<ref NetBlob, BlobFrag*, void>)0xDEADBEEF)(ref this, frag); // .text:00549A20 ; void __thiscall NetBlob::ReceiveAddFragment(NetBlob *this, BlobFrag *frag) .text:00549A20 ?ReceiveAddFragment@NetBlob@@QAEXPAVBlobFrag@@@Z

        // NetBlob.Send:
        // public Byte Send(UInt16 recip, UInt32 priority) => ((delegate* unmanaged[Thiscall]<ref NetBlob, UInt16, UInt32, Byte>)0xDEADBEEF)(ref this, recip, priority); // .text:00549B40 ; bool __thiscall NetBlob::Send(NetBlob *this, unsigned __int16 recip, unsigned int priority) .text:00549B40 ?Send@NetBlob@@QAE_NGI@Z

        // NetBlob.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref NetBlob, void>)0xDEADBEEF)(ref this); // .text:00549C40 ; void __thiscall NetBlob::NetBlob(NetBlob *this) .text:00549C40 ??0NetBlob@@IAE@XZ

        // NetBlob.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref NetBlob, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:00549DA0 ; unsigned int __thiscall NetBlob::Pack(NetBlob *this, void **addr, unsigned int size) .text:00549DA0 ?Pack@NetBlob@@UAEIAAPAXI@Z

        // NetBlob.Fragmentize:
        // (ERR) .text:0054A850 ; public: unsigned long __thiscall NetBlob::Fragmentize(class BlobFrag * *) .text:0054A850 ?Fragmentize@NetBlob@@QAEKPAPAVBlobFrag@@@Z:

        // NetBlob.ReceiveBlobReady:
        public void ReceiveBlobReady() => ((delegate* unmanaged[Thiscall]<ref NetBlob, void>)0x0054A690)(ref this); // .text:00549B30 ; void __thiscall NetBlob::ReceiveBlobReady(NetBlob *this) .text:00549B30 ?ReceiveBlobReady@NetBlob@@QAEXXZ

        // NetBlob.__Ctor:
        public void __Ctor(char* buf, UInt32 bufSize, Int16 queue) => ((delegate* unmanaged[Thiscall]<ref NetBlob, char*, UInt32, Int16, void>)0x0054A6F0)(ref this, buf, bufSize, queue); // .text:00549B90 ; void __thiscall NetBlob::NetBlob(NetBlob *this, char *buf, unsigned int bufSize, __int16 queue) .text:00549B90 ??0NetBlob@@IAE@PAEIF@Z
    }
    public unsafe struct TSRecv {
        // Struct:
        public int receivedFirstEntry_;
        public TSRecvMode mode_;
        public UInt32 overflowLimit_;
        public UInt32 highestStamp_;
        public TSBlockedEntry head_;
        public int numBlockedStamps_;
        public Double blockedSince_;
        public override string ToString() => $"receivedFirstEntry_(int):{receivedFirstEntry_}, mode_(TSRecvMode):{mode_}, overflowLimit_:{overflowLimit_:X8}, highestStamp_:{highestStamp_:X8}, head_(TSBlockedEntry):{head_}, numBlockedStamps_(int):{numBlockedStamps_}, blockedSince_:{blockedSince_:n5}";

        // Functions:

        // TSRecv.AddEntryLatest:
        public int AddEntryLatest(UInt32 stampIn, Turbine_RefCount* pObjIn, UInt32* pstampOut, Turbine_RefCount** ppObjOut) => ((delegate* unmanaged[Thiscall]<ref TSRecv, UInt32, Turbine_RefCount*, UInt32*, Turbine_RefCount**, int>)0x005B1060)(ref this, stampIn, pObjIn, pstampOut, ppObjOut); // .text:005AFFB0 ; int __thiscall TSRecv::AddEntryLatest(TSRecv *this, unsigned int stampIn, ReferenceCountTemplate<1048576,0> *pObjIn, unsigned int *pstampOut, ReferenceCountTemplate<1048576,0> **ppObjOut) .text:005AFFB0 ?AddEntryLatest@TSRecv@@AAEHIPAV?$ReferenceCountTemplate@$0BAAAAA@$0A@@@PAIPAPAV2@@Z

        // TSRecv.AddEntry:
        public void AddEntry(UInt32 stampIn, Turbine_RefCount* pObjIn, int* fRejected) => ((delegate* unmanaged[Thiscall]<ref TSRecv, UInt32, Turbine_RefCount*, int*, void>)0x005B10E0)(ref this, stampIn, pObjIn, fRejected); // .text:005B0030 ; void __thiscall TSRecv::AddEntry(TSRecv *this, unsigned int stampIn, ReferenceCountTemplate<1048576,0> *pObjIn, int *fRejected) .text:005B0030 ?AddEntry@TSRecv@@QAEXIPAV?$ReferenceCountTemplate@$0BAAAAA@$0A@@@AAH@Z

        // TSRecv.AddEntryBlocking:
        public int AddEntryBlocking(UInt32 stampIn, Turbine_RefCount* pObjIn, UInt32* pstampOut, Turbine_RefCount** ppObjOut) => ((delegate* unmanaged[Thiscall]<ref TSRecv, UInt32, Turbine_RefCount*, UInt32*, Turbine_RefCount**, int>)0x005B11A0)(ref this, stampIn, pObjIn, pstampOut, ppObjOut); // .text:005B00F0 ; int __thiscall TSRecv::AddEntryBlocking(TSRecv *this, unsigned int stampIn, ReferenceCountTemplate<1048576,0> *pObjIn, unsigned int *pstampOut, ReferenceCountTemplate<1048576,0> **ppObjOut) .text:005B00F0 ?AddEntryBlocking@TSRecv@@AAEHIPAV?$ReferenceCountTemplate@$0BAAAAA@$0A@@@PAIPAPAV2@@Z

        // TSRecv.AddAndCheck:
        public int AddAndCheck(UInt32 stampIn, Turbine_RefCount* pObjIn, UInt32* pstampOut, Turbine_RefCount** ppObjOut) => ((delegate* unmanaged[Thiscall]<ref TSRecv, UInt32, Turbine_RefCount*, UInt32*, Turbine_RefCount**, int>)0x005B12D0)(ref this, stampIn, pObjIn, pstampOut, ppObjOut); // .text:005B0220 ; int __thiscall TSRecv::AddAndCheck(TSRecv *this, unsigned int stampIn, ReferenceCountTemplate<1048576,0> *pObjIn, unsigned int *pstampOut, ReferenceCountTemplate<1048576,0> **ppObjOut) .text:005B0220 ?AddAndCheck@TSRecv@@QAEHIPAV?$ReferenceCountTemplate@$0BAAAAA@$0A@@@PAIPAPAV2@@Z

        // TSRecv.~TSRecv:
        // (ERR) .text:005B0FF0 ; public: __thiscall TSRecv::~TSRecv(void) .text:005B0FF0 ??1TSRecv@@QAE@XZ

        // TSRecv.__Ctor:
        public void __Ctor(TSRecvMode mode, UInt32 TSOverflowLimit) => ((delegate* unmanaged[Thiscall]<ref TSRecv, TSRecvMode, UInt32, void>)0x005B0F00)(ref this, mode, TSOverflowLimit); // .text:005AFE50 ; void __thiscall TSRecv::TSRecv(TSRecv *this, TSRecvMode mode, unsigned int TSOverflowLimit) .text:005AFE50 ??0TSRecv@@QAE@W4TSRecvMode@@I@Z

        // TSRecv.GetNextReadyEntry:
        public int GetNextReadyEntry(UInt32* pstampOut, Turbine_RefCount** ppObjOut) => ((delegate* unmanaged[Thiscall]<ref TSRecv, UInt32*, Turbine_RefCount**, int>)0x005B0F30)(ref this, pstampOut, ppObjOut); // .text:005AFE80 ; int __thiscall TSRecv::GetNextReadyEntry(TSRecv *this, unsigned int *pstampOut, ReferenceCountTemplate<1048576,0> **ppObjOut) .text:005AFE80 ?GetNextReadyEntry@TSRecv@@QAEHPAIPAPAV?$ReferenceCountTemplate@$0BAAAAA@$0A@@@@Z
    }
    public unsafe struct TSBlockedEntry {
        // Struct:
        public TSBlockedEntry* m_pNext;
        public UInt32 m_stamp;
        public Turbine_RefCount* m_pObj;
        public override string ToString() => $"m_pNext:->(TSBlockedEntry*)0x{(int)m_pNext:X8}, m_stamp:{m_stamp:X8}, m_pObj:->(Turbine_RefCount*)0x{(int)m_pObj:X8}";
    }
    public unsafe struct ACCWeenieObject {
        // Struct:
        public CWeenieObject a0;
        public CObjectInventory* objInventory;
        public int valid;
        public int awaitingAuthentication;
        public int markedForDeletion;
        public int movedWhileMarkedForDeletion;
        public int beingRemoved;
        public PositionState current_state;
        public int selected;
        public int waiting;
        public int sellState;
        public int tradeState;
        public int shortcutNum;
        public Byte m_bShortcutGhosted;
        public UInt32 preRemoveContainerID;
        public UInt32 preRemoveWielderID;
        public UInt32 preRemoveLocation;
        public UInt32 preRemoveContainerPlace;
        public CPhysicsObj* _phys_obj;
        public PublicWeenieDesc pwd;
        public ACWTimeStamper* _stamper;
        public PlayerDesc* m_pQualities;
        public override string ToString() => $"a0(CWeenieObject):{a0}, objInventory:->(CObjectInventory*)0x{(int)objInventory:X8}, valid(int):{valid}, awaitingAuthentication(int):{awaitingAuthentication}, markedForDeletion(int):{markedForDeletion}, movedWhileMarkedForDeletion(int):{movedWhileMarkedForDeletion}, beingRemoved(int):{beingRemoved}, current_state(PositionState):{current_state}, selected(int):{selected}, waiting(int):{waiting}, sellState(int):{sellState}, tradeState(int):{tradeState}, shortcutNum(int):{shortcutNum}, m_bShortcutGhosted:{m_bShortcutGhosted:X2}, preRemoveContainerID:{preRemoveContainerID:X8}, preRemoveWielderID:{preRemoveWielderID:X8}, preRemoveLocation:{preRemoveLocation:X8}, preRemoveContainerPlace:{preRemoveContainerPlace:X8}, _phys_obj:->(CPhysicsObj*)0x{(int)_phys_obj:X8}, pwd(PublicWeenieDesc):{pwd}, _stamper:->(ACWTimeStamper*)0x{(int)_stamper:X8}, m_pQualities:->(PlayerDesc*)0x{(int)m_pQualities:X8}";

        // Functions:

        // ACCWeenieObject.UIAttemptSplitTo3D:
        public void UIAttemptSplitTo3D(int _amount) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058E680)(ref this, _amount); // .text:0058D850 ; void __thiscall ACCWeenieObject::UIAttemptSplitTo3D(ACCWeenieObject *this, int _amount) .text:0058D850 ?UIAttemptSplitTo3D@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.IsHook:
        public int IsHook() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D490)(ref this); // .text:0058C660 ; int __thiscall ACCWeenieObject::IsHook(ACCWeenieObject *this) .text:0058C660 ?IsHook@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.RemoveContentsFromDestructionQueue:
        public void RemoveContentsFromDestructionQueue() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, void>)0x0058D850)(ref this); // .text:0058CA20 ; void __thiscall ACCWeenieObject::RemoveContentsFromDestructionQueue(ACCWeenieObject *this) .text:0058CA20 ?RemoveContentsFromDestructionQueue@ACCWeenieObject@@QAEXXZ

        // ACCWeenieObject.SetCellBarrierImmune:
        public void SetCellBarrierImmune(int b) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CBC0)(ref this, b); // .text:0058BD90 ; void __thiscall ACCWeenieObject::SetCellBarrierImmune(ACCWeenieObject *this, const int b) .text:0058BD90 ?SetCellBarrierImmune@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.SetShortcutNum:
        public void SetShortcutNum(int i_nShortcutNum, Byte i_bGhosted) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, Byte, void>)0x0058CF30)(ref this, i_nShortcutNum, i_bGhosted); // .text:0058C100 ; void __thiscall ACCWeenieObject::SetShortcutNum(ACCWeenieObject *this, int i_nShortcutNum, bool i_bGhosted) .text:0058C100 ?SetShortcutNum@ACCWeenieObject@@QAEXH_N@Z

        // ACCWeenieObject.UIAttemptGive:
        public void UIAttemptGive(UInt32 _targetID, UInt32 _amount) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, UInt32, void>)0x0058E450)(ref this, _targetID, _amount); // .text:0058D620 ; void __thiscall ACCWeenieObject::UIAttemptGive(ACCWeenieObject *this, unsigned int _targetID, unsigned int _amount) .text:0058D620 ?UIAttemptGive@ACCWeenieObject@@QAEXKK@Z

        // ACCWeenieObject.GetDragIcon:
        public Graphic* GetDragIcon() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, Graphic*>)0x0058F490)(ref this); // .text:0058E660 ; Graphic *__thiscall ACCWeenieObject::GetDragIcon(ACCWeenieObject *this) .text:0058E660 ?GetDragIcon@ACCWeenieObject@@QAEPAVGraphic@@XZ

        // ACCWeenieObject.GetPlaceInItemsList:
        public int GetPlaceInItemsList(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int>)0x0058CEC0)(ref this, _id); // .text:0058C090 ; int __thiscall ACCWeenieObject::GetPlaceInItemsList(ACCWeenieObject *this, unsigned int _id) .text:0058C090 ?GetPlaceInItemsList@ACCWeenieObject@@QAEHK@Z

        // ACCWeenieObject.GetPlaceInContainersList:
        public int GetPlaceInContainersList(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int>)0x0058CEE0)(ref this, _id); // .text:0058C0B0 ; int __thiscall ACCWeenieObject::GetPlaceInContainersList(ACCWeenieObject *this, unsigned int _id) .text:0058C0B0 ?GetPlaceInContainersList@ACCWeenieObject@@QAEHK@Z

        // ACCWeenieObject.CanJump:
        public Byte CanJump(Single extent) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, Single, Byte>)0x0058D230)(ref this, extent); // .text:0058C400 ; bool __thiscall ACCWeenieObject::CanJump(ACCWeenieObject *this, float extent) .text:0058C400 ?CanJump@ACCWeenieObject@@UBE_NM@Z

        // ACCWeenieObject.GetExhaustiveContainedItemsList:
        public IDList* GetExhaustiveContainedItemsList(IDList* result) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, IDList*, IDList*>)0x0058CD40)(ref this, result); // .text:0058BF10 ; IDList *__thiscall ACCWeenieObject::GetExhaustiveContainedItemsList(ACCWeenieObject *this, IDList *result) .text:0058BF10 ?GetExhaustiveContainedItemsList@ACCWeenieObject@@QAE?AVIDList@@XZ

        // ACCWeenieObject.GetInvPlacementList:
        public PackableList<InventoryPlacement>* GetInvPlacementList() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, PackableList<InventoryPlacement>*>)0x0058CE20)(ref this); // .text:0058BFF0 ; PackableList<InventoryPlacement> *__thiscall ACCWeenieObject::GetInvPlacementList(ACCWeenieObject *this) .text:0058BFF0 ?GetInvPlacementList@ACCWeenieObject@@QAEPAV?$PackableList@VInventoryPlacement@@@@XZ

        // ACCWeenieObject.JumpStaminaCost:
        public Byte JumpStaminaCost(Single extent, int* cost) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, Single, int*, Byte>)0x0058D270)(ref this, extent, cost); // .text:0058C440 ; bool __thiscall ACCWeenieObject::JumpStaminaCost(ACCWeenieObject *this, float extent, int *cost) .text:0058C440 ?JumpStaminaCost@ACCWeenieObject@@UBE_NMAAJ@Z

        // ACCWeenieObject.AddContentsToDestructionQueue:
        public void AddContentsToDestructionQueue() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, void>)0x0058D7D0)(ref this); // .text:0058C9A0 ; void __thiscall ACCWeenieObject::AddContentsToDestructionQueue(ACCWeenieObject *this) .text:0058C9A0 ?AddContentsToDestructionQueue@ACCWeenieObject@@QAEXXZ

        // ACCWeenieObject.CanMoveInto:
        public int CanMoveInto(CWeenieObject* mover) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, CWeenieObject*, int>)0x0058E870)(ref this, mover); // .text:0058DA40 ; int __thiscall ACCWeenieObject::CanMoveInto(ACCWeenieObject *this, CWeenieObject *mover) .text:0058DA40 ?CanMoveInto@ACCWeenieObject@@UAEHPAVCWeenieObject@@@Z

        // ACCWeenieObject.ObjectBeingDeleted:
        public void ObjectBeingDeleted() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, void>)0x0058F300)(ref this); // .text:0058E4D0 ; void __thiscall ACCWeenieObject::ObjectBeingDeleted(ACCWeenieObject *this) .text:0058E4D0 ?ObjectBeingDeleted@ACCWeenieObject@@UAEXXZ

        // ACCWeenieObject.IsComponentPack:
        public int IsComponentPack() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x00589230)(ref this); // .text:00588400 ; int __thiscall ACCWeenieObject::IsComponentPack(ACCWeenieObject *this) .text:00588400 ?IsComponentPack@ACCWeenieObject@@QBEHXZ

        // ACCWeenieObject.GetNumContainedItems:
        public int GetNumContainedItems() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058CCE0)(ref this); // .text:0058BEB0 ; int __thiscall ACCWeenieObject::GetNumContainedItems(ACCWeenieObject *this) .text:0058BEB0 ?GetNumContainedItems@ACCWeenieObject@@QAEHXZ

        // ACCWeenieObject.SetWaitingState:
        public void SetWaitingState(int _waiting) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CF00)(ref this, _waiting); // .text:0058C0D0 ; void __thiscall ACCWeenieObject::SetWaitingState(ACCWeenieObject *this, int _waiting) .text:0058C0D0 ?SetWaitingState@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.SetSelectedObjectID:
        public static void SetSelectedObjectID(UInt32 _selectedID) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x0058D1C0)(_selectedID); // .text:0058C390 ; void __cdecl ACCWeenieObject::SetSelectedObjectID(unsigned int _selectedID) .text:0058C390 ?SetSelectedObjectID@ACCWeenieObject@@SAXK@Z

        // ACCWeenieObject.UIAttemptPutIn3D:
        public void UIAttemptPutIn3D() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, void>)0x0058E530)(ref this); // .text:0058D700 ; void __thiscall ACCWeenieObject::UIAttemptPutIn3D(ACCWeenieObject *this) .text:0058D700 ?UIAttemptPutIn3D@ACCWeenieObject@@QAEXXZ

        // ACCWeenieObject.IsCoinstack:
        // public Byte IsCoinstack() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, Byte>)0xDEADBEEF)(ref this); // .text:004BD250 ; bool __thiscall ACCWeenieObject::IsCoinstack(ACCWeenieObject *this) .text:004BD250 ?IsCoinstack@ACCWeenieObject@@QBE_NXZ

        // ACCWeenieObject.SetHiddenAdmin:
        public void SetHiddenAdmin(int hide) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CB60)(ref this, hide); // .text:0058BD30 ; void __thiscall ACCWeenieObject::SetHiddenAdmin(ACCWeenieObject *this, const int hide) .text:0058BD30 ?SetHiddenAdmin@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.SetPreviousSelectedObject:
        public static void SetPreviousSelectedObject(UInt32 _selectedID) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x0058D1B0)(_selectedID); // .text:0058C380 ; void __cdecl ACCWeenieObject::SetPreviousSelectedObject(unsigned int _selectedID) .text:0058C380 ?SetPreviousSelectedObject@ACCWeenieObject@@SAXK@Z

        // ACCWeenieObject.IsCreature:
        public int IsCreature() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D220)(ref this); // .text:0058C3F0 ; int __thiscall ACCWeenieObject::IsCreature(ACCWeenieObject *this) .text:0058C3F0 ?IsCreature@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.InqJumpVelocity:
        public Byte InqJumpVelocity(Single extent, Single* v_z) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, Single, Single*, Byte>)0x0058D350)(ref this, extent, v_z); // .text:0058C520 ; bool __thiscall ACCWeenieObject::InqJumpVelocity(ACCWeenieObject *this, float extent, float *v_z) .text:0058C520 ?InqJumpVelocity@ACCWeenieObject@@UBE_NMAAM@Z

        // ACCWeenieObject.BlocksUseOfShield:
        public int BlocksUseOfShield() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0055E100)(ref this); // .text:0055D3E0 ; int __thiscall ACCWeenieObject::BlocksUseOfShield(ACCWeenieObject *this) .text:0055D3E0 ?BlocksUseOfShield@ACCWeenieObject@@QAEHXZ

        // ACCWeenieObject.DeterminePositionState:
        public void DeterminePositionState() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, void>)0x0058CCA0)(ref this); // .text:0058BE70 ; void __thiscall ACCWeenieObject::DeterminePositionState(ACCWeenieObject *this) .text:0058BE70 ?DeterminePositionState@ACCWeenieObject@@QAEXXZ

        // ACCWeenieObject.SetType:
        public void SetType(ITEM_TYPE type) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, ITEM_TYPE, void>)0x0058ECF0)(ref this, type); // .text:0058DEC0 ; void __thiscall ACCWeenieObject::SetType(ACCWeenieObject *this, ITEM_TYPE type) .text:0058DEC0 ?SetType@ACCWeenieObject@@QAEXW4ITEM_TYPE@@@Z

        // ACCWeenieObject.IsOwnedByTrader:
        public int IsOwnedByTrader(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int>)0x0058DC80)(ref this, _id); // .text:0058CE50 ; int __thiscall ACCWeenieObject::IsOwnedByTrader(ACCWeenieObject *this, unsigned int _id) .text:0058CE50 ?IsOwnedByTrader@ACCWeenieObject@@QAEHK@Z

        // ACCWeenieObject.`vector deleting destructor'`adjustor{12}' :
        // (ERR) .text:0058D720 ; [thunk]:public: virtual void * __thiscall ACCWeenieObject::`vector deleting destructor'`adjustor{12}' (unsigned int) .text:0058D720 ??_EACCWeenieObject@@WM@AEPAXI@Z

        // ACCWeenieObject.SetParentedState:
        public void SetParentedState(int _parentedState) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CC40)(ref this, _parentedState); // .text:0058BE10 ; void __thiscall ACCWeenieObject::SetParentedState(ACCWeenieObject *this, int _parentedState) .text:0058BE10 ?SetParentedState@ACCWeenieObject@@UAEXH@Z

        // ACCWeenieObject.__Ctor:
        public void __Ctor(UInt32 iid) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, void>)0x0058D5C0)(ref this, iid); // .text:0058C790 ; void __thiscall ACCWeenieObject::ACCWeenieObject(ACCWeenieObject *this, unsigned int iid) .text:0058C790 ??0ACCWeenieObject@@QAE@K@Z

        // ACCWeenieObject.IsCorpse:
        public int IsCorpse() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D710)(ref this); // .text:0058C8E0 ; int __thiscall ACCWeenieObject::IsCorpse(ACCWeenieObject *this) .text:0058C8E0 ?IsCorpse@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.MagicPackIsOwned:
        public int MagicPackIsOwned(UInt32 wcidEssence) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int>)0x0058D9B0)(ref this, wcidEssence); // .text:0058CB80 ; int __thiscall ACCWeenieObject::MagicPackIsOwned(ACCWeenieObject *this, IDClass<_tagDataID,32,0> wcidEssence) .text:0058CB80 ?MagicPackIsOwned@ACCWeenieObject@@QAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // ACCWeenieObject.SetEffects:
        public void SetEffects(UInt32 effects) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, void>)0x0058ED30)(ref this, effects); // .text:0058DF00 ; void __thiscall ACCWeenieObject::SetEffects(ACCWeenieObject *this, const unsigned int effects) .text:0058DF00 ?SetEffects@ACCWeenieObject@@QAEXK@Z

        // ACCWeenieObject.InqCollisionProfile:
        public int InqCollisionProfile(ObjCollisionProfile* prof) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, ObjCollisionProfile*, int>)0x0058D910)(ref this, prof); // .text:0058CAE0 ; int __thiscall ACCWeenieObject::InqCollisionProfile(ACCWeenieObject *this, ObjCollisionProfile *prof) .text:0058CAE0 ?InqCollisionProfile@ACCWeenieObject@@UBEHAAVObjCollisionProfile@@@Z

        // ACCWeenieObject.IsStorage:
        public int IsStorage() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058DA10)(ref this); // .text:0058CBE0 ; int __thiscall ACCWeenieObject::IsStorage(ACCWeenieObject *this) .text:0058CBE0 ?IsStorage@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.GetLocationOnObject:
        public UInt32 GetLocationOnObject(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, UInt32>)0x0058DC00)(ref this, _id); // .text:0058CDD0 ; unsigned int __thiscall ACCWeenieObject::GetLocationOnObject(ACCWeenieObject *this, unsigned int _id) .text:0058CDD0 ?GetLocationOnObject@ACCWeenieObject@@QAEKK@Z

        // ACCWeenieObject.IsPlayerReadyToMakeInventoryRequest:
        public static int IsPlayerReadyToMakeInventoryRequest(int _quiet) => ((delegate* unmanaged[Cdecl]<int, int>)0x0058DE80)(_quiet); // .text:0058D050 ; int __cdecl ACCWeenieObject::IsPlayerReadyToMakeInventoryRequest(int _quiet) .text:0058D050 ?IsPlayerReadyToMakeInventoryRequest@ACCWeenieObject@@SAHH@Z

        // ACCWeenieObject.GetObjectNameWide:
        public PStringBase<UInt16>* GetObjectNameWide(PStringBase<UInt16>* result, NameType _nameType, int _playerIsBackpack) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, PStringBase<UInt16>*, NameType, int, PStringBase<UInt16>*>)0x0058F8B0)(ref this, result, _nameType, _playerIsBackpack); // .text:0058EA80 ; PStringBase<unsigned short> *__thiscall ACCWeenieObject::GetObjectNameWide(ACCWeenieObject *this, PStringBase<unsigned short> *result, NameType _nameType, int _playerIsBackpack) .text:0058EA80 ?GetObjectNameWide@ACCWeenieObject@@QAE?AV?$PStringBase@G@@W4NameType@@H@Z

        // ACCWeenieObject.IsContainer:
        public int IsContainer() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x004A48A0)(ref this); // .text:004A4530 ; int __thiscall ACCWeenieObject::IsContainer(ACCWeenieObject *this) .text:004A4530 ?IsContainer@ACCWeenieObject@@QBEHXZ

        // ACCWeenieObject.SetMaxStructure:
        public void SetMaxStructure(UInt32 maxStructure) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, void>)0x0058D0D0)(ref this, maxStructure); // .text:0058C2A0 ; void __thiscall ACCWeenieObject::SetMaxStructure(ACCWeenieObject *this, const unsigned int maxStructure) .text:0058C2A0 ?SetMaxStructure@ACCWeenieObject@@QAEXK@Z

        // ACCWeenieObject.UpdateHouseRestrictionTS:
        public int UpdateHouseRestrictionTS(char ts) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, char, int>)0x0058D980)(ref this, ts); // .text:0058CB50 ; int __thiscall ACCWeenieObject::UpdateHouseRestrictionTS(ACCWeenieObject *this, char ts) .text:0058CB50 ?UpdateHouseRestrictionTS@ACCWeenieObject@@QAEHE@Z

        // ACCWeenieObject.ServerSaysMoveItem:
        public void ServerSaysMoveItem(UInt32 _newContainer, int _place, UInt32 _newWielder, UInt32 _newLocation, int _broadcast) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int, UInt32, UInt32, int, void>)0x0058E9E0)(ref this, _newContainer, _place, _newWielder, _newLocation, _broadcast); // .text:0058DBB0 ; void __thiscall ACCWeenieObject::ServerSaysMoveItem(ACCWeenieObject *this, unsigned int _newContainer, int _place, unsigned int _newWielder, unsigned int _newLocation, int _broadcast) .text:0058DBB0 ?ServerSaysMoveItem@ACCWeenieObject@@QAEXKHKKH@Z

        // ACCWeenieObject.OnStatUpdated:
        public void OnStatUpdated(UInt32 stype, UInt32 id) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, UInt32, void>)0x0058F050)(ref this, stype, id); // .text:0058E220 ; void __thiscall ACCWeenieObject::OnStatUpdated(ACCWeenieObject *this, unsigned int stype, unsigned int id) .text:0058E220 ?OnStatUpdated@ACCWeenieObject@@QAEXKK@Z

        // ACCWeenieObject.ObjectsInRange:
        public static int ObjectsInRange(UInt32 _ID1, UInt32 _ID2, Double _range, Byte _use_radii, Byte _xy_only) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Double, Byte, Byte, int>)0x0058CFD0)(_ID1, _ID2, _range, _use_radii, _xy_only); // .text:0058C1A0 ; int __cdecl ACCWeenieObject::ObjectsInRange(unsigned int _ID1, unsigned int _ID2, long double _range, bool _use_radii, bool _xy_only) .text:0058C1A0 ?ObjectsInRange@ACCWeenieObject@@SAHKKN_N0@Z

        // ACCWeenieObject.SetStackSize:
        public void SetStackSize(UInt32 stackSize) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, void>)0x0058D0F0)(ref this, stackSize); // .text:0058C2C0 ; void __thiscall ACCWeenieObject::SetStackSize(ACCWeenieObject *this, const unsigned int stackSize) .text:0058C2C0 ?SetStackSize@ACCWeenieObject@@QAEXK@Z

        // ACCWeenieObject.GetObjectNameWide:
        public static PStringBase<UInt16>* GetObjectNameWide(ACCWeenieObject* This, PStringBase<UInt16>* result, UInt32 _objID, NameType _nameType, int _playerIsBackpack) => ((delegate* unmanaged[Cdecl]<ACCWeenieObject*, PStringBase<UInt16>*, UInt32, NameType, int, PStringBase<UInt16>*>)0x0058F8E0)(This, result, _objID, _nameType, _playerIsBackpack); // .text:0058EAB0 ; PStringBase<unsigned short> *__cdecl ACCWeenieObject::GetObjectNameWide(ACCWeenieObject *this, PStringBase<unsigned short> *result, unsigned int _objID, NameType _nameType, int _playerIsBackpack) .text:0058EAB0 ?GetObjectNameWide@ACCWeenieObject@@SA?AV?$PStringBase@G@@KW4NameType@@H@Z

        // ACCWeenieObject.IsImpenetrable:
        public int IsImpenetrable() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D6F0)(ref this); // .text:0058C8C0 ; int __thiscall ACCWeenieObject::IsImpenetrable(ACCWeenieObject *this) .text:0058C8C0 ?IsImpenetrable@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.RemoveContent:
        public void RemoveContent(ACCWeenieObject* _weenObj) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, ACCWeenieObject*, void>)0x0058DBA0)(ref this, _weenObj); // .text:0058CD70 ; void __thiscall ACCWeenieObject::RemoveContent(ACCWeenieObject *this, ACCWeenieObject *_weenObj) .text:0058CD70 ?RemoveContent@ACCWeenieObject@@QAEXPAV1@@Z

        // ACCWeenieObject.SetPlayerWieldLocation:
        public void SetPlayerWieldLocation(UInt32 _newLocation) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, void>)0x0058E6F0)(ref this, _newLocation); // .text:0058D8C0 ; void __thiscall ACCWeenieObject::SetPlayerWieldLocation(ACCWeenieObject *this, const unsigned int _newLocation) .text:0058D8C0 ?SetPlayerWieldLocation@ACCWeenieObject@@QAEXK@Z

        // ACCWeenieObject.GetIcon:
        public Graphic* GetIcon() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, Graphic*>)0x0058F480)(ref this); // .text:0058E650 ; Graphic *__thiscall ACCWeenieObject::GetIcon(ACCWeenieObject *this) .text:0058E650 ?GetIcon@ACCWeenieObject@@QAEPAVGraphic@@XZ

        // ACCWeenieObject.`scalar deleting destructor':
        // (ERR) .text:0058DA50 ; int __thiscall ACCWeenieObject::`scalar deleting destructor'(void *, char) .text:0058DA50 ??_GACCWeenieObject@@UAEPAXI@Z

        // ACCWeenieObject.SetStuck:
        public void SetStuck(int stuck) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CB00)(ref this, stuck); // .text:0058BCD0 ; void __thiscall ACCWeenieObject::SetStuck(ACCWeenieObject *this, const int stuck) .text:0058BCD0 ?SetStuck@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.UIAttemptPutInContainer:
        public void UIAttemptPutInContainer(UInt32 _container, int _place) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int, void>)0x0058E4B0)(ref this, _container, _place); // .text:0058D680 ; void __thiscall ACCWeenieObject::UIAttemptPutInContainer(ACCWeenieObject *this, unsigned int _container, int _place) .text:0058D680 ?UIAttemptPutInContainer@ACCWeenieObject@@QAEXKH@Z

        // ACCWeenieObject.OnStatUpdated:
        public void OnStatUpdated(UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int, void>)0x0058ED50)(ref this, stype, val); // .text:0058DF20 ; void __thiscall ACCWeenieObject::OnStatUpdated(ACCWeenieObject *this, unsigned int stype, int val) .text:0058DF20 ?OnStatUpdated@ACCWeenieObject@@QAEXKJ@Z

        // ACCWeenieObject.DeclareValid:
        public void DeclareValid() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, void>)0x0058F170)(ref this); // .text:0058E340 ; void __thiscall ACCWeenieObject::DeclareValid(ACCWeenieObject *this) .text:0058E340 ?DeclareValid@ACCWeenieObject@@QAEXXZ

        // ACCWeenieObject.SetOpenable:
        public void SetOpenable(int openable) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CAD0)(ref this, openable); // .text:0058BCA0 ; void __thiscall ACCWeenieObject::SetOpenable(ACCWeenieObject *this, const int openable) .text:0058BCA0 ?SetOpenable@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.AllContainedObjectsExist:
        public int AllContainedObjectsExist() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058CE30)(ref this); // .text:0058C000 ; int __thiscall ACCWeenieObject::AllContainedObjectsExist(ACCWeenieObject *this) .text:0058C000 ?AllContainedObjectsExist@ACCWeenieObject@@QAEHXZ

        // ACCWeenieObject.InqRunRate:
        public Byte InqRunRate(Single* rate) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, Single*, Byte>)0x0058D390)(ref this, rate); // .text:0058C560 ; bool __thiscall ACCWeenieObject::InqRunRate(ACCWeenieObject *this, float *rate) .text:0058C560 ?InqRunRate@ACCWeenieObject@@UBE_NAAM@Z

        // ACCWeenieObject.IsPlayerKiller:
        public int IsPlayerKiller() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D740)(ref this); // .text:0058C910 ; int __thiscall ACCWeenieObject::IsPlayerKiller(ACCWeenieObject *this) .text:0058C910 ?IsPlayerKiller@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.AddContent:
        public void AddContent(ACCWeenieObject* _weenObj, int _place) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, ACCWeenieObject*, int, void>)0x0058DB10)(ref this, _weenObj, _place); // .text:0058CCE0 ; void __thiscall ACCWeenieObject::AddContent(ACCWeenieObject *this, ACCWeenieObject *_weenObj, int _place) .text:0058CCE0 ?AddContent@ACCWeenieObject@@QAEXPAV1@H@Z

        // ACCWeenieObject.SetInscribable:
        public void SetInscribable(int inscribable) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CB30)(ref this, inscribable); // .text:0058BD00 ; void __thiscall ACCWeenieObject::SetInscribable(ACCWeenieObject *this, const int inscribable) .text:0058BD00 ?SetInscribable@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.SetSelectedObject:
        public static void SetSelectedObject(UInt32 _selectedID, int _reselect) => ((delegate* unmanaged[Cdecl]<UInt32, int, void>)0x0058D110)(_selectedID, _reselect); // .text:0058C2E0 ; void __cdecl ACCWeenieObject::SetSelectedObject(unsigned int _selectedID, int _reselect) .text:0058C2E0 ?SetSelectedObject@ACCWeenieObject@@SAXKH@Z

        // ACCWeenieObject.InqMaxRunRate:
        public Byte InqMaxRunRate(Single* rate) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, Single*, Byte>)0x0058D3D0)(ref this, rate); // .text:0058C5A0 ; bool __thiscall ACCWeenieObject::InqMaxRunRate(ACCWeenieObject *this, float *rate) .text:0058C5A0 ?InqMaxRunRate@ACCWeenieObject@@UBE_NAAM@Z

        // ACCWeenieObject.SetCorpseDeleted:
        public static void SetCorpseDeleted(UInt32 corpseID) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x0058F4F0)(corpseID); // .text:0058E6C0 ; void __cdecl ACCWeenieObject::SetCorpseDeleted(const unsigned int corpseID) .text:0058E6C0 ?SetCorpseDeleted@ACCWeenieObject@@SAXK@Z

        // ACCWeenieObject.IsAllegianceMember:
        public int IsAllegianceMember(ACCWeenieObject* wobj) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, ACCWeenieObject*, int>)0x0058D460)(ref this, wobj); // .text:0058C630 ; int __thiscall ACCWeenieObject::IsAllegianceMember(ACCWeenieObject *this, ACCWeenieObject *wobj) .text:0058C630 ?IsAllegianceMember@ACCWeenieObject@@QBEHPAV1@@Z

        // ACCWeenieObject.IsPKLite:
        public int IsPKLite() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D6D0)(ref this); // .text:0058C8A0 ; int __thiscall ACCWeenieObject::IsPKLite(ACCWeenieObject *this) .text:0058C8A0 ?IsPKLite@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.IsOwnedByPlayer:
        public int IsOwnedByPlayer() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058DF90)(ref this); // .text:0058D160 ; int __thiscall ACCWeenieObject::IsOwnedByPlayer(ACCWeenieObject *this) .text:0058D160 ?IsOwnedByPlayer@ACCWeenieObject@@QAEHXZ

        // ACCWeenieObject.UIAttemptWield:
        public void UIAttemptWield(UInt32 _loc) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, void>)0x0058E3C0)(ref this, _loc); // .text:0058D590 ; void __thiscall ACCWeenieObject::UIAttemptWield(ACCWeenieObject *this, unsigned int _loc) .text:0058D590 ?UIAttemptWield@ACCWeenieObject@@QAEXK@Z

        // ACCWeenieObject.GetNumEmptyItemSlots:
        public int GetNumEmptyItemSlots() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058CD00)(ref this); // .text:0058BED0 ; int __thiscall ACCWeenieObject::GetNumEmptyItemSlots(ACCWeenieObject *this) .text:0058BED0 ?GetNumEmptyItemSlots@ACCWeenieObject@@QAEHXZ

        // ACCWeenieObject.InqType:
        public ITEM_TYPE InqType() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, ITEM_TYPE>)0x0058D700)(ref this); // .text:0058C8D0 ; ITEM_TYPE __thiscall ACCWeenieObject::InqType(ACCWeenieObject *this) .text:0058C8D0 ?InqType@ACCWeenieObject@@UBE?AW4ITEM_TYPE@@XZ

        // ACCWeenieObject.UIAttemptMerge:
        public void UIAttemptMerge(UInt32 _mergeToItem, int _amount) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int, void>)0x0058E5A0)(ref this, _mergeToItem, _amount); // .text:0058D770 ; void __thiscall ACCWeenieObject::UIAttemptMerge(ACCWeenieObject *this, unsigned int _mergeToItem, int _amount) .text:0058D770 ?UIAttemptMerge@ACCWeenieObject@@QAEXKH@Z

        // ACCWeenieObject.HasCorpseBeenOpened:
        public static int HasCorpseBeenOpened(UInt32 corpseID) => ((delegate* unmanaged[Cdecl]<UInt32, int>)0x0058E9A0)(corpseID); // .text:0058DB70 ; int __cdecl ACCWeenieObject::HasCorpseBeenOpened(const unsigned int corpseID) .text:0058DB70 ?HasCorpseBeenOpened@ACCWeenieObject@@SAHK@Z

        // ACCWeenieObject.IconDataChanged:
        public void IconDataChanged() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, void>)0x0058EC00)(ref this); // .text:0058DDD0 ; void __thiscall ACCWeenieObject::IconDataChanged(ACCWeenieObject *this) .text:0058DDD0 ?IconDataChanged@ACCWeenieObject@@IAEXXZ

        // ACCWeenieObject.GetNumEmitters:
        public UInt32 GetNumEmitters() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32>)0x0058D2D0)(ref this); // .text:0058C4A0 ; unsigned int __thiscall ACCWeenieObject::GetNumEmitters(ACCWeenieObject *this) .text:0058C4A0 ?GetNumEmitters@ACCWeenieObject@@UAEKXZ

        // ACCWeenieObject.GetObjectAtLocation:
        public UInt32 GetObjectAtLocation(UInt32 _loc, UInt32 _priority) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, UInt32, UInt32>)0x0058DC30)(ref this, _loc, _priority); // .text:0058CE00 ; unsigned int __thiscall ACCWeenieObject::GetObjectAtLocation(ACCWeenieObject *this, unsigned int _loc, unsigned int _priority) .text:0058CE00 ?GetObjectAtLocation@ACCWeenieObject@@QAEKKK@Z

        // ACCWeenieObject.~ACCWeenieObject:
        // (ERR) .text:0058D760 ; public: virtual __thiscall ACCWeenieObject::~ACCWeenieObject(void) .text:0058D760 ??1ACCWeenieObject@@UAE@XZ

        // ACCWeenieObject.RecordRequest:
        public static void RecordRequest(UInt32 _requestObjID, InventoryRequest _request) => ((delegate* unmanaged[Cdecl]<UInt32, InventoryRequest, void>)0x0058D050)(_requestObjID, _request); // .text:0058C220 ; void __cdecl ACCWeenieObject::RecordRequest(unsigned int _requestObjID, InventoryRequest _request) .text:0058C220 ?RecordRequest@ACCWeenieObject@@SAXKW4InventoryRequest@@@Z

        // ACCWeenieObject.InqShowableOnRadar:
        public int InqShowableOnRadar(AC1Legacy.Vector3* cur_pos) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, AC1Legacy.Vector3*, int>)0x0058D080)(ref this, cur_pos); // .text:0058C250 ; int __thiscall ACCWeenieObject::InqShowableOnRadar(ACCWeenieObject *this, AC1Legacy::Vector3 *cur_pos) .text:0058C250 ?InqShowableOnRadar@ACCWeenieObject@@QBEHABVVector3@AC1Legacy@@@Z

        // ACCWeenieObject.PlayScript:
        public int PlayScript(PScriptType script_type, Single mod) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, PScriptType, Single, int>)0x0058D2B0)(ref this, script_type, mod); // .text:0058C480 ; int __thiscall ACCWeenieObject::PlayScript(ACCWeenieObject *this, PScriptType script_type, float mod) .text:0058C480 ?PlayScript@ACCWeenieObject@@UAEHW4PScriptType@@M@Z

        // ACCWeenieObject.GetIconData:
        public IconData* GetIconData() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, IconData*>)0x0058EC60)(ref this); // .text:0058DE30 ; IconData *__thiscall ACCWeenieObject::GetIconData(ACCWeenieObject *this) .text:0058DE30 ?GetIconData@ACCWeenieObject@@QAEPAVIconData@@XZ

        // ACCWeenieObject.SetUseability:
        public void SetUseability(ITEM_USEABLE useability) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, ITEM_USEABLE, void>)0x0058ED10)(ref this, useability); // .text:0058DEE0 ; void __thiscall ACCWeenieObject::SetUseability(ACCWeenieObject *this, ITEM_USEABLE useability) .text:0058DEE0 ?SetUseability@ACCWeenieObject@@QAEXW4ITEM_USEABLE@@@Z

        // ACCWeenieObject.SetUIHidden:
        public void SetUIHidden(int hide) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CB90)(ref this, hide); // .text:0058BD60 ; void __thiscall ACCWeenieObject::SetUIHidden(ACCWeenieObject *this, const int hide) .text:0058BD60 ?SetUIHidden@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.GetContainedItemsList:
        public IDList* GetContainedItemsList() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, IDList*>)0x0058CD20)(ref this); // .text:0058BEF0 ; IDList *__thiscall ACCWeenieObject::GetContainedItemsList(ACCWeenieObject *this) .text:0058BEF0 ?GetContainedItemsList@ACCWeenieObject@@QAEPAVIDList@@XZ

        // ACCWeenieObject.OnStatUpdated:
        public void OnStatUpdated_(UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int, void>)0x0058D4B0)(ref this, stype, val); // .text:0058C680 ; void __thiscall ACCWeenieObject::OnStatUpdated(ACCWeenieObject *this, unsigned int stype, int val) .text:0058C680 ?OnStatUpdated@ACCWeenieObject@@QAEXKH@Z

        // ACCWeenieObject.OnStatUpdated:
        public void OnStatUpdated_(UInt32 stype, uint id) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, UInt32, void>)0x0058EFB0)(ref this, stype, id); // .text:0058E180 ; void __thiscall ACCWeenieObject::OnStatUpdated(ACCWeenieObject *this, unsigned int stype, IDClass<_tagDataID,32,0> id) .text:0058E180 ?OnStatUpdated@ACCWeenieObject@@QAEXKV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // ACCWeenieObject.GetObjectName:
        public static char* GetObjectName(ACCWeenieObject* This, UInt32 _objID, NameType _nameType, int _playerIsBackpack) => ((delegate* unmanaged[Cdecl]<ACCWeenieObject*, UInt32, NameType, int, char*>)0x0058F840)(This, _objID, _nameType, _playerIsBackpack); // .text:0058EA10 ; char *__cdecl ACCWeenieObject::GetObjectName(ACCWeenieObject *this, unsigned int _objID, NameType _nameType, int _playerIsBackpack) .text:0058EA10 ?GetObjectName@ACCWeenieObject@@SAPADKW4NameType@@H@Z

        // ACCWeenieObject.ServerSaysSetStackSize:
        public void ServerSaysSetStackSize(int _size, UInt32 _value) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, UInt32, void>)0x0058DA70)(ref this, _size, _value); // .text:0058CC40 ; void __thiscall ACCWeenieObject::ServerSaysSetStackSize(ACCWeenieObject *this, int _size, unsigned int _value) .text:0058CC40 ?ServerSaysSetStackSize@ACCWeenieObject@@QAEXHK@Z

        // ACCWeenieObject.SetRestrictions:
        public void SetRestrictions(RestrictionDB* db) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, RestrictionDB*, void>)0x00586720)(ref this, db); // .text:005858A0 ; void __thiscall ACCWeenieObject::SetRestrictions(ACCWeenieObject *this, RestrictionDB *db) .text:005858A0 ?SetRestrictions@ACCWeenieObject@@QAEXABVRestrictionDB@@@Z

        // ACCWeenieObject.SetTradeState:
        public void SetTradeState(int _tradeState) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CF70)(ref this, _tradeState); // .text:0058C140 ; void __thiscall ACCWeenieObject::SetTradeState(ACCWeenieObject *this, int _tradeState) .text:0058C140 ?SetTradeState@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.IsPK:
        public int IsPK() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D6E0)(ref this); // .text:0058C8B0 ; int __thiscall ACCWeenieObject::IsPK(ACCWeenieObject *this) .text:0058C8B0 ?IsPK@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.SetCorpseOpened:
        public static void SetCorpseOpened(UInt32 corpseID) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x0058F4A0)(corpseID); // .text:0058E670 ; void __cdecl ACCWeenieObject::SetCorpseOpened(const unsigned int corpseID) .text:0058E670 ?SetCorpseOpened@ACCWeenieObject@@SAXK@Z

        // ACCWeenieObject.SetSellState:
        public void SetSellState(int _sellState) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int, void>)0x0058CFA0)(ref this, _sellState); // .text:0058C170 ; void __thiscall ACCWeenieObject::SetSellState(ACCWeenieObject *this, int _sellState) .text:0058C170 ?SetSellState@ACCWeenieObject@@QAEXH@Z

        // ACCWeenieObject.DoCollision:
        public int DoCollision(EnvCollisionProfile* prof) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, EnvCollisionProfile*, int>)0x0058D1D0)(ref this, prof); // .text:0058C3A0 ; int __thiscall ACCWeenieObject::DoCollision(ACCWeenieObject *this, EnvCollisionProfile *prof) .text:0058C3A0 ?DoCollision@ACCWeenieObject@@UAEHABVEnvCollisionProfile@@@Z

        // ACCWeenieObject.RecordResponse:
        public static void RecordResponse(UInt32 _responseObjID) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x0058D8E0)(_responseObjID); // .text:0058CAB0 ; void __cdecl ACCWeenieObject::RecordResponse(unsigned int _responseObjID) .text:0058CAB0 ?RecordResponse@ACCWeenieObject@@SAXK@Z

        // ACCWeenieObject.GetObjectName:
        public char* GetObjectName(NameType _nameType, int _playerIsBackpack) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, NameType, int, char*>)0x0058F510)(ref this, _nameType, _playerIsBackpack); // .text:0058E6E0 ; char *__thiscall ACCWeenieObject::GetObjectName(ACCWeenieObject *this, NameType _nameType, int _playerIsBackpack) .text:0058E6E0 ?GetObjectName@ACCWeenieObject@@QAEPADW4NameType@@H@Z

        // ACCWeenieObject.ServerSaysAttemptFailed:
        public void ServerSaysAttemptFailed(UInt32 _etype, int _printError) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int, void>)0x0058F910)(ref this, _etype, _printError); // .text:0058EAE0 ; void __thiscall ACCWeenieObject::ServerSaysAttemptFailed(ACCWeenieObject *this, unsigned int _etype, int _printError) .text:0058EAE0 ?ServerSaysAttemptFailed@ACCWeenieObject@@QAEXKH@Z

        // ACCWeenieObject.GetNumContainedContainers:
        public int GetNumContainedContainers() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058CCF0)(ref this); // .text:0058BEC0 ; int __thiscall ACCWeenieObject::GetNumContainedContainers(ACCWeenieObject *this) .text:0058BEC0 ?GetNumContainedContainers@ACCWeenieObject@@QAEHXZ

        // ACCWeenieObject.GetGlobalVelocity:
        public int GetGlobalVelocity(AC1Legacy.Vector3* velocity) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, AC1Legacy.Vector3*, int>)0x0058D2F0)(ref this, velocity); // .text:0058C4C0 ; int __thiscall ACCWeenieObject::GetGlobalVelocity(ACCWeenieObject *this, AC1Legacy::Vector3 *velocity) .text:0058C4C0 ?GetGlobalVelocity@ACCWeenieObject@@UBEHAAVVector3@AC1Legacy@@@Z

        // ACCWeenieObject.SetStructure:
        public void SetStructure(UInt32 structure) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, void>)0x0058D0B0)(ref this, structure); // .text:0058C280 ; void __thiscall ACCWeenieObject::SetStructure(ACCWeenieObject *this, const unsigned int structure) .text:0058C280 ?SetStructure@ACCWeenieObject@@QAEXK@Z

        // ACCWeenieObject.InqIconID:
        public UInt32* InqIconID(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32*, UInt32*>)0x0058D730)(ref this, result); // .text:0058C900 ; IDClass<_tagDataID,32,0> *__thiscall ACCWeenieObject::InqIconID(ACCWeenieObject *this, IDClass<_tagDataID,32,0> *result) .text:0058C900 ?InqIconID@ACCWeenieObject@@UBE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // ACCWeenieObject.GetContainedContainersList:
        public IDList* GetContainedContainersList() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, IDList*>)0x0058CD30)(ref this); // .text:0058BF00 ; IDList *__thiscall ACCWeenieObject::GetContainedContainersList(ACCWeenieObject *this) .text:0058BF00 ?GetContainedContainersList@ACCWeenieObject@@QAEPAVIDList@@XZ

        // ACCWeenieObject.ResetPlayerDesc:
        public void ResetPlayerDesc() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, void>)0x0058CBF0)(ref this); // .text:0058BDC0 ; void __thiscall ACCWeenieObject::ResetPlayerDesc(ACCWeenieObject *this) .text:0058BDC0 ?ResetPlayerDesc@ACCWeenieObject@@UAEXXZ

        // ACCWeenieObject.SetupStamper:
        public int SetupStamper() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D410)(ref this); // .text:0058C5E0 ; int __thiscall ACCWeenieObject::SetupStamper(ACCWeenieObject *this) .text:0058C5E0 ?SetupStamper@ACCWeenieObject@@IAEHXZ

        // ACCWeenieObject.UIAttemptSplitToContainer:
        public void UIAttemptSplitToContainer(UInt32 _container, int _place, int _amount) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int, int, void>)0x0058E600)(ref this, _container, _place, _amount); // .text:0058D7D0 ; void __thiscall ACCWeenieObject::UIAttemptSplitToContainer(ACCWeenieObject *this, unsigned int _container, int _place, int _amount) .text:0058D7D0 ?UIAttemptSplitToContainer@ACCWeenieObject@@QAEXKHH@Z

        // ACCWeenieObject.IsThePlayer:
        public int IsThePlayer() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D200)(ref this); // .text:0058C3D0 ; int __thiscall ACCWeenieObject::IsThePlayer(ACCWeenieObject *this) .text:0058C3D0 ?IsThePlayer@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.CanBypassMoveRestrictions:
        public int CanBypassMoveRestrictions() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D330)(ref this); // .text:0058C500 ; int __thiscall ACCWeenieObject::CanBypassMoveRestrictions(ACCWeenieObject *this) .text:0058C500 ?CanBypassMoveRestrictions@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.IsPlayer:
        public int IsPlayer() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058D6C0)(ref this); // .text:0058C890 ; int __thiscall ACCWeenieObject::IsPlayer(ACCWeenieObject *this) .text:0058C890 ?IsPlayer@ACCWeenieObject@@UBEHXZ

        // ACCWeenieObject.IsOwnedByObject:
        public int IsOwnedByObject(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int>)0x0058DCE0)(ref this, _id); // .text:0058CEB0 ; int __thiscall ACCWeenieObject::IsOwnedByObject(ACCWeenieObject *this, unsigned int _id) .text:0058CEB0 ?IsOwnedByObject@ACCWeenieObject@@QAEHK@Z

        // ACCWeenieObject.ServerSaysRemove:
        // (ERR) .text:0058F2F0 ; public: void __thiscall ACCWeenieObject::ServerSaysRemove(void) .text:0058F2F0 ?ServerSaysRemove@ACCWeenieObject@@QAEXXZ

        // ACCWeenieObject.ServerSaysContainID:
        public void ServerSaysContainID(UInt32 _item, int _place, int _itemIsContainer) => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, UInt32, int, int, void>)0x0058CC70)(ref this, _item, _place, _itemIsContainer); // .text:0058BE40 ; void __thiscall ACCWeenieObject::ServerSaysContainID(ACCWeenieObject *this, unsigned int _item, int _place, int _itemIsContainer) .text:0058BE40 ?ServerSaysContainID@ACCWeenieObject@@QAEXKHH@Z

        // ACCWeenieObject.GetHousePayment:
        public int GetHousePayment() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, int>)0x0058DDB0)(ref this); // .text:0058CF80 ; int __thiscall ACCWeenieObject::GetHousePayment(ACCWeenieObject *this) .text:0058CF80 ?GetHousePayment@ACCWeenieObject@@QBEJXZ

        // ACCWeenieObject.Remove:
        public void Remove() => ((delegate* unmanaged[Thiscall]<ref ACCWeenieObject, void>)0x0058EB50)(ref this); // .text:0058DD20 ; void __thiscall ACCWeenieObject::Remove(ACCWeenieObject *this) .text:0058DD20 ?Remove@ACCWeenieObject@@QAEXXZ

        // Globals:
        public static Double* splitTime = (Double*)0x00871EC8; // .data:00870EB8 ; long double ACCWeenieObject::splitTime .data:00870EB8 ?splitTime@ACCWeenieObject@@1NA
        public static Double* prevRequestTime = (Double*)0x00871ED8; // .data:00870EC8 ; long double ACCWeenieObject::prevRequestTime .data:00870EC8 ?prevRequestTime@ACCWeenieObject@@1NA
        public static UInt32* splitClassID = (UInt32*)0x00871F88; // .data:00870F78 ; IDClass<_tagDataID,32,0> ACCWeenieObject::splitClassID .data:00870F78 ?splitClassID@ACCWeenieObject@@1V?$IDClass@U_tagDataID@@$0CA@$0A@@@A
        public static LongHash<IconData>* iconDataTable = (LongHash<IconData>*)0x008216CC; // .data:008206BC ; LongHash<IconData> ACCWeenieObject::iconDataTable .data:008206BC ?iconDataTable@ACCWeenieObject@@1V?$LongHash@VIconData@@@@A
        public static uint* selectedID = (uint*)0x00871E54; // .data:00870E44 ; _Formatted ACCWeenieObject::selectedID .data:00870E44 ?selectedID@ACCWeenieObject@@1KA
        public static char* nameString = (char*)0x00871E60; // .data:00870E50 ; char ACCWeenieObject::nameString[100] .data:00870E50 ?nameString@ACCWeenieObject@@1PADA
        public static UInt32* splitStackSize = (UInt32*)0x00871EC4; // .data:00870EB4 ; unsigned int ACCWeenieObject::splitStackSize .data:00870EB4 ?splitStackSize@ACCWeenieObject@@1KA
        public static InventoryRequest* prevRequest = (InventoryRequest*)0x00871ED0; // .data:00870EC0 ; InventoryRequest ACCWeenieObject::prevRequest .data:00870EC0 ?prevRequest@ACCWeenieObject@@1W4InventoryRequest@@A
                                                                                     // .data:008216D8 ; void *ACCWeenieObject::iconDataTable .data:008216D8 ?iconDataTable@ACCWeenieObject@@1V?$LongHash@VIconData@@@@A_baseclass_0_buckets
        public static HashSet<UInt32>* m_openedCorpses = (HashSet<UInt32>*)0x008216E8; // .data:008206D8 ; HashSet<unsigned long> ACCWeenieObject::m_openedCorpses .data:008206D8 ?m_openedCorpses@ACCWeenieObject@@1V?$HashSet@K@@A
        public static UInt32* prevSelectedID = (UInt32*)0x00871E58; // .data:00870E48 ; unsigned int ACCWeenieObject::prevSelectedID .data:00870E48 ?prevSelectedID@ACCWeenieObject@@1KA
        public static UInt32* prevSelectedValidID = (UInt32*)0x00871E5C; // .data:00870E4C ; unsigned int ACCWeenieObject::prevSelectedValidID .data:00870E4C ?prevSelectedValidID@ACCWeenieObject@@1KA
        public static UInt32* prevRequestObjectID = (UInt32*)0x00871ED4; // .data:00870EC4 ; unsigned int ACCWeenieObject::prevRequestObjectID .data:00870EC4 ?prevRequestObjectID@ACCWeenieObject@@1KA
        public static int* attackInProgress = (int*)0x00871EE0; // .data:00870ED0 ; int ACCWeenieObject::attackInProgress .data:00870ED0 ?attackInProgress@ACCWeenieObject@@1HA
    }
    public unsafe struct IconData {
        // Struct:
        public LongHashData a0;
        public UInt32 m_idIcon;
        public UInt32 m_idCustomOverlay;
        public UInt32 m_idCustomUnderlay;
        public ITEM_TYPE m_itemType;
        public UInt32 m_effects;
        public Graphic* m_pIcon;
        public Graphic* m_pDragIcon;
        public override string ToString() => $"a0(LongHashData):{a0}, m_idIcon:{m_idIcon:X8}, m_idCustomOverlay:{m_idCustomOverlay:X8}, m_idCustomUnderlay:{m_idCustomUnderlay:X8}, m_itemType(ITEM_TYPE):{m_itemType}, m_effects:{m_effects:X8}, m_pIcon:->(Graphic*)0x{(int)m_pIcon:X8}, m_pDragIcon:->(Graphic*)0x{(int)m_pDragIcon:X8}";

        // Functions:

        // IconData.__Ctor:
        public void __Ctor(ACCWeenieObject* _weenObj, int _id) => ((delegate* unmanaged[Thiscall]<ref IconData, ACCWeenieObject*, int, void>)0x0058E7B0)(ref this, _weenObj, _id); // .text:0058D980 ; void __thiscall IconData::IconData(IconData *this, ACCWeenieObject *_weenObj, int _id) .text:0058D980 ??0IconData@@QAE@PAVACCWeenieObject@@H@Z

        // IconData.UpdateIcons:
        public int UpdateIcons(ACCWeenieObject* _weenObj) => ((delegate* unmanaged[Thiscall]<ref IconData, ACCWeenieObject*, int>)0x0058E800)(ref this, _weenObj); // .text:0058D9D0 ; int __thiscall IconData::UpdateIcons(IconData *this, ACCWeenieObject *_weenObj) .text:0058D9D0 ?UpdateIcons@IconData@@QAEHPAVACCWeenieObject@@@Z

        // IconData.`scalar deleting destructor':
        // (ERR) .text:0058DD60 ; int __thiscall IconData::`scalar deleting destructor'(void *, char) .text:0058DD60 ??_GIconData@@UAEPAXI@Z

        // IconData.RenderIcons:
        public void RenderIcons(ACCWeenieObject* _weenObj) => ((delegate* unmanaged[Thiscall]<ref IconData, ACCWeenieObject*, void>)0x0058DFB0)(ref this, _weenObj); // .text:0058D180 ; void __thiscall IconData::RenderIcons(IconData *this, ACCWeenieObject *_weenObj) .text:0058D180 ?RenderIcons@IconData@@QAEXPAVACCWeenieObject@@@Z

        // Globals:
        // public static RGBAColor* s_NullColor = (RGBAColor*)0xDEADBEEF; // .data:00870EE0 ; RGBAColor IconData::s_NullColor .data:00870EE0 ?s_NullColor@IconData@@0VRGBAColor@@A
    }
    public unsafe struct PlayerDesc {
        // Struct:
        public CACQualities a0;
        public override string ToString() => $"a0(CACQualities):{a0}";

        // Functions:

        // PlayerDesc.PlayerIsPSR:
        public Byte PlayerIsPSR() => ((delegate* unmanaged[Thiscall]<ref PlayerDesc, Byte>)0x00593E30)(ref this); // .text:00593030 ; bool __thiscall PlayerDesc::PlayerIsPSR(PlayerDesc *this) .text:00593030 ?PlayerIsPSR@PlayerDesc@@QAE_NXZ

        // PlayerDesc.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref PlayerDesc, TResult*, Turbine_GUID*, void**, TResult*>)0x00593F20)(ref this, result, i_rcInterface, o_ppvInterface); // .text:00593120 ; TResult *__thiscall PlayerDesc::QueryInterface(PlayerDesc *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:00593120 ?QueryInterface@PlayerDesc@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // PlayerDesc.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref PlayerDesc, void>)0x00594620)(ref this); // .text:00593870 ; void __thiscall PlayerDesc::PlayerDesc(PlayerDesc *this) .text:00593870 ??0PlayerDesc@@QAE@XZ

        // PlayerDesc.Cleanup:
        public void Cleanup() => ((delegate* unmanaged[Thiscall]<ref PlayerDesc, void>)0x00594710)(ref this); // .text:00593910 ; void __thiscall PlayerDesc::Cleanup(PlayerDesc *this) .text:00593910 ?Cleanup@PlayerDesc@@QAEXXZ

        // PlayerDesc.`vector deleting destructor'`adjustor{48}' :
        // (ERR) .text:00593F00 ; [thunk]:public: virtual void * __thiscall PlayerDesc::`vector deleting destructor'`adjustor{48}' (unsigned int) .text:00593F00 ??_EPlayerDesc@@WDA@AEPAXI@Z

        // PlayerDesc.PlayerIsPSRLead:
        public Byte PlayerIsPSRLead() => ((delegate* unmanaged[Thiscall]<ref PlayerDesc, Byte>)0x00593DE0)(ref this); // .text:00592FE0 ; bool __thiscall PlayerDesc::PlayerIsPSRLead(PlayerDesc *this) .text:00592FE0 ?PlayerIsPSRLead@PlayerDesc@@QAE_NXZ
    }
    public unsafe struct CACQualities {
        // Struct:
        public SerializeUsingPackDBObj a0;
        public CBaseQualities a1;
        public AttributeCache* _attribCache;
        public PackableHashTable<UInt32, Skill>* _skillStatsTable;
        public Body* _body;
        public CSpellBook* _spell_book;
        public CEnchantmentRegistry* _enchantment_reg;
        public EventFilter* _event_filter;
        public CEmoteTable* _emote_table;
        public PackableList<CreationProfile>* _create_list;
        public PageDataList* _pageDataList;
        public GeneratorTable* _generator_table;
        public GeneratorRegistry* _generator_registry;
        public GeneratorQueue* _generator_queue;
        public override string ToString() => $"a0(SerializeUsingPackDBObj):{a0}, a1(CBaseQualities):{a1}, _attribCache:->(AttributeCache*)0x{(int)_attribCache:X8}, _skillStatsTable:->(PackableHashTable<UInt32,Skill>*)0x{(int)_skillStatsTable:X8}, _body:->(Body*)0x{(int)_body:X8}, _spell_book:->(CSpellBook*)0x{(int)_spell_book:X8}, _enchantment_reg:->(CEnchantmentRegistry*)0x{(int)_enchantment_reg:X8}, _event_filter:->(EventFilter*)0x{(int)_event_filter:X8}, _emote_table:->(CEmoteTable*)0x{(int)_emote_table:X8}, _create_list:->(PackableList<CreationProfile>*)0x{(int)_create_list:X8}, _pageDataList:->(PageDataList*)0x{(int)_pageDataList:X8}, _generator_table:->(GeneratorTable*)0x{(int)_generator_table:X8}, _generator_registry:->(GeneratorRegistry*)0x{(int)_generator_registry:X8}, _generator_queue:->(GeneratorQueue*)0x{(int)_generator_queue:X8}";

        // Functions:

        // CACQualities.__Ctor:
        public void __Ctor(UInt32 wcid) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, void>)0x00593E70)(ref this, wcid); // .text:00593070 ; void __thiscall CACQualities::CACQualities(CACQualities *this, IDClass<_tagDataID,32,0> wcid) .text:00593070 ??0CACQualities@@QAE@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CACQualities.AddSpell:
        public int AddSpell(UInt32 newSpell) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int>)0x00590050)(ref this, newSpell); // .text:0058F220 ; int __thiscall CACQualities::AddSpell(CACQualities *this, const unsigned int newSpell) .text:0058F220 ?AddSpell@CACQualities@@QAEHK@Z

        // CACQualities.Allocate:
        public DBObj* Allocate() => ((delegate* unmanaged[Thiscall]<ref CACQualities, DBObj*>)0x00593FE0)(ref this); // .text:005931E0 ; DBObj *__thiscall CACQualities::Allocate(CACQualities *this) .text:005931E0 ?Allocate@CACQualities@@UBEPAVDBObj@@XZ

        // CACQualities.Allocator:
        public static DBObj* Allocator() => ((delegate* unmanaged[Cdecl]<DBObj*>)0x00593FF0)(); // .text:005931F0 ; DBObj *__cdecl CACQualities::Allocator() .text:005931F0 ?Allocator@CACQualities@@SAPAVDBObj@@XZ

        // CACQualities.BoundsCheck:
        public int BoundsCheck(UInt32 stype, int* val, UInt32* max) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int*, UInt32*, int>)0x00592E00)(ref this, stype, val, max); // .text:005920E0 ; int __thiscall CACQualities::BoundsCheck(CACQualities *this, unsigned int stype, int *val, unsigned int *max) .text:005920E0 ?BoundsCheck@CACQualities@@QAEHKAAJAAK@Z

        // CACQualities.CanJump:
        public int CanJump(Single extent) => ((delegate* unmanaged[Thiscall]<ref CACQualities, Single, int>)0x00592850)(ref this, extent); // .text:00591B50 ; int __thiscall CACQualities::CanJump(CACQualities *this, float extent) .text:00591B50 ?CanJump@CACQualities@@UBEHM@Z

        // CACQualities.Clear:
        public void Clear() => ((delegate* unmanaged[Thiscall]<ref CACQualities, void>)0x00593B10)(ref this); // .text:00592D10 ; void __thiscall CACQualities::Clear(CACQualities *this) .text:00592D10 ?Clear@CACQualities@@IAEXXZ

        // CACQualities.EnchantAttribute2nd:
        public int EnchantAttribute2nd(UInt32 stype, UInt32* val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, UInt32*, int>)0x0058FEC0)(ref this, stype, val); // .text:0058F090 ; int __thiscall CACQualities::EnchantAttribute2nd(CACQualities *this, unsigned int stype, unsigned int *val) .text:0058F090 ?EnchantAttribute2nd@CACQualities@@IBEHKAAK@Z

        // CACQualities.EnchantAttribute:
        public int EnchantAttribute(UInt32 stype, UInt32* val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, UInt32*, int>)0x0058FEA0)(ref this, stype, val); // .text:0058F070 ; int __thiscall CACQualities::EnchantAttribute(CACQualities *this, unsigned int stype, unsigned int *val) .text:0058F070 ?EnchantAttribute@CACQualities@@IBEHKAAK@Z

        // CACQualities.EnchantFloat:
        public int EnchantFloat(UInt32 stype, Double* val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, Double*, int>)0x0058FF20)(ref this, stype, val); // .text:0058F0F0 ; int __thiscall CACQualities::EnchantFloat(CACQualities *this, unsigned int stype, long double *val) .text:0058F0F0 ?EnchantFloat@CACQualities@@MBEHKAAN@Z

        // CACQualities.EnchantInt:
        public int EnchantInt(UInt32 stype, int* val, int allow_negative) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int*, int, int>)0x0058FF00)(ref this, stype, val, allow_negative); // .text:0058F0D0 ; int __thiscall CACQualities::EnchantInt(CACQualities *this, unsigned int stype, int *val, int allow_negative) .text:0058F0D0 ?EnchantInt@CACQualities@@MBEHKAAJH@Z

        // CACQualities.EnchantSkill:
        public int EnchantSkill(UInt32 stype, int* val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int*, int>)0x0058FEE0)(ref this, stype, val); // .text:0058F0B0 ; int __thiscall CACQualities::EnchantSkill(CACQualities *this, unsigned int stype, int *val) .text:0058F0B0 ?EnchantSkill@CACQualities@@IBEHKAAJ@Z

        // CACQualities.GetDBOType:
        public UInt32 GetDBOType() => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32>)0x00593EF0)(ref this); // .text:005930F0 ; unsigned int __thiscall CACQualities::GetDBOType(CACQualities *this) .text:005930F0 ?GetDBOType@CACQualities@@UBEKXZ

        // CACQualities.GetEnchantmentsInEffect:
        public int GetEnchantmentsInEffect(PackableList<Enchantment>* retval) => ((delegate* unmanaged[Thiscall]<ref CACQualities, PackableList<Enchantment>*, int>)0x0058FD80)(ref this, retval); // .text:0058EF50 ; int __thiscall CACQualities::GetEnchantmentsInEffect(CACQualities *this, PackableList<Enchantment> *retval) .text:0058EF50 ?GetEnchantmentsInEffect@CACQualities@@QBEHAAV?$PackableList@VEnchantment@@@@@Z

        // CACQualities.GetFloatEnchantmentDetails:
        public int GetFloatEnchantmentDetails(UInt32 stype, EnchantedQualityDetails* val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, EnchantedQualityDetails*, int>)0x0058FF40)(ref this, stype, val); // .text:0058F110 ; int __thiscall CACQualities::GetFloatEnchantmentDetails(CACQualities *this, unsigned int stype, EnchantedQualityDetails *val) .text:0058F110 ?GetFloatEnchantmentDetails@CACQualities@@MBEHKAAUEnchantedQualityDetails@@@Z

        // CACQualities.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32>)0x00593CC0)(ref this); // .text:00592EC0 ; unsigned int __thiscall CACQualities::GetPackSize(CACQualities *this) .text:00592EC0 ?GetPackSize@CACQualities@@MAEIXZ

        // CACQualities.GetVitaeValue:
        public Single GetVitaeValue() => ((delegate* unmanaged[Thiscall]<ref CACQualities, Single>)0x0058FE80)(ref this); // .text:0058F050 ; float __thiscall CACQualities::GetVitaeValue(CACQualities *this) .text:0058F050 ?GetVitaeValue@CACQualities@@QBEMXZ

        // CACQualities.HasEnchantmentRegistry:
        public int HasEnchantmentRegistry() => ((delegate* unmanaged[Thiscall]<ref CACQualities, int>)0x0058FD30)(ref this); // .text:0058EF00 ; int __thiscall CACQualities::HasEnchantmentRegistry(CACQualities *this) .text:0058EF00 ?HasEnchantmentRegistry@CACQualities@@QBEHXZ

        // CACQualities.HasSpellBook:
        public int HasSpellBook() => ((delegate* unmanaged[Thiscall]<ref CACQualities, int>)0x0058FCE0)(ref this); // .text:0058EEB0 ; int __thiscall CACQualities::HasSpellBook(CACQualities *this) .text:0058EEB0 ?HasSpellBook@CACQualities@@QBEHXZ

        // CACQualities.InqAttribute2nd:
        public int InqAttribute2nd(UInt32 stype, UInt32* retval, int raw) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, UInt32*, int, int>)0x00592D20)(ref this, stype, retval, raw); // .text:00592020 ; int __thiscall CACQualities::InqAttribute2nd(CACQualities *this, unsigned int stype, unsigned int *retval, int raw) .text:00592020 ?InqAttribute2nd@CACQualities@@QBEHKAAKH@Z

        // CACQualities.InqAttribute2nd:
        public int InqAttribute2nd(UInt32 stype, SecondaryAttribute* retval) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, SecondaryAttribute*, int>)0x005927F0)(ref this, stype, retval); // .text:00591AF0 ; int __thiscall CACQualities::InqAttribute2nd(CACQualities *this, unsigned int stype, SecondaryAttribute *retval) .text:00591AF0 ?InqAttribute2nd@CACQualities@@QBEHKAAVSecondaryAttribute@@@Z

        // CACQualities.InqAttribute2ndBaseLevel:
        public int InqAttribute2ndBaseLevel(UInt32 stype, UInt32* retval, int raw) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, UInt32*, int, int>)0x00592A20)(ref this, stype, retval, raw); // .text:00591D20 ; int __thiscall CACQualities::InqAttribute2ndBaseLevel(CACQualities *this, unsigned int stype, unsigned int *retval, int raw) .text:00591D20 ?InqAttribute2ndBaseLevel@CACQualities@@QBEHKAAKH@Z

        // CACQualities.InqAttribute:
        public int InqAttribute(UInt32 stype, UInt32* retval, int raw) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, UInt32*, int, int>)0x00592700)(ref this, stype, retval, raw); // .text:00591A00 ; int __thiscall CACQualities::InqAttribute(CACQualities *this, unsigned int stype, unsigned int *retval, int raw) .text:00591A00 ?InqAttribute@CACQualities@@QBEHKAAKH@Z

        // CACQualities.InqAttribute:
        public int InqAttribute(UInt32 stype, Attribute* retval) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, Attribute*, int>)0x005926D0)(ref this, stype, retval); // .text:005919D0 ; int __thiscall CACQualities::InqAttribute(CACQualities *this, unsigned int stype, Attribute *retval) .text:005919D0 ?InqAttribute@CACQualities@@QBEHKAAVAttribute@@@Z

        // CACQualities.InqJumpVelocity:
        public int InqJumpVelocity(Single extent, Single* v_z) => ((delegate* unmanaged[Thiscall]<ref CACQualities, Single, Single*, int>)0x00593740)(ref this, extent, v_z); // .text:00592980 ; int __thiscall CACQualities::InqJumpVelocity(CACQualities *this, float extent, float *v_z) .text:00592980 ?InqJumpVelocity@CACQualities@@UBEHMAAM@Z

        // CACQualities.InqLoad:
        public int InqLoad(Single* load) => ((delegate* unmanaged[Thiscall]<ref CACQualities, Single*, int>)0x0058FF60)(ref this, load); // .text:0058F130 ; int __thiscall CACQualities::InqLoad(CACQualities *this, float *load) .text:0058F130 ?InqLoad@CACQualities@@QBEHAAM@Z

        // CACQualities.InqMaxRunRate:
        public int InqMaxRunRate(Single* rate) => ((delegate* unmanaged[Thiscall]<ref CACQualities, Single*, int>)0x00592820)(ref this, rate); // .text:00591B20 ; int __thiscall CACQualities::InqMaxRunRate(CACQualities *this, float *rate) .text:00591B20 ?InqMaxRunRate@CACQualities@@UBEHAAM@Z

        // CACQualities.InqPluralNameString:
        public int InqPluralNameString(AC1Legacy.PStringBase<char>* pluralName) => ((delegate* unmanaged[Thiscall]<ref CACQualities, AC1Legacy.PStringBase<char>*, int>)0x00590680)(ref this, pluralName); // .text:0058F850 ; int __thiscall CACQualities::InqPluralNameString(CACQualities *this, AC1Legacy::PStringBase<char> *pluralName) .text:0058F850 ?InqPluralNameString@CACQualities@@UAEHAAV?$PStringBase@D@AC1Legacy@@@Z

        // CACQualities.InqRunRate:
        public int InqRunRate(Single* rate) => ((delegate* unmanaged[Thiscall]<ref CACQualities, Single*, int>)0x00593570)(ref this, rate); // .text:00592800 ; int __thiscall CACQualities::InqRunRate(CACQualities *this, float *rate) .text:00592800 ?InqRunRate@CACQualities@@UBEHAAM@Z

        // CACQualities.InqSkill:
        public int InqSkill(UInt32 stype, int* retval, int raw) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int*, int, int>)0x00593380)(ref this, stype, retval, raw); // .text:00592660 ; int __thiscall CACQualities::InqSkill(CACQualities *this, unsigned int stype, int *retval, int raw) .text:00592660 ?InqSkill@CACQualities@@QBEHKAAJH@Z

        // CACQualities.InqSkill:
        public int InqSkill(UInt32 stype, Skill* retval) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, Skill*, int>)0x00592AF0)(ref this, stype, retval); // .text:00591DF0 ; int __thiscall CACQualities::InqSkill(CACQualities *this, unsigned int stype, Skill *retval) .text:00591DF0 ?InqSkill@CACQualities@@QBEHKAAVSkill@@@Z

        // CACQualities.InqSkillAdvancementClass:
        public int InqSkillAdvancementClass(UInt32 stype, SKILL_ADVANCEMENT_CLASS* retval) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, SKILL_ADVANCEMENT_CLASS*, int>)0x00592B70)(ref this, stype, retval); // .text:00591E70 ; int __thiscall CACQualities::InqSkillAdvancementClass(CACQualities *this, unsigned int stype, SKILL_ADVANCEMENT_CLASS *retval) .text:00591E70 ?InqSkillAdvancementClass@CACQualities@@QBEHKAAW4SKILL_ADVANCEMENT_CLASS@@@Z

        // CACQualities.InqSkillBaseLevel:
        public int InqSkillBaseLevel(UInt32 stype, int* retval, int raw) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int*, int, int>)0x00592E60)(ref this, stype, retval, raw); // .text:00592140 ; int __thiscall CACQualities::InqSkillBaseLevel(CACQualities *this, unsigned int stype, int *retval, int raw) .text:00592140 ?InqSkillBaseLevel@CACQualities@@QBEHKAAJH@Z

        // CACQualities.InqSkillLevel:
        public int InqSkillLevel(UInt32 stype, int* retval) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int*, int>)0x00592B40)(ref this, stype, retval); // .text:00591E40 ; int __thiscall CACQualities::InqSkillLevel(CACQualities *this, unsigned int stype, int *retval) .text:00591E40 ?InqSkillLevel@CACQualities@@QBEHKAAJ@Z

        // CACQualities.InqVitae:
        public int InqVitae(Enchantment* vitae) => ((delegate* unmanaged[Thiscall]<ref CACQualities, Enchantment*, int>)0x0058FE60)(ref this, vitae); // .text:0058F030 ; int __thiscall CACQualities::InqVitae(CACQualities *this, Enchantment *vitae) .text:0058F030 ?InqVitae@CACQualities@@QBEHAAVEnchantment@@@Z

        // CACQualities.InqWeenieTypeString:
        public int InqWeenieTypeString(char* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CACQualities, char*, UInt32, int>)0x00593C00)(ref this, buff, size); // .text:00592E00 ; int __thiscall CACQualities::InqWeenieTypeString(CACQualities *this, char *buff, const unsigned int size) .text:00592E00 ?InqWeenieTypeString@CACQualities@@MBEHPADI@Z

        // CACQualities.IsEnchanted:
        public int IsEnchanted(UInt32 spell) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int>)0x0058FD40)(ref this, spell); // .text:0058EF10 ; int __thiscall CACQualities::IsEnchanted(CACQualities *this, const unsigned int spell) .text:0058EF10 ?IsEnchanted@CACQualities@@QBEHK@Z

        // CACQualities.IsSpellKnown:
        public int IsSpellKnown(UInt32 spell) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int>)0x0058FCF0)(ref this, spell); // .text:0058EEC0 ; int __thiscall CACQualities::IsSpellKnown(CACQualities *this, const unsigned int spell) .text:0058EEC0 ?IsSpellKnown@CACQualities@@QBEHK@Z

        // CACQualities.JumpStaminaCost:
        public int JumpStaminaCost(Single extent, int* cost) => ((delegate* unmanaged[Thiscall]<ref CACQualities, Single, int*, int>)0x00592890)(ref this, extent, cost); // .text:00591B90 ; int __thiscall CACQualities::JumpStaminaCost(CACQualities *this, float extent, int *cost) .text:00591B90 ?JumpStaminaCost@CACQualities@@UBEHMAAJ@Z

        // CACQualities.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CACQualities, void**, UInt32, UInt32>)0x00594020)(ref this, addr, size); // .text:00593270 ; unsigned int __thiscall CACQualities::Pack(CACQualities *this, void **addr, unsigned int size) .text:00593270 ?Pack@CACQualities@@UAEIAAPAXI@Z

        // CACQualities.PurgeBadEnchantments:
        public int PurgeBadEnchantments() => ((delegate* unmanaged[Thiscall]<ref CACQualities, int>)0x0058FD70)(ref this); // .text:0058EF40 ; int __thiscall CACQualities::PurgeBadEnchantments(CACQualities *this) .text:0058EF40 ?PurgeBadEnchantments@CACQualities@@QAEHXZ

        // CACQualities.PurgeEnchantments:
        public int PurgeEnchantments() => ((delegate* unmanaged[Thiscall]<ref CACQualities, int>)0x0058FD60)(ref this); // .text:0058EF30 ; int __thiscall CACQualities::PurgeEnchantments(CACQualities *this) .text:0058EF30 ?PurgeEnchantments@CACQualities@@QAEHXZ

        // CACQualities.RemoveEnchantment:
        public int RemoveEnchantment(UInt32 eid) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int>)0x0058FDA0)(ref this, eid); // .text:0058EF70 ; int __thiscall CACQualities::RemoveEnchantment(CACQualities *this, const unsigned int eid) .text:0058EF70 ?RemoveEnchantment@CACQualities@@QAEHK@Z

        // CACQualities.RemoveEnchantments:
        public int RemoveEnchantments(PackableList<UInt32>* to_remove) => ((delegate* unmanaged[Thiscall]<ref CACQualities, PackableList<UInt32>*, int>)0x0058FDC0)(ref this, to_remove); // .text:0058EF90 ; int __thiscall CACQualities::RemoveEnchantments(CACQualities *this, PackableList<unsigned long> *to_remove) .text:0058EF90 ?RemoveEnchantments@CACQualities@@QAEHAAV?$PackableList@K@@@Z

        // CACQualities.RemoveSpell:
        public int RemoveSpell(UInt32 spell) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, int>)0x005900B0)(ref this, spell); // .text:0058F280 ; int __thiscall CACQualities::RemoveSpell(CACQualities *this, const unsigned int spell) .text:0058F280 ?RemoveSpell@CACQualities@@QAEHK@Z

        // CACQualities.SetAttribute2nd:
        public int SetAttribute2nd(UInt32 stype, SecondaryAttribute* val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, SecondaryAttribute*, int>)0x00593250)(ref this, stype, val); // .text:00592530 ; int __thiscall CACQualities::SetAttribute2nd(CACQualities *this, unsigned int stype, SecondaryAttribute *val) .text:00592530 ?SetAttribute2nd@CACQualities@@QAEHKABVSecondaryAttribute@@@Z

        // CACQualities.SetAttribute2nd:
        public int SetAttribute2nd(UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, UInt32, int>)0x00593AF0)(ref this, stype, val); // .text:00592CF0 ; int __thiscall CACQualities::SetAttribute2nd(CACQualities *this, unsigned int stype, unsigned int val) .text:00592CF0 ?SetAttribute2nd@CACQualities@@QAEHKK@Z

        // CACQualities.SetAttribute2nd:
        public int SetAttribute2nd(UInt32 stype, UInt32 val, UInt32* bounded_val, UInt32* max) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, UInt32, UInt32*, UInt32*, int>)0x00593310)(ref this, stype, val, bounded_val, max); // .text:005925F0 ; int __thiscall CACQualities::SetAttribute2nd(CACQualities *this, unsigned int stype, unsigned int val, unsigned int *bounded_val, unsigned int *max) .text:005925F0 ?SetAttribute2nd@CACQualities@@QAEHKKAAK0@Z

        // CACQualities.SetAttribute:
        public int SetAttribute(UInt32 stype, Attribute* val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, Attribute*, int>)0x00592750)(ref this, stype, val); // .text:00591A50 ; int __thiscall CACQualities::SetAttribute(CACQualities *this, unsigned int stype, Attribute *val) .text:00591A50 ?SetAttribute@CACQualities@@QAEHKABVAttribute@@@Z

        // CACQualities.SetAttribute:
        public int SetAttribute(UInt32 stype, UInt32 init_val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, UInt32, int>)0x005927A0)(ref this, stype, init_val); // .text:00591AA0 ; int __thiscall CACQualities::SetAttribute(CACQualities *this, unsigned int stype, unsigned int init_val) .text:00591AA0 ?SetAttribute@CACQualities@@QAEHKK@Z

        // CACQualities.SetPackHeader:
        public void SetPackHeader(UInt32* bitfield) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32*, void>)0x00593C20)(ref this, bitfield); // .text:00592E20 ; void __thiscall CACQualities::SetPackHeader(CACQualities *this, unsigned int *bitfield) .text:00592E20 ?SetPackHeader@CACQualities@@AAEXAAK@Z

        // CACQualities.SetSkill:
        public int SetSkill(UInt32 stype, Skill* val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, Skill*, int>)0x00592F60)(ref this, stype, val); // .text:00592240 ; int __thiscall CACQualities::SetSkill(CACQualities *this, unsigned int stype, Skill *val) .text:00592240 ?SetSkill@CACQualities@@QAEHKABVSkill@@@Z

        // CACQualities.SetSkillAdvancementClass:
        public int SetSkillAdvancementClass(UInt32 stype, SKILL_ADVANCEMENT_CLASS val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, SKILL_ADVANCEMENT_CLASS, int>)0x00593150)(ref this, stype, val); // .text:00592430 ; int __thiscall CACQualities::SetSkillAdvancementClass(CACQualities *this, unsigned int stype, SKILL_ADVANCEMENT_CLASS val) .text:00592430 ?SetSkillAdvancementClass@CACQualities@@QAEHKW4SKILL_ADVANCEMENT_CLASS@@@Z

        // CACQualities.SetSkillLevel:
        public int SetSkillLevel(UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref CACQualities, UInt32, UInt32, int>)0x00593060)(ref this, stype, val); // .text:00592340 ; int __thiscall CACQualities::SetSkillLevel(CACQualities *this, unsigned int stype, unsigned int val) .text:00592340 ?SetSkillLevel@CACQualities@@QAEHKK@Z

        // CACQualities.TranscribeSpells:
        public int TranscribeSpells(PackableList<UInt32>* list) => ((delegate* unmanaged[Thiscall]<ref CACQualities, PackableList<UInt32>*, int>)0x0058FD10)(ref this, list); // .text:0058EEE0 ; int __thiscall CACQualities::TranscribeSpells(CACQualities *this, PackableList<unsigned long> *list) .text:0058EEE0 ?TranscribeSpells@CACQualities@@QBEHAAV?$PackableList@K@@@Z

        // CACQualities.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CACQualities, void**, UInt32, int>)0x005941D0)(ref this, addr, size); // .text:00593420 ; int __thiscall CACQualities::UnPack(CACQualities *this, void **addr, unsigned int size) .text:00593420 ?UnPack@CACQualities@@UAEHAAPAXI@Z

        // CACQualities.UpdateEnchantment:
        public int UpdateEnchantment(Enchantment* to_update) => ((delegate* unmanaged[Thiscall]<ref CACQualities, Enchantment*, int>)0x0058FDE0)(ref this, to_update); // .text:0058EFB0 ; int __thiscall CACQualities::UpdateEnchantment(CACQualities *this, Enchantment *to_update) .text:0058EFB0 ?UpdateEnchantment@CACQualities@@QAEHABVEnchantment@@@Z

        // CACQualities.UpdateEnchantments:
        public int UpdateEnchantments(PackableList<Enchantment>* to_update_list) => ((delegate* unmanaged[Thiscall]<ref CACQualities, PackableList<Enchantment>*, int>)0x0058FE20)(ref this, to_update_list); // .text:0058EFF0 ; int __thiscall CACQualities::UpdateEnchantments(CACQualities *this, PackableList<Enchantment> *to_update_list) .text:0058EFF0 ?UpdateEnchantments@CACQualities@@QAEHAAV?$PackableList@VEnchantment@@@@@Z
    }


    public unsafe struct CSequence {
        // Struct:
        public PackObj a0;
        public DLList<AnimSequenceNode> anim_list;
        public AnimSequenceNode* first_cyclic;
        public AC1Legacy.Vector3 velocity;
        public AC1Legacy.Vector3 omega;
        public CPhysicsObj* hook_obj;
        public Double frame_number;
        public AnimSequenceNode* curr_anim;
        public AnimFrame* placement_frame;
        public UInt32 placement_frame_id;
        public int bIsTrivial;
        public override string ToString() => $"a0(PackObj):{a0}, anim_list(DLList<AnimSequenceNode>):{anim_list}, first_cyclic:->(AnimSequenceNode*)0x{(int)first_cyclic:X8}, velocity(AC1Legacy.Vector3):{velocity}, omega(AC1Legacy.Vector3):{omega}, hook_obj:->(CPhysicsObj*)0x{(int)hook_obj:X8}, frame_number:{frame_number:n5}, curr_anim:->(AnimSequenceNode*)0x{(int)curr_anim:X8}, placement_frame:->(AnimFrame*)0x{(int)placement_frame:X8}, placement_frame_id:{placement_frame_id:X8}, bIsTrivial(int):{bIsTrivial}";

        // Functions:

        // CSequence.update_internal:
        public void update_internal(Double quantum, AnimSequenceNode** _curr_anim, Double* _frame_number, Frame* retval) => ((delegate* unmanaged[Thiscall]<ref CSequence, Double, AnimSequenceNode**, Double*, Frame*, void>)0x005261D0)(ref this, quantum, _curr_anim, _frame_number, retval); // .text:005255D0 ; void __thiscall CSequence::update_internal(CSequence *this, long double quantum, AnimSequenceNode **_curr_anim, long double *_frame_number, Frame *retval) .text:005255D0 ?update_internal@CSequence@@IBEXNAAPAVAnimSequenceNode@@AANPAVFrame@@@Z

        // CSequence.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CSequence, void**, UInt32, int>)0x005265D0)(ref this, addr, size); // .text:005259D0 ; int __thiscall CSequence::UnPack(CSequence *this, void **addr, unsigned int size) .text:005259D0 ?UnPack@CSequence@@UAEHAAPAXI@Z

        // CSequence.set_velocity:
        public void set_velocity(AC1Legacy.Vector3* v) => ((delegate* unmanaged[Thiscall]<ref CSequence, AC1Legacy.Vector3*, void>)0x00525480)(ref this, v); // .text:00524880 ; void __thiscall CSequence::set_velocity(CSequence *this, AC1Legacy::Vector3 *v) .text:00524880 ?set_velocity@CSequence@@QAEXABVVector3@AC1Legacy@@@Z

        // CSequence.remove_link_animations:
        public void remove_link_animations(UInt32 n) => ((delegate* unmanaged[Thiscall]<ref CSequence, UInt32, void>)0x005257E0)(ref this, n); // .text:00524BE0 ; void __thiscall CSequence::remove_link_animations(CSequence *this, unsigned int n) .text:00524BE0 ?remove_link_animations@CSequence@@QAEXI@Z

        // CSequence.clear_animations:
        public void clear_animations() => ((delegate* unmanaged[Thiscall]<ref CSequence, void>)0x005259C0)(ref this); // .text:00524DC0 ; void __thiscall CSequence::clear_animations(CSequence *this) .text:00524DC0 ?clear_animations@CSequence@@QAEXXZ

        // CSequence.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CSequence, void**, UInt32, UInt32>)0x00525C20)(ref this, addr, size); // .text:00525020 ; unsigned int __thiscall CSequence::Pack(CSequence *this, void **addr, unsigned int size) .text:00525020 ?Pack@CSequence@@UAEIAAPAXI@Z

        // CSequence.`scalar deleting destructor':
        // (ERR) .text:00525E90 ; int __thiscall CSequence::`scalar deleting destructor'(void *, char) .text:00525E90 ??_GCSequence@@UAEPAXI@Z

        // CSequence.subtract_physics:
        public void subtract_physics(AC1Legacy.Vector3* v, AC1Legacy.Vector3* o) => ((delegate* unmanaged[Thiscall]<ref CSequence, AC1Legacy.Vector3*, AC1Legacy.Vector3*, void>)0x00525500)(ref this, v, o); // .text:00524900 ; void __thiscall CSequence::subtract_physics(CSequence *this, AC1Legacy::Vector3 *v, AC1Legacy::Vector3 *o) .text:00524900 ?subtract_physics@CSequence@@QAEXABVVector3@AC1Legacy@@0@Z

        // CSequence.remove_cyclic_anims:
        public void remove_cyclic_anims() => ((delegate* unmanaged[Thiscall]<ref CSequence, void>)0x00525A40)(ref this); // .text:00524E40 ; void __thiscall CSequence::remove_cyclic_anims(CSequence *this) .text:00524E40 ?remove_cyclic_anims@CSequence@@QAEXXZ

        // CSequence.pack_size:
        public UInt32 pack_size(UInt32* bitfield, UInt32* num_anims) => ((delegate* unmanaged[Thiscall]<ref CSequence, UInt32*, UInt32*, UInt32>)0x00525B20)(ref this, bitfield, num_anims); // .text:00524F20 ; unsigned int __thiscall CSequence::pack_size(CSequence *this, unsigned int *bitfield, unsigned int *num_anims) .text:00524F20 ?pack_size@CSequence@@QAEIAAKAAI@Z

        // CSequence.remove_all_link_animations:
        public void remove_all_link_animations() => ((delegate* unmanaged[Thiscall]<ref CSequence, void>)0x005258A0)(ref this); // .text:00524CA0 ; void __thiscall CSequence::remove_all_link_animations(CSequence *this) .text:00524CA0 ?remove_all_link_animations@CSequence@@QAEXXZ

        // CSequence.get_curr_frame_number:
        // public UInt32 get_curr_frame_number() => ((delegate* unmanaged[Thiscall]<ref CSequence, UInt32>)0xDEADBEEF)(ref this); // .text:005249D0 ; unsigned int __thiscall CSequence::get_curr_frame_number(CSequence *this) .text:005249D0 ?get_curr_frame_number@CSequence@@QBEIXZ

        // CSequence.apply_physics:
        public void apply_physics(Frame* frame, Double quantum, Double sign) => ((delegate* unmanaged[Thiscall]<ref CSequence, Frame*, Double, Double, void>)0x005256B0)(ref this, frame, quantum, sign); // .text:00524AB0 ; void __thiscall CSequence::apply_physics(CSequence *this, Frame *frame, long double quantum, long double sign) .text:00524AB0 ?apply_physics@CSequence@@IBEXPAVFrame@@NN@Z

        // CSequence.append_animation:
        public void append_animation(AnimData* new_data) => ((delegate* unmanaged[Thiscall]<ref CSequence, AnimData*, void>)0x00526110)(ref this, new_data); // .text:00525510 ; void __thiscall CSequence::append_animation(CSequence *this, AnimData *new_data) .text:00525510 ?append_animation@CSequence@@QAEXABVAnimData@@@Z

        // CSequence.set_placement_frame:
        public void set_placement_frame(AnimFrame* _placement_frame, UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref CSequence, AnimFrame*, UInt32, void>)0x005255B0)(ref this, _placement_frame, _id); // .text:005249B0 ; void __thiscall CSequence::set_placement_frame(CSequence *this, AnimFrame *_placement_frame, unsigned int _id) .text:005249B0 ?set_placement_frame@CSequence@@QAEXPBVAnimFrame@@I@Z

        // CSequence.set_omega:
        public void set_omega(AC1Legacy.Vector3* o) => ((delegate* unmanaged[Thiscall]<ref CSequence, AC1Legacy.Vector3*, void>)0x005254A0)(ref this, o); // .text:005248A0 ; void __thiscall CSequence::set_omega(CSequence *this, AC1Legacy::Vector3 *o) .text:005248A0 ?set_omega@CSequence@@QAEXABVVector3@AC1Legacy@@@Z

        // CSequence.multiply_cyclic_animation_fr:
        public void multiply_cyclic_animation_fr(Single multiplier) => ((delegate* unmanaged[Thiscall]<ref CSequence, Single, void>)0x00525540)(ref this, multiplier); // .text:00524940 ; void __thiscall CSequence::multiply_cyclic_animation_fr(CSequence *this, float multiplier) .text:00524940 ?multiply_cyclic_animation_fr@CSequence@@QAEXM@Z

        // CSequence.clear_physics:
        public void clear_physics() => ((delegate* unmanaged[Thiscall]<ref CSequence, void>)0x00525950)(ref this); // .text:00524D50 ; void __thiscall CSequence::clear_physics(CSequence *this) .text:00524D50 ?clear_physics@CSequence@@QAEXXZ

        // CSequence.advance_to_next_animation:
        public void advance_to_next_animation(Double quantum, AnimSequenceNode** _curr_anim, Double* _frame_number, Frame* retval) => ((delegate* unmanaged[Thiscall]<ref CSequence, Double, AnimSequenceNode**, Double*, Frame*, void>)0x00525EB0)(ref this, quantum, _curr_anim, _frame_number, retval); // .text:005252B0 ; void __thiscall CSequence::advance_to_next_animation(CSequence *this, long double quantum, AnimSequenceNode **_curr_anim, long double *_frame_number, Frame *retval) .text:005252B0 ?advance_to_next_animation@CSequence@@IBEXNAAPBVAnimSequenceNode@@AANPAVFrame@@@Z

        // CSequence.clear:
        public void clear() => ((delegate* unmanaged[Thiscall]<ref CSequence, void>)0x005261B0)(ref this); // .text:005255B0 ; void __thiscall CSequence::clear(CSequence *this) .text:005255B0 ?clear@CSequence@@QAEXXZ

        // CSequence.execute_hooks:
        public void execute_hooks(AnimFrame* animframe, int dir) => ((delegate* unmanaged[Thiscall]<ref CSequence, AnimFrame*, int, void>)0x00525430)(ref this, animframe, dir); // .text:00524830 ; void __thiscall CSequence::execute_hooks(CSequence *this, AnimFrame *animframe, int dir) .text:00524830 ?execute_hooks@CSequence@@IBEXPBVAnimFrame@@H@Z

        // CSequence.~CSequence:
        // (ERR) .text:00525630 ; public: virtual __thiscall CSequence::~CSequence(void) .text:00525630 ??1CSequence@@UAE@XZ

        // CSequence.combine_physics:
        public void combine_physics(AC1Legacy.Vector3* v, AC1Legacy.Vector3* o) => ((delegate* unmanaged[Thiscall]<ref CSequence, AC1Legacy.Vector3*, AC1Legacy.Vector3*, void>)0x005254C0)(ref this, v, o); // .text:005248C0 ; void __thiscall CSequence::combine_physics(CSequence *this, AC1Legacy::Vector3 *v, AC1Legacy::Vector3 *o) .text:005248C0 ?combine_physics@CSequence@@QAEXABVVector3@AC1Legacy@@0@Z

        // CSequence.get_curr_animframe:
        public AnimFrame* get_curr_animframe() => ((delegate* unmanaged[Thiscall]<ref CSequence, AnimFrame*>)0x00525570)(ref this); // .text:00524970 ; AnimFrame *__thiscall CSequence::get_curr_animframe(CSequence *this) .text:00524970 ?get_curr_animframe@CSequence@@QBEPBVAnimFrame@@XZ

        // CSequence.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CSequence, void>)0x005255F0)(ref this); // .text:005249F0 ; void __thiscall CSequence::CSequence(CSequence *this) .text:005249F0 ??0CSequence@@QAE@XZ

        // CSequence.apricot:
        public void apricot() => ((delegate* unmanaged[Thiscall]<ref CSequence, void>)0x00525740)(ref this); // .text:00524B40 ; void __thiscall CSequence::apricot(CSequence *this) .text:00524B40 ?apricot@CSequence@@IAEXXZ

        // CSequence.has_anims:
        public int has_anims() => ((delegate* unmanaged[Thiscall]<ref CSequence, int>)0x005257D0)(ref this); // .text:00524BD0 ; int __thiscall CSequence::has_anims(CSequence *this) .text:00524BD0 ?has_anims@CSequence@@QBEHXZ

        // CSequence.update:
        public void update(Double quantum, Frame* retval) => ((delegate* unmanaged[Thiscall]<ref CSequence, Double, Frame*, void>)0x00526780)(ref this, quantum, retval); // .text:00525B80 ; void __thiscall CSequence::update(CSequence *this, long double quantum, Frame *retval) .text:00525B80 ?update@CSequence@@QAEXNPAVFrame@@@Z

        // CSequence.set_object:
        public void set_object(CPhysicsObj* _phys_obj) => ((delegate* unmanaged[Thiscall]<ref CSequence, CPhysicsObj*, void>)0x00525420)(ref this, _phys_obj); // .text:00524820 ; void __thiscall CSequence::set_object(CSequence *this, CPhysicsObj *_phys_obj) .text:00524820 ?set_object@CSequence@@QAEXPAVCPhysicsObj@@@Z
    }
    public unsafe struct CBaseQualities {
        // Struct:
        public CBaseQualities.Vtbl* vfptr;
        public UInt32 _weenie_type;
        public PackableHashTable<UInt32, UInt32>* _intStatsTable;
        public PackableHashTable<UInt32, Int64>* _int64StatsTable;
        public PackableHashTable<UInt32, bool>* _boolStatsTable;
        public PackableHashTable<UInt32, Double>* _floatStatsTable;
        public PackableHashTable<UInt32, AC1Legacy.PStringBase<char>>* _strStatsTable;
        public PackableHashTable<UInt32, UInt32>* _didStatsTable;
        public PackableHashTable<UInt32, UInt32>* _iidStatsTable;
        public PackableHashTable<UInt32, Position>* _posStatsTable;
        public override string ToString() => $"vfptr:->(CBaseQualities.Vtbl*)0x{(int)vfptr:X8}, _weenie_type:{_weenie_type:X8}, _intStatsTable:->(PackableHashTable<UInt32,UInt32>*)0x{(int)_intStatsTable:X8}, _int64StatsTable:->(PackableHashTable<UInt32,Int64>*)0x{(int)_int64StatsTable:X8}, _boolStatsTable:->(PackableHashTable<UInt32,int>*)0x{(int)_boolStatsTable:X8}, _floatStatsTable:->(PackableHashTable<UInt32,Double>*)0x{(int)_floatStatsTable:X8}, _strStatsTable:->(PackableHashTable<UInt32,AC1Legacy.PStringBase<char> >*)0x{(int)_strStatsTable:X8}, _didStatsTable:->(PackableHashTable<UInt32,UInt32 >*)0x{(int)_didStatsTable:X8}, _iidStatsTable:->(PackableHashTable<UInt32,UInt32>*)0x{(int)_iidStatsTable:X8}, _posStatsTable:->(PackableHashTable<UInt32,Position>*)0x{(int)_posStatsTable:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(CBaseQualities *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, UInt32, Double*, int> EnchantFloat; // int (__thiscall *EnchantFloat)(CBaseQualities *this, unsigned int, long double *) __declspec(align(8));
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, UInt32, EnchantedQualityDetails*, int> GetFloatEnchantmentDetails; // int (__thiscall *GetFloatEnchantmentDetails)(CBaseQualities *this, unsigned int, EnchantedQualityDetails *);
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, Single*, int> InqRunRate; // int (__thiscall *InqRunRate)(CBaseQualities *this, float *);
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, Single*, int> InqMaxRunRate; // int (__thiscall *InqMaxRunRate)(CBaseQualities *this, float *);
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, Single, Single*, int> InqJumpVelocity; // int (__thiscall *InqJumpVelocity)(CBaseQualities *this, float, float *);
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, Single, int> CanJump; // int (__thiscall *CanJump)(CBaseQualities *this, float);
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, Single, int*, int> JumpStaminaCost; // int (__thiscall *JumpStaminaCost)(CBaseQualities *this, float, int *);
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, void**, UInt32, UInt32> Pack; // unsigned int (__thiscall *Pack)(CBaseQualities *this, void **, unsigned int);
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, void**, UInt32, int> UnPack; // int (__thiscall *UnPack)(CBaseQualities *this, void **, unsigned int);
            public static delegate* unmanaged[Thiscall]<CBaseQualities*, char*, UInt32, int> InqWeenieTypeString; // int (__thiscall *InqWeenieTypeString)(CBaseQualities *this, char *, unsigned int);
        }


        public UInt32 Get(STypeInt stype) {
            var ret = _intStatsTable->lookup((UInt32)stype);
            if (ret == null) return 0;
            return ret->_data;
        }
        public Int64 Get(STypeInt64 stype) {
            var ret = _int64StatsTable->lookup((UInt32)stype);
            if (ret == null) return 0;
            return ret->_data;
        }
        public bool Get(STypeBool stype) {
            var ret = _boolStatsTable->lookup((UInt32)stype);
            if (ret == null) return false;
            return ret->_data;
        }
        public Double Get(STypeFloat stype) {
            var ret = _floatStatsTable->lookup((UInt32)stype);
            if (ret == null) return 0;
            return ret->_data;
        }
        public AC1Legacy.PStringBase<char> Get(STypeString stype) {
            var ret = _strStatsTable->lookup((UInt32)stype);
            if (ret == null) return new AC1Legacy.PStringBase<char>();
            return ret->_data;
        }
        public UInt32 Get(STypeDID stype) {
            var ret = _didStatsTable->lookup((UInt32)stype);
            if (ret == null) return 0;
            return ret->_data;
        }
        public UInt32 Get(STypeIID stype) {
            var ret = _iidStatsTable->lookup((UInt32)stype);
            if (ret == null) return 0;
            return ret->_data;
        }
        public Position Get(STypePosition stype) {
            var ret = _posStatsTable->lookup((UInt32)stype);
            if (ret == null) return new Position();
            return ret->_data;
        }

        // Functions:

        // CBaseQualities.InqInt64:
        public int InqInt64(UInt32 stype, Int64* retval) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, Int64*, int>)0x00590C70)(ref this, stype, retval); // .text:0058FE40 ; int __thiscall CBaseQualities::InqInt64(CBaseQualities *this, unsigned int stype, __int64 *retval) .text:0058FE40 ?InqInt64@CBaseQualities@@QBEHKAA_J@Z

        // CBaseQualities.RemoveBool:
        public int RemoveBool(UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int>)0x00591610)(ref this, stype); // .text:00590910 ; int __thiscall CBaseQualities::RemoveBool(CBaseQualities *this, unsigned int stype) .text:00590910 ?RemoveBool@CBaseQualities@@QAEHK@Z

        // CBaseQualities.RemoveFloat:
        public int RemoveFloat(UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int>)0x00591710)(ref this, stype); // .text:00590A10 ; int __thiscall CBaseQualities::RemoveFloat(CBaseQualities *this, unsigned int stype) .text:00590A10 ?RemoveFloat@CBaseQualities@@QAEHK@Z

        // CBaseQualities.SetFloat:
        public int SetFloat(UInt32 stype, Double val) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, Double, int>)0x00591740)(ref this, stype, val); // .text:00590A40 ; int __thiscall CBaseQualities::SetFloat(CBaseQualities *this, unsigned int stype, const long double val) .text:00590A40 ?SetFloat@CBaseQualities@@QAEHKN@Z

        // CBaseQualities.InqFloat:
        public int InqFloat(UInt32 stype, Double* retval, int raw) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, Double*, int, int>)0x00590CD0)(ref this, stype, retval, raw); // .text:0058FEA0 ; int __thiscall CBaseQualities::InqFloat(CBaseQualities *this, unsigned int stype, long double *retval, int raw) .text:0058FEA0 ?InqFloat@CBaseQualities@@QBEHKAANH@Z

        // CBaseQualities.SetInt:
        public int SetInt(UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int, int>)0x00591430)(ref this, stype, val); // .text:00590730 ; int __thiscall CBaseQualities::SetInt(CBaseQualities *this, unsigned int stype, const int val) .text:00590730 ?SetInt@CBaseQualities@@QAEHKJ@Z

        // CBaseQualities.Clear:
        // public void Clear() => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, void>)0xDEADBEEF)(ref this); // .text:00595C40 ; void __thiscall CBaseQualities::Clear(CBaseQualities *this) .text:00595C40 ?Clear@CBaseQualities@@IAEXXZ

        // CBaseQualities.UnPack:
        // public int UnPack(void** addr, UInt32 left) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, left); // .text:00595F10 ; int __thiscall CBaseQualities::UnPack(CBaseQualities *this, void **addr, unsigned int left) .text:00595F10 ?UnPack@CBaseQualities@@UAEHAAPAXI@Z

        // CBaseQualities.RemoveInt64:
        public int RemoveInt64(UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int>)0x00591500)(ref this, stype); // .text:00590800 ; int __thiscall CBaseQualities::RemoveInt64(CBaseQualities *this, unsigned int stype) .text:00590800 ?RemoveInt64@CBaseQualities@@QAEHK@Z

        // CBaseQualities.SetDataID:
        public int SetDataID(UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, UInt32, int>)0x00591820)(ref this, stype, val); // .text:00590B20 ; int __thiscall CBaseQualities::SetDataID(CBaseQualities *this, unsigned int stype, IDClass<_tagDataID,32,0> val) .text:00590B20 ?SetDataID@CBaseQualities@@QAEHKV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CBaseQualities.SetInstanceID:
        public int SetInstanceID(UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, UInt32, int>)0x00591920)(ref this, stype, val); // .text:00590C20 ; int __thiscall CBaseQualities::SetInstanceID(CBaseQualities *this, unsigned int stype, const unsigned int val) .text:00590C20 ?SetInstanceID@CBaseQualities@@QAEHKK@Z

        // CBaseQualities.SetString:
        public int SetString(UInt32 stype, AC1Legacy.PStringBase<char>* val) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, AC1Legacy.PStringBase<char>*, int>)0x00591CC0)(ref this, stype, val); // .text:00590FC0 ; int __thiscall CBaseQualities::SetString(CBaseQualities *this, unsigned int stype, AC1Legacy::PStringBase<char> *val) .text:00590FC0 ?SetString@CBaseQualities@@QAEHKABV?$PStringBase@D@AC1Legacy@@@Z

        // CBaseQualities.RemoveDataID:
        public int RemoveDataID(UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int>)0x00592220)(ref this, stype); // .text:00591520 ; int __thiscall CBaseQualities::RemoveDataID(CBaseQualities *this, unsigned int stype) .text:00591520 ?RemoveDataID@CBaseQualities@@QAEHK@Z

        // CBaseQualities.InqDataID:
        public int InqDataID(UInt32 stype, UInt32* retval) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, UInt32*, int>)0x00590D20)(ref this, stype, retval); // .text:0058FEF0 ; int __thiscall CBaseQualities::InqDataID(CBaseQualities *this, unsigned int stype, IDClass<_tagDataID,32,0> *retval) .text:0058FEF0 ?InqDataID@CBaseQualities@@QBEHKAAV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CBaseQualities.RemoveInstanceID:
        // public int RemoveInstanceID(UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int>)0xDEADBEEF)(ref this, stype); // .text:00590BF0 ; int __thiscall CBaseQualities::RemoveInstanceID(CBaseQualities *this, unsigned int stype) .text:00590BF0 ?RemoveInstanceID@CBaseQualities@@QAEHK@Z

        // CBaseQualities.InqInt:
        public int InqInt(UInt32 stype, int* retval, int raw, int allow_negative) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int*, int, int, int>)0x00590C20)(ref this, stype, retval, raw, allow_negative); // .text:0058FDF0 ; int __thiscall CBaseQualities::InqInt(CBaseQualities *this, unsigned int stype, int *retval, int raw, int allow_negative) .text:0058FDF0 ?InqInt@CBaseQualities@@QBEHKAAJHH@Z

        // CBaseQualities.InqBool:
        public int InqBool(UInt32 stype, int* retval) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int*, int>)0x00590CA0)(ref this, stype, retval); // .text:0058FE70 ; int __thiscall CBaseQualities::InqBool(CBaseQualities *this, unsigned int stype, int *retval) .text:0058FE70 ?InqBool@CBaseQualities@@QBEHKAAH@Z

        // CBaseQualities.RemoveInt:
        public int RemoveInt(UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int>)0x00591400)(ref this, stype); // .text:00590700 ; int __thiscall CBaseQualities::RemoveInt(CBaseQualities *this, unsigned int stype) .text:00590700 ?RemoveInt@CBaseQualities@@QAEHK@Z

        // CBaseQualities.SetPosition:
        public int SetPosition(UInt32 stype, Position* val) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, Position*, int>)0x00591DA0)(ref this, stype, val); // .text:005910A0 ; int __thiscall CBaseQualities::SetPosition(CBaseQualities *this, unsigned int stype, Position *val) .text:005910A0 ?SetPosition@CBaseQualities@@QAEHKABVPosition@@@Z

        // CBaseQualities.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:00595E40 ; unsigned int __thiscall CBaseQualities::Pack(CBaseQualities *this, void **addr, unsigned int size) .text:00595E40 ?Pack@CBaseQualities@@UAEIAAPAXI@Z

        // CBaseQualities.InqInstanceID:
        public int InqInstanceID(UInt32 stype, UInt32* retval) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, UInt32*, int>)0x00590D50)(ref this, stype, retval); // .text:0058FF20 ; int __thiscall CBaseQualities::InqInstanceID(CBaseQualities *this, unsigned int stype, unsigned int *retval) .text:0058FF20 ?InqInstanceID@CBaseQualities@@QBEHKAAK@Z

        // CBaseQualities.SetBool:
        public int SetBool(UInt32 stype, int val) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int, int>)0x00591640)(ref this, stype, val); // .text:00590940 ; int __thiscall CBaseQualities::SetBool(CBaseQualities *this, unsigned int stype, const int val) .text:00590940 ?SetBool@CBaseQualities@@QAEHKH@Z

        // CBaseQualities.RemovePosition:
        public int RemovePosition(UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int>)0x00592250)(ref this, stype); // .text:00591550 ; int __thiscall CBaseQualities::RemovePosition(CBaseQualities *this, unsigned int stype) .text:00591550 ?RemovePosition@CBaseQualities@@QAEHK@Z

        // CBaseQualities.InqPosition:
        public int InqPosition(UInt32 stype, Position* retval) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, Position*, int>)0x00590D80)(ref this, stype, retval); // .text:0058FF50 ; int __thiscall CBaseQualities::InqPosition(CBaseQualities *this, unsigned int stype, Position *retval) .text:0058FF50 ?InqPosition@CBaseQualities@@QBEHKAAVPosition@@@Z

        // CBaseQualities.InqString:
        public int InqString(UInt32 stype, AC1Legacy.PStringBase<char>* retval) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, AC1Legacy.PStringBase<char>*, int>)0x005919F0)(ref this, stype, retval); // .text:00590CF0 ; int __thiscall CBaseQualities::InqString(CBaseQualities *this, unsigned int stype, AC1Legacy::PStringBase<char> *retval) .text:00590CF0 ?InqString@CBaseQualities@@QBEHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // CBaseQualities.RemoveString:
        public int RemoveString(UInt32 stype) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, int>)0x005925F0)(ref this, stype); // .text:005918F0 ; int __thiscall CBaseQualities::RemoveString(CBaseQualities *this, unsigned int stype) .text:005918F0 ?RemoveString@CBaseQualities@@QAEHK@Z

        // CBaseQualities.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32>)0x00596C30)(ref this); // .text:00595D30 ; unsigned int __thiscall CBaseQualities::GetPackSize(CBaseQualities *this) .text:00595D30 ?GetPackSize@CBaseQualities@@IAEIXZ

        // CBaseQualities.__Ctor:
        // public void __Ctor(UInt32 wcid) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, void>)0xDEADBEEF)(ref this, wcid); // .text:00595E00 ; void __thiscall CBaseQualities::CBaseQualities(CBaseQualities *this, IDClass<_tagDataID,32,0> wcid) .text:00595E00 ??0CBaseQualities@@QAE@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CBaseQualities.SetInt64:
        public int SetInt64(UInt32 stype, Int64 val) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32, Int64, int>)0x00591530)(ref this, stype, val); // .text:00590830 ; int __thiscall CBaseQualities::SetInt64(CBaseQualities *this, unsigned int stype, const __int64 val) .text:00590830 ?SetInt64@CBaseQualities@@QAEHK_J@Z

        // CBaseQualities.SetPackHeader:
        // public void SetPackHeader(UInt32* bitfield) => ((delegate* unmanaged[Thiscall]<ref CBaseQualities, UInt32*, void>)0xDEADBEEF)(ref this, bitfield); // .text:00595CD0 ; void __thiscall CBaseQualities::SetPackHeader(CBaseQualities *this, unsigned int *bitfield) .text:00595CD0 ?SetPackHeader@CBaseQualities@@AAEXAAK@Z
    }
    public unsafe struct CBaseQualitiesVtbl {
    }
    public unsafe struct EnchantedQualityDetails {
        // Struct:
        public Double rRawValue;
        public Double rValueIncreasingMultiplier;
        public Double rValueDecreasingMultiplier;
        public Double rValueIncreasingAdditive;
        public Double rValueDecreasingAdditive;
        public override string ToString() => $"rRawValue:{rRawValue:n5}, rValueIncreasingMultiplier:{rValueIncreasingMultiplier:n5}, rValueDecreasingMultiplier:{rValueDecreasingMultiplier:n5}, rValueIncreasingAdditive:{rValueIncreasingAdditive:n5}, rValueDecreasingAdditive:{rValueDecreasingAdditive:n5}";
    }
    public unsafe struct Attribute {
        // Struct:
        public PackObj a0;
        public UInt32 _level_from_cp;
        public UInt32 _init_level;
        public UInt32 _cp_spent;
        public override string ToString() => $"a0(PackObj):{a0}, _level_from_cp:{_level_from_cp:X8}, _init_level:{_init_level:X8}, _cp_spent:{_cp_spent:X8}";

        // Functions:

        // Attribute.__Ctor:
        public void __Ctor(Attribute* __that) => ((delegate* unmanaged[Thiscall]<ref Attribute, Attribute*, void>)0x00558430)(ref this, __that); // .text:005577F0 ; void __thiscall Attribute::Attribute(Attribute *this, Attribute *__that) .text:005577F0 ??0Attribute@@QAE@ABV0@@Z

        // Attribute.LevelFromExperience:
        public UInt32 LevelFromExperience(UInt32 xp) => ((delegate* unmanaged[Thiscall]<ref Attribute, UInt32, UInt32>)0x005CBB00)(ref this, xp); // .text:005CAB90 ; unsigned int __thiscall Attribute::LevelFromExperience(Attribute *this, unsigned int xp) .text:005CAB90 ?LevelFromExperience@Attribute@@UBEKK@Z

        // Attribute.ExperienceToLevel:
        public UInt32 ExperienceToLevel(UInt32 level) => ((delegate* unmanaged[Thiscall]<ref Attribute, UInt32, UInt32>)0x005CBB10)(ref this, level); // .text:005CABA0 ; unsigned int __thiscall Attribute::ExperienceToLevel(Attribute *this, unsigned int level) .text:005CABA0 ?ExperienceToLevel@Attribute@@UBEKK@Z

        // Attribute.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Attribute, void**, UInt32, int>)0x005CBB20)(ref this, addr, size); // .text:005CABF0 ; int __thiscall Attribute::UnPack(Attribute *this, void **addr, unsigned int size) .text:005CABF0 ?UnPack@Attribute@@UAEHAAPAXI@Z
    }
    public unsafe struct SecondaryAttribute {
        // Struct:
        public Attribute a0;
        public UInt32 _current_level;
        public override string ToString() => $"a0(Attribute):{a0}, _current_level:{_current_level:X8}";

        // Functions:

        // SecondaryAttribute.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SecondaryAttribute, void**, UInt32, int>)0x005CBBC0)(ref this, addr, size); // .text:005CAC90 ; int __thiscall SecondaryAttribute::UnPack(SecondaryAttribute *this, void **addr, unsigned int size) .text:005CAC90 ?UnPack@SecondaryAttribute@@UAEHAAPAXI@Z

        // SecondaryAttribute.__Ctor:
        public void __Ctor(SecondaryAttribute* __that) => ((delegate* unmanaged[Thiscall]<ref SecondaryAttribute, SecondaryAttribute*, void>)0x00558460)(ref this, __that); // .text:00557820 ; void __thiscall SecondaryAttribute::SecondaryAttribute(SecondaryAttribute *this, SecondaryAttribute *__that) .text:00557820 ??0SecondaryAttribute@@QAE@ABV0@@Z

        // SecondaryAttribute.LevelFromExperience:
        public UInt32 LevelFromExperience(UInt32 xp) => ((delegate* unmanaged[Thiscall]<ref SecondaryAttribute, UInt32, UInt32>)0x005CBB70)(ref this, xp); // .text:005CAC40 ; unsigned int __thiscall SecondaryAttribute::LevelFromExperience(SecondaryAttribute *this, unsigned int xp) .text:005CAC40 ?LevelFromExperience@SecondaryAttribute@@UBEKK@Z

        // SecondaryAttribute.ExperienceToLevel:
        public UInt32 ExperienceToLevel(UInt32 level) => ((delegate* unmanaged[Thiscall]<ref SecondaryAttribute, UInt32, UInt32>)0x005CBB80)(ref this, level); // .text:005CAC50 ; unsigned int __thiscall SecondaryAttribute::ExperienceToLevel(SecondaryAttribute *this, unsigned int level) .text:005CAC50 ?ExperienceToLevel@SecondaryAttribute@@UBEKK@Z

        // SecondaryAttribute.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SecondaryAttribute, void**, UInt32, UInt32>)0x005CBB90)(ref this, addr, size); // .text:005CAC60 ; unsigned int __thiscall SecondaryAttribute::Pack(SecondaryAttribute *this, void **addr, unsigned int size) .text:005CAC60 ?Pack@SecondaryAttribute@@UAEIAAPAXI@Z
    }
    public unsafe struct AttributeCache {
        // Struct:
        public PackObj a0;
        public Attribute* _strength;
        public Attribute* _endurance;
        public Attribute* _quickness;
        public Attribute* _coordination;
        public Attribute* _focus;
        public Attribute* _self;
        public SecondaryAttribute* _health;
        public SecondaryAttribute* _stamina;
        public SecondaryAttribute* _mana;
        public override string ToString() => $"a0(PackObj):{a0}, _strength:->(Attribute*)0x{(int)_strength:X8}, _endurance:->(Attribute*)0x{(int)_endurance:X8}, _quickness:->(Attribute*)0x{(int)_quickness:X8}, _coordination:->(Attribute*)0x{(int)_coordination:X8}, _focus:->(Attribute*)0x{(int)_focus:X8}, _self:->(Attribute*)0x{(int)_self:X8}, _health:->(SecondaryAttribute*)0x{(int)_health:X8}, _stamina:->(SecondaryAttribute*)0x{(int)_stamina:X8}, _mana:->(SecondaryAttribute*)0x{(int)_mana:X8}";

        // Functions:

        // AttributeCache.InqAttribute:
        public int InqAttribute(UInt32 stype, UInt32* retval) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, UInt32, UInt32*, int>)0x005CD430)(ref this, stype, retval); // .text:005CC4E0 ; int __thiscall AttributeCache::InqAttribute(AttributeCache *this, unsigned int stype, unsigned int *retval) .text:005CC4E0 ?InqAttribute@AttributeCache@@QBEHKAAK@Z

        // AttributeCache.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref AttributeCache, void>)0x005CD5F0)(ref this); // .text:005CC6A0 ; void __thiscall AttributeCache::AttributeCache(AttributeCache *this) .text:005CC6A0 ??0AttributeCache@@QAE@XZ

        // AttributeCache.InqAttribute:
        public int InqAttribute(UInt32 stype, Attribute* retval) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, UInt32, Attribute*, int>)0x005CD620)(ref this, stype, retval); // .text:005CC6D0 ; int __thiscall AttributeCache::InqAttribute(AttributeCache *this, unsigned int stype, Attribute *retval) .text:005CC6D0 ?InqAttribute@AttributeCache@@QBEHKAAVAttribute@@@Z

        // AttributeCache.SetAttribute:
        public int SetAttribute(UInt32 stype, Attribute* val) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, UInt32, Attribute*, int>)0x005CD690)(ref this, stype, val); // .text:005CC740 ; int __thiscall AttributeCache::SetAttribute(AttributeCache *this, unsigned int stype, Attribute *val) .text:005CC740 ?SetAttribute@AttributeCache@@QAEHKABVAttribute@@@Z

        // AttributeCache.InqAttribute2nd:
        public int InqAttribute2nd(UInt32 stype, SecondaryAttribute* retval) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, UInt32, SecondaryAttribute*, int>)0x005CDA20)(ref this, stype, retval); // .text:005CCAD0 ; int __thiscall AttributeCache::InqAttribute2nd(AttributeCache *this, unsigned int stype, SecondaryAttribute *retval) .text:005CCAD0 ?InqAttribute2nd@AttributeCache@@QBEHKAAVSecondaryAttribute@@@Z

        // AttributeCache.SetAttribute2nd:
        public int SetAttribute2nd(UInt32 stype, SecondaryAttribute* val) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, UInt32, SecondaryAttribute*, int>)0x005CDA90)(ref this, stype, val); // .text:005CCB40 ; int __thiscall AttributeCache::SetAttribute2nd(AttributeCache *this, unsigned int stype, SecondaryAttribute *val) .text:005CCB40 ?SetAttribute2nd@AttributeCache@@QAEHKABVSecondaryAttribute@@@Z

        // AttributeCache.SetAttribute2nd:
        public int SetAttribute2nd(UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, UInt32, UInt32, int>)0x005CDBA0)(ref this, stype, val); // .text:005CCC50 ; int __thiscall AttributeCache::SetAttribute2nd(AttributeCache *this, unsigned int stype, const unsigned int val) .text:005CCC50 ?SetAttribute2nd@AttributeCache@@QAEHKK@Z

        // AttributeCache.CleanUp:
        // public void CleanUp() => ((delegate* unmanaged[Thiscall]<ref AttributeCache, void>)0xDEADBEEF)(ref this); // .text:005CC440 ; void __thiscall AttributeCache::CleanUp(AttributeCache *this) .text:005CC440 ?CleanUp@AttributeCache@@IAEXXZ

        // AttributeCache.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005CCE20 ; unsigned int __thiscall AttributeCache::Pack(AttributeCache *this, void **addr, unsigned int size) .text:005CCE20 ?Pack@AttributeCache@@UAEIAAPAXI@Z

        // AttributeCache.SetAttribute:
        public int SetAttribute(UInt32 stype, UInt32 val) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, UInt32, UInt32, int>)0x005CD860)(ref this, stype, val); // .text:005CC910 ; int __thiscall AttributeCache::SetAttribute(AttributeCache *this, unsigned int stype, const unsigned int val) .text:005CC910 ?SetAttribute@AttributeCache@@QAEHKK@Z

        // AttributeCache.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005CCFB0 ; int __thiscall AttributeCache::UnPack(AttributeCache *this, void **addr, unsigned int size) .text:005CCFB0 ?UnPack@AttributeCache@@UAEHAAPAXI@Z

        // AttributeCache.InqAttribute2nd:
        public int InqAttribute2nd(UInt32 stype, UInt32* retval) => ((delegate* unmanaged[Thiscall]<ref AttributeCache, UInt32, UInt32*, int>)0x005CD520)(ref this, stype, retval); // .text:005CC5D0 ; int __thiscall AttributeCache::InqAttribute2nd(AttributeCache *this, unsigned int stype, unsigned int *retval) .text:005CC5D0 ?InqAttribute2nd@AttributeCache@@QBEHKAAK@Z
    }
    public unsafe struct Skill {
        // Struct:
        public PackObj a0;
        public SKILL_ADVANCEMENT_CLASS _sac;
        public UInt32 _pp;
        public UInt32 _init_level;
        public UInt32 _level_from_pp;
        public int _resistance_of_last_check;
        public Double _last_used_time;
        public override string ToString() => $"{_sac} pp:{_pp}, init:{_init_level}, from_pp:{_level_from_pp}, res:{_resistance_of_last_check}, last_time:{_last_used_time:n5}";

        // Functions:

        // Skill.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Skill, void>)0x0049B020)(ref this); // .text:0049ADB0 ; void __thiscall Skill::Skill(Skill *this) .text:0049ADB0 ??0Skill@@QAE@XZ

        // Skill.SetSkillAdvancementClass:
        public void SetSkillAdvancementClass(SKILL_ADVANCEMENT_CLASS sac) => ((delegate* unmanaged[Thiscall]<ref Skill, SKILL_ADVANCEMENT_CLASS, void>)0x005CB8B0)(ref this, sac); // .text:005CA940 ; void __thiscall Skill::SetSkillAdvancementClass(Skill *this, SKILL_ADVANCEMENT_CLASS sac) .text:005CA940 ?SetSkillAdvancementClass@Skill@@QAEXW4SKILL_ADVANCEMENT_CLASS@@@Z

        // Skill.AdjPP:
        // public int AdjPP(UInt32* amount) => ((delegate* unmanaged[Thiscall]<ref Skill, UInt32*, int>)0xDEADBEEF)(ref this, amount); // .text:005CA960 ; int __thiscall Skill::AdjPP(Skill *this, unsigned int *amount) .text:005CA960 ?AdjPP@Skill@@QAEHAAK@Z

        // Skill.SanityCheck:
        // public int SanityCheck() => ((delegate* unmanaged[Thiscall]<ref Skill, int>)0xDEADBEEF)(ref this); // .text:005CA9C0 ; int __thiscall Skill::SanityCheck(Skill *this) .text:005CA9C0 ?SanityCheck@Skill@@QAEHXZ

        // Skill.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Skill, void**, UInt32, UInt32>)0x005CB990)(ref this, addr, size); // .text:005CAA20 ; unsigned int __thiscall Skill::Pack(Skill *this, void **addr, unsigned int size) .text:005CAA20 ?Pack@Skill@@UAEIAAPAXI@Z

        // Skill.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Skill, void**, UInt32, int>)0x005CBA30)(ref this, addr, size); // .text:005CAAC0 ; int __thiscall Skill::UnPack(Skill *this, void **addr, unsigned int size) .text:005CAAC0 ?UnPack@Skill@@UAEHAAPAXI@Z
    }
    public unsafe struct BodyPart {
        // Struct:
        public PackObj a0;
        public DAMAGE_TYPE _dtype;
        public int _dval;
        public Single _dvar;
        public ArmorCache _acache;
        public BODY_HEIGHT _bh;
        public BodyPartSelectionData* _bpsd;
        public override string ToString() => $"a0(PackObj):{a0}, _dtype(DAMAGE_TYPE):{_dtype}, _dval(int):{_dval}, _dvar:{_dvar:n5}, _acache(ArmorCache):{_acache}, _bh(BODY_HEIGHT):{_bh}, _bpsd:->(BodyPartSelectionData*)0x{(int)_bpsd:X8}";

        // Functions:

        // BodyPart.~BodyPart:
        // (ERR) .text:005D2180 ; public: virtual __thiscall BodyPart::~BodyPart(void) .text:005D2180 ??1BodyPart@@UAE@XZ

        // BodyPart.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref BodyPart, void>)0x0058FFF0)(ref this); // .text:0058F1C0 ; void __thiscall BodyPart::BodyPart(BodyPart *this) .text:0058F1C0 ??0BodyPart@@QAE@XZ

        // BodyPart.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref BodyPart, UInt32>)0x005D20A0)(ref this); // .text:005D10A0 ; unsigned int __thiscall BodyPart::GetPackSize(BodyPart *this) .text:005D10A0 ?GetPackSize@BodyPart@@UAEIXZ

        // BodyPart.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref BodyPart, void**, UInt32, UInt32>)0x005D2210)(ref this, addr, size); // .text:005D1210 ; unsigned int __thiscall BodyPart::Pack(BodyPart *this, void **addr, unsigned int size) .text:005D1210 ?Pack@BodyPart@@UAEIAAPAXI@Z

        // BodyPart.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref BodyPart, void**, UInt32, int>)0x005D22A0)(ref this, addr, size); // .text:005D12A0 ; int __thiscall BodyPart::UnPack(BodyPart *this, void **addr, unsigned int size) .text:005D12A0 ?UnPack@BodyPart@@UAEHAAPAXI@Z

        // BodyPart.operator_equals:
        // public BodyPart* operator_equals(class BodyPart, const a1) => ((delegate* unmanaged[Thiscall]<ref BodyPart, class, const, BodyPart*>)0xDEADBEEF)(ref this, BodyPart, a1); // .text:005D13A0 ; public: class BodyPart & __thiscall BodyPart::operator=(class BodyPart const &) .text:005D13A0 ??4BodyPart@@QAEAAV0@ABV0@@Z

        // BodyPart.__Ctor:
        public void __Ctor(BodyPart* rhs) => ((delegate* unmanaged[Thiscall]<ref BodyPart, BodyPart*, void>)0x005D2460)(ref this, rhs); // .text:005D1460 ; void __thiscall BodyPart::BodyPart(BodyPart *this, BodyPart *rhs) .text:005D1460 ??0BodyPart@@QAE@ABV0@@Z

        // BodyPart.`vector deleting destructor':
        // (ERR) .text:00590030 ; int __thiscall BodyPart::`vector deleting destructor'(void *, char) .text:00590030 ??_EBodyPart@@UAEPAXI@Z
    }
    public unsafe struct ArmorCache {
        // Struct:
        public PackObj a0;
        public int _base_armor;
        public int _armor_vs_slash;
        public int _armor_vs_pierce;
        public int _armor_vs_bludgeon;
        public int _armor_vs_cold;
        public int _armor_vs_fire;
        public int _armor_vs_acid;
        public int _armor_vs_electric;
        public int _armor_vs_nether;
        public override string ToString() => $"a0(PackObj):{a0}, _base_armor(int):{_base_armor}, _armor_vs_slash(int):{_armor_vs_slash}, _armor_vs_pierce(int):{_armor_vs_pierce}, _armor_vs_bludgeon(int):{_armor_vs_bludgeon}, _armor_vs_cold(int):{_armor_vs_cold}, _armor_vs_fire(int):{_armor_vs_fire}, _armor_vs_acid(int):{_armor_vs_acid}, _armor_vs_electric(int):{_armor_vs_electric}, _armor_vs_nether(int):{_armor_vs_nether}";

        // Functions:

        // ArmorCache.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ArmorCache, void**, UInt32, UInt32>)0x005D24B0)(ref this, addr, size); // .text:005D14B0 ; unsigned int __thiscall ArmorCache::Pack(ArmorCache *this, void **addr, unsigned int size) .text:005D14B0 ?Pack@ArmorCache@@UAEIAAPAXI@Z

        // ArmorCache.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ArmorCache, void**, UInt32, int>)0x005D2540)(ref this, addr, size); // .text:005D1540 ; int __thiscall ArmorCache::UnPack(ArmorCache *this, void **addr, unsigned int size) .text:005D1540 ?UnPack@ArmorCache@@UAEHAAPAXI@Z
    }
    public unsafe struct BodyPartSelectionData {
        // Struct:
        public PackObj a0;
        public Single HLF;
        public Single MLF;
        public Single LLF;
        public Single HRF;
        public Single MRF;
        public Single LRF;
        public Single HLB;
        public Single MLB;
        public Single LLB;
        public Single HRB;
        public Single MRB;
        public Single LRB;
        public override string ToString() => $"a0(PackObj):{a0}, HLF:{HLF:n5}, MLF:{MLF:n5}, LLF:{LLF:n5}, HRF:{HRF:n5}, MRF:{MRF:n5}, LRF:{LRF:n5}, HLB:{HLB:n5}, MLB:{MLB:n5}, LLB:{LLB:n5}, HRB:{HRB:n5}, MRB:{MRB:n5}, LRB:{LRB:n5}";

        // Functions:

        // BodyPartSelectionData.GetPackSize:
        // public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref BodyPartSelectionData, UInt32>)0xDEADBEEF)(ref this); // .text:00421F50 ; unsigned int __thiscall BodyPartSelectionData::GetPackSize(BodyPartSelectionData *this) .text:00421F50 ?GetPackSize@BodyPartSelectionData@@UAEIXZ

        // BodyPartSelectionData.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref BodyPartSelectionData, void>)0xDEADBEEF)(ref this); // .text:005D10F0 ; void __thiscall BodyPartSelectionData::BodyPartSelectionData(BodyPartSelectionData *this) .text:005D10F0 ??0BodyPartSelectionData@@QAE@XZ

        // BodyPartSelectionData.__Ctor:
        // public void __Ctor(BodyPartSelectionData* __that) => ((delegate* unmanaged[Thiscall]<ref BodyPartSelectionData, BodyPartSelectionData*, void>)0xDEADBEEF)(ref this, __that); // .text:005D1120 ; void __thiscall BodyPartSelectionData::BodyPartSelectionData(BodyPartSelectionData *this, BodyPartSelectionData *__that) .text:005D1120 ??0BodyPartSelectionData@@QAE@ABV0@@Z

        // BodyPartSelectionData.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref BodyPartSelectionData, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005D15E0 ; unsigned int __thiscall BodyPartSelectionData::Pack(BodyPartSelectionData *this, void **addr, unsigned int size) .text:005D15E0 ?Pack@BodyPartSelectionData@@UAEIAAPAXI@Z

        // BodyPartSelectionData.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref BodyPartSelectionData, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005D1690 ; int __thiscall BodyPartSelectionData::UnPack(BodyPartSelectionData *this, void **addr, unsigned int size) .text:005D1690 ?UnPack@BodyPartSelectionData@@UAEHAAPAXI@Z
    }
    public unsafe struct ArmorProfile {
        // Struct:
        public PackObj a0;
        public Single mod_vs_slash;
        public Single mod_vs_pierce;
        public Single mod_vs_bludgeon;
        public Single mod_vs_cold;
        public Single mod_vs_fire;
        public Single mod_vs_acid;
        public Single mod_vs_electric;
        public Single mod_vs_nether;
        public override string ToString() => $"a0(PackObj):{a0}, mod_vs_slash:{mod_vs_slash:n5}, mod_vs_pierce:{mod_vs_pierce:n5}, mod_vs_bludgeon:{mod_vs_bludgeon:n5}, mod_vs_cold:{mod_vs_cold:n5}, mod_vs_fire:{mod_vs_fire:n5}, mod_vs_acid:{mod_vs_acid:n5}, mod_vs_electric:{mod_vs_electric:n5}, mod_vs_nether:{mod_vs_nether:n5}";

        // Functions:

        // ArmorProfile.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ArmorProfile, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005D0E40 ; int __thiscall ArmorProfile::UnPack(ArmorProfile *this, void **addr, unsigned int size) .text:005D0E40 ?UnPack@ArmorProfile@@UAEHAAPAXI@Z

        // ArmorProfile.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ArmorProfile, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005D0DC0 ; unsigned int __thiscall ArmorProfile::Pack(ArmorProfile *this, void **addr, unsigned int size) .text:005D0DC0 ?Pack@ArmorProfile@@UAEIAAPAXI@Z
    }
    public unsafe struct Body {
        // Struct:
        public PackObj a0;
        public PackableHashTable<UInt32, BodyPart> _body_part_table;
        public override string ToString() => $"a0(PackObj):{a0}, _body_part_table(PackableHashTable<UInt32,BodyPart>):{_body_part_table}";

        // Functions:

        // Body.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Body, void>)0x005905B0)(ref this); // .text:0058F780 ; void __thiscall Body::Body(Body *this) .text:0058F780 ??0Body@@QAE@XZ

        // Body.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Body, void**, UInt32, int>)0x005D2040)(ref this, addr, size); // .text:005CB130 ; int __thiscall Body::UnPack(Body *this, void **addr, unsigned int size) .text:005CB130 ?UnPack@Body@@UAEHAAPAXI@Z

        // Body.`scalar deleting destructor':
        // (ERR) .text:00590650 ; int __thiscall Body::`scalar deleting destructor'(void *, char) .text:00590650 ??_GBody@@UAEPAXI@Z
    }
    public unsafe struct StatMod {
        // Struct:
        public PackObj a0;
        public UInt32 type;
        public UInt32 key;
        public Single val;
        public override string ToString() => $"a0(PackObj):{a0}, type:{type:X8}, key:{key:X8}, val:{val:n5}";

        // Functions:

        // StatMod.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref StatMod, void**, UInt32, UInt32>)0x005BE160)(ref this, addr, size); // .text:005BD090 ; unsigned int __thiscall StatMod::Pack(StatMod *this, void **addr, unsigned int size) .text:005BD090 ?Pack@StatMod@@UAEIAAPAXI@Z

        // StatMod.UnPack:
        // public int UnPack(ShortCutData* this, void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref StatMod, ShortCutData*, void**, UInt32, int>)0xDEADBEEF)(ref this, this, addr, size); // .text:005D5620 ; int __thiscall StatMod::UnPack(ShortCutData *this, void **addr, unsigned int size) .text:005D5620 ?UnPack@StatMod@@UAEHAAPAXI@Z
    }
    public unsafe struct EventFilter {
        // Struct:
        public PackObj a0;
        public UInt32 num_events;
        public UInt32* event_filter;
        public override string ToString() => $"a0(PackObj):{a0}, num_events:{num_events:X8}, event_filter:->(UInt32*)0x{(int)event_filter:X8}";

        // Functions:

        // EventFilter.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref EventFilter, void>)0xDEADBEEF)(ref this); // .text:006B1D70 ; void __thiscall EventFilter::EventFilter(EventFilter *this) .text:006B1D70 ??0EventFilter@@QAE@XZ

        // EventFilter.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref EventFilter, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:006B1D90 ; unsigned int __thiscall EventFilter::Pack(EventFilter *this, void **addr, unsigned int size) .text:006B1D90 ?Pack@EventFilter@@UAEIAAPAXI@Z

        // EventFilter.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref EventFilter, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:006B1DE0 ; int __thiscall EventFilter::UnPack(EventFilter *this, void **addr, unsigned int size) .text:006B1DE0 ?UnPack@EventFilter@@UAEHAAPAXI@Z
    }
    public unsafe struct CreationProfile {
        // Struct:
        public PackObj a0;
        public UInt32 wcid;
        public int try_to_bond;
        public UInt32 palette;
        public Single shade; // union Single probability;
        public DestinationType destination; // union RegenerationType regen_algorithm;
        public Int32 amount; // union Int32 max_number; Int32 stack_size;
        public override string ToString() => $"a0(PackObj):{a0}, wcid:{wcid:X8}, try_to_bond(int):{try_to_bond}, palette:{palette:X8}, shade:{shade:n5}, destination:{destination}, amount:{amount}";

        // Functions:

        // CreationProfile.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CreationProfile, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005CC370 ; unsigned int __thiscall CreationProfile::Pack(CreationProfile *this, void **addr, unsigned int size) .text:005CC370 ?Pack@CreationProfile@@UAEIAAPAXI@Z

        // CreationProfile.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CreationProfile, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005CC3D0 ; int __thiscall CreationProfile::UnPack(CreationProfile *this, void **addr, unsigned int size) .text:005CC3D0 ?UnPack@CreationProfile@@UAEHAAPAXI@Z

        // CreationProfile.operator_equals:
        //public CreationProfile* operator_equals(class CreationProfile, const a1) => ((delegate* unmanaged[Thiscall]<ref CreationProfile, class, const, CreationProfile*>)0x005CD210)(ref this, CreationProfile, a1); // .text:005CC2C0 ; public: class CreationProfile & __thiscall CreationProfile::operator=(class CreationProfile const &) .text:005CC2C0 ??4CreationProfile@@QAEAAV0@ABV0@@Z

        // CreationProfile.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CreationProfile, void>)0x005CD250)(ref this); // .text:005CC300 ; void __thiscall CreationProfile::CreationProfile(CreationProfile *this) .text:005CC300 ??0CreationProfile@@QAE@XZ

        // CreationProfile.__Ctor:
        public void __Ctor(CreationProfile* rhs) => ((delegate* unmanaged[Thiscall]<ref CreationProfile, CreationProfile*, void>)0x005CD280)(ref this, rhs); // .text:005CC330 ; void __thiscall CreationProfile::CreationProfile(CreationProfile *this, CreationProfile *rhs) .text:005CC330 ??0CreationProfile@@QAE@ABV0@@Z
    }
    public unsafe struct Emote {
        // Struct:
        public PackObj a0;
        public UInt32 type;
        public Single delay;
        public Single extent;
        public UInt32 amount;
        public UInt64 amount64;
        public UInt64 heroxp64;
        public UInt64 min64;
        public UInt64 max64;
        public UInt32 min;
        public UInt32 max;
        public Double fmin;
        public Double fmax;
        public UInt32 stat;
        public UInt32 motion;
        public PScriptType pscript;
        public SoundType sound;
        public CreationProfile cprof;
        public Frame frame;
        public UInt32 spellid;
        public AC1Legacy.PStringBase<char> teststring;
        public AC1Legacy.PStringBase<char> msg;
        public Double percent;
        public int display;
        public UInt32 wealth_rating;
        public UInt32 treasure_class;
        public int treasure_type;
        public Position mPosition;
        public override string ToString() => $"a0(PackObj):{a0}, type:{type:X8}, delay:{delay:n5}, extent:{extent:n5}, amount:{amount:X8}, amount64(UInt64):{amount64}, heroxp64(UInt64):{heroxp64}, min64(UInt64):{min64}, max64(UInt64):{max64}, min:{min:X8}, max:{max:X8}, fmin:{fmin:n5}, fmax:{fmax:n5}, stat:{stat:X8}, motion:{motion:X8}, pscript(PScriptType):{pscript}, sound(SoundType):{sound}, cprof(CreationProfile):{cprof}, frame(Frame):{frame}, spellid:{spellid:X8}, teststring:{teststring}, msg:{msg}, percent:{percent:n5}, display(int):{display}, wealth_rating:{wealth_rating:X8}, treasure_class:{treasure_class:X8}, treasure_type(int):{treasure_type}, mPosition(Position):{mPosition}";

        // Functions:

        // Emote.operator_equals:
        // public Emote* operator_equals(class Emote, const a1) => ((delegate* unmanaged[Thiscall]<ref Emote, class, const, Emote*>)0xDEADBEEF)(ref this, Emote, a1); // .text:005CDF30 ; public: class Emote & __thiscall Emote::operator=(class Emote const &) .text:005CDF30 ??4Emote@@QAEAAV0@ABV0@@Z

        // Emote.pack_size:
        // public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref Emote, UInt32>)0xDEADBEEF)(ref this); // .text:005CE0E0 ; unsigned int __thiscall Emote::pack_size(Emote *this) .text:005CE0E0 ?pack_size@Emote@@QAEIXZ

        // Emote.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Emote, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005CE380 ; unsigned int __thiscall Emote::Pack(Emote *this, void **addr, unsigned int size) .text:005CE380 ?Pack@Emote@@UAEIAAPAXI@Z

        // Emote.__Ctor:
        // public void __Ctor(Emote* rhs) => ((delegate* unmanaged[Thiscall]<ref Emote, Emote*, void>)0xDEADBEEF)(ref this, rhs); // .text:005CE8C0 ; void __thiscall Emote::Emote(Emote *this, Emote *rhs) .text:005CE8C0 ??0Emote@@QAE@ABV0@@Z

        // Emote.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Emote, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005CE970 ; int __thiscall Emote::UnPack(Emote *this, void **addr, unsigned int size) .text:005CE970 ?UnPack@Emote@@UAEHAAPAXI@Z

        // Emote.IsValid:
        // public int IsValid() => ((delegate* unmanaged[Thiscall]<ref Emote, int>)0xDEADBEEF)(ref this); // .text:005CDA00 ; int __thiscall Emote::IsValid(Emote *this) .text:005CDA00 ?IsValid@Emote@@QBEHXZ

        // Emote.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Emote, void>)0xDEADBEEF)(ref this); // .text:005CDDA0 ; void __thiscall Emote::Emote(Emote *this) .text:005CDDA0 ??0Emote@@QAE@XZ
    }
    public unsafe struct EmoteSet {
        // Struct:
        public PackObj a0;
        public UInt32 category;
        public Single probability;
        public UInt32 classID;
        public AC1Legacy.PStringBase<char> quest;
        public UInt32 style;
        public UInt32 substyle;
        public UInt32 vendorType;
        public Single minhealth;
        public Single maxhealth;
        public PackableList<Emote> emotes;
        public override string ToString() => $"a0(PackObj):{a0}, category:{category:X8}, probability:{probability:n5}, classID:{classID:X8}, quest:{quest}, style:{style:X8}, substyle:{substyle:X8}, vendorType:{vendorType:X8}, minhealth:{minhealth:n5}, maxhealth:{maxhealth:n5}, emotes(PackableList<Emote>):{emotes}";

        // Functions:

        // EmoteSet.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref EmoteSet, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005964A0 ; unsigned int __thiscall EmoteSet::Pack(EmoteSet *this, void **addr, unsigned int size) .text:005964A0 ?Pack@EmoteSet@@UAEIAAPAXI@Z

        // EmoteSet.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref EmoteSet, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:00596620 ; int __thiscall EmoteSet::UnPack(EmoteSet *this, void **addr, unsigned int size) .text:00596620 ?UnPack@EmoteSet@@UAEHAAPAXI@Z

        // EmoteSet.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref EmoteSet, void>)0xDEADBEEF)(ref this); // .text:00596850 ; void __thiscall EmoteSet::EmoteSet(EmoteSet *this) .text:00596850 ??0EmoteSet@@QAE@XZ

        // EmoteSet.operator_equals:
        // public EmoteSet* operator_equals(class EmoteSet, const a1) => ((delegate* unmanaged[Thiscall]<ref EmoteSet, class, const, EmoteSet*>)0xDEADBEEF)(ref this, EmoteSet, a1); // .text:00596910 ; public: class EmoteSet & __thiscall EmoteSet::operator=(class EmoteSet const &) .text:00596910 ??4EmoteSet@@QAEAAV0@ABV0@@Z

        // EmoteSet.__Ctor:
        public void __Ctor(EmoteSet* rhs) => ((delegate* unmanaged[Thiscall]<ref EmoteSet, EmoteSet*, void>)0x00597900)(ref this, rhs); // .text:00596A00 ; void __thiscall EmoteSet::EmoteSet(EmoteSet *this, EmoteSet *rhs) .text:00596A00 ??0EmoteSet@@QAE@ABV0@@Z

        // EmoteSet.pack_size:
        // public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref EmoteSet, UInt32>)0xDEADBEEF)(ref this); // .text:00596400 ; unsigned int __thiscall EmoteSet::pack_size(EmoteSet *this) .text:00596400 ?pack_size@EmoteSet@@QAEIXZ
    }
    public unsafe struct CEmoteTable {
        // Struct:
        public PackObj a0;
        public PackableHashTable<UInt32, PackableList<EmoteSet>> _emote_table;
        public override string ToString() => $"a0(PackObj):{a0}, _emote_table(PackableHashTable<UInt32,PackableList<EmoteSet> >):{_emote_table}";

        // Functions:

        // CEmoteTable.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CEmoteTable, void**, UInt32, int>)0x00595C90)(ref this, addr, size); // .text:00594E20 ; int __thiscall CEmoteTable::UnPack(CEmoteTable *this, void **addr, unsigned int size) .text:00594E20 ?UnPack@CEmoteTable@@UAEHAAPAXI@Z

        // CEmoteTable.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CEmoteTable, void>)0xDEADBEEF)(ref this); // .text:00595410 ; void __thiscall CEmoteTable::CEmoteTable(CEmoteTable *this) .text:00595410 ??0CEmoteTable@@QAE@XZ
    }
    public unsafe struct PageData {
        // Struct:
        public PackObj a0;
        public UInt32 authorID;
        public AC1Legacy.PStringBase<char> authorName;
        public AC1Legacy.PStringBase<char> authorAccount;
        public int textIncluded;
        public int ignoreAuthor;
        public AC1Legacy.PStringBase<char> pageText;
        public PageData* prev;
        public PageData* next;
        public override string ToString() => $"a0(PackObj):{a0}, authorID:{authorID:X8}, authorName:{authorName}, authorAccount:{authorAccount}, textIncluded(int):{textIncluded}, ignoreAuthor(int):{ignoreAuthor}, pageText:{pageText}, prev:->(PageData*)0x{(int)prev:X8}, next:->(PageData*)0x{(int)next:X8}";

        // Functions:

        // PageData.SetPageText:
        // public void SetPageText(AC1Legacy.PStringBase<char>* _pageText) => ((delegate* unmanaged[Thiscall]<ref PageData, AC1Legacy.PStringBase<char>*, void>)0xDEADBEEF)(ref this, _pageText); // .text:004BACF0 ; void __thiscall PageData::SetPageText(PageData *this, AC1Legacy::PStringBase<char> *_pageText) .text:004BACF0 ?SetPageText@PageData@@QAEXABV?$PStringBase@D@AC1Legacy@@@Z

        // PageData.__Ctor:
        // public void __Ctor(PageData* _pd, int _includeText) => ((delegate* unmanaged[Thiscall]<ref PageData, PageData*, int, void>)0xDEADBEEF)(ref this, _pd, _includeText); // .text:005D22B0 ; void __thiscall PageData::PageData(PageData *this, PageData *_pd, int _includeText) .text:005D22B0 ??0PageData@@QAE@AAV0@H@Z

        // PageData.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PageData, void**, UInt32, UInt32>)0x005D3380)(ref this, addr, size); // .text:005D2380 ; unsigned int __thiscall PageData::Pack(PageData *this, void **addr, unsigned int size) .text:005D2380 ?Pack@PageData@@UAEIAAPAXI@Z

        // PageData.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PageData, void**, UInt32, int>)0x005D3460)(ref this, addr, size); // .text:005D2460 ; int __thiscall PageData::UnPack(PageData *this, void **addr, unsigned int size) .text:005D2460 ?UnPack@PageData@@UAEHAAPAXI@Z

        // PageData.PackNoText:
        // public UInt32 PackNoText(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PageData, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005D2510 ; unsigned int __thiscall PageData::PackNoText(PageData *this, void **addr, unsigned int size) .text:005D2510 ?PackNoText@PageData@@QAEIAAPAXI@Z

        // PageData.~PageData:
        // (ERR) .text:0055B180 ; public: virtual __thiscall PageData::~PageData(void) .text:0055B180 ??1PageData@@UAE@XZ

        // PageData.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref PageData, void>)0x005D2FC0)(ref this); // .text:005D1FC0 ; void __thiscall PageData::PageData(PageData *this) .text:005D1FC0 ??0PageData@@QAE@XZ

        // PageData.__Ctor:
        // public void __Ctor(UInt32 _authorID, AC1Legacy.PStringBase<char>* _authorName, AC1Legacy.PStringBase<char>* _authorAccount, AC1Legacy.PStringBase<char>* _pageText, int _ignoreAuthor) => ((delegate* unmanaged[Thiscall]<ref PageData, UInt32, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*, int, void>)0xDEADBEEF)(ref this, _authorID, _authorName, _authorAccount, _pageText, _ignoreAuthor); // .text:005D2020 ; void __thiscall PageData::PageData(PageData *this, unsigned int _authorID, AC1Legacy::PStringBase<char> *_authorName, AC1Legacy::PStringBase<char> *_authorAccount, AC1Legacy::PStringBase<char> *_pageText, const int _ignoreAuthor) .text:005D2020 ??0PageData@@QAE@KABV?$PStringBase@D@AC1Legacy@@00H@Z

        // PageData.operator_equals:
        // public PageData* operator_equals(class PageData, const a1) => ((delegate* unmanaged[Thiscall]<ref PageData, class, const, PageData*>)0xDEADBEEF)(ref this, PageData, a1); // .text:005D21C0 ; public: class PageData & __thiscall PageData::operator=(class PageData const &) .text:005D21C0 ??4PageData@@QAEAAV0@ABV0@@Z

        // PageData.`scalar deleting destructor':
        // (ERR) .text:0055B1F0 ; int __thiscall PageData::`scalar deleting destructor'(void *, char) .text:0055B1F0 ??_GPageData@@UAEPAXI@Z
    }
    public unsafe struct PageDataList {
        // Struct:
        public PackObj a0;
        public PageData* first;
        public PageData* last;
        public int numPages;
        public int maxNumPages;
        public int maxNumCharsPerPage;
        public int packWithText;
        public override string ToString() => $"a0(PackObj):{a0}, first:->(PageData*)0x{(int)first:X8}, last:->(PageData*)0x{(int)last:X8}, numPages(int):{numPages}, maxNumPages(int):{maxNumPages}, maxNumCharsPerPage(int):{maxNumCharsPerPage}, packWithText(int):{packWithText}";

        // Functions:

        // PageDataList.Remove:
        // public PageData* Remove(int _pos) => ((delegate* unmanaged[Thiscall]<ref PageDataList, int, PageData*>)0xDEADBEEF)(ref this, _pos); // .text:005D1ED0 ; PageData *__thiscall PageDataList::Remove(PageDataList *this, int _pos) .text:005D1ED0 ?Remove@PageDataList@@QAEPAVPageData@@H@Z

        // PageDataList.Flush:
        // public void Flush() => ((delegate* unmanaged[Thiscall]<ref PageDataList, void>)0xDEADBEEF)(ref this); // .text:005D1F60 ; void __thiscall PageDataList::Flush(PageDataList *this) .text:005D1F60 ?Flush@PageDataList@@QAEXXZ

        // PageDataList.operator_equals:
        // public PageDataList* operator_equals(class PageDataList, const a1) => ((delegate* unmanaged[Thiscall]<ref PageDataList, class, const, PageDataList*>)0xDEADBEEF)(ref this, PageDataList, a1); // .text:005D25C0 ; public: class PageDataList & __thiscall PageDataList::operator=(class PageDataList const &) .text:005D25C0 ??4PageDataList@@QAEAAV0@ABV0@@Z

        // PageDataList.pack_size:
        // public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref PageDataList, UInt32>)0xDEADBEEF)(ref this); // .text:005D2640 ; unsigned int __thiscall PageDataList::pack_size(PageDataList *this) .text:005D2640 ?pack_size@PageDataList@@QAEIXZ

        // PageDataList.Get:
        // public PageData* Get(int _pos) => ((delegate* unmanaged[Thiscall]<ref PageDataList, int, PageData*>)0xDEADBEEF)(ref this, _pos); // .text:005D1DC0 ; PageData *__thiscall PageDataList::Get(PageDataList *this, int _pos) .text:005D1DC0 ?Get@PageDataList@@QAEPAVPageData@@H@Z

        // PageDataList.Insert:
        // public void Insert(PageData* _pd, int _pos) => ((delegate* unmanaged[Thiscall]<ref PageDataList, PageData*, int, void>)0xDEADBEEF)(ref this, _pd, _pos); // .text:005D1E20 ; void __thiscall PageDataList::Insert(PageDataList *this, PageData *_pd, int _pos) .text:005D1E20 ?Insert@PageDataList@@QAEXPAVPageData@@H@Z

        // PageDataList.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PageDataList, void**, UInt32, int>)0x005D30B0)(ref this, addr, size); // .text:005D20B0 ; int __thiscall PageDataList::UnPack(PageDataList *this, void **addr, unsigned int size) .text:005D20B0 ?UnPack@PageDataList@@UAEHAAPAXI@Z

        // PageDataList.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PageDataList, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005D26A0 ; unsigned int __thiscall PageDataList::Pack(PageDataList *this, void **addr, unsigned int size) .text:005D26A0 ?Pack@PageDataList@@UAEIAAPAXI@Z

        // PageDataList.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref PageDataList, void>)0x005D2DF0)(ref this); // .text:005D1DF0 ; void __thiscall PageDataList::PageDataList(PageDataList *this) .text:005D1DF0 ??0PageDataList@@QAE@XZ

        // PageDataList.Delete:
        // public void Delete(int _pos) => ((delegate* unmanaged[Thiscall]<ref PageDataList, int, void>)0xDEADBEEF)(ref this, _pos); // .text:005D1F40 ; void __thiscall PageDataList::Delete(PageDataList *this, int _pos) .text:005D1F40 ?Delete@PageDataList@@QAEXH@Z
    }
    public unsafe struct GeneratorProfile {
        // Struct:
        public PackObj a0;
        public Single probability;
        public UInt32 type;
        public Double delay;
        public int initCreate;
        public int maxNum;
        public RegenerationType whenCreate;
        public RegenLocationType whereCreate;
        public int stackSize;
        public UInt32 ptid;
        public Single shade;
        public Position pos_val;
        public UInt32 slot;
        public override string ToString() => $"a0(PackObj):{a0}, probability:{probability:n5}, type:{type:X8}, delay:{delay:n5}, initCreate(int):{initCreate}, maxNum(int):{maxNum}, whenCreate(RegenerationType):{whenCreate}, whereCreate(RegenLocationType):{whereCreate}, stackSize(int):{stackSize}, ptid:{ptid:X8}, shade:{shade:n5}, pos_val(Position):{pos_val}, slot:{slot:X8}";

        // Functions:

        // GeneratorProfile.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref GeneratorProfile, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005D0970 ; int __thiscall GeneratorProfile::UnPack(GeneratorProfile *this, void **addr, unsigned int size) .text:005D0970 ?UnPack@GeneratorProfile@@UAEHAAPAXI@Z

        // GeneratorProfile.operator_equals:
        // public GeneratorProfile* operator_equals(class GeneratorProfile, const a1) => ((delegate* unmanaged[Thiscall]<ref GeneratorProfile, class, const, GeneratorProfile*>)0xDEADBEEF)(ref this, GeneratorProfile, a1); // .text:005D0A50 ; public: class GeneratorProfile & __thiscall GeneratorProfile::operator=(class GeneratorProfile const &) .text:005D0A50 ??4GeneratorProfile@@QAEAAV0@ABV0@@Z

        // GeneratorProfile.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref GeneratorProfile, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005D0AC0 ; unsigned int __thiscall GeneratorProfile::Pack(GeneratorProfile *this, void **addr, unsigned int size) .text:005D0AC0 ?Pack@GeneratorProfile@@UAEIAAPAXI@Z

        // GeneratorProfile.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref GeneratorProfile, void>)0xDEADBEEF)(ref this); // .text:005D08F0 ; void __thiscall GeneratorProfile::GeneratorProfile(GeneratorProfile *this) .text:005D08F0 ??0GeneratorProfile@@QAE@XZ
    }
    public unsafe struct GeneratorTable {
        // Struct:
        public PackObj a0;
        public PackableList<GeneratorProfile> _profile_list;
        public override string ToString() => $"a0(PackObj):{a0}, _profile_list(PackableList<GeneratorProfile>):{_profile_list}";

        // Functions:

        // GeneratorTable.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref GeneratorTable, void>)0xDEADBEEF)(ref this); // .text:005D0360 ; void __thiscall GeneratorTable::GeneratorTable(GeneratorTable *this) .text:005D0360 ??0GeneratorTable@@QAE@XZ
    }
    public unsafe struct GeneratorRegistryNode {
        // Struct:
        public PackObj a0;
        public UInt32 m_wcidOrTtype;
        public Double ts;
        public int m_bTreasureType;
        public UInt32 slot;
        public int checkpointed;
        public int shop;
        public int amount;
        public override string ToString() => $"a0(PackObj):{a0}, m_wcidOrTtype:{m_wcidOrTtype:X8}, ts:{ts:n5}, m_bTreasureType(int):{m_bTreasureType}, slot:{slot:X8}, checkpointed(int):{checkpointed}, shop(int):{shop}, amount(int):{amount}";

        // Functions:

        // GeneratorRegistryNode.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref GeneratorRegistryNode, void>)0xDEADBEEF)(ref this); // .text:005D0B90 ; void __thiscall GeneratorRegistryNode::GeneratorRegistryNode(GeneratorRegistryNode *this) .text:005D0B90 ??0GeneratorRegistryNode@@QAE@XZ

        // GeneratorRegistryNode.__Ctor:
        // public void __Ctor(GeneratorRegistryNode* rhs) => ((delegate* unmanaged[Thiscall]<ref GeneratorRegistryNode, GeneratorRegistryNode*, void>)0xDEADBEEF)(ref this, rhs); // .text:005D0BC0 ; void __thiscall GeneratorRegistryNode::GeneratorRegistryNode(GeneratorRegistryNode *this, GeneratorRegistryNode *rhs) .text:005D0BC0 ??0GeneratorRegistryNode@@QAE@ABV0@@Z

        // GeneratorRegistryNode.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref GeneratorRegistryNode, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005D0C10 ; unsigned int __thiscall GeneratorRegistryNode::Pack(GeneratorRegistryNode *this, void **addr, unsigned int size) .text:005D0C10 ?Pack@GeneratorRegistryNode@@UAEIAAPAXI@Z

        // GeneratorRegistryNode.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref GeneratorRegistryNode, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005D0C80 ; int __thiscall GeneratorRegistryNode::UnPack(GeneratorRegistryNode *this, void **addr, unsigned int size) .text:005D0C80 ?UnPack@GeneratorRegistryNode@@UAEHAAPAXI@Z
    }
    public unsafe struct GeneratorRegistry {
        // Struct:
        public PackObj a0;
        public PackableHashTable<UInt32, GeneratorRegistryNode> _registry;
        public override string ToString() => $"a0(PackObj):{a0}, _registry(PackableHashTable<UInt32,GeneratorRegistryNode>):{_registry}";

        // Functions:

        // GeneratorRegistry.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref GeneratorRegistry, void>)0xDEADBEEF)(ref this); // .text:005D0630 ; void __thiscall GeneratorRegistry::GeneratorRegistry(GeneratorRegistry *this) .text:005D0630 ??0GeneratorRegistry@@QAE@XZ

        // GeneratorRegistry.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref GeneratorRegistry, void**, UInt32, UInt32>)0x005CC060)(ref this, addr, size); // .text:005D1060 ; unsigned int __thiscall GeneratorRegistry::Pack(Body *this, void **addr, unsigned int size) .text:005D1060 ?Pack@GeneratorRegistry@@UAEIAAPAXI@Z
    }
    public unsafe struct GeneratorQueueNode {
        // Struct:
        public PackObj a0;
        public UInt32 slot;
        public Double when;
        public override string ToString() => $"a0(PackObj):{a0}, slot:{slot:X8}, when:{when:n5}";

        // Functions:

        // GeneratorQueueNode.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref GeneratorQueueNode, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005D0D50 ; unsigned int __thiscall GeneratorQueueNode::Pack(GeneratorQueueNode *this, void **addr, unsigned int size) .text:005D0D50 ?Pack@GeneratorQueueNode@@UAEIAAPAXI@Z

        // GeneratorQueueNode.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref GeneratorQueueNode, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005D0D80 ; int __thiscall GeneratorQueueNode::UnPack(GeneratorQueueNode *this, void **addr, unsigned int size) .text:005D0D80 ?UnPack@GeneratorQueueNode@@UAEHAAPAXI@Z

        // GeneratorQueueNode.operator_equals:
        // public GeneratorQueueNode* operator_equals(class GeneratorQueueNode, const a1) => ((delegate* unmanaged[Thiscall]<ref GeneratorQueueNode, class, const, GeneratorQueueNode*>)0xDEADBEEF)(ref this, GeneratorQueueNode, a1); // .text:005B6490 ; public: class GeneratorQueueNode & __thiscall GeneratorQueueNode::operator=(class GeneratorQueueNode const &) .text:005B6490 ??4GeneratorQueueNode@@QAEAAV0@ABV0@@Z

        // GeneratorQueueNode.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref GeneratorQueueNode, void>)0xDEADBEEF)(ref this); // .text:005D0D00 ; void __thiscall GeneratorQueueNode::GeneratorQueueNode(GeneratorQueueNode *this) .text:005D0D00 ??0GeneratorQueueNode@@QAE@XZ

        // GeneratorQueueNode.__Ctor:
        // public void __Ctor(GeneratorQueueNode* rhs) => ((delegate* unmanaged[Thiscall]<ref GeneratorQueueNode, GeneratorQueueNode*, void>)0xDEADBEEF)(ref this, rhs); // .text:005D0D20 ; void __thiscall GeneratorQueueNode::GeneratorQueueNode(GeneratorQueueNode *this, GeneratorQueueNode *rhs) .text:005D0D20 ??0GeneratorQueueNode@@QAE@ABV0@@Z
    }
    public unsafe struct GeneratorQueue {
        // Struct:
        public PackObj a0;
        public PackableList<GeneratorQueueNode> _queue;
        public override string ToString() => $"a0(PackObj):{a0}, _queue(PackableList<GeneratorQueueNode>):{_queue}";

        // Functions:

        // GeneratorQueue.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref GeneratorQueue, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005D06C0 ; int __thiscall GeneratorQueue::UnPack(GeneratorQueue *this, void **addr, unsigned int size) .text:005D06C0 ?UnPack@GeneratorQueue@@UAEHAAPAXI@Z

        // GeneratorQueue.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref GeneratorQueue, void>)0xDEADBEEF)(ref this); // .text:005D0890 ; void __thiscall GeneratorQueue::GeneratorQueue(GeneratorQueue *this) .text:005D0890 ??0GeneratorQueue@@QAE@XZ
    }


    public unsafe struct ACWTimeStamper {
        // Struct:
        public WTimeStamper a0;
        public override string ToString() => $"a0(WTimeStamper):{a0}";

        // Functions:

        // ACWTimeStamper.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ACWTimeStamper, void>)0x005BE470)(ref this); // .text:005BD3A0 ; void __thiscall ACWTimeStamper::ACWTimeStamper(ACWTimeStamper *this) .text:005BD3A0 ??0ACWTimeStamper@@QAE@XZ

        // ACWTimeStamper.`scalar deleting destructor':
        // (ERR) .text:005BE490 ; int __thiscall ACWTimeStamper::`scalar deleting destructor'(void *, char) .text:005BE490 ??_GACWTimeStamper@@UAEPAXI@Z
    }
    public unsafe struct WTimeStamper {
        // Struct:
        public PackObj a0;
        public PHashTable<UInt32, Byte> _table;
        public char _house_ts;
        public override string ToString() => $"a0(PackObj):{a0}, _table(PHashTable<UInt32,Uchar>):{_table}, _house_ts(char):{_house_ts}";

        // Functions:

        // WTimeStamper.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref WTimeStamper, void**, UInt32, int>)0x006B3920)(ref this, addr, size); // .text:006B2A50 ; int __thiscall WTimeStamper::UnPack(WTimeStamper *this, void **addr, unsigned int size) .text:006B2A50 ?UnPack@WTimeStamper@@UAEHAAPAXI@Z

        // WTimeStamper.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref WTimeStamper, void>)0x006B3C10)(ref this); // .text:006B2CD0 ; void __thiscall WTimeStamper::WTimeStamper(WTimeStamper *this) .text:006B2CD0 ??0WTimeStamper@@QAE@XZ

        // WTimeStamper.UpdateTS:
        public int UpdateTS(UInt32 key, char new_ts) => ((delegate* unmanaged[Thiscall]<ref WTimeStamper, UInt32, char, int>)0x006B3CB0)(ref this, key, new_ts); // .text:006B2D70 ; int __thiscall WTimeStamper::UpdateTS(WTimeStamper *this, unsigned int key, char new_ts) .text:006B2D70 ?UpdateTS@WTimeStamper@@IAEHKE@Z

        // WTimeStamper.~WTimeStamper:
        // (ERR) .text:006B3B90 ; public: virtual __thiscall WTimeStamper::~WTimeStamper(void) .text:006B3B90 ??1WTimeStamper@@UAE@XZ

        // WTimeStamper.`scalar deleting destructor':
        // (ERR) .text:006B3BF0 ; int __thiscall WTimeStamper::`scalar deleting destructor'(void *, char) .text:006B3BF0 ??_GWTimeStamper@@UAEPAXI@Z

        // WTimeStamper.UpdateHouseRestrictionTS:
        public int UpdateHouseRestrictionTS(char ts) => ((delegate* unmanaged[Thiscall]<ref WTimeStamper, char, int>)0x006B3860)(ref this, ts); // .text:006B2990 ; int __thiscall WTimeStamper::UpdateHouseRestrictionTS(WTimeStamper *this, char ts) .text:006B2990 ?UpdateHouseRestrictionTS@WTimeStamper@@QAEHE@Z

        // WTimeStamper.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref WTimeStamper, UInt32>)0x006B38A0)(ref this); // .text:006B29D0 ; unsigned int __thiscall WTimeStamper::GetPackSize(WTimeStamper *this) .text:006B29D0 ?GetPackSize@WTimeStamper@@UAEIXZ

        // WTimeStamper.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref WTimeStamper, void**, UInt32, UInt32>)0x006B38E0)(ref this, addr, size); // .text:006B2A10 ; unsigned int __thiscall WTimeStamper::Pack(WTimeStamper *this, void **addr, unsigned int size) .text:006B2A10 ?Pack@WTimeStamper@@UAEIAAPAXI@Z
    }
    public unsafe struct PublicWeenieDesc {
        // Struct:
        public WeenieDesc a0;
        public AC1Legacy.PStringBase<char> _name;
        public AC1Legacy.PStringBase<char> _plural_name;
        public UInt32 _wcid;
        public UInt32 _iconID;
        public UInt32 _iconOverlayID;
        public UInt32 _iconUnderlayID;
        public UInt32 _containerID;
        public UInt32 _wielderID;
        public UInt32 _priority;
        public UInt32 _valid_locations;
        public UInt32 _location;
        public int _itemsCapacity;
        public int _containersCapacity;
        public ITEM_TYPE _type;
        public UInt32 _value;
        public ITEM_USEABLE _useability;
        public Single _useRadius;
        public ITEM_TYPE _targetType;
        public UInt32 _effects;
        public AMMO_TYPE _ammoType;
        public COMBAT_USE _combatUse;
        public UInt32 _structure;
        public UInt32 _maxStructure;
        public UInt32 _stackSize;
        public UInt32 _maxStackSize;
        public UInt32 _bitfield;
        public int _blipColor;
        public RadarEnum _radar_enum;
        public int _burden;
        public UInt32 _spellID;
        public UInt32 _house_owner_iid;
        public RestrictionDB* _db;
        public PScriptType _pscript;
        public UInt32 _hook_type;
        public ITEM_TYPE _hook_item_types;
        public UInt32 _monarch;
        public int _material_type;
        public Single _workmanship;
        public int _cooldown_id;
        public Double _cooldown_duration;
        public UInt32 _pet_owner;
        public override string ToString() => $"a0(WeenieDesc):{a0}, _name:{_name}, _plural_name:{_plural_name}, _wcid:{_wcid:X8}, _iconID:{_iconID:X8}, _iconOverlayID:{_iconOverlayID:X8}, _iconUnderlayID:{_iconUnderlayID:X8}, _containerID:{_containerID:X8}, _wielderID:{_wielderID:X8}, _priority:{_priority:X8}, _valid_locations:{_valid_locations:X8}, _location:{_location:X8}, _itemsCapacity(int):{_itemsCapacity}, _containersCapacity(int):{_containersCapacity}, _type(ITEM_TYPE):{_type}, _value:{_value:X8}, _useability(ITEM_USEABLE):{_useability}, _useRadius:{_useRadius:n5}, _targetType(ITEM_TYPE):{_targetType}, _effects:{_effects:X8}, _ammoType(AMMO_TYPE):{_ammoType}, _combatUse(COMBAT_USE):{_combatUse}, _structure:{_structure:X8}, _maxStructure:{_maxStructure:X8}, _stackSize:{_stackSize:X8}, _maxStackSize:{_maxStackSize:X8}, _bitfield:{_bitfield:X8}, _blipColor(int):{_blipColor}, _radar_enum(RadarEnum):{_radar_enum}, _burden(int):{_burden}, _spellID:{_spellID:X8}, _house_owner_iid:{_house_owner_iid:X8}, _db:->(RestrictionDB*)0x{(int)_db:X8}, _pscript(PScriptType):{_pscript}, _hook_type:{_hook_type:X8}, _hook_item_types(ITEM_TYPE):{_hook_item_types}, _monarch:{_monarch:X8}, _material_type(int):{_material_type}, _workmanship:{_workmanship:n5}, _cooldown_id(int):{_cooldown_id}, _cooldown_duration:{_cooldown_duration:n5}, _pet_owner:{_pet_owner:X8}";
        // Enums:
        public enum BitfieldIndex : UInt32 {
            BF_OPENABLE = 0x1,
            BF_INSCRIBABLE = 0x2,
            BF_STUCK = 0x4,
            BF_PLAYER = 0x8,
            BF_ATTACKABLE = 0x10,
            BF_PLAYER_KILLER = 0x20,
            BF_HIDDEN_ADMIN = 0x40,
            BF_UI_HIDDEN = 0x80,
            BF_BOOK = 0x100,
            BF_VENDOR = 0x200,
            BF_PKSWITCH = 0x400,
            BF_NPKSWITCH = 0x800,
            BF_DOOR = 0x1000,
            BF_CORPSE = 0x2000,
            BF_LIFESTONE = 0x4000,
            BF_FOOD = 0x8000,
            BF_HEALER = 0x10000,
            BF_LOCKPICK = 0x20000,
            BF_PORTAL = 0x40000,
            BF_ADMIN = 0x100000,
            BF_FREE_PKSTATUS = 0x200000,
            BF_IMMUNE_CELL_RESTRICTIONS = 0x400000,
            BF_REQUIRES_PACKSLOT = 0x800000,
            BF_RETAINED = 0x1000000,
            BF_PKLITE_PKSTATUS = 0x2000000,
            BF_INCLUDES_SECOND_HEADER = 0x4000000,
            BF_BINDSTONE = 0x8000000,
            BF_VOLATILE_RARE = 0x10000000,
            BF_WIELD_ON_USE = 0x20000000,
            BF_WIELD_LEFT = 0x40000000,
            FORCE_BitfieldIndex_32_BIT = 0x7FFFFFFF,
        };

        // Functions:

        // PublicWeenieDesc.operator_equals:
        //public PublicWeenieDesc* operator_equals(class PublicWeenieDesc, const a1) => ((delegate* unmanaged[Thiscall]<ref PublicWeenieDesc, class, const, PublicWeenieDesc*>)0x005ADB20)(ref this, PublicWeenieDesc, a1); // .text:005ACA70 ; public: class PublicWeenieDesc & __thiscall PublicWeenieDesc::operator=(class PublicWeenieDesc const &) .text:005ACA70 ??4PublicWeenieDesc@@QAEAAV0@ABV0@@Z

        // PublicWeenieDesc.Reset:
        public void Reset() => ((delegate* unmanaged[Thiscall]<ref PublicWeenieDesc, void>)0x005ADD20)(ref this); // .text:005ACC70 ; void __thiscall PublicWeenieDesc::Reset(PublicWeenieDesc *this) .text:005ACC70 ?Reset@PublicWeenieDesc@@QAEXXZ

        // PublicWeenieDesc.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref PublicWeenieDesc, void>)0x005AE4D0)(ref this); // .text:005AD420 ; void __thiscall PublicWeenieDesc::PublicWeenieDesc(PublicWeenieDesc *this) .text:005AD420 ??0PublicWeenieDesc@@QAE@XZ

        // PublicWeenieDesc.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PublicWeenieDesc, void**, UInt32, int>)0x005AE520)(ref this, addr, size); // .text:005AD470 ; int __thiscall PublicWeenieDesc::UnPack(PublicWeenieDesc *this, void **addr, unsigned int size) .text:005AD470 ?UnPack@PublicWeenieDesc@@UAEHAAPAXI@Z

        // PublicWeenieDesc.`scalar deleting destructor':
        // (ERR) .text:005ADB00 ; int __thiscall PublicWeenieDesc::`scalar deleting destructor'(void *, char) .text:005ADB00 ??_GPublicWeenieDesc@@UAEPAXI@Z

        // PublicWeenieDesc.set_pack_header:
        public void set_pack_header(UInt32* header) => ((delegate* unmanaged[Thiscall]<ref PublicWeenieDesc, UInt32*, void>)0x005AD8D0)(ref this, header); // .text:005AC820 ; void __thiscall PublicWeenieDesc::set_pack_header(PublicWeenieDesc *this, unsigned int *header) .text:005AC820 ?set_pack_header@PublicWeenieDesc@@AAEXAAK@Z

        // PublicWeenieDesc.SetPlayerKillerStatus:
        public void SetPlayerKillerStatus(UInt32 pk) => ((delegate* unmanaged[Thiscall]<ref PublicWeenieDesc, UInt32, void>)0x005AD870)(ref this, pk); // .text:005AC7C0 ; void __thiscall PublicWeenieDesc::SetPlayerKillerStatus(PublicWeenieDesc *this, unsigned int pk) .text:005AC7C0 ?SetPlayerKillerStatus@PublicWeenieDesc@@QAEXK@Z

        // PublicWeenieDesc.pack_size:
        public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref PublicWeenieDesc, UInt32>)0x005ADEB0)(ref this); // .text:005ACE00 ; unsigned int __thiscall PublicWeenieDesc::pack_size(PublicWeenieDesc *this) .text:005ACE00 ?pack_size@PublicWeenieDesc@@EAEIXZ

        // PublicWeenieDesc.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PublicWeenieDesc, void**, UInt32, UInt32>)0x005AE120)(ref this, addr, size); // .text:005AD070 ; unsigned int __thiscall PublicWeenieDesc::Pack(PublicWeenieDesc *this, void **addr, unsigned int size) .text:005AD070 ?Pack@PublicWeenieDesc@@UAEIAAPAXI@Z

        // PublicWeenieDesc.~PublicWeenieDesc:
        // (ERR) .text:005ADA90 ; public: virtual __thiscall PublicWeenieDesc::~PublicWeenieDesc(void) .text:005ADA90 ??1PublicWeenieDesc@@UAE@XZ

        // PublicWeenieDesc.IsTalkable:
        public static int IsTalkable(ITEM_TYPE _itemType) => ((delegate* unmanaged[Cdecl]<ITEM_TYPE, int>)0x005AD860)(_itemType); // .text:005AC7B0 ; int __cdecl PublicWeenieDesc::IsTalkable(ITEM_TYPE _itemType) .text:005AC7B0 ?IsTalkable@PublicWeenieDesc@@SAHW4ITEM_TYPE@@@Z
    }
    public unsafe struct WeenieDesc {
        // Struct:
        public PackObj a0;
        public override string ToString() => $"a0(PackObj):{a0}";

        // Functions:

        // WeenieDesc.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref WeenieDesc, void>)0x005AEBE0)(ref this); // .text:005ADB30 ; void __thiscall WeenieDesc::WeenieDesc(WeenieDesc *this) .text:005ADB30 ??0WeenieDesc@@QAE@XZ

        // WeenieDesc.~WeenieDesc:
        // (ERR) .text:005AEBF0 ; public: virtual __thiscall WeenieDesc::~WeenieDesc(void) .text:005AEBF0 ??1WeenieDesc@@UAE@XZ
    }


    public unsafe struct AppraisalProfile {
        // Struct:
        public PackObj a0;
        public int success_flag;
        public CreatureAppraisalProfile* creature_profile;
        public HookAppraisalProfile* hook_profile;
        public WeaponProfile* weapon_profile;
        public ArmorProfile* armor_profile;
        public PackableHashTable<UInt32, UInt32>* _intStatsTable;
        public PackableHashTable<UInt32, Int64>* _int64StatsTable;
        public PackableHashTable<UInt32, int>* _boolStatsTable;
        public PackableHashTable<UInt32, Double>* _floatStatsTable;
        public PackableHashTable<UInt32, AC1Legacy.PStringBase<char>>* _strStatsTable;
        public PackableHashTable<UInt32, UInt32>* _didStatsTable;
        public PSmartArray<UInt32>* _spellBook;
        public UInt32 armor_ench_bitfield;
        public UInt32 weapon_ench_bitfield;
        public UInt32 resist_ench_bitfield;
        public int base_armor_head;
        public int base_armor_chest;
        public int base_armor_groin;
        public int base_armor_bicep;
        public int base_armor_wrist;
        public int base_armor_hand;
        public int base_armor_thigh;
        public int base_armor_shin;
        public int base_armor_foot;
        public override string ToString() => $"a0(PackObj):{a0}, success_flag(int):{success_flag}, creature_profile:->(CreatureAppraisalProfile*)0x{(int)creature_profile:X8}, hook_profile:->(HookAppraisalProfile*)0x{(int)hook_profile:X8}, weapon_profile:->(WeaponProfile*)0x{(int)weapon_profile:X8}, armor_profile:->(ArmorProfile*)0x{(int)armor_profile:X8}, _intStatsTable:->(PackableHashTable<UInt32,UInt32>*)0x{(int)_intStatsTable:X8}, _int64StatsTable:->(PackableHashTable<UInt32,Int64>*)0x{(int)_int64StatsTable:X8}, _boolStatsTable:->(PackableHashTable<UInt32,int>*)0x{(int)_boolStatsTable:X8}, _floatStatsTable:->(PackableHashTable<UInt32,Double>*)0x{(int)_floatStatsTable:X8}, _strStatsTable:->(PackableHashTable<UInt32,AC1Legacy.PStringBase<char> >*)0x{(int)_strStatsTable:X8}, _didStatsTable:->(PackableHashTable<UInt32,UInt32 >*)0x{(int)_didStatsTable:X8}, _spellBook:->(PSmartArray<UInt32>*)0x{(int)_spellBook:X8}, armor_ench_bitfield:{armor_ench_bitfield:X8}, weapon_ench_bitfield:{weapon_ench_bitfield:X8}, resist_ench_bitfield:{resist_ench_bitfield:X8}, base_armor_head(int):{base_armor_head}, base_armor_chest(int):{base_armor_chest}, base_armor_groin(int):{base_armor_groin}, base_armor_bicep(int):{base_armor_bicep}, base_armor_wrist(int):{base_armor_wrist}, base_armor_hand(int):{base_armor_hand}, base_armor_thigh(int):{base_armor_thigh}, base_armor_shin(int):{base_armor_shin}, base_armor_foot(int):{base_armor_foot}";
        // Enums:
        public enum ArmorEnchantment_BFIndex : UInt32 {
            BF_ARMOR_LEVEL = 0x1,
            BF_ARMOR_MOD_VS_SLASH = 0x2,
            BF_ARMOR_MOD_VS_PIERCE = 0x4,
            BF_ARMOR_MOD_VS_BLUDGEON = 0x8,
            BF_ARMOR_MOD_VS_COLD = 0x10,
            BF_ARMOR_MOD_VS_FIRE = 0x20,
            BF_ARMOR_MOD_VS_ACID = 0x40,
            BF_ARMOR_MOD_VS_ELECTRIC = 0x80,
            BF_ARMOR_MOD_VS_NETHER = 0x100,
            BF_ARMOR_LEVEL_HI = 0x10000,
            BF_ARMOR_MOD_VS_SLASH_HI = 0x20000,
            BF_ARMOR_MOD_VS_PIERCE_HI = 0x40000,
            BF_ARMOR_MOD_VS_BLUDGEON_HI = 0x80000,
            BF_ARMOR_MOD_VS_COLD_HI = 0x100000,
            BF_ARMOR_MOD_VS_FIRE_HI = 0x200000,
            BF_ARMOR_MOD_VS_ACID_HI = 0x400000,
            BF_ARMOR_MOD_VS_ELECTRIC_HI = 0x800000,
            BF_ARMOR_MOD_VS_NETHER_HI = 0x1000000,
            FORCE_ArmorEnchantment_BFIndex_32_BIT = 0x7FFFFFFF,
        };
        public enum WeaponEnchantment_BFIndex : UInt32 {
            BF_WEAPON_OFFENSE = 0x1,
            BF_WEAPON_DEFENSE = 0x2,
            BF_WEAPON_TIME = 0x4,
            BF_DAMAGE = 0x8,
            BF_DAMAGE_VARIANCE = 0x10,
            BF_DAMAGE_MOD = 0x20,
            BF_WEAPON_OFFENSE_HI = 0x10000,
            BF_WEAPON_DEFENSE_HI = 0x20000,
            BF_WEAPON_TIME_HI = 0x40000,
            BF_DAMAGE_HI = 0x80000,
            BF_DAMAGE_VARIANCE_HI = 0x100000,
            BF_DAMAGE_MOD_HI = 0x200000,
            FORCE_WeaponEnchantment_BFIndex_32_BIT = 0x7FFFFFFF,
        };
        public enum ResistanceEnchantment_BFIndex : UInt32 {
            BF_RESIST_SLASH = 0x1,
            BF_RESIST_PIERCE = 0x2,
            BF_RESIST_BLUDGEON = 0x4,
            BF_RESIST_FIRE = 0x8,
            BF_RESIST_COLD = 0x10,
            BF_RESIST_ACID = 0x20,
            BF_RESIST_ELECTRIC = 0x40,
            BF_RESIST_HEALTH_BOOST = 0x80,
            BF_RESIST_STAMINA_DRAIN = 0x100,
            BF_RESIST_STAMINA_BOOST = 0x200,
            BF_RESIST_MANA_DRAIN = 0x400,
            BF_RESIST_MANA_BOOST = 0x800,
            BF_MANA_CON_MOD = 0x1000,
            BF_ELE_DAMAGE_MOD = 0x2000,
            BF_RESIST_NETHER = 0x4000,
            BF_RESIST_SLASH_HI = 0x10000,
            BF_RESIST_PIERCE_HI = 0x20000,
            BF_RESIST_BLUDGEON_HI = 0x40000,
            BF_RESIST_FIRE_HI = 0x80000,
            BF_RESIST_COLD_HI = 0x100000,
            BF_RESIST_ACID_HI = 0x200000,
            BF_RESIST_ELECTRIC_HI = 0x400000,
            BF_RESIST_HEALTH_BOOST_HI = 0x800000,
            BF_RESIST_STAMINA_DRAIN_HI = 0x1000000,
            BF_RESIST_STAMINA_BOOST_HI = 0x2000000,
            BF_RESIST_MANA_DRAIN_HI = 0x4000000,
            BF_RESIST_MANA_BOOST_HI = 0x8000000,
            BF_MANA_CON_MOD_HI = 0x10000000,
            BF_ELE_DAMAGE_MOD_HI = 0x20000000,
            BF_RESIST_NETHER_HI = 0x40000000,
            FORCE_ResistanceEnchantment_BFIndex_32_BIT = 0x7FFFFFFF,
        };

        // Functions:

        // AppraisalProfile.InqIntEnchantmentMod:
        // public int InqIntEnchantmentMod(UInt32 stype, int* raised) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32, int*, int>)0xDEADBEEF)(ref this, stype, raised); // .text:005B2C10 ; int __thiscall AppraisalProfile::InqIntEnchantmentMod(AppraisalProfile *this, unsigned int stype, int *raised) .text:005B2C10 ?InqIntEnchantmentMod@AppraisalProfile@@QBEHKAAH@Z

        // AppraisalProfile.IsHookedItemInscribable:
        // public int IsHookedItemInscribable() => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, int>)0xDEADBEEF)(ref this); // .text:005B2F90 ; int __thiscall AppraisalProfile::IsHookedItemInscribable(AppraisalProfile *this) .text:005B2F90 ?IsHookedItemInscribable@AppraisalProfile@@QBEHXZ

        // AppraisalProfile.GetHookedItemAmmoType:
        // public AMMO_TYPE GetHookedItemAmmoType() => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, AMMO_TYPE>)0xDEADBEEF)(ref this); // .text:005B2FD0 ; AMMO_TYPE __thiscall AppraisalProfile::GetHookedItemAmmoType(AppraisalProfile *this) .text:005B2FD0 ?GetHookedItemAmmoType@AppraisalProfile@@QBE?AW4AMMO_TYPE@@XZ

        // AppraisalProfile.pack_size:
        // public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32>)0xDEADBEEF)(ref this); // .text:005B30D0 ; unsigned int __thiscall AppraisalProfile::pack_size(AppraisalProfile *this) .text:005B30D0 ?pack_size@AppraisalProfile@@IAEIXZ

        // AppraisalProfile.InqArmor:
        // public int InqArmor(ArmorProfile* aap) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, ArmorProfile*, int>)0xDEADBEEF)(ref this, aap); // .text:005B3370 ; int __thiscall AppraisalProfile::InqArmor(AppraisalProfile *this, ArmorProfile *aap) .text:005B3370 ?InqArmor@AppraisalProfile@@QBEHAAVArmorProfile@@@Z

        // AppraisalProfile.InqWeapon:
        // public int InqWeapon(WeaponProfile* wap) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, WeaponProfile*, int>)0xDEADBEEF)(ref this, wap); // .text:005B3810 ; int __thiscall AppraisalProfile::InqWeapon(AppraisalProfile *this, WeaponProfile *wap) .text:005B3810 ?InqWeapon@AppraisalProfile@@QBEHAAVWeaponProfile@@@Z

        // AppraisalProfile.InqInt:
        // public int InqInt(UInt32 stype, int* retval) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32, int*, int>)0xDEADBEEF)(ref this, stype, retval); // .text:005B3830 ; int __thiscall AppraisalProfile::InqInt(AppraisalProfile *this, unsigned int stype, int *retval) .text:005B3830 ?InqInt@AppraisalProfile@@QBEHKAAJ@Z

        // AppraisalProfile.InqCreature:
        // public int InqCreature(CreatureAppraisalProfile* cap) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, CreatureAppraisalProfile*, int>)0xDEADBEEF)(ref this, cap); // .text:005B2BF0 ; int __thiscall AppraisalProfile::InqCreature(AppraisalProfile *this, CreatureAppraisalProfile *cap) .text:005B2BF0 ?InqCreature@AppraisalProfile@@QBEHAAVCreatureAppraisalProfile@@@Z

        // AppraisalProfile.InqString:
        // public int InqString(UInt32 stype, AC1Legacy.PStringBase<char>* retval) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32, AC1Legacy.PStringBase<char>*, int>)0xDEADBEEF)(ref this, stype, retval); // .text:005B3950 ; int __thiscall AppraisalProfile::InqString(AppraisalProfile *this, unsigned int stype, AC1Legacy::PStringBase<char> *retval) .text:005B3950 ?InqString@AppraisalProfile@@QBEHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalProfile.InqInt64:
        // public int InqInt64(UInt32 stype, Int64* retval) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32, Int64*, int>)0xDEADBEEF)(ref this, stype, retval); // .text:005B3860 ; int __thiscall AppraisalProfile::InqInt64(AppraisalProfile *this, unsigned int stype, __int64 *retval) .text:005B3860 ?InqInt64@AppraisalProfile@@QBEHKAA_J@Z

        // AppraisalProfile.InqBool:
        // public int InqBool(UInt32 stype, int* retval) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32, int*, int>)0xDEADBEEF)(ref this, stype, retval); // .text:005B3890 ; int __thiscall AppraisalProfile::InqBool(AppraisalProfile *this, unsigned int stype, int *retval) .text:005B3890 ?InqBool@AppraisalProfile@@QBEHKAAH@Z

        // AppraisalProfile.IsHookedItemLockpick:
        // public int IsHookedItemLockpick() => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, int>)0xDEADBEEF)(ref this); // .text:005B2FB0 ; int __thiscall AppraisalProfile::IsHookedItemLockpick(AppraisalProfile *this) .text:005B2FB0 ?IsHookedItemLockpick@AppraisalProfile@@QBEHXZ

        // AppraisalProfile.IsHookedItemHealer:
        // public int IsHookedItemHealer() => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, int>)0xDEADBEEF)(ref this); // .text:005B2FA0 ; int __thiscall AppraisalProfile::IsHookedItemHealer(AppraisalProfile *this) .text:005B2FA0 ?IsHookedItemHealer@AppraisalProfile@@QBEHXZ

        // AppraisalProfile.SetPackHeader:
        // public void SetPackHeader(UInt32* bitfield) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32*, void>)0xDEADBEEF)(ref this, bitfield); // .text:005B2FE0 ; void __thiscall AppraisalProfile::SetPackHeader(AppraisalProfile *this, unsigned int *bitfield) .text:005B2FE0 ?SetPackHeader@AppraisalProfile@@IAEXAAK@Z

        // AppraisalProfile.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005B33C0 ; unsigned int __thiscall AppraisalProfile::Pack(AppraisalProfile *this, void **addr, unsigned int size) .text:005B33C0 ?Pack@AppraisalProfile@@UAEIAAPAXI@Z

        // AppraisalProfile.InqDataID:
        // public int InqDataID(UInt32 stype, UInt32* retval) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32, UInt32*, int>)0xDEADBEEF)(ref this, stype, retval); // .text:005B38F0 ; int __thiscall AppraisalProfile::InqDataID(AppraisalProfile *this, unsigned int stype, IDClass<_tagDataID,32,0> *retval) .text:005B38F0 ?InqDataID@AppraisalProfile@@QBEHKAAV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // AppraisalProfile.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005B3980 ; int __thiscall AppraisalProfile::UnPack(AppraisalProfile *this, void **addr, unsigned int size) .text:005B3980 ?UnPack@AppraisalProfile@@UAEHAAPAXI@Z

        // AppraisalProfile.InqFloatEnchantmentMod:
        // public int InqFloatEnchantmentMod(UInt32 stype, int* raised) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32, int*, int>)0xDEADBEEF)(ref this, stype, raised); // .text:005B2C70 ; int __thiscall AppraisalProfile::InqFloatEnchantmentMod(AppraisalProfile *this, unsigned int stype, int *raised) .text:005B2C70 ?InqFloatEnchantmentMod@AppraisalProfile@@QBEHKAAH@Z

        // AppraisalProfile.GetHookedItemValidLocations:
        // public UInt32 GetHookedItemValidLocations() => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32>)0xDEADBEEF)(ref this); // .text:005B2FC0 ; unsigned int __thiscall AppraisalProfile::GetHookedItemValidLocations(AppraisalProfile *this) .text:005B2FC0 ?GetHookedItemValidLocations@AppraisalProfile@@QBEKXZ

        // AppraisalProfile.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, void>)0xDEADBEEF)(ref this); // .text:005B32A0 ; void __thiscall AppraisalProfile::AppraisalProfile(AppraisalProfile *this) .text:005B32A0 ??0AppraisalProfile@@QAE@XZ

        // AppraisalProfile.InqFloat:
        // public int InqFloat(UInt32 stype, Double* retval) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, UInt32, Double*, int>)0xDEADBEEF)(ref this, stype, retval); // .text:005B38C0 ; int __thiscall AppraisalProfile::InqFloat(AppraisalProfile *this, unsigned int stype, long double *retval) .text:005B38C0 ?InqFloat@AppraisalProfile@@QBEHKAAN@Z

        // AppraisalProfile.operator_equals:
        // public AppraisalProfile* operator_equals(class AppraisalProfile, const a1) => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, class, const, AppraisalProfile*>)0xDEADBEEF)(ref this, AppraisalProfile, a1); // .text:005B4100 ; public: class AppraisalProfile & __thiscall AppraisalProfile::operator=(class AppraisalProfile const &) .text:005B4100 ??4AppraisalProfile@@QAEAAV0@ABV0@@Z

        // AppraisalProfile.Clear:
        public void Clear() => ((delegate* unmanaged[Thiscall]<ref AppraisalProfile, void>)0x005B3BB0)(ref this); // .text:005B2B00 ; void __thiscall AppraisalProfile::Clear(AppraisalProfile *this) .text:005B2B00 ?Clear@AppraisalProfile@@QAEXXZ
    }
    public unsafe struct CreatureAppraisalProfile {
        // Struct:
        public PackObj a0;
        public UInt32 strength;
        public UInt32 endurance;
        public UInt32 quickness;
        public UInt32 coordination;
        public UInt32 focus;
        public UInt32 self;
        public UInt32 health;
        public UInt32 stamina;
        public UInt32 mana;
        public UInt32 max_health;
        public UInt32 max_stamina;
        public UInt32 max_mana;
        public UInt32 enchantment_bitfield;
        public override string ToString() => $"a0(PackObj):{a0}, strength:{strength:X8}, endurance:{endurance:X8}, quickness:{quickness:X8}, coordination:{coordination:X8}, focus:{focus:X8}, self:{self:X8}, health:{health:X8}, stamina:{stamina:X8}, mana:{mana:X8}, max_health:{max_health:X8}, max_stamina:{max_stamina:X8}, max_mana:{max_mana:X8}, enchantment_bitfield:{enchantment_bitfield:X8}";
        // Enums:
        public enum Enchantment_BFIndex : UInt32 {
            BF_STRENGTH = 0x1,
            BF_ENDURANCE = 0x2,
            BF_QUICKNESS = 0x4,
            BF_COORDINATION = 0x8,
            BF_FOCUS = 0x10,
            BF_SELF = 0x20,
            BF_MAX_HEALTH = 0x40,
            BF_MAX_STAMINA = 0x80,
            BF_MAX_MANA = 0x100,
            BF_STRENGTH_HI = 0x10000,
            BF_ENDURANCE_HI = 0x20000,
            BF_QUICKNESS_HI = 0x40000,
            BF_COORDINATION_HI = 0x80000,
            BF_FOCUS_HI = 0x100000,
            BF_SELF_HI = 0x200000,
            BF_MAX_HEALTH_HI = 0x400000,
            BF_MAX_STAMINA_HI = 0x800000,
            BF_MAX_MANA_HI = 0x1000000,
            FORCE_Enchantment_BFIndex_32_BIT = 0x7FFFFFFF,
        };

        // Functions:

        // CreatureAppraisalProfile.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CreatureAppraisalProfile, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005B6190 ; int __thiscall CreatureAppraisalProfile::UnPack(CreatureAppraisalProfile *this, void **addr, unsigned int size) .text:005B6190 ?UnPack@CreatureAppraisalProfile@@UAEHAAPAXI@Z

        // CreatureAppraisalProfile.operator_equals:
        // public CreatureAppraisalProfile* operator_equals(class CreatureAppraisalProfile, const a1) => ((delegate* unmanaged[Thiscall]<ref CreatureAppraisalProfile, class, const, CreatureAppraisalProfile*>)0xDEADBEEF)(ref this, CreatureAppraisalProfile, a1); // .text:005B5D20 ; public: class CreatureAppraisalProfile & __thiscall CreatureAppraisalProfile::operator=(class CreatureAppraisalProfile const &) .text:005B5D20 ??4CreatureAppraisalProfile@@QAEAAV0@ABV0@@Z

        // CreatureAppraisalProfile.InqAttribute:
        public int InqAttribute(UInt32 stype, UInt32* retval) => ((delegate* unmanaged[Thiscall]<ref CreatureAppraisalProfile, UInt32, UInt32*, int>)0x005B6E30)(ref this, stype, retval); // .text:005B5D80 ; int __thiscall CreatureAppraisalProfile::InqAttribute(CreatureAppraisalProfile *this, unsigned int stype, unsigned int *retval) .text:005B5D80 ?InqAttribute@CreatureAppraisalProfile@@QBEHKAAK@Z

        // CreatureAppraisalProfile.InqAttribute2nd:
        public int InqAttribute2nd(UInt32 stype, UInt32* retval) => ((delegate* unmanaged[Thiscall]<ref CreatureAppraisalProfile, UInt32, UInt32*, int>)0x005B6ED0)(ref this, stype, retval); // .text:005B5E20 ; int __thiscall CreatureAppraisalProfile::InqAttribute2nd(CreatureAppraisalProfile *this, unsigned int stype, unsigned int *retval) .text:005B5E20 ?InqAttribute2nd@CreatureAppraisalProfile@@QBEHKAAK@Z

        // CreatureAppraisalProfile.InqAttributeEnchantmentMod:
        public int InqAttributeEnchantmentMod(UInt32 stype, int* raised) => ((delegate* unmanaged[Thiscall]<ref CreatureAppraisalProfile, UInt32, int*, int>)0x005B6F70)(ref this, stype, raised); // .text:005B5EC0 ; int __thiscall CreatureAppraisalProfile::InqAttributeEnchantmentMod(CreatureAppraisalProfile *this, unsigned int stype, int *raised) .text:005B5EC0 ?InqAttributeEnchantmentMod@CreatureAppraisalProfile@@QBEHKAAH@Z

        // CreatureAppraisalProfile.InqAttribute2ndEnchantmentMod:
        public int InqAttribute2ndEnchantmentMod(UInt32 stype, int* raised) => ((delegate* unmanaged[Thiscall]<ref CreatureAppraisalProfile, UInt32, int*, int>)0x005B7060)(ref this, stype, raised); // .text:005B5FB0 ; int __thiscall CreatureAppraisalProfile::InqAttribute2ndEnchantmentMod(CreatureAppraisalProfile *this, unsigned int stype, int *raised) .text:005B5FB0 ?InqAttribute2ndEnchantmentMod@CreatureAppraisalProfile@@QBEHKAAH@Z

        // CreatureAppraisalProfile.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CreatureAppraisalProfile, void>)0xDEADBEEF)(ref this); // .text:005B6020 ; void __thiscall CreatureAppraisalProfile::CreatureAppraisalProfile(CreatureAppraisalProfile *this) .text:005B6020 ??0CreatureAppraisalProfile@@QAE@XZ

        // CreatureAppraisalProfile.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CreatureAppraisalProfile, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005B6060 ; unsigned int __thiscall CreatureAppraisalProfile::Pack(CreatureAppraisalProfile *this, void **addr, unsigned int size) .text:005B6060 ?Pack@CreatureAppraisalProfile@@UAEIAAPAXI@Z
    }
    public unsafe struct HookAppraisalProfile {
        // Struct:
        public PackObj a0;
        public UInt32 mBitfield;
        public UInt32 mValidLocations;
        public AMMO_TYPE mAmmoType;
        public override string ToString() => $"a0(PackObj):{a0}, mBitfield:{mBitfield:X8}, mValidLocations:{mValidLocations:X8}, mAmmoType(AMMO_TYPE):{mAmmoType}";

        // Functions:

        // HookAppraisalProfile.IsLockpick:
        // public int IsLockpick() => ((delegate* unmanaged[Thiscall]<ref HookAppraisalProfile, int>)0xDEADBEEF)(ref this); // .text:005B64E0 ; int __thiscall HookAppraisalProfile::IsLockpick(HookAppraisalProfile *this) .text:005B64E0 ?IsLockpick@HookAppraisalProfile@@QBEHXZ

        // HookAppraisalProfile.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref HookAppraisalProfile, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005B64F0 ; unsigned int __thiscall HookAppraisalProfile::Pack(HookAppraisalProfile *this, void **addr, unsigned int size) .text:005B64F0 ?Pack@HookAppraisalProfile@@UAEIAAPAXI@Z

        // HookAppraisalProfile.GetValidLocations:
        public int GetValidLocations() => ((delegate* unmanaged[Thiscall]<ref HookAppraisalProfile, int>)0x004F8D90)(ref this); // .text:0051D4B0 ; int __thiscall HookAppraisalProfile::GetValidLocations(ChatDisplayInfo *this) .text:0051D4B0 ?GetValidLocations@HookAppraisalProfile@@QBEKXZ

        // HookAppraisalProfile.Clear:
        // public void Clear() => ((delegate* unmanaged[Thiscall]<ref HookAppraisalProfile, void>)0xDEADBEEF)(ref this); // .text:005B64B0 ; void __thiscall HookAppraisalProfile::Clear(HookAppraisalProfile *this) .text:005B64B0 ?Clear@HookAppraisalProfile@@QAEXXZ

        // HookAppraisalProfile.IsInscribable:
        // public int IsInscribable() => ((delegate* unmanaged[Thiscall]<ref HookAppraisalProfile, int>)0xDEADBEEF)(ref this); // .text:005B64C0 ; int __thiscall HookAppraisalProfile::IsInscribable(HookAppraisalProfile *this) .text:005B64C0 ?IsInscribable@HookAppraisalProfile@@QBEHXZ

        // HookAppraisalProfile.IsHealer:
        // public int IsHealer() => ((delegate* unmanaged[Thiscall]<ref HookAppraisalProfile, int>)0xDEADBEEF)(ref this); // .text:005B64D0 ; int __thiscall HookAppraisalProfile::IsHealer(HookAppraisalProfile *this) .text:005B64D0 ?IsHealer@HookAppraisalProfile@@QBEHXZ
    }
    public unsafe struct WeaponProfile {
        // Struct:
        public PackObj a0;
        public DAMAGE_TYPE damage_type;
        public UInt32 weapon_skill;
        public int weapon_time;
        public int weapon_damage;
        public Double damage_variance;
        public Double damage_mod;
        public Double weapon_length;
        public Double max_velocity;
        public Double weapon_offense;
        public int max_velocity_estimated;
        public override string ToString() => $"a0(PackObj):{a0}, damage_type(DAMAGE_TYPE):{damage_type}, weapon_skill:{weapon_skill:X8}, weapon_time(int):{weapon_time}, weapon_damage(int):{weapon_damage}, damage_variance:{damage_variance:n5}, damage_mod:{damage_mod:n5}, weapon_length:{weapon_length:n5}, max_velocity:{max_velocity:n5}, weapon_offense:{weapon_offense:n5}, max_velocity_estimated(int):{max_velocity_estimated}";

        // Functions:

        // WeaponProfile.operator_equals:
        // public WeaponProfile* operator_equals(class WeaponProfile, const a1) => ((delegate* unmanaged[Thiscall]<ref WeaponProfile, class, const, WeaponProfile*>)0xDEADBEEF)(ref this, WeaponProfile, a1); // .text:005B3300 ; public: class WeaponProfile & __thiscall WeaponProfile::operator=(class WeaponProfile const &) .text:005B3300 ??4WeaponProfile@@QAEAAV0@ABV0@@Z

        // WeaponProfile.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref WeaponProfile, void>)0xDEADBEEF)(ref this); // .text:005B62C0 ; void __thiscall WeaponProfile::WeaponProfile(WeaponProfile *this) .text:005B62C0 ??0WeaponProfile@@QAE@XZ

        // WeaponProfile.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref WeaponProfile, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:005B6310 ; unsigned int __thiscall WeaponProfile::Pack(WeaponProfile *this, void **addr, unsigned int size) .text:005B6310 ?Pack@WeaponProfile@@UAEIAAPAXI@Z

        // WeaponProfile.UnPack:
        // public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref WeaponProfile, void**, UInt32, int>)0xDEADBEEF)(ref this, addr, size); // .text:005B63C0 ; int __thiscall WeaponProfile::UnPack(WeaponProfile *this, void **addr, unsigned int size) .text:005B63C0 ?UnPack@WeaponProfile@@UAEHAAPAXI@Z
    }











}