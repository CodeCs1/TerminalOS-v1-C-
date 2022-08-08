using System;
using Cosmos.Core;
namespace TerminalOSv1.Command.CommandList
{
    public class SysinfoCommand : Command
    {
        public SysinfoCommand(string name):base(name) { }

        public override string execute(string[] arguments)
        {

            /*Console.WriteLine("Installeer datum:          " + Utils.Settings.GetValue("setuptime"));
                    }
                    Console.WriteLine("Starttijd van het systeem: " + Kernel.boottime);
                    Console.WriteLine("Hoeveelheid RAM:           " + Cosmos.Core.CPU.GetAmountOfRAM() + "MB");
                    Console.WriteLine("Processor(s):              " + Computer.Info.GetNumberOfCPU() + " processor(s) geïnstalleerd.");
                    int k = 1;
                    foreach (Processor processor in Computer.CPUInfo.Processors)
                    {
                        Console.WriteLine("[" + k + "] : " + processor.GetBrandName() + (int)processor.Frequency + " Mhz");
                        k++;
                    }
                    Computer.CPUInfo.Processors.Clear();*/
            //string response = "";
            try
            {
                Console.WriteLine(@"
  _______                      _                _   ____    _____         __ 
 |__   __|                    (_)              | | / __ \  / ____|       /_ |
    | |  ___  _ __  _ __ ___   _  _ __    __ _ | || |  | || (___   __   __| |
    | | / _ \| '__|| '_ ` _ \ | || '_ \  / _` || || |  | | \___ \  \ \ / /| |
    | ||  __/| |   | | | | | || || | | || (_| || || |__| | ____) |  \ V / | |
    |_| \___||_|   |_| |_| |_||_||_| |_| \__,_||_| \____/ |_____/    \_/  |_|
                                                                             
                             Remake version                                                
");
                Console.WriteLine(@"SysInfo (aka: Neofetch) -- System Infomation: 
System Kernel: Cosmos C#
System OS: TerminalOS v1 (remake) [or TerminalOS version N/A]
System CPU: " + CPU.GetCPUBrandString() + " | " + CPU.GetCPUVendorName());
/*
System CPU: " + Cosmos.Core.CPU.GetCPUBrandString() + @"
System Ram: " + Cosmos.Core.CPU.GetAmountOfRAM() + " MB*/
            } catch (Exception ex)
            {
                Kernel.BSOD(ex.Message);
            }
            return "";
        }
    }
}
