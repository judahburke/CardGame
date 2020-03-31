using CardGame.Core;
using CardGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Helpers.Solitaire.ConsoleApp
{
    public class CardActions
    {
        public static void Move(Stack<Card> source, Stack<Card> destination)
        {
            try
            {
                destination.Push(source.Pop());
            }
            catch (Exception)
            {
                //Serilog.Log.Verbose("Whoops, tried to push top of {Source} to {Destination}", source, destination);
            }
        }

        public static bool Compare(Stack<Card> source, Stack<Card> destination)
        {
            try
            {
                return CardLogic.AreCompatible(source.Peek(), destination.Peek());
            }
            catch (Exception)
            {
                //Serilog.Log.Warning("Whoops, tried to compare top of {Source} with {Destination}", source, destination);
            }
            return false;
        }

        public static bool Compare(Card source, Card destination)
        {
            try
            {
                return CardLogic.AreCompatible(source, destination);
            }
            catch (Exception)
            {
                //Serilog.Log.Warning("Whoops, tried to compare {Source} with {Destination}", source, destination);
            }
            return false;
        }
    }
}
