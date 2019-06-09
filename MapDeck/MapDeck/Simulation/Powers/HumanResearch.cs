using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Powers
{
    class HumanResearch : Power
    {
        public override Image Icon => Image.FromFile("Assets/HumanResearch.png");

        public override string Name => "Research";

        public override Color BackgroundColor => Color.White;

        public override Color ForegroundColor => Color.Black;
    }
}
