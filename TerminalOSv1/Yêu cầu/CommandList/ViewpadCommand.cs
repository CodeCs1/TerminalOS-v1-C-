using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TerminalOSv1.Command.CommandList
{
    public class ViewpadCommand:Command
    {
        public ViewpadCommand(String name) : base(name)
        {

        }
        public override string execute(string[] arguments) //viewpad <filename>
        {
            string response = "";
            if (arguments.Length != 0)
            {
                Console.WriteLine(@"***********ViewPad*************
[Press anykey to quit this application]");
                try
                {
                    /*
                    FileStream fs = (FileStream)Cosmos.System.FileSystem.VFS.VFSManager.GetFile(arguments[0]).GetFileStream();
                    if (fs.CanRead)
                    {
                        Byte[] data = new byte[256];

                        fs.Read(data, 0, data.Length);

                        response = Encoding.ASCII.GetString(data);
                        if (response == string.Empty)
                        {
                            Console.WriteLine("String is empty!");
                        }
                    }
                    else
                    {
                        response = "Error: file not exist or can't write cuz admin\nFilename = '" + arguments[1] + "'";
                    }
                    */
                    response = File.ReadAllText("0:\\" + arguments[0]);
                }
                catch (Exception ex)
                {
                    Kernel.BSOD(ex.Message);
                }
            }
            else
            {
                response = "[Error]: File name must be specified";
            }
            return response;
        }
    }
}
