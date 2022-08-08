using System;
using Sys = Cosmos.System;

namespace TerminalOS_Recovery
{
    public class Kernel : Sys.Kernel
    {
        public enum Status
        {
            OK,
            WARNING,
            ERROR
        };

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
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Welcome to TerminalOS Recovery Version!");
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
                Console.WriteLine("For more infomation about this issue and possiable fixes, visit: https://www.github.com/Codedev/TerminalOS [You can create issue]");
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

        public static string TerminalOSVersion = "termv1";

        protected override void Run()
        {
            Console.Write("[TerminalOS@Root]~-> ");
            string response;
            string input = Console.ReadLine();
            response = this.CommandManager.processInputExample(input);

            Console.WriteLine(response);

        }
    }
}
