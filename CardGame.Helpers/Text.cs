using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Helpers
{
    public enum TextLanguage { English, Spanish, French, Vietnamese }

    public class Text
    {
        public static void SetTextLanguage(TextLanguage lang)
        {
            switch (lang)
            {
                case TextLanguage.English:
                    _welcome = "Welcome to Towers, Vol 1 of Judah's Card Games";
                    _hintValue = "Try terrace #{0}. ";
                    _invalidCard = "Whoops, That card is invalid. ";
                    _noMoves = "Whoops, you have no more moves. ";
                    _dealAgain = "Sorry, no moves. Deal again?";
                    _deckEmpty = "Whoops, the deck is empty. ";
                    _youWin = "Fantastic! You won! ";
                    _youLose = "Whoops, no moves. You lose this time. ";
                    _tryAgain = "Try again? ";
                    _replay = "Retry this game? "; //todo: (Future DEV) backup tableu
                    _thanks = "Thanks for playing, play again soon ";
                    _finalQuit = "Press any key to exit... ";

                    _alertInvalid = "INVALID";
                    _btnNewGame = "New Game";
                    _btnNewGameDesc = "Start new game";
                    _btnHint = "Get Hint";
                    _btnHintDesc = "Suggest Move";
                    _btnDealDesc = "Deal card";
                    _btnCardDesc = "Play card";
                    _btnQuitDesc = "Quit game";
                    break;
                case TextLanguage.Spanish:
                    break;
                case TextLanguage.French:
                    break;
                case TextLanguage.Vietnamese:
                    break;
                default:
                    break;
            }
        }

        private static string _welcome;
        private static string _hintValue;
        private static string _invalidCard;
        private static string _noMoves;
        private static string _dealAgain;
        private static string _deckEmpty;
        private static string _youWin;
        private static string _youLose;
        private static string _tryAgain;
        private static string _replay;
        private static string _thanks;
        private static string _finalQuit;

        private static string _alertInvalid;
        private static string _btnNewGame;
        private static string _btnNewGameDesc;
        private static string _btnHint;
        private static string _btnHintDesc;
        private static string _btnDealDesc;
        private static string _btnCardDesc;
        private static string _btnQuitDesc;


        public static string Welcome { get => _welcome; }
        public static string HintValue { get => _hintValue; }
        public static string InvalidCard { get => _invalidCard; }
        public static string NoMoves { get => _noMoves; }
        public static string DealAgain { get => _dealAgain; }
        public static string DeckEmpty { get => _deckEmpty; }
        public static string YouWin { get => _youWin; }
        public static string YouLose { get => _youLose; }
        public static string TryAgain { get => _tryAgain; }
        public static string Replay { get => _replay; }
        public static string Thanks { get => _thanks; }
        public static string FinalQuit { get => _finalQuit; }

        public static string AlertInvalid { get => _alertInvalid; }
        public static string BtnNewGame { get => _btnNewGame; }
        public static string BtnNewGameDesc { get => _btnNewGameDesc; }
        public static string BtnHint { get => _btnHint; }
        public static string BtnHintDesc { get => _btnHintDesc; }
        public static string BtnDealDesc { get => _btnDealDesc; }
        public static string BtnCardDesc { get => _btnCardDesc; }
        public static string BtnQuitDesc { get => _btnQuitDesc; }
    }

}
