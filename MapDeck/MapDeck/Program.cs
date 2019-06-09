using System.Threading.Tasks;
using MapDeck.Engine;
using MapDeck.Screens;
using MapDeck.Simulation;
using OpenMacroBoard.NetCore.SDK;
using StreamDeckSharp.NetCore;

namespace MapDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var deck = StreamDeck.OpenDevice())
            {
                deck.ClearKeys();
                var map = new Map();
                var player = new Player();

                var screenManager = new ScreenManager(deck);
                var titleScreen = new TitleScreen(screenManager);
                var powerScreen = new PowersScreen(screenManager, player);

                var mapScreen = new MapScreen(screenManager, map, player);

                titleScreen.NextScreen = powerScreen;
                powerScreen.NextScreen = mapScreen;

                titleScreen.Activate();

                while (true) Task.Delay(1000).GetAwaiter().GetResult();
            }
        }
    }
}
