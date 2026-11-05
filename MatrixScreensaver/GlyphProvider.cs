using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MatrixScreensaver
{
    internal sealed class GlyphProvider
    {
        // One symbol per entry
        private static readonly string[] Symbols =
        {
            "*", "+", ".", "0", "1", "2", "3", "4", "5", "ﾜ",
            "6", "7", "8", "9", ":", "<", "=", ">", "Z", "_",
            "¦", "日", "｜", "ｰ", "ｳ", "ｴ", "ｵ", "ｶ", "ｷ", "ｹ",
            "ｻ", "ｼ", "ｽ", "ｾ", "ﾀ", "ﾂ", "ﾃ", "ﾅ", "ﾆ", "ﾇ",
            "ﾈ", "ﾊ", "ﾋ", "ﾎ", "ﾏ", "ﾐ", "ﾑ", "ﾒ", "ﾓ", "ﾕ",
            "ﾗ", "ﾘ",
        };

        private readonly Glyph[] glyphs = new Glyph[Symbols.Length * (Settings.AlphaLevels + 1)];
        private const int RandomNumbersAmount = 512; // must be power of 2
        private readonly int[] randomNumbers = new int[RandomNumbersAmount];
        private int randomNumberIdx = 0;

        public void Init(Random rnd)
        {
            //creating glyphs for each symbol and opacity level
            //so we don't need to calculate this on a draw event
            for (int symbolIdx = 0; symbolIdx < Symbols.Length; symbolIdx++)
            {
                var symbol = Symbols[symbolIdx];
                var glyphsPerSymbol = Settings.AlphaLevels + 1;
                var mainGlyphIndex = symbolIdx * glyphsPerSymbol;
                var firstGlyph = CreateGlyph(symbol, Constants.Opacity, mainGlyphIndex, Color.WhiteSmoke, Settings.GlyphGlowColor);
                glyphs[mainGlyphIndex] = firstGlyph;

                for (int alphaLevel = Constants.Opacity - Constants.AlphaStep, alphaIdx = 1; alphaLevel > 0; alphaLevel -= Constants.AlphaStep, alphaIdx++)
                {
                    var glyphNum = (symbolIdx * glyphsPerSymbol) + alphaIdx;
                    var glyph = CreateGlyph(symbol, alphaLevel, glyphNum, Settings.GlyphColor, Settings.GlyphGlowColor);
                    glyphs[glyphNum] = glyph;
                }
            }

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = rnd.Next(Symbols.Length);
            }
        }

        private Glyph CreateGlyph(string symbol, int alpha, int glyphNum, Color color, Color glowColor)
        {
            var bmp = new Bitmap(Settings.CharWidth, Settings.CharHeight, PixelFormat.Format32bppPArgb);
            using (var mainBrush = new SolidBrush(Color.FromArgb(alpha, color)))
            using (var glowBrush = new SolidBrush(Color.FromArgb(35, glowColor)))
            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawString(symbol, Settings.Font, mainBrush, new Point(0, 0));
                g.DrawString(symbol, Settings.Font, glowBrush, new Point(-Settings.GlowOffset, 0));
                g.DrawString(symbol, Settings.Font, glowBrush, new Point(Settings.GlowOffset, 0));
            }

            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
            var result = new Glyph(bmp, glyphNum);
            return result;
        }

        public Glyph GetRandomGlyphByLevel(int alphaLevel)
        {
            // increasing randomNumberIdx and reseting it to 0
            randomNumberIdx = (randomNumberIdx + 1) % RandomNumbersAmount;
            var mainGlyphIdx = (Settings.AlphaLevels + 1) * randomNumbers[randomNumberIdx];

            // computing the shift for a specific alpha level
            var glyphAlphaLevelShift = (Constants.Opacity - alphaLevel) / Constants.AlphaStep;
            return glyphs[mainGlyphIdx + glyphAlphaLevelShift];
        }

        public Glyph GetMoreTransparentGlyph(Glyph currentGlyph)
        {
            // never gonna be true currentGlyph.AlphaLevel <= MinAlphaLevel
            return glyphs[currentGlyph.GlyphNumber + 1];
        }
    }
}
