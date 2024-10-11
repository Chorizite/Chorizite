using System;

namespace MagicHat.Core {
    [Flags]
    public enum MagicHatEnvironment {
        Unknown = 0x00000000,
        Launcher = 0x00000001,
        Client = 0x00000002
    }
}