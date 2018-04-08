using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Core.Models
{
    public class ICard
    {
        public CardSuit CardSuit { get; set; }
        public CardValue CardValue { get; set; }
    }
}
