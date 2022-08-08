using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalOSv1.Command.CommandList
{
    public class echoCommand:Command
    {
        public echoCommand(String name):base(name)
        {

        }

        public override string execute(string[] arguments)
        {
            string response="";

            /*
             
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
             */

            if (arguments.Length != 0)
            {
                string str = "";
                foreach(string args in arguments)
                {
                    str += args + " ";
                }
                response = string.Format("{0}", str);
            } else
            {
                response = "ECHO is off by default.";
            }

            return response;
        }
    }
}
