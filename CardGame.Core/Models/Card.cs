using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Core.Models
{
    public class Card
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

        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
    }

}
