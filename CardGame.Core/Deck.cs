using CardGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Core
{
    public class Deck : IDeck
    {
        public Deck(CardSuit trump = CardSuit.None
            , CardValue high = CardValue.King
            , bool hasJokers = false)
        {
            Undealt = Dealer.ShuffledDeck();
            Dealt = new List<ICard>();

            TrumpSuit = trump;
            HighValue = high;
            HasJokers = hasJokers;
        }
    }
}
