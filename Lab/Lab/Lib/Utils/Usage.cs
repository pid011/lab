using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Lib.Utils
{
    public class Usage
    {
        public Usage(string command, Dictionary<string, string> description)
        {
            this.Command = command;
            this.Description = description;
        }

        public string Command { get; set; }
        public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>();
    }
}
