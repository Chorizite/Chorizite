using System;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Helper class for maths.
    /// </summary>
    public static class MathHelper {
        /// <summary>
        /// Represents the mathematical constant Pi (π, approximately 3.141592653589793).
        /// </summary>
        public const float Pi = (float)Math.PI;

        /// <summary>
        /// Represents Pi divided by 2 (π/2, approximately 1.5707963267948966).
        /// </summary>
        public const float PiOver2 = (float)(Math.PI / 2.0);

        /// <summary>
        /// Represents Pi divided by 4 (π/4, approximately 0.7853981633974483).
        /// </summary>
        public const float PiOver4 = (float)(Math.PI / 4.0);

        /// <summary>
        /// Represents 2 times Pi (2π, approximately 6.283185307179586).
        /// </summary>
        public const float TwoPi = (float)(Math.PI * 2.0);

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static float ToRadians(float degrees) {
            return degrees * (Pi / 180.0f);
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        public static float ToDegrees(float radians) {
            return radians * (180.0f / Pi);
        }

        /// <summary>
        /// Clamps a value to be within a specified range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value.</returns>
        public static float Clamp(float value, float min, float max) {
            return Math.Max(min, Math.Min(max, value));
        }

        /// <summary>
        /// Linearly interpolates between two values.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <param name="amount">The amount to interpolate (0.0 to 1.0).</param>
        /// <returns>The interpolated value.</returns>
        public static float Lerp(float value1, float value2, float amount) {
            return value1 + (value2 - value1) * Clamp(amount, 0.0f, 1.0f);
        }

        /// <summary>
        /// Wraps an angle to be within [0, 2π).
        /// </summary>
        /// <param name="angle">The angle in radians.</param>
        /// <returns>The wrapped angle in radians.</returns>
        public static float WrapAngle(float angle) {
            angle = (float)Math.IEEERemainder(angle, TwoPi);
            if (angle < 0.0f)
                angle += TwoPi;
            return angle;
        }
    }
}