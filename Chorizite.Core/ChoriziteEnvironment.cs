using System;

namespace Chorizite.Core {
    [Flags]
    public enum ChoriziteEnvironment {
        Unknown = 0x00000000,
        Launcher = 0x00000001,
        Client = 0x00000002
    }
}