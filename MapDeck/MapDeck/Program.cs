using System.Threading.Tasks;
using MapDeck.Engine;
using MapDeck.Screens;
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
                var screenManager = new ScreenManager(deck);
                var titleScreen = new TitleScreen(screenManager);
                var powerScreen = new PowersScreen(screenManager);

                titleScreen.NextScreen = powerScreen;

                titleScreen.Activate();

                while (true) Task.Delay(1000).GetAwaiter().GetResult();
            }
        }
    }
}
