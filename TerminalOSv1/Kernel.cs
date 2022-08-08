using Cosmos.HAL;
using Cosmos.System.Network.Config;
using System;
using Sys = Cosmos.System;

namespace TerminalOSv1
{
    public class Kernel : Sys.Kernel
    {
        public enum Status
        {
            OK,
            WARNING,
            ERROR
        };

        public static string file;
        public void Message(string text, Status status)
        {
            string status_text;
            string empty = string.Empty;
            status_text = empty;
            if (status == Status.OK) status_text = "OK";
            if (status == Status.ERROR) status_text = "ERROR";
            if (status == Status.WARNING) status_text = "WARNING";

            Console.WriteLine("[" + status_text + "] " + text);
        }

        public void Message(string text)
        {
            Console.WriteLine(text);
        }


        public static long collecting_drive_space;
        public static string collecting_system_file;

        public static string collecting_system_label;
        public static string user;
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Welcome to TerminalOS!");
            System.Threading.Thread.Sleep(10000);
            Message("Enabling File System...");
            Sys.FileSystem.CosmosVFS FS = new Sys.FileSystem.CosmosVFS();
            try
            {
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(FS);
                Message("Enable File System Successfully", Status.OK);
                FS.Initialize(true);
                long collecting_drive_space1 = FS.GetAvailableFreeSpace("0:\\");
                string collecting_system_file1 = FS.GetFileSystemType("0:\\");

                var collecting_system_label1 = FS.GetFileSystemLabel("0:\\");

                collecting_drive_space = collecting_drive_space1;
                collecting_system_file = collecting_system_file1;
                collecting_system_label = collecting_system_label1;
            }catch (Exception ex)
            {
                Message("Enable File System Fail Successfully", Status.ERROR);
                BSOD(ex.Message);
            }
            Message("Connecting to Command Manager...");
            this.CommandManager = new Command.CommandManager();
            Message("Connect successfully!", Status.OK);

            Message("Connecting to network...");

            try
            {
                NetworkDevice nic = NetworkDevice.GetDeviceByName("eth0"); //get network device by name
                IPConfig.Enable(nic, new Sys.Network.IPv4.Address(192, 168, 1, 69), new Sys.Network.IPv4.Address(255, 255, 255, 0), new Sys.Network.IPv4.Address(192, 168, 1, 254)); //enable IPv4 configuration
                Message("Checking if network is exist...");
                IPConfig.FindNetwork(new Sys.Network.IPv4.Address(192, 168, 1, 69));
                Message("Connecting to network sucessfully!", Status.OK);
            }
            catch (Exception ex)
            {
                Kernel.BSOD(ex.Message);
            }

            if (!System.IO.File.Exists("0:\\UserConfig.cfg") && !System.IO.File.Exists("0:\\PasswordConfig.cfg"))
            {
                Console.Write("Please type your username here: ");
                string user = Console.ReadLine();
                Console.WriteLine("\nPlease type your password [Note: Empty password mean no password]");
                Console.WriteLine("Note that you CAN'T backspace the password you has been type.");
                Console.Write("Password: ");
                string password = string.Empty;
                ConsoleKey key;
                do
                {
                    var keyinfo = Console.ReadKey(intercept: true);
                    key = keyinfo.Key;

                    if (key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        Console.Write("\b");
                        password = password[0..^1];
                    }
                    else if (!char.IsControl(keyinfo.KeyChar))
                    {
                        Console.Write("*");
                        password += keyinfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);

                retypep(password, password);

                try
                {
                    Sys.FileSystem.VFS.VFSManager.CreateFile("0:\\UserConfig.cfg");
                    Sys.FileSystem.VFS.VFSManager.CreateFile("0:\\PasswordConfig.cfg");
                    System.IO.File.WriteAllText("0:\\UserConfig.cfg", user);
                    System.IO.File.WriteAllText("0:\\PasswordConfig.cfg", password);
                    Cosmos.System.Power.Reboot();
                }
                catch (Exception ex)
                {
                    BSOD(ex.Message);
                }
            }
            else
            {
                string username = "";
                string password1 = "";
                do
                {
                    Console.Write("User Name: ");
                    username = Console.ReadLine();
                    if (username == System.IO.File.ReadAllText(@"0:\\UserConfig.cfg"))
                    {
                        user = username;
                    }else if (username == "root")
                    {
                        user = username;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Username");
                    }
                } while (username != System.IO.File.ReadAllText(@"0:\\UserConfig.cfg"));

                do
                {
                    Console.Write("\nPassword: ");
                    password1 = string.Empty;
                    ConsoleKey key;
                    do
                    {
                        var keyinfo = Console.ReadKey(intercept: true);
                        key = keyinfo.Key;

                        if (key == ConsoleKey.Backspace && password1.Length > 0)
                        {
                            Console.Write("\b");
                            password1 = password1[0..^1];
                        }
                        else if (!char.IsControl(keyinfo.KeyChar))
                        {
                            Console.Write("*");
                            password1 += keyinfo.KeyChar;
                        }
                    } while (key != ConsoleKey.Enter);

                    if (password1 ==System.IO.File.ReadAllText(@"0:\\PasswordConfig.cfg"))
                    {
                        return;
                    } else
                    {
                        Console.WriteLine("\nWrong Password!");
                    }

                } while (password1 != System.IO.File.ReadAllText(@"0:\\PasswordConfig.cfg"));
            }
        }


        public static bool retypep(string retypepassword, string firstpass)
        {
            Console.Write("\nRetype your password: ");
            string password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyinfo = Console.ReadKey(intercept: true);
                key = keyinfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyinfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyinfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            firstpass = password;

            if (retypepassword == firstpass)
            {
                return true;
            } else
            {
                Console.WriteLine("\nIncorrect, try again!");
                return false;
            }
        }

        public static void BSOD(string exception_text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine(":(");
                Console.WriteLine("Your PC ran into a problem and need to restart");
                Console.WriteLine();
                Console.WriteLine("For more infomation about this issue and possiable fixes, visit: <https://github.com/CodeCs1/TerminalOS-v1-C-> [You can create issue]");
                Console.WriteLine("If you call a support person, give them this info: ");
                Console.WriteLine("Error Code: " + exception_text);
                Console.WriteLine("Collecting info: " + i + "%");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
            Console.WriteLine("Please press Enter key to reboot");
            Console.ReadLine();
            Sys.Power.Reboot();

        }

        private Command.CommandManager CommandManager;

        protected override void Run()
        {
            Console.Write("\n[TerminalOS@" + user + "]~-> ");
            string response;
            string input = Console.ReadLine();
            response = this.CommandManager.processInputExample(input);

            Console.WriteLine(response);

        }

        protected override void AfterRun()
        {
            Console.WriteLine("Is now safe to turn off your computer!");
            Cosmos.System.Power.Shutdown();
            base.AfterRun();
        }
    }
}
