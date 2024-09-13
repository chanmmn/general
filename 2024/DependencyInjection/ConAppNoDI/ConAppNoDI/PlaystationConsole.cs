using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppNoDI
{
    internal class PlaystationConsole
    {
        
        GameLoader gameLoader = new GameLoader("God of War");
        //public PlaystationConsole(GameLoader gameLoaderr)
        //{
        //    this.gameLoader = gameLoaderr;
        //}

        public void Play()
        {
            gameLoader.Load();
        }
    }
}
