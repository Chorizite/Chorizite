using System;
using System.Collections.Generic;
using System.Text;

namespace Chorizite.Common.Enums {
    [Flags]
    public enum PhysicsDescriptionFlag {
        None = 0,
        CSetup = 1,
        MTable = 2,
        Velocity = 4,
        Acceleration = 8,
        Omega = 0x10,
        Parent = 0x20,
        Children = 0x40,
        ObjScale = 0x80,
        Friction = 0x100,
        Elasticity = 0x200,
        Timestamps = 0x400,
        STable = 0x800,
        PeTable = 0x1000,
        DefaultScript = 0x2000,
        DefaultScriptIntensity = 0x4000,
        Position = 0x8000,
        Movement = 0x10000,
        AnimationFrame = 0x20000,
        Translucency = 0x40000
    }
}
