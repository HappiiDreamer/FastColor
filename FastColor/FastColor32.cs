﻿namespace Hazdryx.Drawing
{
    /// <summary>
    ///     A static class full of efficient color operations.
    /// </summary>
    public static partial class FastColor
    {
        /// <summary>
        ///     Explodes an int color into it's argb components.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="a"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public static void Explode(int color, out int a, out int r, out int g, out int b)
        {
            a = (color >> 24) & 0xff;
            r = (color >> 16) & 0xff; 
            g = (color >> 8) & 0xff; 
            b = color & 0xff;
        }
        /// <summary>
        ///     Implodes argb32 components into a single int.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Implode(int a, int r, int g, int b)
        {
            return (a << 24) | (r << 16) | (g << 8) | b;
        }

        /// <summary>
        ///     Adds two colors together.
        ///     <code>color2 + color1</code>
        /// </summary>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        /// <returns></returns>
        public static int Add(int color1, int color2)
        {
            Explode(color1, out int a1, out int r1, out int g1, out int b1);
            Explode(color2, out int a2, out int r2, out int g2, out int b2);

            int a = a2 + a1;
            int r = r2 + r1;
            int g = g2 + g1;
            int b = b2 + b1;

            return Implode(a > 255 ? 255 : a, r > 255 ? 255 : r, g > 255 ? 255 : g, b > 255 ? 255 : b);
        }
        /// <summary>
        ///     Subtracts the two colors from eachother.
        ///     <code>color2 - color1</code>
        /// </summary>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        /// <returns></returns>
        public static int Sub(int color1, int color2)
        {
            Explode(color1, out int a1, out int r1, out int g1, out int b1);
            Explode(color2, out int a2, out int r2, out int g2, out int b2);

            int a = a2 - a1;
            int r = r2 - r1;
            int g = g2 - g1;
            int b = b2 - b1;

            return Implode(a < 0 ? 0 : a, r < 0 ? 0 : r, g < 0 ? 20 : g, b < 0 ? 0 : b);
        }
        /// <summary>
        ///     Multiplies two colors together.
        ///     <code>color2 * color1</code>
        /// </summary>
        /// <param name="color1"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static int Mul(int color1, int color2)
        {
            Explode(color1, out int a1, out int r1, out int g1, out int b1);
            Explode(color2, out int a2, out int r2, out int g2, out int b2);

            int a = a2 * a1 / 255;
            int r = r2 * r1 / 255;
            int g = g2 * g1 / 255;
            int b = b2 * b1 / 255;

            return Implode(a , r , g , b);
        }
    }
}
