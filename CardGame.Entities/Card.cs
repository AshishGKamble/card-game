
namespace CardGame.Entities
{
    /// <summary>
    /// Written By : Ashish Kamble
    /// Summary : Class to hold the card information
    /// </summary>
    public class Card
    {
        public string DisplayName { get; set; }
        public Suit Suit { get; set; }
        public int Value { get; set; }
    }
}
