using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Lib
{
    public class Card
    {
        public Card(char suit, char val)
        {
            Suit = new CardSuit(suit);
            Value = new CardValue(val);
        }
        public string WriteCard()
        {
            return Value.WrittenValue + " of " + Suit.WrittenSuit;
        }

        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
    }

    public class CardSuit
    {
        public CardSuit(char suit)
        {
            this.Suit = suit;
            this.WrittenSuit = writeSuit(suit);
        }
        private string writeSuit(char suit)
        {
            char s = suit.ToString().ToUpper()[0];
            switch (s)
            {
                case 'H':
                    return "Hearts";
                case 'S':
                    return "Spades";
                case 'C':
                    return "Clubs";
                case 'D':
                    return "Diamonds";
                default:
                    return "Undefined";
            }
        }

        public char Suit { get; set; }
        public string WrittenSuit { get; }
    }

    public class CardValue
    {
        public CardValue(char val)
        {
            this._high = 'K';
            this.Value = val;
            this.WrittenValue = writeValue(val);
            this.OrderedValue = orderValue(val);
        }

        /// <summary>
        /// Return the string equivalent of the character value
        /// </summary>
        /// <param name="val">Character value</param>
        /// <returns></returns>
        private string writeValue(char val)
        {
            char v = val.ToString().ToUpper()[0];
            switch (v)
            {
                case 'A':
                    return "Ace";
                case '2':
                    return "Two";
                case '3':
                    return "Three";
                case '4':
                    return "Four";
                case '5':
                    return "Five";
                case '6':
                    return "Six";
                case '7':
                    return "Seven";
                case '8':
                    return "Eight";
                case '9':
                    return "Nine";
                case '0':
                    return "Ten";
                case 'J':
                    return "Jack";
                case 'Q':
                    return "Queen";
                case 'K':
                    return "King";
                default:
                    return "Joker";
            }
        }

        /// <summary>
        /// Return the ordered value of the card for comparison
        /// </summary>
        /// <param name="val">Character value</param>
        /// <param name="high">What Character is High</param>
        /// <returns></returns>
        private int orderValue(char val)
        {
            char v = val.ToString().ToUpper()[0];
            if (_high == 'A')
            {
                switch (v)
                {
                    case 'A':
                        return (int)AceHigh.Ace;
                    case '2':
                        return (int)AceHigh.Two;
                    case '3':
                        return (int)AceHigh.Three;
                    case '4':
                        return (int)AceHigh.Four;
                    case '5':
                        return (int)AceHigh.Five;
                    case '6':
                        return (int)AceHigh.Six;
                    case '7':
                        return (int)AceHigh.Seven;
                    case '8':
                        return (int)AceHigh.Eight;
                    case '9':
                        return (int)AceHigh.Nine;
                    case '0':
                        return (int)AceHigh.Ten;
                    case 'J':
                        return (int)AceHigh.Jack;
                    case 'Q':
                        return (int)AceHigh.Queen;
                    case 'K':
                        return (int)AceHigh.King;
                    default:
                        return (int)AceHigh.Joker;
                }
            }
            else if (_high == '2')
            {
                switch (v)
                {
                    case 'A':
                        return (int)TwoHigh.Ace;
                    case '2':
                        return (int)TwoHigh.Two;
                    case '3':
                        return (int)TwoHigh.Three;
                    case '4':
                        return (int)TwoHigh.Four;
                    case '5':
                        return (int)TwoHigh.Five;
                    case '6':
                        return (int)TwoHigh.Six;
                    case '7':
                        return (int)TwoHigh.Seven;
                    case '8':
                        return (int)TwoHigh.Eight;
                    case '9':
                        return (int)TwoHigh.Nine;
                    case '0':
                        return (int)TwoHigh.Ten;
                    case 'J':
                        return (int)TwoHigh.Jack;
                    case 'Q':
                        return (int)TwoHigh.Queen;
                    case 'K':
                        return (int)TwoHigh.King;
                    default:
                        return (int)TwoHigh.Joker;
                }
            }
            else // default to King high (high == 'K')
            {
                switch (v)
                {
                    case 'A':
                        return (int)KingHigh.Ace;
                    case '2':
                        return (int)KingHigh.Two;
                    case '3':
                        return (int)KingHigh.Three;
                    case '4':
                        return (int)KingHigh.Four;
                    case '5':
                        return (int)KingHigh.Five;
                    case '6':
                        return (int)KingHigh.Six;
                    case '7':
                        return (int)KingHigh.Seven;
                    case '8':
                        return (int)KingHigh.Eight;
                    case '9':
                        return (int)KingHigh.Nine;
                    case '0':
                        return (int)KingHigh.Ten;
                    case 'J':
                        return (int)KingHigh.Jack;
                    case 'Q':
                        return (int)KingHigh.Queen;
                    case 'K':
                        return (int)KingHigh.King;
                    default:
                        return (int)KingHigh.Joker;
                }
            }
        }


        public char Value { get; set; }
        public string WrittenValue { get; }
        public int OrderedValue { get; set; }

        private char _high;
        public char HighestValue
        {
            get
            {
                return this._high;
            }
            set
            {
                this._high = value;
                this.OrderedValue = orderValue(this.Value);
            }
        }

        public enum AceHigh
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace,
            Joker // #13
        }
        public enum KingHigh
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Joker // #13
        }
        public enum TwoHigh
        {
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace,
            Two,
            Joker // #13
        }
    }
}
