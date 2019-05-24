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
            }
        }
    }
}
