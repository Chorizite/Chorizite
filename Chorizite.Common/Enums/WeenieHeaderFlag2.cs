using System;
using System.Collections.Generic;
using System.Text;

namespace Chorizite.Common.Enums {
    [Flags]
    public enum WeenieHeaderFlag2 : uint {
        None = 0u,
        IconUnderlay = 1u,
        Cooldown = 2u,
        CooldownDuration = 4u,
        PetOwner = 8u
    }
}
