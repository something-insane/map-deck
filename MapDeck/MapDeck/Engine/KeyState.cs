using System;
using System.Diagnostics;

namespace MapDeck.Engine
{
    public class KeyState
    {
        public KeyState(int whichKey, bool state)
        {
            this.Key = whichKey;
            this.Column = (whichKey % 5) + 1;
            this.Row = (int)Math.Floor(whichKey / 5d) + 1;
            this.Time = Stopwatch.StartNew();
            this.IsDown = state;
        }

        public int Key { get; }

        public bool IsDown { get; }

        public bool IsUp => !this.IsDown;

        public Stopwatch Time { get; }

        public int Row { get; }

        public int Column { get; }
    }
}
