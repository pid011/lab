using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Lab.Lib.Utils;

namespace Lab.Lib
{
    /// <summary>
    /// 명령어에 대한 여러가지 내용들을 제공합니다.
    /// </summary>
    public class CommandManager
    {
        /// <summary>
        /// 명령어 목록을 제공합니다.
        /// </summary>
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
            List<Type> types = new List<Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            types.AddRange(assembly.GetExportedTypes());

            string pluginDirPath = Utils.Path.GetPluginDirectoryPath;

            List<string> pluginsPath = new List<string>();
            pluginsPath.AddRange(Directory.GetFiles(pluginDirPath, "*.dll", SearchOption.AllDirectories));

            foreach (string pluginPath in pluginsPath)
            {
                Assembly plugin = Assembly.LoadFile(pluginPath);
                types.AddRange(plugin.GetExportedTypes());
            }
            AddCommand(types);
        }

        private static void AddCommand(List<Type> types)
        {
            foreach (Type type in types)
            {
                if (type.IsDefined(typeof(CommandAttribute), false))
                {
                    var ctor = type.GetConstructor(Type.EmptyTypes);
                    if (ctor != null)
                    {
                        var command = ctor.Invoke(null);
                        _commands.Add(command);
                    }   
                }
            }

        }

        internal void RunCommand(string command, string[] args)
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
        /*
        internal void ShowHelp()
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
        */
    }
}
