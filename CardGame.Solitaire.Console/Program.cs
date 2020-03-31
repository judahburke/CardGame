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
            CardLogic.Rules = new CardRules(); // todo: set up card rules for game
            Print.ConfigurePrint(TextLanguage.English);
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
                    //Serilog.Log.Error(ex, "Game error with key {Key} and Tableu {Tableu}", key.Key, MyTableu); // todo: add error string
                    Print.Alert(ex.Message);
                }
            }
            Print.Final();
        }

        public static void NewGame()
        {
            MyTableu = new Tableu();
            for (int i = 0; i < MyTableu.TerraceCount; i++) // Get 5 Cards...
                foreach (var terrace in MyTableu.TerraceList) // // For each PileStack...
                    CardActions.Move(MyTableu.UndealtCards, terrace); // And Push Cards From UndealtStack
            CardActions.Move(MyTableu.UndealtCards, MyTableu.DealtCards);
            IsGameStarted = true;
            Print.Game(false);
        }
        public static void Deal()
        {
            if (MyTableu.UndealtCards.Count == 0)
                { Print.Alert(Text.DeckEmpty); return; }
            CardActions.Move(MyTableu.UndealtCards, MyTableu.DealtCards);
            Print.Game(false);
        }
        public static void Terrace(int index)
        {
            if (index < 0 || index >= MyTableu.TerraceCount
                || !CardActions.Compare(MyTableu.TerraceList[index], MyTableu.DealtCards))
            { Print.Alert(Text.InvalidCard); return; }
            CardActions.Move(MyTableu.TerraceList[index], MyTableu.DealtCards);


            foreach (var terrace in MyTableu.TerraceList)
                if (terrace.Count > 0)
                    { Print.Game(false); return; }
            IsGameStarted = false;
            Print.Game(false);
            Print.Note(Text.YouWin);
        }
        public static void GetHint()
        {
            for (var t=0;t<MyTableu.TerraceCount;t++)
                if (CardLogic.AreCompatible(MyTableu.TerraceList[t].Peek(), MyTableu.DealtCards.Peek()))
                    { Print.Note(string.Format(Text.HintValue, t)); return; }

            if (MyTableu.UndealtCards.Count > 0)
                { Print.Note(Text.DealAgain); return; }
            IsGameStarted = false;
            Print.Game(false);
            Print.Note(Text.YouLose);
        }

    }
}
