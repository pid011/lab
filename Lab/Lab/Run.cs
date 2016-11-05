using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Lab.Lib;
using Lab.Lib.Utils;

namespace Lab
{
    class Run
    {
        static void Main(string[] args)
        {
            CommandManager manager = new CommandManager();
            if (args.Length == 0)
            {
                args = new string[1] { "help" };
            }
            List<string> commandArgs = args.ToList();
            string command = commandArgs[0];
            commandArgs.Remove(commandArgs[0]);

            args = null;
            args = commandArgs.ToArray();

            manager.RunCommand(command, args);
            return;
        }
    }
}