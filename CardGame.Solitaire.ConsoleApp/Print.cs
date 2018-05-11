using CardGame.Core.Models;
using CardGame.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Solitaire.ConsoleApp
{
    public static class Print
    {
        private static readonly int MsgTab = 5;
        private static readonly int MsgLine = 3;
        private static readonly int EndLine = 17;


        public static void ConfigurePrint(TextLanguage language = TextLanguage.English)
        {
            Text.SetTextLanguage(language);
            Console.SetWindowSize(101, 20);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
        public static void SetMsgLocation(bool readNew = false) { Console.SetCursorPosition(readNew ? 0 : MsgTab, MsgLine); }
        public static void SetEndLocation() { Console.SetCursorPosition(0, EndLine); }
        

        public static void Game(bool newGame = false)
        {
            if (newGame)
            {
                Console.Clear();
                Console.WriteLine(Text.Welcome);
                Console.WriteLine();
                Directions(true);
                Console.Write("\n\n");
            }
            else
            {
                Console.Clear();
                Directions();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                if (Program.MyTableu != null) AllCards();
                else throw new Exception(string.Format(Text.AlertNullObject,$"{Program.MyTableu}"));
            }
        }
        public static void Directions(bool newGame = false)
        {
            int l = 18, r = 20;
            bool canDeal = Program.MyTableu?.UndealtStack.Count > 0;
            var dir = string.Empty;
            dir += $"(N) {Text.BtnNewGame}".PadLeft(l).PadRight(r);
            if (!newGame && canDeal) dir += $"(D) {Text.BtnDealDesc}".PadLeft(l).PadRight(r);
            if (!newGame) dir += $"(1-5) {Text.BtnCardDesc}".PadLeft(l).PadRight(r);
            if (!newGame) dir += $"(H) {Text.BtnHint}".PadLeft(l).PadRight(r);
            dir += $"(ESC) {Text.BtnQuitDesc}".PadLeft(l).PadRight(r);
            Console.WriteLine(dir);
        }
        public static void AllCards()
        {
            int width = 100,
                r = width / Program.MyTableu.TerraceCount,
                l = r * 3 / 4,
                i = 0;
            string terraces = string.Empty
                , terraceHeader = string.Empty
                , dealdiscard = string.Empty
                , dealdiscardHeader = string.Empty;

            // Write Terraces to screen
            foreach (var t in Program.MyTableu.TerraceStackList)
            {
                terraceHeader += $"#{i++} ({t.Count} left)".ToString().PadLeft(l).PadRight(r);   
                if (t.Count > 0)
                    terraces += CardString(t.Peek()).PadLeft(l).PadRight(r);
                else
                    terraces += CardString(null).PadRight(r);
            }
            Console.WriteLine(terraceHeader);
            Console.WriteLine(terraces);

            // Space between the two
            Console.WriteLine();
            Console.WriteLine();

            // Write Undealt/Dealt or Deal/Discard to screen
            dealdiscardHeader = "Discard".PadLeft(width / 3).PadRight(width / 2) 
                + "Deal".PadRight(width / 3).PadLeft(width / 2);
            dealdiscard = CardString(Program.MyTableu.DealtStack.Peek()).PadLeft(width / 3).PadRight(width / 2)
                + $"[{Program.MyTableu.UndealtStack.Count}]".PadRight(width / 3).PadLeft(width / 2);
            Console.WriteLine(dealdiscardHeader);
            Console.WriteLine(dealdiscard);
        }


        public static void Note(string message)
        {
            SetMsgLocation();
            Console.Write(message.PadRight(Console.BufferWidth - MsgTab));
        }
        public static void Alert(string message)
        {
            SetMsgLocation();
            Console.Write($"{Text.AlertInvalid} - {message}".PadRight(Console.BufferWidth - MsgTab));
        }
        public static void Final(string message = null)
        {
            SetEndLocation();
            Console.WriteLine(message ?? Text.Thanks);
            Console.WriteLine(Text.FinalQuit);
            Console.ReadKey();
            Console.Clear();
        }


        public static string CardString(ICard card = null)
        {
            var suitval = "";
            if (card == null)
                return "    ";
            switch (card.Suit)
            {
                case Core.Models.CardSuit.Clubs:
                    suitval += '\u2663'; break; // \u2663 &#9827; CLEAR -> \u2667, &#9831;
                case Core.Models.CardSuit.Diamonds:
                    suitval += '\u2666'; break; // \u2666 &#9830; CLEAR -> \u2662, &#9826;
                case Core.Models.CardSuit.Hearts:
                    suitval += '\u2665'; break; // \u2665 &#9829; CLEAR -> \u2661, &#9825;
                case Core.Models.CardSuit.Spades:
                    suitval += '\u2660'; break; // \u2660 &#9824; CLEAR -> \u2664, &#9828;
                default:
                    break;
            }
            switch (card.Value)
            {
                case Core.Models.CardValue.Ace: suitval += " A "; break;
                case Core.Models.CardValue.Two: suitval += " 2 "; break;
                case Core.Models.CardValue.Three: suitval += " 3 "; break;
                case Core.Models.CardValue.Four: suitval += " 4 "; break;
                case Core.Models.CardValue.Five: suitval += " 5 "; break;
                case Core.Models.CardValue.Six: suitval += " 6 "; break;
                case Core.Models.CardValue.Seven: suitval += " 7 "; break;
                case Core.Models.CardValue.Eight: suitval += " 8 "; break;
                case Core.Models.CardValue.Nine: suitval += " 9 "; break;
                case Core.Models.CardValue.Ten: suitval += "10 "; break;
                case Core.Models.CardValue.Jack: suitval += " J "; break;
                case Core.Models.CardValue.Queen: suitval += " Q "; break;
                case Core.Models.CardValue.King: suitval += " K "; break;
                case Core.Models.CardValue.Joker: suitval += " W "; break;
                default: break;
            }
            return suitval;
        }
        public static string CardBack(Stack<ICard> stack)
        {
            return $"[{stack.Count.ToString("00")}]";
        }

    }
}
