using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Core.Models
{
    /// <summary>
    /// Deck of cards
    /// http://www.solitairelaboratory.com/glossary.html
    /// </summary>
    public interface IDeck
    {
        Card Deal();
        void Shuffle(int shuffles, bool allCards);
        //void Sort(bool bySuit, bool byValue);
        //void Cut(int loc);

        Stack<Card> UndealtCards { get; set; }
    }
}
