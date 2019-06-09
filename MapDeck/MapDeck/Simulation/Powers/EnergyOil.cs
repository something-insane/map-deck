using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    public class EnergyOil : Power
    {
        public override Image Icon => Image.FromFile("Assets/EnergyOil.png");

        public override string Name => "Oil";

        public override Color BackgroundColor => Color.LightPink;

        public override Color ForegroundColor => Color.DarkRed;
    }
}
