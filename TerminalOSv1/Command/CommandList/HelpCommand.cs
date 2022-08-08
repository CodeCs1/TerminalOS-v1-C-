using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOSv1.Command.CommandList
{
    public class HelpCommand : Command
    {

        public HelpCommand(String name) : base(name) { }

        public override string execute(string[] arguments)
        {
            string response = "";
            response = "TerminalOS help ultities: \nHelp: show this help\nMan <command>: show command help menu\nSystemIO <Setting>: System Input/Output Application (To create, delete file and folder (write in file))\nShutdown: Halt machine\nReboot: restart machine\ndir <dirname>:List File and Folder\nsysteminfo: show your pc and os infomation\nclear: Clear the screen\n\nFor more infomation, please type man <command>";
            return response;
        }
    }
}
