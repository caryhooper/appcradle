using System;
using System.IO;

namespace AppCradle
{
    static class Logger
    {
        //declare variables
        private static StreamWriter writer = File.AppendText("cradle-log.txt");

        //constructor
        //public static Logger()
        //{
        //    writer = File.AppendText("cradle-log.txt");
        //}

        internal static void Write(string message)
        {
            //ToDo add crash dump data.  Stack dump + Registers + full memory dump? (no thank you)
            message = $"{DateTime.Now}: {message}";
            Console.WriteLine(message);
            writer.WriteLine(message);
        }
    }
}