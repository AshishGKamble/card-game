using CardGame.Entities;
using System.Collections.Generic;

namespace CardGame.Interfaces
{
    /// <summary>
    /// Written By : Ashish Kamble
    /// Summary : Interface to expose the game functionality to client
    /// </summary>
    public interface IGame
    {
        void Play();
    }


    /// <summary>
    /// Written By : Ashish Kamble
    /// Summary : Interface have methods to implement the game functionality
    /// </summary>
    public interface IGamePlay : IGame
    {
        void DisplayMenu();
        void PrintDeck(Queue<Card> cardDeck);
        bool IsEndOfGame(Queue<Card> cardDeck);
    }
}
