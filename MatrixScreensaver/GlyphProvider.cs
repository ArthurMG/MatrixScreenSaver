using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace MatrixScreensaver
{
    internal class GlyphProvider
    {
        private static readonly char[] Chars =
            "ﾊ日ﾋｼﾂｳｰﾅﾐﾓﾆｻﾜｵﾘﾎﾏｴｷﾑﾃｹﾒｶﾕﾗｾﾈｽﾀﾇ012345678\"9Z*+:=.<>｜¦_".ToCharArray();

        private readonly Glyph[] glyphs = new Glyph[Chars.Length * (Settings.AlphaLevels + 1)];
        private readonly Dictionary<char, int> charToIdx = new Dictionary<char, int>();
        private Random rnd;

        public void Init(Random rnd)
        {
            this.rnd = rnd;

            for (int i = 0; i < Chars.Length; i++)
            {
                charToIdx.Add(Chars[i], i);
            }

            //creating chars for each opacity level
            //so we don't need to calculate this on a draw event
            for (int charIdx = 0; charIdx < Chars.Length; charIdx++)
            {
                var ch = Chars[charIdx];
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

        public Glyph GetRandomGlyphByLevel(int alphaLevel)
        {
            char ch = Chars[rnd.Next(Chars.Length)];
            return GetGlyphByLevel(ch, alphaLevel);
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
