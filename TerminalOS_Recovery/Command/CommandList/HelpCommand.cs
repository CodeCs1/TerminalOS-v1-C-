using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOS_Recovery.Command.CommandList
{
    public class HelpCommand : Command
    {

        public HelpCommand(String name) : base(name) { }

        public override string execute(string[] arguments)
        {
            string response = "";


            if (string.IsNullOrEmpty(arguments[0]))
            {
                response = "TerminalOS help ultities: \nHelp: show this help\nMan: same as help\nSystemIO: System Input/Output Application (To create, delete file and folder (write in file))\nShutdown: Halt machine\nReboot: restart machine\ndir:List File and Folder";
            }
            else
            {
                response = "";
            }
            return response;
        }
    }
}
