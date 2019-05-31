using System;
using System.Drawing;
using MapDeck.Engine;
using OpenMacroBoard.NetCore.SDK;

namespace MapDeck.Screens
{
    public class PowersScreen : ScreenBase
    {
        private readonly int[] _selections = new int[4];
        private WhileHoldScreenBase _targetExplainerScreen = null;

        public PowersScreen(ScreenManager screenManager)
            : base(screenManager)
        {
            this.Shuffle();

            this[5, 1] = KeyBitmap.Create.FromRgb(50, 50, 50);
            this[5, 2] = KeyBitmap.Black;
            this[5, 3] = SharedTiles.Continue;
        }

        public override string Name => "Powers Picker";

        public ScreenBase NextScreen { get; set; }

        public override void OnKeyEvent(KeyState oldKeyState, KeyState newKeyState)
        {
            if (newKeyState.IsDown && newKeyState.Row == 1 && newKeyState.Column == 5)
                this._targetExplainerScreen?.Activate();

            switch (newKeyState.Column)
            {
                case 5:
                    switch (newKeyState.Row)
                    {
                        case 2:
                            if (newKeyState.IsUp)
                                Shuffle();
                            break;
                        case 3:
                            if (newKeyState.IsUp)
                            {
                                var nextScreen = this.NextScreen ?? throw new InvalidOperationException($"{nameof(this.NextScreen)} not set.");
                                nextScreen.Activate();
                            }
                            break;
                    }

                    break;
                default:
                    this.UpdateColumn(newKeyState.Column, newKeyState.Row);
                    break;
            }
        }

        private void Shuffle()
        {
            var random = new Random();
            this.UpdateColumn(1, random.Next(3) + 1);
            this.UpdateColumn(2, random.Next(3) + 1);
            this.UpdateColumn(3, random.Next(3) + 1);
            this.UpdateColumn(4, random.Next(3) + 1);
            this._targetExplainerScreen = null;
        }

        private void UpdateColumn(int column, int newRow)
        {
            var foreground = Color.DeepPink;
            var background = Color.HotPink;
            var name = "broken";
            switch (column)
            {
                case 1:
                    foreground = Color.Black;
                    background = Color.White;
                    name = "housing";
                    this._targetExplainerScreen = new ExplainCityScreen(this.ScreenManager, this);
                    break;
                case 2:
                    foreground = Color.DarkGreen;
                    background = Color.PaleGreen;
                    name = "plant";
                    this._targetExplainerScreen = null;
                    break;
                case 3:
                    foreground = Color.DarkRed;
                    background = Color.LightPink;
                    name = "power";
                    this._targetExplainerScreen = null;
                    break;
                case 4:
                    foreground = Color.DarkBlue;
                    background = Color.PowderBlue;
                    name = "special";
                    this._targetExplainerScreen = null;
                    break;
            }

            this._selections[column - 1] = newRow;
            this[column, 1] = SharedTiles.PieceLogo(background, foreground, "1", this._selections[column - 1] == 1);
            this[column, 2] = SharedTiles.PieceLogo(background, foreground, "2", this._selections[column - 1] == 2);
            this[column, 3] = SharedTiles.PieceLogo(background, foreground, "3", this._selections[column - 1] == 3);
        }
    }
}
