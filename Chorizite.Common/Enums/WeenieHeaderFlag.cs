using System;
using System.Collections.Generic;
using System.Text;

namespace Chorizite.Common.Enums {
    [Flags]
    public enum WeenieHeaderFlag : uint {
        None = 0u,
        PluralName = 1u,
        ItemsCapacity = 2u,
        ContainersCapacity = 4u,
        Value = 8u,
        Usable = 0x10u,
        UseRadius = 0x20u,
        Monarch = 0x40u,
        UiEffects = 0x80u,
        AmmoType = 0x100u,
        CombatUse = 0x200u,
        Uses = 0x400u,
        MaxUses = 0x800u,
        StackSize = 0x1000u,
        MaxStackSize = 0x2000u,
        Container = 0x4000u,
        Wielder = 0x8000u,
        ValidEquipLocations = 0x10000u,
        CurrentlyWieldedLocation = 0x20000u,
        Coverage = 0x40000u,
        TargetType = 0x80000u,
        RadarBlipColor = 0x100000u,
        Burden = 0x200000u,
        Spell = 0x400000u,
        RadarBehavior = 0x800000u,
        Workmanship = 0x1000000u,
        Owner = 0x2000000u,
        HouseRestrictions = 0x4000000u,
        PhysicsScript = 0x8000000u,
        HookableOn = 0x10000000u,
        HookType = 0x20000000u,
        IconOverlay = 0x40000000u,
        MaterialType = 0x80000000u
    }
}
