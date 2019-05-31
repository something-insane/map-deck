using System.Drawing;
using MapDeck.Engine;
using OpenMacroBoard.NetCore.SDK;

namespace MapDeck.Screens
{
    /// <summary>
    ///     Explains all cities.
    /// </summary>
    public class ExplainCityScreen : WhileHoldScreenBase
    {
        public ExplainCityScreen(
            ScreenManager screenManager,
            ScreenBase goBackTo)
            : base(screenManager, goBackTo)
        {
            this[1, 1] =
                KeyBitmap.Create.FromGraphics(72, 72, graphics =>
                {
                    graphics.Clear(Color.Black);
                    graphics.DrawString("CITY", Constants.DrawFont, Constants.WhiteBrush, Constants.TopLine);
                    graphics.DrawString("TILE", Constants.DrawFont, Constants.WhiteBrush, Constants.MiddleLine);
                    graphics.DrawString("????????????????", Constants.DrawFont, Constants.WhiteBrush, Constants.BottomLine);
                });
            this[2, 1] =
                KeyBitmap.Create.FromGraphics(72, 72, graphics =>
                {
                    graphics.Clear(Color.Black);
                    graphics.DrawString("HELP", Constants.DrawFont, Constants.WhiteBrush, Constants.TopLine);
                    graphics.DrawString("PAGE", Constants.DrawFont, Constants.WhiteBrush, Constants.MiddleLine);
                    graphics.DrawString("????????????????", Constants.DrawFont, Constants.WhiteBrush, Constants.BottomLine);
                });

            this[1, 2] =
                KeyBitmap.Create.FromGraphics(72, 72, graphics =>
                {
                    graphics.Clear(Color.Black);
                    graphics.DrawString("Cities\nmake\nmoney.", Constants.SmallFont, Constants.WhiteBrush, Constants.TopLine);
                });

            this[1, 3] =
                KeyBitmap.Create.FromGraphics(72, 72, graphics =>
                {
                    graphics.Clear(Color.Black);
                    graphics.DrawString("Money\nbuys\ntiles.", Constants.SmallFont, Constants.WhiteBrush, Constants.TopLine);
                });

            this[2, 2] =
                KeyBitmap.Create.FromGraphics(72, 72, graphics =>
                {
                    graphics.Clear(Color.Black);
                    graphics.DrawString("Adjacent\ncities\ngrow.", Constants.SmallFont, Constants.WhiteBrush, Constants.TopLine);
                });

            this[3, 2] =
                KeyBitmap.Create.FromGraphics(72, 72, graphics =>
                {
                    graphics.Clear(Color.Black);
                    graphics.DrawString("Cities\nneed\npower.", Constants.SmallFont, Constants.WhiteBrush, Constants.TopLine);
                });
        }
    }
}
