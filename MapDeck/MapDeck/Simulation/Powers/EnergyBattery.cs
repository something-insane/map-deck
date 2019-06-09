using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    public class EnergyBattery : Power
    {
        public override Image Icon => Image.FromFile("Assets/EnergyBattery.png");

        public override string Name => "Battery";

        public override Color BackgroundColor => Color.LightPink;

        public override Color ForegroundColor => Color.DarkRed;
    }
}
