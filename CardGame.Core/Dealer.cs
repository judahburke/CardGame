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
        public static IEnumerable<ICard> SortedDeck(bool hasSingleJoker = false, bool hasSuitedJoker = false)
        {
            var sortedDeck = new List<ICard>();

            // Add Suit of Hearts
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Ace));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Two));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Three));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Four));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Five));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Six));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Seven));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Eight));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Nine));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Ten));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Jack));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Queen));
            sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.King));
            if (hasSuitedJoker)
                sortedDeck.Add(new Card(CardSuit.Hearts, CardValue.Joker));

            // Add Suit of Spades
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Ace));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Two));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Three));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Four));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Five));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Six));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Seven));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Eight));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Nine));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Ten));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Jack));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Queen));
            sortedDeck.Add(new Card(CardSuit.Spades, CardValue.King));
            if (hasSuitedJoker)
                sortedDeck.Add(new Card(CardSuit.Spades, CardValue.Joker));

            // Add Suit of Diamonds
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Ace));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Two));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Three));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Four));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Five));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Six));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Seven));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Eight));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Nine));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Ten));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Jack));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Queen));
            sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.King));
            if (hasSuitedJoker)
                sortedDeck.Add(new Card(CardSuit.Diamonds, CardValue.Joker));

            // Add Suit of Clubs
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Ace));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Two));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Three));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Four));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Five));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Six));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Seven));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Eight));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Nine));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Ten));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Jack));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Queen));
            sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.King));
            if (hasSuitedJoker)
                sortedDeck.Add(new Card(CardSuit.Clubs, CardValue.Joker));

            if (hasSingleJoker)
                sortedDeck.Add(new Card(CardSuit.None, CardValue.Joker));

            return sortedDeck;
        }

        public static IEnumerable<ICard> ShuffledDeck(int numberOfShuffles = 1)
        {
            // Get a new IEnumerable of sorted cards
            IEnumerable<ICard> sorted = SortedDeck();

            IEnumerable<ICard> shuffled = Shuffle(sorted);
            for (int i=0; i< numberOfShuffles; i++)
                shuffled = Shuffle(shuffled);

            // Return the shuffled cards
            return shuffled;
        }

        public static IEnumerable<ICard> Shuffle(IEnumerable<ICard> unshuffled)
        {
            var shuffled = new List<ICard>(); // todo: IEnumerable in dealer/shuffle
            Random random = new Random();

            int location = 0;
            foreach (ICard card in unshuffled)
            {
                shuffled.Insert(location, card);
                location = random.Next(0, shuffled.Count() - 1);
            }

            return shuffled; // new Stack<ICard>(shuffled)
        }

        public static void ShuffleOldDeck(IDeck d)
        {
            // Deal all cards in the incoming deck
            d.Dealt.ToList().AddRange(d.Undealt);
            d.Undealt.ToList().RemoveRange(0, d.Undealt.Count());

            // Shuffle the dealt cards back into the deck
            d.Undealt = Shuffle(d.Dealt);
            d.Dealt = new List<ICard>(); //todo: IEnumerable in Dealer/ShuffleOldDeck
        }

        public static IEnumerable<Hand> Deal(int players, int cards, IDeck deck)
        {
            var trick = new List<Hand>();
            var dealt = new Stack<ICard>(deck.Dealt);
            var undealt = new Stack<ICard>(deck.Dealt);
            for (int i = 0; i < players; i++)
            {
                var myHand = new List<ICard>();

                for (int j = 0; j < cards; j++)
                {
                    ICard c = undealt.Peek();
                    dealt.Push(undealt.Pop());

                    myHand.Add(c);
                }

                trick.Add(new Hand(myHand,i));
            }
            return trick;
        }
    }
}
