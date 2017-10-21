using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Lib
{
    public class Deck
    {
        public Deck()
        {
            Undealt = Dealer.ShuffledDeck();
            Dealt = new List<Card>();

            HighValue = new CardValue('K');
            TrumpSuit = new CardSuit('S');
            HasJokers = false;
        }
        public List<Card> Undealt { get; set; }
        public List<Card> Dealt { get; set; }

        public CardValue HighValue { get; set; }
        public CardSuit TrumpSuit { get; set; }
        public bool HasJokers { get; set; }
    }
}
