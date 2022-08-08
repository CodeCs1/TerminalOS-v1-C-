using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOS_Recovery.Command.CommandList
{
    public class NeofetchCommand:Command
    {
        public NeofetchCommand(String name):base(name)
        {

        }

        public override string execute(string[] arguments)
        {
            if (Kernel.TerminalOSVersion == "termv1")
            {
                Console.WriteLine("###############   TerminalOS@Root ");
                Console.WriteLine("####`##########   -------------------");
                Console.WriteLine("#####`#########   OS: TerminalOS Recovery version 1");
                Console.WriteLine("####`#`````####   Kernel: Cosmos C#");
                Console.WriteLine("###############   Uptime: " + DateTime.Today.Second + " secs");
                Console.WriteLine("                  Packages: Not updated yet (instzip)");
                Console.WriteLine("                  Terminal: Not updated yet");
                Console.WriteLine("                  Cpu: Not updated yet");
                Console.WriteLine("                  Memory: Not updated yet");
                Console.WriteLine("Disk (0:\\): " + Kernel.collecting_drive_space);
            }
            return "";
        }
    }
}
