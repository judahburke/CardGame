using CardGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Core
{
    public class Dealer
    {
        public static IEnumerable<Card> SortedDeck(bool hasSingleJoker = false, bool hasSuitedJoker = false)
        {
            var sortedDeck = new List<Card>
            {

                // Add Suit of Hearts
                new Card(CardSuit.Hearts, CardValue.Ace),
                new Card(CardSuit.Hearts, CardValue.Two),
                new Card(CardSuit.Hearts, CardValue.Three),
                new Card(CardSuit.Hearts, CardValue.Four),
                new Card(CardSuit.Hearts, CardValue.Five),
                new Card(CardSuit.Hearts, CardValue.Six),
                new Card(CardSuit.Hearts, CardValue.Seven),
                new Card(CardSuit.Hearts, CardValue.Eight),
                new Card(CardSuit.Hearts, CardValue.Nine),
                new Card(CardSuit.Hearts, CardValue.Ten),
                new Card(CardSuit.Hearts, CardValue.Jack),
                new Card(CardSuit.Hearts, CardValue.Queen),
                new Card(CardSuit.Hearts, CardValue.King),

                // Add Suit of Spades
                new Card(CardSuit.Spades, CardValue.Ace),
                new Card(CardSuit.Spades, CardValue.Two),
                new Card(CardSuit.Spades, CardValue.Three),
                new Card(CardSuit.Spades, CardValue.Four),
                new Card(CardSuit.Spades, CardValue.Five),
                new Card(CardSuit.Spades, CardValue.Six),
                new Card(CardSuit.Spades, CardValue.Seven),
                new Card(CardSuit.Spades, CardValue.Eight),
                new Card(CardSuit.Spades, CardValue.Nine),
                new Card(CardSuit.Spades, CardValue.Ten),
                new Card(CardSuit.Spades, CardValue.Jack),
                new Card(CardSuit.Spades, CardValue.Queen),
                new Card(CardSuit.Spades, CardValue.King),

                // Add Suit of Diamonds
                new Card(CardSuit.Diamonds, CardValue.Ace),
                new Card(CardSuit.Diamonds, CardValue.Two),
                new Card(CardSuit.Diamonds, CardValue.Three),
                new Card(CardSuit.Diamonds, CardValue.Four),
                new Card(CardSuit.Diamonds, CardValue.Five),
                new Card(CardSuit.Diamonds, CardValue.Six),
                new Card(CardSuit.Diamonds, CardValue.Seven),
                new Card(CardSuit.Diamonds, CardValue.Eight),
                new Card(CardSuit.Diamonds, CardValue.Nine),
                new Card(CardSuit.Diamonds, CardValue.Ten),
                new Card(CardSuit.Diamonds, CardValue.Jack),
                new Card(CardSuit.Diamonds, CardValue.Queen),
                new Card(CardSuit.Diamonds, CardValue.King),

                // Add Suit of Clubs
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Two),
                new Card(CardSuit.Clubs, CardValue.Three),
                new Card(CardSuit.Clubs, CardValue.Four),
                new Card(CardSuit.Clubs, CardValue.Five),
                new Card(CardSuit.Clubs, CardValue.Six),
                new Card(CardSuit.Clubs, CardValue.Seven),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Nine),
                new Card(CardSuit.Clubs, CardValue.Ten),
                new Card(CardSuit.Clubs, CardValue.Jack),
                new Card(CardSuit.Clubs, CardValue.Queen),
                new Card(CardSuit.Clubs, CardValue.King),
            };
            
            if (hasSingleJoker)
                sortedDeck.Add(new Card(CardSuit.None, CardValue.Joker));
            if (hasSuitedJoker)
            {
                sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Joker));
                sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Joker));
                sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Joker));
                sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Joker));
            }

            return sortedDeck;
        }

        public static IEnumerable<Card> ShuffledDeck(int numberOfShuffles = 1)
        {
            // Get a new IEnumerable of sorted cards
            IEnumerable<Card> sorted = SortedDeck();

            IEnumerable<Card> shuffled = Shuffle(sorted);
            for (int i=0; i< numberOfShuffles; i++)
                shuffled = Shuffle(shuffled);

            // Return the shuffled cards
            return shuffled;
        }

        public static IEnumerable<Card> Shuffle(IEnumerable<Card> unshuffled)
        {
            var shuffled = new List<Card>(); // todo: IEnumerable in dealer/shuffle
            Random random = new Random();

            int location = 0;
            foreach (Card card in unshuffled)
            {
                shuffled.Insert(location, card);
                location = random.Next(0, shuffled.Count() - 1);
            }

            return shuffled; // new Stack<Card>(shuffled)
        }
    }
}
