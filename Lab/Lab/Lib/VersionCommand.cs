using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab.Lib.Utils;

namespace Lab.Lib
{
    /// <summary>
    /// Version 명령어입니다.
    /// </summary>
    [Command]
    public class VersionCommand : ICommand
    {
        private Dictionary<string, string> commandDescription = new Dictionary<string, string>()
        {
            ["lab version"] = "Shows version of the program."

        };
        /// <summary>
        /// Version명령어에 대한 사용법을 제공합니다.
        /// </summary>
        public Usage CommandUsage
        {
            get
            {
                return new Usage("version", commandDescription);
            }
        }
        /// <summary>
        /// Version명령어에 대한 진입점입니다.
        /// </summary>
        /// <param name="args">명령어의 인수입니다.</param>
        public void ExecuteCommand(string[] args)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Log.WriteLine($"Lab Version: ");
            Log.WriteLine($"\t{version.ToString()}");
        }
    }
}
