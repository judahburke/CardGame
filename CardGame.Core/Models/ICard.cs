using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Core.Models
{
    /// <summary>
    /// Card model with Suit and Value
    /// http://www.solitairelaboratory.com/glossary.html
    /// </summary>
    public class ICard
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
    }
}
