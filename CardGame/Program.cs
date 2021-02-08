using CardGame.BAL;
using CardGame.Interfaces;

namespace CardGame.UI
{
    class Program
    {
        /// <summary>
        /// Written By : Ashish Kamble
        /// Summary : Entry point to the game
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create and start the game
            IGame game = new Game();            
            game.Play();           
        }
    }
}
