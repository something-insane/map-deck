using System;
using System.Collections.Generic;
using System.Text;

namespace MapDeck.Simulation
{
    public class Player
    {
        public Power HumanPower { get; set; }
        public Power PlantPower { get; set; }
        public Power EnergyPower { get; set; }
        public Power SpecialPower { get; set; }
    }
}
