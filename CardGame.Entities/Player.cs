using System.Collections.Generic;

namespace CardGame.Entities
{
    /// <summary>
    /// Written By : Ashish Kamble
    /// Summary : Class to hold the player information
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> Deck { get; set; }
    }
}
