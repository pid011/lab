using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Lib.Utils;
using Lab.Lib;

namespace Lab.Lib
{
    [Command]
    public class HelloWorld : ICommand
    {
        public Usage CommandUsage
        {
            get
            {
                Dictionary<string, string> description = new Dictionary<string, string>()
                {
                    ["lab helloworld"] = "Shows \"Hello, world!\""
                };
                return new Usage("helloworld", description);
            }
        }

        public void ExecuteCommand(string[] args)
        {
            Log.WriteLine("Hello, world!");
        }
    }
}
