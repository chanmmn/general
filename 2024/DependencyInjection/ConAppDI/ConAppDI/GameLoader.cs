using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppNoDI
{
    public class GameLoader
    {
        public string input { get; set; }

        public GameLoader()
        {
            Console.WriteLine("Enter the game you want to play: ");
        }
        public GameLoader(string input)
        {
            Console.WriteLine("Enter the game you want to play: ");
            this.input = input;
        }

        public void Load()
        {
            Console.WriteLine("Loadinging " + input);
        }
    }
}
