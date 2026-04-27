using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace MatrixScreensaver
{
    internal class GlyphProvider
    {
        private readonly Glyph[] glyphs = new Glyph[Column.Chars.Length * (Settings.AlphaLevels + 1)];
        private readonly Dictionary<char, int> charToIdx = new Dictionary<char, int>();

        public void Init()
        {
            for (int i = 0; i < Column.Chars.Length; i++)
            {
                charToIdx.Add(Column.Chars[i], i);
            }

            //creating chars for each opacity level
            //so we don't need to calculate this on a draw event
            for (int charIdx = 0; charIdx < Column.Chars.Length; charIdx++)
            {
                var ch = Column.Chars[charIdx];
                var chShift = Settings.AlphaLevels + 1;
                var firstGlyph = CreateGlyph(ch, Constants.Opacity, Color.WhiteSmoke, Settings.MatrixGlowColor);
                glyphs[charIdx * chShift] = firstGlyph;

                for (int alphaLevel = Constants.Opacity - Constants.AlphaStep, alphaIdx = 1; alphaLevel > 0; alphaLevel -= Constants.AlphaStep, alphaIdx++)
                {
                    var glyph = CreateGlyph(ch, alphaLevel, Settings.MatrixColor, Settings.MatrixGlowColor);
                    glyphs[(charIdx * chShift) + alphaIdx] = glyph;
                }
            }
        }

        private Glyph CreateGlyph(char c, int alpha, Color color, Color glowColor)
        {
            var bmp = new Bitmap(Settings.CharWidth, Settings.CharHeight, PixelFormat.Format32bppPArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawString(c.ToString(), Settings.Font, new SolidBrush(Color.FromArgb(alpha, color)), new Point(0, 0));
                g.DrawString(c.ToString(), Settings.Font, new SolidBrush(Color.FromArgb(35, glowColor)), new Point(-3, 0));
                g.DrawString(c.ToString(), Settings.Font, new SolidBrush(Color.FromArgb(35, glowColor)), new Point(3, 0));
            }

            var result = new Glyph(bmp, c, alpha);
            return result;
        }

        public Glyph GetGlyphByLevel(char ch, int alphaLevel)
        {
            var charIdx = charToIdx[ch];

            int alphaIdx = (Constants.Opacity - alphaLevel) / Constants.AlphaStep;
            int glyphIdx = (charIdx * (Settings.AlphaLevels + 1)) + alphaIdx;
            var glyph = glyphs[glyphIdx];
            return glyph;
        }
    }
}
