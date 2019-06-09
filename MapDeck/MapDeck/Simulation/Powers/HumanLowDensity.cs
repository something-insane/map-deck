using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    class HumanLowDensity : Power
    {
        public override Image Icon => Image.FromFile("Assets/HumanLowDensity.png");

        public override string Name => "Low Density";

        public override Color BackgroundColor => Color.White;

        public override Color ForegroundColor => Color.Black;
    }
}
