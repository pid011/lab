using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab.Lib.Utils;

namespace Lab.Lib
{
    /// <summary>
    /// 명령어에 대한 여러가지 내용들을 제공합니다.
    /// </summary>
    public class CommandManager
    {
        public static List<object> Commands
        {
            get
            {
                return _commands;
            }
        }

        private static List<object> _commands = new List<object>();


        static CommandManager()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetExportedTypes();
            foreach (var type in types)
            {
                if (! type.IsDefined(typeof(CommandAttribute), false))
                {
                    continue;
                }
                var ctor = type.GetConstructor(Type.EmptyTypes);
                if (ctor != null)
                {
                    var command = ctor.Invoke(null);
                    _commands.Add(command);
                }
            }
        }

        public void RunCommand(string command, string[] args)
        {
            bool isSuccessed = false;
            foreach (object target in Commands)
            {
                ICommand findingCommand = target as ICommand;
                if (findingCommand != null)
                {
                    if (findingCommand.CommandUsage.Command == command)
                    {
                        isSuccessed = true;
                        findingCommand.ExecuteCommand(args);
                    }
                }
            }
            if (! isSuccessed)
            {
                Log.Error("No command to match.");
            }
        }

        public void ShowHelp()
        {
            foreach (object target in Commands)
            {
                ICommand findingCommand = target as ICommand;
                if (findingCommand != null)
                {
                    foreach (var description in findingCommand.CommandUsage.Description)
                    {
                        Console.WriteLine(description.Key.ToString());
                        Console.WriteLine($"\t- {description.Value.ToString()}");
                    }
                }
            }
        }
    }
}
