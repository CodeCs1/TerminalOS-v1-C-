using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOS_Recovery.Command.CommandList
{
    public class DirCommand:Command
    {
        public DirCommand(string name) : base(name)
        {

        }

        public override string execute(string[] arguments)
        {
            string response="";

            var FileList = System.IO.Directory.GetFiles(arguments[0]);

            var systemlabel = Kernel.collecting_system_label;

            Console.WriteLine("System Drive: 0:\\");
            Console.WriteLine("System Label: " + systemlabel);

            foreach (var file in FileList)
            {
                response = file;
            }
            return response;
        }
    }
}
