using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    class SpecialRoad : Power
    {
        public override Image Icon => Image.FromFile("Assets/SpecialRoad.png");

        public override string Name => "Road";

        public override Color BackgroundColor => Color.PowderBlue;

        public override Color ForegroundColor => Color.DarkBlue;
    }
}
