using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Core.Models
{
    /// <summary>
    /// Deck of cards
    /// http://www.solitairelaboratory.com/glossary.html
    /// </summary>
    public class IDeck
    {
        public IEnumerable<ICard> Undealt { get; set; }
        public IEnumerable<ICard> Dealt { get; set; }

        public CardValue HighValue { get; set; }
        public CardSuit TrumpSuit { get; set; }
        public bool HasJokers { get; set; }
    }
}
