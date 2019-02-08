using System;
using System.Collections.Generic;
using System.Text;
using CardGame.Core.Models;

namespace CardGame.Core
{
    public class CardRules
    {
        public CardRules(CardValue high = CardValue.Ace, CardSuit trump = CardSuit.None, 
            bool useJokers = false, bool useWilds = false, bool alternatingColor = false)
        {
            High = high;
            Trump = trump;
            UseJokers = useJokers;
            UseWilds = useWilds;
            AlternatingColor = alternatingColor;
        }

        public CardValue High;
        public CardSuit Trump;
        public bool UseWilds;
        public bool UseJokers;
        public bool AlternatingColor;
    }

    public static class CardLogic
    {
        private static CardRules _rules = null;
        public static CardRules Rules { get => _rules ?? new CardRules(); set => _rules = value; }

        public static bool AreEqualValue(Card a, Card b)
        {
            if (a.Value == b.Value) return true;
            if (Rules.UseWilds && (a.Value == CardValue.Joker || b.Value == CardValue.Joker)) return true;
            return false;
        }
        public static bool AreSameSuit(Card a, Card b)
        {
            if (a.Suit == b.Suit) return true;
            if (Rules.UseWilds && (a.Suit == CardSuit.None || b.Suit == CardSuit.None)) return true;
            return false;
        }
        public static Card Greater(Card a, Card b)
        {
            if (Rules.Trump != CardSuit.None && a.Suit != b.Suit)
            {
                if (a.Suit == Rules.Trump)
                    return a;
                if (b.Suit == Rules.Trump)
                    return b;
            }
            return (a.Value > b.Value) ? a : b; //todo: adapt to different high cards
        }
        public static bool AreCompatible(Card a, Card b)
        {
            int srcValue = (int)a.Value,
                dstValue = (int)b.Value,
                wild = Rules.UseWilds ? (int)CardValue.Joker : -1;
            if ((srcValue + 1) % 13 == dstValue % 13 || (srcValue - 1) % 13 == dstValue % 13)
                return true;
            if (srcValue == wild || dstValue == wild)
                return true;
            return false;
        }
    }
}
