using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalOSv1.Games;

namespace TerminalOSv1.Command.CommandList
{
    public class TouhouGameCommand:Command
    {
        public TouhouGameCommand(string name):base(name)
        {

        }
        public override string execute(string[] arguments)
        {
            TouhouConsole.StartGame(string.Empty);
            return "Run Completed!";
        }
    }
}
