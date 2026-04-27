using System;
using System.Drawing;

namespace MatrixScreensaver
{
    internal class Glyph : IEquatable<Glyph>
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

        public override bool Equals(object other)
        {
            return other is Glyph a && Equals(a); // Calls method bellow
        }

        public bool Equals(Glyph other)
        {
            return AlphaLevel == other.AlphaLevel && Char == other.Char;
        }

        public override int GetHashCode()
        {
            return AlphaLevel.GetHashCode() ^ Char.GetHashCode();
        }

        // Calls static Object.Eqauls that will call our custom instance Equals 
        public static bool operator ==(Glyph a1, Glyph a2) => Equals(a1, a2);
        public static bool operator !=(Glyph a1, Glyph a2) => !(a1 == a2);
    }
}
