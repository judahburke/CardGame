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
            Shuffle(10, true);
        }

        public int TerraceCount { get; set; }
        public List<Stack<Card>> TerraceList { get; set; }
        public Stack<Card> UndealtCards { get; set; }
        public Stack<Card> DealtCards { get; set; }
               

        public void Shuffle(int shuffles = 10, bool allCards = true)
        {
            if (allCards)
            {
                TerraceList = new List<Stack<Card>>();
                for (var i = 0; i < TerraceCount; i++)
                    TerraceList.Add(new Stack<Card>());
                DealtCards = new Stack<Card>();
                UndealtCards = new Stack<Card>(Dealer.ShuffledDeck(shuffles));
            }
            else
            {
                UndealtCards = new Stack<Card>(Dealer.ShuffledDeck(shuffles));
            }
        }
        public Card Deal()
        {
            return UndealtCards.Pop();
        }
    }

    public class Terrace : Stack<Card>
    {
        
    }
}
