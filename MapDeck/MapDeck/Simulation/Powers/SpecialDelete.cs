using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    class SpecialDelete : Power
    {
        public override Image Icon => Image.FromFile("Assets/SpecialDelete.png");

        public override string Name => "Delete";

        public override Color BackgroundColor => Color.PowderBlue;

        public override Color ForegroundColor => Color.DarkBlue;
    }
}
