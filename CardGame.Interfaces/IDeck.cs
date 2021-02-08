using CardGame.Entities;
using System.Collections.Generic;

namespace CardGame.Interfaces
{
    /// <summary>
    /// Written By : Ashish Kamble
    /// Summary : Interface provides methods for the creation and manupulation of the cards.
    /// </summary>
    public interface IDeck
    {
        Queue<Card> CreateDeck();
        Queue<Card> ShuffleDeck(Queue<Card> cards);
    }
}
