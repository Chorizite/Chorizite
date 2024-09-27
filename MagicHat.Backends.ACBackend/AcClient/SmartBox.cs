using System;
using System.Runtime.InteropServices;

namespace AcClient {
    public unsafe struct SmartBox {
        // Struct:
        public SmartBox.Vtbl* vfptr;
        public int testMode;
        public Position viewer;
        public CObjCell* viewer_cell;
        public UInt32 head_index;
        public Position viewer_sought_position;
        public CameraManager* camera_manager;
        public CellManager* cell_manager;
        public CPhysics* physics;
        public CObjectMaint* m_pObjMaint;
        public LScape* lscape;
        public Ambient* ambient_sounds;
        public CommandInterpreter* cmdinterp;
        public int creature_mode;
        public Single m_fGameFOV;
        public Single m_fViewDistFOV;
        public Byte m_bUseViewDistance;
        public Single game_ambient_level;
        public UInt32 game_ambient_color;
        public int game_degrades_disabled;
        public int hidden;
        public int position_update_complete;
        public int waiting_for_teleport;
        public int has_been_teleported;
        public NIList<NetBlob>* in_queue;
        public NIList<NetBlob>* netblob_list;
        public _iobuf* position_and_movement_file;
        public UInt32 player_id;
        public CPhysicsObj* player;
        public UInt32 target_object_id;
        public static delegate* unmanaged[Cdecl]<UInt32, ObjectSelectStatus, tagRECT*, Single, void> target_callback; // void (__cdecl *target_callback)(unsigned int, ObjectSelectStatus, tagRECT *, float);
        public UInt32 num_cells;
        public CEnvCell** cells;
        public UInt32 num_objects;
        public CPhysicsObj** objects;
        public static delegate* unmanaged[Cdecl]<void> m_renderingCallback; // void (__cdecl *m_renderingCallback)();
        public override string ToString() => $"vfptr:->(SmartBox.Vtbl*)0x{(int)vfptr:X8}, testMode(int):{testMode}, viewer(Position):{viewer}, viewer_cell:->(CObjCell*)0x{(int)viewer_cell:X8}, head_index:{head_index:X8}, viewer_sought_position(Position):{viewer_sought_position}, camera_manager:->(CameraManager*)0x{(int)camera_manager:X8}, cell_manager:->(CellManager*)0x{(int)cell_manager:X8}, physics:->(CPhysics*)0x{(int)physics:X8}, m_pObjMaint:->(CObjectMaint*)0x{(int)m_pObjMaint:X8}, lscape:->(LScape*)0x{(int)lscape:X8}, ambient_sounds:->(Ambient*)0x{(int)ambient_sounds:X8}, cmdinterp:->(CommandInterpreter*)0x{(int)cmdinterp:X8}, creature_mode(int):{creature_mode}, m_fGameFOV:{m_fGameFOV:n5}, m_fViewDistFOV:{m_fViewDistFOV:n5}, m_bUseViewDistance:{m_bUseViewDistance:X2}, game_ambient_level:{game_ambient_level:n5}, game_ambient_color:{game_ambient_color:X8}, game_degrades_disabled(int):{game_degrades_disabled}, hidden(int):{hidden}, position_update_complete(int):{position_update_complete}, waiting_for_teleport(int):{waiting_for_teleport}, has_been_teleported(int):{has_been_teleported}, in_queue:->(NIList<NetBlob>*)0x{(int)in_queue:X8}, netblob_list:->(NIList<NetBlob>*)0x{(int)netblob_list:X8}, position_and_movement_file:->(_iobuf*)0x{(int)position_and_movement_file:X8}, player_id:{player_id:X8}, player:->(CPhysicsObj*)0x{(int)player:X8}, target_object_id:{target_object_id:X8}, num_cells:{num_cells:X8}, cells:->(CEnvCell**)0x{(int)cells:X8}, num_objects:{num_objects:X8}, objects:->(CPhysicsObj**)0x{(int)objects:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<SmartBox*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(SmartBox *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<SmartBox*, NetBlob*, int> IsReadyToDispatchEvent; // int (__thiscall *IsReadyToDispatchEvent)(SmartBox *this, NetBlob *);
            public static delegate* unmanaged[Thiscall]<SmartBox*, NetBlob*, NetBlobProcessedStatus> DispatchSmartBoxEvent; // NetBlobProcessedStatus (__thiscall *DispatchSmartBoxEvent)(SmartBox *this, NetBlob *);
        }

        // Functions:

        // SmartBox.__Ctor:
        public void __Ctor(NIList<NetBlob>* _in_queue) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NIList<NetBlob>*, void>)0x00454640)(ref this, _in_queue); // .text:004545A0 ; void __thiscall SmartBox::SmartBox(SmartBox *this, NIList<NetBlob *> *_in_queue) .text:004545A0 ??0SmartBox@@QAE@PAV?$NIList@PAVNetBlob@@@@@Z

        // SmartBox.BlipPlayer:
        public void BlipPlayer(Position* new_pos) => ((delegate* unmanaged[Thiscall]<ref SmartBox, Position*, void>)0x004539E0)(ref this, new_pos); // .text:00453940 ; void __thiscall SmartBox::BlipPlayer(SmartBox *this, Position *new_pos) .text:00453940 ?BlipPlayer@SmartBox@@IAEXABVPosition@@@Z

        // SmartBox.Cleanup:
        public static void Cleanup(SmartBox* _smartbox) => ((delegate* unmanaged[Cdecl]<SmartBox*, void>)0x004538E0)(_smartbox); // .text:00453840 ; void __cdecl SmartBox::Cleanup(SmartBox *_smartbox) .text:00453840 ?Cleanup@SmartBox@@SAXPAV1@@Z

        // SmartBox.DestroyQueuedNetBlobs:
        public void DestroyQueuedNetBlobs() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x00453AB0)(ref this); // .text:00453A10 ; void __thiscall SmartBox::DestroyQueuedNetBlobs(SmartBox *this) .text:00453A10 ?DestroyQueuedNetBlobs@SmartBox@@IAEXXZ

        // SmartBox.DisableDegrades:
        public static void DisableDegrades(int disable) => ((delegate* unmanaged[Cdecl]<int, void>)0x00451DE0)(disable); // .text:00451DA0 ; void __cdecl SmartBox::DisableDegrades(int disable) .text:00451DA0 ?DisableDegrades@SmartBox@@SAXH@Z

        // SmartBox.DisableFogging:
        public static void DisableFogging(int disable) => ((delegate* unmanaged[Cdecl]<int, void>)0x00451DF0)(disable); // .text:00451DB0 ; void __cdecl SmartBox::DisableFogging(int disable) .text:00451DB0 ?DisableFogging@SmartBox@@SAXH@Z

        // SmartBox.DispatchSmartBoxEvent:
        public NetBlobProcessedStatus DispatchSmartBoxEvent(NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, NetBlobProcessedStatus>)0x00451BB0)(ref this, blob); // .text:00451B70 ; NetBlobProcessedStatus __thiscall SmartBox::DispatchSmartBoxEvent(SmartBox *this, NetBlob *blob) .text:00451B70 ?DispatchSmartBoxEvent@SmartBox@@UAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@@Z

        // SmartBox.DoParentEvent:
        public void DoParentEvent(CPhysicsObj* child, CPhysicsObj* parent, UInt32 child_location, UInt32 placement_id, UInt16 position_stamp) => ((delegate* unmanaged[Thiscall]<ref SmartBox, CPhysicsObj*, CPhysicsObj*, UInt32, UInt32, UInt16, void>)0x004522D0)(ref this, child, parent, child_location, placement_id, position_stamp); // .text:00452290 ; void __thiscall SmartBox::DoParentEvent(SmartBox *this, CPhysicsObj *child, CPhysicsObj *parent, unsigned int child_location, unsigned int placement_id, unsigned __int16 position_stamp) .text:00452290 ?DoParentEvent@SmartBox@@QAEXPAVCPhysicsObj@@0KKG@Z

        // SmartBox.DoPickupEvent:
        public void DoPickupEvent(CPhysicsObj* _object, UInt16 position_timestamp) => ((delegate* unmanaged[Thiscall]<ref SmartBox, CPhysicsObj*, UInt16, void>)0x00452280)(ref this, _object, position_timestamp); // .text:00452240 ; void __thiscall SmartBox::DoPickupEvent(SmartBox *this, CPhysicsObj *object, unsigned __int16 position_timestamp) .text:00452240 ?DoPickupEvent@SmartBox@@QAEXPAVCPhysicsObj@@G@Z

        // SmartBox.DoSetState:
        public void DoSetState(CPhysicsObj* _object, UInt32 state, UInt16 state_timestamp) => ((delegate* unmanaged[Thiscall]<ref SmartBox, CPhysicsObj*, UInt32, UInt16, void>)0x00452110)(ref this, _object, state, state_timestamp); // .text:004520D0 ; void __thiscall SmartBox::DoSetState(SmartBox *this, CPhysicsObj *object, unsigned int state, unsigned __int16 state_timestamp) .text:004520D0 ?DoSetState@SmartBox@@QAEXPAVCPhysicsObj@@KG@Z

        // SmartBox.DoVectorUpdate:
        public void DoVectorUpdate(CPhysicsObj* _object, AC1Legacy.Vector3* velocity, AC1Legacy.Vector3* omega, UInt16 vector_timestamp) => ((delegate* unmanaged[Thiscall]<ref SmartBox, CPhysicsObj*, AC1Legacy.Vector3*, AC1Legacy.Vector3*, UInt16, void>)0x00452200)(ref this, _object, velocity, omega, vector_timestamp); // .text:004521C0 ; void __thiscall SmartBox::DoVectorUpdate(SmartBox *this, CPhysicsObj *object, AC1Legacy::Vector3 *velocity, AC1Legacy::Vector3 *omega, unsigned __int16 vector_timestamp) .text:004521C0 ?DoVectorUpdate@SmartBox@@QAEXPAVCPhysicsObj@@ABVVector3@AC1Legacy@@1G@Z

        // SmartBox.Draw:
        public void Draw() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x00455610)(ref this); // .text:00455570 ; void __thiscall SmartBox::Draw(SmartBox *this) .text:00455570 ?Draw@SmartBox@@QAEXXZ

        // SmartBox.DrawNoBlit:
        // public void DrawNoBlit() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0xDEADBEEF)(ref this); // .text:00454C20 ; void __thiscall SmartBox::DrawNoBlit(SmartBox *this) .text:00454C20 ?DrawNoBlit@SmartBox@@QAEXXZ

        // SmartBox.DrawNoBlit:
        // (ERR) .text:00454CC0 ; public: void __thiscall SmartBox::DrawNoBlit(void) .text:00454CC0 ?DrawNoBlit@SmartBox@@QAEXXZ:

        // SmartBox.EnableWeather:
        public void EnableWeather(int enable) => ((delegate* unmanaged[Thiscall]<ref SmartBox, int, void>)0x00451E10)(ref this, enable); // .text:00451DD0 ; void __thiscall SmartBox::EnableWeather(SmartBox *this, int enable) .text:00451DD0 ?EnableWeather@SmartBox@@QAEXH@Z

        // SmartBox.GetObjectBoundingBox:
        public ObjectSelectStatus GetObjectBoundingBox(UInt32 object_iid, tagRECT* bbox, Single* heading) => ((delegate* unmanaged[Thiscall]<ref SmartBox, UInt32, tagRECT*, Single*, ObjectSelectStatus>)0x00452E60)(ref this, object_iid, bbox, heading); // .text:00452E20 ; ObjectSelectStatus __thiscall SmartBox::GetObjectBoundingBox(SmartBox *this, unsigned int object_iid, tagRECT *bbox, float *heading) .text:00452E20 ?GetObjectBoundingBox@SmartBox@@QBE?AW4ObjectSelectStatus@@KAAUtagRECT@@AAM@Z

        // SmartBox.GetOverrideFovDistance:
        public Single GetOverrideFovDistance() => ((delegate* unmanaged[Thiscall]<ref SmartBox, Single>)0x00451C20)(ref this); // .text:00451BE0 ; float __thiscall SmartBox::GetOverrideFovDistance(SmartBox *this) .text:00451BE0 ?GetOverrideFovDistance@SmartBox@@QAEMXZ

        // SmartBox.HandleCreateObject:
        public NetBlobProcessedStatus HandleCreateObject(NetBlob* blob, UInt32 object_id, VisualDesc* vdesc, PhysicsDesc* physicsdesc, WeenieDesc* wdesc, int force_recreate) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, VisualDesc*, PhysicsDesc*, WeenieDesc*, int, NetBlobProcessedStatus>)0x00454D20)(ref this, blob, object_id, vdesc, physicsdesc, wdesc, force_recreate); // .text:00454C80 ; NetBlobProcessedStatus __thiscall SmartBox::HandleCreateObject(SmartBox *this, NetBlob *blob, unsigned int object_id, VisualDesc *vdesc, PhysicsDesc *physicsdesc, WeenieDesc *wdesc, int force_recreate) .text:00454C80 ?HandleCreateObject@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KABVVisualDesc@@ABVPhysicsDesc@@ABVWeenieDesc@@H@Z

        // SmartBox.HandleCreatePlayer:
        public NetBlobProcessedStatus HandleCreatePlayer(NetBlob* blob, UInt32 object_id) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, NetBlobProcessedStatus>)0x004551B0)(ref this, blob, object_id); // .text:00455110 ; NetBlobProcessedStatus __thiscall SmartBox::HandleCreatePlayer(SmartBox *this, NetBlob *blob, unsigned int object_id) .text:00455110 ?HandleCreatePlayer@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@K@Z

        // SmartBox.HandleDeleteObject:
        public NetBlobProcessedStatus HandleDeleteObject(NetBlob* blob, UInt32 object_id, UInt16 instance_timestamp) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, UInt16, NetBlobProcessedStatus>)0x00451EE0)(ref this, blob, object_id, instance_timestamp); // .text:00451EA0 ; NetBlobProcessedStatus __thiscall SmartBox::HandleDeleteObject(SmartBox *this, NetBlob *blob, unsigned int object_id, unsigned __int16 instance_timestamp) .text:00451EA0 ?HandleDeleteObject@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KG@Z

        // SmartBox.HandleObjDescEvent:
        public NetBlobProcessedStatus HandleObjDescEvent(NetBlob* blob, UInt32 object_id, VisualDesc* vdesc, PhysicsTimestampPack* timestamps) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, VisualDesc*, PhysicsTimestampPack*, NetBlobProcessedStatus>)0x00453380)(ref this, blob, object_id, vdesc, timestamps); // .text:00453340 ; NetBlobProcessedStatus __thiscall SmartBox::HandleObjDescEvent(SmartBox *this, NetBlob *blob, unsigned int object_id, VisualDesc *vdesc, PhysicsTimestampPack *timestamps) .text:00453340 ?HandleObjDescEvent@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KABVVisualDesc@@ABVPhysicsTimestampPack@@@Z

        // SmartBox.HandleParentEvent:
        public NetBlobProcessedStatus HandleParentEvent(NetBlob* blob, UInt32 object_id, UInt32 child_id, UInt32 child_location, UInt32 placement_id, PhysicsTimestampPack* timestamps) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, UInt32, UInt32, UInt32, PhysicsTimestampPack*, NetBlobProcessedStatus>)0x00453610)(ref this, blob, object_id, child_id, child_location, placement_id, timestamps); // .text:004535D0 ; NetBlobProcessedStatus __thiscall SmartBox::HandleParentEvent(SmartBox *this, NetBlob *blob, unsigned int object_id, unsigned int child_id, unsigned int child_location, unsigned int placement_id, PhysicsTimestampPack *timestamps) .text:004535D0 ?HandleParentEvent@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KKKKABVPhysicsTimestampPack@@@Z

        // SmartBox.HandlePickupEvent:
        public NetBlobProcessedStatus HandlePickupEvent(NetBlob* blob, UInt32 object_id, PhysicsTimestampPack* timestamps) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, PhysicsTimestampPack*, NetBlobProcessedStatus>)0x00453570)(ref this, blob, object_id, timestamps); // .text:00453530 ; NetBlobProcessedStatus __thiscall SmartBox::HandlePickupEvent(SmartBox *this, NetBlob *blob, unsigned int object_id, PhysicsTimestampPack *timestamps) .text:00453530 ?HandlePickupEvent@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KABVPhysicsTimestampPack@@@Z

        // SmartBox.HandlePlayScriptID:
        public NetBlobProcessedStatus HandlePlayScriptID(NetBlob* blob, UInt32 object_id, UInt32 script_id) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, UInt32, NetBlobProcessedStatus>)0x00452060)(ref this, blob, object_id, script_id); // .text:00452020 ; NetBlobProcessedStatus __thiscall SmartBox::HandlePlayScriptID(SmartBox *this, NetBlob *blob, unsigned int object_id, IDClass<_tagDataID,32,0> script_id) .text:00452020 ?HandlePlayScriptID@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // SmartBox.HandlePlayScriptType:
        public NetBlobProcessedStatus HandlePlayScriptType(NetBlob* blob, UInt32 object_id, int script_type, Single mod) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, int, Single, NetBlobProcessedStatus>)0x004520B0)(ref this, blob, object_id, script_type, mod); // .text:00452070 ; NetBlobProcessedStatus __thiscall SmartBox::HandlePlayScriptType(SmartBox *this, NetBlob *blob, unsigned int object_id, int script_type, float mod) .text:00452070 ?HandlePlayScriptType@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KJM@Z

        // SmartBox.HandlePlayerTeleport:
        public NetBlobProcessedStatus HandlePlayerTeleport(NetBlob* blob, UInt16 physics_timestamp) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt16, NetBlobProcessedStatus>)0x00452190)(ref this, blob, physics_timestamp); // .text:00452150 ; NetBlobProcessedStatus __thiscall SmartBox::HandlePlayerTeleport(SmartBox *this, NetBlob *blob, unsigned __int16 physics_timestamp) .text:00452150 ?HandlePlayerTeleport@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@G@Z

        // SmartBox.HandleReceivedPosition:
        public void HandleReceivedPosition(CPhysicsObj* _object, Position* position, UInt32 placement_id, int has_contact, AC1Legacy.Vector3* velocity, UInt16 position_timestamp, UInt16 teleport_timestamp, UInt16 force_position_timestamp) => ((delegate* unmanaged[Thiscall]<ref SmartBox, CPhysicsObj*, Position*, UInt32, int, AC1Legacy.Vector3*, UInt16, UInt16, UInt16, void>)0x00454070)(ref this, _object, position, placement_id, has_contact, velocity, position_timestamp, teleport_timestamp, force_position_timestamp); // .text:00453FD0 ; void __thiscall SmartBox::HandleReceivedPosition(SmartBox *this, CPhysicsObj *object, Position *position, unsigned int placement_id, int has_contact, AC1Legacy::Vector3 *velocity, unsigned __int16 position_timestamp, unsigned __int16 teleport_timestamp, unsigned __int16 force_position_timestamp) .text:00453FD0 ?HandleReceivedPosition@SmartBox@@QAEXPAVCPhysicsObj@@ABVPosition@@KHABVVector3@AC1Legacy@@GGG@Z

        // SmartBox.HandleRenderOption:
        public int HandleRenderOption(int argc, char** argv, char** status_string, char** textbox_string) => ((delegate* unmanaged[Thiscall]<ref SmartBox, int, char**, char**, char**, int>)0x00451E60)(ref this, argc, argv, status_string, textbox_string); // .text:00451E20 ; int __thiscall SmartBox::HandleRenderOption(SmartBox *this, int argc, char **argv, const char **status_string, const char **textbox_string) .text:00451E20 ?HandleRenderOption@SmartBox@@QAEHHPAPADAAPBD1@Z

        // SmartBox.HandleSetState:
        public NetBlobProcessedStatus HandleSetState(NetBlob* blob, UInt32 object_id, UInt32 new_state, PhysicsTimestampPack* timestamps) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, UInt32, PhysicsTimestampPack*, NetBlobProcessedStatus>)0x00453420)(ref this, blob, object_id, new_state, timestamps); // .text:004533E0 ; NetBlobProcessedStatus __thiscall SmartBox::HandleSetState(SmartBox *this, NetBlob *blob, unsigned int object_id, unsigned int new_state, PhysicsTimestampPack *timestamps) .text:004533E0 ?HandleSetState@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KKABVPhysicsTimestampPack@@@Z

        // SmartBox.HandleSoundEvent:
        public NetBlobProcessedStatus HandleSoundEvent(NetBlob* blob, UInt32 object_id, int sound, Single volume) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, int, Single, NetBlobProcessedStatus>)0x00452000)(ref this, blob, object_id, sound, volume); // .text:00451FC0 ; NetBlobProcessedStatus __thiscall SmartBox::HandleSoundEvent(SmartBox *this, NetBlob *blob, unsigned int object_id, int sound, float volume) .text:00451FC0 ?HandleSoundEvent@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KJM@Z

        // SmartBox.HandleUpdateObject:
        public NetBlobProcessedStatus HandleUpdateObject(NetBlob* blob, UInt32 object_id, VisualDesc* objdesc, PhysicsDesc* physicsdesc, WeenieDesc* wdesc) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, VisualDesc*, PhysicsDesc*, WeenieDesc*, NetBlobProcessedStatus>)0x00455620)(ref this, blob, object_id, objdesc, physicsdesc, wdesc); // .text:00455580 ; NetBlobProcessedStatus __thiscall SmartBox::HandleUpdateObject(SmartBox *this, NetBlob *blob, unsigned int object_id, VisualDesc *objdesc, PhysicsDesc *physicsdesc, WeenieDesc *wdesc) .text:00455580 ?HandleUpdateObject@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KABVVisualDesc@@ABVPhysicsDesc@@ABVWeenieDesc@@@Z

        // SmartBox.HandleVectorUpdate:
        public NetBlobProcessedStatus HandleVectorUpdate(NetBlob* blob, UInt32 object_id, AC1Legacy.Vector3* velocity, AC1Legacy.Vector3* omega, PhysicsTimestampPack* timestamps) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, UInt32, AC1Legacy.Vector3*, AC1Legacy.Vector3*, PhysicsTimestampPack*, NetBlobProcessedStatus>)0x004534C0)(ref this, blob, object_id, velocity, omega, timestamps); // .text:00453480 ; NetBlobProcessedStatus __thiscall SmartBox::HandleVectorUpdate(SmartBox *this, NetBlob *blob, unsigned int object_id, AC1Legacy::Vector3 *velocity, AC1Legacy::Vector3 *omega, PhysicsTimestampPack *timestamps) .text:00453480 ?HandleVectorUpdate@SmartBox@@QAE?AW4NetBlobProcessedStatus@@PAVNetBlob@@KABVVector3@AC1Legacy@@1ABVPhysicsTimestampPack@@@Z

        // SmartBox.Hide:
        public void Hide() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x00451D80)(ref this); // .text:00451D40 ; void __thiscall SmartBox::Hide(SmartBox *this) .text:00451D40 ?Hide@SmartBox@@QAEXXZ

        // SmartBox.Init:
        public static SmartBox* Init(NIList<NetBlob>* _in_queue, int test_mode) => ((delegate* unmanaged[Cdecl]<NIList<NetBlob>*, int, SmartBox*>)0x00455710)(_in_queue, test_mode); // .text:00455670 ; SmartBox *__cdecl SmartBox::Init(NIList<NetBlob *> *_in_queue, int test_mode) .text:00455670 ?Init@SmartBox@@SAPAV1@PAV?$NIList@PAVNetBlob@@@@H@Z

        // SmartBox.InitInternal:
        public Byte InitInternal(NIList<NetBlob>* _in_queue) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NIList<NetBlob>*, Byte>)0x00455290)(ref this, _in_queue); // .text:004551F0 ; bool __thiscall SmartBox::InitInternal(SmartBox *this, NIList<NetBlob *> *_in_queue) .text:004551F0 ?InitInternal@SmartBox@@IAE_NPAV?$NIList@PAVNetBlob@@@@@Z

        // SmartBox.PlayerPhysicsUpdatedCallback:
        public void PlayerPhysicsUpdatedCallback() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x00452DA0)(ref this); // .text:00452D60 ; void __thiscall SmartBox::PlayerPhysicsUpdatedCallback(SmartBox *this) .text:00452D60 ?PlayerPhysicsUpdatedCallback@SmartBox@@QAEXXZ

        // SmartBox.PlayerPositionUpdated:
        public void PlayerPositionUpdated(int teleporting, Single distance_moved) => ((delegate* unmanaged[Thiscall]<ref SmartBox, int, Single, void>)0x00453910)(ref this, teleporting, distance_moved); // .text:00453870 ; void __thiscall SmartBox::PlayerPositionUpdated(SmartBox *this, int teleporting, float distance_moved) .text:00453870 ?PlayerPositionUpdated@SmartBox@@IAEXHM@Z

        // SmartBox.ProcessNetBlobs:
        public void ProcessNetBlobs() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x00454B10)(ref this); // .text:00454A70 ; void __thiscall SmartBox::ProcessNetBlobs(SmartBox *this) .text:00454A70 ?ProcessNetBlobs@SmartBox@@IAEXXZ

        // SmartBox.ProcessObjectNetBlobs:
        public void ProcessObjectNetBlobs(CPhysicsObj* _object) => ((delegate* unmanaged[Thiscall]<ref SmartBox, CPhysicsObj*, void>)0x00454BC0)(ref this, _object); // .text:00454B20 ; void __thiscall SmartBox::ProcessObjectNetBlobs(SmartBox *this, CPhysicsObj *object) .text:00454B20 ?ProcessObjectNetBlobs@SmartBox@@IAEXPAVCPhysicsObj@@@Z

        // SmartBox.QueueBlobForObject:
        public void QueueBlobForObject(UInt32 object_id, NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref SmartBox, UInt32, NetBlob*, void>)0x00451BD0)(ref this, object_id, blob); // .text:00451B90 ; void __thiscall SmartBox::QueueBlobForObject(SmartBox *this, unsigned int object_id, NetBlob *blob) .text:00451B90 ?QueueBlobForObject@SmartBox@@IAEXKPAVNetBlob@@@Z

        // SmartBox.QueueNetBlob:
        public void QueueNetBlob(NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref SmartBox, NetBlob*, void>)0x00453A20)(ref this, blob); // .text:00453980 ; void __thiscall SmartBox::QueueNetBlob(SmartBox *this, NetBlob *blob) .text:00453980 ?QueueNetBlob@SmartBox@@IAEXPAVNetBlob@@@Z

        // SmartBox.RenderNormalMode:
        public void RenderNormalMode() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x00453B40)(ref this); // .text:00453AA0 ; void __thiscall SmartBox::RenderNormalMode(SmartBox *this) .text:00453AA0 ?RenderNormalMode@SmartBox@@IAEXXZ

        // SmartBox.Reset:
        public void Reset(int clear_objects) => ((delegate* unmanaged[Thiscall]<ref SmartBox, int, void>)0x00453C90)(ref this, clear_objects); // .text:00453BF0 ; void __thiscall SmartBox::Reset(SmartBox *this, int clear_objects) .text:00453BF0 ?Reset@SmartBox@@QAEXH@Z

        // SmartBox.ResetDetailTexturing:
        public static Byte ResetDetailTexturing() => ((delegate* unmanaged[Cdecl]<Byte>)0x004530B0)(); // .text:00453070 ; bool __cdecl SmartBox::ResetDetailTexturing() .text:00453070 ?ResetDetailTexturing@SmartBox@@SA_NXZ

        // SmartBox.SetDefaultFov:
        public void SetDefaultFov(Single degrees) => ((delegate* unmanaged[Thiscall]<ref SmartBox, Single, void>)0x00451EA0)(ref this, degrees); // .text:00451E60 ; void __thiscall SmartBox::SetDefaultFov(SmartBox *this, float degrees) .text:00451E60 ?SetDefaultFov@SmartBox@@QAEXM@Z

        // SmartBox.SetDetailTexturing:
        public Byte SetDetailTexturing(Byte landscape, Byte environment) => ((delegate* unmanaged[Thiscall]<ref SmartBox, Byte, Byte, Byte>)0x00451E30)(ref this, landscape, environment); // .text:00451DF0 ; bool __thiscall SmartBox::SetDetailTexturing(SmartBox *this, bool landscape, bool environment) .text:00451DF0 ?SetDetailTexturing@SmartBox@@QAE_N_N0@Z

        // SmartBox.SetMode:
        public int SetMode(int _x, int _y, int _width, int _height) => ((delegate* unmanaged[Thiscall]<ref SmartBox, int, int, int, int, int>)0x00451D90)(ref this, _x, _y, _width, _height); // .text:00451D50 ; int __thiscall SmartBox::SetMode(SmartBox *this, int _x, int _y, int _width, int _height) .text:00451D50 ?SetMode@SmartBox@@QAEHHHHH@Z

        // SmartBox.SetNormalMode:
        public int SetNormalMode() => ((delegate* unmanaged[Thiscall]<ref SmartBox, int>)0x00453160)(ref this); // .text:00453120 ; int __thiscall SmartBox::SetNormalMode(SmartBox *this) .text:00453120 ?SetNormalMode@SmartBox@@QAEHXZ

        // SmartBox.SetOverrideFovDistance:
        public void SetOverrideFovDistance(Byte fEnable, Single i_vdst) => ((delegate* unmanaged[Thiscall]<ref SmartBox, Byte, Single, void>)0x00451C00)(ref this, fEnable, i_vdst); // .text:00451BC0 ; void __thiscall SmartBox::SetOverrideFovDistance(SmartBox *this, bool fEnable, float i_vdst) .text:00451BC0 ?SetOverrideFovDistance@SmartBox@@QAEX_NM@Z

        // SmartBox.SetRegion:
        public int SetRegion(UInt32 region_num) => ((delegate* unmanaged[Thiscall]<ref SmartBox, UInt32, int>)0x00453230)(ref this, region_num); // .text:004531F0 ; int __thiscall SmartBox::SetRegion(SmartBox *this, unsigned int region_num) .text:004531F0 ?SetRegion@SmartBox@@QAEHK@Z

        // SmartBox.SetTargetObjectID:
        public void SetTargetObjectID(UInt32 new_target_object_id) => ((delegate* unmanaged[Thiscall]<ref SmartBox, UInt32, void>)0x00451D60)(ref this, new_target_object_id); // .text:00451D20 ; void __thiscall SmartBox::SetTargetObjectID(SmartBox *this, unsigned int new_target_object_id) .text:00451D20 ?SetTargetObjectID@SmartBox@@QAEXK@Z

        // SmartBox.SetTargettingCallback:
        public void SetTargettingCallback(delegate* unmanaged[Cdecl]<UInt32, ObjectSelectStatus, tagRECT*, Single> targetting_callback_func) => ((delegate* unmanaged[Thiscall]<ref SmartBox, delegate* unmanaged[Cdecl]<UInt32, ObjectSelectStatus, tagRECT*, Single>, void>)0x00451D50)(ref this, targetting_callback_func); // .text:00451D10 ; void __thiscall SmartBox::SetTargettingCallback(SmartBox *this, void (__cdecl *targetting_callback_func)(unsigned int, ObjectSelectStatus, tagRECT *, const float)) .text:00451D10 ?SetTargettingCallback@SmartBox@@QAEXP6AXKW4ObjectSelectStatus@@ABUtagRECT@@M@Z@Z

        // SmartBox.SetWorldAmbientLight:
        public void SetWorldAmbientLight(Single intensity, UInt32 color) => ((delegate* unmanaged[Thiscall]<ref SmartBox, Single, UInt32, void>)0x004530E0)(ref this, intensity, color); // .text:004530A0 ; void __thiscall SmartBox::SetWorldAmbientLight(SmartBox *this, float intensity, unsigned int color) .text:004530A0 ?SetWorldAmbientLight@SmartBox@@QAEXMK@Z

        // SmartBox.Show:
        public void Show() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x00451D70)(ref this); // .text:00451D30 ; void __thiscall SmartBox::Show(SmartBox *this) .text:00451D30 ?Show@SmartBox@@QAEXXZ

        // SmartBox.TeleportPlayer:
        public void TeleportPlayer(Position* new_pos) => ((delegate* unmanaged[Thiscall]<ref SmartBox, Position*, void>)0x004539B0)(ref this, new_pos); // .text:00453910 ; void __thiscall SmartBox::TeleportPlayer(SmartBox *this, Position *new_pos) .text:00453910 ?TeleportPlayer@SmartBox@@IAEXABVPosition@@@Z

        // SmartBox.UnpackPositionEvent:
        public NetBlobProcessedStatus UnpackPositionEvent(UInt32 object_id, void** buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref SmartBox, UInt32, void**, UInt32, NetBlobProcessedStatus>)0x00454360)(ref this, object_id, buff, size); // .text:004542C0 ; NetBlobProcessedStatus __thiscall SmartBox::UnpackPositionEvent(SmartBox *this, unsigned int object_id, void **buff, unsigned int size) .text:004542C0 ?UnpackPositionEvent@SmartBox@@QAE?AW4NetBlobProcessedStatus@@KAAPAXI@Z

        // SmartBox.UpdateVisualDesc:
        public int UpdateVisualDesc(CPhysicsObj* _object, VisualDesc* vdesc, UInt16 vdesc_ts) => ((delegate* unmanaged[Thiscall]<ref SmartBox, CPhysicsObj*, VisualDesc*, UInt16, int>)0x00451F80)(ref this, _object, vdesc, vdesc_ts); // .text:00451F40 ; int __thiscall SmartBox::UpdateVisualDesc(SmartBox *this, CPhysicsObj *object, VisualDesc *vdesc, unsigned __int16 vdesc_ts) .text:00451F40 ?UpdateVisualDesc@SmartBox@@QAEHPAVCPhysicsObj@@ABVVisualDesc@@G@Z

        // SmartBox.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x004554B0)(ref this); // .text:00455410 ; void __thiscall SmartBox::UseTime(SmartBox *this) .text:00455410 ?UseTime@SmartBox@@QAEXXZ

        // SmartBox.convert_to_player_space:
        public int convert_to_player_space(CPhysicsObj* _object, AC1Legacy.Vector3* _return_vector) => ((delegate* unmanaged[Thiscall]<ref SmartBox, CPhysicsObj*, AC1Legacy.Vector3*, int>)0x00452DE0)(ref this, _object, _return_vector); // .text:00452DA0 ; int __thiscall SmartBox::convert_to_player_space(SmartBox *this, CPhysicsObj *object, AC1Legacy::Vector3 *_return_vector) .text:00452DA0 ?convert_to_player_space@SmartBox@@QBEHPAVCPhysicsObj@@AAVVector3@AC1Legacy@@@Z

        // SmartBox.find_object:
        public static Byte find_object(UInt32 _mouseX, UInt32 _mouseY) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x00451CA0)(_mouseX, _mouseY); // .text:00451C60 ; bool __cdecl SmartBox::find_object(unsigned int _mouseX, unsigned int _mouseY) .text:00451C60 ?find_object@SmartBox@@SA_NKK@Z

        // SmartBox.get_found_object_id:
        public static UInt32 get_found_object_id() => ((delegate* unmanaged[Cdecl]<UInt32>)0x00451D20)(); // .text:00451CE0 ; unsigned int __cdecl SmartBox::get_found_object_id() .text:00451CE0 ?get_found_object_id@SmartBox@@SAKXZ

        // SmartBox.get_player_visualdesc:
        public VisualDesc* get_player_visualdesc() => ((delegate* unmanaged[Thiscall]<ref SmartBox, VisualDesc*>)0x00451BC0)(ref this); // .text:00451B80 ; VisualDesc *__thiscall SmartBox::get_player_visualdesc(SmartBox *this) .text:00451B80 ?get_player_visualdesc@SmartBox@@QBEPAVVisualDesc@@XZ

        // SmartBox.init_player:
        public void init_player(CPhysicsObj* player_object, int autonomous) => ((delegate* unmanaged[Thiscall]<ref SmartBox, CPhysicsObj*, int, void>)0x00453D20)(ref this, player_object, autonomous); // .text:00453C80 ; void __thiscall SmartBox::init_player(SmartBox *this, CPhysicsObj *player_object, int autonomous) .text:00453C80 ?init_player@SmartBox@@IAEXPAVCPhysicsObj@@H@Z

        // SmartBox.is_player_outside:
        public int is_player_outside() => ((delegate* unmanaged[Thiscall]<ref SmartBox, int>)0x00451EC0)(ref this); // .text:00451E80 ; int __thiscall SmartBox::is_player_outside(SmartBox *this) .text:00451E80 ?is_player_outside@SmartBox@@QBEHXZ

        // SmartBox.is_selected_object_in_view:
        public static Byte is_selected_object_in_view() => ((delegate* unmanaged[Cdecl]<Byte>)0x00451BF0)(); // .text:00451BB0 ; bool __cdecl SmartBox::is_selected_object_in_view() .text:00451BB0 ?is_selected_object_in_view@SmartBox@@SA_NXZ

        // SmartBox.set_found_object:
        public static void set_found_object(UInt32 iid, UInt32 index) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, void>)0x00451D30)(iid, index); // .text:00451CF0 ; void __cdecl SmartBox::set_found_object(unsigned int iid, unsigned int index) .text:00451CF0 ?set_found_object@SmartBox@@SAXKK@Z

        // SmartBox.set_mid_radius:
        public int set_mid_radius(int mid_radius) => ((delegate* unmanaged[Thiscall]<ref SmartBox, int, int>)0x004531C0)(ref this, mid_radius); // .text:00453180 ; int __thiscall SmartBox::set_mid_radius(SmartBox *this, int mid_radius) .text:00453180 ?set_mid_radius@SmartBox@@QAEHJ@Z

        // SmartBox.set_selected_object_id:
        public static void set_selected_object_id(UInt32 _id) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x00451BE0)(_id); // .text:00451BA0 ; void __cdecl SmartBox::set_selected_object_id(unsigned int _id) .text:00451BA0 ?set_selected_object_id@SmartBox@@SAXK@Z

        // SmartBox.set_viewer:
        public void set_viewer(Position* new_viewer, int set_sought_position) => ((delegate* unmanaged[Thiscall]<ref SmartBox, Position*, int, void>)0x00452C80)(ref this, new_viewer, set_sought_position); // .text:00452C40 ; void __thiscall SmartBox::set_viewer(SmartBox *this, Position *new_viewer, int set_sought_position) .text:00452C40 ?set_viewer@SmartBox@@QAEXABVPosition@@H@Z

        // SmartBox.set_viewer_home:
        public void set_viewer_home() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x00453280)(ref this); // .text:00453240 ; void __thiscall SmartBox::set_viewer_home(SmartBox *this) .text:00453240 ?set_viewer_home@SmartBox@@QAEXXZ

        // SmartBox.teleport_in_progress:
        public Byte teleport_in_progress() => ((delegate* unmanaged[Thiscall]<ref SmartBox, Byte>)0x00451C60)(ref this); // .text:00451C20 ; bool __thiscall SmartBox::teleport_in_progress(SmartBox *this) .text:00451C20 ?teleport_in_progress@SmartBox@@QAE_NXZ

        // SmartBox.teleport_occured:
        public int teleport_occured() => ((delegate* unmanaged[Thiscall]<ref SmartBox, int>)0x00451C80)(ref this); // .text:00451C40 ; int __thiscall SmartBox::teleport_occured(SmartBox *this) .text:00451C40 ?teleport_occured@SmartBox@@QAEHXZ

        // SmartBox.update_viewer:
        public void update_viewer() => ((delegate* unmanaged[Thiscall]<ref SmartBox, void>)0x00453D80)(ref this); // .text:00453CE0 ; void __thiscall SmartBox::update_viewer(SmartBox *this) .text:00453CE0 ?update_viewer@SmartBox@@IAEXXZ

        // Globals:
        public static int* click_object_index = (int*)0x00819618; // .data:00818618 ; int SmartBox::click_object_index .data:00818618 ?click_object_index@SmartBox@@1HA
        public static UInt32* click_object_id = (UInt32*)0x0083DA44; // .data:0083CA44 ; unsigned int SmartBox::click_object_id .data:0083CA44 ?click_object_id@SmartBox@@1KA
        public static UInt32* m_cyWindowFindPos = (UInt32*)0x0083DA50; // .data:0083CA50 ; unsigned int SmartBox::m_cyWindowFindPos .data:0083CA50 ?m_cyWindowFindPos@SmartBox@@1KA
        public static Single* s_fViewerLightFalloff = (Single*)0x00819610; // .data:00818610 ; float SmartBox::s_fViewerLightFalloff .data:00818610 ?s_fViewerLightFalloff@SmartBox@@1MA
        public static UInt32* m_cxWindowFindPos = (UInt32*)0x0083DA4C; // .data:0083CA4C ; unsigned int SmartBox::m_cxWindowFindPos .data:0083CA4C ?m_cxWindowFindPos@SmartBox@@1KA
        public static int* clear_screen = (int*)0x0083DA54; // .data:0083CA54 ; int SmartBox::clear_screen .data:0083CA54 ?clear_screen@SmartBox@@1HA
        public static SmartBox** smartbox = (SmartBox**)0x0083DA58; // .data:0083CA58 ; SmartBox *SmartBox::smartbox .data:0083CA58 ?smartbox@SmartBox@@1PAV1@A
        public static Single* s_fViewerLightIntensity = (Single*)0x0083DC10; // .data:0083CC10 ; float SmartBox::s_fViewerLightIntensity .data:0083CC10 ?s_fViewerLightIntensity@SmartBox@@1MA
        public static Byte* lookingForObject = (Byte*)0x0083DA48; // .data:0083CA48 ; bool SmartBox::lookingForObject .data:0083CA48 ?lookingForObject@SmartBox@@1_NA
    }


    public unsafe struct PhysicsTimestampPack {
        public PackObj packObj;
        public UInt16 ts1;
        public UInt16 ts2;
    };
    public unsafe struct VisualDesc {
        public PackObj packObj;
    };
    public unsafe struct PhysicsDesc {
        public PackObj packObj;
        public UInt32 bitfield;
        public void* movement_buffer;
        public UInt32 buff_length;
        public Int32 autonomous_movement;
        public UInt32 animframe_id;
        public Position pos;
        public UInt32 state;
        public Single object_scale;
        public Single friction;
        public Single elasticity;
        public Single translucency;
        public Vector3 velocity;
        public Vector3 acceleration;
        public Vector3 omega;
        public UInt32 num_children;
        public UInt32* child_ids;
        public UInt32* child_location_ids;
        public UInt32 parent_id;
        public UInt32 location_id;
        public UInt32 mtable_id; // IDClass<_tagDataID, 32, 0>
        public UInt32 stable_id; // IDClass<_tagDataID, 32, 0>
        public UInt32 phstable_id; // IDClass<_tagDataID, 32, 0>
        public PScriptType default_script;
        public Single default_script_Int32ensity;
        public UInt32 setup_id; // IDClass<_tagDataID, 32, 0>
        public fixed UInt16 timestamps[9];
    };

    public unsafe struct CameraManager {
        public CInputHandler cInputHandler;
        public IInputActionCallback iInputActionCallback;
        public Single t_stiffness;
        public Single r_stiffness;
        public UInt32 pivot_object_id;
        public Int32 pivot_part_index;
        public Vector3 pivot_offset;
        public UInt32 target_object_id;
        public Int32 target_part_index;
        public Vector3 target_offset;
        public Vector3 direction;
        public CameraTarget target_status;
        public Vector3 viewer_offset;
        public bool m_bAlignCameraToSlope;
        public Single m_rCameraStiffness;
        public Single m_rCameraAdjustmentSpeed;
        public UInt32 m_dwPivotOffsetMovement;
        public UInt32 m_dwCameraOffsetMovement;
        public Single m_rMovementSpeed;
        public Single scale;
        public Double last_update_time;
        public Vector3 old_velocities_0;
        public Vector3 old_velocities_1;
        public Vector3 old_velocities_2;
        public Vector3 old_velocities_3;
        public Vector3 old_velocities_4;
        public Int32 old_velocity_num;
        public bool m_bEnabled;
        public CameraSet* m_pCurrentCameraSet;
    };
    public unsafe struct CameraSet {
        public Turbine_RefCount _ref;
        public CameraManager* cm;
        public SmartBox* sbox;
        public Int32 looking_down;
        public Int32 in_map_mode;
        public Int32 mouselook_active;
        public Int32 camera_movement_active;
        public Int32 targeting;
        public Int32 rot_left;
        public Int32 rot_right;
        public Int32 lower;
        public Int32 raise;
        public Int32 farther;
        public Int32 closer;
        public Single current_stiffness;
        public Int16 mouselook_x_extent;
        public Int16 mouselook_y_extent;
        public Vector3 lookdown_saved_offset;
        public Vector3 lookdown_saved_target_dir;
        public Double m_ttLastRotate;
        public Double m_ttLastRaiseOrLower;
        public Double m_ttLastZoom;
        public Double m_LastServerMessage;
        public Double m_LastMouseMovement;
    };

    public unsafe struct CameraSet_ {
        // Struct:
        public Turbine_RefCount _ref;
        public CameraManager* cm;
        public SmartBox* sbox;
        public Int32 looking_down;
        public Int32 in_map_mode;
        public Int32 mouselook_active;
        public Int32 camera_movement_active;
        public Int32 targeting;
        public Int32 rot_left;
        public Int32 rot_right;
        public Int32 lower;
        public Int32 raise;
        public Int32 farther;
        public Int32 closer;
        public Single current_stiffness;
        public Int16 mouselook_x_extent;
        public Int16 mouselook_y_extent;
        public Vector3 lookdown_saved_offset;
        public Vector3 lookdown_saved_target_dir;
        public Double m_ttLastRotate;
        public Double m_ttLastRaiseOrLower;
        public Double m_ttLastZoom;
        public Double m_LastServerMessage;
        public Double m_LastMouseMovement;

        // Functions:
        // .text:004587F0 ; Int32 __stdcall CameraSet::Closer(Int32, Single)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, Single, void> Closer = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, Single, void>)0xDEADBEEF; // .text:004586D0 ; void __thiscall CameraSet::Closer(CameraSet *this, Int32 keep_going, Single i_fChangeModOverride)
                                                                                                                                                                    // .text:004589B0 ; public: void __thiscall CameraSet::Farther(Int32,Single)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, Single, void> Farther = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, Single, void>)0xDEADBEEF; // .text:00458890 ; void __thiscall CameraSet::Farther(CameraSet *this, Int32 keep_going, Single i_fChangeModOverride)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Single, Single, Single, Single*, Single*, void> FilterMouseInput = (delegate* unmanaged[Thiscall]<CameraSet*, Single, Single, Single, Single*, Single*, void>)0xDEADBEEF; // .text:00457530 ; void __thiscall CameraSet::FilterMouseInput(CameraSet *this, const Single _DeltaX, const Single _DeltaY, const Single _MouseSmoothingAmount, Single *o_FilteredX, Single *o_FilteredY)
                                                                                                                                                                                                                                // .text:00457650 ; Int32 __stdcall CameraSet::FilterMouseInput(Single, Single, Single, Int32, Int32)
                                                                                                                                                                                                                                // .text:004577A0 ; public: Int32 __thiscall CameraSet::InHead(void)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32> InHead = (delegate* unmanaged[Thiscall]<CameraSet*, Int32>)0xDEADBEEF; // .text:00457680 ; Int32 __thiscall CameraSet::InHead(CameraSet *this)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Vector3, Int32> InHead_ = (delegate* unmanaged[Thiscall]<CameraSet*, Vector3, Int32>)0xDEADBEEF; // .text:00457450 ; Int32 __thiscall CameraSet::InHead(CameraSet *this, AC1Legacy::Vector3 camera_off)
                                                                                                                                                             // .text:00457570 ; Int32 __stdcall CameraSet::InHead(Single, Single, Single)
                                                                                                                                                             // .text:00458110 ; public: void __thiscall CameraSet::LookDown(Int32)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, void> LookDown = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, void>)0xDEADBEEF; // .text:00457FF0 ; void __thiscall CameraSet::LookDown(CameraSet *this, Int32 look_down)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, Single, void> Lower = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, Single, void>)0xDEADBEEF; // .text:00457CF0 ; void __thiscall CameraSet::Lower(CameraSet *this, Int32 keep_going, Single i_fChangeModOverride)
                                                                                                                                                                   // .text:00457E10 ; Int32 __stdcall CameraSet::Lower(Int32, Single)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, Int32, void> MouseLookHandler = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, Int32, void>)0xDEADBEEF; // .text:00458D80 ; void __thiscall CameraSet::MouseLookHandler(CameraSet *this, Int32 i_nXMove, Int32 i_nYMove)
                                                                                                                                                                          // .text:00458EA0 ; Int32 __stdcall CameraSet::MouseLookHandler(Single, Int32)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, Single, void> Raise = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, Single, void>)0xDEADBEEF; // .text:00457980 ; void __thiscall CameraSet::Raise(CameraSet *this, Int32 keep_going, Single i_fChangeModOverride)
                                                                                                                                                                   // .text:00457AA0 ; Int32 __stdcall CameraSet::Raise(Int32, Single)
                                                                                                                                                                   // .text:00458430 ; Int32 __stdcall CameraSet::Rotate(Int32, Int32, Single, Int32)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, Int32, Single, Int32, void> Rotate = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, Int32, Single, Int32, void>)0xDEADBEEF; // .text:00458310 ; void __thiscall CameraSet::Rotate(CameraSet *this, Int32 clockwise_dir, Int32 keep_going, Single i_fChangeModOverride, Int32 camera_keys)
                                                                                                                                                                                        // .text:004590A0 ; public: void __thiscall CameraSet::SetDefaultOffsets(Int32)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, void> SetDefaultOffsets = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, void>)0xDEADBEEF; // .text:00458F80 ; void __thiscall CameraSet::SetDefaultOffsets(CameraSet *this, Int32 move_camera)
        public static delegate* unmanaged[Thiscall]<CameraSet*, void> SetInHead = (delegate* unmanaged[Thiscall]<CameraSet*, void>)0xDEADBEEF; // .text:00458CE0 ; void __thiscall CameraSet::SetInHead(CameraSet *this)
                                                                                                                                               // .text:00458E00 ; public: void __thiscall CameraSet::SetInHead(void)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, void> SetMapMode = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, void>)0xDEADBEEF; // .text:004581D0 ; void __thiscall CameraSet::SetMapMode(CameraSet *this, Int32 map_mode)
                                                                                                                                                          // .text:004582F0 ; public: void __thiscall CameraSet::SetMapMode(Int32)
                                                                                                                                                          // .text:00457960 ; Int32 __stdcall CameraSet::SetScale(Single)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Single, void> SetScale = (delegate* unmanaged[Thiscall]<CameraSet*, Single, void>)0xDEADBEEF; // .text:00457840 ; void __thiscall CameraSet::SetScale(CameraSet *this, Single _scale)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Single, void> SetStiffness = (delegate* unmanaged[Thiscall]<CameraSet*, Single, void>)0xDEADBEEF; // .text:004577F0 ; void __thiscall CameraSet::SetStiffness(CameraSet *this, Single _stiffness)
                                                                                                                                                                // .text:00457910 ; Int32 __stdcall CameraSet::SetStiffness(Single)
                                                                                                                                                                // .text:00457800 ; Int32 __stdcall CameraSet::SetTargetForOffset(Single, Single, Single)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Vector3, void> SetTargetForOffset = (delegate* unmanaged[Thiscall]<CameraSet*, Vector3, void>)0xDEADBEEF; // .text:004576E0 ; void __thiscall CameraSet::SetTargetForOffset(CameraSet *this, AC1Legacy::Vector3 camera_off)
        public static delegate* unmanaged[Thiscall]<CameraSet*, void> StopCloser = (delegate* unmanaged[Thiscall]<CameraSet*, void>)0xDEADBEEF; // .text:00457430 ; void __thiscall CameraSet::StopCloser(CameraSet *this)
                                                                                                                                                // .text:00457550 ; public: void __thiscall CameraSet::StopCloser(void)
                                                                                                                                                // .text:00457560 ; public: void __thiscall CameraSet::StopFarther(void)
        public static delegate* unmanaged[Thiscall]<CameraSet*, void> StopFarther = (delegate* unmanaged[Thiscall]<CameraSet*, void>)0xDEADBEEF; // .text:00457440 ; void __thiscall CameraSet::StopFarther(CameraSet *this)
        public static delegate* unmanaged[Thiscall]<CameraSet*, void> StopLowering = (delegate* unmanaged[Thiscall]<CameraSet*, void>)0xDEADBEEF; // .text:00457420 ; void __thiscall CameraSet::StopLowering(CameraSet *this)
                                                                                                                                                  // .text:00457540 ; public: void __thiscall CameraSet::StopLowering(void)
                                                                                                                                                  // .text:00457530 ; public: void __thiscall CameraSet::StopRaising(void)
        public static delegate* unmanaged[Thiscall]<CameraSet*, void> StopRaising = (delegate* unmanaged[Thiscall]<CameraSet*, void>)0xDEADBEEF; // .text:00457410 ; void __thiscall CameraSet::StopRaising(CameraSet *this)
                                                                                                                                                 // .text:00457510 ; public: void __thiscall CameraSet::StopRotating(Int32)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, void> StopRotating = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, void>)0xDEADBEEF; // .text:004573F0 ; void __thiscall CameraSet::StopRotating(CameraSet *this, Int32 __formal)
        public static delegate* unmanaged[Thiscall]<CameraSet*, void> ToggleLookDown = (delegate* unmanaged[Thiscall]<CameraSet*, void>)0xDEADBEEF; // .text:00455E40 ; void __thiscall CameraSet::ToggleLookDown(CameraSet *this)
                                                                                                                                                    // .text:00455F60 ; public: void __thiscall CameraSet::ToggleLookDown(void)
        public static delegate* unmanaged[Thiscall]<CameraSet*, void> ToggleMapMode = (delegate* unmanaged[Thiscall]<CameraSet*, void>)0xDEADBEEF; // .text:00455E60 ; void __thiscall CameraSet::ToggleMapMode(CameraSet *this)
                                                                                                                                                   // .text:00455F80 ; public: void __thiscall CameraSet::ToggleMapMode(void)
                                                                                                                                                   // .text:004575B0 ; public: void __thiscall CameraSet::ToggleMouseLook(Int32)
        public static delegate* unmanaged[Thiscall]<CameraSet*, Int32, void> ToggleMouseLook = (delegate* unmanaged[Thiscall]<CameraSet*, Int32, void>)0xDEADBEEF; // .text:00457490 ; void __thiscall CameraSet::ToggleMouseLook(CameraSet *this, Int32 mouse_on)
                                                                                                                                                               // .text:004583A0 ; Int32 __stdcall CameraSet::TrackTarget(Single)
        public static delegate* unmanaged[Thiscall]<CameraSet*, UInt32, void> TrackTarget = (delegate* unmanaged[Thiscall]<CameraSet*, UInt32, void>)0xDEADBEEF; // .text:00458280 ; void __thiscall CameraSet::TrackTarget(CameraSet *this, UInt32 _gid)
                                                                                                                                                             // .text:00458C00 ; public: void __thiscall CameraSet::UpdateCamera(void)
        public static delegate* unmanaged[Thiscall]<CameraSet*, void> UpdateCamera = (delegate* unmanaged[Thiscall]<CameraSet*, void>)0xDEADBEEF; // .text:00458AE0 ; void __thiscall CameraSet::UpdateCamera(CameraSet *this)
        public static delegate* unmanaged[Thiscall]<CameraSet*, SmartBox*, void> __Ctor = (delegate* unmanaged[Thiscall]<CameraSet*, SmartBox*, void>)0xDEADBEEF; // .text:004590C0 ; void __thiscall CameraSet::CameraSet(CameraSet *this, SmartBox *_sbox)
        public static delegate* unmanaged[Thiscall]<CameraSet*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<CameraSet*, UInt32, void*>)0xDEADBEEF; // .text:00459150 ; void *__thiscall CameraSet::`vector deleting destructor'(CameraSet *this, UInt32)
                                                                                                                                                                // .text:00459270 ; Int32 __thiscall CameraSet::`vector deleting destructor'(void *, Char)

        // Globals:
    }


    public unsafe struct CommandInterpreter {
        public IInputActionCallback iInputActionCallback;
        public SmartBox* smartbox;
        public CPhysicsObj* player;
        public CommandList SubstateList;
        public CommandList TurnList;
        public CommandList SidestepList;
        public UInt32 autonomy_level;
        public Int32 controlled_by_server;
        public Int32 hold_run;
        public Int32 hold_sidestep;
        public Int32 transient_state;
        public Int32 enabled;
        public Int32 auto_run;
        public Int32 mouselook_active;
        public Int32 mouseleft_down;
        public Single autorun_speed;
        public UInt32 action_stamp;
        public Double last_sent_position_time;
        public Position last_sent_position;
        public Plane last_sent_contact_plane;
        public Double time_between_position_events;
    };
    public unsafe struct CommandList {
        public CommandListElement* head;
        public CommandListElement* mouse_command;
        public CommandListElement* current;
    };
    public unsafe struct LScape {
        public Int32 mid_radius;
        public Int32 mid_width;
        public CLandBlock** land_blocks;
        public CLandBlock** block_draw_list;
        public UInt32 loaded_cell_id;
        public UInt32 viewer_cell_id;
        public Int32 viewer_b_xoff;
        public Int32 viewer_b_yoff;
        public GameSky* sky;
        public CSurface* landscape_detail_surface;
        public CSurface* environment_detail_surface;
        public CSurface* building_detail_surface;
        public CSurface* object_detail_surface;
    };
    public unsafe struct GameSky {
        public AC1Legacy.SmartArray<PTR<CelestialPosition>> sky_obj_pos;
        public AC1Legacy.SmartArray<PTR<CPhysicsObj>> sky_obj;
        public AC1Legacy.SmartArray<UInt32> property_array;
        public CEnvCell* before_sky_cell;
        public CEnvCell* after_sky_cell;
    };
    public unsafe struct AmbientSound {
        public AmbientSoundVtbl* vfptr;
        public Int32 on_queue;
        public Single sound_count;
        public AmbientSTBDesc* desc;
        public UInt32 ambient_sound_id;
        public Int32 constant_sound;
    };
    public unsafe struct AmbientSoundVtbl {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate void ResetCount(AmbientSound* This); // void(__thiscall *ResetCount)(AmbientSound *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate Single GetVolume(AmbientSound* This); // Single(__thiscall *GetVolume)(AmbientSound *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate Int32 CanHear(AmbientSound* This); // Int32(__thiscall *CanHear)(AmbientSound *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate Int32 PlayNow(AmbientSound* This); // Int32(__thiscall *PlayNow)(AmbientSound *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate Single GetPlayInterval(AmbientSound* This); // Single(__thiscall *GetPlayInterval)(AmbientSound *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate void AddTo(AmbientSound* This, Single a2, Vector3* a3, LandDefs.Direction a4); // void(__thiscall *AddTo)(AmbientSound *this, Single, Vector3 *, LandDefs__Direction);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate void UpdateSound(AmbientSound* This, Single a2); // void(__thiscall *UpdateSound)(AmbientSound *this, Single);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate Int32 GetSoundPos(AmbientSound* This, Position* a2); // Int32(__thiscall *GetSoundPos)(AmbientSound *this, Position *);
    };
    public unsafe struct AmbientSTBDesc {
        public UInt32 stb_id; // IDClass<_tagDataID, 32, 0>
        public Int32 stb_not_found;
        public AC1Legacy.SmartArray<PTR<AmbientSoundDesc>> ambient_sounds;
        public CSoundTable* sound_table;
        public UInt32 play_count;
    };
    public unsafe struct AmbientSoundDesc {
        public SoundType stype;
        public Int32 is_continuous;
        public Single volume;
        public Single base_chance;
        public Single min_rate;
        public Single max_rate;

        public override string ToString() => $"{stype}:{(is_continuous == 0 ? "" : "(continuous)")} volume:{volume:n2} base_chance:{base_chance:n2} min_rate:{min_rate:n2} max_rate:{max_rate:n2}";
    };


    public unsafe struct CommandListElement {
        public CommandListElement* next;
        public CommandListElement* prev;
        public UInt32 command;
        public Single speed;
        public Int32 hold_run;
    };
    public unsafe struct CelestialPosition {
        public UInt32 gfx_id; // IDClass<_tagDataID, 32, 0>
        public UInt32 pes_id; // IDClass<_tagDataID, 32, 0>
        public Single heading;
        public Single rotation;
        public Vector3 tex_velocity;
        public Single transparent;
        public Single luminosity;
        public Single max_bright;
        public UInt32 properties;
        public override string ToString() => $"gfx_id:{gfx_id:X8} pes_id:{pes_id:X8} heading:{heading:n2} rotation:{rotation:n2} tex_velocity({tex_velocity}) transparent:{transparent:n2} luminosity:{luminosity:n2} max_bright:{max_bright:n2} properties:{properties:X8}";
    };
    public unsafe struct CellManager {
        public LScape* lscape;
        public Ambient* ambient_sounds;
        public UInt32 last_prefetch_cell_id;
        public Double last_prefetch_check;
        public Byte blocking_for_cells;
        public Byte all_cells_available;
        public UInt32 num_cells_waiting;
        public UInt32 total_num_cells_waiting;
        public CObjCell* curr_cell;
        public Position load_pos;
        public Int32 keep_lscape_loaded;
    };
    public unsafe struct Ambient {
        public Position player_pos;
        public Single total_sound_count;
        public UInt32 num_sounds;
        public DArray<AmbientSound> sounds;
        public AC1Legacy.PQueueArray<Double> sound_queue;
    };

}
