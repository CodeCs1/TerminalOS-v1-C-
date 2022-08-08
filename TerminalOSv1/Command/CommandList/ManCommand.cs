using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOSv1.Command.CommandList
{
    public class ManCommand:Command
    {
        public ManCommand(string name):base(name) { }

        public override string execute(string[] arguments)
        {
            string response = "";
            if (arguments.Length != 0)
            {
                if (arguments[0] == "--help")
                { 
                    response = @"
Man (Manual utils) - an system's manual pager

How to use:
    Man <command name>

man is the system's  manual pager.  Each page argument given to man is normally the name of a program, utility or function.  The manual page associated
with each of these arguments is then found and displayed.A section, if provided, will direct man to look only in that section of the  manual.The de‐
fault action  is to search in all of the available sections following a pre-defined order(see DEFAULTS), and to show only the first page found, even if
page exists in several sections.
";
                }
                #region list of command manual!

                else if (arguments[0] == "dir")
                {
                    response = @"dir (directory) - a system's directory lister application

How to use:
    dir <directory name>

dir is the system's directory lister application. This application will show all file and folder in arguments =)
<Too lazy to make this <man dir>>";
                }
                else if (arguments[0] == "SystemIO")
                {
                    response = @"SystemIO - a command line create, delete, write file (folder), by location arguments

How to use:
    SystemIO -w <file> <text> : Write file into 0:\ [edited]
    SystemIO -c [file | directory] <name or location> : Create new file or folder into 0:\ [make empty file or folder]
    SystemIO -r [file | directory] <name or location> : Remove exist file or folder in 0:\ [remove]

SystemIO (aka: System Input\Output) is the system's commmand line can create, delete, write file (folder), by location arguments
sometime this application has some error code like: index out of bounds, Can't create file (folder), ...";
                }
                #endregion
            }
            else
            {
                response = "Error: Arguments is need.";
            }
            return response;
        }
    }
}
