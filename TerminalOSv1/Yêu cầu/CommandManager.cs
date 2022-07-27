using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalOSv1.Command.CommandList;

namespace TerminalOSv1.Command
{
    public class CommandManager
    {
        private List<Command> commands;
        public CommandManager()
        {
            this.commands = new List<Command>(1);
            this.commands.Add(new HelpCommand("help"));
            this.commands.Add(new FileCommand("SystemIO"));
            this.commands.Add(new ViewpadCommand("viewpad"));
            this.commands.Add(new ShutdownCommand("shutdown"));
            this.commands.Add(new RebootCommand("reboot"));
            this.commands.Add(new DirCommand("dir"));
            this.commands.Add(new ManCommand("man"));
            this.commands.Add(new MIVCommand("miv"));
            this.commands.Add(new StartGuiCommand("startx"));
            this.commands.Add(new echoCommand("echo"));
            this.commands.Add(new ipconfigCommand("ipconfig"));

            //games
            this.commands.Add(new TouhouGameCommand("th6e"));
        }

        public string processInputExample(string input)
        {
            string[] split = input.Split(' ');

            string label = split[0];
            List<String> args = new List<string>();

            int ctr = 0;

            foreach (String i in split) {

                if (ctr != 0) args.Add(i);
                ++ctr;
            }

            foreach(Command cmd in this.commands)
            {
                if (cmd.name==label)
                {
                    return cmd.execute(args.ToArray());
                }
            }

            return "Command '" + label + "' not exist, please type man <command> or help <command> or more details.";
        }
    }
}
