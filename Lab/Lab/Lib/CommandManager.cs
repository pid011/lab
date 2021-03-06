﻿using System;
using System.Collections.Generic;
using System.Reflection;
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
        /// 명령어 목록을 가져옵니다.
        /// </summary>
        public static List<ICommand> Commands
        {
            get
            {
                List<ICommand> commands = new List<ICommand>();
                foreach (object item in _commands)
                {
                    ICommand cmd = item as ICommand;
                    if (cmd != null)
                    {
                        commands.Add(cmd);
                    }
                }
                return commands;
            }
        }

        private static List<object> _commands = new List<object>();

        /// <summary>
        /// 최초로 한번만 명령어를 가져옵니다. 
        /// 플러그인 폴더가 존재하지 않을 시 플러그인 폴더를 생성합니다.
        /// </summary>
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
            AddCommands(types);
        }

        /// <summary>
        /// 명령어를 추가합니다.
        /// </summary>
        /// <param name="type">플러그인에 정의된 클래스 형식입니다.</param>
        public static void AddCommand(Type type)
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
        /// <summary>
        /// 명령어들을 추가합니다.
        /// </summary>
        /// <param name="types">플러그인에 정의된 클래스 형식들입니다.</param>
        public static void AddCommands(List<Type> types)
        {
            foreach (Type type in types)
            {
                AddCommand(type);
            }
        }

        internal void RunCommand(string command, string[] args)
        {
            bool isSuccessed = false;
            foreach (ICommand target in Commands)
            {
                if (target.CommandUsage.Command == command)
                {
                    isSuccessed = true;
                    target.ExecuteCommand(args);
                }
            }
            if (! isSuccessed)
            {
                Log.Error("No command to match.");
            }
        }
    }
}
