using MapDeck.Engine;
using MapDeck.Simulation;
using OpenMacroBoard.NetCore.SDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MapDeck.Screens
{
    public class MapScreen : ScreenBase
    {
        private readonly Map map;

        public MapScreen(ScreenManager screenManager, Map map) : base(screenManager)
        {
            this.map = map;
            this[4, 1] = SharedTiles.Move;
            SetMapTiles(false);
        }

        public override string Name => "Map";

        public override void OnKeyEvent(KeyState oldKeyState, KeyState newKeyState)
        {
            if (newKeyState.Column == 4
                && newKeyState.Row == 1)
            {
                SetMapTiles(newKeyState.IsDown);
            }
        }

        private void SetMapTiles(bool isZoomedOut)
        {
            this[1, 1] = this.map.GetKeyBitmapFor(-1, -1, isZoomedOut);
            this[2, 1] = this.map.GetKeyBitmapFor(-1,  0, isZoomedOut);
            this[3, 1] = this.map.GetKeyBitmapFor(-1,  1, isZoomedOut);

            this[1, 2] = this.map.GetKeyBitmapFor( 0, -1, isZoomedOut);
            this[2, 2] = this.map.GetKeyBitmapFor( 0,  0, isZoomedOut);
            this[3, 2] = this.map.GetKeyBitmapFor( 0,  1, isZoomedOut);

            this[1, 3] = this.map.GetKeyBitmapFor( 1, -1, isZoomedOut);
            this[2, 3] = this.map.GetKeyBitmapFor( 1,  0, isZoomedOut);
            this[3, 3] = this.map.GetKeyBitmapFor( 1,  1, isZoomedOut);
        }
    }
}
