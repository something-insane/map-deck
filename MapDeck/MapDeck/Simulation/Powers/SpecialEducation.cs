using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    class SpecialEducation : Power
    {
        public override Image Icon => Image.FromFile("Assets/SpecialEducation.png");

        public override string Name => "Education";

        public override Color BackgroundColor => Color.PowderBlue;

        public override Color ForegroundColor => Color.DarkBlue;
    }
}
