using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation
{
    public abstract class Power
    {
        public abstract Image Icon { get; }

        public abstract string Name { get; }

        public abstract Color BackgroundColor { get; }
        public abstract Color ForegroundColor { get; }
    }
}
