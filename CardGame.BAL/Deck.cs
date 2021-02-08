using CardGame.Entities;
using CardGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.BAL
{
    /// <summary>
    /// Written By : Ashish G. Kamble
    /// Summary : Class to implement functionality of the deck of cards
    /// </summary>
    public class Deck : IDeck
    {
        public Deck()
        {
        }

        public Queue<Card> CreateDeck()
        {
            Console.WriteLine("\nCreating the deck!!");

            Queue<Card> cards = new Queue<Card>();

            try
            {
                for (int i = 2; i <= 14; i++)
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        cards.Enqueue(new Card()
                        {
                            Suit = suit,
                            Value = i,
                            DisplayName = GetShortName(i, suit)
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return ShuffleDeck(cards);
        }


        /// <summary>
        /// Written By : Ashish Kamble
        /// Summary : Function to shuffle the given card deck
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public Queue<Card> ShuffleDeck(Queue<Card> cards)
        {
            Queue<Card> shuffledCards = null;

            Console.WriteLine("\nShuffling the deck!!");

            //Shuffle the existing cards
            IList<Card> transformedCards = cards.ToList();

            Random r = new Random(DateTime.Now.Millisecond);

            try
            {
                for (int n = transformedCards.Count - 1; n > 0; --n)
                {
                    //Step 2: Randomly pick a card which has not been shuffled
                    int k = r.Next(n + 1);

                    //Step 3: Swap the selected item 
                    //        with the last "unselected" card in the collection
                    Card temp = transformedCards[n];
                    transformedCards[n] = transformedCards[k];
                    transformedCards[k] = temp;
                }

                shuffledCards = new Queue<Card>();

                foreach (var card in transformedCards)
                {
                    shuffledCards.Enqueue(card);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return shuffledCards;
        }


        /// <summary>
        /// Function to get the short name for the given card
        /// </summary>
        /// <param name="value">value associated for the given card</param>
        /// <param name="suit">Type of card</param>
        /// <returns></returns>
        private static string GetShortName(int value, Suit suit)
        {
            string valueDisplay = "";

            if (value >= 2 && value <= 10)
            {
                valueDisplay = value.ToString();
            }
            else if (value == 11)
            {
                valueDisplay = "J";
            }
            else if (value == 12)
            {
                valueDisplay = "Q";
            }
            else if (value == 13)
            {
                valueDisplay = "K";
            }
            else if (value == 14)
            {
                valueDisplay = "A";
            }

            return valueDisplay + Enum.GetName(typeof(Suit), suit)[0];
        }
    }
}
