using System;
using static AcClient.ArgumentParser;

namespace AcClient {
    public unsafe struct MovementManager {
        // Struct:
        public CMotionInterp* motion_interpreter;
        public MoveToManager* moveto_manager;
        public CPhysicsObj* physics_obj;
        public CWeenieObject* weenie_obj;
        public override string ToString() => $"motion_interpreter:->(CMotionInterp*)0x{(int)motion_interpreter:X8}, moveto_manager:->(MoveToManager*)0x{(int)moveto_manager:X8}, physics_obj:->(CPhysicsObj*)0x{(int)physics_obj:X8}, weenie_obj:->(CWeenieObject*)0x{(int)weenie_obj:X8}";

        // Functions:

        // MovementManager.IsMovingTo:
        public int IsMovingTo() => ((delegate* unmanaged[Thiscall]<ref MovementManager, int>)0x00524260)(ref this); // .text:00524260 ; int __thiscall MovementManager::IsMovingTo(MovementManager *this) .text:00524260 ?IsMovingTo@MovementManager@@QBEHXZ

        // MovementManager.HitGround:
        public void HitGround() => ((delegate* unmanaged[Thiscall]<ref MovementManager, void>)0x00524300)(ref this); // .text:00524300 ; void __thiscall MovementManager::HitGround(MovementManager *this) .text:00524300 ?HitGround@MovementManager@@QAEXXZ

        // MovementManager.LeaveGround:
        public void LeaveGround() => ((delegate* unmanaged[Thiscall]<ref MovementManager, void>)0x00524320)(ref this); // .text:00524320 ; void __thiscall MovementManager::LeaveGround(MovementManager *this) .text:00524320 ?LeaveGround@MovementManager@@QAEXXZ

        // MovementManager.HandleEnterWorld:
        public void HandleEnterWorld() => ((delegate* unmanaged[Thiscall]<ref MovementManager, void>)0x00524340)(ref this); // .text:00524340 ; void __thiscall MovementManager::HandleEnterWorld(MovementManager *this) .text:00524340 ?HandleEnterWorld@MovementManager@@QAEXXZ

        // MovementManager.HandleExitWorld:
        public void HandleExitWorld() => ((delegate* unmanaged[Thiscall]<ref MovementManager, void>)0x00524350)(ref this); // .text:00524350 ; void __thiscall MovementManager::HandleExitWorld(MovementManager *this) .text:00524350 ?HandleExitWorld@MovementManager@@QAEXXZ

        // MovementManager.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref MovementManager, void>)0x005243F0)(ref this); // .text:005243F0 ; void __thiscall MovementManager::Destroy(MovementManager *this) .text:005243F0 ?Destroy@MovementManager@@QAEXXZ

        // MovementManager.SetWeenieObject:
        public void SetWeenieObject(CWeenieObject* _weenie_obj) => ((delegate* unmanaged[Thiscall]<ref MovementManager, CWeenieObject*, void>)0x00524020)(ref this, _weenie_obj); // .text:00524020 ; void __thiscall MovementManager::SetWeenieObject(MovementManager *this, CWeenieObject *_weenie_obj) .text:00524020 ?SetWeenieObject@MovementManager@@QAEXPAVCWeenieObject@@@Z

        // MovementManager.Create:
        public static MovementManager* Create(CPhysicsObj* _physics_obj, CWeenieObject* _weenie_obj) => ((delegate* unmanaged[Cdecl]<CPhysicsObj*, CWeenieObject*, MovementManager*>)0x00524050)(_physics_obj, _weenie_obj); // .text:00524050 ; MovementManager *__cdecl MovementManager::Create(CPhysicsObj *_physics_obj, CWeenieObject *_weenie_obj) .text:00524050 ?Create@MovementManager@@SAPAV1@PAVCPhysicsObj@@PAVCWeenieObject@@@Z

        // MovementManager.HandleUpdateTarget:
        public void HandleUpdateTarget(TargetInfo target_info) => ((delegate* unmanaged[Thiscall]<ref MovementManager, TargetInfo, void>)0x00524790)(ref this, target_info); // .text:00524790 ; void __thiscall MovementManager::HandleUpdateTarget(MovementManager *this, TargetInfo target_info) .text:00524790 ?HandleUpdateTarget@MovementManager@@QAEXVTargetInfo@@@Z

        // MovementManager.get_minterp:
        public CMotionInterp* get_minterp() => ((delegate* unmanaged[Thiscall]<ref MovementManager, CMotionInterp*>)0x005242A0)(ref this); // .text:005242A0 ; CMotionInterp *__thiscall MovementManager::get_minterp(MovementManager *this) .text:005242A0 ?get_minterp@MovementManager@@QAEPAVCMotionInterp@@XZ

        // MovementManager.MotionDone:
        public void MotionDone(UInt32 motion, int success) => ((delegate* unmanaged[Thiscall]<ref MovementManager, UInt32, int, void>)0x005242D0)(ref this, motion, success); // .text:005242D0 ; void __thiscall MovementManager::MotionDone(MovementManager *this, unsigned int motion, int success) .text:005242D0 ?MotionDone@MovementManager@@QAEXKH@Z

        // MovementManager.ReportExhaustion:
        public void ReportExhaustion() => ((delegate* unmanaged[Thiscall]<ref MovementManager, void>)0x00524360)(ref this); // .text:00524360 ; void __thiscall MovementManager::ReportExhaustion(MovementManager *this) .text:00524360 ?ReportExhaustion@MovementManager@@QAEXXZ

        // MovementManager.PerformMovement:
        public UInt32 PerformMovement(MovementStruct* movement_struct) => ((delegate* unmanaged[Thiscall]<ref MovementManager, MovementStruct*, UInt32>)0x005240D0)(ref this, movement_struct); // .text:005240D0 ; unsigned int __thiscall MovementManager::PerformMovement(MovementManager *this, MovementStruct *movement_struct) .text:005240D0 ?PerformMovement@MovementManager@@QAEKABVMovementStruct@@@Z

        // MovementManager.move_to_interpreted_state:
        public void move_to_interpreted_state(InterpretedMotionState* state) => ((delegate* unmanaged[Thiscall]<ref MovementManager, InterpretedMotionState*, void>)0x00524170)(ref this, state); // .text:00524170 ; void __thiscall MovementManager::move_to_interpreted_state(MovementManager *this, InterpretedMotionState *state) .text:00524170 ?move_to_interpreted_state@MovementManager@@QAEXABVInterpretedMotionState@@@Z

        // MovementManager.unpack_movement:
        public int unpack_movement(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref MovementManager, void**, UInt32, int>)0x00524440)(ref this, addr, size); // .text:00524440 ; int __thiscall MovementManager::unpack_movement(MovementManager *this, void **addr, unsigned int size) .text:00524440 ?unpack_movement@MovementManager@@QAEHAAPAXI@Z

        // MovementManager.CancelMoveTo:
        public void CancelMoveTo(UInt32 err) => ((delegate* unmanaged[Thiscall]<ref MovementManager, UInt32, void>)0x005241B0)(ref this, err); // .text:005241B0 ; void __thiscall MovementManager::CancelMoveTo(MovementManager *this, unsigned int err) .text:005241B0 ?CancelMoveTo@MovementManager@@QAEXK@Z

        // MovementManager.motions_pending:
        public int motions_pending() => ((delegate* unmanaged[Thiscall]<ref MovementManager, int>)0x00524280)(ref this); // .text:00524280 ; int __thiscall MovementManager::motions_pending(MovementManager *this) .text:00524280 ?motions_pending@MovementManager@@QBEHXZ

        // MovementManager.InqRawMotionState:
        public RawMotionState* InqRawMotionState() => ((delegate* unmanaged[Thiscall]<ref MovementManager, RawMotionState*>)0x00524200)(ref this); // .text:00524200 ; RawMotionState *__thiscall MovementManager::InqRawMotionState(MovementManager *this) .text:00524200 ?InqRawMotionState@MovementManager@@QAEABVRawMotionState@@XZ

        // MovementManager.InqInterpretedMotionState:
        public InterpretedMotionState* InqInterpretedMotionState() => ((delegate* unmanaged[Thiscall]<ref MovementManager, InterpretedMotionState*>)0x00524230)(ref this); // .text:00524230 ; InterpretedMotionState *__thiscall MovementManager::InqInterpretedMotionState(MovementManager *this) .text:00524230 ?InqInterpretedMotionState@MovementManager@@QAEABVInterpretedMotionState@@XZ

        // MovementManager.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref MovementManager, void>)0x005242F0)(ref this); // .text:005242F0 ; void __thiscall MovementManager::UseTime(MovementManager *this) .text:005242F0 ?UseTime@MovementManager@@QAEXXZ

        // MovementManager.MakeMoveToManager:
        public void MakeMoveToManager() => ((delegate* unmanaged[Thiscall]<ref MovementManager, void>)0x00524000)(ref this); // .text:00524000 ; void __thiscall MovementManager::MakeMoveToManager(MovementManager *this) .text:00524000 ?MakeMoveToManager@MovementManager@@AAEXXZ

        // MovementManager.EnterDefaultState:
        public void EnterDefaultState() => ((delegate* unmanaged[Thiscall]<ref MovementManager, void>)0x005241C0)(ref this); // .text:005241C0 ; void __thiscall MovementManager::EnterDefaultState(MovementManager *this) .text:005241C0 ?EnterDefaultState@MovementManager@@QAEXXZ
    }


    public unsafe struct PositionManager {
        // Struct:
        public InterpolationManager* interpolation_manager;
        public StickyManager* sticky_manager;
        public ConstraintManager* constraint_manager;
        public CPhysicsObj* physics_obj;
        public override string ToString() => $"interpolation_manager:->(InterpolationManager*)0x{(int)interpolation_manager:X8}, sticky_manager:->(StickyManager*)0x{(int)sticky_manager:X8}, constraint_manager:->(ConstraintManager*)0x{(int)constraint_manager:X8}, physics_obj:->(CPhysicsObj*)0x{(int)physics_obj:X8}";

        // Functions:

        // PositionManager.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref PositionManager, void>)0x00555160)(ref this); // .text:00555160 ; void __thiscall PositionManager::UseTime(PositionManager *this) .text:00555160 ?UseTime@PositionManager@@QAEXXZ

        // PositionManager.InterpolateTo:
        public void InterpolateTo(Position* p, int keep_heading) => ((delegate* unmanaged[Thiscall]<ref PositionManager, Position*, int, void>)0x005551F0)(ref this, p, keep_heading); // .text:005551F0 ; void __thiscall PositionManager::InterpolateTo(PositionManager *this, Position *p, int keep_heading) .text:005551F0 ?InterpolateTo@PositionManager@@QAEXABVPosition@@H@Z

        // PositionManager.StickTo:
        public void StickTo(UInt32 object_id, Single radius, Single height) => ((delegate* unmanaged[Thiscall]<ref PositionManager, UInt32, Single, Single, void>)0x00555230)(ref this, object_id, radius, height); // .text:00555230 ; void __thiscall PositionManager::StickTo(PositionManager *this, unsigned int object_id, float radius, float height) .text:00555230 ?StickTo@PositionManager@@QAEXKMM@Z

        // PositionManager.HandleUpdateTarget:
        public void HandleUpdateTarget(TargetInfo target_info) => ((delegate* unmanaged[Thiscall]<ref PositionManager, TargetInfo, void>)0x005553D0)(ref this, target_info); // .text:005553D0 ; void __thiscall PositionManager::HandleUpdateTarget(PositionManager *this, TargetInfo target_info) .text:005553D0 ?HandleUpdateTarget@PositionManager@@QAEXVTargetInfo@@@Z

        // PositionManager.adjust_offset:
        public void adjust_offset(Frame* offset, Double quantum) => ((delegate* unmanaged[Thiscall]<ref PositionManager, Frame*, Double, void>)0x00555190)(ref this, offset, quantum); // .text:00555190 ; void __thiscall PositionManager::adjust_offset(PositionManager *this, Frame *offset, long double quantum) .text:00555190 ?adjust_offset@PositionManager@@QAEXAAVFrame@@N@Z

        // PositionManager.ConstrainTo:
        public void ConstrainTo(Position* p, Single start_distance, Single max_distance) => ((delegate* unmanaged[Thiscall]<ref PositionManager, Position*, Single, Single, void>)0x00555280)(ref this, p, start_distance, max_distance); // .text:00555280 ; void __thiscall PositionManager::ConstrainTo(PositionManager *this, Position *p, float start_distance, float max_distance) .text:00555280 ?ConstrainTo@PositionManager@@QAEXABVPosition@@MM@Z

        // PositionManager.UnConstrain:
        public void UnConstrain() => ((delegate* unmanaged[Thiscall]<ref PositionManager, void>)0x005552B0)(ref this); // .text:005552B0 ; void __thiscall PositionManager::UnConstrain(PositionManager *this) .text:005552B0 ?UnConstrain@PositionManager@@QAEXXZ

        // PositionManager.Create:
        public static PositionManager* Create(CPhysicsObj* _physics_obj) => ((delegate* unmanaged[Cdecl]<CPhysicsObj*, PositionManager*>)0x005552D0)(_physics_obj); // .text:005552D0 ; PositionManager *__cdecl PositionManager::Create(CPhysicsObj *_physics_obj) .text:005552D0 ?Create@PositionManager@@SAPAV1@PAVCPhysicsObj@@@Z

        // PositionManager.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref PositionManager, void>)0x00555340)(ref this); // .text:00555340 ; void __thiscall PositionManager::Destroy(PositionManager *this) .text:00555340 ?Destroy@PositionManager@@IAEXXZ

        // PositionManager.UnStick:
        public void UnStick() => ((delegate* unmanaged[Thiscall]<ref PositionManager, void>)0x005551E0)(ref this); // .text:005551E0 ; void __thiscall PositionManager::UnStick(PositionManager *this) .text:005551E0 ?UnStick@PositionManager@@QAEXXZ

        // PositionManager.StopInterpolating:
        public void StopInterpolating() => ((delegate* unmanaged[Thiscall]<ref PositionManager, void>)0x00555220)(ref this); // .text:00555220 ; void __thiscall PositionManager::StopInterpolating(PositionManager *this) .text:00555220 ?StopInterpolating@PositionManager@@QAEXXZ

        // PositionManager.GetStickyObjectID:
        public UInt32 GetStickyObjectID() => ((delegate* unmanaged[Thiscall]<ref PositionManager, UInt32>)0x00555270)(ref this); // .text:00555270 ; unsigned int __thiscall PositionManager::GetStickyObjectID(PositionManager *this) .text:00555270 ?GetStickyObjectID@PositionManager@@QBEKXZ

        // PositionManager.IsFullyConstrained:
        public int IsFullyConstrained() => ((delegate* unmanaged[Thiscall]<ref PositionManager, int>)0x005552C0)(ref this); // .text:005552C0 ; int __thiscall PositionManager::IsFullyConstrained(PositionManager *this) .text:005552C0 ?IsFullyConstrained@PositionManager@@QBEHXZ

        // PositionManager.IsInterpolating:
        public int IsInterpolating() => ((delegate* unmanaged[Thiscall]<ref PositionManager, int>)0x005553B0)(ref this); // .text:005553B0 ; int __thiscall PositionManager::IsInterpolating(PositionManager *this) .text:005553B0 ?IsInterpolating@PositionManager@@QBEHXZ
    }



    public unsafe struct MovementStruct {
        // Struct:
        public MovementTypes.Type type;
        public UInt32 motion;
        public UInt32 object_id;
        public UInt32 top_level_id;
        public Position pos;
        public Single radius;
        public Single height;
        public MovementParameters* _params;
        public override string ToString() => $"type(MovementTypes.Type):{type}, motion:{motion:X8}, object_id:{object_id:X8}, top_level_id:{top_level_id:X8}, pos(Position):{pos}, radius:{radius:n5}, height:{height:n5}, _params:->(MovementParameters*)0x{(Int32)_params:X8}";

    }
    public unsafe struct MoveToManager {
        // Struct:
        public MovementTypes.Type movement_type;
        public Position sought_position;
        public Position current_target_position;
        public Position starting_position;
        public MovementParameters movement_params;
        public Single previous_heading;
        public Single previous_distance;
        public Double previous_distance_time;
        public Single original_distance;
        public Double original_distance_time;
        public UInt32 fail_progress_count;
        public UInt32 sought_object_id;
        public UInt32 top_level_object_id;
        public Single sought_object_radius;
        public Single sought_object_height;
        public UInt32 current_command;
        public UInt32 aux_command;
        public int moving_away;
        public int initialized;
        public DLList<MoveToManager.MovementNode> pending_actions;
        public CPhysicsObj* physics_obj;
        public CWeenieObject* weenie_obj;
        public override string ToString() => $"movement_type(MovementTypes::Type):{movement_type}, sought_position(Position):{sought_position}, current_target_position(Position):{current_target_position}, starting_position(Position):{starting_position}, movement_params(MovementParameters):{movement_params}, previous_heading:{previous_heading:n5}, previous_distance:{previous_distance:n5}, previous_distance_time:{previous_distance_time:n5}, original_distance:{original_distance:n5}, original_distance_time:{original_distance_time:n5}, fail_progress_count:{fail_progress_count:X8}, sought_object_id:{sought_object_id:X8}, top_level_object_id:{top_level_object_id:X8}, sought_object_radius:{sought_object_radius:n5}, sought_object_height:{sought_object_height:n5}, current_command:{current_command:X8}, aux_command:{aux_command:X8}, moving_away(int):{moving_away}, initialized(int):{initialized}, pending_actions(DLList<MoveToManager::MovementNode>):{pending_actions}, physics_obj:->(CPhysicsObj*)0x{(int)physics_obj:X8}, weenie_obj:->(CWeenieObject*)0x{(int)weenie_obj:X8}";
        public unsafe struct MovementNode {
            public DLListData a0;
            public MovementTypes.Type type;
            public Single heading;
            public override string ToString() => $"a0(DLListData):{a0}, type(MovementTypes.Type):{type}, heading:{heading:n5}";
        }

        // Functions:

        // MoveToManager.AddTurnToHeadingNode:
        public void AddTurnToHeadingNode(Single global_heading) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, Single, void>)0x00529530)(ref this, global_heading); // .text:00529530 ; void __thiscall MoveToManager::AddTurnToHeadingNode(MoveToManager *this, float global_heading) .text:00529530 ?AddTurnToHeadingNode@MoveToManager@@IAEXM@Z

        // MoveToManager.GetCurrentDistance:
        public Single GetCurrentDistance() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, Single>)0x005291B0)(ref this); // .text:005291B0 ; float __thiscall MoveToManager::GetCurrentDistance(MoveToManager *this) .text:005291B0 ?GetCurrentDistance@MoveToManager@@IBEMXZ

        // MoveToManager.CleanUpAndCallWeenie:
        public void CleanUpAndCallWeenie(UInt32 status) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, UInt32, void>)0x00529650)(ref this, status); // .text:00529650 ; void __thiscall MoveToManager::CleanUpAndCallWeenie(MoveToManager *this, unsigned int status) .text:00529650 ?CleanUpAndCallWeenie@MoveToManager@@IAEXK@Z

        // MoveToManager.HitGround:
        public void HitGround() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x00529D70)(ref this); // .text:00529D70 ; void __thiscall MoveToManager::HitGround(MoveToManager *this) .text:00529D70 ?HitGround@MoveToManager@@QAEXXZ

        // MoveToManager.HandleTurnToHeading:
        public void HandleTurnToHeading() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x0052A0C0)(ref this); // .text:0052A0C0 ; void __thiscall MoveToManager::HandleTurnToHeading(MoveToManager *this) .text:0052A0C0 ?HandleTurnToHeading@MoveToManager@@IAEXXZ

        // MoveToManager.MoveToObject_Internal:
        public void MoveToObject_Internal(Position* _target_position, Position* interpolated_position) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, Position*, Position*, void>)0x0052A400)(ref this, _target_position, interpolated_position); // .text:0052A400 ; void __thiscall MoveToManager::MoveToObject_Internal(MoveToManager *this, Position *_target_position, Position *interpolated_position) .text:0052A400 ?MoveToObject_Internal@MoveToManager@@IAEXABVPosition@@0@Z

        // MoveToManager.TurnToObject_Internal:
        public void TurnToObject_Internal(Position* _target_position) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, Position*, void>)0x0052A550)(ref this, _target_position); // .text:0052A550 ; void __thiscall MoveToManager::TurnToObject_Internal(MoveToManager *this, Position *_target_position) .text:0052A550 ?TurnToObject_Internal@MoveToManager@@IAEXABVPosition@@@Z

        // MoveToManager.is_moving_to:
        public int is_moving_to() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, int>)0x00529220)(ref this); // .text:00529220 ; int __thiscall MoveToManager::is_moving_to(MoveToManager *this) .text:00529220 ?is_moving_to@MoveToManager@@QBEHXZ

        // MoveToManager.SetWeenieObject:
        public void SetWeenieObject(CWeenieObject* wobj) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, CWeenieObject*, void>)0x00529230)(ref this, wobj); // .text:00529230 ; void __thiscall MoveToManager::SetWeenieObject(MoveToManager *this, CWeenieObject *wobj) .text:00529230 ?SetWeenieObject@MoveToManager@@QAEXPAVCWeenieObject@@@Z

        // MoveToManager.SetPhysicsObject:
        public void SetPhysicsObject(CPhysicsObj* pobj) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, CPhysicsObj*, void>)0x00529240)(ref this, pobj); // .text:00529240 ; void __thiscall MoveToManager::SetPhysicsObject(MoveToManager *this, CPhysicsObj *pobj) .text:00529240 ?SetPhysicsObject@MoveToManager@@QAEXPAVCPhysicsObj@@@Z

        // MoveToManager.Create:
        public static MoveToManager* Create(CPhysicsObj* physics_obj, CWeenieObject* weenie_obj) => ((delegate* unmanaged[Cdecl]<CPhysicsObj*, CWeenieObject*, MoveToManager*>)0x00529470)(physics_obj, weenie_obj); // .text:00529470 ; MoveToManager *__cdecl MoveToManager::Create(CPhysicsObj *physics_obj, CWeenieObject *weenie_obj) .text:00529470 ?Create@MoveToManager@@SAPAV1@PAVCPhysicsObj@@PAVCWeenieObject@@@Z

        // MoveToManager.BeginTurnToHeading:
        public void BeginTurnToHeading() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x00529B90)(ref this); // .text:00529B90 ; void __thiscall MoveToManager::BeginTurnToHeading(MoveToManager *this) .text:00529B90 ?BeginTurnToHeading@MoveToManager@@IAEXXZ

        // MoveToManager.BeginNextNode:
        public void BeginNextNode() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x00529CB0)(ref this); // .text:00529CB0 ; void __thiscall MoveToManager::BeginNextNode(MoveToManager *this) .text:00529CB0 ?BeginNextNode@MoveToManager@@IAEXXZ

        // MoveToManager.MoveToPosition:
        public void MoveToPosition(Position* p, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, Position*, MovementParameters*, void>)0x0052A240)(ref this, p, _params); // .text:0052A240 ; void __thiscall MoveToManager::MoveToPosition(MoveToManager *this, Position *p, MovementParameters *params) .text:0052A240 ?MoveToPosition@MoveToManager@@QAEXABVPosition@@ABVMovementParameters@@@Z

        // MoveToManager.PerformMovement:
        public UInt32 PerformMovement(MovementStruct* mvs) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, MovementStruct*, UInt32>)0x0052A900)(ref this, mvs); // .text:0052A900 ; unsigned int __thiscall MoveToManager::PerformMovement(MoveToManager *this, MovementStruct *mvs) .text:0052A900 ?PerformMovement@MoveToManager@@QAEKABVMovementStruct@@@Z

        // MoveToManager._DoMotion:
        public UInt32 _DoMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, UInt32, MovementParameters*, UInt32>)0x00529010)(ref this, motion, _params); // .text:00529010 ; unsigned int __thiscall MoveToManager::_DoMotion(MoveToManager *this, unsigned int motion, MovementParameters *params) .text:00529010 ?_DoMotion@MoveToManager@@IAEKKAAVMovementParameters@@@Z

        // MoveToManager.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x005293B0)(ref this); // .text:005293B0 ; void __thiscall MoveToManager::MoveToManager(MoveToManager *this) .text:005293B0 ??0MoveToManager@@IAE@XZ

        // MoveToManager.CancelMoveTo:
        public void CancelMoveTo(UInt32 retval) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, UInt32, void>)0x00529930)(ref this, retval); // .text:00529930 ; void __thiscall MoveToManager::CancelMoveTo(MoveToManager *this, unsigned int retval) .text:00529930 ?CancelMoveTo@MoveToManager@@QAEXK@Z

        // MoveToManager.BeginMoveForward:
        public void BeginMoveForward() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x00529A00)(ref this); // .text:00529A00 ; void __thiscall MoveToManager::BeginMoveForward(MoveToManager *this) .text:00529A00 ?BeginMoveForward@MoveToManager@@IAEXXZ

        // MoveToManager.HandleMoveToPosition:
        public void HandleMoveToPosition() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x00529D80)(ref this); // .text:00529D80 ; void __thiscall MoveToManager::HandleMoveToPosition(MoveToManager *this) .text:00529D80 ?HandleMoveToPosition@MoveToManager@@IAEXXZ

        // MoveToManager._StopMotion:
        public UInt32 _StopMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, UInt32, MovementParameters*, UInt32>)0x00529080)(ref this, motion, _params); // .text:00529080 ; unsigned int __thiscall MoveToManager::_StopMotion(MoveToManager *this, unsigned int motion, MovementParameters *params) .text:00529080 ?_StopMotion@MoveToManager@@IAEKKAAVMovementParameters@@@Z

        // MoveToManager.RemovePendingActionsHead:
        public void RemovePendingActionsHead() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x00529380)(ref this); // .text:00529380 ; void __thiscall MoveToManager::RemovePendingActionsHead(MoveToManager *this) .text:00529380 ?RemovePendingActionsHead@MoveToManager@@IAEXXZ

        // MoveToManager.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x005294B0)(ref this); // .text:005294B0 ; void __thiscall MoveToManager::Destroy(MoveToManager *this) .text:005294B0 ?Destroy@MoveToManager@@QAEXXZ

        // MoveToManager.CleanUp:
        public void CleanUp() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x005295C0)(ref this); // .text:005295C0 ; void __thiscall MoveToManager::CleanUp(MoveToManager *this) .text:005295C0 ?CleanUp@MoveToManager@@IAEXXZ

        // MoveToManager.TurnToObject:
        public void TurnToObject(UInt32 object_id, UInt32 top_level_id, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, UInt32, UInt32, MovementParameters*, void>)0x005297D0)(ref this, object_id, top_level_id, _params); // .text:005297D0 ; void __thiscall MoveToManager::TurnToObject(MoveToManager *this, unsigned int object_id, unsigned int top_level_id, MovementParameters *params) .text:005297D0 ?TurnToObject@MoveToManager@@QAEXKKABVMovementParameters@@@Z

        // MoveToManager.HandleUpdateTarget:
        public void HandleUpdateTarget(TargetInfo* target_info) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, TargetInfo*, void>)0x0052A7D0)(ref this, target_info); // .text:0052A7D0 ; void __thiscall MoveToManager::HandleUpdateTarget(MoveToManager *this, TargetInfo *target_info) .text:0052A7D0 ?HandleUpdateTarget@MoveToManager@@QAEXABVTargetInfo@@@Z

        // MoveToManager.MoveToObject:
        public void MoveToObject(UInt32 object_id, UInt32 top_level_id, Single object_radius, Single object_height, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, UInt32, UInt32, Single, Single, MovementParameters*, void>)0x00529680)(ref this, object_id, top_level_id, object_radius, object_height, _params); // .text:00529680 ; void __thiscall MoveToManager::MoveToObject(MoveToManager *this, unsigned int object_id, unsigned int top_level_id, float object_radius, float object_height, MovementParameters *params) .text:00529680 ?MoveToObject@MoveToManager@@QAEXKKMMABVMovementParameters@@@Z

        // MoveToManager.TurnToHeading:
        public void TurnToHeading(MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, MovementParameters*, void>)0x0052A630)(ref this, _params); // .text:0052A630 ; void __thiscall MoveToManager::TurnToHeading(MoveToManager *this, MovementParameters *params) .text:0052A630 ?TurnToHeading@MoveToManager@@QAEXABVMovementParameters@@@Z

        // MoveToManager.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x0052A780)(ref this); // .text:0052A780 ; void __thiscall MoveToManager::UseTime(MoveToManager *this) .text:0052A780 ?UseTime@MoveToManager@@QAEXXZ

        // MoveToManager.CheckProgressMade:
        public int CheckProgressMade(Single curr_distance) => ((delegate* unmanaged[Thiscall]<ref MoveToManager, Single, int>)0x005290F0)(ref this, curr_distance); // .text:005290F0 ; int __thiscall MoveToManager::CheckProgressMade(MoveToManager *this, float curr_distance) .text:005290F0 ?CheckProgressMade@MoveToManager@@IAEHM@Z

        // MoveToManager.InitializeLocalVariables:
        public void InitializeLocalVariables() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x00529250)(ref this); // .text:00529250 ; void __thiscall MoveToManager::InitializeLocalVariables(MoveToManager *this) .text:00529250 ?InitializeLocalVariables@MoveToManager@@IAEXXZ

        // MoveToManager.AddMoveToPositionNode:
        public void AddMoveToPositionNode() => ((delegate* unmanaged[Thiscall]<ref MoveToManager, void>)0x00529580)(ref this); // .text:00529580 ; void __thiscall MoveToManager::AddMoveToPositionNode(MoveToManager *this) .text:00529580 ?AddMoveToPositionNode@MoveToManager@@IAEXXZ
    }



    public unsafe struct MovementTypes {
        // Enums:
        public enum Type : UInt32 {
            Invalid = 0x0,
            RawCommand = 0x1,
            InterpretedCommand = 0x2,
            StopRawCommand = 0x3,
            StopInterpretedCommand = 0x4,
            StopCompletely = 0x5,
            MoveToObject = 0x6,
            MoveToPosition = 0x7,
            TurnToObject = 0x8,
            TurnToHeading = 0x9,
            FORCE_Type_32_BIT = 0x7FFFFFFF,
        };
    }


    public unsafe struct MovementParameters {
        public PackObj a0;
        public UInt32 bitfield;
        /*
          U__Int32 can_walk : 1;
          U__Int32 can_run : 1;
          U__Int32 can_sidestep : 1;
          U__Int32 can_walk_backwards : 1;
          U__Int32 can_Charge : 1;
          U__Int32 fail_walk : 1;
          U__Int32 use_final_heading : 1;
          U__Int32 sticky : 1;
          U__Int32 move_away : 1;
          U__Int32 move_towards : 1;
          U__Int32 use_spheres : 1;
          U__Int32 set_hold_key : 1;
          U__Int32 autonomous : 1;
          U__Int32 modify_raw_state : 1;
          U__Int32 modify_Int32erpreted_state : 1;
          U__Int32 cancel_moveto : 1;
          U__Int32 stop_completely : 1;
          U__Int32 disable_jump_during_link : 1;
        */
        public Single distance_to_object;
        public Single min_distance;
        public Single desired_heading;
        public Single speed;
        public Single fail_distance;
        public Single walk_run_threshhold;
        public UInt32 context_id;
        public HoldKey hold_key_to_apply;
        public UInt32 action_stamp;
        public override string ToString() => $"bitfield:{bitfield:X8}, distance_to_object:{distance_to_object:n5}, min_distance:{min_distance:n5}, desired_heading:{desired_heading:n5}, speed:{speed:n5}, fail_distance:{fail_distance:n5}, walk_run_threshhold:{walk_run_threshhold:n5}, context_id:{context_id:X8}, hold_key_to_apply:{hold_key_to_apply}, action_stamp:{action_stamp:X8}";

        // Functions:

        // MovementParameters.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref MovementParameters, void>)0x00524380)(ref this); // .text:00524380 ; void __thiscall MovementParameters::MovementParameters(MovementParameters *this) .text:00524380 ??0MovementParameters@@QAE@XZ

        // MovementParameters.towards_and_away:
        public void towards_and_away(Single curr_distance, Single curr_heading, UInt32* command, int* moving_away) => ((delegate* unmanaged[Thiscall]<ref MovementParameters, Single, Single, UInt32*, int*, void>)0x0052A9A0)(ref this, curr_distance, curr_heading, command, moving_away); // .text:0052A9A0 ; void __thiscall MovementParameters::towards_and_away(MovementParameters *this, float curr_distance, float curr_heading, unsigned int *command, int *moving_away) .text:0052A9A0 ?towards_and_away@MovementParameters@@ABEXMMAAKAAH@Z

        // MovementParameters.get_command:
        public void get_command(Single curr_distance, Single curr_heading, UInt32* command, HoldKey* key, int* moving_away) => ((delegate* unmanaged[Thiscall]<ref MovementParameters, Single, Single, UInt32*, HoldKey*, int*, void>)0x0052AA00)(ref this, curr_distance, curr_heading, command, key, moving_away); // .text:0052AA00 ; void __thiscall MovementParameters::get_command(MovementParameters *this, float curr_distance, float curr_heading, unsigned int *command, HoldKey *key, int *moving_away) .text:0052AA00 ?get_command@MovementParameters@@QBEXMMAAKAAW4HoldKey@@AAH@Z

        // MovementParameters.get_desired_heading:
        public Single get_desired_heading(UInt32 command, int moving_away) => ((delegate* unmanaged[Thiscall]<ref MovementParameters, UInt32, int, Single>)0x0052AAD0)(ref this, command, moving_away); // .text:0052AAD0 ; float __thiscall MovementParameters::get_desired_heading(MovementParameters *this, unsigned int command, int moving_away) .text:0052AAD0 ?get_desired_heading@MovementParameters@@QBEMKH@Z

        // MovementParameters.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref MovementParameters, void**, UInt32, UInt32>)0x0052AB20)(ref this, addr, size); // .text:0052AB20 ; unsigned int __thiscall MovementParameters::Pack(MovementParameters *this, void **addr, unsigned int size) .text:0052AB20 ?Pack@MovementParameters@@UAEIAAPAXI@Z

        // MovementParameters.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref MovementParameters, void**, UInt32, int>)0x0052ABC0)(ref this, addr, size); // .text:0052ABC0 ; int __thiscall MovementParameters::UnPack(MovementParameters *this, void **addr, unsigned int size) .text:0052ABC0 ?UnPack@MovementParameters@@UAEHAAPAXI@Z

        // MovementParameters.UnPackNet:
        public int UnPackNet(MovementTypes.Type type, void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref MovementParameters, MovementTypes.Type, void**, UInt32, int>)0x0052AC50)(ref this, type, addr, size); // .text:0052AC50 ; int __thiscall MovementParameters::UnPackNet(MovementParameters *this, MovementTypes::Type type, void **addr, unsigned int size) .text:0052AC50 ?UnPackNet@MovementParameters@@QAEHW4Type@MovementTypes@@AAPAXI@Z

        // Globals:
        //public static UInt32 `void __thiscall* set_moveto_flags(void)'.`2'.normal_bitfield = (UInt32 `void __thiscall*)0x008444E8; // .data:008444E8 ; unsigned int `public: void __thiscall MovementParameters::set_moveto_flags(void)'::`2'::normal_bitfield .data:008444E8 ?normal_bitfield@?1??set_moveto_flags@MovementParameters@@QAEXXZ@4IA

    };

    public unsafe struct RawMotionState {
        // Struct:
        public PackObj a0;
        public LList<ActionNode> actions;
        public HoldKey current_holdkey;
        public UInt32 current_style;
        public UInt32 forward_command;
        public HoldKey forward_holdkey;
        public Single forward_speed;
        public UInt32 sidestep_command;
        public HoldKey sidestep_holdkey;
        public Single sidestep_speed;
        public UInt32 turn_command;
        public HoldKey turn_holdkey;
        public Single turn_speed;
        public override string ToString() => $"actions:{actions}, current_holdkey:{current_holdkey}, current_style:{current_style:X8}, forward_command:{forward_command:X8}, forward_holdkey(HoldKey):{forward_holdkey}, forward_speed:{forward_speed:n5}, sidestep_command:{sidestep_command:X8}, sidestep_holdkey(HoldKey):{sidestep_holdkey}, sidestep_speed:{sidestep_speed:n5}, turn_command:{turn_command:X8}, turn_holdkey(HoldKey):{turn_holdkey}, turn_speed:{turn_speed:n5}";
        //public unsafe struct PackBitfield {
        //    public UInt32 current_holdkey : 1;
        //    public UInt32 current_style : 1;
        //    public UInt32 forward_command : 1;
        //    public UInt32 forward_holdkey : 1;
        //    public UInt32 forward_speed : 1;
        //    public UInt32 sidestep_command : 1;
        //    public UInt32 sidestep_holdkey : 1;
        //    public UInt32 sidestep_speed : 1;
        //    public UInt32 turn_command : 1;
        //    public UInt32 turn_holdkey : 1;
        //    public UInt32 turn_speed : 1;
        //    public UInt32 num_actions : 5;
        //    public override string ToString() => $"1(UInt32 current_holdkey :):{1}, 1(UInt32 current_style :):{1}, 1(UInt32 forward_command :):{1}, 1(UInt32 forward_holdkey :):{1}, 1(UInt32 forward_speed :):{1}, 1(UInt32 sidestep_command :):{1}, 1(UInt32 sidestep_holdkey :):{1}, 1(UInt32 sidestep_speed :):{1}, 1(UInt32 turn_command :):{1}, 1(UInt32 turn_holdkey :):{1}, 1(UInt32 turn_speed :):{1}, 5(UInt32 num_actions :):{5}";
        //}

        // Functions:

        // RawMotionState.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref RawMotionState, void>)0x0051EB20)(ref this); // .text:0051EB20 ; void __thiscall RawMotionState::Destroy(RawMotionState *this) .text:0051EB20 ?Destroy@RawMotionState@@QAEXXZ

        // RawMotionState.ApplyMotion:
        public void ApplyMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref RawMotionState, UInt32, MovementParameters*, void>)0x0051EB60)(ref this, motion, _params); // .text:0051EB60 ; void __thiscall RawMotionState::ApplyMotion(RawMotionState *this, unsigned int motion, MovementParameters *params) .text:0051EB60 ?ApplyMotion@RawMotionState@@QAEXKABVMovementParameters@@@Z

        // RawMotionState.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref RawMotionState, void**, UInt32, UInt32>)0x0051ED10)(ref this, addr, size); // .text:0051ED10 ; unsigned int __thiscall RawMotionState::Pack(RawMotionState *this, void **addr, unsigned int size) .text:0051ED10 ?Pack@RawMotionState@@UAEIAAPAXI@Z

        // RawMotionState.RemoveAction:
        public UInt32 RemoveAction() => ((delegate* unmanaged[Thiscall]<ref RawMotionState, UInt32>)0x0051E8A0)(ref this); // .text:0051E8A0 ; unsigned int __thiscall RawMotionState::RemoveAction(RawMotionState *this) .text:0051E8A0 ?RemoveAction@RawMotionState@@QAEKXZ

        // RawMotionState.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref RawMotionState, void>)0x0051E7F0)(ref this); // .text:0051E7F0 ; void __thiscall RawMotionState::RawMotionState(RawMotionState *this) .text:0051E7F0 ??0RawMotionState@@QAE@XZ

        // RawMotionState.AddAction:
        public void AddAction(UInt32 action, Single speed, UInt32 stamp, int autonomous) => ((delegate* unmanaged[Thiscall]<ref RawMotionState, UInt32, Single, UInt32, int, void>)0x0051E840)(ref this, action, speed, stamp, autonomous); // .text:0051E840 ; void __thiscall RawMotionState::AddAction(RawMotionState *this, unsigned int action, float speed, unsigned int stamp, int autonomous) .text:0051E840 ?AddAction@RawMotionState@@QAEXKMKH@Z

        // RawMotionState.operator_equals:
        public RawMotionState* operator_equals() => ((delegate* unmanaged[Thiscall]<ref RawMotionState, RawMotionState*>)0x0051EC60)(ref this); // .text:0051EC60 ; public: class RawMotionState & __thiscall RawMotionState::operator=(class RawMotionState const &) .text:0051EC60 ??4RawMotionState@@QAEAAV0@ABV0@@Z

        // RawMotionState.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref RawMotionState, void**, UInt32, int>)0x0051EFC0)(ref this, addr, size); // .text:0051EFC0 ; int __thiscall RawMotionState::UnPack(RawMotionState *this, void **addr, unsigned int size) .text:0051EFC0 ?UnPack@RawMotionState@@UAEHAAPAXI@Z

        // RawMotionState.RemoveMotion:
        public void RemoveMotion(UInt32 motion) => ((delegate* unmanaged[Thiscall]<ref RawMotionState, UInt32, void>)0x0051E6E0)(ref this, motion); // .text:0051E6E0 ; void __thiscall RawMotionState::RemoveMotion(RawMotionState *this, unsigned int motion) .text:0051E6E0 ?RemoveMotion@RawMotionState@@QAEXK@Z
    }
    public unsafe struct InterpretedMotionState {
        // Struct:
        public PackObj a0;
        public UInt32 current_style;
        public UInt32 forward_command;
        public Single forward_speed;
        public UInt32 sidestep_command;
        public Single sidestep_speed;
        public UInt32 turn_command;
        public Single turn_speed;
        public LList<ActionNode> actions;
        public override string ToString() => $"current_style:{current_style:X8}, forward_command:{forward_command:X8}, forward_speed:{forward_speed:n5}, sidestep_command:{sidestep_command:X8}, sidestep_speed:{sidestep_speed:n5}, turn_command:{turn_command:X8}, turn_speed:{turn_speed:n5}, actions:{actions}";
        //public unsafe struct PackBitfield {
        //    public UInt32 current_style : 1;
        //    public UInt32 forward_command : 1;
        //    public UInt32 forward_speed : 1;
        //    public UInt32 sidestep_command : 1;
        //    public UInt32 sidestep_speed : 1;
        //    public UInt32 turn_command : 1;
        //    public UInt32 turn_speed : 1;
        //    public UInt32 num_actions : 5;
        //    public override string ToString() => $"1(UInt32 current_style :):{1}, 1(UInt32 forward_command :):{1}, 1(UInt32 forward_speed :):{1}, 1(UInt32 sidestep_command :):{1}, 1(UInt32 sidestep_speed :):{1}, 1(UInt32 turn_command :):{1}, 1(UInt32 turn_speed :):{1}, 5(UInt32 num_actions :):{5}";
        //}

        // Functions:

        // InterpretedMotionState.operator_equals:
        public InterpretedMotionState* operator_equals() => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, InterpretedMotionState*>)0x0051E950)(ref this); // .text:0051E950 ; public: class InterpretedMotionState & __thiscall InterpretedMotionState::operator=(class InterpretedMotionState const &) .text:0051E950 ??4InterpretedMotionState@@QAEAAV0@ABV0@@Z

        // InterpretedMotionState.__Ctor:
        public void __Ctor(InterpretedMotionState* rhs) => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, InterpretedMotionState*, void>)0x0051F180)(ref this, rhs); // .text:0051F180 ; void __thiscall InterpretedMotionState::InterpretedMotionState(InterpretedMotionState *this, InterpretedMotionState *rhs) .text:0051F180 ??0InterpretedMotionState@@QAE@ABV0@@Z

        // InterpretedMotionState.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, void**, UInt32, int>)0x0051F400)(ref this, addr, size); // .text:0051F400 ; int __thiscall InterpretedMotionState::UnPack(InterpretedMotionState *this, void **addr, unsigned int size) .text:0051F400 ?UnPack@InterpretedMotionState@@UAEHAAPAXI@Z

        // InterpretedMotionState.RemoveMotion:
        public void RemoveMotion(UInt32 motion) => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, UInt32, void>)0x0051E790)(ref this, motion); // .text:0051E790 ; void __thiscall InterpretedMotionState::RemoveMotion(InterpretedMotionState *this, unsigned int motion) .text:0051E790 ?RemoveMotion@InterpretedMotionState@@QAEXK@Z

        // InterpretedMotionState.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, void>)0x0051E8D0)(ref this); // .text:0051E8D0 ; void __thiscall InterpretedMotionState::InterpretedMotionState(InterpretedMotionState *this) .text:0051E8D0 ??0InterpretedMotionState@@QAE@XZ

        // InterpretedMotionState.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, void>)0x0051E910)(ref this); // .text:0051E910 ; void __thiscall InterpretedMotionState::Destroy(InterpretedMotionState *this) .text:0051E910 ?Destroy@InterpretedMotionState@@QAEXXZ

        // InterpretedMotionState.AddAction:
        public void AddAction(UInt32 action, Single speed, UInt32 stamp, int autonomous) => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, UInt32, Single, UInt32, int, void>)0x0051E9E0)(ref this, action, speed, stamp, autonomous); // .text:0051E9E0 ; void __thiscall InterpretedMotionState::AddAction(InterpretedMotionState *this, unsigned int action, float speed, unsigned int stamp, int autonomous) .text:0051E9E0 ?AddAction@InterpretedMotionState@@QAEXKMKH@Z

        // InterpretedMotionState.ApplyMotion:
        public void ApplyMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, UInt32, MovementParameters*, void>)0x0051EA40)(ref this, motion, _params); // .text:0051EA40 ; void __thiscall InterpretedMotionState::ApplyMotion(InterpretedMotionState *this, unsigned int motion, MovementParameters *params) .text:0051EA40 ?ApplyMotion@InterpretedMotionState@@QAEXKABVMovementParameters@@@Z

        // InterpretedMotionState.RemoveAction:
        public UInt32 RemoveAction() => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, UInt32>)0x0051EAD0)(ref this); // .text:0051EAD0 ; unsigned int __thiscall InterpretedMotionState::RemoveAction(InterpretedMotionState *this) .text:0051EAD0 ?RemoveAction@InterpretedMotionState@@QAEKXZ

        // InterpretedMotionState.GetNumActions:
        public UInt32 GetNumActions() => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, UInt32>)0x0051EB00)(ref this); // .text:0051EB00 ; unsigned int __thiscall InterpretedMotionState::GetNumActions(InterpretedMotionState *this) .text:0051EB00 ?GetNumActions@InterpretedMotionState@@QBEKXZ

        // InterpretedMotionState.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, void**, UInt32, UInt32>)0x0051F1D0)(ref this, addr, size); // .text:0051F1D0 ; unsigned int __thiscall InterpretedMotionState::Pack(InterpretedMotionState *this, void **addr, unsigned int size) .text:0051F1D0 ?Pack@InterpretedMotionState@@UAEIAAPAXI@Z

        // InterpretedMotionState.copy_movement_from:
        public void copy_movement_from(InterpretedMotionState* rhs) => ((delegate* unmanaged[Thiscall]<ref InterpretedMotionState, InterpretedMotionState*, void>)0x0051E750)(ref this, rhs); // .text:0051E750 ; void __thiscall InterpretedMotionState::copy_movement_from(InterpretedMotionState *this, InterpretedMotionState *rhs) .text:0051E750 ?copy_movement_from@InterpretedMotionState@@QAEXABV1@@Z
    }
    public unsafe struct CMotionInterp {
        // Struct:
        public int initted;
        public CWeenieObject* weenie_obj;
        public CPhysicsObj* physics_obj;
        public RawMotionState raw_state;
        public InterpretedMotionState interpreted_state;
        public Single current_speed_factor;
        public int standing_longjump;
        public Single jump_extent;
        public UInt32 server_action_stamp;
        public Single my_run_rate;
        public LList<CMotionInterp.MotionNode> pending_motions;
        public override string ToString() => $"initted(int):{initted}, weenie_obj:->(CWeenieObject*)0x{(int)weenie_obj:X8}, physics_obj:->(CPhysicsObj*)0x{(int)physics_obj:X8}, raw_state(RawMotionState):({raw_state}), interpreted_state(InterpretedMotionState):({interpreted_state}), current_speed_factor:{current_speed_factor:n5}, standing_longjump(int):{standing_longjump}, jump_extent:{jump_extent:n5}, server_action_stamp:{server_action_stamp:X8}, my_run_rate:{my_run_rate:n5}, pending_motions:{pending_motions}";
        public unsafe struct MotionNode {
            public LListData a0;
            public UInt32 context_id;
            public UInt32 motion;
            public UInt32 jump_error_code;
            public override string ToString() => $"a0(LListData):{a0}, context_id:{context_id:X8}, motion:{motion:X8}, jump_error_code:{jump_error_code:X8}";
        }

        // Functions:

        // CMotionInterp.jump_charge_is_allowed:
        public UInt32 jump_charge_is_allowed() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32>)0x00527A50)(ref this); // .text:00527A50 ; unsigned int __thiscall CMotionInterp::jump_charge_is_allowed(CMotionInterp *this) .text:00527A50 ?jump_charge_is_allowed@CMotionInterp@@QAEKXZ

        // CMotionInterp.StopCompletely:
        public UInt32 StopCompletely() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32>)0x00527E40)(ref this); // .text:00527E40 ; unsigned int __thiscall CMotionInterp::StopCompletely(CMotionInterp *this) .text:00527E40 ?StopCompletely@CMotionInterp@@QAEKXZ

        // CMotionInterp.contact_allows_move:
        public int contact_allows_move(UInt32 motion) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32, int>)0x00528240)(ref this, motion); // .text:00528240 ; int __thiscall CMotionInterp::contact_allows_move(CMotionInterp *this, unsigned int motion) .text:00528240 ?contact_allows_move@CMotionInterp@@QBEHK@Z

        // CMotionInterp.SetPhysicsObject:
        public void SetPhysicsObject(CPhysicsObj* _physics_obj) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, CPhysicsObj*, void>)0x00528970)(ref this, _physics_obj); // .text:00528970 ; void __thiscall CMotionInterp::SetPhysicsObject(CMotionInterp *this, CPhysicsObj *_physics_obj) .text:00528970 ?SetPhysicsObject@CMotionInterp@@QAEXPAVCPhysicsObj@@@Z

        // CMotionInterp.get_adjusted_max_speed:
        public Single get_adjusted_max_speed() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, Single>)0x00527D00)(ref this); // .text:00527D00 ; float __thiscall CMotionInterp::get_adjusted_max_speed(CMotionInterp *this) .text:00527D00 ?get_adjusted_max_speed@CMotionInterp@@QBEMXZ

        // CMotionInterp.HitGround:
        public void HitGround() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, void>)0x00528AC0)(ref this); // .text:00528AC0 ; void __thiscall CMotionInterp::HitGround(CMotionInterp *this) .text:00528AC0 ?HitGround@CMotionInterp@@QAEXXZ

        // CMotionInterp.DoMotion:
        public UInt32 DoMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32, MovementParameters*, UInt32>)0x00528D20)(ref this, motion, _params); // .text:00528D20 ; unsigned int __thiscall CMotionInterp::DoMotion(CMotionInterp *this, unsigned int motion, MovementParameters *params) .text:00528D20 ?DoMotion@CMotionInterp@@QAEKKABVMovementParameters@@@Z

        // CMotionInterp.get_state_velocity:
        public void get_state_velocity(AC1Legacy.Vector3* v) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, AC1Legacy.Vector3*, void>)0x00527D50)(ref this, v); // .text:00527D50 ; void __thiscall CMotionInterp::get_state_velocity(CMotionInterp *this, AC1Legacy::Vector3 *v) .text:00527D50 ?get_state_velocity@CMotionInterp@@QBEXAAVVector3@AC1Legacy@@@Z

        // CMotionInterp.StopInterpretedMotion:
        public UInt32 StopInterpretedMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32, MovementParameters*, UInt32>)0x00528470)(ref this, motion, _params); // .text:00528470 ; unsigned int __thiscall CMotionInterp::StopInterpretedMotion(CMotionInterp *this, unsigned int motion, MovementParameters *params) .text:00528470 ?StopInterpretedMotion@CMotionInterp@@QAEKKABVMovementParameters@@@Z

        // CMotionInterp.set_hold_run:
        public void set_hold_run(int val, int cancel_moveto) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, int, int, void>)0x00528B70)(ref this, val, cancel_moveto); // .text:00528B70 ; void __thiscall CMotionInterp::set_hold_run(CMotionInterp *this, int val, int cancel_moveto) .text:00528B70 ?set_hold_run@CMotionInterp@@QAEXHH@Z

        // CMotionInterp.jump_is_allowed:
        public UInt32 jump_is_allowed(Single extent, int* stamina_cost) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, Single, int*, UInt32>)0x005282B0)(ref this, extent, stamina_cost); // .text:005282B0 ; unsigned int __thiscall CMotionInterp::jump_is_allowed(CMotionInterp *this, float extent, int *stamina_cost) .text:005282B0 ?jump_is_allowed@CMotionInterp@@QAEKMAAJ@Z

        // CMotionInterp.apply_raw_movement:
        public void apply_raw_movement(int cancel_moveto, int disallow_jump) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, int, int, void>)0x005287E0)(ref this, cancel_moveto, disallow_jump); // .text:005287E0 ; void __thiscall CMotionInterp::apply_raw_movement(CMotionInterp *this, int cancel_moveto, int disallow_jump) .text:005287E0 ?apply_raw_movement@CMotionInterp@@IAEXHH@Z

        // CMotionInterp.get_jump_v_z:
        public Single get_jump_v_z() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, Single>)0x00527AA0)(ref this); // .text:00527AA0 ; float __thiscall CMotionInterp::get_jump_v_z(CMotionInterp *this) .text:00527AA0 ?get_jump_v_z@CMotionInterp@@QBEMXZ

        // CMotionInterp.InqStyle:
        public UInt32 InqStyle() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32>)0x00527B10)(ref this); // .text:00527B10 ; unsigned int __thiscall CMotionInterp::InqStyle(CMotionInterp *this) .text:00527B10 ?InqStyle@CMotionInterp@@QBEKXZ

        // CMotionInterp.HandleExitWorld:
        public void HandleExitWorld() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, void>)0x00527F30)(ref this); // .text:00527F30 ; void __thiscall CMotionInterp::HandleExitWorld(CMotionInterp *this) .text:00527F30 ?HandleExitWorld@CMotionInterp@@QAEXXZ

        // CMotionInterp.charge_jump:
        public UInt32 charge_jump() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32>)0x005281C0)(ref this); // .text:005281C0 ; unsigned int __thiscall CMotionInterp::charge_jump(CMotionInterp *this) .text:005281C0 ?charge_jump@CMotionInterp@@QAEKXZ

        // CMotionInterp.motion_allows_jump:
        public UInt32 motion_allows_jump(UInt32 substate) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32, UInt32>)0x005279E0)(ref this, substate); // .text:005279E0 ; unsigned int __thiscall CMotionInterp::motion_allows_jump(CMotionInterp *this, unsigned int substate) .text:005279E0 ?motion_allows_jump@CMotionInterp@@QAEKK@Z

        // CMotionInterp.get_leave_ground_velocity:
        public void get_leave_ground_velocity(AC1Legacy.Vector3* v) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, AC1Legacy.Vector3*, void>)0x005280C0)(ref this, v); // .text:005280C0 ; void __thiscall CMotionInterp::get_leave_ground_velocity(CMotionInterp *this, AC1Legacy::Vector3 *v) .text:005280C0 ?get_leave_ground_velocity@CMotionInterp@@QAEXAAVVector3@AC1Legacy@@@Z

        // CMotionInterp.DoInterpretedMotion:
        public UInt32 DoInterpretedMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32, MovementParameters*, UInt32>)0x00528360)(ref this, motion, _params); // .text:00528360 ; unsigned int __thiscall CMotionInterp::DoInterpretedMotion(CMotionInterp *this, unsigned int motion, MovementParameters *params) .text:00528360 ?DoInterpretedMotion@CMotionInterp@@QAEKKABVMovementParameters@@@Z

        // CMotionInterp.jump:
        public UInt32 jump(Single extent, int* stamina_adjustment) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, Single, int*, UInt32>)0x00528780)(ref this, extent, stamina_adjustment); // .text:00528780 ; unsigned int __thiscall CMotionInterp::jump(CMotionInterp *this, float extent, int *stamina_adjustment) .text:00528780 ?jump@CMotionInterp@@QAEKMAAJ@Z

        // CMotionInterp.apply_current_movement:
        public void apply_current_movement(int cancel_moveto, int disallow_jump) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, int, int, void>)0x00528870)(ref this, cancel_moveto, disallow_jump); // .text:00528870 ; void __thiscall CMotionInterp::apply_current_movement(CMotionInterp *this, int cancel_moveto, int disallow_jump) .text:00528870 ?apply_current_movement@CMotionInterp@@IAEXHH@Z

        // CMotionInterp.SetWeenieObject:
        public void SetWeenieObject(CWeenieObject* _weenie_obj) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, CWeenieObject*, void>)0x00528920)(ref this, _weenie_obj); // .text:00528920 ; void __thiscall CMotionInterp::SetWeenieObject(CMotionInterp *this, CWeenieObject *_weenie_obj) .text:00528920 ?SetWeenieObject@CMotionInterp@@QAEXPAVCWeenieObject@@@Z

        // CMotionInterp.MotionDone:
        public void MotionDone(int success) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, int, void>)0x00528AD0)(ref this, success); // .text:00528AD0 ; void __thiscall CMotionInterp::MotionDone(CMotionInterp *this, int success) .text:00527EC0 ?MotionDone@CMotionInterp@@QAEXH@Z

        // CMotionInterp.is_standing_still:
        public int is_standing_still() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, int>)0x00527FA0)(ref this); // .text:00527FA0 ; int __thiscall CMotionInterp::is_standing_still(CMotionInterp *this) .text:00527FA0 ?is_standing_still@CMotionInterp@@QBEHXZ

        // CMotionInterp.motions_pending:
        public int motions_pending() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, int>)0x00527FE0)(ref this); // .text:00527FE0 ; int __thiscall CMotionInterp::motions_pending(CMotionInterp *this) .text:00527FE0 ?motions_pending@CMotionInterp@@QBEHXZ

        // CMotionInterp.adjust_motion:
        public void adjust_motion(UInt32* motion, Single* speed, HoldKey key) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32*, Single*, HoldKey, void>)0x00528010)(ref this, motion, speed, key); // .text:00528010 ; void __thiscall CMotionInterp::adjust_motion(CMotionInterp *this, unsigned int *motion, float *speed, HoldKey key) .text:00528010 ?adjust_motion@CMotionInterp@@QBEXAAKAAMW4HoldKey@@@Z

        // CMotionInterp.SetHoldKey:
        public void SetHoldKey(HoldKey key, int cancel_moveto) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, HoldKey, int, void>)0x00528BB0)(ref this, key, cancel_moveto); // .text:00528BB0 ; void __thiscall CMotionInterp::SetHoldKey(CMotionInterp *this, HoldKey key, int cancel_moveto) .text:00528BB0 ?SetHoldKey@CMotionInterp@@QAEXW4HoldKey@@H@Z

        // CMotionInterp.Create:
        public static CMotionInterp* Create(CPhysicsObj* _physics_obj, CWeenieObject* _weenie_obj) => ((delegate* unmanaged[Cdecl]<CPhysicsObj*, CWeenieObject*, CMotionInterp*>)0x00528C00)(_physics_obj, _weenie_obj); // .text:00528C00 ; CMotionInterp *__cdecl CMotionInterp::Create(CPhysicsObj *_physics_obj, CWeenieObject *_weenie_obj) .text:00528C00 ?Create@CMotionInterp@@SAPAV1@PAVCPhysicsObj@@PAVCWeenieObject@@@Z

        // CMotionInterp.LeaveGround:
        public void LeaveGround() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, void>)0x00528B00)(ref this); // .text:00528B00 ; void __thiscall CMotionInterp::LeaveGround(CMotionInterp *this) .text:00528B00 ?LeaveGround@CMotionInterp@@QAEXXZ

        // CMotionInterp.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, void>)0x00527B40)(ref this); // .text:00527B40 ; void __thiscall CMotionInterp::Destroy(CMotionInterp *this) .text:00527B40 ?Destroy@CMotionInterp@@QAEXXZ

        // CMotionInterp.add_to_queue:
        public void add_to_queue(UInt32 context_id, UInt32 motion, UInt32 jump_error_code) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32, UInt32, UInt32, void>)0x00527B80)(ref this, context_id, motion, jump_error_code); // .text:00527B80 ; void __thiscall CMotionInterp::add_to_queue(CMotionInterp *this, unsigned int context_id, unsigned int motion, unsigned int jump_error_code) .text:00527B80 ?add_to_queue@CMotionInterp@@AAEXKKK@Z

        // CMotionInterp.apply_interpreted_movement:
        public void apply_interpreted_movement(int cancel_moveto, int disallow_jump) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, int, int, void>)0x00528600)(ref this, cancel_moveto, disallow_jump); // .text:00528600 ; void __thiscall CMotionInterp::apply_interpreted_movement(CMotionInterp *this, int cancel_moveto, int disallow_jump) .text:00528600 ?apply_interpreted_movement@CMotionInterp@@IAEXHH@Z

        // CMotionInterp.move_to_interpreted_state:
        public int move_to_interpreted_state(InterpretedMotionState* new_state) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, InterpretedMotionState*, int>)0x005289C0)(ref this, new_state); // .text:005289C0 ; int __thiscall CMotionInterp::move_to_interpreted_state(CMotionInterp *this, InterpretedMotionState *new_state) .text:005289C0 ?move_to_interpreted_state@CMotionInterp@@QAEHABVInterpretedMotionState@@@Z

        // CMotionInterp.enter_default_state:
        public void enter_default_state() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, void>)0x00528C80)(ref this); // .text:00528C80 ; void __thiscall CMotionInterp::enter_default_state(CMotionInterp *this) .text:00528C80 ?enter_default_state@CMotionInterp@@QAEXXZ

        // CMotionInterp.PerformMovement:
        public UInt32 PerformMovement(MovementStruct* mvs) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, MovementStruct*, UInt32>)0x00528E80)(ref this, mvs); // .text:00528E80 ; unsigned int __thiscall CMotionInterp::PerformMovement(CMotionInterp *this, MovementStruct *mvs) .text:00528E80 ?PerformMovement@CMotionInterp@@QAEKABVMovementStruct@@@Z

        // CMotionInterp.apply_run_to_command:
        public void apply_run_to_command(UInt32* motion, Single* speed) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32*, Single*, void>)0x00527BE0)(ref this, motion, speed); // .text:00527BE0 ; void __thiscall CMotionInterp::apply_run_to_command(CMotionInterp *this, unsigned int *motion, float *speed) .text:00527BE0 ?apply_run_to_command@CMotionInterp@@IBEXAAKAAM@Z

        // CMotionInterp.get_max_speed:
        public Single get_max_speed() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, Single>)0x00527CB0)(ref this); // .text:00527CB0 ; float __thiscall CMotionInterp::get_max_speed(CMotionInterp *this) .text:00527CB0 ?get_max_speed@CMotionInterp@@QBEMXZ

        // CMotionInterp.StopMotion:
        public UInt32 StopMotion(UInt32 motion, MovementParameters* _params) => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, UInt32, MovementParameters*, UInt32>)0x00528530)(ref this, motion, _params); // .text:00528530 ; unsigned int __thiscall CMotionInterp::StopMotion(CMotionInterp *this, unsigned int motion, MovementParameters *params) .text:00528530 ?StopMotion@CMotionInterp@@QAEKKABVMovementParameters@@@Z

        // CMotionInterp.ReportExhaustion:
        public void ReportExhaustion() => ((delegate* unmanaged[Thiscall]<ref CMotionInterp, void>)0x005288D0)(ref this); // .text:005288D0 ; void __thiscall CMotionInterp::ReportExhaustion(CMotionInterp *this) .text:005288D0 ?ReportExhaustion@CMotionInterp@@QAEXXZ
    }

    public unsafe struct ActionNode {
        // Struct:
        public LListData a0;
        public UInt32 action;
        public Single speed;
        public UInt32 stamp;
        public int autonomous;
        public override string ToString() => $"a0(LListData):{a0}, action:{action:X8}, speed:{speed:n5}, stamp:{stamp:X8}, autonomous(int):{autonomous}";
    }

    public unsafe struct JumpPack {
        // Struct:
        public PackObj a0;
        public Single extent;
        public AC1Legacy.Vector3 velocity;
        public Position position;
        public UInt16 instance_timestamp;
        public UInt16 server_control_timestamp;
        public UInt16 teleport_timestamp;
        public UInt16 force_position_ts;
        public override string ToString() => $"a0(PackObj):{a0}, extent:{extent:n5}, velocity(AC1Legacy::Vector3):{velocity}, position(Position):{position}, instance_timestamp:{instance_timestamp:X4}, server_control_timestamp:{server_control_timestamp:X4}, teleport_timestamp:{teleport_timestamp:X4}, force_position_ts:{force_position_ts:X4}";

        // Functions:

        // JumpPack.__Ctor:
        public void __Ctor(Single _extent, AC1Legacy.Vector3* _velocity, Position* _position, UInt16 _instance_timestamp, UInt16 _server_control_timestamp, UInt16 _teleport_timestamp, UInt16 _force_position_ts) => ((delegate* unmanaged[Thiscall]<ref JumpPack, Single, AC1Legacy.Vector3*, Position*, UInt16, UInt16, UInt16, UInt16, void>)0x00516C70)(ref this, _extent, _velocity, _position, _instance_timestamp, _server_control_timestamp, _teleport_timestamp, _force_position_ts); // .text:00516C70 ; void __thiscall JumpPack::JumpPack(JumpPack *this, float _extent, AC1Legacy::Vector3 *_velocity, Position *_position, unsigned __int16 _instance_timestamp, unsigned __int16 _server_control_timestamp, unsigned __int16 _teleport_timestamp, unsigned __int16 _force_position_ts) .text:00516C70 ??0JumpPack@@QAE@MABVVector3@AC1Legacy@@ABVPosition@@GGGG@Z

        // JumpPack.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref JumpPack, void**, UInt32, UInt32>)0x00516D10)(ref this, addr, size); // .text:00516D10 ; unsigned int __thiscall JumpPack::Pack(JumpPack *this, void **addr, unsigned int size) .text:00516D10 ?Pack@JumpPack@@UAEIAAPAXI@Z

        // JumpPack.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref JumpPack, void**, UInt32, int>)0x00516DF0)(ref this, addr, size); // .text:00516DF0 ; int __thiscall JumpPack::UnPack(JumpPack *this, void **addr, unsigned int size) .text:00516DF0 ?UnPack@JumpPack@@UAEHAAPAXI@Z
    }

    public unsafe struct MoveToStatePack {
        // Struct:
        public PackObj PackObj;
        public RawMotionState raw_motion_state;
        public Position position;
        public Int32 contact;
        public Int32 longjump_mode;
        public UInt16 instance_timestamp;
        public UInt16 server_control_timestamp;
        public UInt16 teleport_timestamp;
        public UInt16 force_position_ts;
        public override string ToString() => $"PackObj(PackObj):{PackObj}, raw_motion_state(RawMotionState):{raw_motion_state}, position(Position):{position}, contact:{contact}, longjump_mode:{longjump_mode}, instance_timestamp:{instance_timestamp:X4}, server_control_timestamp:{server_control_timestamp:X4}, teleport_timestamp:{teleport_timestamp:X4}, force_position_ts:{force_position_ts:X4}";


        // Functions:

        // MoveToStatePack.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<MoveToStatePack*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<MoveToStatePack*, UInt32, void*>)0x00517AC0; // .text:00516FC0 ; void *__thiscall MoveToStatePack::`vector deleting destructor'(MoveToStatePack *this, UInt32) .text:00516FC0 ??_EMoveToStatePack@@UAEPAXI@Z

        // MoveToStatePack.__Ctor:
        public static delegate* unmanaged[Thiscall]<MoveToStatePack*, RawMotionState*, Position*, Int32, Int32, UInt16, UInt16, UInt16, UInt16> __Ctor = (delegate* unmanaged[Thiscall]<MoveToStatePack*, RawMotionState*, Position*, Int32, Int32, UInt16, UInt16, UInt16, UInt16>)0x00517AF0; // .text:00516FF0 ; void __thiscall MoveToStatePack::MoveToStatePack(MoveToStatePack *this, RawMotionState *_raw_motion_state, Position *_position, Int32 _contact, Int32 _longjump_mode, U__Int3216 _instance_timestamp, U__Int3216 _server_control_timestamp, U__Int3216 _teleport_timestamp, U__Int3216 _force_position_ts) .text:00516FF0 ??0MoveToStatePack@@QAE@ABVRawMotionState@@ABVPosition@@HHGGGG@Z

        // MoveToStatePack.pack_size:
        public static delegate* unmanaged[Thiscall]<MoveToStatePack*, UInt32> pack_size = (delegate* unmanaged[Thiscall]<MoveToStatePack*, UInt32>)0x005173A0; // .text:005168A0 ; UInt32 __thiscall MoveToStatePack::pack_size(MoveToStatePack *this) .text:005168A0 ?pack_size@MoveToStatePack@@QAEIXZ

        // MoveToStatePack.Pack:
        public static delegate* unmanaged[Thiscall]<MoveToStatePack*, void**, UInt32, UInt32> Pack = (delegate* unmanaged[Thiscall]<MoveToStatePack*, void**, UInt32, UInt32>)0x005173F0; // .text:005168F0 ; UInt32 __thiscall MoveToStatePack::Pack(MoveToStatePack *this, void **addr, UInt32 size) .text:005168F0 ?Pack@MoveToStatePack@@UAEIAAPAXI@Z

        // MoveToStatePack.UnPack:
        public static delegate* unmanaged[Thiscall]<MoveToStatePack*, void**, UInt32, Int32> UnPack = (delegate* unmanaged[Thiscall]<MoveToStatePack*, void**, UInt32, Int32>)0x005174B0; // .text:005169B0 ; Int32 __thiscall MoveToStatePack::UnPack(MoveToStatePack *this, void **addr, UInt32 size) .text:005169B0 ?UnPack@MoveToStatePack@@UAEHAAPAXI@Z
    }
    public unsafe struct TurnToEventPack {
        // Struct:
        public PackObj a0;
        public Single absolute_degrees;
        public int run;
        public override string ToString() => $"a0(PackObj):{a0}, absolute_degrees:{absolute_degrees:n5}, run(int):{run}";
    }
    public unsafe struct AutonomousPositionPack {
        // Struct:
        public PackObj a0;
        public Position position;
        public int contact;
        public UInt16 instance_timestamp;
        public UInt16 server_control_timestamp;
        public UInt16 teleport_timestamp;
        public UInt16 force_position_ts;
        public override string ToString() => $"a0(PackObj):{a0}, position(Position):{position}, contact(int):{contact}, instance_timestamp:{instance_timestamp:X4}, server_control_timestamp:{server_control_timestamp:X4}, teleport_timestamp:{teleport_timestamp:X4}, force_position_ts:{force_position_ts:X4}";

        // Functions:

        // AutonomousPositionPack.__Ctor:
        public void __Ctor(Position* _position, int _contact, UInt16 _instance_timestamp, UInt16 _server_control_timestamp, UInt16 _teleport_timestamp, UInt16 _force_position_ts) => ((delegate* unmanaged[Thiscall]<ref AutonomousPositionPack, Position*, int, UInt16, UInt16, UInt16, UInt16, void>)0x00516A70)(ref this, _position, _contact, _instance_timestamp, _server_control_timestamp, _teleport_timestamp, _force_position_ts); // .text:00516A70 ; void __thiscall AutonomousPositionPack::AutonomousPositionPack(AutonomousPositionPack *this, Position *_position, int _contact, unsigned __int16 _instance_timestamp, unsigned __int16 _server_control_timestamp, unsigned __int16 _teleport_timestamp, unsigned __int16 _force_position_ts) .text:00516A70 ??0AutonomousPositionPack@@QAE@ABVPosition@@HGGGG@Z

        // AutonomousPositionPack.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AutonomousPositionPack, void**, UInt32, UInt32>)0x00516AF0)(ref this, addr, size); // .text:00516AF0 ; unsigned int __thiscall AutonomousPositionPack::Pack(AutonomousPositionPack *this, void **addr, unsigned int size) .text:00516AF0 ?Pack@AutonomousPositionPack@@UAEIAAPAXI@Z

        // AutonomousPositionPack.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AutonomousPositionPack, void**, UInt32, int>)0x00516BA0)(ref this, addr, size); // .text:00516BA0 ; int __thiscall AutonomousPositionPack::UnPack(AutonomousPositionPack *this, void **addr, unsigned int size) .text:00516BA0 ?UnPack@AutonomousPositionPack@@UAEHAAPAXI@Z
    }

    public unsafe struct MotionTableManager {
        // Struct:
        public CPhysicsObj* physics_obj;
        public CMotionTable* table;
        public MotionState state;
        public int animation_counter;
        public DLList<PTR<MotionTableManager.AnimNode>> pending_animations;
        public override string ToString() => $"physics_obj:->(CPhysicsObj*)0x{(int)physics_obj:X8}, table:->(CMotionTable*)0x{(int)table:X8}, state(MotionState):{state}, animation_counter(int):{animation_counter}, pending_animations(DLList<MotionTableManager.AnimNode>):{pending_animations}";
        public unsafe struct AnimNode {
            public DLListData a0;
            public UInt32 motion;
            public UInt32 num_anims;
            public override string ToString() => $"a0(DLListData):{a0}, motion:{motion:X8}, num_anims:{num_anims:X8}";
        }

        // Functions:

        // MotionTableManager.Create:
        public static MotionTableManager* Create(UInt32 mtable_id) => ((delegate* unmanaged[Cdecl]<UInt32, MotionTableManager*>)0x0051C780)(mtable_id); // .text:0051BC50 ; MotionTableManager *__cdecl MotionTableManager::Create(IDClass<_tagDataID,32,0> mtable_id) .text:0051BC50 ?Create@MotionTableManager@@SAPAV1@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // MotionTableManager.truncate_animation_list:
        public void truncate_animation_list(MotionTableManager.AnimNode* node, CSequence* seq) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, MotionTableManager.AnimNode*, CSequence*, void>)0x0051C7D0)(ref this, node, seq); // .text:0051BCA0 ; void __thiscall MotionTableManager::truncate_animation_list(MotionTableManager *this, MotionTableManager::AnimNode *node, CSequence *seq) .text:0051BCA0 ?truncate_animation_list@MotionTableManager@@AAEXPBVAnimNode@1@AAVCSequence@@@Z

        // MotionTableManager.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, void>)0x0051C990)(ref this); // .text:0051BE90 ; void __thiscall MotionTableManager::Destroy(MotionTableManager *this) .text:0051BE90 ?Destroy@MotionTableManager@@AAEXXZ

        // MotionTableManager.GetMotionTableID:
        public UInt32* GetMotionTableID(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, UInt32*, UInt32*>)0x0051C740)(ref this, result); // .text:0051BC10 ; IDClass<_tagDataID,32,0> *__thiscall MotionTableManager::GetMotionTableID(MotionTableManager *this, IDClass<_tagDataID,32,0> *result) .text:0051BC10 ?GetMotionTableID@MotionTableManager@@QBE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ

        // MotionTableManager.SetMotionTableID:
        public int SetMotionTableID(UInt32 mtable_id) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, UInt32, int>)0x0051C700)(ref this, mtable_id); // .text:0051BBD0 ; int __thiscall MotionTableManager::SetMotionTableID(MotionTableManager *this, IDClass<_tagDataID,32,0> mtable_id) .text:0051BBD0 ?SetMotionTableID@MotionTableManager@@QAEHV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // MotionTableManager.HandleEnterWorld:
        // public void HandleEnterWorld(CSequence* seq) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, CSequence*, void>)0xDEADBEEF)(ref this, seq); // .text:0051BDD0 ; void __thiscall MotionTableManager::HandleEnterWorld(MotionTableManager *this, CSequence *seq) .text:0051BDD0 ?HandleEnterWorld@MotionTableManager@@QAEXAAVCSequence@@@Z

        // MotionTableManager.remove_redundant_links:
        public void remove_redundant_links(CSequence* seq) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, CSequence*, void>)0x0051CA20)(ref this, seq); // .text:0051BF20 ; void __thiscall MotionTableManager::remove_redundant_links(MotionTableManager *this, CSequence *seq) .text:0051BF20 ?remove_redundant_links@MotionTableManager@@AAEXAAVCSequence@@@Z

        // MotionTableManager.add_to_queue:
        public void add_to_queue(UInt32 motion, UInt32 num_anims, CSequence* seq) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, UInt32, UInt32, CSequence*, void>)0x0051CB10)(ref this, motion, num_anims, seq); // .text:0051BFE0 ; void __thiscall MotionTableManager::add_to_queue(MotionTableManager *this, unsigned int motion, unsigned int num_anims, CSequence *seq) .text:0051BFE0 ?add_to_queue@MotionTableManager@@AAEXKKAAVCSequence@@@Z

        // MotionTableManager.UseTime:
        // (ERR) .text:0051CB00 ; public: void __thiscall MotionTableManager::UseTime(void) .text:0051CB00 ?UseTime@MotionTableManager@@QAEXXZ

        // MotionTableManager.AnimationDone:
        public void AnimationDone(int success) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, int, void>)0x0051C810)(ref this, success); // .text:0051BCE0 ; void __thiscall MotionTableManager::AnimationDone(MotionTableManager *this, int success) .text:0051BCE0 ?AnimationDone@MotionTableManager@@QAEXH@Z

        // MotionTableManager.HandleExitWorld:
        public void HandleExitWorld(CSequence* seq) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, CSequence*, void>)0x0051C8D0)(ref this, seq); // .text:0051BDA0 ; void __thiscall MotionTableManager::HandleExitWorld(MotionTableManager *this, CSequence *seq) .text:0051BDA0 ?HandleExitWorld@MotionTableManager@@QAEXAAVCSequence@@@Z

        // MotionTableManager.CheckForCompletedMotions:
        public void CheckForCompletedMotions() => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, void>)0x0051C900)(ref this); // .text:0051BE00 ; void __thiscall MotionTableManager::CheckForCompletedMotions(MotionTableManager *this) .text:0051BE00 ?CheckForCompletedMotions@MotionTableManager@@QAEXXZ

        // MotionTableManager.initialize_state:
        public void initialize_state(CSequence* seq) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, CSequence*, void>)0x0051CB60)(ref this, seq); // .text:0051C030 ; void __thiscall MotionTableManager::initialize_state(MotionTableManager *this, CSequence *seq) .text:0051C030 ?initialize_state@MotionTableManager@@QAEXAAVCSequence@@@Z

        // MotionTableManager.PerformMovement:
        public UInt32 PerformMovement(MovementStruct* ms, CSequence* seq) => ((delegate* unmanaged[Thiscall]<ref MotionTableManager, MovementStruct*, CSequence*, UInt32>)0x0051CBE0)(ref this, ms, seq); // .text:0051C0B0 ; unsigned int __thiscall MotionTableManager::PerformMovement(MotionTableManager *this, MovementStruct *ms, CSequence *seq) .text:0051C0B0 ?PerformMovement@MotionTableManager@@QAEKABVMovementStruct@@AAVCSequence@@@Z
    }
    public unsafe struct CMotionTable {
        // Struct:
        public SerializeUsingPackDBObj a0;
        public LongNIValHash<UInt32> style_defaults;
        public LongHash<MotionData> cycles;
        public LongHash<MotionData> modifiers;
        public LongNIValHash<PTR<LongHash<MotionData>>> links;
        public UInt32 default_style;
        public override string ToString() => $"a0(SerializeUsingPackDBObj):{a0}, style_defaults(LongNIValHash<UInt32>):{style_defaults}, cycles(LongHash<MotionData>):{cycles}, modifiers(LongHash<MotionData>):{modifiers}, links(LongNIValHash<LongHash<MotionData>*>):{links}, default_style:{default_style:X8}";

        // Functions:

        // CMotionTable.is_allowed:
        public int is_allowed(UInt32 motion, MotionData* mdata, MotionState* state) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, UInt32, MotionData*, MotionState*, int>)0x00523260)(ref this, motion, mdata, state); // .text:005226C0 ; int __thiscall CMotionTable::is_allowed(CMotionTable *this, unsigned int motion, MotionData *mdata, MotionState *state) .text:005226C0 ?is_allowed@CMotionTable@@ABEHKPBVMotionData@@ABVMotionState@@@Z

        // CMotionTable.get_link:
        public MotionData* get_link(UInt32 style, UInt32 substate, Single substate_speed, UInt32 motion, Single speed) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, UInt32, UInt32, Single, UInt32, Single, MotionData*>)0x005232B0)(ref this, style, substate, substate_speed, motion, speed); // .text:00522710 ; MotionData *__thiscall CMotionTable::get_link(CMotionTable *this, unsigned int style, unsigned int substate, float substate_speed, unsigned int motion, float speed) .text:00522710 ?get_link@CMotionTable@@ABEPAVMotionData@@KKMKM@Z

        // CMotionTable.GetObjectSequence:
        public int GetObjectSequence(UInt32 motion, MotionState* curr_state, CSequence* sequence, Single speed_mod, UInt32* num_anims, int stop_modifiers) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, UInt32, MotionState*, CSequence*, Single, UInt32*, int, int>)0x00523400)(ref this, motion, curr_state, sequence, speed_mod, num_anims, stop_modifiers); // .text:00522860 ; int __thiscall CMotionTable::GetObjectSequence(CMotionTable *this, unsigned int motion, MotionState *curr_state, CSequence *sequence, float speed_mod, unsigned int *num_anims, int stop_modifiers) .text:00522860 ?GetObjectSequence@CMotionTable@@QBEHKAAVMotionState@@AAVCSequence@@MAAKH@Z

        // CMotionTable.StopSequenceMotion:
        public int StopSequenceMotion(UInt32 motion, Single speed, MotionState* curr_state, CSequence* sequence, UInt32* num_anims) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, UInt32, Single, MotionState*, CSequence*, UInt32*, int>)0x00523B60)(ref this, motion, speed, curr_state, sequence, num_anims); // .text:00522FC0 ; int __thiscall CMotionTable::StopSequenceMotion(CMotionTable *this, unsigned int motion, float speed, MotionState *curr_state, CSequence *sequence, unsigned int *num_anims) .text:00522FC0 ?StopSequenceMotion@CMotionTable@@QBEHKMAAVMotionState@@AAVCSequence@@AAK@Z

        // CMotionTable.StopObjectMotion:
        // (ERR) .text:00524AC0 ; public: int __thiscall CMotionTable::StopObjectMotion(unsigned long,float,class MotionState &,class CSequence &,unsigned long &)const .text:00524AC0 ?StopObjectMotion@CMotionTable@@QBEHKMAAVMotionState@@AAVCSequence@@AAK@Z

        // CMotionTable.StopObjectCompletely:
        public int StopObjectCompletely(MotionState* curr_state, CSequence* sequence, UInt32* num_anims) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, MotionState*, CSequence*, UInt32*, int>)0x00524AD0)(ref this, curr_state, sequence, num_anims); // .text:00523ED0 ; int __thiscall CMotionTable::StopObjectCompletely(CMotionTable *this, MotionState *curr_state, CSequence *sequence, unsigned int *num_anims) .text:00523ED0 ?StopObjectCompletely@CMotionTable@@QBEHAAVMotionState@@AAVCSequence@@AAK@Z

        // CMotionTable.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CMotionTable, void>)0xDEADBEEF)(ref this); // .text:004F94E0 ; void __thiscall CMotionTable::CMotionTable(CMotionTable *this) .text:004F94E0 ??0CMotionTable@@QAE@XZ

        // CMotionTable.SetDefaultState:
        public int SetDefaultState(MotionState* state, CSequence* sequence, UInt32* num_anims) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, MotionState*, CSequence*, UInt32*, int>)0x00523C40)(ref this, state, sequence, num_anims); // .text:005230A0 ; int __thiscall CMotionTable::SetDefaultState(CMotionTable *this, MotionState *state, CSequence *sequence, unsigned int *num_anims) .text:005230A0 ?SetDefaultState@CMotionTable@@QBEHAAVMotionState@@AAVCSequence@@AAK@Z

        // CMotionTable.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, void**, UInt32, UInt32>)0x00523D20)(ref this, addr, size); // .text:00523180 ; unsigned int __thiscall CMotionTable::Pack(CMotionTable *this, void **addr, unsigned int size) .text:00523180 ?Pack@CMotionTable@@UAEIAAPAXI@Z

        // CMotionTable.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref CMotionTable, void>)0x00524970)(ref this); // .text:00523D70 ; void __thiscall CMotionTable::Destroy(CMotionTable *this) .text:00523D70 ?Destroy@CMotionTable@@EAEXXZ

        // CMotionTable.DoObjectMotion:
        public int DoObjectMotion(UInt32 motion, MotionState* curr_state, CSequence* sequence, Single speed_mod, UInt32* num_anims) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, UInt32, MotionState*, CSequence*, Single, UInt32*, int>)0x00524A90)(ref this, motion, curr_state, sequence, speed_mod, num_anims); // .text:00523E90 ; int __thiscall CMotionTable::DoObjectMotion(CMotionTable *this, unsigned int motion, MotionState *curr_state, CSequence *sequence, float speed_mod, unsigned int *num_anims) .text:00523E90 ?DoObjectMotion@CMotionTable@@QBEHKAAVMotionState@@AAVCSequence@@MAAK@Z

        // CMotionTable.Allocator:
        // public DBObj* Allocator() => ((delegate* unmanaged[Thiscall]<ref CMotionTable, DBObj*>)0xDEADBEEF)(ref this); // .text:004F96E0 ; DBObj *__thiscall CMotionTable::Allocator(CMotionTable *this) .text:004F96E0 ?Allocator@CMotionTable@@SAPAVDBObj@@XZ

        // CMotionTable.re_modify:
        public void re_modify(CSequence* sequence, MotionState* state) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, CSequence*, MotionState*, void>)0x00522E30)(ref this, sequence, state); // .text:005222E0 ; void __thiscall CMotionTable::re_modify(CMotionTable *this, CSequence *sequence, MotionState *state) .text:005222E0 ?re_modify@CMotionTable@@ABEXAAVCSequence@@AAVMotionState@@@Z

        // CMotionTable.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CMotionTable, void**, UInt32, int>)0x00524460)(ref this, addr, size); // .text:005238C0 ; int __thiscall CMotionTable::UnPack(CMotionTable *this, void **addr, unsigned int size) .text:005238C0 ?UnPack@CMotionTable@@UAEHAAPAXI@Z
    }


    public unsafe struct MotionState {
        // Struct:
        public UInt32 style;
        public UInt32 substate;
        public Single substate_mod;
        public MotionList* modifier_head;
        public MotionList* action_head;
        public MotionList* action_tail;
        public override string ToString() => $"style:{style:X8}, substate:{substate:X8}, substate_mod:{substate_mod:n5}, modifier_head:->(MotionList*)0x{(int)modifier_head:X8}, action_head:->(MotionList*)0x{(int)action_head:X8}, action_tail:->(MotionList*)0x{(int)action_tail:X8}";

        // Functions:

        // MotionState.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref MotionState, void>)0x00526EE0)(ref this); // .text:005262E0 ; void __thiscall MotionState::Destroy(MotionState *this) .text:005262E0 ?Destroy@MotionState@@QAEXXZ

        // MotionState.add_modifier:
        public int add_modifier(UInt32 modifier, Single speed_mod) => ((delegate* unmanaged[Thiscall]<ref MotionState, UInt32, Single, int>)0x00526F40)(ref this, modifier, speed_mod); // .text:00526340 ; int __thiscall MotionState::add_modifier(MotionState *this, unsigned int modifier, float speed_mod) .text:00526340 ?add_modifier@MotionState@@QAEHKM@Z

        // MotionState.add_action:
        public void add_action(UInt32 action, Single speed_mod) => ((delegate* unmanaged[Thiscall]<ref MotionState, UInt32, Single, void>)0x00526CA0)(ref this, action, speed_mod); // .text:005260A0 ; void __thiscall MotionState::add_action(MotionState *this, unsigned int action, float speed_mod) .text:005260A0 ?add_action@MotionState@@QAEXKM@Z

        // MotionState.clear_actions:
        public void clear_actions() => ((delegate* unmanaged[Thiscall]<ref MotionState, void>)0x00526CF0)(ref this); // .text:005260F0 ; void __thiscall MotionState::clear_actions(MotionState *this) .text:005260F0 ?clear_actions@MotionState@@QAEXXZ

        // MotionState.remove_modifier:
        public void remove_modifier(MotionList* curr, MotionList* prev) => ((delegate* unmanaged[Thiscall]<ref MotionState, MotionList*, MotionList*, void>)0x00526C40)(ref this, curr, prev); // .text:00526040 ; void __thiscall MotionState::remove_modifier(MotionState *this, MotionList *curr, MotionList *prev) .text:00526040 ?remove_modifier@MotionState@@QAEXPAVMotionList@@0@Z

        // MotionState.clear_modifiers:
        public void clear_modifiers() => ((delegate* unmanaged[Thiscall]<ref MotionState, void>)0x00526C70)(ref this); // .text:00526070 ; void __thiscall MotionState::clear_modifiers(MotionState *this) .text:00526070 ?clear_modifiers@MotionState@@QAEXXZ

        // MotionState.remove_action_head:
        public UInt32 remove_action_head() => ((delegate* unmanaged[Thiscall]<ref MotionState, UInt32>)0x00526D20)(ref this); // .text:00526120 ; unsigned int __thiscall MotionState::remove_action_head(MotionState *this) .text:00526120 ?remove_action_head@MotionState@@QAEKXZ

        // MotionState.copy:
        public void copy(MotionState* s) => ((delegate* unmanaged[Thiscall]<ref MotionState, MotionState*, void>)0x00526DD0)(ref this, s); // .text:005261D0 ; void __thiscall MotionState::copy(MotionState *this, MotionState *s) .text:005261D0 ?copy@MotionState@@AAEXABV1@@Z

        // MotionState.__Ctor:
        public void __Ctor(MotionState* s) => ((delegate* unmanaged[Thiscall]<ref MotionState, MotionState*, void>)0x00527390)(ref this, s); // .text:00526790 ; void __thiscall MotionState::MotionState(MotionState *this, MotionState *s) .text:00526790 ??0MotionState@@QAE@ABV0@@Z

        // MotionState.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref MotionState, void>)0x00526BD0)(ref this); // .text:00525FD0 ; void __thiscall MotionState::MotionState(MotionState *this) .text:00525FD0 ??0MotionState@@QAE@XZ

        // MotionState.add_modifier_no_check:
        public void add_modifier_no_check(UInt32 modifier, Single speed_mod) => ((delegate* unmanaged[Thiscall]<ref MotionState, UInt32, Single, void>)0x00526BF0)(ref this, modifier, speed_mod); // .text:00525FF0 ; void __thiscall MotionState::add_modifier_no_check(MotionState *this, unsigned int modifier, float speed_mod) .text:00525FF0 ?add_modifier_no_check@MotionState@@QAEXKM@Z
    }
    public unsafe struct MotionList {
        // Struct:
        public UInt32 motion;
        public Single speed_mod;
        public MotionList* next;
        public override string ToString() => $"motion:{motion:X8}, speed_mod:{speed_mod:n5}, next:->(MotionList*)0x{(int)next:X8}";
    }
    public unsafe struct ACCmdInterp {
        // Struct:
        public CommandInterpreter a0;
        public gmNoticeHandler a1;
        public HashTable<UInt32, UInt32> m_hashEmoteInputActionsToCommands;
        public override string ToString() => $"a0(CommandInterpreter):{a0}, a1(gmNoticeHandler):{a1}, m_hashEmoteInputActionsToCommands(HashTable<UInt32,UInt32,0>):{m_hashEmoteInputActionsToCommands}";

        // Functions:

        // ACCmdInterp.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, void>)0x0058C960)(ref this); // .text:0058BB30 ; void __thiscall ACCmdInterp::ACCmdInterp(ACCmdInterp *this) .text:0058BB30 ??0ACCmdInterp@@QAE@XZ

        // ACCmdInterp.CommenceJump:
        public void CommenceJump() => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, void>)0x0058BFD0)(ref this); // .text:0058B1A0 ; void __thiscall ACCmdInterp::CommenceJump(ACCmdInterp *this) .text:0058B1A0 ?CommenceJump@ACCmdInterp@@MAEXXZ

        // ACCmdInterp.DoJump:
        public void DoJump(Byte autonomous) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, Byte, void>)0x0058BFF0)(ref this, autonomous); // .text:0058B1C0 ; void __thiscall ACCmdInterp::DoJump(ACCmdInterp *this, bool autonomous) .text:0058B1C0 ?DoJump@ACCmdInterp@@MAEXN@Z

        // ACCmdInterp.FinishJump:
        public void FinishJump() => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, void>)0x0058C000)(ref this); // .text:0058B1D0 ; void __thiscall ACCmdInterp::FinishJump(ACCmdInterp *this) .text:0058B1D0 ?FinishJump@ACCmdInterp@@UAEXXZ

        // ACCmdInterp.HandleNewForwardMovement:
        public void HandleNewForwardMovement() => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, void>)0x0058C020)(ref this); // .text:0058B1F0 ; void __thiscall ACCmdInterp::HandleNewForwardMovement(ACCmdInterp *this) .text:0058B1F0 ?HandleNewForwardMovement@ACCmdInterp@@AEXXZ

        // ACCmdInterp.InitializeEmoteInputActionHash:
        public void InitializeEmoteInputActionHash() => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, void>)0x0058C340)(ref this); // .text:0058B510 ; void __thiscall ACCmdInterp::InitializeEmoteInputActionHash(ACCmdInterp *this) .text:0058B510 ?InitializeEmoteInputActionash@ACCmdInterp@@IAEXXZ

        // ACCmdInterp.OnAction:
        public Byte OnAction(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, InputEvent*, Byte>)0x0058C1A0)(ref this, i_evt); // .text:0058B370 ; bool __thiscall ACCmdInterp::OnAction(ACCmdInterp *this, InputEvent *i_evt) .text:0058B370 ?OnAction@ACCmdnterp@@MAE_NABVInputEvent@@@Z

        // ACCmdInterp.RecvNotice_PlayerOptionChanged:
        public void RecvNotice_PlayerOptionChanged(PlayerOption i_eOption) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, PlayerOption, void>)0x0058C100)(ref this, i_eOption); // .text:0058B2D0 ; void __thiscall ACCmdInterp::RecvNotice_PlayerOptionChanged(ACCmdInterp *tis, PlayerOption i_eOption) .text:0058B2D0 ?RecvNotice_PlayerOptionChanged@ACCmdInterp@@MAEXW4PlayerOption@@@Z

        // ACCmdInterp.SendAutonomousPositionEvent:
        public int SendAutonomousPositionEvent(AutonomousPositionPack* app) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, AutonomousPositionPack*, int>)0x0058C0C0)(ref this, app); // .text:0058B290 ; int __thiscall ACCmdInterp::SendAutonomousPositionEvent(ACCmdInterp *his, AutonomousPositionPack *app) .text:0058B290 ?SendAutonomousPositionEvent@ACCmdInterp@@MAEHAAVAutonomousPositionPack@@@Z

        // ACCmdInterp.SendAutonomyLevelEvent:
        public int SendAutonomyLevelEvent(UInt32 level) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, UInt32, int>)0x0058C040)(ref this, level); // .text:0058B210 ; int __thiscall ACCmdInterp::SendAutonomyLevelEvent(ACCmdInterp *this, unsigned int level) .text:0058B210?SendAutonomyLevelEvent@ACCmdInterp@@MAEHK@Z

        // ACCmdInterp.SendDoMovementEvent:
        public int SendDoMovementEvent(UInt32 motion, Single speed, HoldKey hold_key) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, UInt32, Single, HoldKey, int>)0x0058C060)(ref this, motion, speed, hold_key); // .text:0058B230 ; int __thiscall ACCmdInterp::SendDoMovemntEvent(ACCmdInterp *this, unsigned int motion, float speed, HoldKey hold_key) .text:0058B230 ?SendDoMovementEvent@ACCmdInterp@@MAEHKMW4HoldKey@@@Z

        // ACCmdInterp.SendMoveToStateEvent:
        public int SendMoveToStateEvent(MoveToStatePack* mtsp) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, MoveToStatePack*, int>)0x0058C0A0)(ref this, mtsp); // .text:0058B270 ; int __thiscall ACCmdInterp::SendMoveToStateEvent(ACCmdInterp *this, MoveToStatePack *mts) .text:0058B270 ?SendMoveToStateEvent@ACCmdInterp@@MAEHAAVMoveToStatePack@@@Z

        // ACCmdInterp.SendStopMovementEvent:
        public int SendStopMovementEvent(UInt32 motion, HoldKey hold_key) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, UInt32, HoldKey, int>)0x0058C080)(ref this, motion, hold_key); // .text:0058B250 ; int __thiscall ACCmdInterp::SendStopMovementEvent(ACCmdInterp *thi, unsigned int motion, HoldKey hold_key) .text:0058B250 ?SendStopMovementEvent@ACCmdInterp@@MAEHKW4HoldKey@@@Z

        // ACCmdInterp.SendTurnToEvent:
        public int SendTurnToEvent(TurnToEventPack* tep) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, TurnToEventPack*, int>)0x0058C0E0)(ref this, tep); // .text:0058B2B0 ; int __thiscall ACCmdInterp::SendTurnToEvent(ACCmdInterp *this, TurnToEventPack *tep) .text:00582B0 ?SendTurnToEvent@ACCmdInterp@@MAEHAAVTurnToEventPack@@@Z

        // ACCmdInterp.SetMotion:
        public void SetMotion(UInt32 motion, bool fOn) => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, UInt32, bool, void>)0x0058C140)(ref this, motion, fOn); // .text:0058C140 ; void __thiscall ACCmdInterp::SetMotion(ACCmdInterp *this, unsigned int motion, bool fOn) .tet:0058C140 ?SetMotion@ACCmdInterp@@IAEXK_N@Z

        // ACCmdInterp.TakeControlFromServer:
        public void TakeControlFromServer() => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, void>)0x0058BF90)(ref this); // .text:0058B160 ; void __thiscall ACCmdInterp::TakeControlFromServer(ACCmdInterp *this) .text:0058B160 ?TakeControlFromServer@ACCmdInterp@@UAEXXZ

        // ACCmdInterp.UITogglesRun:
        public int UITogglesRun() => ((delegate* unmanaged[Thiscall]<ref ACCmdInterp, int>)0x0058BFB0)(ref this); // .text:0058B180 ; int __thiscall ACCmdInterp::UITogglesRun(ACCmdInterp *this) .text:0058B180 ?UITogglesRun@ACCmdInterp@@MBEHXZ
    }




}