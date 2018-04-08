using CardGame;
using CardGame.Core;
using System;
using System.IO;
using System.Collections.Generic;

namespace CardGame.General
{
    class Program
    {
        static void Main(string[] args)
        {
            startGame(2, 13);

            Console.Write("Thanks for playing, Enter to Exit... ");
            string again = Console.ReadLine();
            return;
        }


        static void startGame(int playerCount, int cardsPerHand)
        {
            Deck myDeck = new Deck();
            List<Hand> myHands = Dealer.Deal(playerCount, cardsPerHand, myDeck);
            List<Player> myPlayers = getPlayers(playerCount, myHands);

            playGame(myPlayers);
        }

        static List<Player> getPlayers(int count, List<Hand> hands)
        {
            List<Player> us = new List<Player>();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Player {0}, What's your name? ", i + 1);
                string name = Console.ReadLine();
                Player player = new Player(name, i + 1);
                player.Hand = hands[i];
                player.Hand.Player = new KeyValuePair<int, string>(i + 1, name);

                us.Add(player);
            }
            return us;
        }

        static void playGame(List<Player> myPlayers)
        {
            Console.WriteLine("We are just practicing, so show your hands...");
            foreach (Player p in myPlayers)
            {
                Console.WriteLine("Player {0}: {1}'s cards are as follows", p.Order, p.Name);
                foreach (Card c in p.Hand.Cards)
                {
                    Console.WriteLine("\t{0}", c.WriteCard());
                }
            }
        }
    }
}
