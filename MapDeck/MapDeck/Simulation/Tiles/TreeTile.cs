using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Simulation.Tiles
{
    public class TreeTile : Tile
    {
        public override Image Fullsize => Image.FromFile("Assets/Tree.png");

        public override Image NinthSize => Image.FromFile("Assets/Tree.png");
    }
}
