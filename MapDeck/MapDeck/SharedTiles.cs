using System.Drawing;
using OpenMacroBoard.NetCore.SDK;

namespace MapDeck
{
    public static class SharedTiles
    {
        public static KeyBitmap Logo() =>
            KeyBitmap.Create.FromGraphics(72, 72, graphics =>
            {
                graphics.Clear(Color.Red);
                graphics.DrawString("MAP", Constants.DrawFont, Constants.BlackBrush, Constants.TopLine);
                graphics.DrawString("DECK", Constants.DrawFont, Constants.BlackBrush, Constants.BottomLine);
            });

        public static KeyBitmap Continue =>
            KeyBitmap.Create.FromGraphics(72, 72, graphics =>
            {
                graphics.Clear(Color.Black);
                graphics.DrawString("---->", Constants.DrawFont, Constants.WhiteBrush, Constants.TopLine);
                graphics.DrawString("CONT-", Constants.DrawFont, Constants.WhiteBrush, Constants.MiddleLine);
                graphics.DrawString("INUE", Constants.DrawFont, Constants.WhiteBrush, Constants.BottomLine);
            });

        public static KeyBitmap PieceLogo(Color background, Color foreground, string piece, bool isSelected) =>
            KeyBitmap.Create.FromGraphics(72, 72, graphics =>
            {
                if (isSelected)
                {
                    var temp = background;
                    background = foreground;
                    foreground = temp;
                }
                ////if (isSelected)
                ////{
                ////    foreground = background;
                ////    background = Color.White;
                ////}

                graphics.Clear(background);
                if (isSelected)
                    using (var pen = new Pen(foreground, 6))
                        graphics.DrawRectangle(pen, 0, 0, 72, 72);

                using (var brush = new SolidBrush(foreground))
                    graphics.DrawString(piece, Constants.DrawFont, brush, Constants.MiddleLine);
            });
    }
}
