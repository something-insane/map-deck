using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    class LandscapeSprout : Power
    {
        public override Image Icon => Image.FromFile("Assets/LandscapeSprout.png");

        public override string Name => "Sprout";

        public override Color BackgroundColor => Color.PaleGreen;

        public override Color ForegroundColor => Color.DarkGreen;
    }
}
