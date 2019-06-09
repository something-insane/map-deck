using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Tiles
{
    public class CityTile : Tile
    {
        public override Image Fullsize => Image.FromFile("Assets/City.png");

        public override Image NinthSize => Image.FromFile("Assets/City.png");
    }
}
