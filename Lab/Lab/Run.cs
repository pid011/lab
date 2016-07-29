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
            if (args.Length == 0)
            {
                args = null;
                Log.WriteLine("[ Lab - developer lab ] is started...");
                Log.Write("> ");

                string input = Console.ReadLine();
                args = input.Split(' ');
            }
            List<string> commandArgs = args.ToList();
            string command = commandArgs[0];
            commandArgs.Remove(commandArgs[0]);

            args = null;
            args = commandArgs.ToArray();

            CommandManager manager = new CommandManager();
            manager.RunCommand(command, args);

            return;
        }
    }
}