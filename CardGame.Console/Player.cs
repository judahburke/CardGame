using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame.Core;
using CardGame.Core.Models;

namespace CardGame.General
{
    class Player
    {
        public Player(string name = "Player", int order = 0)
        {
            Name = name;
            Order = order;
        }

        public ICard PlayCard()
        {
            //todo: choose card to play from hand
            Random rand = new Random();
            int max = Hand.Cards.Count - 1;
            return Hand.Cards.ElementAt(rand.Next(0,max));
        }

        public Hand Hand { get; set; }
        public KeyValuePair<int, string> Team { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
