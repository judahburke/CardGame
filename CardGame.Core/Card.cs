using CardGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Core
{
    public class Card : ICard
    {
        public Card(CardSuit suit, CardValue val)
        {
            Suit = suit;
            Value = val;
        }
        public Card(Card card)
        {
            Suit = card.Suit;
            Value = card.Value;
        }
        public string WriteCard()
        {
            return Value.ToString() + " of " + Suit.ToString();
        }

        //public CardSuit Suit { get; set; }
        //public CardValue Value { get; set; }
    }

}
