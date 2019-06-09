using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    class LandscapeTree : Power
    {
        public override Image Icon => Image.FromFile("Assets/LandscapeTree.png");

        public override string Name => "Tree";

        public override Color BackgroundColor => Color.PaleGreen;

        public override Color ForegroundColor => Color.DarkGreen;
    }
}
