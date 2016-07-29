using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Lib.Utils
{
    public class Log
    {
        public static void Write<T>(T msg)
        {
            Console.Write(msg.ToString());
        }

        public static void WriteLine<T>(T msg)
        {
            Console.WriteLine(msg.ToString());
        }

        public static void Error(string msg)
        {
            Console.WriteLine($"ERROR: {msg}");
        }
    }
}
