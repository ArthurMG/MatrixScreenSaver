using System.Drawing;

namespace MatrixScreensaver
{
    internal sealed class Glyph
    {
        public Bitmap Bitmap { get; private set; }

        public int GlyphNumber { get; private set; }

        public Glyph(Bitmap bitmap, int glyphNumber)
        {
            Bitmap = bitmap;
            GlyphNumber = glyphNumber;
        }
    }
}
