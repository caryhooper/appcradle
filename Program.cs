using System;
using System.Diagnostics;
using System.Threading;


// Start program
// If it crashes, capture all that info
// After a crash, log the crash
// After a while, kill the process (if not already crashed)


namespace AppCradle
{
    class Program
    {
        public static Cradle HandleArgs(string[] args)
        {
            if (args.Length == 0){
                //No arguments given? Instantiate with calc.exe
                return new Cradle();
            }
            else if (args.Length == 1){
                return new Cradle(args[0]);
            } else
            {
                //More than one argument given
                Console.WriteLine($"Invalid number of arguments given: {args.Length}.\nUsage:");
                Console.WriteLine("\t.\\AppCradle.exe /path/to/exe");
                System.Environment.Exit(1);
                return null;
            }
        }
        static void Main(string[] args)
        {

            Cradle cradle = HandleArgs(args);
            //Start process
            cradle.StartProcess();
            cradle.LogStart();
            Thread.Sleep(3000);


            var hasExited = cradle.CurrentProc.HasExited;
            Console.WriteLine($"Has the program exited? {hasExited}");
            if (hasExited == true)
            {
                // ... log things to file.
                cradle.PlaySong();
                cradle.DumpCrashToLog();
            }
            if (cradle.CurrentProc != null && !cradle.CurrentProc.HasExited)
            {
                cradle.CurrentProc.Kill(); //This doesn't work for some reason.
            }
        }
    }
}
