using System;
using System.Threading;


// Start program
// If it crashes, capture all that info
// After a crash, log the crash
// After a while, kill the process (if not already crashed)
//ToDo: Create UI for AppCradle

namespace AppCradle
{
    class Program
    {
        public static Cradle HandleArgs(string[] args)
        {
            //ToDo: Add argument for # of iterations.
            if (args.Length != 1)
            {
                //No arguments given? Exit program.
                Console.WriteLine($"Invalid number of arguments given: {args.Length}.\nUsage:");
                Console.WriteLine("\t.\\AppCradle.exe /path/to/exe");
                System.Environment.Exit(1);
                return null;
            }
            else
            {
                //More than one argument given
                return new Cradle(args[0]);
            }
        }
        static void Main(string[] args)
        {
            //Log = new Logger("cradle-log.txt");
            //Instantiate object from arguments
            Cradle cradle = HandleArgs(args);

            // Need better solution than do... while loop.
            //ToDo: Add a way for the user to stop (# iterations, user-input key, etc.)
            do
            {
                cradle.StartProcess();          //Start process

                ///What could be the trigger for doing the thing?
                Thread.Sleep(3000);             //Wait for fuzzing to happen
                ///Attach to socket and look for network traffic
                
                cradle.CheckIfCrashed();        //Check for crash
                cradle.KillProcess();
            } while (true);
        }
    }
}
