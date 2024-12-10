//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;

namespace Chorizite.ACProtocol.Enums {
    /// <summary>
    /// The useablilty flags of the object
    /// </summary>
    [Flags]
    public enum Usable : uint {
        /// <summary>
        /// source not usable
        /// </summary>
        SourceUnusable = 0x00000001,

        /// <summary>
        /// source self
        /// </summary>
        SourceSelf = 0x00000002,

        /// <summary>
        /// source usable while wielded
        /// </summary>
        SourceWielded = 0x00000004,

        /// <summary>
        /// source usable while contained (owned by player)
        /// </summary>
        SourceContained = 0x00000008,

        /// <summary>
        /// source usable while viewed
        /// </summary>
        SourceViewed = 0x00000010,

        /// <summary>
        /// source usable while remote
        /// </summary>
        SourceRemote = 0x00000020,

        /// <summary>
        /// source don&#39;t approach
        /// </summary>
        SourceNoApproach = 0x00000040,

        /// <summary>
        /// source object self
        /// </summary>
        SourceObjectSelf = 0x00000080,

        /// <summary>
        /// target not usable
        /// </summary>
        TargetUnusable = 0x00010000,

        /// <summary>
        /// target self
        /// </summary>
        TargetSelf = 0x00020000,

        /// <summary>
        /// target usable while wielded
        /// </summary>
        TargetWielded = 0x00040000,

        /// <summary>
        /// target usable while contained (owned by player)
        /// </summary>
        TargetContained = 0x00080000,

        /// <summary>
        /// target usable while viewed
        /// </summary>
        TargetViewed = 0x00100000,

        /// <summary>
        /// target usable while remote
        /// </summary>
        TargetRemote = 0x00200000,

        /// <summary>
        /// target don&#39;t approach
        /// </summary>
        TargetNoApproach = 0x00400000,

        /// <summary>
        /// target object self
        /// </summary>
        TargetObjectSelf = 0x00800000,

    };
}
