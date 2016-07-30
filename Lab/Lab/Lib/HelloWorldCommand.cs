using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Lib.Utils;
using Lab.Lib;

namespace Lab.Lib
{
    /// <summary>
    /// HelloWorld 명령어입니다.
    /// </summary>
    [Command]
    public class HelloWorldCommand : ICommand
    {
        private Dictionary<string, string> description = new Dictionary<string, string>()
        {
            ["lab helloworld"] = "Shows \"Hello, world!\""
        };
        /// <summary>
        /// HelloWorld명령어에 대한 사용법을 제공합니다.
        /// </summary>
        public Usage CommandUsage
        {
            get
            {
                return new Usage("helloworld", description);
            }
        }

        /// <summary>
        /// HelloWorld명령어에 대한 진입점입니다.
        /// </summary>
        /// <param name="args">명령어의 인수입니다.</param>
        public void ExecuteCommand(string[] args)
        {
            Log.WriteLine("Hello, world!");
        }
    }
}
