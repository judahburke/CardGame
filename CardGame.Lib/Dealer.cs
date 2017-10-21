using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Lib
{
    public class Dealer
    {
        public static List<Card> SortedDeck()
        {
            List<Card> sortedDeck = new List<Card>();
            bool hasSuitedJoker = false;
            bool hasSingleJoker = false;

            // Add Suit of Hearts
            sortedDeck.Add(new Card('H', 'A'));
            sortedDeck.Add(new Card('H', '1'));
            sortedDeck.Add(new Card('H', '2'));
            sortedDeck.Add(new Card('H', '3'));
            sortedDeck.Add(new Card('H', '4'));
            sortedDeck.Add(new Card('H', '5'));
            sortedDeck.Add(new Card('H', '6'));
            sortedDeck.Add(new Card('H', '7'));
            sortedDeck.Add(new Card('H', '8'));
            sortedDeck.Add(new Card('H', '9'));
            sortedDeck.Add(new Card('H', '0'));
            sortedDeck.Add(new Card('H', 'J'));
            sortedDeck.Add(new Card('H', 'Q'));
            sortedDeck.Add(new Card('H', 'K'));
            if (hasSuitedJoker)
                sortedDeck.Add(new Card('H', 'R'));

            // Add Suit of Spades
            sortedDeck.Add(new Card('S', 'A'));
            sortedDeck.Add(new Card('S', '1'));
            sortedDeck.Add(new Card('S', '2'));
            sortedDeck.Add(new Card('S', '3'));
            sortedDeck.Add(new Card('S', '4'));
            sortedDeck.Add(new Card('S', '5'));
            sortedDeck.Add(new Card('S', '6'));
            sortedDeck.Add(new Card('S', '7'));
            sortedDeck.Add(new Card('S', '8'));
            sortedDeck.Add(new Card('S', '9'));
            sortedDeck.Add(new Card('S', '0'));
            sortedDeck.Add(new Card('S', 'J'));
            sortedDeck.Add(new Card('S', 'Q'));
            sortedDeck.Add(new Card('S', 'K'));
            if (hasSuitedJoker)
                sortedDeck.Add(new Card('S', 'R'));

            // Add Suit of Clubs
            sortedDeck.Add(new Card('C', 'A'));
            sortedDeck.Add(new Card('C', '1'));
            sortedDeck.Add(new Card('C', '2'));
            sortedDeck.Add(new Card('C', '3'));
            sortedDeck.Add(new Card('C', '4'));
            sortedDeck.Add(new Card('C', '5'));
            sortedDeck.Add(new Card('C', '6'));
            sortedDeck.Add(new Card('C', '7'));
            sortedDeck.Add(new Card('C', '8'));
            sortedDeck.Add(new Card('C', '9'));
            sortedDeck.Add(new Card('C', '0'));
            sortedDeck.Add(new Card('C', 'J'));
            sortedDeck.Add(new Card('C', 'Q'));
            sortedDeck.Add(new Card('C', 'K'));
            if (hasSuitedJoker)
                sortedDeck.Add(new Card('C', 'R'));

            // Add Suit of Diamonds
            sortedDeck.Add(new Card('D', 'A'));
            sortedDeck.Add(new Card('D', '1'));
            sortedDeck.Add(new Card('D', '2'));
            sortedDeck.Add(new Card('D', '3'));
            sortedDeck.Add(new Card('D', '4'));
            sortedDeck.Add(new Card('D', '5'));
            sortedDeck.Add(new Card('D', '6'));
            sortedDeck.Add(new Card('D', '7'));
            sortedDeck.Add(new Card('D', '8'));
            sortedDeck.Add(new Card('D', '9'));
            sortedDeck.Add(new Card('D', '0'));
            sortedDeck.Add(new Card('D', 'J'));
            sortedDeck.Add(new Card('D', 'Q'));
            sortedDeck.Add(new Card('D', 'K'));
            if (hasSuitedJoker)
                sortedDeck.Add(new Card('D', 'R'));

            if (hasSingleJoker)
                sortedDeck.Add(new Card('J', 'R'));

            return sortedDeck;
        }

        public static List<Card> ShuffledDeck(int num = 1)
        {
            // Get a new list of sorted cards
            List<Card> sorted = SortedDeck();

            List<Card> shuffled = Shuffle(sorted);
            while (num > 1)
            {
                shuffled = Shuffle(shuffled);
                num--;
            }

            // Return the shuffled cards
            return shuffled;
        }

        public static List<Card> Shuffle(List<Card> unshuffled)
        {
            List<Card> shuffled = new List<Card>();
            Random random = new Random();

            int location = 0;
            foreach (Card card in unshuffled)
            {
                shuffled.Insert(location, card);
                location = random.Next(0, shuffled.Count - 1);
            }

            return shuffled;
        }

        public static void ShuffleOldDeck(Deck d)
        {
            // Deal all cards in the incoming deck
            d.Dealt.AddRange(d.Undealt);
            d.Undealt.RemoveRange(0, d.Undealt.Count);

            // Shuffle the dealt cards back into the deck
            d.Undealt = Shuffle(d.Dealt);
            d.Dealt = new List<Card>();
        }

        public static List<Hand> Deal(int players, int cards, Deck deck)
        {
            List<Hand> trick = new List<Hand>();
            for (int i = 0; i < players; i++)
            {
                List<Card> myHand = new List<Card>();

                for (int j = 0; j < cards; j++)
                {
                    Card c = deck.Undealt[0];
                    deck.Dealt.Add(c);
                    deck.Undealt.Remove(c);

                    myHand.Add(c);
                }

                trick.Add(new Hand(myHand,i));
            }
            return trick;
        }
    }
}
