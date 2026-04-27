using System.Drawing;

namespace MatrixScreensaver
{
    internal static class Settings
    {
        public const int AlphaLevels = 16;

        public static int CharWidth = 18;
        public static int CharHeight = 22;
        public static Font Font = new Font("Consolas", CharWidth - 2, FontStyle.Bold);
        public static Color MatrixColor = Color.FromArgb(36, 200, 89);
        public static Color MatrixGlowColor = Color.FromArgb(20, 140, 20);

        public const int MinCharsCount = 14;
        public const int MaxCharsCount = 26;
    }
}
