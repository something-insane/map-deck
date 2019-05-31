using System;
using System.Collections.Generic;
using System.Linq;
using OpenMacroBoard.NetCore.SDK;
using StreamDeckSharp.NetCore;

namespace MapDeck.Engine
{
    public class ScreenManager
    {
        private readonly List<ScreenBase> screens = new List<ScreenBase>();
        private readonly KeyState[,] _keyStates = new KeyState[5, 3];

        public ScreenManager(IStreamDeckBoard deck)
        {
            this.Deck = deck;

            deck.KeyStateChanged += this.OnKeyEvent;
            for (var i = 0; i < 15; i++)
            {
                var keyState = new KeyState(i, false);
                this._keyStates[keyState.Column - 1, keyState.Row - 1] = keyState;
            }
        }

        public IStreamDeckBoard Deck { get; }

        public ScreenBase ActiveScreen { get; private set; }

        public void RegisterScreen(ScreenBase screen)
        {
            screens.Add(screen ?? throw new ArgumentNullException(nameof(screen)));
        }

        public void OnScreenActivated(ScreenBase screen)
        {
            this.ActiveScreen?.Deactivate();
            this.ActiveScreen = screen ?? throw new ArgumentNullException(nameof(screen));
            Console.WriteLine($"Activated Screen: {screen.Name}");
        }

        public void OnScreenDeactivated(ScreenBase screen)
        {
            // nothing yet
            Console.WriteLine($"Deactivated Screen: {screen.Name}");
        }

        public IEnumerable<KeyState> KeyStates => this._keyStates.Cast<KeyState>();

        private void OnKeyEvent(object sender, KeyEventArgs args)
        {
            var newKeyState = new KeyState(args.Key, args.IsDown);
            this._keyStates[newKeyState.Column - 1, newKeyState.Row - 1] = newKeyState;
            var oldKeyState = this._keyStates[newKeyState.Column - 1, newKeyState.Row - 1];
            this.ActiveScreen?.OnKeyEvent(oldKeyState, newKeyState);
        }
    }
}
