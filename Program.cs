using System;
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
            //ToDo: Add argument for # of iterations.
            if (args.Length == 0)
            {
                //No arguments given? Instantiate with calc.exe
                return new Cradle();
            }
            else if (args.Length == 1)
            {
                return new Cradle(args[0]);
            }
            else
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

            // Need better solution than do... while loop.
            //ToDo: Add a way for the user to stop (# iterations, user-input key, etc.)
            do
            {
                cradle.StartProcess();          //Start process
                Thread.Sleep(3000);             //Wait for fuzzing to happen
                cradle.CheckIfCrashed();        //Check for crash
                cradle.KillProcess();
            } while (true);
        }
    }
}
