using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    public class HumanHighDensity : Power
    {
        public override Image Icon => Image.FromFile("Assets/HumanHighDensity.png");

        public override string Name => "High Density";

        public override Color BackgroundColor => Color.White;

        public override Color ForegroundColor => Color.Black;
    }
}
