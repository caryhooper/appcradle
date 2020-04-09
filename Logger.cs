using System;
using System.IO;

namespace AppCradle
{
    class Logger
    {
        //constructor
        public Logger(string logname = @"cradle-log.txt")
        {
            LogFileName = logname;
        }

        public string LogFileName = "cradle-log.txt";

        internal void LogCrash()
        {
            using (var writer = File.AppendText(LogFileName))
            {
                //ToDo add crash dump data.  Stack dump + Registers + full memory dump? (no thank you)
                var message = $"{DateTime.Now}: Crash! The application has crashed.";
                Console.WriteLine(message);
                writer.WriteLine(message);
            }
        }
        internal void LogStart(string exepath)
        {
            using (var writer = File.AppendText(LogFileName))
            {
                var message = $"{DateTime.Now}: {exepath} has been started.";
            }
        }
    }
}
