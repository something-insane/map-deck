using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    class LandscapeLivestock : Power
    {
        public override Image Icon => Image.FromFile("Assets/LandscapeLivestock.png");

        public override string Name => "Livestock";

        public override Color BackgroundColor => Color.PaleGreen;

        public override Color ForegroundColor => Color.DarkGreen;
    }
}
