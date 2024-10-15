using System;

namespace AcClient {

    public unsafe struct CPhysics {
        // Struct:
        public CObjectMaint* obj_maint;
        public SmartBox* smartbox;
        public CPhysicsObj* player;
        public LongHashIter<CPhysicsObj>* iter;
        public override string ToString() => $"obj_maint:->(CObjectMaint*)0x{(int)obj_maint:X8}, smartbox:->(SmartBox*)0x{(int)smartbox:X8}, player:->(CPhysicsObj*)0x{(int)player:X8}, iter:->(LongHashIter<CPhysicsObj>*)0x{(int)iter:X8}";

        // Functions:

        // CPhysics.SetObjectMovement:
        public int SetObjectMovement(CPhysicsObj* _object, void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CPhysics, CPhysicsObj*, void*, UInt32, int>)0x00509790)(ref this, _object, buff, size); // .text:00509790 ; int __thiscall CPhysics::SetObjectMovement(CPhysics *this, CPhysicsObj *object, void *buff, unsigned int size) .text:00509790 ?SetObjectMovement@CPhysics@@QAEHPAVCPhysicsObj@@PAXI@Z

        // CPhysics.UpdateTexVelocity:
        public static void UpdateTexVelocity(Single time_delta) => ((delegate* unmanaged[Cdecl]<Single, void>)0x00509820)(time_delta); // .text:00509820 ; void __cdecl CPhysics::UpdateTexVelocity(float time_delta) .text:00509820 ?UpdateTexVelocity@CPhysics@@KAXM@Z

        // CPhysics.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref CPhysics, void>)0x00509950)(ref this); // .text:00509950 ; void __thiscall CPhysics::UseTime(CPhysics *this) .text:00509950 ?UseTime@CPhysics@@QAEXXZ

        // CPhysics.__Ctor:
        public void __Ctor(CObjectMaint* _obj_maint, SmartBox* _smartbox) => ((delegate* unmanaged[Thiscall]<ref CPhysics, CObjectMaint*, SmartBox*, void>)0x00509A60)(ref this, _obj_maint, _smartbox); // .text:00509A60 ; void __thiscall CPhysics::CPhysics(CPhysics *this, CObjectMaint *_obj_maint, SmartBox *_smartbox) .text:00509A60 ??0CPhysics@@QAE@PAVCObjectMaint@@PAVSmartBox@@@Z

        // CPhysics.AddStaticAnimatingObject:
        public static void AddStaticAnimatingObject(CPhysicsObj* _object) => ((delegate* unmanaged[Cdecl]<CPhysicsObj*, void>)0x00509AF0)(_object); // .text:00509AF0 ; void __cdecl CPhysics::AddStaticAnimatingObject(CPhysicsObj *object) .text:00509AF0 ?AddStaticAnimatingObject@CPhysics@@SAXPAVCPhysicsObj@@@Z

        // CPhysics.AddGfxVelocity:
        public static void AddGfxVelocity(UInt32 gfx_id, Single du, Single dv) => ((delegate* unmanaged[Cdecl]<UInt32, Single, Single, void>)0x00509B60)(gfx_id, du, dv); // .text:00509B60 ; void __cdecl CPhysics::AddGfxVelocity(IDClass<_tagDataID,32,0> gfx_id, float du, float dv) .text:00509B60 ?AddGfxVelocity@CPhysics@@SAXV?$IDClass@U_tagDataID@@$0CA@$0A@@@MM@Z

        // CPhysics.SetObjectMovement:
        public int SetObjectMovement(CPhysicsObj* _object, void* buff, UInt32 size, UInt16 movement_timestamp, UInt16 server_control_timestamp, int autonomous) => ((delegate* unmanaged[Thiscall]<ref CPhysics, CPhysicsObj*, void*, UInt32, UInt16, UInt16, int, int>)0x00509690)(ref this, _object, buff, size, movement_timestamp, server_control_timestamp, autonomous); // .text:00509690 ; int __thiscall CPhysics::SetObjectMovement(CPhysics *this, CPhysicsObj *object, void *buff, unsigned int size, unsigned __int16 movement_timestamp, unsigned __int16 server_control_timestamp, int autonomous) .text:00509690 ?SetObjectMovement@CPhysics@@QAEHPAVCPhysicsObj@@PAXIGGH@Z

        // CPhysics.RemoveStaticAnimatingObject:
        public static void RemoveStaticAnimatingObject(CPhysicsObj* _object) => ((delegate* unmanaged[Cdecl]<CPhysicsObj*, void>)0x00509760)(_object); // .text:00509760 ; void __cdecl CPhysics::RemoveStaticAnimatingObject(CPhysicsObj *object) .text:00509760 ?RemoveStaticAnimatingObject@CPhysics@@SAXPAVCPhysicsObj@@@Z

        // Globals:
        public static AC1Legacy.SmartArray<PTR<CPhysicsObj>>* static_animating_objects = (AC1Legacy.SmartArray<PTR<CPhysicsObj>>*)0x00841C40; // .data:00841C40 ; AC1Legacy::SmartArray<CPhysicsObj *> CPhysics::static_animating_objects .data:00841C40 ?static_animating_objects@CPhysics@@1V?$SmartArray@PAVCPhysicsObj@@@AC1Legacy@@A
        public static AC1Legacy.SmartArray<PTR<GfxVelocityDesc>>* texture_velocity_gids = (AC1Legacy.SmartArray<PTR<GfxVelocityDesc>>*)0x00841C4C; // .data:00841C4C ; AC1Legacy::SmartArray<GfxVelocityDesc *> CPhysics::texture_velocity_gids .data:00841C4C ?texture_velocity_gids@CPhysics@@1V?$SmartArray@PAUGfxVelocityDesc@@@AC1Legacy@@A
    }



    public unsafe struct GfxVelocityDesc {
        // Struct:
        public UInt32 id;
        public CVec2Duv offset;
        public CVec2Duv total;
        public override string ToString() => $"id:{id:X8}, offset(CVec2Duv):{offset}, total(CVec2Duv):{total}";
    }

    public unsafe struct CPhysicsObj {
        // Struct:
        public LongHashData a0;
        public NIList<NetBlob>* netblob_list;
        public CPartArray* part_array;
        public AC1Legacy.Vector3 player_vector;
        public Single player_distance;
        public Single CYpt;
        public CSoundTable* sound_table;
        public Byte m_bExaminationObject;
        public ScriptManager* script_manager;
        public PhysicsScriptTable* physics_script_table;
        public PScriptType default_script;
        public Single default_script_intensity;
        public CPhysicsObj* parent;
        public CHILDLIST* children;
        public Position m_position;
        public CObjCell* cell;
        public UInt32 num_shadow_objects;
        public DArray<CShadowObj> shadow_objects;
        public UInt32 state;
        public UInt32 transient_state;
        public Single elasticity;
        public Single translucency;
        public Single translucencyOriginal;
        public Single friction;
        public Single massinv;
        public MovementManager* movement_manager;
        public PositionManager* position_manager;
        public int last_move_was_autonomous;
        public int jumped_this_frame;
        public Double update_time;
        public AC1Legacy.Vector3 m_velocityVector;
        public AC1Legacy.Vector3 m_accelerationVector;
        public AC1Legacy.Vector3 m_omegaVector;
        public PhysicsObjHook* hooks;
        public AC1Legacy.SmartArray<PTR<CAnimHook>> anim_hooks;
        public Single m_scale;
        public Single attack_radius;
        public DetectionManager* detection_manager;
        public AttackManager* attack_manager;
        public TargetManager* target_manager;
        public ParticleManager* particle_manager;
        public ACCWeenieObject* weenie_obj;
        public Plane contact_plane;
        public UInt32 contact_plane_cell_id;
        public AC1Legacy.Vector3 sliding_normal;
        public AC1Legacy.Vector3 cached_velocity;
        public LongNIValHash<CPhysicsObj.CollisionRecord>* collision_table;
        public int colliding_with_environment;
        public fixed int update_times[9];
        public override string ToString() => $"a0(LongHashData):{a0}, netblob_list:->(NIList<NetBlob*>*)0x{(int)netblob_list:X8}, part_array:->(CPartArray*)0x{(int)part_array:X8}, player_vector(AC1Legacy.Vector3):{player_vector}, player_distance:{player_distance:n5}, CYpt:{CYpt:n5}, sound_table:->(CSoundTable*)0x{(int)sound_table:X8}, m_bExaminationObject:{m_bExaminationObject:X2}, script_manager:->(ScriptManager*)0x{(int)script_manager:X8}, physics_script_table:->(PhysicsScriptTable*)0x{(int)physics_script_table:X8}, default_script(PScriptType):{default_script}, default_script_intensity:{default_script_intensity:n5}, parent:->(CPhysicsObj*)0x{(int)parent:X8}, children:->(CHILDLIST*)0x{(int)children:X8}, m_position(Position):{m_position}, cell:->(CObjCell*)0x{(int)cell:X8}, num_shadow_objects:{num_shadow_objects:X8}, shadow_objects(DArray<CShadowObj>):{shadow_objects}, state:{state:X8}, transient_state:{transient_state:X8}, elasticity:{elasticity:n5}, translucency:{translucency:n5}, translucencyOriginal:{translucencyOriginal:n5}, friction:{friction:n5}, massinv:{massinv:n5}, movement_manager:->(MovementManager*)0x{(int)movement_manager:X8}, position_manager:->(PositionManager*)0x{(int)position_manager:X8}, last_move_was_autonomous(int):{last_move_was_autonomous}, jumped_this_frame(int):{jumped_this_frame}, update_time:{update_time:n5}, m_velocityVector(AC1Legacy.Vector3):{m_velocityVector}, m_accelerationVector(AC1Legacy.Vector3):{m_accelerationVector}, m_omegaVector(AC1Legacy.Vector3):{m_omegaVector}, hooks:->(PhysicsObjHook*)0x{(int)hooks:X8}, anim_hooks(AC1Legacy.SmartArray<CAnimHook*>):{anim_hooks}, m_scale:{m_scale:n5}, attack_radius:{attack_radius:n5}, detection_manager:->(DetectionManager*)0x{(int)detection_manager:X8}, attack_manager:->(AttackManager*)0x{(int)attack_manager:X8}, target_manager:->(TargetManager*)0x{(int)target_manager:X8}, particle_manager:->(ParticleManager*)0x{(int)particle_manager:X8}, weenie_obj:->(CWeenieObject*)0x{(int)weenie_obj:X8}, contact_plane(Plane):{contact_plane}, contact_plane_cell_id:{contact_plane_cell_id:X8}, sliding_normal(AC1Legacy.Vector3):{sliding_normal}, cached_velocity(AC1Legacy.Vector3):{cached_velocity}, collision_table:->(LongNIValHash<CPhysicsObj.CollisionRecord>*)0x{(int)collision_table:X8}, colliding_with_environment(int):{colliding_with_environment}, update_times[9](fixed int):{update_times[9]}";
        public unsafe struct CollisionRecord {
            public Double touched_time;
            public int ethereal;
            public override string ToString() => $"touched_time:{touched_time:n5}, ethereal(int):{ethereal}";
        }

        // Functions:

        // CPhysicsObj.motions_pending:
        public int motions_pending() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x0050F580)(ref this); // .text:0050EAB0 ; int __thiscall CPhysicsObj::motions_pending(CPhysicsObj *this) .text:0050EAB0 ?motions_pending@CPhysicsObj@@QBEHXZ

        // CPhysicsObj.UpdateViewerDistanceRecursive:
        public void UpdateViewerDistanceRecursive() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00511720)(ref this); // .text:00510C50 ; void __thiscall CPhysicsObj::UpdateViewerDistanceRecursive(CPhysicsObj *this) .text:00510C50 ?UpdateViewerDistanceRecursive@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.UpdatePhysicsInternal:
        public void UpdatePhysicsInternal(Single quantum, Frame* offset_frame) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Frame*, void>)0x005111D0)(ref this, quantum, offset_frame); // .text:00510700 ; void __thiscall CPhysicsObj::UpdatePhysicsInternal(CPhysicsObj *this, float quantum, Frame *offset_frame) .text:00510700 ?UpdatePhysicsInternal@CPhysicsObj@@IAEXMAAVFrame@@@Z

        // CPhysicsObj.process_hooks:
        public void process_hooks() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00512020)(ref this); // .text:00511550 ; void __thiscall CPhysicsObj::process_hooks(CPhysicsObj *this) .text:00511550 ?process_hooks@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.makeObject:
        public static CPhysicsObj* makeObject(CPhysicsObj* pTemplate) => ((delegate* unmanaged[Cdecl]<CPhysicsObj*, CPhysicsObj*>)0x00514FB0)(pTemplate); // .text:005144B0 ; CPhysicsObj *__cdecl CPhysicsObj::makeObject(CPhysicsObj *pTemplate) .text:005144B0 ?makeObject@CPhysicsObj@@SAPAV1@PBV1@@Z

        // CPhysicsObj.is_newer:
        public static int is_newer(UInt16 timestamp, UInt16 new_time) => ((delegate* unmanaged[Cdecl]<UInt16, UInt16, int>)0x00451B10)(timestamp, new_time); // .text:00451AD0 ; int __cdecl CPhysicsObj::is_newer(unsigned __int16 timestamp, unsigned __int16 new_time) .text:00451AD0 ?is_newer@CPhysicsObj@@SAHGG@Z

        // CPhysicsObj.movement_is_autonomous:
        public int movement_is_autonomous() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x0050F600)(ref this); // .text:0050EB30 ; int __thiscall CPhysicsObj::movement_is_autonomous(CPhysicsObj *this) .text:0050EB30 ?movement_is_autonomous@CPhysicsObj@@QBEHXZ

        // CPhysicsObj.is_valid_walkable:
        public int is_valid_walkable(AC1Legacy.Vector3* normal) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, AC1Legacy.Vector3*, int>)0x00510000)(ref this, normal); // .text:0050F530 ; int __thiscall CPhysicsObj::is_valid_walkable(CPhysicsObj *this, AC1Legacy::Vector3 *normal) .text:0050F530 ?is_valid_walkable@CPhysicsObj@@QBEHABVVector3@AC1Legacy@@@Z

        // CPhysicsObj.SetDiffusion:
        public void SetDiffusion(Single start, Single end, Double delta) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Single, Double, void>)0x005124B0)(ref this, start, end, delta); // .text:005119E0 ; void __thiscall CPhysicsObj::SetDiffusion(CPhysicsObj *this, float start, float end, long double delta) .text:005119E0 ?SetDiffusion@CPhysicsObj@@QAEXMMN@Z

        // CPhysicsObj.get_position_manager:
        public PositionManager* get_position_manager() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, PositionManager*>)0x00512C00)(ref this); // .text:00512130 ; PositionManager *__thiscall CPhysicsObj::get_position_manager(CPhysicsObj *this) .text:00512130 ?get_position_manager@CPhysicsObj@@QAEPAVPositionManager@@XZ

        // CPhysicsObj.GetStartConstraintDistance:
        public Single GetStartConstraintDistance() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x0050F690)(ref this); // .text:0050EBC0 ; float __thiscall CPhysicsObj::GetStartConstraintDistance(CPhysicsObj *this) .text:0050EBC0 ?GetStartConstraintDistance@CPhysicsObj@@QBE?BMXZ

        // CPhysicsObj.destroy_particle_emitter:
        public int destroy_particle_emitter(UInt32 emitter_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x0050FED0)(ref this, emitter_id); // .text:0050F400 ; int __thiscall CPhysicsObj::destroy_particle_emitter(CPhysicsObj *this, unsigned int emitter_id) .text:0050F400 ?destroy_particle_emitter@CPhysicsObj@@QAEHK@Z

        // CPhysicsObj.destroy_particle_manager:
        public void destroy_particle_manager() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00511820)(ref this); // .text:00510D50 ; void __thiscall CPhysicsObj::destroy_particle_manager(CPhysicsObj *this) .text:00510D50 ?destroy_particle_manager@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetLuminosity:
        public void SetLuminosity(Single start, Single end, Double delta) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Single, Double, void>)0x00512360)(ref this, start, end, delta); // .text:00511890 ; void __thiscall CPhysicsObj::SetLuminosity(CPhysicsObj *this, float start, float end, long double delta) .text:00511890 ?SetLuminosity@CPhysicsObj@@QAEXMMN@Z

        // CPhysicsObj.get_sticky_object_id:
        public UInt32 get_sticky_object_id() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32>)0x0050F5C0)(ref this); // .text:0050EAF0 ; unsigned int __thiscall CPhysicsObj::get_sticky_object_id(CPhysicsObj *this) .text:0050EAF0 ?get_sticky_object_id@CPhysicsObj@@QBEKXZ

        // CPhysicsObj.set_cell_id:
        public void set_cell_id(UInt32 new_cell_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, void>)0x0050FFC0)(ref this, new_cell_id); // .text:0050F4F0 ; void __thiscall CPhysicsObj::set_cell_id(CPhysicsObj *this, unsigned int new_cell_id) .text:0050F4F0 ?set_cell_id@CPhysicsObj@@QAEXK@Z

        // CPhysicsObj.set_elasticity:
        public int set_elasticity(Single _elasticity) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, int>)0x00510810)(ref this, _elasticity); // .text:0050FD40 ; int __thiscall CPhysicsObj::set_elasticity(CPhysicsObj *this, float _elasticity) .text:0050FD40 ?set_elasticity@CPhysicsObj@@QAEHM@Z

        // CPhysicsObj.InitObjectBegin:
        public int InitObjectBegin(UInt32 _object_iid, int bDynamic) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int, int>)0x00510A50)(ref this, _object_iid, bDynamic); // .text:0050FF80 ; int __thiscall CPhysicsObj::InitObjectBegin(CPhysicsObj *this, unsigned int _object_iid, int bDynamic) .text:0050FF80 ?InitObjectBegin@CPhysicsObj@@IAEHKH@Z

        // CPhysicsObj.cancel_moveto:
        public void cancel_moveto() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00510CC0)(ref this); // .text:005101F0 ; void __thiscall CPhysicsObj::cancel_moveto(CPhysicsObj *this) .text:005101F0 ?cancel_moveto@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.receive_detection_update:
        public void receive_detection_update(DetectionInfo* info) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, DetectionInfo*, void>)0x005110A0)(ref this, info); // .text:005105D0 ; void __thiscall CPhysicsObj::receive_detection_update(CPhysicsObj *this, DetectionInfo *info) .text:005105D0 ?receive_detection_update@CPhysicsObj@@QAEXABVDetectionInfo@@@Z

        // CPhysicsObj.CacheHasPhysicsBSP:
        public int CacheHasPhysicsBSP() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00510040)(ref this); // .text:0050F570 ; int __thiscall CPhysicsObj::CacheHasPhysicsBSP(CPhysicsObj *this) .text:0050F570 ?CacheHasPhysicsBSP@CPhysicsObj@@IAEHXZ

        // CPhysicsObj.store_position:
        public void store_position(Position* p) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Position*, void>)0x00514CA0)(ref this, p); // .text:005141A0 ; void __thiscall CPhysicsObj::store_position(CPhysicsObj *this, Position *p) .text:005141A0 ?store_position@CPhysicsObj@@QAEXABVPosition@@@Z

        // CPhysicsObj.enter_world:
        public int enter_world(int slide) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, int>)0x00516C70)(ref this, slide); // .text:00516170 ; int __thiscall CPhysicsObj::enter_world(CPhysicsObj *this, const int slide) .text:00516170 ?enter_world@CPhysicsObj@@QAEHH@Z

        // CPhysicsObj.GetDataID:
        public UInt32* GetDataID(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32*, UInt32*>)0x0050F460)(ref this, result); // .text:0050E990 ; IDClass<_tagDataID,32,0> *__thiscall CPhysicsObj::GetDataID(CPhysicsObj *this, IDClass<_tagDataID,32,0> *result) .text:0050E990 ?GetDataID@CPhysicsObj@@QBE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // CPhysicsObj.GetHeight:
        public Single GetHeight() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x0050F4B0)(ref this); // .text:0050E9E0 ; float __thiscall CPhysicsObj::GetHeight(CPhysicsObj *this) .text:0050E9E0 ?GetHeight@CPhysicsObj@@QBEMXZ

        // CPhysicsObj.CheckPositionInternal:
        public int CheckPositionInternal(CObjCell* new_cell, Position* new_pos, CTransition* transit, SetPositionStruct* sps) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CObjCell*, Position*, CTransition*, SetPositionStruct*, int>)0x00512960)(ref this, new_cell, new_pos, transit, sps); // .text:00511E90 ; int __thiscall CPhysicsObj::CheckPositionInternal(CPhysicsObj *this, CObjCell *new_cell, Position *new_pos, CTransition *transit, SetPositionStruct *sps) .text:00511E90 ?CheckPositionInternal@CPhysicsObj@@IAEHPAVCObjCell@@AAVPosition@@PAVCTransition@@ABVSetPositionStruct@@@Z

        // CPhysicsObj.animate_static_object:
        public void animate_static_object() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x005148F0)(ref this); // .text:00513DF0 ; void __thiscall CPhysicsObj::animate_static_object(CPhysicsObj *this) .text:00513DF0 ?animate_static_object@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetPosition:
        public SetPositionError SetPosition(SetPositionStruct* sps) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, SetPositionStruct*, SetPositionError>)0x00516BC0)(ref this, sps); // .text:005160C0 ; SetPositionError __thiscall CPhysicsObj::SetPosition(CPhysicsObj *this, SetPositionStruct *sps) .text:005160C0 ?SetPosition@CPhysicsObj@@QAE?AW4SetPositionError@@AAVSetPositionStruct@@@Z

        // CPhysicsObj.check_collision:
        public int check_collision(CPhysicsObj* _object) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, int>)0x005139D0)(ref this, _object); // .text:00512ED0 ; int __thiscall CPhysicsObj::check_collision(CPhysicsObj *this, CPhysicsObj *object) .text:00512ED0 ?check_collision@CPhysicsObj@@QBEHPBV1@@Z

        // CPhysicsObj.unset_parent:
        public void unset_parent() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00513F70)(ref this); // .text:00513470 ; void __thiscall CPhysicsObj::unset_parent(CPhysicsObj *this) .text:00513470 ?unset_parent@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.set_frame:
        public void set_frame(Frame* i_frame) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Frame*, void>)0x00514B90)(ref this, i_frame); // .text:00514090 ; void __thiscall CPhysicsObj::set_frame(CPhysicsObj *this, Frame *i_frame) .text:00514090 ?set_frame@CPhysicsObj@@QAEXABVFrame@@@Z

        // CPhysicsObj.SetTextureVelocity:
        public void SetTextureVelocity(Single du, Single dv) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Single, void>)0x005106F0)(ref this, du, dv); // .text:0050FC20 ; void __thiscall CPhysicsObj::SetTextureVelocity(CPhysicsObj *this, float du, float dv) .text:0050FC20 ?SetTextureVelocity@CPhysicsObj@@QAEXMM@Z

        // CPhysicsObj.CheckForCompletedMotions:
        public void CheckForCompletedMotions() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00510900)(ref this); // .text:0050FE30 ; void __thiscall CPhysicsObj::CheckForCompletedMotions(CPhysicsObj *this) .text:0050FE30 ?CheckForCompletedMotions@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetMotionTableID:
        public int SetMotionTableID(UInt32 mtable_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x00513280)(ref this, mtable_id); // .text:00512780 ; int __thiscall CPhysicsObj::SetMotionTableID(CPhysicsObj *this, IDClass<_tagDataID,32,0> mtable_id) .text:00512780 ?SetMotionTableID@CPhysicsObj@@QAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CPhysicsObj.report_collision_start:
        public void report_collision_start() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00514AD0)(ref this); // .text:00513FD0 ; void __thiscall CPhysicsObj::report_collision_start(CPhysicsObj *this) .text:00513FD0 ?report_collision_start@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.clear_target:
        public void clear_target() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x0050F860)(ref this); // .text:0050ED90 ; void __thiscall CPhysicsObj::clear_target(CPhysicsObj *this) .text:0050ED90 ?clear_target@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetPartTranslucency:
        public void SetPartTranslucency(UInt32 part_index, Single start_trans, Single end_trans, Double delta) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, Single, Single, Double, void>)0x00512200)(ref this, part_index, start_trans, end_trans, delta); // .text:00511730 ; void __thiscall CPhysicsObj::SetPartTranslucency(CPhysicsObj *this, unsigned int part_index, float start_trans, float end_trans, long double delta) .text:00511730 ?SetPartTranslucency@CPhysicsObj@@QAEXKMMN@Z

        // CPhysicsObj.process_fp_hook:
        public void process_fp_hook(int type, Single curr_value, void* user_data) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, Single, void*, void>)0x005140C0)(ref this, type, curr_value, user_data); // .text:005135C0 ; void __thiscall CPhysicsObj::process_fp_hook(CPhysicsObj *this, int type, float curr_value, void *user_data) .text:005135C0 ?process_fp_hook@CPhysicsObj@@QAEXHMPAX@Z

        // CPhysicsObj.SetPositionInternal:
        public SetPositionError SetPositionInternal(Position* p, SetPositionStruct* sps, CTransition* transit) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Position*, SetPositionStruct*, CTransition*, SetPositionError>)0x005166D0)(ref this, p, sps, transit); // .text:00515BD0 ; SetPositionError __thiscall CPhysicsObj::SetPositionInternal(CPhysicsObj *this, Position *p, SetPositionStruct *sps, CTransition *transit) .text:00515BD0 ?SetPositionInternal@CPhysicsObj@@IAE?AW4SetPositionError@@AAVPosition@@ABVSetPositionStruct@@PAVCTransition@@@Z

        // CPhysicsObj.UpdateChildrenInternal:
        public void UpdateChildrenInternal() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x005148A0)(ref this); // .text:00513DA0 ; void __thiscall CPhysicsObj::UpdateChildrenInternal(CPhysicsObj *this) .text:00513DA0 ?UpdateChildrenInternal@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.handle_all_collisions:
        public int handle_all_collisions(COLLISIONINFO* collisions, int prev_has_contact, int prev_on_walkable) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, COLLISIONINFO*, int, int, int>)0x00515280)(ref this, collisions, prev_has_contact, prev_on_walkable); // .text:00514780 ; int __thiscall CPhysicsObj::handle_all_collisions(CPhysicsObj *this, COLLISIONINFO *collisions, int prev_has_contact, int prev_on_walkable) .text:00514780 ?handle_all_collisions@CPhysicsObj@@IAEHABVCOLLISIONINFO@@HH@Z

        // CPhysicsObj.add_obj_to_cell:
        public void add_obj_to_cell(CObjCell* new_cell, Frame* new_frame) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CObjCell*, Frame*, void>)0x005164E0)(ref this, new_cell, new_frame); // .text:005159E0 ; void __thiscall CPhysicsObj::add_obj_to_cell(CPhysicsObj *this, CObjCell *new_cell, Frame *new_frame) .text:005159E0 ?add_obj_to_cell@CPhysicsObj@@QAEXPAVCObjCell@@ABVFrame@@@Z

        // CPhysicsObj.update_object:
        public void update_object() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00516810)(ref this); // .text:00515D10 ; void __thiscall CPhysicsObj::update_object(CPhysicsObj *this) .text:00515D10 ?update_object@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetPositionInternal:
        public SetPositionError SetPositionInternal(SetPositionStruct* sps, CTransition* transit) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, SetPositionStruct*, CTransition*, SetPositionError>)0x00516B40)(ref this, sps, transit); // .text:00516040 ; SetPositionError __thiscall CPhysicsObj::SetPositionInternal(CPhysicsObj *this, SetPositionStruct *sps, CTransition *transit) .text:00516040 ?SetPositionInternal@CPhysicsObj@@IAE?AW4SetPositionError@@ABVSetPositionStruct@@PAVCTransition@@@Z

        // CPhysicsObj.StopInterpretedMotion:
        public UInt32 StopInterpretedMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, MovementParameters*, UInt32>)0x0050F560)(ref this, motion, _params); // .text:0050EA90 ; unsigned int __thiscall CPhysicsObj::StopInterpretedMotion(CPhysicsObj *this, unsigned int motion, MovementParameters *params) .text:0050EA90 ?StopInterpretedMotion@CPhysicsObj@@QAEKKABVMovementParameters@@@Z

        // CPhysicsObj.RemovePartFromShadowCells:
        public void RemovePartFromShadowCells(CPhysicsPart* part) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsPart*, void>)0x00511940)(ref this, part); // .text:00510E70 ; void __thiscall CPhysicsObj::RemovePartFromShadowCells(CPhysicsObj *this, CPhysicsPart *part) .text:00510E70 ?RemovePartFromShadowCells@CPhysicsObj@@QAEXPAVCPhysicsPart@@@Z

        // CPhysicsObj.SetScale:
        public void SetScale(Single new_scale, Double delta) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Double, void>)0x005141A0)(ref this, new_scale, delta); // .text:005136A0 ; void __thiscall CPhysicsObj::SetScale(CPhysicsObj *this, float new_scale, long double delta) .text:005136A0 ?SetScale@CPhysicsObj@@QAEXMN@Z

        // CPhysicsObj.set_active:
        public int set_active(int _active) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, int>)0x00510710)(ref this, _active); // .text:0050FC40 ; int __thiscall CPhysicsObj::set_active(CPhysicsObj *this, int _active) .text:0050FC40 ?set_active@CPhysicsObj@@QAEHH@Z

        // CPhysicsObj.set_cell_id_recursive:
        public void set_cell_id_recursive(UInt32 new_cell_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, void>)0x00511870)(ref this, new_cell_id); // .text:00510DA0 ; void __thiscall CPhysicsObj::set_cell_id_recursive(CPhysicsObj *this, unsigned int new_cell_id) .text:00510DA0 ?set_cell_id_recursive@CPhysicsObj@@QAEXK@Z

        // CPhysicsObj.create_particle_emitter:
        public UInt32 create_particle_emitter(UInt32 emitter_info_id, UInt32 part_index, Frame* offset, UInt32 emitter_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, UInt32, Frame*, UInt32, UInt32>)0x0050FE30)(ref this, emitter_info_id, part_index, offset, emitter_id); // .text:0050F360 ; unsigned int __thiscall CPhysicsObj::create_particle_emitter(CPhysicsObj *this, IDClass<_tagDataID,32,0> emitter_info_id, unsigned int part_index, Frame *offset, unsigned int emitter_id) .text:0050F360 ?create_particle_emitter@CPhysicsObj@@QAEKV?$IDClass@U_tagDataID@@$0CA@$0A@@@KABVFrame@@K@Z

        // CPhysicsObj.SetPartTextureVelocity:
        public void SetPartTextureVelocity(UInt32 part_index, Single du, Single dv) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, Single, Single, void>)0x00510700)(ref this, part_index, du, dv); // .text:0050FC30 ; void __thiscall CPhysicsObj::SetPartTextureVelocity(CPhysicsObj *this, unsigned int part_index, float du, float dv) .text:0050FC30 ?SetPartTextureVelocity@CPhysicsObj@@QAEXKMM@Z

        // CPhysicsObj.GetSelectionSphere:
        public int GetSelectionSphere(CSphere* selection_sphere) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CSphere*, int>)0x0050F510)(ref this, selection_sphere); // .text:0050EA40 ; int __thiscall CPhysicsObj::GetSelectionSphere(CPhysicsObj *this, CSphere *selection_sphere) .text:0050EA40 ?GetSelectionSphere@CPhysicsObj@@QBEHAAVCSphere@@@Z

        // CPhysicsObj.IsInterpolating:
        public int IsInterpolating() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x0050F620)(ref this); // .text:0050EB50 ; int __thiscall CPhysicsObj::IsInterpolating(CPhysicsObj *this) .text:0050EB50 ?IsInterpolating@CPhysicsObj@@QBEHXZ

        // CPhysicsObj.SetPlayer:
        public static void SetPlayer(CPhysicsObj* new_player_object) => ((delegate* unmanaged[Cdecl]<CPhysicsObj*, void>)0x0050FF90)(new_player_object); // .text:0050F4C0 ; void __cdecl CPhysicsObj::SetPlayer(CPhysicsObj *new_player_object) .text:0050F4C0 ?SetPlayer@CPhysicsObj@@SAXPAV1@@Z

        // CPhysicsObj.leave_cell:
        public void leave_cell(int is_changing_cell) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, void>)0x00511A20)(ref this, is_changing_cell); // .text:00510F50 ; void __thiscall CPhysicsObj::leave_cell(CPhysicsObj *this, int is_changing_cell) .text:00510F50 ?leave_cell@CPhysicsObj@@QAEXH@Z

        // CPhysicsObj.remove_voyeur:
        public int remove_voyeur(UInt32 _object_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x0050F920)(ref this, _object_id); // .text:0050EE50 ; int __thiscall CPhysicsObj::remove_voyeur(CPhysicsObj *this, unsigned int _object_id) .text:0050EE50 ?remove_voyeur@CPhysicsObj@@QAEHK@Z

        // CPhysicsObj.DoMotion:
        public UInt32 DoMotion(UInt32 motion, MovementParameters* _params, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, MovementParameters*, int, UInt32>)0x00510AF0)(ref this, motion, _params, send_event); // .text:00510020 ; unsigned int __thiscall CPhysicsObj::DoMotion(CPhysicsObj *this, unsigned int motion, MovementParameters *params, int send_event) .text:00510020 ?DoMotion@CPhysicsObj@@QAEKKABVMovementParameters@@H@Z

        // CPhysicsObj.remove_shadows_from_cells:
        public void remove_shadows_from_cells() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00511D00)(ref this); // .text:00511230 ; void __thiscall CPhysicsObj::remove_shadows_from_cells(CPhysicsObj *this) .text:00511230 ?remove_shadows_from_cells@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.update_position:
        public void update_position() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00515020)(ref this); // .text:00514520 ; void __thiscall CPhysicsObj::update_position(CPhysicsObj *this) .text:00514520 ?update_position@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.teleport_hook:
        public void teleport_hook(int hide) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, void>)0x005159D0)(ref this, hide); // .text:00514ED0 ; void __thiscall CPhysicsObj::teleport_hook(CPhysicsObj *this, int hide) .text:00514ED0 ?teleport_hook@CPhysicsObj@@QAEXH@Z

        // CPhysicsObj.InqInterpretedMotionState:
        public InterpretedMotionState* InqInterpretedMotionState() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, InterpretedMotionState*>)0x005108D0)(ref this); // .text:0050FE00 ; InterpretedMotionState *__thiscall CPhysicsObj::InqInterpretedMotionState(CPhysicsObj *this) .text:0050FE00 ?InqInterpretedMotionState@CPhysicsObj@@QBEPBVInterpretedMotionState@@XZ

        // CPhysicsObj.report_environment_collision:
        public int report_environment_collision(int prev_has_contact) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, int>)0x00513AC0)(ref this, prev_has_contact); // .text:00512FC0 ; int __thiscall CPhysicsObj::report_environment_collision(CPhysicsObj *this, int prev_has_contact) .text:00512FC0 ?report_environment_collision@CPhysicsObj@@IAEHH@Z

        // CPhysicsObj.IsMovingTo:
        public int IsMovingTo() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x0050F5E0)(ref this); // .text:0050EB10 ; int __thiscall CPhysicsObj::IsMovingTo(CPhysicsObj *this) .text:0050EB10 ?IsMovingTo@CPhysicsObj@@QBEHXZ

        // CPhysicsObj.FindObjCollisions:
        public TransitionState FindObjCollisions(CTransition* transition) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CTransition*, TransitionState>)0x0050FB20)(ref this, transition); // .text:0050F050 ; TransitionState __thiscall CPhysicsObj::FindObjCollisions(CPhysicsObj *this, CTransition *transition) .text:0050F050 ?FindObjCollisions@CPhysicsObj@@QBE?AW4TransitionState@@AAVCTransition@@@Z

        // CPhysicsObj.MorphToExistingObject:
        public int MorphToExistingObject(CPhysicsObj* pObj) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, int>)0x00510580)(ref this, pObj); // .text:0050FAB0 ; int __thiscall CPhysicsObj::MorphToExistingObject(CPhysicsObj *this, CPhysicsObj *pObj) .text:0050FAB0 ?MorphToExistingObject@CPhysicsObj@@QAEHPBV1@@Z

        // CPhysicsObj.Hook_AnimDone:
        public void Hook_AnimDone() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00510870)(ref this); // .text:0050FDA0 ; void __thiscall CPhysicsObj::Hook_AnimDone(CPhysicsObj *this) .text:0050FDA0 ?Hook_AnimDone@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.queue_netblob:
        public void queue_netblob(NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, NetBlob*, void>)0x00514270)(ref this, blob); // .text:00513770 ; void __thiscall CPhysicsObj::queue_netblob(CPhysicsObj *this, NetBlob *blob) .text:00513770 ?queue_netblob@CPhysicsObj@@QAEXPAVNetBlob@@@Z

        // CPhysicsObj.StopCompletely_Internal:
        public void StopCompletely_Internal() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x0050F5A0)(ref this); // .text:0050EAD0 ; void __thiscall CPhysicsObj::StopCompletely_Internal(CPhysicsObj *this) .text:0050EAD0 ?StopCompletely_Internal@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetPartLighting:
        public int SetPartLighting(UInt32 part_index, Single luminosity, Single diffuse) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, Single, Single, int>)0x00512560)(ref this, part_index, luminosity, diffuse); // .text:00511A90 ; int __thiscall CPhysicsObj::SetPartLighting(CPhysicsObj *this, unsigned int part_index, float luminosity, float diffuse) .text:00511A90 ?SetPartLighting@CPhysicsObj@@QAEHKMM@Z

        // CPhysicsObj.CallPESInternal:
        public void CallPESInternal(UInt32 pes, Single cur_value) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, Single, void>)0x00512590)(ref this, pes, cur_value); // .text:00511AC0 ; void __thiscall CPhysicsObj::CallPESInternal(CPhysicsObj *this, IDClass<_tagDataID,32,0> pes, float cur_value) .text:00511AC0 ?CallPESInternal@CPhysicsObj@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@M@Z

        // CPhysicsObj.get_local_physics_velocity:
        public void get_local_physics_velocity(AC1Legacy.Vector3* retval) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, AC1Legacy.Vector3*, void>)0x00512C10)(ref this, retval); // .text:00512140 ; void __thiscall CPhysicsObj::get_local_physics_velocity(CPhysicsObj *this, AC1Legacy::Vector3 *retval) .text:00512140 ?get_local_physics_velocity@CPhysicsObj@@QBEXAAVVector3@AC1Legacy@@@Z

        // CPhysicsObj.RemoveObjectFromSingleCell:
        public void RemoveObjectFromSingleCell(CObjCell* obj_cell) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CObjCell*, void>)0x00513EF0)(ref this, obj_cell); // .text:005133F0 ; void __thiscall CPhysicsObj::RemoveObjectFromSingleCell(CPhysicsObj *this, CObjCell *obj_cell) .text:005133F0 ?RemoveObjectFromSingleCell@CPhysicsObj@@QAEXPAVCObjCell@@@Z

        // CPhysicsObj.calc_cross_cells_static:
        public void calc_cross_cells_static() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00515C60)(ref this); // .text:00515160 ; void __thiscall CPhysicsObj::calc_cross_cells_static(CPhysicsObj *this) .text:00515160 ?calc_cross_cells_static@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.calc_cross_cells:
        public void calc_cross_cells() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00515D30)(ref this); // .text:00515230 ; void __thiscall CPhysicsObj::calc_cross_cells(CPhysicsObj *this) .text:00515230 ?calc_cross_cells@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.leave_world:
        public void leave_world() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x005160A0)(ref this); // .text:005155A0 ; void __thiscall CPhysicsObj::leave_world(CPhysicsObj *this) .text:005155A0 ?leave_world@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.TurnToObject_Internal:
        public void TurnToObject_Internal(UInt32 _object_id, UInt32 top_level_id, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, UInt32, MovementParameters*, void>)0x00510EC0)(ref this, _object_id, top_level_id, _params); // .text:005103F0 ; void __thiscall CPhysicsObj::TurnToObject_Internal(CPhysicsObj *this, unsigned int _object_id, unsigned int top_level_id, MovementParameters *params) .text:005103F0 ?TurnToObject_Internal@CPhysicsObj@@QAEXKKABVMovementParameters@@@Z

        // CPhysicsObj.get_landscape_coord:
        public int get_landscape_coord(int* x, int* y) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int*, int*, int>)0x00511850)(ref this, x, y); // .text:00510D80 ; int __thiscall CPhysicsObj::get_landscape_coord(CPhysicsObj *this, int *x, int *y) .text:00510D80 ?get_landscape_coord@CPhysicsObj@@QBEHAAJ0@Z

        // CPhysicsObj.set_ethereal:
        public int set_ethereal(int ethereal, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, int, int>)0x00512710)(ref this, ethereal, send_event); // .text:00511C40 ; int __thiscall CPhysicsObj::set_ethereal(CPhysicsObj *this, int ethereal, int send_event) .text:00511C40 ?set_ethereal@CPhysicsObj@@QAEHHH@Z

        // CPhysicsObj.GetStepDownHeight:
        public Single GetStepDownHeight() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x0050F4F0)(ref this); // .text:0050EA20 ; float __thiscall CPhysicsObj::GetStepDownHeight(CPhysicsObj *this) .text:0050EA20 ?GetStepDownHeight@CPhysicsObj@@QBEMXZ

        // CPhysicsObj.ConstrainTo:
        public void ConstrainTo(Position* p, Single start_distance, Single max_distance) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Position*, Single, Single, void>)0x00510FF0)(ref this, p, start_distance, max_distance); // .text:00510520 ; void __thiscall CPhysicsObj::ConstrainTo(CPhysicsObj *this, Position *p, float start_distance, float max_distance) .text:00510520 ?ConstrainTo@CPhysicsObj@@QAEXABVPosition@@MM@Z

        // CPhysicsObj.SetPartDiffusion:
        public void SetPartDiffusion(UInt32 part, Single start, Single end, Double delta) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, Single, Single, Double, void>)0x00512400)(ref this, part, start, end, delta); // .text:00511930 ; void __thiscall CPhysicsObj::SetPartDiffusion(CPhysicsObj *this, unsigned int part, float start, float end, long double delta) .text:00511930 ?SetPartDiffusion@CPhysicsObj@@QAEXKMMN@Z

        // CPhysicsObj.get_object_info:
        public UInt32 get_object_info(CTransition* transit, int admin_move) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CTransition*, int, UInt32>)0x00512790)(ref this, transit, admin_move); // .text:00511CC0 ; unsigned int __thiscall CPhysicsObj::get_object_info(CPhysicsObj *this, CTransition *transit, int admin_move) .text:00511CC0 ?get_object_info@CPhysicsObj@@IBEKPAVCTransition@@H@Z

        // CPhysicsObj.InitPartArrayObject:
        public int InitPartArrayObject(UInt32 data_did, int bCreateParts) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int, int>)0x005131B0)(ref this, data_did, bCreateParts); // .text:005126B0 ; int __thiscall CPhysicsObj::InitPartArrayObject(CPhysicsObj *this, IDClass<_tagDataID,32,0> data_did, int bCreateParts) .text:005126B0 ?InitPartArrayObject@CPhysicsObj@@IAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@H@Z

        // CPhysicsObj.UpdateViewerDistance:
        public void UpdateViewerDistance() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00511600)(ref this); // .text:00510B30 ; void __thiscall CPhysicsObj::UpdateViewerDistance(CPhysicsObj *this) .text:00510B30 ?UpdateViewerDistance@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.set_heading:
        public void set_heading(Single degrees, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, int, void>)0x00514C60)(ref this, degrees, send_event); // .text:00514160 ; void __thiscall CPhysicsObj::set_heading(CPhysicsObj *this, float degrees, int send_event) .text:00514160 ?set_heading@CPhysicsObj@@QAEXMH@Z

        // CPhysicsObj.calc_friction:
        public void calc_friction(Single quantum, Single velocity_mag2) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Single, void>)0x0050F940)(ref this, quantum, velocity_mag2); // .text:0050EE70 ; void __thiscall CPhysicsObj::calc_friction(CPhysicsObj *this, float quantum, float velocity_mag2) .text:0050EE70 ?calc_friction@CPhysicsObj@@IAEXMM@Z

        // CPhysicsObj.play_script:
        public int play_script(UInt32 script_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x00511800)(ref this, script_id); // .text:00510D30 ; int __thiscall CPhysicsObj::play_script(CPhysicsObj *this, IDClass<_tagDataID,32,0> script_id) .text:00510D30 ?play_script@CPhysicsObj@@QAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CPhysicsObj.UpdatePositionInternal:
        public void UpdatePositionInternal(Single quantum, Frame* o_newFrame) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Frame*, void>)0x00513730)(ref this, quantum, o_newFrame); // .text:00512C30 ; void __thiscall CPhysicsObj::UpdatePositionInternal(CPhysicsObj *this, float quantum, Frame *o_newFrame) .text:00512C30 ?UpdatePositionInternal@CPhysicsObj@@IAEXMAAVFrame@@@Z

        // CPhysicsObj.set_target_quantum:
        public void set_target_quantum(Double new_quantum) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Double, void>)0x0050F870)(ref this, new_quantum); // .text:0050EDA0 ; void __thiscall CPhysicsObj::set_target_quantum(CPhysicsObj *this, long double new_quantum) .text:0050EDA0 ?set_target_quantum@CPhysicsObj@@QAEXN@Z

        // CPhysicsObj.add_child:
        public int add_child(CPhysicsObj* obj, UInt32 part_index, Frame* frame) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, UInt32, Frame*, int>)0x005103C0)(ref this, obj, part_index, frame); // .text:0050F8F0 ; int __thiscall CPhysicsObj::add_child(CPhysicsObj *this, CPhysicsObj *obj, unsigned int part_index, Frame *frame) .text:0050F8F0 ?add_child@CPhysicsObj@@IAEHPAV1@KABVFrame@@@Z

        // CPhysicsObj.set_local_velocity:
        public void set_local_velocity(AC1Legacy.Vector3* new_velocity, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, AC1Legacy.Vector3*, int, void>)0x00511FA0)(ref this, new_velocity, send_event); // .text:005114D0 ; void __thiscall CPhysicsObj::set_local_velocity(CPhysicsObj *this, AC1Legacy::Vector3 *new_velocity, int send_event) .text:005114D0 ?set_local_velocity@CPhysicsObj@@QAEXABVVector3@AC1Legacy@@H@Z

        // CPhysicsObj.SetTranslucency:
        public void SetTranslucency(Single _translucency, Double delta) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Double, void>)0x005120C0)(ref this, _translucency, delta); // .text:005115F0 ; void __thiscall CPhysicsObj::SetTranslucency(CPhysicsObj *this, float _translucency, long double delta) .text:005115F0 ?SetTranslucency@CPhysicsObj@@QAEXMN@Z

        // CPhysicsObj.enter_world:
        public int enter_world(Position* p) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Position*, int>)0x00516E10)(ref this, p); // .text:00516310 ; int __thiscall CPhysicsObj::enter_world(CPhysicsObj *this, Position *p) .text:00516310 ?enter_world@CPhysicsObj@@QAEHABVPosition@@@Z

        // CPhysicsObj.IsFullyConstrained:
        public int IsFullyConstrained() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x0050F730)(ref this); // .text:0050EC60 ; int __thiscall CPhysicsObj::IsFullyConstrained(CPhysicsObj *this) .text:0050EC60 ?IsFullyConstrained@CPhysicsObj@@QBEHXZ

        // CPhysicsObj.check_contact:
        public int check_contact(int contact) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, int>)0x00510080)(ref this, contact); // .text:0050F5B0 ; int __thiscall CPhysicsObj::check_contact(CPhysicsObj *this, int contact) .text:0050F5B0 ?check_contact@CPhysicsObj@@IBEHH@Z

        // CPhysicsObj.get_distance_to_object:
        public Single get_distance_to_object(CPhysicsObj* _object, int use_cyls) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, int, Single>)0x00510270)(ref this, _object, use_cyls); // .text:0050F7A0 ; float __thiscall CPhysicsObj::get_distance_to_object(CPhysicsObj *this, CPhysicsObj *object, int use_cyls) .text:0050F7A0 ?get_distance_to_object@CPhysicsObj@@QAEMPAV1@H@Z

        // CPhysicsObj.report_attacks:
        public void report_attacks(AttackInfo* attack_info) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, AttackInfo*, void>)0x00511010)(ref this, attack_info); // .text:00510540 ; void __thiscall CPhysicsObj::report_attacks(CPhysicsObj *this, AttackInfo *attack_info) .text:00510540 ?report_attacks@CPhysicsObj@@IAEXPAVAttackInfo@@@Z

        // CPhysicsObj.CallPES:
        public void CallPES(UInt32 pes, Double delta) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, Double, void>)0x005125C0)(ref this, pes, delta); // .text:00511AF0 ; void __thiscall CPhysicsObj::CallPES(CPhysicsObj *this, IDClass<_tagDataID,32,0> pes, long double delta) .text:00511AF0 ?CallPES@CPhysicsObj@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@N@Z

        // CPhysicsObj.makeObject:
        public static CPhysicsObj* makeObject(UInt32 data_did, UInt32 _object_iid, int bDynamic) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, int, CPhysicsObj*>)0x00514470)(data_did, _object_iid, bDynamic); // .text:00513970 ; CPhysicsObj *__cdecl CPhysicsObj::makeObject(IDClass<_tagDataID,32,0> data_did, unsigned int _object_iid, int bDynamic) .text:00513970 ?makeObject@CPhysicsObj@@SAPAV1@V?$IDClass@U_tagDataID@@$0CA@$0A@@@KH@Z

        // CPhysicsObj.add_voyeur:
        public void add_voyeur(UInt32 _object_id, Single radius, Single quantum) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, Single, Single, void>)0x0050F8D0)(ref this, _object_id, radius, quantum); // .text:0050EE00 ; void __thiscall CPhysicsObj::add_voyeur(CPhysicsObj *this, unsigned int _object_id, float radius, float quantum) .text:0050EE00 ?add_voyeur@CPhysicsObj@@QAEXKMM@Z

        // CPhysicsObj.stop_particle_emitter:
        public int stop_particle_emitter(UInt32 emitter_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x0050FEF0)(ref this, emitter_id); // .text:0050F420 ; int __thiscall CPhysicsObj::stop_particle_emitter(CPhysicsObj *this, unsigned int emitter_id) .text:0050F420 ?stop_particle_emitter@CPhysicsObj@@QAEHK@Z

        // CPhysicsObj.makeNullObject:
        public static CPhysicsObj* makeNullObject(UInt32 object_iid, int bDynamic) => ((delegate* unmanaged[Cdecl]<UInt32, int, CPhysicsObj*>)0x00513100)(object_iid, bDynamic); // .text:00512600 ; CPhysicsObj *__cdecl CPhysicsObj::makeNullObject(unsigned int _object_iid, int bDynamic) .text:00512600 ?makeNullObject@CPhysicsObj@@SAPAV1@KH@Z

        // CPhysicsObj.UpdateChild:
        public void UpdateChild(CPhysicsObj* child_obj, UInt32 part_index, Frame* child_frame) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, UInt32, Frame*, void>)0x00513850)(ref this, child_obj, part_index, child_frame); // .text:00512D50 ; void __thiscall CPhysicsObj::UpdateChild(CPhysicsObj *this, CPhysicsObj *child_obj, unsigned int part_index, Frame *child_frame) .text:00512D50 ?UpdateChild@CPhysicsObj@@IAEXPAV1@KABVFrame@@@Z

        // CPhysicsObj.clear_sequence_anims:
        public void clear_sequence_anims() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00510230)(ref this); // .text:0050F760 ; void __thiscall CPhysicsObj::clear_sequence_anims(CPhysicsObj *this) .text:0050F760 ?clear_sequence_anims@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetNoDraw:
        public void SetNoDraw(int no_draw) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, void>)0x00510470)(ref this, no_draw); // .text:0050F9A0 ; void __thiscall CPhysicsObj::SetNoDraw(CPhysicsObj *this, int no_draw) .text:0050F9A0 ?SetNoDraw@CPhysicsObj@@QAEXH@Z

        // CPhysicsObj.InitObjectEnd:
        public int InitObjectEnd() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00510AB0)(ref this); // .text:0050FFE0 ; int __thiscall CPhysicsObj::InitObjectEnd(CPhysicsObj *this) .text:0050FFE0 ?InitObjectEnd@CPhysicsObj@@IAEHXZ

        // CPhysicsObj.MoveToObject_Internal:
        public void MoveToObject_Internal(UInt32 _object_id, UInt32 top_level_id, Single _object_radius, Single _object_height, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, UInt32, Single, Single, MovementParameters*, void>)0x00510DB0)(ref this, _object_id, top_level_id, _object_radius, _object_height, _params); // .text:005102E0 ; void __thiscall CPhysicsObj::MoveToObject_Internal(CPhysicsObj *this, unsigned int _object_id, unsigned int top_level_id, float _object_radius, float _object_height, MovementParameters *params) .text:005102E0 ?MoveToObject_Internal@CPhysicsObj@@QAEXKKMMABVMovementParameters@@@Z

        // CPhysicsObj.obj_within_block:
        public int obj_within_block() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00511B00)(ref this); // .text:00511030 ; int __thiscall CPhysicsObj::obj_within_block(CPhysicsObj *this) .text:00511030 ?obj_within_block@CPhysicsObj@@QAEHXZ

        // CPhysicsObj.prepare_to_enter_world:
        public void prepare_to_enter_world() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00512A70)(ref this); // .text:00511FA0 ; void __thiscall CPhysicsObj::prepare_to_enter_world(CPhysicsObj *this) .text:00511FA0 ?prepare_to_enter_world@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.play_script:
        public int play_script(PScriptType script_type, Single mod) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, PScriptType, Single, int>)0x00513D60)(ref this, script_type, mod); // .text:00513260 ; int __thiscall CPhysicsObj::play_script(CPhysicsObj *this, PScriptType script_type, float mod) .text:00513260 ?play_script@CPhysicsObj@@QAEHW4PScriptType@@M@Z

        // CPhysicsObj.check_attack:
        public UInt32 check_attack(Position* attacker_pos, Single attacker_scale, AttackCone* attack_cone, Single attacker_attack_radius) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Position*, Single, AttackCone*, Single, UInt32>)0x0050F750)(ref this, attacker_pos, attacker_scale, attack_cone, attacker_attack_radius); // .text:0050EC80 ; unsigned int __thiscall CPhysicsObj::check_attack(CPhysicsObj *this, Position *attacker_pos, const float attacker_scale, AttackCone *attack_cone, float attacker_attack_radius) .text:0050EC80 ?check_attack@CPhysicsObj@@QBEKABVPosition@@MABVAttackCone@@M@Z

        // CPhysicsObj.play_default_script:
        public int play_default_script() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00513DB0)(ref this); // .text:005132B0 ; int __thiscall CPhysicsObj::play_default_script(CPhysicsObj *this) .text:005132B0 ?play_default_script@CPhysicsObj@@QAEHXZ

        // CPhysicsObj.DoInterpretedMotion:
        public UInt32 DoInterpretedMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, MovementParameters*, UInt32>)0x0050F540)(ref this, motion, _params); // .text:0050EA70 ; unsigned int __thiscall CPhysicsObj::DoInterpretedMotion(CPhysicsObj *this, unsigned int motion, MovementParameters *params) .text:0050EA70 ?DoInterpretedMotion@CPhysicsObj@@QAEKKABVMovementParameters@@@Z

        // CPhysicsObj.is_completely_visible:
        public int is_completely_visible() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00511D90)(ref this); // .text:005112C0 ; int __thiscall CPhysicsObj::is_completely_visible(CPhysicsObj *this) .text:005112C0 ?is_completely_visible@CPhysicsObj@@QAEHXZ

        // CPhysicsObj.get_curr_frame_number:
        public UInt32 get_curr_frame_number() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32>)0x00510250)(ref this); // .text:0050F780 ; unsigned int __thiscall CPhysicsObj::get_curr_frame_number(CPhysicsObj *this) .text:0050F780 ?get_curr_frame_number@CPhysicsObj@@QBEKXZ

        // CPhysicsObj.on_ground:
        public int on_ground() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00528730)(ref this); // .text:00527B20 ; int __thiscall CPhysicsObj::on_ground(CPhysicsObj *this) .text:00527B20 ?on_ground@CPhysicsObj@@QBEHXZ

        // CPhysicsObj.ethereal_check_for_collisions:
        public int ethereal_check_for_collisions() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00511510)(ref this); // .text:00510A40 ; int __thiscall CPhysicsObj::ethereal_check_for_collisions(CPhysicsObj *this) .text:00510A40 ?ethereal_check_for_collisions@CPhysicsObj@@IAEHXZ

        // CPhysicsObj.InitializeMotionTables:
        public void InitializeMotionTables() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x0050F530)(ref this); // .text:0050EA60 ; void __thiscall CPhysicsObj::InitializeMotionTables(CPhysicsObj *this) .text:0050EA60 ?InitializeMotionTables@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetPlacementFrameInternal:
        public int SetPlacementFrameInternal(UInt32 frame_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x00510160)(ref this, frame_id); // .text:0050F690 ; int __thiscall CPhysicsObj::SetPlacementFrameInternal(CPhysicsObj *this, unsigned int frame_id) .text:0050F690 ?SetPlacementFrameInternal@CPhysicsObj@@IAEHK@Z

        // CPhysicsObj.set_nodraw:
        public int set_nodraw(int nodraw, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, int, int>)0x00510770)(ref this, nodraw, send_event); // .text:0050FCA0 ; int __thiscall CPhysicsObj::set_nodraw(CPhysicsObj *this, int nodraw, int send_event) .text:0050FCA0 ?set_nodraw@CPhysicsObj@@QAEHHH@Z

        // CPhysicsObj.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00512EF0)(ref this); // .text:005123F0 ; void __thiscall CPhysicsObj::CPhysicsObj(CPhysicsObj *this) .text:005123F0 ??0CPhysicsObj@@QAE@XZ

        // CPhysicsObj.get_frame:
        public Frame* get_frame() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Frame*>)0x00452950)(ref this); // .text:00452910 ; Frame *__thiscall CPhysicsObj::get_frame(CPhysicsObj *this) .text:00452910 ?get_frame@CPhysicsObj@@QBEABVFrame@@XZ

        // CPhysicsObj.MotionDone:
        public void MotionDone(UInt32 motion, int success) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int, void>)0x00510880)(ref this, motion, success); // .text:0050FDB0 ; void __thiscall CPhysicsObj::MotionDone(CPhysicsObj *this, unsigned int motion, int success) .text:0050FDB0 ?MotionDone@CPhysicsObj@@QAEXKH@Z

        // CPhysicsObj.InterpolateTo:
        public void InterpolateTo(Position* p, int keep_heading) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Position*, int, void>)0x00510FC0)(ref this, p, keep_heading); // .text:005104F0 ; void __thiscall CPhysicsObj::InterpolateTo(CPhysicsObj *this, Position *p, int keep_heading) .text:005104F0 ?InterpolateTo@CPhysicsObj@@QAEXABVPosition@@H@Z

        // CPhysicsObj.play_default_script:
        public int play_default_script(UInt32 part_index) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x00513E00)(ref this, part_index); // .text:00513300 ; int __thiscall CPhysicsObj::play_default_script(CPhysicsObj *this, unsigned int part_index) .text:00513300 ?play_default_script@CPhysicsObj@@QAEHK@Z

        // CPhysicsObj.UpdateViewerDistance:
        public void UpdateViewerDistance(Single _CYpt, AC1Legacy.Vector3* _viewer_heading) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, AC1Legacy.Vector3*, void>)0x0050FE10)(ref this, _CYpt, _viewer_heading); // .text:0050F340 ; void __thiscall CPhysicsObj::UpdateViewerDistance(CPhysicsObj *this, float _CYpt, AC1Legacy::Vector3 *_viewer_heading) .text:0050F340 ?UpdateViewerDistance@CPhysicsObj@@QAEXMABVVector3@AC1Legacy@@@Z

        // CPhysicsObj.build_collision_profile:
        public int build_collision_profile(ObjCollisionProfile* prof, CPhysicsObj* obj, AC1Legacy.Vector3* vel, int amIInContact, int objIsMissile, int objHasContact) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, ObjCollisionProfile*, CPhysicsObj*, AC1Legacy.Vector3*, int, int, int, int>)0x005100D0)(ref this, prof, obj, vel, amIInContact, objIsMissile, objHasContact); // .text:0050F600 ; int __thiscall CPhysicsObj::build_collision_profile(CPhysicsObj *this, ObjCollisionProfile *prof, CPhysicsObj *obj, AC1Legacy::Vector3 *vel, const int amIInContact, const int objIsMissile, const int objHasContact) .text:0050F600 ?build_collision_profile@CPhysicsObj@@IBEHAAVObjCollisionProfile@@PBV1@ABVVector3@AC1Legacy@@HHH@Z

        // CPhysicsObj.DoObjDescChanges:
        public int DoObjDescChanges(ObjDesc* objdesc) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, ObjDesc*, int>)0x00510500)(ref this, objdesc); // .text:0050FA30 ; int __thiscall CPhysicsObj::DoObjDescChanges(CPhysicsObj *this, ObjDesc *objdesc) .text:0050FA30 ?DoObjDescChanges@CPhysicsObj@@QAEHPBVObjDesc@@@Z

        // CPhysicsObj.reenter_visibility:
        public int reenter_visibility() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00516D50)(ref this); // .text:00516250 ; int __thiscall CPhysicsObj::reenter_visibility(CPhysicsObj *this) .text:00516250 ?reenter_visibility@CPhysicsObj@@QAEHXZ

        // CPhysicsObj.get_heading:
        public Single get_heading() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x00512010)(ref this); // .text:00511540 ; float __thiscall CPhysicsObj::get_heading(CPhysicsObj *this) .text:00511540 ?get_heading@CPhysicsObj@@QBEMXZ

        // CPhysicsObj.clear_transient_states:
        public void clear_transient_states() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x005126C0)(ref this); // .text:00511BF0 ; void __thiscall CPhysicsObj::clear_transient_states(CPhysicsObj *this) .text:00511BF0 ?clear_transient_states@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.set_state:
        public int set_state(UInt32 new_state, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int, int>)0x005158D0)(ref this, new_state, send_event); // .text:00514DD0 ; int __thiscall CPhysicsObj::set_state(CPhysicsObj *this, unsigned int new_state, int send_event) .text:00514DD0 ?set_state@CPhysicsObj@@QAEHKH@Z

        // CPhysicsObj.set_omega:
        public void set_omega(AC1Legacy.Vector3* new_omega, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, AC1Legacy.Vector3*, int, void>)0x005101A0)(ref this, new_omega, send_event); // .text:0050F6D0 ; void __thiscall CPhysicsObj::set_omega(CPhysicsObj *this, AC1Legacy::Vector3 *new_omega, int send_event) .text:0050F6D0 ?set_omega@CPhysicsObj@@QAEXABVVector3@AC1Legacy@@H@Z

        // CPhysicsObj.report_exhaustion:
        // public void report_exhaustion() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0xDEADBEEF)(ref this); // .text:0050FDD0 ; void __thiscall CPhysicsObj::report_exhaustion(CPhysicsObj *this) .text:0050FDD0 ?report_exhaustion@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.DrawRecursive:
        public void DrawRecursive() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00511760)(ref this); // .text:00510C90 ; void __thiscall CPhysicsObj::DrawRecursive(CPhysicsObj *this) .text:00510C90 ?DrawRecursive@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.AddPartToShadowCells:
        public void AddPartToShadowCells(CPhysicsPart* part) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsPart*, void>)0x005118D0)(ref this, part); // .text:00510E00 ; void __thiscall CPhysicsObj::AddPartToShadowCells(CPhysicsObj *this, CPhysicsPart *part) .text:00510E00 ?AddPartToShadowCells@CPhysicsObj@@QAEXPAVCPhysicsPart@@@Z

        // CPhysicsObj.SetPartLuminosity:
        public void SetPartLuminosity(UInt32 part, Single start, Single end, Double delta) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, Single, Single, Double, void>)0x005122B0)(ref this, part, start, end, delta); // .text:005117E0 ; void __thiscall CPhysicsObj::SetPartLuminosity(CPhysicsObj *this, unsigned int part, float start, float end, long double delta) .text:005117E0 ?SetPartLuminosity@CPhysicsObj@@QAEXKMMN@Z

        // CPhysicsObj.prepare_to_leave_visibility:
        public int prepare_to_leave_visibility() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00512A10)(ref this); // .text:00511F40 ; int __thiscall CPhysicsObj::prepare_to_leave_visibility(CPhysicsObj *this) .text:00511F40 ?prepare_to_leave_visibility@CPhysicsObj@@QAEHXZ

        // CPhysicsObj.StopInterpolating:
        public void StopInterpolating() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x0050F610)(ref this); // .text:0050EB40 ; void __thiscall CPhysicsObj::StopInterpolating(CPhysicsObj *this) .text:0050EB40 ?StopInterpolating@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.GetMaxConstraintDistance:
        public Single GetMaxConstraintDistance() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x0050F6E0)(ref this); // .text:0050EC10 ; float __thiscall CPhysicsObj::GetMaxConstraintDistance(CPhysicsObj *this) .text:0050EC10 ?GetMaxConstraintDistance@CPhysicsObj@@QBE?BMXZ

        // CPhysicsObj.StopCompletely:
        public void StopCompletely(int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, void>)0x00510C50)(ref this, send_event); // .text:00510180 ; void __thiscall CPhysicsObj::StopCompletely(CPhysicsObj *this, int send_event) .text:00510180 ?StopCompletely@CPhysicsObj@@QAEXH@Z

        // CPhysicsObj.report_object_collision_end:
        public int report_object_collision_end(UInt32 _object_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x00511560)(ref this, _object_id); // .text:00510A90 ; int __thiscall CPhysicsObj::report_object_collision_end(CPhysicsObj *this, const unsigned int _object_id) .text:00510A90 ?report_object_collision_end@CPhysicsObj@@IAEHK@Z

        // CPhysicsObj.RestoreLighting:
        public void RestoreLighting() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00512580)(ref this); // .text:00511AB0 ; void __thiscall CPhysicsObj::RestoreLighting(CPhysicsObj *this) .text:00511AB0 ?RestoreLighting@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.get_walkable_z:
        public Single get_walkable_z() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x00510030)(ref this); // .text:0050F560 ; float __thiscall CPhysicsObj::get_walkable_z(CPhysicsObj *this) .text:0050F560 ?get_walkable_z@CPhysicsObj@@QAEMXZ

        // CPhysicsObj.SetTranslucencyInternal:
        public void SetTranslucencyInternal(Single _translucency) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, void>)0x00510430)(ref this, _translucency); // .text:0050F960 ; void __thiscall CPhysicsObj::SetTranslucencyInternal(CPhysicsObj *this, float _translucency) .text:0050F960 ?SetTranslucencyInternal@CPhysicsObj@@IAEXM@Z

        // CPhysicsObj.GetSetupID:
        public UInt32* GetSetupID(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32*, UInt32*>)0x0050F430)(ref this, result); // .text:0050E960 ; IDClass<_tagDataID,32,0> *__thiscall CPhysicsObj::GetSetupID(CPhysicsObj *this, IDClass<_tagDataID,32,0> *result) .text:0050E960 ?GetSetupID@CPhysicsObj@@QBE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // CPhysicsObj.GetObjectA:
        public static CPhysicsObj* GetObjectA(UInt32 object_id) => ((delegate* unmanaged[Cdecl]<UInt32, CPhysicsObj*>)0x0050FF60)(object_id); // .text:0050F490 ; CPhysicsObj *__cdecl CPhysicsObj::GetObjectA(unsigned int _object_id) .text:0050F490 ?GetObjectA@CPhysicsObj@@SAPAV1@K@Z

        // CPhysicsObj.DoObjDescChangesFromDefault:
        public int DoObjDescChangesFromDefault(ObjDesc* objdesc) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, ObjDesc*, int>)0x00510480)(ref this, objdesc); // .text:0050F9B0 ; int __thiscall CPhysicsObj::DoObjDescChangesFromDefault(CPhysicsObj *this, ObjDesc *objdesc) .text:0050F9B0 ?DoObjDescChangesFromDefault@CPhysicsObj@@QAEHPBVObjDesc@@@Z

        // CPhysicsObj.GetBoundingBox:
        public Byte GetBoundingBox(BBox* o_bbox) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, BBox*, Byte>)0x00510910)(ref this, o_bbox); // .text:0050FE40 ; bool __thiscall CPhysicsObj::GetBoundingBox(CPhysicsObj *this, BBox *o_bbox) .text:0050FE40 ?GetBoundingBox@CPhysicsObj@@QBE_NAAVBBox@@@Z

        // CPhysicsObj.attack:
        public void attack(AttackCone* attack_cone) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, AttackCone*, void>)0x00513570)(ref this, attack_cone); // .text:00512A70 ; void __thiscall CPhysicsObj::attack(CPhysicsObj *this, AttackCone *attack_cone) .text:00512A70 ?attack@CPhysicsObj@@QAEXABVAttackCone@@@Z

        // CPhysicsObj.SetPlacementFrame:
        public int SetPlacementFrame(UInt32 frame_id, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int, int>)0x00511E50)(ref this, frame_id, send_event); // .text:00511380 ; int __thiscall CPhysicsObj::SetPlacementFrame(CPhysicsObj *this, unsigned int frame_id, int send_event) .text:00511380 ?SetPlacementFrame@CPhysicsObj@@QAEHKH@Z

        // CPhysicsObj.report_object_collision:
        public int report_object_collision(CPhysicsObj* _object, int prev_has_contact) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, int, int>)0x00513B60)(ref this, _object, prev_has_contact); // .text:00513060 ; int __thiscall CPhysicsObj::report_object_collision(CPhysicsObj *this, CPhysicsObj *object, int prev_has_contact) .text:00513060 ?report_object_collision@CPhysicsObj@@IAEHPBV1@H@Z

        // CPhysicsObj.MoveOrTeleport:
        public int MoveOrTeleport(Position* p, UInt16 teleport_timestamp, int contact, AC1Legacy.Vector3* velocity) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Position*, UInt16, int, AC1Legacy.Vector3*, int>)0x00516E30)(ref this, p, teleport_timestamp, contact, velocity); // .text:00516330 ; int __thiscall CPhysicsObj::MoveOrTeleport(CPhysicsObj *this, Position *p, unsigned __int16 teleport_timestamp, int contact, AC1Legacy::Vector3 *velocity) .text:00516330 ?MoveOrTeleport@CPhysicsObj@@QAEHAAVPosition@@GHABVVector3@AC1Legacy@@@Z

        // CPhysicsObj.MakePositionManager:
        public void MakePositionManager() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00510CE0)(ref this); // .text:00510210 ; void __thiscall CPhysicsObj::MakePositionManager(CPhysicsObj *this) .text:00510210 ?MakePositionManager@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.TurnToHeading:
        public void TurnToHeading(MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, MovementParameters*, void>)0x00513480)(ref this, _params); // .text:00512980 ; void __thiscall CPhysicsObj::TurnToHeading(CPhysicsObj *this, MovementParameters *params) .text:00512980 ?TurnToHeading@CPhysicsObj@@QAEXABVMovementParameters@@@Z

        // CPhysicsObj.SetPositionInternal:
        public int SetPositionInternal(CTransition* transit) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CTransition*, int>)0x00515E30)(ref this, transit); // .text:00515330 ; int __thiscall CPhysicsObj::SetPositionInternal(CPhysicsObj *this, CTransition *transit) .text:00515330 ?SetPositionInternal@CPhysicsObj@@IAEHPBVCTransition@@@Z

        // CPhysicsObj.HasAnims:
        public int HasAnims() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int>)0x00510240)(ref this); // .text:0050F770 ; int __thiscall CPhysicsObj::HasAnims(CPhysicsObj *this) .text:0050F770 ?HasAnims@CPhysicsObj@@QBEHXZ

        // CPhysicsObj.add_child:
        public int add_child(CPhysicsObj* obj, UInt32 where) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, UInt32, int>)0x00510340)(ref this, obj, where); // .text:0050F870 ; int __thiscall CPhysicsObj::add_child(CPhysicsObj *this, CPhysicsObj *obj, unsigned int where) .text:0050F870 ?add_child@CPhysicsObj@@IAEHPAV1@K@Z

        // CPhysicsObj.get_velocity:
        public AC1Legacy.Vector3* get_velocity(AC1Legacy.Vector3* result) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, AC1Legacy.Vector3*, AC1Legacy.Vector3*>)0x00511E90)(ref this, result); // .text:005113C0 ; AC1Legacy::Vector3 *__thiscall CPhysicsObj::get_velocity(CPhysicsObj *this, AC1Legacy::Vector3 *result) .text:005113C0 ?get_velocity@CPhysicsObj@@QBE?AVVector3@AC1Legacy@@XZ

        // CPhysicsObj.InitDefaults:
        public void InitDefaults(CSetup* setup) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CSetup*, void>)0x005144D0)(ref this, setup); // .text:005139D0 ; void __thiscall CPhysicsObj::InitDefaults(CPhysicsObj *this, CSetup *setup) .text:005139D0 ?InitDefaults@CPhysicsObj@@QAEXPBVCSetup@@@Z

        // CPhysicsObj.SetTranslucency2:
        public void SetTranslucency2(Single _start_translucency, Single _end_translucency, Double delta) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Single, Double, void>)0x00510620)(ref this, _start_translucency, _end_translucency, delta); // .text:0050FB50 ; void __thiscall CPhysicsObj::SetTranslucency2(CPhysicsObj *this, float _start_translucency, float _end_translucency, long double delta) .text:0050FB50 ?SetTranslucency2@CPhysicsObj@@QAEXMMN@Z

        // CPhysicsObj.play_script_internal:
        public int play_script_internal(UInt32 script_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x005117A0)(ref this, script_id); // .text:00510CD0 ; int __thiscall CPhysicsObj::play_script_internal(CPhysicsObj *this, IDClass<_tagDataID,32,0> script_id) .text:00510CD0 ?play_script_internal@CPhysicsObj@@IAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CPhysicsObj.HandleUpdateTarget:
        public void HandleUpdateTarget(TargetInfo target_info) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, TargetInfo, void>)0x005136C0)(ref this, target_info); // .text:00512BC0 ; void __thiscall CPhysicsObj::HandleUpdateTarget(CPhysicsObj *this, TargetInfo target_info) .text:00512BC0 ?HandleUpdateTarget@CPhysicsObj@@QAEXVTargetInfo@@@Z

        // CPhysicsObj.change_cell:
        public void change_cell(CObjCell* new_cell) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CObjCell*, void>)0x00513E90)(ref this, new_cell); // .text:00513390 ; void __thiscall CPhysicsObj::change_cell(CPhysicsObj *this, CObjCell *new_cell) .text:00513390 ?change_cell@CPhysicsObj@@QAEXPAVCObjCell@@@Z

        // CPhysicsObj.play_sound:
        public int play_sound(SoundType sound_type, Single volume) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, SoundType, Single, int>)0x0050FF30)(ref this, sound_type, volume); // .text:0050F460 ; int __thiscall CPhysicsObj::play_sound(CPhysicsObj *this, SoundType sound_type, float volume) .text:0050F460 ?play_sound@CPhysicsObj@@QBEHW4SoundType@@M@Z

        // CPhysicsObj.UpdatePartsInternal:
        public void UpdatePartsInternal() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00510140)(ref this); // .text:0050F670 ; void __thiscall CPhysicsObj::UpdatePartsInternal(CPhysicsObj *this) .text:0050F670 ?UpdatePartsInternal@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.set_parent:
        public int set_parent(CPhysicsObj* obj, UInt32 where) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, UInt32, int>)0x00516590)(ref this, obj, where); // .text:00515A90 ; int __thiscall CPhysicsObj::set_parent(CPhysicsObj *this, CPhysicsObj *obj, unsigned int where) .text:00515A90 ?set_parent@CPhysicsObj@@QAEHPAV1@K@Z

        // CPhysicsObj.SetPositionSimple:
        public SetPositionError SetPositionSimple(Position* p, int sliding) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Position*, int, SetPositionError>)0x00516DB0)(ref this, p, sliding); // .text:005162B0 ; SetPositionError __thiscall CPhysicsObj::SetPositionSimple(CPhysicsObj *this, Position *p, int sliding) .text:005162B0 ?SetPositionSimple@CPhysicsObj@@QAE?AW4SetPositionError@@ABVPosition@@H@Z

        // CPhysicsObj.get_num_emitters:
        public UInt32 get_num_emitters() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32>)0x0050FF10)(ref this); // .text:0050F440 ; unsigned int __thiscall CPhysicsObj::get_num_emitters(CPhysicsObj *this) .text:0050F440 ?get_num_emitters@CPhysicsObj@@QAEKXZ

        // CPhysicsObj.set_on_walkable:
        public void set_on_walkable(int is_on_walkable) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, void>)0x00511DE0)(ref this, is_on_walkable); // .text:00511310 ; void __thiscall CPhysicsObj::set_on_walkable(CPhysicsObj *this, int is_on_walkable) .text:00511310 ?set_on_walkable@CPhysicsObj@@QAEXH@Z

        // CPhysicsObj.set_target:
        public void set_target(UInt32 context_id, UInt32 _object_id, Single radius, Double quantum) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, UInt32, Single, Double, void>)0x0050F800)(ref this, context_id, _object_id, radius, quantum); // .text:0050ED30 ; void __thiscall CPhysicsObj::set_target(CPhysicsObj *this, unsigned int context_id, unsigned int _object_id, float radius, long double quantum) .text:0050ED30 ?set_target@CPhysicsObj@@QAEXKKMN@Z

        // CPhysicsObj.set_sequence_animation:
        public void set_sequence_animation(UInt32 anim_id, int interrupt, UInt32 start_frame, Single frame_rate) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int, UInt32, Single, void>)0x005101C0)(ref this, anim_id, interrupt, start_frame, frame_rate); // .text:0050F6F0 ; void __thiscall CPhysicsObj::set_sequence_animation(CPhysicsObj *this, IDClass<_tagDataID,32,0> anim_id, int interrupt, unsigned int start_frame, float frame_rate) .text:0050F6F0 ?set_sequence_animation@CPhysicsObj@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@HKM@Z

        // CPhysicsObj.find_bbox_cell_list:
        public void find_bbox_cell_list(CELLARRAY* cell_array) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CELLARRAY*, void>)0x00511A90)(ref this, cell_array); // .text:00510FC0 ; void __thiscall CPhysicsObj::find_bbox_cell_list(CPhysicsObj *this, CELLARRAY *cell_array) .text:00510FC0 ?find_bbox_cell_list@CPhysicsObj@@IAEXAAVCELLARRAY@@@Z

        // CPhysicsObj.set_velocity:
        public void set_velocity(AC1Legacy.Vector3* new_velocity, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, AC1Legacy.Vector3*, int, void>)0x00511EC0)(ref this, new_velocity, send_event); // .text:005113F0 ; void __thiscall CPhysicsObj::set_velocity(CPhysicsObj *this, AC1Legacy::Vector3 *new_velocity, int send_event) .text:005113F0 ?set_velocity@CPhysicsObj@@QAEXABVVector3@AC1Legacy@@H@Z

        // CPhysicsObj.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x005145D0)(ref this); // .text:00513AD0 ; void __thiscall CPhysicsObj::Destroy(CPhysicsObj *this) .text:00513AD0 ?Destroy@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.SetScatterPositionInternal:
        public SetPositionError SetScatterPositionInternal(SetPositionStruct* sps, CTransition* transit) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, SetPositionStruct*, CTransition*, SetPositionError>)0x00516A00)(ref this, sps, transit); // .text:00515F00 ; SetPositionError __thiscall CPhysicsObj::SetScatterPositionInternal(CPhysicsObj *this, SetPositionStruct *sps, CTransition *transit) .text:00515F00 ?SetScatterPositionInternal@CPhysicsObj@@IAE?AW4SetPositionError@@ABVSetPositionStruct@@PAVCTransition@@@Z

        // CPhysicsObj.unstick_from_object:
        public void unstick_from_object() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x0050F5B0)(ref this); // .text:0050EAE0 ; void __thiscall CPhysicsObj::unstick_from_object(CPhysicsObj *this) .text:0050EAE0 ?unstick_from_object@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetTranslucencyHierarchical:
        public void SetTranslucencyHierarchical(Single _translucency) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, void>)0x00512190)(ref this, _translucency); // .text:005116C0 ; void __thiscall CPhysicsObj::SetTranslucencyHierarchical(CPhysicsObj *this, float _translucency) .text:005116C0 ?SetTranslucencyHierarchical@CPhysicsObj@@QAEXM@Z

        // CPhysicsObj.stick_to_object:
        public void stick_to_object(UInt32 _object_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, void>)0x005132E0)(ref this, _object_id); // .text:005127E0 ; void __thiscall CPhysicsObj::stick_to_object(CPhysicsObj *this, unsigned int _object_id) .text:005127E0 ?stick_to_object@CPhysicsObj@@QAEXK@Z

        // CPhysicsObj.TurnToObject:
        public void TurnToObject(UInt32 _object_id, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, MovementParameters*, void>)0x00513440)(ref this, _object_id, _params); // .text:00512940 ; void __thiscall CPhysicsObj::TurnToObject(CPhysicsObj *this, unsigned int _object_id, MovementParameters *params) .text:00512940 ?TurnToObject@CPhysicsObj@@QAEXKABVMovementParameters@@@Z

        // CPhysicsObj.makeAnimObject:
        public int makeAnimObject(UInt32 setup_id, int bCreateParts) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int, int>)0x0050F400)(ref this, setup_id, bCreateParts); // .text:0050E930 ; int __thiscall CPhysicsObj::makeAnimObject(CPhysicsObj *this, IDClass<_tagDataID,32,0> setup_id, int bCreateParts) .text:0050E930 ?makeAnimObject@CPhysicsObj@@IAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@H@Z

        // CPhysicsObj.get_target_quantum:
        public Single get_target_quantum() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x0050F890)(ref this); // .text:0050EDC0 ; float __thiscall CPhysicsObj::get_target_quantum(CPhysicsObj *this) .text:0050EDC0 ?get_target_quantum@CPhysicsObj@@QBEMXZ

        // CPhysicsObj.receive_target_update:
        public void receive_target_update(TargetInfo* info) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, TargetInfo*, void>)0x0050F8B0)(ref this, info); // .text:0050EDE0 ; void __thiscall CPhysicsObj::receive_target_update(CPhysicsObj *this, TargetInfo *info) .text:0050EDE0 ?receive_target_update@CPhysicsObj@@QAEXABVTargetInfo@@@Z

        // CPhysicsObj.set_weenie_obj_ptr:
        public void set_weenie_obj_ptr(CWeenieObject* wobj) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CWeenieObject*, void>)0x0050FFA0)(ref this, wobj); // .text:0050F4D0 ; void __thiscall CPhysicsObj::set_weenie_obj_ptr(CPhysicsObj *this, CWeenieObject *wobj) .text:0050F4D0 ?set_weenie_obj_ptr@CPhysicsObj@@QAEXPAVCWeenieObject@@@Z

        // CPhysicsObj.get_minterp:
        public CMotionInterp* get_minterp() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CMotionInterp*>)0x00512B90)(ref this); // .text:005120C0 ; CMotionInterp *__thiscall CPhysicsObj::get_minterp(CPhysicsObj *this) .text:005120C0 ?get_minterp@CPhysicsObj@@QAEPAVCMotionInterp@@XZ

        // CPhysicsObj.MoveToObject:
        public void MoveToObject(UInt32 _object_id, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, MovementParameters*, void>)0x00513360)(ref this, _object_id, _params); // .text:00512860 ; void __thiscall CPhysicsObj::MoveToObject(CPhysicsObj *this, unsigned int _object_id, MovementParameters *params) .text:00512860 ?MoveToObject@CPhysicsObj@@QAEXKABVMovementParameters@@@Z

        // CPhysicsObj.GetStepUpHeight:
        public Single GetStepUpHeight() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x0050F4D0)(ref this); // .text:0050EA00 ; float __thiscall CPhysicsObj::GetStepUpHeight(CPhysicsObj *this) .text:0050EA00 ?GetStepUpHeight@CPhysicsObj@@QBEMXZ

        // CPhysicsObj.enter_cell:
        public void enter_cell(CObjCell* new_cell) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CObjCell*, void>)0x005119A0)(ref this, new_cell); // .text:00510ED0 ; void __thiscall CPhysicsObj::enter_cell(CPhysicsObj *this, CObjCell *new_cell) .text:00510ED0 ?enter_cell@CPhysicsObj@@QAEXPAVCObjCell@@@Z

        // CPhysicsObj.InitNullObject:
        public int InitNullObject(UInt32 data_did) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, int>)0x00514410)(ref this, data_did); // .text:00513910 ; int __thiscall CPhysicsObj::InitNullObject(CPhysicsObj *this, IDClass<_tagDataID,32,0> data_did) .text:00513910 ?InitNullObject@CPhysicsObj@@QAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CPhysicsObj.InqRawMotionState:
        public RawMotionState* InqRawMotionState() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, RawMotionState*>)0x005108B0)(ref this); // .text:0050FDE0 ; RawMotionState *__thiscall CPhysicsObj::InqRawMotionState(CPhysicsObj *this) .text:0050FDE0 ?InqRawMotionState@CPhysicsObj@@QBEPBVRawMotionState@@XZ

        // CPhysicsObj.SetLighting:
        public void SetLighting(Single luminosity, Single diffuse) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Single, void>)0x00512550)(ref this, luminosity, diffuse); // .text:00511A80 ; void __thiscall CPhysicsObj::SetLighting(CPhysicsObj *this, float luminosity, float diffuse) .text:00511A80 ?SetLighting@CPhysicsObj@@QAEXMM@Z

        // CPhysicsObj.unparent_children:
        public void unparent_children() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00513FE0)(ref this); // .text:005134E0 ; void __thiscall CPhysicsObj::unparent_children(CPhysicsObj *this) .text:005134E0 ?unparent_children@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.leave_visibility:
        public void leave_visibility() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00514D20)(ref this); // .text:00514220 ; void __thiscall CPhysicsObj::leave_visibility(CPhysicsObj *this) .text:00514220 ?leave_visibility@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.newer_event:
        public int newer_event(PhysicsTimeStamp stamp, UInt16 new_time) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, PhysicsTimeStamp, UInt16, int>)0x00451B50)(ref this, stamp, new_time); // .text:00451B10 ; int __thiscall CPhysicsObj::newer_event(CPhysicsObj *this, PhysicsTimeStamp stamp, unsigned __int16 new_time) .text:00451B10 ?newer_event@CPhysicsObj@@QAEHW4PhysicsTimeStamp@@G@Z

        // CPhysicsObj.makeParticleObject:
        public static CPhysicsObj* makeParticleObject(UInt32 num_parts, CSphere* sorting_sphere) => ((delegate* unmanaged[Cdecl]<UInt32, CSphere*, CPhysicsObj*>)0x00513140)(num_parts, sorting_sphere); // .text:00512640 ; CPhysicsObj *__cdecl CPhysicsObj::makeParticleObject(unsigned int num_parts, CSphere *sorting_sphere) .text:00512640 ?makeParticleObject@CPhysicsObj@@SAPAV1@KABVCSphere@@@Z

        // CPhysicsObj.set_description:
        public int set_description(PhysicsDesc* desc, int set_movement) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, PhysicsDesc*, int, int>)0x00515A40)(ref this, desc, set_movement); // .text:00514F40 ; int __thiscall CPhysicsObj::set_description(CPhysicsObj *this, PhysicsDesc *desc, int set_movement) .text:00514F40 ?set_description@CPhysicsObj@@QAEHABVPhysicsDesc@@H@Z

        // CPhysicsObj.recalc_cross_cells:
        public void recalc_cross_cells() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00516530)(ref this); // .text:00515A30 ; void __thiscall CPhysicsObj::recalc_cross_cells(CPhysicsObj *this) .text:00515A30 ?recalc_cross_cells@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.SetObjectMaintainer:
        public static void SetObjectMaintainer(CObjectMaint* _obj_maint) => ((delegate* unmanaged[Cdecl]<CObjectMaint*, void>)0x0050FF80)(_obj_maint); // .text:0050F4B0 ; void __cdecl CPhysicsObj::SetObjectMaintainer(CObjectMaint *_obj_maint) .text:0050F4B0 ?SetObjectMaintainer@CPhysicsObj@@SAXPAVCObjectMaint@@@Z

        // CPhysicsObj.ShouldDrawParticles:
        public Byte ShouldDrawParticles(Single i_fDegradeDistance) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, Byte>)0x00510930)(ref this, i_fDegradeDistance); // .text:0050FE60 ; bool __thiscall CPhysicsObj::ShouldDrawParticles(CPhysicsObj *this, float i_fDegradeDistance) .text:0050FE60 ?ShouldDrawParticles@CPhysicsObj@@QBE_NM@Z

        // CPhysicsObj.set_initial_frame:
        public void set_initial_frame(Frame* frame) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Frame*, void>)0x00514C20)(ref this, frame); // .text:00514120 ; void __thiscall CPhysicsObj::set_initial_frame(CPhysicsObj *this, Frame *frame) .text:00514120 ?set_initial_frame@CPhysicsObj@@QAEXABVFrame@@@Z

        // CPhysicsObj.UpdateObjectInternal:
        public void UpdateObjectInternal(Single quantum) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, void>)0x005161B0)(ref this, quantum); // .text:005156B0 ; void __thiscall CPhysicsObj::UpdateObjectInternal(CPhysicsObj *this, float quantum) .text:005156B0 ?UpdateObjectInternal@CPhysicsObj@@IAEXM@Z

        // CPhysicsObj.GetRadius:
        public Single GetRadius() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x0050F490)(ref this); // .text:0050E9C0 ; float __thiscall CPhysicsObj::GetRadius(CPhysicsObj *this) .text:0050E9C0 ?GetRadius@CPhysicsObj@@QBEMXZ

        // CPhysicsObj.remove_parts:
        public void remove_parts(CObjCell* obj_cell) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CObjCell*, void>)0x0050FFF0)(ref this, obj_cell); // .text:0050F520 ; void __thiscall CPhysicsObj::remove_parts(CPhysicsObj *this, CObjCell *obj_cell) .text:0050F520 ?remove_parts@CPhysicsObj@@QAEXPAVCObjCell@@@Z

        // CPhysicsObj.AdjustPosition:
        public static int AdjustPosition(Position* p, AC1Legacy.Vector3* low_pt, CObjCell** new_cell, int bDontCreateCells, int bSearchCells) => ((delegate* unmanaged[Cdecl]<Position*, AC1Legacy.Vector3*, CObjCell**, int, int, int>)0x00512850)(p, low_pt, new_cell, bDontCreateCells, bSearchCells); // .text:00511D80 ; int __cdecl CPhysicsObj::AdjustPosition(Position *p, AC1Legacy::Vector3 *low_pt, CObjCell **new_cell, int bDontCreateCells, int bSearchCells) .text:00511D80 ?AdjustPosition@CPhysicsObj@@SAHAAVPosition@@ABVVector3@AC1Legacy@@AAPAVCObjCell@@HH@Z

        // CPhysicsObj.transition:
        public CTransition* transition(Position* old_pos, Position* new_pos, int admin_move) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Position*, Position*, int, CTransition*>)0x005138C0)(ref this, old_pos, new_pos, admin_move); // .text:00512DC0 ; CTransition *__thiscall CPhysicsObj::transition(CPhysicsObj *this, Position *old_pos, Position *new_pos, int admin_move) .text:00512DC0 ?transition@CPhysicsObj@@IAEPBVCTransition@@ABVPosition@@0H@Z

        // CPhysicsObj.add_shadows_to_cells:
        public void add_shadows_to_cells(CELLARRAY* cell_array) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CELLARRAY*, void>)0x005155E0)(ref this, cell_array); // .text:00514AE0 ; void __thiscall CPhysicsObj::add_shadows_to_cells(CPhysicsObj *this, CELLARRAY *cell_array) .text:00514AE0 ?add_shadows_to_cells@CPhysicsObj@@IAEXABVCELLARRAY@@@Z

        // CPhysicsObj.exit_world:
        public void exit_world() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00515960)(ref this); // .text:00514E60 ; void __thiscall CPhysicsObj::exit_world(CPhysicsObj *this) .text:00514E60 ?exit_world@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.ForceIntoCell:
        public SetPositionError ForceIntoCell(CObjCell* _pNewCell, Position* _pos) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CObjCell*, Position*, SetPositionError>)0x00516160)(ref this, _pNewCell, _pos); // .text:00515660 ; SetPositionError __thiscall CPhysicsObj::ForceIntoCell(CPhysicsObj *this, CObjCell *_pNewCell, Position *_pos) .text:00515660 ?ForceIntoCell@CPhysicsObj@@IAE?AW4SetPositionError@@PAVCObjCell@@ABVPosition@@@Z

        // CPhysicsObj.RemoveLinkAnimations:
        public void RemoveLinkAnimations() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x005108F0)(ref this); // .text:0050FE20 ; void __thiscall CPhysicsObj::RemoveLinkAnimations(CPhysicsObj *this) .text:0050FE20 ?RemoveLinkAnimations@CPhysicsObj@@QAEXXZ

        // CPhysicsObj.MakeMovementManager:
        public void MakeMovementManager(int init_motion) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, void>)0x00510D40)(ref this, init_motion); // .text:00510270 ; void __thiscall CPhysicsObj::MakeMovementManager(CPhysicsObj *this, int init_motion) .text:00510270 ?MakeMovementManager@CPhysicsObj@@IAEXH@Z

        // CPhysicsObj.unpack_movement:
        public void unpack_movement(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void**, UInt32, void>)0x00512B10)(ref this, addr, size); // .text:00512040 ; void __thiscall CPhysicsObj::unpack_movement(CPhysicsObj *this, void **addr, unsigned int size) .text:00512040 ?unpack_movement@CPhysicsObj@@QAEXAAPAXI@Z

        // CPhysicsObj.set_lights:
        public void set_lights(int lights_on, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, int, void>)0x005107C0)(ref this, lights_on, send_event); // .text:0050FCF0 ; void __thiscall CPhysicsObj::set_lights(CPhysicsObj *this, int lights_on, int send_event) .text:0050FCF0 ?set_lights@CPhysicsObj@@QAEXHH@Z

        // CPhysicsObj.calc_acceleration:
        public void calc_acceleration() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00511420)(ref this); // .text:00510950 ; void __thiscall CPhysicsObj::calc_acceleration(CPhysicsObj *this) .text:00510950 ?calc_acceleration@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.track_object_collision:
        public int track_object_collision(CPhysicsObj* _object, int prev_has_contact) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, int, int>)0x00514A10)(ref this, _object, prev_has_contact); // .text:00513F10 ; int __thiscall CPhysicsObj::track_object_collision(CPhysicsObj *this, CPhysicsObj *object, int prev_has_contact) .text:00513F10 ?track_object_collision@CPhysicsObj@@IAEHPBV1@H@Z

        // CPhysicsObj.GetAutonomyBlipDistance:
        public Single GetAutonomyBlipDistance() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single>)0x0050F640)(ref this); // .text:0050EB70 ; float __thiscall CPhysicsObj::GetAutonomyBlipDistance(CPhysicsObj *this) .text:0050EB70 ?GetAutonomyBlipDistance@CPhysicsObj@@QBE?BMXZ

        // CPhysicsObj.AddObjectToSingleCell:
        public void AddObjectToSingleCell(CObjCell* obj_cell) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CObjCell*, void>)0x005154E0)(ref this, obj_cell); // .text:005149E0 ; void __thiscall CPhysicsObj::AddObjectToSingleCell(CPhysicsObj *this, CObjCell *obj_cell) .text:005149E0 ?AddObjectToSingleCell@CPhysicsObj@@QAEXPAVCObjCell@@@Z

        // CPhysicsObj.create_blocking_particle_emitter:
        public UInt32 create_blocking_particle_emitter(UInt32 emitter_info_id, UInt32 part_index, Frame* offset, UInt32 emitter_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, UInt32, Frame*, UInt32, UInt32>)0x0050FE80)(ref this, emitter_info_id, part_index, offset, emitter_id); // .text:0050F3B0 ; unsigned int __thiscall CPhysicsObj::create_blocking_particle_emitter(CPhysicsObj *this, IDClass<_tagDataID,32,0> emitter_info_id, unsigned int part_index, Frame *offset, unsigned int emitter_id) .text:0050F3B0 ?create_blocking_particle_emitter@CPhysicsObj@@QAEKV?$IDClass@U_tagDataID@@$0CA@$0A@@@KABVFrame@@K@Z

        // CPhysicsObj.report_collision_end:
        public void report_collision_end(int force_end) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, void>)0x00515120)(ref this, force_end); // .text:00514620 ; void __thiscall CPhysicsObj::report_collision_end(CPhysicsObj *this, const int force_end) .text:00514620 ?report_collision_end@CPhysicsObj@@IAEXH@Z

        // CPhysicsObj.set_hidden:
        public void set_hidden(int hidden, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, int, int, void>)0x00515760)(ref this, hidden, send_event); // .text:00514C60 ; void __thiscall CPhysicsObj::set_hidden(CPhysicsObj *this, int hidden, int send_event) .text:00514C60 ?set_hidden@CPhysicsObj@@QAEXHH@Z

        // CPhysicsObj.StopMotion:
        public UInt32 StopMotion(UInt32 motion, MovementParameters* _params, int send_event) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, UInt32, MovementParameters*, int, UInt32>)0x00510BA0)(ref this, motion, _params, send_event); // .text:005100D0 ; unsigned int __thiscall CPhysicsObj::StopMotion(CPhysicsObj *this, unsigned int motion, MovementParameters *params, int send_event) .text:005100D0 ?StopMotion@CPhysicsObj@@QAEKKABVMovementParameters@@H@Z

        // CPhysicsObj.SetScaleStatic:
        public void SetScaleStatic(Single new_scale) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, Single, void>)0x00512680)(ref this, new_scale); // .text:00511BB0 ; void __thiscall CPhysicsObj::SetScaleStatic(CPhysicsObj *this, float new_scale) .text:00511BB0 ?SetScaleStatic@CPhysicsObj@@QAEXM@Z

        // CPhysicsObj.add_particle_shadow_to_cell:
        public void add_particle_shadow_to_cell() => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, void>)0x00515570)(ref this); // .text:00514A70 ; void __thiscall CPhysicsObj::add_particle_shadow_to_cell(CPhysicsObj *this) .text:00514A70 ?add_particle_shadow_to_cell@CPhysicsObj@@IAEXXZ

        // CPhysicsObj.add_anim_hook:
        public void add_anim_hook(CAnimHook* hook) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CAnimHook*, void>)0x00515720)(ref this, hook); // .text:00514C20 ; void __thiscall CPhysicsObj::add_anim_hook(CPhysicsObj *this, CAnimHook *hook) .text:00514C20 ?add_anim_hook@CPhysicsObj@@QAEXPAVCAnimHook@@@Z

        // CPhysicsObj.set_parent:
        public int set_parent(CPhysicsObj* obj, UInt32 part_index, Frame* frame) => ((delegate* unmanaged[Thiscall]<ref CPhysicsObj, CPhysicsObj*, UInt32, Frame*, int>)0x00516650)(ref this, obj, part_index, frame); // .text:00515B50 ; int __thiscall CPhysicsObj::set_parent(CPhysicsObj *this, CPhysicsObj *obj, unsigned int part_index, Frame *frame) .text:00515B50 ?set_parent@CPhysicsObj@@QAEHPAV1@KABVFrame@@@Z

        // Globals:
        public static CObjectMaint** obj_maint = (CObjectMaint**)0x00844D64; // .data:00843D54 ; CObjectMaint *CPhysicsObj::obj_maint .data:00843D54 ?obj_maint@CPhysicsObj@@1PAVCObjectMaint@@A
        public static CPhysicsObj** player_object = (CPhysicsObj**)0x00844D68; // .data:00843D58 ; CPhysicsObj *CPhysicsObj::player_object .data:00843D58 ?player_object@CPhysicsObj@@1PAV1@A
    }




    public unsafe struct RestrictionDB {
        // Struct:
        public PackObj a0;
        public UInt32 _bitmask;
        public UInt32 _monarch_iid;
        public PHashTable<UInt32, UInt32> _table;
        public override string ToString() => $"a0(PackObj):{a0}, _bitmask:{_bitmask:X8}, _monarch_iid:{_monarch_iid:X8}, _table(PHashTable<UInt32,UInt32>):{_table}";

        // Functions:

        // RestrictionDB.SetOpenHouse:
        public void SetOpenHouse(int open) => ((delegate* unmanaged[Thiscall]<ref RestrictionDB, int, void>)0x005AE310)(ref this, open); // .text:005AE310 ; void __thiscall RestrictionDB::SetOpenHouse(RestrictionDB *this, int open) .text:005AE310 ?SetOpenHouse@RestrictionDB@@QAEXH@Z

        // RestrictionDB.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref RestrictionDB, void**, UInt32, UInt32>)0x005AE330)(ref this, addr, size); // .text:005AE330 ; unsigned int __thiscall RestrictionDB::Pack(RestrictionDB *this, void **addr, unsigned int size) .text:005AE330 ?Pack@RestrictionDB@@UAEIAAPAXI@Z

        // RestrictionDB.IsAllowedIn:
        public int IsAllowedIn(UInt32 guest, UInt32 monarch) => ((delegate* unmanaged[Thiscall]<ref RestrictionDB, UInt32, UInt32, int>)0x005AE8F0)(ref this, guest, monarch); // .text:005AE8F0 ; int __thiscall RestrictionDB::IsAllowedIn(RestrictionDB *this, unsigned int guest, unsigned int monarch) .text:005AE8F0 ?IsAllowedIn@RestrictionDB@@QBEHKK@Z

        // RestrictionDB.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref RestrictionDB, void**, UInt32, int>)0x005AE990)(ref this, addr, size); // .text:005AE990 ; int __thiscall RestrictionDB::UnPack(RestrictionDB *this, void **addr, unsigned int size) .text:005AE990 ?UnPack@RestrictionDB@@UAEHAAPAXI@Z

        // RestrictionDB.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref RestrictionDB, void>)0x005AEEB0)(ref this); // .text:005AEEB0 ; void __thiscall RestrictionDB::RestrictionDB(RestrictionDB *this) .text:005AEEB0 ??0RestrictionDB@@QAE@XZ

        // RestrictionDB.operator_equals:
        public RestrictionDB* operator_equals() => ((delegate* unmanaged[Thiscall]<ref RestrictionDB, RestrictionDB*>)0x005AEF00)(ref this); // .text:005AEF00 ; public: class RestrictionDB & __thiscall RestrictionDB::operator=(class RestrictionDB const &) .text:005AEF00 ??4RestrictionDB@@QAEAAV0@ABV0@@Z

        // RestrictionDB.__Ctor:
        public void __Ctor(RestrictionDB* rhs) => ((delegate* unmanaged[Thiscall]<ref RestrictionDB, RestrictionDB*, void>)0x005AEFB0)(ref this, rhs); // .text:005AEFB0 ; void __thiscall RestrictionDB::RestrictionDB(RestrictionDB *this, RestrictionDB *rhs) .text:005AEFB0 ??0RestrictionDB@@QAE@ABV0@@Z
    }

    public unsafe struct EnvCollisionProfile {
        // Struct:
        public AC1Legacy.Vector3 velocity;
        public UInt32 _bitfield;
        public override string ToString() => $"velocity(AC1Legacy.Vector3):{velocity}, _bitfield:{_bitfield:X8}";

        // Functions:

        // EnvCollisionProfile.SetMeInContact:
        public void SetMeInContact(int hasContact) => ((delegate* unmanaged[Thiscall]<ref EnvCollisionProfile, int, void>)0x0051B920)(ref this, hasContact); // .text:0051B920 ; void __thiscall EnvCollisionProfile::SetMeInContact(EnvCollisionProfile *this, const int hasContact) .text:0051B920 ?SetMeInContact@EnvCollisionProfile@@QAEXH@Z

        // EnvCollisionProfile.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref EnvCollisionProfile, void>)0x0051BA20)(ref this); // .text:0051BA20 ; void __thiscall EnvCollisionProfile::EnvCollisionProfile(EnvCollisionProfile *this) .text:0051BA20 ??0EnvCollisionProfile@@QAE@XZ
    }


    public unsafe struct CPhysicsPart {
        // Struct:
        public Single CYpt;
        public AC1Legacy.Vector3 viewer_heading;
        public GfxObjDegradeInfo* degrades;
        public UInt32 deg_level;
        public int deg_mode;
        public int draw_state;
        public CGfxObj** gfxobj;
        public AC1Legacy.Vector3 gfxobj_scale;
        public Position pos;
        public Position draw_pos;
        public CMaterial* material;
        public CSurface** surfaces;
        public UInt32 original_palette_id;
        public Single curTranslucency;
        public Single curDiffuse;
        public Single curLuminosity;
        public Palette* shiftPal;
        public UInt32 m_current_render_frame_num;
        public CPhysicsObj* physobj;
        public int physobj_index;
        public override string ToString() => $"CYpt:{CYpt:n5}, viewer_heading(AC1Legacy.Vector3):{viewer_heading}, degrades:->(GfxObjDegradeInfo*)0x{(int)degrades:X8}, deg_level:{deg_level:X8}, deg_mode(int):{deg_mode}, draw_state(int):{draw_state}, gfxobj:->(CGfxObj**)0x{(int)gfxobj:X8}, gfxobj_scale(AC1Legacy.Vector3):{gfxobj_scale}, pos(Position):{pos}, draw_pos(Position):{draw_pos}, material:->(CMaterial*)0x{(int)material:X8}, surfaces:->(CSurface**)0x{(int)surfaces:X8}, original_palette_id:{original_palette_id:X8}, curTranslucency:{curTranslucency:n5}, curDiffuse:{curDiffuse:n5}, curLuminosity:{curLuminosity:n5}, shiftPal:->(Palette*)0x{(int)shiftPal:X8}, m_current_render_frame_num:{m_current_render_frame_num:X8}, physobj:->(CPhysicsObj*)0x{(int)physobj:X8}, physobj_index(int):{physobj_index}";
        // Enums:
        public enum PartDrawState : UInt32 {
            DEFAULT_DS = 0x0,
            NODRAW_DS = 0x1,
            FORCE_PartDrawState_32_BIT = 0x7FFFFFFF,
        };

        // Functions:

        // CPhysicsPart.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, void>)0x0050E550)(ref this); // .text:0050DA80 ; void __thiscall CPhysicsPart::CPhysicsPart(CPhysicsPart *this) .text:0050DA80 ??0CPhysicsPart@@IAE@XZ

        // CPhysicsPart.Always2D:
        public int Always2D() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, int>)0x0050E370)(ref this); // .text:0050D8A0 ; int __thiscall CPhysicsPart::Always2D(CPhysicsPart *this) .text:0050D8A0 ?Always2D@CPhysicsPart@@QBEHXZ

        // CPhysicsPart.CopyMaterial:
        public int CopyMaterial() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, int>)0x0050E100)(ref this); // .text:0050D630 ; int __thiscall CPhysicsPart::CopyMaterial(CPhysicsPart *this) .text:0050D630 ?CopyMaterial@CPhysicsPart@@QAEHXZ

        // CPhysicsPart.CopySurfaces:
        public int CopySurfaces() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, int>)0x0050E170)(ref this); // .text:0050D6A0 ; int __thiscall CPhysicsPart::CopySurfaces(CPhysicsPart *this) .text:0050D6A0 ?CopySurfaces@CPhysicsPart@@QAEHXZ

        // CPhysicsPart.CurSettingsAreDefault:
        public Byte CurSettingsAreDefault() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Byte>)0x0050E4B0)(ref this); // .text:0050D9E0 ; bool __thiscall CPhysicsPart::CurSettingsAreDefault(CPhysicsPart *this) .text:0050D9E0 ?CurSettingsAreDefault@CPhysicsPart@@IAE_NXZ

        // CPhysicsPart.DetermineBasePal:
        public void DetermineBasePal() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, void>)0x0050E750)(ref this); // .text:0050DC80 ; void __thiscall CPhysicsPart::DetermineBasePal(CPhysicsPart *this) .text:0050DC80 ?DetermineBasePal@CPhysicsPart@@IAEXXZ

        // CPhysicsPart.Draw:
        public void Draw(int building_flag) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, int, void>)0x0050E270)(ref this, building_flag); // .text:0050D7A0 ; void __thiscall CPhysicsPart::Draw(CPhysicsPart *this, int building_flag) .text:0050D7A0 ?Draw@CPhysicsPart@@QAEXH@Z

        // CPhysicsPart.GetBoundingBox:
        public BBox* GetBoundingBox() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, BBox*>)0x0050E0D0)(ref this); // .text:0050D600 ; BBox *__thiscall CPhysicsPart::GetBoundingBox(CPhysicsPart *this) .text:0050D600 ?GetBoundingBox@CPhysicsPart@@QBEABVBBox@@XZ

        // CPhysicsPart.GetDrawnThisFrame:
        public Byte GetDrawnThisFrame() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Byte>)0x0050DFA0)(ref this); // .text:0050D4D0 ; bool __thiscall CPhysicsPart::GetDrawnThisFrame(CPhysicsPart *this) .text:0050D4D0 ?GetDrawnThisFrame@CPhysicsPart@@QAE_NXZ

        // CPhysicsPart.GetMaxDegradeDistance:
        public Single GetMaxDegradeDistance() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Single>)0x0050DFE0)(ref this); // .text:0050D510 ; float __thiscall CPhysicsPart::GetMaxDegradeDistance(CPhysicsPart *this) .text:0050D510 ?GetMaxDegradeDistance@CPhysicsPart@@QBEMXZ

        // CPhysicsPart.GetOriginalPaletteID:
        public UInt32* GetOriginalPaletteID(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, UInt32*, UInt32*>)0x0050E070)(ref this, result); // .text:0050D5A0 ; IDClass<_tagDataID,32,0> *__thiscall CPhysicsPart::GetOriginalPaletteID(CPhysicsPart *this, IDClass<_tagDataID,32,0> *result) .text:0050D5A0 ?GetOriginalPaletteID@CPhysicsPart@@QBE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // CPhysicsPart.InitObjDescChanges:
        public int InitObjDescChanges() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, int>)0x0050EE80)(ref this); // .text:0050E3B0 ; int __thiscall CPhysicsPart::InitObjDescChanges(CPhysicsPart *this) .text:0050E3B0 ?InitObjDescChanges@CPhysicsPart@@QAEHXZ

        // CPhysicsPart.IsPartOfPlayerObj:
        public Byte IsPartOfPlayerObj() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Byte>)0x0050DF80)(ref this); // .text:0050D4B0 ; bool __thiscall CPhysicsPart::IsPartOfPlayerObj(CPhysicsPart *this) .text:0050D4B0 ?IsPartOfPlayerObj@CPhysicsPart@@QBE_NXZ

        // CPhysicsPart.LoadGfxObjArray:
        //public static int LoadGfxObjArray(UInt32 i_idRootObject, GfxObjDegradeInfo** new_degrades, CGfxObj** a2, new_gfxobj a3) => ((delegate* unmanaged[Cdecl]<UInt32, GfxObjDegradeInfo**, CGfxObj**, new_gfxobj, int>)0x0050E7C0)(i_idRootObject, new_degrades, a2, a3); // .text:0050DCF0 ; int __cdecl CPhysicsPart::LoadGfxObjArray(IDClass<_tagDataID,32,0> i_idRootObject, GfxObjDegradeInfo **new_degrades, CGfxObj ***new_gfxobj) .text:0050DCF0 ?LoadGfxObjArray@CPhysicsPart@@KAHV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAPAVGfxObjDegradeInfo@@AAPAPAVCGfxObj@@@Z

        // CPhysicsPart.MorphToExistingObject:
        public Byte MorphToExistingObject(CPhysicsPart* pTemplate) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, CPhysicsPart*, Byte>)0x0050E640)(ref this, pTemplate); // .text:0050DB70 ; bool __thiscall CPhysicsPart::MorphToExistingObject(CPhysicsPart *this, CPhysicsPart *pTemplate) .text:0050DB70 ?MorphToExistingObject@CPhysicsPart@@IAE_NPBV1@@Z

        // CPhysicsPart.ReleaseGfxObjArray:
        //public static void ReleaseGfxObjArray(GfxObjDegradeInfo** old_degrades, CGfxObj** a1, old_gfxobj a2) => ((delegate* unmanaged[Cdecl]<GfxObjDegradeInfo**, CGfxObj**, old_gfxobj, void>)0x0050E000)(old_degrades, a1, a2); // .text:0050D530 ; void __cdecl CPhysicsPart::ReleaseGfxObjArray(GfxObjDegradeInfo **old_degrades, CGfxObj ***old_gfxobj) .text:0050D530 ?ReleaseGfxObjArray@CPhysicsPart@@KAXAAPAVGfxObjDegradeInfo@@AAPAPAVCGfxObj@@@Z

        // CPhysicsPart.RestoreLighting:
        public void RestoreLighting() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, void>)0x0050EF70)(ref this); // .text:0050E4A0 ; void __thiscall CPhysicsPart::RestoreLighting(CPhysicsPart *this) .text:0050E4A0 ?RestoreLighting@CPhysicsPart@@QAEXXZ

        // CPhysicsPart.RestoreMaterial:
        public void RestoreMaterial() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, void>)0x0050EA40)(ref this); // .text:0050DF70 ; void __thiscall CPhysicsPart::RestoreMaterial(CPhysicsPart *this) .text:0050DF70 ?RestoreMaterial@CPhysicsPart@@QAEXXZ

        // CPhysicsPart.RestorePalette:
        public void RestorePalette() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, void>)0x0050E080)(ref this); // .text:0050D5B0 ; void __thiscall CPhysicsPart::RestorePalette(CPhysicsPart *this) .text:0050D5B0 ?RestorePalette@CPhysicsPart@@QAEXXZ

        // CPhysicsPart.RestoreSurfaces:
        public void RestoreSurfaces() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, void>)0x0050E200)(ref this); // .text:0050D730 ; void __thiscall CPhysicsPart::RestoreSurfaces(CPhysicsPart *this) .text:0050D730 ?RestoreSurfaces@CPhysicsPart@@QAEXXZ

        // CPhysicsPart.SetDiffusion:
        public void SetDiffusion(Single _diffuse) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Single, void>)0x0050F040)(ref this, _diffuse); // .text:0050E570 ; void __thiscall CPhysicsPart::SetDiffusion(CPhysicsPart *this, float _diffuse) .text:0050E570 ?SetDiffusion@CPhysicsPart@@QAEXM@Z

        // CPhysicsPart.SetDrawnThisFrame:
        public void SetDrawnThisFrame() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, void>)0x0050DFC0)(ref this); // .text:0050D4F0 ; void __thiscall CPhysicsPart::SetDrawnThisFrame(CPhysicsPart *this) .text:0050D4F0 ?SetDrawnThisFrame@CPhysicsPart@@QAEXXZ

        // CPhysicsPart.SetGfxObjArray:
        public void SetGfxObjArray(GfxObjDegradeInfo* new_degrades, CGfxObj** new_gfxobj) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, GfxObjDegradeInfo*, CGfxObj**, void>)0x0050EDB0)(ref this, new_degrades, new_gfxobj); // .text:0050E2E0 ; void __thiscall CPhysicsPart::SetGfxObjArray(CPhysicsPart *this, GfxObjDegradeInfo *new_degrades, CGfxObj **new_gfxobj) .text:0050E2E0 ?SetGfxObjArray@CPhysicsPart@@IAEXPAVGfxObjDegradeInfo@@PAPAVCGfxObj@@@Z

        // CPhysicsPart.SetLighting:
        public void SetLighting(Single _luminosity, Single _diffuse) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Single, Single, void>)0x0050EED0)(ref this, _luminosity, _diffuse); // .text:0050E400 ; void __thiscall CPhysicsPart::SetLighting(CPhysicsPart *this, float _luminosity, float _diffuse) .text:0050E400 ?SetLighting@CPhysicsPart@@QAEXMM@Z

        // CPhysicsPart.SetLuminosity:
        public void SetLuminosity(Single _luminosity) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Single, void>)0x0050F0C0)(ref this, _luminosity); // .text:0050E5F0 ; void __thiscall CPhysicsPart::SetLuminosity(CPhysicsPart *this, float _luminosity) .text:0050E5F0 ?SetLuminosity@CPhysicsPart@@QAEXM@Z

        // CPhysicsPart.SetNoDraw:
        public void SetNoDraw(int no_draw) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, int, void>)0x0050E0E0)(ref this, no_draw); // .text:0050D610 ; void __thiscall CPhysicsPart::SetNoDraw(CPhysicsPart *this, int no_draw) .text:0050D610 ?SetNoDraw@CPhysicsPart@@QAEXH@Z

        // CPhysicsPart.SetPart:
        public int SetPart(UInt32 gfxobj_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, UInt32, int>)0x0050F1D0)(ref this, gfxobj_id); // .text:0050E700 ; int __thiscall CPhysicsPart::SetPart(CPhysicsPart *this, IDClass<_tagDataID,32,0> gfxobj_id) .text:0050E700 ?SetPart@CPhysicsPart@@QAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // CPhysicsPart.SetTextureMap:
        public int SetTextureMap(UInt32 old_tex_id, UInt32 new_tex_id) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, UInt32, UInt32, int>)0x0050E900)(ref this, old_tex_id, new_tex_id); // .text:0050DE30 ; int __thiscall CPhysicsPart::SetTextureMap(CPhysicsPart *this, IDClass<_tagDataID,32,0> old_tex_id, IDClass<_tagDataID,32,0> new_tex_id) .text:0050DE30 ?SetTextureMap@CPhysicsPart@@QAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@0@Z

        // CPhysicsPart.SetTranslucency:
        public void SetTranslucency(Single _translucency) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Single, void>)0x0050F140)(ref this, _translucency); // .text:0050E670 ; void __thiscall CPhysicsPart::SetTranslucency(CPhysicsPart *this, float _translucency) .text:0050E670 ?SetTranslucency@CPhysicsPart@@QAEXM@Z

        // CPhysicsPart.UpdateViewerDistance:
        public void UpdateViewerDistance(Single _CYpt, AC1Legacy.Vector3* _viewer_heading) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Single, AC1Legacy.Vector3*, void>)0x0050EC70)(ref this, _CYpt, _viewer_heading); // .text:0050E1A0 ; void __thiscall CPhysicsPart::UpdateViewerDistance(CPhysicsPart *this, float _CYpt, AC1Legacy::Vector3 *_viewer_heading) .text:0050E1A0 ?UpdateViewerDistance@CPhysicsPart@@QAEXMABVVector3@AC1Legacy@@@Z

        // CPhysicsPart.UpdateViewerDistance:
        public void UpdateViewerDistance() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, void>)0x0050EB00)(ref this); // .text:0050E030 ; void __thiscall CPhysicsPart::UpdateViewerDistance(CPhysicsPart *this) .text:0050E030 ?UpdateViewerDistance@CPhysicsPart@@QAEXXZ

        // CPhysicsPart.UsePalette:
        public int UsePalette(Palette* pal) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, Palette*, int>)0x0050E9A0)(ref this, pal); // .text:0050DED0 ; int __thiscall CPhysicsPart::UsePalette(CPhysicsPart *this, Palette *pal) .text:0050DED0 ?UsePalette@CPhysicsPart@@QAEHPAVPalette@@@Z

        // CPhysicsPart.calc_draw_frame:
        public void calc_draw_frame() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, void>)0x0050EA70)(ref this); // .text:0050DFA0 ; void __thiscall CPhysicsPart::calc_draw_frame(CPhysicsPart *this) .text:0050DFA0 ?calc_draw_frame@CPhysicsPart@@IAEXXZ

        // CPhysicsPart.find_obj_collisions:
        public TransitionState find_obj_collisions(CTransition* transition) => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, CTransition*, TransitionState>)0x0050E3A0)(ref this, transition); // .text:0050D8D0 ; TransitionState __thiscall CPhysicsPart::find_obj_collisions(CPhysicsPart *this, CTransition *transition) .text:0050D8D0 ?find_obj_collisions@CPhysicsPart@@QBE?AW4TransitionState@@AAVCTransition@@@Z

        // CPhysicsPart.get_physobj_id:
        public UInt32 get_physobj_id() => ((delegate* unmanaged[Thiscall]<ref CPhysicsPart, UInt32>)0x0050DF60)(ref this); // .text:0050D490 ; unsigned int __thiscall CPhysicsPart::get_physobj_id(CPhysicsPart *this) .text:0050D490 ?get_physobj_id@CPhysicsPart@@QBEKXZ

        // CPhysicsPart.makePhysicsPart:
        public static CPhysicsPart* makePhysicsPart(CPhysicsPart* pTemplate) => ((delegate* unmanaged[Cdecl]<CPhysicsPart*, CPhysicsPart*>)0x0050ED00)(pTemplate); // .text:0050E230 ; CPhysicsPart *__cdecl CPhysicsPart::makePhysicsPart(CPhysicsPart *pTemplate) .text:0050E230 ?makePhysicsPart@CPhysicsPart@@SAPAV1@PBV1@@Z

        // CPhysicsPart.makePhysicsPart:
        public static CPhysicsPart* makePhysicsPart(UInt32 gfxobj_id) => ((delegate* unmanaged[Cdecl]<UInt32, CPhysicsPart*>)0x0050F230)(gfxobj_id); // .text:0050E760 ; CPhysicsPart *__cdecl CPhysicsPart::makePhysicsPart(IDClass<_tagDataID,32,0> gfxobj_id) .text:0050E760 ?makePhysicsPart@CPhysicsPart@@SAPAV1@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // Globals:
        public static UInt32* viewcone_check_object_id = (UInt32*)0x00844BFC; // .data:00843BEC ; unsigned int CPhysicsPart::viewcone_check_object_id .data:00843BEC ?viewcone_check_object_id@CPhysicsPart@@1KA
        public static int* selected_object_in_view = (int*)0x00844C00; // .data:00843BF0 ; int CPhysicsPart::selected_object_in_view .data:00843BF0 ?selected_object_in_view@CPhysicsPart@@1HA
        public static int* creature_mode = (int*)0x00844C04; // .data:00843BF4 ; int CPhysicsPart::creature_mode .data:00843BF4 ?creature_mode@CPhysicsPart@@1HA
        public static UInt32* player_iid = (UInt32*)0x00844C08; // .data:00843BF8 ; unsigned int CPhysicsPart::player_iid .data:00843BF8 ?player_iid@CPhysicsPart@@1KA
    }


    public unsafe struct SetPositionStruct {
        // Struct:
        public Position pos;
        public UInt32 flags;
        public AC1Legacy.Vector3 line;
        public Single xrad;
        public Single yrad;
        public UInt32 num_tries;
        public override string ToString() => $"pos(Position):{pos}, flags:{flags:X8}, line(AC1Legacy.Vector3):{line}, xrad:{xrad:n5}, yrad:{yrad:n5}, num_tries:{num_tries:X8}";

        // Functions:

        // SetPositionStruct.SetFlags:
        public void SetFlags(UInt32 new_flags) => ((delegate* unmanaged[Thiscall]<ref SetPositionStruct, UInt32, void>)0x0051BB40)(ref this, new_flags); // .text:0051BB40 ; void __thiscall SetPositionStruct::SetFlags(SetPositionStruct *this, const unsigned int new_flags) .text:0051BB40 ?SetFlags@SetPositionStruct@@QAEXK@Z

        // SetPositionStruct.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref SetPositionStruct, void>)0x0051BB50)(ref this); // .text:0051BB50 ; void __thiscall SetPositionStruct::SetPositionStruct(SetPositionStruct *this) .text:0051BB50 ??0SetPositionStruct@@QAE@XZ

        // SetPositionStruct.SetPosition:
        public void SetPosition(Position* new_pos) => ((delegate* unmanaged[Thiscall]<ref SetPositionStruct, Position*, void>)0x0051BBA0)(ref this, new_pos); // .text:0051BBA0 ; void __thiscall SetPositionStruct::SetPosition(SetPositionStruct *this, Position *new_pos) .text:0051BBA0 ?SetPosition@SetPositionStruct@@QAEXABVPosition@@@Z
    }
    public unsafe struct AttackCone {
        // Struct:
        public int part_index;
        public Vec2D left;
        public Vec2D right;
        public Single radius;
        public Single height;
        public override string ToString() => $"part_index(int):{part_index}, left(Vec2D):{left}, right(Vec2D):{right}, radius:{radius:n5}, height:{height:n5}";

        // Functions:

        // AttackCone.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AttackCone, void**, UInt32, UInt32>)0x00526FF0)(ref this, addr, size); // .text:00526FF0 ; unsigned int __thiscall AttackCone::Pack(AttackCone *this, void **addr, unsigned int size) .text:00526FF0 ?Pack@AttackCone@@QAEIAAPAXI@Z

        // AttackCone.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AttackCone, void**, UInt32, int>)0x00527060)(ref this, addr, size); // .text:00527060 ; int __thiscall AttackCone::UnPack(AttackCone *this, void **addr, unsigned int size) .text:00527060 ?UnPack@AttackCone@@QAEHAAPAXI@Z
    }
    public unsafe struct ObjCollisionProfile {
        // Struct:
        public UInt32 id;
        public AC1Legacy.Vector3 velocity;
        public UInt32 wcid;
        public ITEM_TYPE itemType;
        public UInt32 _bitfield;
        public override string ToString() => $"id:{id:X8}, velocity(AC1Legacy.Vector3):{velocity}, wcid:{wcid:X8}, itemType(ITEM_TYPE):{itemType}, _bitfield:{_bitfield:X8}";

        // Functions:

        // ObjCollisionProfile.SetDoor:
        public void SetDoor(int isDoor) => ((delegate* unmanaged[Thiscall]<ref ObjCollisionProfile, int, void>)0x0051B980)(ref this, isDoor); // .text:0051B980 ; void __thiscall ObjCollisionProfile::SetDoor(ObjCollisionProfile *this, const int isDoor) .text:0051B980 ?SetDoor@ObjCollisionProfile@@QAEXH@Z

        // ObjCollisionProfile.SetAttackable:
        public void SetAttackable(int attackable) => ((delegate* unmanaged[Thiscall]<ref ObjCollisionProfile, int, void>)0x0051B9A0)(ref this, attackable); // .text:0051B9A0 ; void __thiscall ObjCollisionProfile::SetAttackable(ObjCollisionProfile *this, const int attackable) .text:0051B9A0 ?SetAttackable@ObjCollisionProfile@@QAEXH@Z

        // ObjCollisionProfile.SetMissile:
        public void SetMissile(int isMissile) => ((delegate* unmanaged[Thiscall]<ref ObjCollisionProfile, int, void>)0x0051B9C0)(ref this, isMissile); // .text:0051B9C0 ; void __thiscall ObjCollisionProfile::SetMissile(ObjCollisionProfile *this, const int isMissile) .text:0051B9C0 ?SetMissile@ObjCollisionProfile@@QAEXH@Z

        // ObjCollisionProfile.SetInContact:
        public void SetInContact(int hasContact) => ((delegate* unmanaged[Thiscall]<ref ObjCollisionProfile, int, void>)0x0051B9E0)(ref this, hasContact); // .text:0051B9E0 ; void __thiscall ObjCollisionProfile::SetInContact(ObjCollisionProfile *this, const int hasContact) .text:0051B9E0 ?SetInContact@ObjCollisionProfile@@QAEXH@Z

        // ObjCollisionProfile.SetMeInContact:
        public void SetMeInContact(int hasContact) => ((delegate* unmanaged[Thiscall]<ref ObjCollisionProfile, int, void>)0x0051BA00)(ref this, hasContact); // .text:0051BA00 ; void __thiscall ObjCollisionProfile::SetMeInContact(ObjCollisionProfile *this, const int hasContact) .text:0051BA00 ?SetMeInContact@ObjCollisionProfile@@QAEXH@Z

        // ObjCollisionProfile.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ObjCollisionProfile, void>)0x0051BA30)(ref this); // .text:0051BA30 ; void __thiscall ObjCollisionProfile::ObjCollisionProfile(ObjCollisionProfile *this) .text:0051BA30 ??0ObjCollisionProfile@@QAE@XZ

        // ObjCollisionProfile.SetCreature:
        public void SetCreature(int isCreature) => ((delegate* unmanaged[Thiscall]<ref ObjCollisionProfile, int, void>)0x0051B940)(ref this, isCreature); // .text:0051B940 ; void __thiscall ObjCollisionProfile::SetCreature(ObjCollisionProfile *this, const int isCreature) .text:0051B940 ?SetCreature@ObjCollisionProfile@@QAEXH@Z

        // ObjCollisionProfile.SetPlayer:
        public void SetPlayer(int isPlayer) => ((delegate* unmanaged[Thiscall]<ref ObjCollisionProfile, int, void>)0x0051B960)(ref this, isPlayer); // .text:0051B960 ; void __thiscall ObjCollisionProfile::SetPlayer(ObjCollisionProfile *this, const int isPlayer) .text:0051B960 ?SetPlayer@ObjCollisionProfile@@QAEXH@Z
    }
    public unsafe struct CTransition {
        // Struct:
        public OBJECTINFO object_info;
        public SPHEREPATH sphere_path;
        public COLLISIONINFO collision_info;
        public CELLARRAY cell_array;
        public CObjCell* new_cell_ptr;
        public override string ToString() => $"object_info(OBJECTINFO):{object_info}, sphere_path(SPHEREPATH):{sphere_path}, collision_info(COLLISIONINFO):{collision_info}, cell_array(CELLARRAY):{cell_array}, new_cell_ptr:->(CObjCell*)0x{(int)new_cell_ptr:X8}";

        // Functions:

        // CTransition.insert_into_cell:
        public TransitionState insert_into_cell(CObjCell* cell, int num_insertion_attempts) => ((delegate* unmanaged[Thiscall]<ref CTransition, CObjCell*, int, TransitionState>)0x00509E70)(ref this, cell, num_insertion_attempts); // .text:00509E70 ; TransitionState __thiscall CTransition::insert_into_cell(CTransition *this, CObjCell *cell, int num_insertion_attempts) .text:00509E70 ?insert_into_cell@CTransition@@IAE?AW4TransitionState@@PBVCObjCell@@H@Z

        // CTransition.validate_transition:
        public TransitionState validate_transition(TransitionState ts, int* redo) => ((delegate* unmanaged[Thiscall]<ref CTransition, TransitionState, int*, TransitionState>)0x0050AA70)(ref this, ts, redo); // .text:0050AA70 ; TransitionState __thiscall CTransition::validate_transition(CTransition *this, TransitionState ts, int *redo) .text:0050AA70 ?validate_transition@CTransition@@IAE?AW4TransitionState@@W42@AAH@Z

        // CTransition.init_sliding_normal:
        public void init_sliding_normal(AC1Legacy.Vector3* normal) => ((delegate* unmanaged[Thiscall]<ref CTransition, AC1Legacy.Vector3*, void>)0x0050FF20)(ref this, normal); // .text:0050FF20 ; void __thiscall CTransition::init_sliding_normal(CTransition *this, AC1Legacy::Vector3 *normal) .text:0050FF20 ?init_sliding_normal@CTransition@@QAEXABVVector3@AC1Legacy@@@Z

        // CTransition.transitional_insert:
        public TransitionState transitional_insert(int num_insertion_attempts) => ((delegate* unmanaged[Thiscall]<ref CTransition, int, TransitionState>)0x0050B6F0)(ref this, num_insertion_attempts); // .text:0050B6F0 ; TransitionState __thiscall CTransition::transitional_insert(CTransition *this, int num_insertion_attempts) .text:0050B6F0 ?transitional_insert@CTransition@@IAE?AW4TransitionState@@H@Z

        // CTransition.edge_slide:
        public int edge_slide(TransitionState* ts, Single step_down_ht, Single z_val) => ((delegate* unmanaged[Thiscall]<ref CTransition, TransitionState*, Single, Single, int>)0x0050B3D0)(ref this, ts, step_down_ht, z_val); // .text:0050B3D0 ; int __thiscall CTransition::edge_slide(CTransition *this, TransitionState *ts, float step_down_ht, float z_val) .text:0050B3D0 ?edge_slide@CTransition@@IAEHAAW4TransitionState@@MM@Z

        // CTransition.find_placement_pos:
        public int find_placement_pos() => ((delegate* unmanaged[Thiscall]<ref CTransition, int>)0x0050BA50)(ref this); // .text:0050BA50 ; int __thiscall CTransition::find_placement_pos(CTransition *this) .text:0050BA50 ?find_placement_pos@CTransition@@IAEHXZ

        // CTransition.find_valid_position:
        public int find_valid_position() => ((delegate* unmanaged[Thiscall]<ref CTransition, int>)0x0050C310)(ref this); // .text:0050C310 ; int __thiscall CTransition::find_valid_position(CTransition *this) .text:0050C310 ?find_valid_position@CTransition@@QAEHXZ

        // CTransition.build_cell_array:
        public void build_cell_array(CObjCell** new_cell_p) => ((delegate* unmanaged[Thiscall]<ref CTransition, CObjCell**, void>)0x00509EE0)(ref this, new_cell_p); // .text:00509EE0 ; void __thiscall CTransition::build_cell_array(CTransition *this, CObjCell **new_cell_p) .text:00509EE0 ?build_cell_array@CTransition@@QAEXPAPAVCObjCell@@@Z

        // CTransition.calc_num_steps:
        public void calc_num_steps(AC1Legacy.Vector3* offset, AC1Legacy.Vector3* offset_per_step, UInt32* num_steps) => ((delegate* unmanaged[Thiscall]<ref CTransition, AC1Legacy.Vector3*, AC1Legacy.Vector3*, UInt32*, void>)0x0050A0B0)(ref this, offset, offset_per_step, num_steps); // .text:0050A0B0 ; void __thiscall CTransition::calc_num_steps(CTransition *this, AC1Legacy::Vector3 *offset, AC1Legacy::Vector3 *offset_per_step, unsigned int *num_steps) .text:0050A0B0 ?calc_num_steps@CTransition@@IAEXAAVVector3@AC1Legacy@@0AAK@Z

        // CTransition.adjust_offset:
        public AC1Legacy.Vector3* adjust_offset(AC1Legacy.Vector3* result, AC1Legacy.Vector3* offset) => ((delegate* unmanaged[Thiscall]<ref CTransition, AC1Legacy.Vector3*, AC1Legacy.Vector3*, AC1Legacy.Vector3*>)0x0050A370)(ref this, result, offset); // .text:0050A370 ; AC1Legacy::Vector3 *__thiscall CTransition::adjust_offset(CTransition *this, AC1Legacy::Vector3 *result, AC1Legacy::Vector3 *offset) .text:0050A370 ?adjust_offset@CTransition@@IAE?AVVector3@AC1Legacy@@ABV23@@Z

        // CTransition.validate_placement:
        public TransitionState validate_placement(TransitionState ts, int adjust) => ((delegate* unmanaged[Thiscall]<ref CTransition, TransitionState, int, TransitionState>)0x0050B210)(ref this, ts, adjust); // .text:0050B210 ; TransitionState __thiscall CTransition::validate_placement(CTransition *this, TransitionState ts, int adjust) .text:0050B210 ?validate_placement@CTransition@@IAE?AW4TransitionState@@W42@H@Z

        // CTransition.check_other_cells:
        public TransitionState check_other_cells(CObjCell* curr_cell) => ((delegate* unmanaged[Thiscall]<ref CTransition, CObjCell*, TransitionState>)0x0050AE50)(ref this, curr_cell); // .text:0050AE50 ; TransitionState __thiscall CTransition::check_other_cells(CTransition *this, CObjCell *curr_cell) .text:0050AE50 ?check_other_cells@CTransition@@IAE?AW4TransitionState@@PBVCObjCell@@@Z

        // CTransition.makeTransition:
        public static CTransition* makeTransition() => ((delegate* unmanaged[Cdecl]<CTransition*>)0x0050B150)(); // .text:0050B150 ; CTransition *__cdecl CTransition::makeTransition() .text:0050B150 ?makeTransition@CTransition@@SAPAV1@XZ

        // CTransition.init_contact_plane:
        public void init_contact_plane(UInt32 cell_id, Plane* plane, int is_water) => ((delegate* unmanaged[Thiscall]<ref CTransition, UInt32, Plane*, int, void>)0x0050E850)(ref this, cell_id, plane, is_water); // .text:0050E850 ; void __thiscall CTransition::init_contact_plane(CTransition *this, unsigned int cell_id, Plane *plane, int is_water) .text:0050E850 ?init_contact_plane@CTransition@@QAEXKABVPlane@@H@Z

        // CTransition.check_collisions:
        public int check_collisions(CPhysicsObj* _object) => ((delegate* unmanaged[Thiscall]<ref CTransition, CPhysicsObj*, int>)0x0050AA00)(ref this, _object); // .text:0050AA00 ; int __thiscall CTransition::check_collisions(CTransition *this, CPhysicsObj *object) .text:0050AA00 ?check_collisions@CTransition@@QAEHPBVCPhysicsObj@@@Z

        // CTransition.check_walkable:
        public int check_walkable(Single z_chk) => ((delegate* unmanaged[Thiscall]<ref CTransition, Single, int>)0x0050AFF0)(ref this, z_chk); // .text:0050AFF0 ; int __thiscall CTransition::check_walkable(CTransition *this, float z_chk) .text:0050AFF0 ?check_walkable@CTransition@@QAEHM@Z

        // CTransition.find_transitional_position:
        public int find_transitional_position() => ((delegate* unmanaged[Thiscall]<ref CTransition, int>)0x0050BDF0)(ref this); // .text:0050BDF0 ; int __thiscall CTransition::find_transitional_position(CTransition *this) .text:0050BDF0 ?find_transitional_position@CTransition@@IAEHXZ

        // CTransition.init:
        public void init() => ((delegate* unmanaged[Thiscall]<ref CTransition, void>)0x00509DD0)(ref this); // .text:00509DD0 ; void __thiscall CTransition::init(CTransition *this) .text:00509DD0 ?init@CTransition@@IAEXXZ

        // CTransition.init_object:
        public void init_object(CPhysicsObj* _object, int _object_state) => ((delegate* unmanaged[Thiscall]<ref CTransition, CPhysicsObj*, int, void>)0x00509E40)(ref this, _object, _object_state); // .text:00509E40 ; void __thiscall CTransition::init_object(CTransition *this, CPhysicsObj *object, int _object_state) .text:00509E40 ?init_object@CTransition@@QAEXPAVCPhysicsObj@@H@Z

        // CTransition.init_sphere:
        public void init_sphere(UInt32 num_sphere, CSphere* sphere, Single scale) => ((delegate* unmanaged[Thiscall]<ref CTransition, UInt32, CSphere*, Single, void>)0x00509E50)(ref this, num_sphere, sphere, scale); // .text:00509E50 ; void __thiscall CTransition::init_sphere(CTransition *this, const unsigned int num_sphere, CSphere *sphere, const float scale) .text:00509E50 ?init_sphere@CTransition@@QAEXKPBVCSphere@@M@Z

        // CTransition.cliff_slide:
        public TransitionState cliff_slide(Plane* contact_plane) => ((delegate* unmanaged[Thiscall]<ref CTransition, Plane*, TransitionState>)0x0050A6D0)(ref this, contact_plane); // .text:0050A6D0 ; TransitionState __thiscall CTransition::cliff_slide(CTransition *this, Plane *contact_plane) .text:0050A6D0 ?cliff_slide@CTransition@@QAE?AW4TransitionState@@ABVPlane@@@Z

        // CTransition.cleanupTransition:
        public static void cleanupTransition(CTransition* transit) => ((delegate* unmanaged[Cdecl]<CTransition*, void>)0x00509DC0)(transit); // .text:00509DC0 ; void __cdecl CTransition::cleanupTransition(CTransition *transit) .text:00509DC0 ?cleanupTransition@CTransition@@SAXPAV1@@Z

        // CTransition.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CTransition, void>)0x0050A980)(ref this); // .text:0050A980 ; void __thiscall CTransition::CTransition(CTransition *this) .text:0050A980 ??0CTransition@@QAE@XZ

        // CTransition.step_down:
        public int step_down(Single step_down_ht, Single z_val) => ((delegate* unmanaged[Thiscall]<ref CTransition, Single, Single, int>)0x0050B2A0)(ref this, step_down_ht, z_val); // .text:0050B2A0 ; int __thiscall CTransition::step_down(CTransition *this, float step_down_ht, float z_val) .text:0050B2A0 ?step_down@CTransition@@IAEHMM@Z

        // CTransition.find_placement_position:
        public int find_placement_position() => ((delegate* unmanaged[Thiscall]<ref CTransition, int>)0x0050C170)(ref this); // .text:0050C170 ; int __thiscall CTransition::find_placement_position(CTransition *this) .text:0050C170 ?find_placement_position@CTransition@@IAEHXZ

        // CTransition.init_last_known_contact_plane:
        public void init_last_known_contact_plane(UInt32 cell_id, Plane* plane, int is_water) => ((delegate* unmanaged[Thiscall]<ref CTransition, UInt32, Plane*, int, void>)0x0050E8E0)(ref this, cell_id, plane, is_water); // .text:0050E8E0 ; void __thiscall CTransition::init_last_known_contact_plane(CTransition *this, unsigned int cell_id, Plane *plane, int is_water) .text:0050E8E0 ?init_last_known_contact_plane@CTransition@@QAEXKABVPlane@@H@Z

        // CTransition.init_path:
        public void init_path(CObjCell* begin_cell, Position* begin_pos, Position* end_pos) => ((delegate* unmanaged[Thiscall]<ref CTransition, CObjCell*, Position*, Position*, void>)0x00509E60)(ref this, begin_cell, begin_pos, end_pos); // .text:00509E60 ; void __thiscall CTransition::init_path(CTransition *this, CObjCell *begin_cell, Position *begin_pos, Position *end_pos) .text:00509E60 ?init_path@CTransition@@QAEXPBVCObjCell@@PBVPosition@@1@Z

        // CTransition.validate_placement_transition:
        public TransitionState validate_placement_transition(TransitionState ts, int* redo) => ((delegate* unmanaged[Thiscall]<ref CTransition, TransitionState, int*, TransitionState>)0x0050ADC0)(ref this, ts, redo); // .text:0050ADC0 ; TransitionState __thiscall CTransition::validate_placement_transition(CTransition *this, TransitionState ts, int *redo) .text:0050ADC0 ?validate_placement_transition@CTransition@@IAE?AW4TransitionState@@W42@AAH@Z

        // CTransition.placement_insert:
        public TransitionState placement_insert() => ((delegate* unmanaged[Thiscall]<ref CTransition, TransitionState>)0x0050B1D0)(ref this); // .text:0050B1D0 ; TransitionState __thiscall CTransition::placement_insert(CTransition *this) .text:0050B1D0 ?placement_insert@CTransition@@IAE?AW4TransitionState@@XZ

        // CTransition.step_up:
        public int step_up(AC1Legacy.Vector3* collision_normal) => ((delegate* unmanaged[Thiscall]<ref CTransition, AC1Legacy.Vector3*, int>)0x0050B610)(ref this, collision_normal); // .text:0050B610 ; int __thiscall CTransition::step_up(CTransition *this, AC1Legacy::Vector3 *collision_normal) .text:0050B610 ?step_up@CTransition@@QAEHAAVVector3@AC1Legacy@@@Z

        // Globals:
        public static int* transition_level = (int*)0x00841C5C; // .data:00841C5C ; int CTransition::transition_level .data:00841C5C ?transition_level@CTransition@@1HA
    }





    public unsafe struct CPartArray {
        public UInt32 pa_state;
        public CPhysicsObj* owner;
        public CSequence sequence;
        public MotionTableManager* motion_table_manager;
        public CSetup* setup;
        public UInt32 num_parts;
        public CPhysicsPart** parts;
        public Vector3 scale;
        public Palette** pals;
        public LIGHTLIST* lights;
        public AnimFrame* last_animframe;
    };

    public unsafe struct AnimFrame {
        public AFrame* frame;
        public UInt32 num_frame_hooks;
        public CAnimHook* hooks;
        public UInt32 num_parts;
    };
    public unsafe struct AFrame {
        public Vector3 m_fOrigin;
        public Single qw;
        public Single qx;
        public Single qy;
        public Single qz;
    };
    public unsafe struct AnimSequenceNode {
        public PackObj packObj;
        public DLListData dLListData;
        public CAnimation* anim;
        public Single framerate;
        public Int32 low_frame;
        public Int32 high_frame;
    };
    public unsafe struct CAnimation {
        public SerializeUsingPackDBObj serializeUsingPackDBObj;
        public AFrame* pos_frames;
        public AnimFrame* part_frames;
        public Int32 has_hooks;
        public UInt32 num_parts;
        public UInt32 num_frames;
    };
    public unsafe struct LIGHTLIST {
        public UInt32 num_lights;
        public LIGHTOBJ* lightobj;
    };


    public unsafe struct Palette {
        public SerializeUsingPackDBObj serializeUsingPackDBObj;
        public UInt32 num_colors;
        public Single min_lighting;
        public UInt32* ARGB;
    };
    public unsafe struct CSetup {
        public SerializeUsingPackDBObj serializeUsingPackDBObj;
        public UInt32 num_parts;
        public UInt32* parts; // IDClass<_tagDataID, 32, 0>
        public UInt32* parent_index;
        public Vector3* default_scale;
        public UInt32 num_cylsphere;
        public CCylSphere* cylsphere;
        public UInt32 num_sphere;
        public CSphere* sphere;
        public Int32 has_physics_bsp;
        public Int32 allow_free_heading;
        public Single height;
        public Single radius;
        public Single step_down_height;
        public Single step_up_height;
        public CSphere sorting_sphere;
        public CSphere selection_sphere;
        public UInt32 num_lights;
        public LIGHTINFO* lights;
        public Vector3 anim_scale;
        public LongHash<LocationType>* holding_locations;
        public LongHash<LocationType>* connection_poInt32s;
        public LongHash<PlacementType> placement_frames;
        public UInt32 default_anim_id; // IDClass<_tagDataID, 32, 0>
        public UInt32 default_script_id; // IDClass<_tagDataID, 32, 0>
        public UInt32 default_mtable_id; // IDClass<_tagDataID, 32, 0>
        public UInt32 default_stable_id; // IDClass<_tagDataID, 32, 0>
        public UInt32 default_phstable_id; // IDClass<_tagDataID, 32, 0>
    };

    public unsafe struct PhysicsScript {
        public SerializeUsingPackDBObj serializeUsingPackDBObj;
        public OldSmartArray<PhysicsScriptData> script_data;
        public Double length;
        /*(004F7270)
void __cdecl PhysicsScript::Allocator();
        (00521690)
void __thiscall PhysicsScript::PhysicsScript(PhysicsScript *this); // idb
signed Int32 PhysicsScript::GetDBOType();
PhysicsScript *__thiscall PhysicsScript::__vecDelDtor(PhysicsScript *this, UInt32 a2);
void __thiscall PhysicsScript::Destroy(PhysicsScript *this); // idb
void __thiscall PhysicsScript::GetSubDataIDs(PhysicsScript *this, QualifiedDataIDArray *id_array); // idb
Int32 __thiscall PhysicsScript::pack_size(PhysicsScript *this);
Int32 __thiscall PhysicsScript::Pack(PhysicsScript *this, void **addr, UInt32 size);
Int32 __thiscall PhysicsScript::UnPack(PhysicsScript *this, void **addr, UInt32 size); // idb
PhysicsScript *__thiscall PhysicsScript::__scaDelDtor(PhysicsScript *this, UInt32 a2);

        */
    };
    public unsafe struct PhysicsScriptTableData {
        public AC1Legacy.SmartArray<PTR<ScriptAndModData>> script_array;
        /*(00521A20)
IDClass<_tagDataID,32,0> *__thiscall PhysicsScriptTableData::GetScript(PhysicsScriptTableData *this, IDClass<_tagDataID,32,0> *result, Single mod); // idb
        (00521AB0)
Int32 __thiscall PhysicsScriptTableData::Pack(PhysicsScriptTableData *this, void **addr, UInt32 size);
void __thiscall PhysicsScriptTableData::GetSubDataIDs(PhysicsScriptTableData *this, QualifiedDataIDArray *id_array); // idb
        (00521DC0)
Int32 __thiscall PhysicsScriptTableData::UnPack(PhysicsScriptTableData *this, void **addr, UInt32 size); // idb
        */
    };

    public unsafe struct PhysicsScriptData {
        public Double start_time;
        public CAnimHook* hook;
        /*(00521600)
Int32 __cdecl PhysicsScriptData::Sort(const void *a, const void *b); // idb

        */
    };

    public unsafe struct PhysicsScriptTable {
        public SerializeUsingPackDBObj serializeUsingPackDBObj;
        public HashTable<UInt32, PhysicsScriptTableData> script_table;
        /*(004F7290)
void __cdecl PhysicsScriptTable::Allocator();
        (00521C30)
signed Int32 __thiscall PhysicsScriptTable::pack_size(PhysicsScriptTable *this, Int32 *num_scripts);
UInt32 __thiscall PhysicsScriptTable::Pack(PhysicsScriptTable *this, void **addr, UInt32 size); // idb
void __thiscall PhysicsScriptTable::GetSubDataIDs(PhysicsScriptTable *this, QualifiedDataIDArray *id_array); // idb
        (00521E40)
IDClass<_tagDataID,32,0> *__thiscall PhysicsScriptTable::GetScript(PhysicsScriptTable *this, IDClass<_tagDataID,32,0> *result, PScriptType type, Single mod); // idb
        (00521FA0)
void __thiscall PhysicsScriptTable::PhysicsScriptTable(PhysicsScriptTable *this); // idb
signed Int32 PhysicsScriptTable::GetDBOType();
PhysicsScriptTable *__thiscall PhysicsScriptTable::__vecDelDtor(PhysicsScriptTable *this, UInt32 a2);
void __thiscall PhysicsScriptTable::Destroy(PhysicsScriptTable *this); // idb
Int32 __thiscall PhysicsScriptTable::UnPack(PhysicsScriptTable *this, void **addr, UInt32 size); // idb
void __thiscall PhysicsScriptTable::~PhysicsScriptTable(PhysicsScriptTable *this); // idb
PhysicsScriptTable *__thiscall PhysicsScriptTable::__vecDelDtor(PhysicsScriptTable *this, UInt32 a2);


        */
    };
}
