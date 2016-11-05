using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab.Lib;
using Lab.Lib.Utils;

namespace Lab.Lib
{
    /// <summary>
    /// Help 명령어입니다.
    /// </summary>
    [Command]
    public class HelpCommand : ICommand
    {
        private Dictionary<string, string> description = new Dictionary<string, string>()
        {
            ["lab help"] = "Shows Help information."
        };
        /// <summary>
        /// Help명령어에 대한 사용법을 제공합니다.
        /// </summary>
        public Usage CommandUsage
        {
            get
            {
                return new Usage("help", description);
            }
        }

        /// <summary>
        /// Help명령어에 대한 진입점입니다.
        /// </summary>
        /// <param name="args">명령어의 인수입니다.</param>
        public void ExecuteCommand(string[] args)
        {
            foreach (var target in CommandManager.Commands)
            {
                    foreach (var description in target.CommandUsage.Description)
                    {
                        Log.WriteLine(description.Key.ToString());
                        Log.WriteLine($"\t- {description.Value.ToString()}");
                    }
            }
        }
    }
}
