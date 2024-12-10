using System;

namespace Chorizite.Common.Enums {
    /// <summary>
    /// The type of the friend change event.
    /// </summary>
    [Flags]
    public enum FriendsUpdateType : uint {
        Full = 0x0000,

        Added = 0x0001,

        Removed = 0x0002,

        LoginChange = 0x0004,

    };
}
