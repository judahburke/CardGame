using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Lib
{
    public class Hand
    {
        public Hand(List<Card> cards, int id = 0, string name = "")
        {
            Player = new KeyValuePair<int, string>(id,name);
            Cards = cards;
        }
        public KeyValuePair<int, string> Player { get; set; }
        public List<Card> Cards { get; set; }
    }
}
