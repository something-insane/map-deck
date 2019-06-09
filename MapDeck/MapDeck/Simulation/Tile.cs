using System.Drawing;

namespace MapDeck.Simulation
{
    public abstract class Tile
    {
        public abstract Image Fullsize { get; }

        public abstract Image NinthSize { get; }
    }
}
