using System;
using System.Drawing;
using MapDeck.Engine;
using MapDeck.Simulation;
using MapDeck.Simulation.Powers;
using OpenMacroBoard.NetCore.SDK;

namespace MapDeck.Screens
{
    public class PowersScreen : ScreenBase
    {
        private Power[][] powerOptions = new Power[][] {
            new Power[] {
                new HumanHighDensity(),
                new HumanLowDensity(),
                new HumanResearch(),
            },
            new Power[] {
                new LandscapeTree(),
                new LandscapeSprout(),
                new LandscapeLivestock(),
            },
            new Power[] {
                new EnergyOil(),
                new EnergySolar(),
                new EnergyBattery(),
            },
            new Power[] {
                new SpecialDelete(),
                new SpecialEducation(),
                new SpecialRoad(),
            },
        };
        private readonly int[] _selections = new int[4];
        private readonly Player player;
        private WhileHoldScreenBase _targetExplainerScreen = null;

        public PowersScreen(ScreenManager screenManager, Player player)
            : base(screenManager)
        {
            this.player = player;
            this.Shuffle();

            this[5, 1] = KeyBitmap.Create.FromRgb(50, 50, 50);
            this[5, 2] = KeyBitmap.Black;
            this[5, 3] = SharedTiles.Continue;
        }

        public override string Name => "Powers Picker";

        public ScreenBase NextScreen { get; set; }

        public override void OnKeyEvent(KeyState oldKeyState, KeyState newKeyState)
        {
            if (newKeyState.IsDown && newKeyState.Row == 1 && newKeyState.Column == 5)
                this._targetExplainerScreen?.Activate();

            switch (newKeyState.Column)
            {
                case 5:
                    switch (newKeyState.Row)
                    {
                        case 2:
                            if (newKeyState.IsUp)
                                Shuffle();
                            break;
                        case 3:
                            if (newKeyState.IsUp)
                            {
                                var nextScreen = this.NextScreen ?? throw new InvalidOperationException($"{nameof(this.NextScreen)} not set.");
                                this.player.HumanPower = this.powerOptions[0][this._selections[0] - 1];
                                this.player.PlantPower = this.powerOptions[1][this._selections[1] - 1];
                                this.player.EnergyPower = this.powerOptions[2][this._selections[2] - 1];
                                this.player.SpecialPower = this.powerOptions[3][this._selections[3] - 1];
                                nextScreen.Activate();
                            }
                            break;
                    }

                    break;
                default:
                    this.UpdateColumn(newKeyState.Column, newKeyState.Row);
                    break;
            }
        }

        private void Shuffle()
        {
            var random = new Random();
            this.UpdateColumn(1, random.Next(3) + 1);
            this.UpdateColumn(2, random.Next(3) + 1);
            this.UpdateColumn(3, random.Next(3) + 1);
            this.UpdateColumn(4, random.Next(3) + 1);
            this._targetExplainerScreen = null;
        }

        private void UpdateColumn(int column, int newRow)
        {
            this._selections[column - 1] = newRow;
            var powerList = powerOptions[column - 1];
            this[column, 1] = SharedTiles.PieceLogo(powerList[0], this._selections[column - 1] == 1);
            this[column, 2] = SharedTiles.PieceLogo(powerList[1], this._selections[column - 1] == 2);
            this[column, 3] = SharedTiles.PieceLogo(powerList[2], this._selections[column - 1] == 3);
        }
    }
}
