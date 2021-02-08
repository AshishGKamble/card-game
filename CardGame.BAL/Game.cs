using CardGame.Entities;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;

namespace CardGame.BAL
{
    /// <summary>
    /// Written By : Ashish Kamble
    /// Summary : Class have functions related to the gameplay
    /// </summary>
    public class Game : IGamePlay
    {
        private static readonly IDeck deck;

        /// <summary>
        /// Constructor the resolve the dependencies
        /// </summary>
        static Game()
        {
            Console.SetWindowSize(80, 50);

            deck = new Deck();
        }

        /// <summary>
        /// Function to display the game menu to user
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine("\n\nPlease select one of the following options :");
            Console.WriteLine("Enter d to draw the card");
            Console.WriteLine("Enter s to shuffle the deck");
            Console.WriteLine("Enter p to print the deck");
            Console.WriteLine("Enter r to restart the game");
            Console.WriteLine("Enter x to exit the game");
        }

        /// <summary>
        /// Function to print the given deck of cards
        /// </summary>
        /// <param name="cardDeck"></param>
        public void PrintDeck(Queue<Card> cardDeck)
        {
            Console.WriteLine(String.Concat("\nPrinting the Deck of Cards of size => ", cardDeck.Count));

            try
            {
                foreach (var card in cardDeck)
                {
                    Console.Write(string.Concat(card.DisplayName, " "));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Function to play the card game
        /// </summary>
        public void Play()
        {
            bool exitGame = false;

            Console.WriteLine("Welcome to the Game of Cards!!");

            try
            {
                #region create and print the deck for first time           
                var cardDeck = deck.CreateDeck();
                PrintDeck(cardDeck);
                DisplayMenu();
                #endregion

                #region Code to play the game. Select user entered options and process them
                while (exitGame == false)
                {
                    #region if game is already ended return from here
                    exitGame = IsEndOfGame(cardDeck);

                    if (exitGame)
                    {
                        Console.ReadKey();
                        return;
                    }
                    #endregion

                    switch (Console.ReadLine())
                    {
                        case "d": // Draw a card from deck
                            var firstCard = cardDeck.Dequeue();
                            Console.WriteLine("\nCard played is => " + firstCard.DisplayName);
                            break;
                        case "s": // Shuffle the deck
                            cardDeck = deck.ShuffleDeck(cardDeck);
                            PrintDeck(cardDeck);
                            break;
                        case "p": // print the deck                        
                            PrintDeck(cardDeck);
                            break;
                        case "r": // Restart the game
                            Console.WriteLine("\n***** Restarting the Game *****");
                            cardDeck = deck.CreateDeck();
                            PrintDeck(cardDeck);
                            DisplayMenu();
                            break;
                        case "x": // Exit the game
                            Console.WriteLine("\nThanks for playing the game!!");
                            exitGame = true;
                            break;
                        default:
                            Console.WriteLine("\nPlease select a valid option!!");
                            break;
                    }

                    if (!exitGame)
                        DisplayMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured in playing game");
                Console.WriteLine(ex.Message);
            }
            #endregion
        }

        /// <summary>
        /// Function to check if game ended
        /// </summary>
        /// <param name="cardDeck"></param>
        /// <returns></returns>
        public bool IsEndOfGame(Queue<Card> cardDeck)
        {
            bool isGameEnded = false;

            if (cardDeck.Count == 0)
            {
                Console.WriteLine("\nDeck is Empty !!");
                Console.WriteLine("***** End of Game *****");
                isGameEnded = true;
            }

            return isGameEnded;
        }


    } // End of class
}   // End of namespace
