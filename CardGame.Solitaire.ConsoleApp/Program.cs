using CardGame.Core;
using CardGame.Core.Models;
using CardGame.Helpers;
using CardGame.Helpers.Solitaire.ConsoleApp;
using System;
using System.Threading;
using System.Collections.Generic;

namespace CardGame.Solitaire.ConsoleApp
{
    class Program
    {
        internal static Tableu MyTableu = null;
        internal static bool IsGameStarted;

        static void Main(string[] args)
        {
            LogHelper.ConfigureLog();
            Print.ConfigurePrint(TextLanguage.English, MyTableu);
            Print.Game(true);
            IsGameStarted = false;
            var key = new ConsoleKeyInfo();
            while (true)
            {
                try
                {
                    Print.SetMsgLocation(true);
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.N)
                    { NewGame(); continue; }
                    if (IsGameStarted && key.Key == ConsoleKey.D)
                    { Deal(); continue; }
                    if (IsGameStarted && key.Key == ConsoleKey.H)
                    { GetHint(); continue; }
                    if (IsGameStarted && int.TryParse(key.KeyChar.ToString(), out int n))
                    { Terrace(n); continue; }
                    if (key.Key == ConsoleKey.Escape)
                    { break; }
                    continue;
                }
                catch (Exception ex)
                {
                    Serilog.Log.Error(ex, "Game error with key {Key} and Tableu {Tableu}", key.Key, MyTableu);
                    Print.Alert(ex.Message);
                }
            }
            Print.Final();
        }

        public static void NewGame()
        {
            MyTableu = new Tableu();
            MyTableu.UndealtStack = new Stack<ICard>(Dealer.ShuffledDeck(10));
            for (int i = 0; i < MyTableu.TerraceCount; i++) // Get 5 Cards...
                foreach (var terraceStack in MyTableu.TerraceStackList) // // For each PileStack...
                    CardActions.Move(MyTableu.UndealtStack, terraceStack); // And Push Cards From UndealtStack
            CardActions.Move(MyTableu.UndealtStack, MyTableu.DealtStack);
            IsGameStarted = true;
            Print.Game(false);
        }
        public static void Deal()
        {
            if (MyTableu.UndealtStack.Count == 0)
                { Print.Alert(Text.DeckEmpty); return; }
            CardActions.Move(MyTableu.UndealtStack, MyTableu.DealtStack);
            Print.Game(false);
        }
        public static void Terrace(int index)
        {
            if (index < 0 || index >= MyTableu.TerraceCount
                || !CardActions.Compare(MyTableu.TerraceStackList[index], MyTableu.DealtStack))
            { Print.Alert(Text.InvalidCard); return; }
            CardActions.Move(MyTableu.TerraceStackList[index], MyTableu.DealtStack);


            foreach (var terrace in MyTableu.TerraceStackList)
                if (terrace.Count > 0)
                    { Print.Game(false); return; }
            IsGameStarted = false;
            Print.Game(false);
            Print.Note(Text.YouWin);
        }
        public static void GetHint()
        {
            for (var t=0;t<MyTableu.TerraceCount;t++)
                if (CardActions.Compare(MyTableu.TerraceStackList[t].Peek(), MyTableu.DealtStack.Peek()))
                    { Print.Note(string.Format(Text.HintValue, t)); return; }

            if (MyTableu.UndealtStack.Count > 0)
                { Print.Note(Text.DealAgain); return; }
            IsGameStarted = false;
            Print.Game(false);
            Print.Note(Text.YouLose);
        }

    }
}
