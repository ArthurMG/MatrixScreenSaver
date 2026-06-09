using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace MatrixScreensaver
{
    internal class Column
    {
        public static readonly char[] Chars =
            "ﾊ日ﾋｼﾂｳｰﾅﾐﾓﾆｻﾜｵﾘﾎﾏｴｷﾑﾃｹﾒｶﾕﾗｾﾈｽﾀﾇ012345678\"9Z*+:=.<>｜¦_".ToCharArray();

        private int X;
        private int Y;
        private readonly int moveSpeed;
        private int changeCharsSpeed;
        private readonly int screenHeight;
        private readonly int columnHeightPx;

        private readonly Random rand;
        private readonly Glyph[] glyphs;
        private readonly Bitmap columnBitmap;
        private readonly Graphics cg;

        private readonly GlyphProvider glyphProvider;

        public Column(int x,
            int startY,
            int length,
            Random rand,
            int screenHeight,
            GlyphProvider glyphProvider)
        {
            this.X = x;
            this.Y = startY;
            this.rand = rand;
            this.glyphProvider = glyphProvider;
            this.screenHeight = screenHeight;

            columnHeightPx = (length * Settings.CharHeight) + Settings.CharHeight;

            glyphs = new Glyph[length];
            // for bitmap height add additional emtpy black square to remove redraw artifacts
            columnBitmap = new Bitmap(
                Settings.CharWidth,
                columnHeightPx,
                PixelFormat.Format32bppPArgb);

            cg = Graphics.FromImage(columnBitmap);
            cg.CompositingMode = CompositingMode.SourceOver;
            cg.CompositingQuality = CompositingQuality.HighSpeed;
            cg.InterpolationMode = InterpolationMode.NearestNeighbor;
            cg.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            cg.SmoothingMode = SmoothingMode.None;

            var rndCoef = rand.Next(1, 6);
            moveSpeed = Settings.FallSpeed + rndCoef;
            changeCharsSpeed += rndCoef;
            RandomizeGlyphs();
        }

        private void RandomizeGlyphs()
        {
            var alphaLevel = Constants.Opacity;
            bool reachedLowestAlpha = false;
            for (int i = 0; i < glyphs.Length; i++)
            {
                char c = Chars[rand.Next(Chars.Length)];
                glyphs[i] = glyphProvider.GetGlyphByLevel(c, alphaLevel);

                if (!reachedLowestAlpha)
                {
                    alphaLevel -= Constants.AlphaStep;
                    if (alphaLevel < Constants.AlphaStep)
                    {
                        alphaLevel = Constants.AlphaStep;
                        reachedLowestAlpha = true;
                    }
                }
            }

            RedrawColumn();
        }

        private void RedrawColumn()
        {
            cg.Clear(Color.Black);

            int y = Settings.CharHeight;
            for (int i = glyphs.Length - 1; i > -1; i--)
            {
                cg.DrawImageUnscaled(glyphs[i].Bitmap, 0, y);
                y += Settings.CharHeight;
            }
        }

        public void Update()
        {
            Y += moveSpeed;
            changeCharsSpeed++;

            if (changeCharsSpeed % 7 != 0)
            {
                return;
            }

            for (int current = glyphs.Length - 1, prev = glyphs.Length - 2; current > 0; current--, prev--)
            {
                var prevGlyph = glyphProvider.GetGlyphByLevel(glyphs[prev].Char, glyphs[current].AlphaLevel);
                glyphs[current] = prevGlyph;
            }

            // pick random char
            // and set it at the beginning
            char newChar = Chars[rand.Next(Chars.Length)];
            var glyphToChange = glyphs[0];
            glyphs[0] = glyphProvider.GetGlyphByLevel(newChar, glyphToChange.AlphaLevel);

            // glyph below bottom
            if (Y - columnHeightPx > screenHeight)
            {
                Y = rand.Next(-screenHeight, -columnHeightPx);
                changeCharsSpeed = 0;
            }

            RedrawColumn();
        }

        public void DrawColumn(Graphics g)
        {
            g.DrawImageUnscaled(columnBitmap, X, Y);
        }
    }
}