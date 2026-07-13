using System;
using System.Drawing;

namespace MatrixScreensaver
{
    internal static class Settings
    {
        public const int AlphaLevels = 16;
        public const int MinCharsCount = 14;
        public const int MaxCharsCount = 26;
        public static readonly Color MatrixColor;
        public static readonly Color MatrixGlowColor;
        public static readonly Font Font;
        public static readonly int FallSpeed;
        public static int CharWidth;
        public static int CharHeight;

        static Settings()
        {
            CharWidth = Properties.Settings.Default.CharWidth;
            CharHeight = CharWidth + 4;
            Font = new Font("Consolas", CharWidth - 2, FontStyle.Bold);
            FallSpeed = Properties.Settings.Default.FallSpeed;
            MatrixColor = Properties.Settings.Default.GlyphColor;
            // make glow color a little lighter
            MatrixGlowColor = Color.FromArgb(
                Math.Min(255, (int)(MatrixColor.R * 1.2)),
                Math.Min(255, (int)(MatrixColor.G * 1.2)),
                Math.Min(255, (int)(MatrixColor.B * 1.2))
            );
        }
    }
}
