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
    /// Flags that dictate what property tables are included with the ACBaseQuali
    /// </summary>
    [Flags]
    public enum ACBaseQualitiesFlags : uint {
        None = 0x0000,

        PropertyInt = 0x0001,

        PropertyBool = 0x0002,

        PropertyFloat = 0x0004,

        PropertyDataId = 0x0008,

        PropertyString = 0x0010,

        PropertyPosition = 0x0020,

        PropertyInstanceId = 0x0040,

        PropertyInt64 = 0x0080,

    };
}
