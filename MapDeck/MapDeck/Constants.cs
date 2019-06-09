using System.Drawing;

namespace MapDeck
{
    public static class Constants
    {
        public static Font DrawFont = new Font("Arial", 16);
        public static Font SmallFont = new Font("Arial", 11);
        public static Font TinyFont = new Font("Arial", 8);
        public static SolidBrush BlackBrush = new SolidBrush(Color.Black);
        public static SolidBrush WhiteBrush = new SolidBrush(Color.White);
        public static SolidBrush CyanBrush = new SolidBrush(Color.Cyan);

        public static Point TopLine = new Point();
        public static Point MiddleLine = new Point(0, DrawFont.Height);
        public static Point BottomLine = new Point(0, DrawFont.Height * 2);
    }
}
