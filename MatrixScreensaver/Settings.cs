using System;
using System.Drawing;

namespace MatrixScreensaver
{
    internal static class Settings
    {
        public const int AlphaLevels = 16;
        public const int MinCharsCount = 14;
        public const int MaxCharsCount = 26;
        public static readonly Color GlyphColor;
        public static readonly Color GlyphGlowColor;
        public static readonly Font Font;
        public static readonly int FallSpeed;
        public static readonly int GlowOffset;
        public static int CharWidth;
        public static int CharHeight;

        static Settings()
        {
            CharWidth = Properties.Settings.Default.CharWidth;
            CharHeight = CharWidth + 4;
            Font = new Font("Consolas", CharWidth - 2, FontStyle.Bold);
            FallSpeed = Properties.Settings.Default.FallSpeed;
            GlowOffset = Properties.Settings.Default.GlowOffset;
            GlyphColor = Properties.Settings.Default.GlyphColor;
            // make glow color a little lighter
            GlyphGlowColor = Color.FromArgb(
                Math.Min(255, (int)(GlyphColor.R * 1.2)),
                Math.Min(255, (int)(GlyphColor.G * 1.2)),
                Math.Min(255, (int)(GlyphColor.B * 1.2))
            );
        }
    }
}
