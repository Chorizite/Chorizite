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
    /// The PositionFlags value defines the fields present in the Position structure.
    /// </summary>
    [Flags]
    public enum PositionFlags : uint {
        /// <summary>
        /// velocity vector is present
        /// </summary>
        HasVelocity = 0x0001,

        /// <summary>
        /// placement id is present
        /// </summary>
        HasPlacementId = 0x0002,

        /// <summary>
        /// object is grounded
        /// </summary>
        IsGrounded = 0x0004,

        /// <summary>
        /// orientation quaternion has no w component
        /// </summary>
        OrientationHasNoW = 0x0008,

        /// <summary>
        /// orientation quaternion has no x component
        /// </summary>
        OrientationHasNoX = 0x0010,

        /// <summary>
        /// orientation quaternion has no y component
        /// </summary>
        OrientationHasNoY = 0x0020,

        /// <summary>
        /// orientation quaternion has no z component
        /// </summary>
        OrientationHasNoZ = 0x0040,

    };
}
