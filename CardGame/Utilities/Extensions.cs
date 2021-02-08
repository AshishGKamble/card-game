using CardGame.Entities;
using System.Collections.Generic;

namespace CardGame.UI.Utilities
{
    /// <summary>
    /// Written By : Ashish Kamble
    /// Summary : Class holds extension methods related to the card deck
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// This function will add the set of cards into the existing card deck
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="newCards"></param>
        public static void Enqueue(this Queue<Card> cards, Queue<Card> newCards)
        {
            foreach (var card in newCards)
            {
                cards.Enqueue(card);
            }
        }
    }
}
