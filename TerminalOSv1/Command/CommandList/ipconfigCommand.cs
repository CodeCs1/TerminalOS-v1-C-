using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Network;
using IL2CPU.API.Attribs;

namespace TerminalOSv1.Command.CommandList
{
    public class ipconfigCommand:Command
    {

        public ipconfigCommand(string name):base(name)
        {

        }

        public override string execute(string[] arguments)
        {

            string getnetwork = "";
            try
            {
                getnetwork = Cosmos.HAL.NetworkDevice.Devices.ToString();
            } catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                throw new NotImplementedException();
            }
            return getnetwork;
        }
    }
}
