using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOS_Recovery.Command
{
    public class Command
    {
        public readonly string name;

        public Command(string name)
        {
            this.name = name;
        }

        public virtual string execute(String[] arguments)
        {
            return "";
        }
    }
}
