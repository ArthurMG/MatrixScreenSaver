using System.Drawing;

namespace MatrixScreensaver
{
    internal static class Settings
    {
        public const int AlphaLevels = 16;
        public const int MinCharsCount = 14;
        public const int MaxCharsCount = 26;
        public static readonly Color MatrixColor = Color.FromArgb(36, 200, 89);
        public static readonly Color MatrixGlowColor = Color.FromArgb(20, 140, 20);
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
        }
    }
}
