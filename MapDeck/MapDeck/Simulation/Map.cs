using MapDeck.Simulation.Tiles;
using OpenMacroBoard.NetCore.SDK;
using System;
using System.Drawing;

namespace MapDeck.Simulation
{
    public class Map
    {
        public Tile[,] Tiles = new Tile[3 * 16, 3 * 16];

        public Point CenterLocation = new Point(3 * 8, 3 * 8);

        public Map()
        {
            var rand = new Random();
            for (var x = 0; x < this.Tiles.GetLength(0); x++)
            {
                for (var y = 0; y < this.Tiles.GetLength(1); y++)
                {
                    this.Tiles[x, y] = rand.Next() % 2 == 0 ? new TreeTile() as Tile : new CityTile() as Tile;
                }
            }
        }

        public Tile GetOffsetTile(int offsetX, int offsetY)
        {
            return Tiles[CenterLocation.X + offsetX, CenterLocation.Y + offsetY];
        }

        public void MoveCenterLocation(int offsetX, int offsetY)
        {
            this.CenterLocation.X += offsetX * 3;
            this.CenterLocation.Y += offsetY * 3;
        }

        public KeyBitmap GetKeyBitmapFor(int offsetX, int offsetY, bool isZoomed)
        {
            if (!isZoomed)
            {
                var image = GetOffsetTile(offsetX, offsetY).Fullsize;
                return KeyBitmap.Create.FromGraphics(72, 72, g =>
                {
                    g.DrawImage(image, new Rectangle(0, 0, 72, 72));
                    g.DrawString($"{offsetX}, {offsetY}", Constants.TinyFont, Constants.CyanBrush, Constants.MiddleLine);
                });
            }
            else
            {
                return KeyBitmap.Create.FromGraphics(72, 72, g =>
                {
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            var x = 24 * i;
                            var y = 24 * j;
                            var tileOffsetX = offsetX * 3 + i - 1;
                            var tileOffsetY = offsetY * 3 + j - 1;
                            var tile = this.GetOffsetTile(tileOffsetX, tileOffsetY);
                            g.DrawImage(tile.NinthSize, new Rectangle(x, y, 24, 24));
                            g.DrawString($"{tileOffsetX}, {tileOffsetY}", Constants.TinyFont, Constants.CyanBrush, new Point(x,y));
                        }
                    }
                });
            }
        }
    }
}
