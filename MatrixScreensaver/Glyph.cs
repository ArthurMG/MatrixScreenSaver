using System.Drawing;

namespace MatrixScreensaver
{
    internal class Glyph
    {
        public Bitmap Bitmap { get; private set; }

        public char Char { get; private set; }

        public int AlphaLevel { get; private set; }

        public Glyph(Bitmap bitmap, char ch, int alphaLevel)
        {
            Bitmap = bitmap;
            AlphaLevel = alphaLevel;
            Char = ch;
        }
    }
}
