using System;
using System.Collections.Generic;
using System.Text;

namespace Chorizite.Core {
    /// <summary>
    /// The environment Chorizite is running in
    /// </summary>
    [Flags]
    public enum ChoriziteEnvironment : uint {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0x00000000,

        /// <summary>
        /// The launcher
        /// </summary>
        Launcher = 0x00000001,

        /// <summary>
        /// The client
        /// </summary>
        Client = 0x00000002,

        /// <summary>
        /// The inspector
        /// </summary>
        Inspector = 0x00000004,

        /// <summary>
        /// The documentation generator
        /// </summary>
        DocGen = Launcher | Client
    }
}
