using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Chorizite.Common.Enums {
    //
    // Summary:
    //     The AttributeID identifies a specific Character attribute.
    public enum AttributeId : uint {
        Undef,
        //
        // Summary:
        //     Strength Attribute
        Strength,
        //
        // Summary:
        //     Endurance Attribute
        Endurance,
        //
        // Summary:
        //     Quickness Attribute
        Quickness,
        //
        // Summary:
        //     Coordination Attribute
        Coordination,
        //
        // Summary:
        //     Focus Attribute
        Focus,
        //
        // Summary:
        //     Self Attribute
        Self
    }
}
