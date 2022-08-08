using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOS_Recovery
{
    public class FileCommand : Command.Command
    {
        public FileCommand(string name): base (name)
        {

        }

        public override string execute(string[] arguments)
        {
            string response=string.Empty;

            if (arguments.Length != 0)
            {

                switch (arguments[0])
                {
                    case "-c": //SystemIO -c file <filename> or SystemIO -c directory <dirname>
                        switch (arguments[1])
                        {
                            case "file":
                                Console.WriteLine("Create file '" + arguments[2] + "' ?");
                                Console.WriteLine("[Yes\\No]");
                                string ans = Console.ReadLine();
                                if (ans == "Yes" || ans == "yes")
                                {
                                    try
                                    {
                                        Cosmos.System.FileSystem.VFS.VFSManager.CreateFile(arguments[2]);
                                        response = "File '" + arguments[2] + "' Successfully created! [Empty file]";
                                    }
                                    catch (Exception ex)
                                    {
                                        Kernel.BSOD(ex.Message);
                                    }
                                }
                                else
                                {
                                    response = "User has canceled.";
                                }
                                break;
                            case "directory":
                                Console.WriteLine("Create folder '" + arguments[2] + "' ?");
                                Console.WriteLine("[Yes\\No]");
                                string ans1 = Console.ReadLine();
                                if (ans1 == "Yes" || ans1 == "yes")
                                {
                                    try
                                    {
                                        Cosmos.System.FileSystem.VFS.VFSManager.CreateDirectory(arguments[2]);
                                        response = "Folder '" + arguments[2] + "' Successfully created";
                                    }
                                    catch (Exception ex)
                                    {
                                        Kernel.BSOD(ex.Message);
                                    }
                                }
                                else
                                {
                                    response = "User has canceled.";
                                }
                                break;
                        }
                        break;
                    case "-r": //SystemIO -r file <filename> or SystemIO -r directory <dirname>
                        switch (arguments[1])
                        {
                            case "file":
                                Console.WriteLine("Remove file '" + arguments[2] + "' ?");
                                Console.WriteLine("[Yes\\No]");
                                string ans = Console.ReadLine();
                                if (ans == "Yes" || ans == "yes")
                                {
                                    try
                                    {
                                        Cosmos.System.FileSystem.VFS.VFSManager.DeleteFile(arguments[2]);
                                        response = "File '" + arguments[2] + "' Successfully removed!";
                                    }
                                    catch (Exception ex)
                                    {
                                        Kernel.BSOD(ex.Message);
                                    }
                                }
                                else
                                {
                                    response = "User has canceled.";
                                }
                                break;
                            case "directory":
                                Console.WriteLine("Remove folder '" + arguments[2] + "' ?");
                                Console.WriteLine("[Yes\\No]");
                                string ans1 = Console.ReadLine();
                                if (ans1 == "Yes" || ans1 == "yes")
                                {
                                    try
                                    {
                                        Cosmos.System.FileSystem.VFS.VFSManager.DeleteDirectory(arguments[2], true);
                                        response = "Folder '" + arguments[2] + "' Successfully remove";
                                    }
                                    catch (Exception ex)
                                    {
                                        Kernel.BSOD(ex.Message);
                                    }
                                }
                                else
                                {
                                    response = "User has canceled.";
                                }
                                break;
                        }
                        break;
                    case "-w": //SystemIO -w <input> <text> <output>
                        if (!string.IsNullOrEmpty(arguments[1]))
                        {
                            try
                            {
                                System.IO.FileStream fs = (System.IO.FileStream)Cosmos.System.FileSystem.VFS.VFSManager.GetFile(arguments[1]).GetFileStream();
                                if (fs.CanWrite)
                                {
                                    int ctr = 0;
                                    StringBuilder sb = new StringBuilder();
                                    foreach (string s in arguments)
                                    {
                                        if (ctr > 1)
                                            sb.Append(s + ' ');
                                        ++ctr;
                                    }
                                    string txt = sb.ToString();
                                    Byte[] data = Encoding.ASCII.GetBytes(txt.Substring(0, txt.Length - 1));

                                    fs.Write(data, 0, data.Length);
                                    fs.Close();
                                    response = "File Successfully wrote.";
                                    break;
                                }
                                else
                                {
                                    response = "Error: file not exist or can't write cuz admin\nFilename = '" + arguments[1] + "'";
                                    break;
                                }

                            }
                            catch (Exception ex)
                            {
                                Kernel.BSOD(ex.Message);
                            }
                        }
                        else if (string.IsNullOrEmpty(arguments[1]))
                        {
                            try
                            {
                                Cosmos.System.FileSystem.VFS.VFSManager.CreateFile(arguments[3]);
                                System.IO.FileStream fs = (System.IO.FileStream)Cosmos.System.FileSystem.VFS.VFSManager.GetFile(arguments[3]).GetFileStream();
                                if (fs.CanWrite)
                                {
                                    int ctr = 0;
                                    StringBuilder sb = new StringBuilder();
                                    foreach (string s in arguments)
                                    {
                                        if (ctr > 1)
                                            sb.Append(s + ' ');
                                        ++ctr;
                                    }
                                    string txt = sb.ToString();
                                    Byte[] data = Encoding.ASCII.GetBytes(txt.Substring(0, txt.Length - 1));

                                    fs.Write(data, 0, data.Length);
                                    fs.Close();
                                    break;
                                }
                                else
                                {
                                    response = "Error: file not exist or can't write cuz admin\nFilename = '" + arguments[1] + "'";
                                    break;
                                }

                            }
                            catch (Exception ex)
                            {
                                Kernel.BSOD(ex.Message);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Unexpected arguments '" + arguments[0] + "'");
                        break;
                }
            } else
            {
                response = "Error: Arguments is need!";
            }
            return response;
        }
    }
}
