namespace Chorizite.Common.Enums {
    /// <summary>
    /// Radar behavior
    /// </summary>
    public enum RadarBehavior : byte {
        Undefined = 0x00,

        ShowNever = 0x01,

        ShowMovement = 0x02,

        ShowAttacking = 0x03,

        ShowAlways = 0x04,

    };
}
