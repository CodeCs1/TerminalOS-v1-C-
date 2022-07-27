using System;
using TerminalOSv1.Graphics;

namespace TerminalOSv1.Command.CommandList
{
    public class StartGuiCommand:Command
    {
        public StartGuiCommand(string name):base(name) { }

        public override string execute(string[] arguments)
        {
            GraphicsUserInterface.Initialize();
            return "";
        }
    }
}
