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
        private readonly Player player;
        private bool inZoomMode = false;

        public MapScreen(ScreenManager screenManager, Map map, Player player)
            : base(screenManager)
        {
            this.map = map;
            this.player = player;
            this[4, 1] = SharedTiles.Move;
            SetMapTiles(false);
        }

        public override void Activate()
        {
            base.Activate();

            this[4, 2] = SharedTiles.PieceLogo(this.player.HumanPower, false);
            this[5, 2] = SharedTiles.PieceLogo(this.player.PlantPower, false);
            this[4, 3] = SharedTiles.PieceLogo(this.player.SpecialPower, false);
            this[5, 3] = SharedTiles.PieceLogo(this.player.EnergyPower, false);
        }

        public override string Name => "Map";

        public override void OnKeyEvent(KeyState oldKeyState, KeyState newKeyState)
        {
            if (newKeyState.Column == 4
                && newKeyState.Row == 1)
            {
                this.inZoomMode = newKeyState.IsDown;
                SetMapTiles(inZoomMode);
            }

            if (this.inZoomMode
                && newKeyState.Column <= 3
                && newKeyState.IsDown)
            {
                var offsetX = newKeyState.Column - 2;
                var offsetY = newKeyState.Row - 2;
                var isCenterTile = offsetX == 0 && offsetY == 0;
                if (!isCenterTile)
                {
                    this.map.MoveCenterLocation(offsetX, offsetY);
                    this.inZoomMode = false;
                    SetMapTiles(inZoomMode);
                }
            }
        }

        private void SetMapTiles(bool isZoomedOut)
        {
            this[1, 1] = this.map.GetKeyBitmapFor(-1, -1, isZoomedOut);
            this[2, 1] = this.map.GetKeyBitmapFor( 0, -1, isZoomedOut);
            this[3, 1] = this.map.GetKeyBitmapFor( 1, -1, isZoomedOut);

            this[1, 2] = this.map.GetKeyBitmapFor(-1,  0, isZoomedOut);
            this[2, 2] = this.map.GetKeyBitmapFor( 0,  0, isZoomedOut);
            this[3, 2] = this.map.GetKeyBitmapFor( 1,  0, isZoomedOut);

            this[1, 3] = this.map.GetKeyBitmapFor(-1,  1, isZoomedOut);
            this[2, 3] = this.map.GetKeyBitmapFor( 0,  1, isZoomedOut);
            this[3, 3] = this.map.GetKeyBitmapFor( 1,  1, isZoomedOut);
        }
    }
}
