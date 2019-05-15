using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            // Appelle la classe Game, la nomme "myGame", lance la classe Game. Lance CreateGame de myGame puis Run de myGame.
            Game myGame = new Game();
            myGame.CreateGame();
            myGame.Run();
        }
        
    }
}
