using System;
using System.Diagnostics;
using System.Threading;

namespace AppCradle
{
    //Should we derive Cradle from the System.Diagnostics.Process class?
    class Cradle
    {
        //constructor
        public Cradle(string exepath = @"C:\Users\Cary\source\repos\formExplorer\formExplorer\bin\Debug\formExplorer.exe")
        {
            Exepath = exepath;
        }
        public string Exepath;
        public int iteration = int.MinValue;
        public Process CurrentProc;
        public Logger LogFile = new Logger("cradle-log.txt");

        public void StartProcess()
        {
            iteration += 1;
            //prepare the process
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = Exepath;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //start the process
            CurrentProc = Process.Start(startInfo);
            Console.WriteLine($"Process {Exepath} has started with PID {CurrentProc.Id}");
            LogFile.LogStart(Exepath);
        }

        public void CheckIfCrashed()
        {
            //ToDo logic to determine if process has crashed
            CurrentProc.WaitForExit(3 * 1000);

            try
            {
                //Crash Happens
                Console.WriteLine($"Exit Code: {CurrentProc.ExitCode}");
                PlaySong();
                LogFile.LogCrash();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Program has not crashed: {ex.Message}");
            }
            finally
            {
                string message = $"** Iteration {iteration} completed. **";
                Console.WriteLine(message);
                CurrentProc.Kill();
            }
        }

        internal void KillProcess()
        {
            CurrentProc.Kill();
        }

        internal void PlaySong()
        {
            //ToDo - play a song thats more bad ass.
            int B = 247;
            int A = 220;
            int G = 196;
            Console.Beep(B, 200);
            Console.Beep(A, 200);
            Console.Beep(G, 200);
            Console.Beep(A, 200);
            Console.Beep(B, 200);
            Console.Beep(B, 200);
            Console.Beep(B, 200);
            Thread.Sleep(200);
            Console.Beep(A, 200);
            Console.Beep(A, 200);
            Console.Beep(A, 200);
            Thread.Sleep(200);
            Console.Beep(B, 200);
            Console.Beep(B, 200);
            Console.Beep(B, 200);
            Thread.Sleep(200);
            Console.Beep(B, 200);
            Console.Beep(A, 200);
            Console.Beep(G, 200);
            Console.Beep(A, 200);
            Console.Beep(B, 200);
            Console.Beep(B, 200);
            Console.Beep(B, 200);
            Thread.Sleep(200);
            Console.Beep(A, 200);
            Console.Beep(A, 200);
            Console.Beep(B, 200);
            Console.Beep(A, 200);
            Console.Beep(G, 600);
        }
    }
}
