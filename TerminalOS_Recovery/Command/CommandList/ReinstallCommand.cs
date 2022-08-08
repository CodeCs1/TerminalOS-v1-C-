using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOS_Recovery.Command.CommandList
{
    public class ReinstallCommand:Command
    {
        public ReinstallCommand (string name):base(name) { }
        public override string execute(string[] arguments)
        {
            string response = "";

            Console.Clear();
            Console.WriteLine("Welcome to TerminalOS installer");
            if (arguments.Length != 0)
            {
                if (arguments[0] == "-r")
                {
                    Console.WriteLine("You have choose the reinstall command, delete config file is by default, do you want to continue ?");
                    Console.WriteLine("(Y/N)");
                    ConsoleKeyInfo info;
                    ConsoleKey keys;
                    do
                    {
                        info = Console.ReadKey(true);
                        keys = info.Key;
                        if (keys == ConsoleKey.Y)
                        {
                            Console.WriteLine("Reinstalling in progress...");
                            Console.Write("User Config file ->");
                            try
                            {
                                Cosmos.System.FileSystem.VFS.VFSManager.DeleteFile("0:\\UserConfig.cfg");
                                Console.Write(" Password Config file.");
                                try
                                {
                                    Cosmos.System.FileSystem.VFS.VFSManager.DeleteFile("0:\\PasswordConfig.cfg");
                                    Console.WriteLine("Reinstall completed successfully, please reboot your system. [and plug your usb or your cd-rom]\nFor VM just select terminalOS iso file\n");
                                    break;
                                }catch (Exception ex)
                                {
                                    Kernel.BSOD(ex.Message);
                                }
                            }
                            catch (Exception ex)
                            {
                                Kernel.BSOD(ex.Message);
                            }
                        }
                    } while (keys != ConsoleKey.Y || keys != ConsoleKey.N);
                }


            }
            return response;
        }
    }
}
