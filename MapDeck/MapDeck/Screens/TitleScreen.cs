using System;
using MapDeck.Engine;

namespace MapDeck.Screens
{
    public class TitleScreen : ScreenBase
    {
        private string test = "";
        public TitleScreen(ScreenManager screenManager) : base(screenManager)
        {
            this[3, 2] = SharedTiles.Logo;
        }

        public override string Name => "Title";

        public override void OnKeyEvent(KeyState oldKeyState, KeyState newKeyState)
        {
            if (newKeyState.Column == 3
                && newKeyState.Row == 2
                && newKeyState.IsUp)
            {
                var nextScreen = this.NextScreen ?? throw new InvalidOperationException($"{nameof(this.NextScreen)} not set.");
                nextScreen.Activate();
            }
        }

        public ScreenBase NextScreen { get; set; }
    }
}
