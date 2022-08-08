using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOSv1.Command.CommandList
{
    public class ShutdownCommand:Command
    {

        public ShutdownCommand(String name):base(name)
        {

        }

        public override string execute(string[] arguments)
        {
            Cosmos.System.Power.Shutdown();
            return "Shutdown completed!";
        }
    }
}
