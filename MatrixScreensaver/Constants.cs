namespace MatrixScreensaver
{
    internal static class Constants
    {
        public const int Opacity = 255;

        public const int AlphaStep = Opacity / Settings.AlphaLevels;
        public const int MinAlphaLevel = Opacity - (AlphaStep * Settings.AlphaLevels);
    }
}
