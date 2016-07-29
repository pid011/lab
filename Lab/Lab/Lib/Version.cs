using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab.Lib.Utils;

namespace Lab.Lib
{
    [Command]
    public class Version : ICommand
    {
        public Usage CommandUsage
        {
            get
            {
                Dictionary<string, string> description = new Dictionary<string, string>()
                {
                    ["lab version"] = "Shows version of the program."
                };
                return new Usage("version", description);
            }
        }

        public void ExecuteCommand(string[] args)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Log.WriteLine($"Lab Version: ");
            Log.WriteLine($"\t{version.ToString()}");
        }
    }
}
