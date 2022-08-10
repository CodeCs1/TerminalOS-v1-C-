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
                if (str.Contains("$"))
                {
                    String St = str;

                    int pFrom = St.IndexOf("$") + "$".Length;
                    int pTo = St.LastIndexOf(" ");

                    String result = St.Substring(pFrom, pTo - pFrom);
                    DateTime dateTime = new DateTime(DateTime.Now.Year, 8, 8);
                    DateTime CurrentDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                    int IsEastereggIsDetected = DateTime.Compare(dateTime, CurrentDateTime);
                    if (result == "DuCa") //=)
                    {
                        if (IsEastereggIsDetected != -1)
                        { // easteregg = True #Cuz -1 is not equal to current time =)
                            Console.WriteLine("Variable: " + result);
                            Console.WriteLine(@"
  (\___/)         Welcome, this is rabit =)
  (='.'=)         and yes, if you are in Vietnamese, you already know about 
 ('')_('')        'Hibiki Duca' right ?
                                                        - Variable $DuCa -");
                            return "";
                        } else
                        {
                            Console.WriteLine("WARNING: You need to wait to 8/8 to this easter egg work =)");
                        }
                    }
                    else
                    {
                        response = "Variable: " + result;
                    }
                    return "";
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
