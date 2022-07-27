﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOSv1.Command.CommandList
{
    public class RebootCommand:Command
    {
        public RebootCommand(string name):base (name)
        {

        }

        public override string execute(string[] arguments)
        {
            Cosmos.System.Power.Reboot();
            return "";
        }
    }
}
