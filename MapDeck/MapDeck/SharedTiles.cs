using System.Drawing;
using System.Drawing.Imaging;
using MapDeck.Simulation;
using OpenMacroBoard.NetCore.SDK;

namespace MapDeck
{
    public static class SharedTiles
    {
        public static KeyBitmap Logo =>
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

        public static KeyBitmap Move =>
            KeyBitmap.Create.FromGraphics(72, 72, graphics =>
            {
                graphics.Clear(Color.Black);
                graphics.DrawString("HOLD", Constants.DrawFont, Constants.WhiteBrush, Constants.TopLine);
                graphics.DrawString("TO ", Constants.DrawFont, Constants.WhiteBrush, Constants.MiddleLine);
                graphics.DrawString("MOVE", Constants.DrawFont, Constants.WhiteBrush, Constants.BottomLine);
            });

        public static KeyBitmap PieceLogo(Power power, bool isSelected) =>
            KeyBitmap.Create.FromGraphics(72, 72, graphics =>
            {
                var background = power.BackgroundColor;
                var foreground = power.ForegroundColor;

                if (isSelected)
                {
                    var temp = background;
                    background = foreground;
                    foreground = temp;
                }

                graphics.Clear(background);
                if (isSelected)
                    using (var pen = new Pen(foreground, 6))
                        graphics.DrawRectangle(pen, 0, 0, 72, 72);

                var imageAttributes = new ImageAttributes();
                if (isSelected)
                {
                    var invertingColorMatrix = new ColorMatrix(new float[][]
                    {
                        new float[] {-1, 0, 0, 0, 0},
                        new float[] {0, -1, 0, 0, 0},
                        new float[] {0, 0, -1, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {1, 1, 1, 0, 1}
                    });
                    imageAttributes.SetColorMatrix(invertingColorMatrix);
                }
                graphics.DrawImage(
                    power.Icon,
                    new Rectangle(0, 0, 72, 72),
                    0, 0, power.Icon.Width, power.Icon.Height,
                    GraphicsUnit.Pixel,
                    imageAttributes);

                ////using (var brush = new SolidBrush(foreground))
                ////    graphics.DrawString(power.Name, Constants.DrawFont, brush, Constants.MiddleLine);
            });
    }
}
