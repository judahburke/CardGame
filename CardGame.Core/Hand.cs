using CardGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Core
{
    public class Hand
    {
        public Hand(List<ICard> cards, int id = 0, string name = "")
        {
            Player = new KeyValuePair<int, string>(id,name);
            Cards = cards;
        }
        public KeyValuePair<int, string> Player { get; set; }
        public List<ICard> Cards { get; set; }
    }
}
