using CardGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Helpers.Solitaire.ConsoleApp
{
    public class CardActions
    {
        public static void Move(Stack<ICard> source, Stack<ICard> destination)
        {
            try
            {
                destination.Push(source.Pop());
            }
            catch (Exception)
            {
                Serilog.Log.Verbose("Whoops, tried to push top of {Source} to {Destination}", source, destination);
            }
        }

        public static bool Compare(Stack<ICard> source, Stack<ICard> destination)
        {
            try
            {
                var srcValue = (int)source.Peek().Value;
                var dstValue = (int)destination.Peek().Value;
                var wild = (int)CardValue.Joker;

                if ((srcValue + 1) % 13 == dstValue % 13 || (srcValue - 1) % 13 == dstValue % 13)
                    return true;
                if (srcValue == wild || dstValue == wild)
                    return true;
            }
            catch (Exception)
            {
                Serilog.Log.Verbose("Whoops, tried to compare top of {Source} with {Destination}", source, destination);
            }
            return false;
        }

        public static bool Compare(ICard source, ICard destination)
        {
            try
            {
                var srcValue = (int)source.Value;
                var dstValue = (int)destination.Value;
                var wild = (int)CardValue.Joker;

                if ((srcValue + 1) % 13 == dstValue % 13 || (srcValue - 1) % 13 == dstValue % 13)
                    return true;
                if (srcValue == wild || dstValue == wild)
                    return true;
            }
            catch (Exception)
            {
                Serilog.Log.Verbose("Whoops, tried to compare {Source} with {Destination}", source, destination);
            }
            return false;
        }
    }
}
