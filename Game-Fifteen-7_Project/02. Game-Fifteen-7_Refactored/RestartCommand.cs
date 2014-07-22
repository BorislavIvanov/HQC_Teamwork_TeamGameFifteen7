using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteenVersionSeven
{
    public class RestartCommand : ICommand
    {

        public GameEngine GameEngine { get; set; }

        public RestartCommand(GameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }
        public void Execute()
        {
            this.GameEngine.StartNewGame();
        }
    }
}
