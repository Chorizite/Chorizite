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
    /// The ConfirmationType identifies the specific confirmation panel to be displayed.
    /// </summary>
    public enum ConfirmationType : uint {
        /// <summary>
        /// Swear Allegiance Request
        /// </summary>
        SwearAllegiance = 0x01,

        /// <summary>
        /// Alter Skill Confirmation Request
        /// </summary>
        AlterSkill = 0x02,

        /// <summary>
        /// Alter Attribute Confirmation Request
        /// </summary>
        AlterAttribute = 0x03,

        /// <summary>
        /// Fellowship Request
        /// </summary>
        Fellowship = 0x04,

        /// <summary>
        /// Craft Interaction Confirmation Request
        /// </summary>
        Craft = 0x05,

        /// <summary>
        /// Augmentation Confirmation Request
        /// </summary>
        Augmentation = 0x06,

        /// <summary>
        /// Yes/No Confirmation Request
        /// </summary>
        YesNo = 0x07,

    };
}
