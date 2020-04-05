using System;
using System.Diagnostics;
using System.Threading;

namespace AppCradle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Argument Handling https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/command-line-arguments
            //string[] array (.Length)
            if (args.Length != 1)
            {
                Console.WriteLine("Error.  Invalid arguments.");
                Console.WriteLine("\t.\\AppCradle.exe /path/to/program.exe");
            }
            string exepath = args[0];
            Console.WriteLine($"Hello World! - {exepath}");
            //Using ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = exepath;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;


            //Set arguments
            startInfo.Arguments = "";

            //Call WaitForExit
            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    Thread.Sleep(15000);
                    exeProcess.Kill();
                    //Ideally we could grab the PID from here during the Kill stub.
                }
            }
            catch
            {
                //Log Error

            }
            
            
            //Stub to kill process
            Thread.Sleep(3000);
            Process[] processes = Process.GetProcessesByName("Calculator");
            Console.WriteLine("Total Processes: {0}", processes.Length);
            foreach (Process process in processes)
            {
                Console.WriteLine($"{process.ProcessName} - {process.Id}");
                process.Kill();
            }



        }
    }
}
