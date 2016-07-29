using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab.Lib;
using Lab.Lib.Utils;

namespace Lab.Lib
{
    [Command]
    public class Help : ICommand
    {
        public Usage CommandUsage
        {
            get
            {
                Dictionary<string, string> description = new Dictionary<string, string>()
                {
                    ["lab help"] = "Shows Help information."
                };

                return new Usage("help", description);
            }
        }

        public void ExecuteCommand(string[] args)
        {
            new CommandManager().ShowHelp();
        }
    }
}
