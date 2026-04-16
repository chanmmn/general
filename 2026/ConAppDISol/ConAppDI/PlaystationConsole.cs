using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppNoDI
{
    internal class PlaystationConsole
    {
        private readonly IGameLoader gameLoader;

        public PlaystationConsole(IGameLoader gameLoaderr)
        {
            this.gameLoader = gameLoaderr;
        }

        public void Play()
        {
            gameLoader.Load();
        }
    }
}
