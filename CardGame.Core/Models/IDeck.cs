using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Core.Models
{
    public class IDeck
    {
        public List<ICard> Undealt { get; set; }
        public List<ICard> Dealt { get; set; }

        public CardValue HighValue { get; set; }
        public CardSuit TrumpSuit { get; set; }
        public bool HasJokers { get; set; }
    }
}
