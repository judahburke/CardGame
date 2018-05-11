using CardGame.Core;
using CardGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Solitaire.ConsoleApp
{
    public class Tableu : IDeck
    {
        public Tableu(int terraces = 5)
        {
            TerraceCount = terraces;
            TerraceStackList = new List<Stack<ICard>>();
            for (var i = 0; i < terraces; i++)
                TerraceStackList.Add(new Stack<ICard>());
            DealtStack = new Stack<ICard>();
            UndealtStack = new Stack<ICard>(Dealer.SortedDeck()); 
        }


        public List<Stack<ICard>> TerraceStackList { get; set; }
        public Stack<ICard> UndealtStack { get; set; }
        public Stack<ICard> DealtStack { get; set; }

        public int TerraceCount { get; set; }
    }

    public class Terrace : Stack<ICard>
    {
        
    }
}
