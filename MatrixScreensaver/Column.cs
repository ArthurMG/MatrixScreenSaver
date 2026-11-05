using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MatrixScreensaver
{
    internal sealed class Column : IDisposable
    {
        private Rectangle Position;

        private readonly int moveSpeed;
        private int changeCharsSpeed;
        private readonly int screenHeight;

        private readonly Random rand;
        private readonly Glyph[] glyphs;
        private readonly GlyphProvider glyphProvider;

        // glyphs are composed into a single strip so a frame needs one blit per column
        private readonly Bitmap glyphStrip;
        private readonly Graphics glyphStripGraphics;
        private bool glyphStripDirty = true;

        public Column(int x,
            int startY,
            int length,
            Random rand,
            int screenHeight,
            GlyphProvider glyphProvider)
        {
            this.rand = rand;
            this.glyphProvider = glyphProvider;
            this.screenHeight = screenHeight;

            Position = new Rectangle(x, startY, Settings.CharWidth, length * Settings.CharHeight);

            glyphs = new Glyph[length];
            glyphStrip = new Bitmap(Settings.CharWidth, length * Settings.CharHeight, PixelFormat.Format32bppPArgb);
            glyphStripGraphics = Graphics.FromImage(glyphStrip);

            var rndCoef = rand.Next(1, 5);
            moveSpeed = Settings.FallSpeed + rndCoef;
            changeCharsSpeed += rndCoef;
            GenerateGlyphs();
        }

        private void GenerateGlyphs()
        {
            var alphaLevel = Constants.Opacity;
            bool reachedLowestAlpha = false;
            for (int i = glyphs.Length - 1; i >= 0; i--)
            {
                glyphs[i] = glyphProvider.GetRandomGlyphByLevel(alphaLevel);

                if (reachedLowestAlpha)
                {
                    continue;
                }

                alphaLevel -= Constants.AlphaStep;
                if (alphaLevel < Constants.AlphaStep)
                {
                    alphaLevel = Constants.AlphaStep;
                    reachedLowestAlpha = true;
                }
            }
        }

        public void Update()
        {
            Position.Y += moveSpeed;
            changeCharsSpeed++;

            if (changeCharsSpeed % 7 != 0)
            {
                return;
            }

            for (int current = 0, next = 1; current < glyphs.Length - 1; current++, next++)
            {
                var nextGlyph = glyphProvider.GetMoreTransparentGlyph(glyphs[next]);
                glyphs[current] = nextGlyph;
            }

            // changing the "head" by random non opacite char
            glyphs[glyphs.Length - 1] = glyphProvider.GetRandomGlyphByLevel(Constants.Opacity);
            glyphStripDirty = true;

            // column is below bottom
            if (Position.Y - Position.Height > screenHeight)
            {
                Position.Y = rand.Next(-screenHeight, -Position.Height);
                changeCharsSpeed = 0;
            }
        }

        public void DrawColumn(Graphics g, int clipTop, int clipBottom)
        {
            // column is completely outside of the visible area
            if (Position.Bottom <= clipTop || Position.Y >= clipBottom)
            {
                return;
            }

            if (glyphStripDirty)
            {
                RebuildGlyphStrip();
            }

            g.DrawImageUnscaled(glyphStrip, Position.X, Position.Y);
        }

        private void RebuildGlyphStrip()
        {
            glyphStripGraphics.Clear(Color.Transparent);

            int glyphHeight = Settings.CharHeight;
            for (int i = 0; i < glyphs.Length; i++)
            {
                glyphStripGraphics.DrawImageUnscaled(glyphs[i].Bitmap, 0, i * glyphHeight);
            }

            glyphStripDirty = false;
        }

        public void Dispose()
        {
            glyphStripGraphics.Dispose();
            glyphStrip.Dispose();
        }
    }
}