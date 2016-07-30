using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Lib;
using Lab.Lib.Utils;

namespace LabExamplePlugin
{
    [Command]
    public class Example : ICommand
    {
        private Dictionary<string, string> commandDescription = new Dictionary<string, string>()
        {
            ["lab example"] = "This command is example command."
        };

        public Usage CommandUsage => new Usage("example", commandDescription);

        public void ExecuteCommand(string[] args)
        {
            Log.WriteLine("You enterd example command.");
        }
    }
}
