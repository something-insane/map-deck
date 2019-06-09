using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    public class EnergySolar : Power
    {
        public override Image Icon => Image.FromFile("Assets/EnergySolar.png");

        public override string Name => "Solar";

        public override Color BackgroundColor => Color.LightPink;

        public override Color ForegroundColor => Color.DarkRed;
    }
}
