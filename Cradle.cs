using System;
using System.Diagnostics;
using System.Threading;

namespace AppCradle
{
    class Cradle
    {
        private string Exepath;
        private int Iteration { get; set; }
        private Process CurrentProc;

        //constructor
        public Cradle(string exepath)
        {            
            Exepath = exepath;
        }

        public void StartProcess()
        {
            Iteration += 1;
            //prepare the process
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = Exepath,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            //start the process
            CurrentProc = Process.Start(startInfo);
            Console.WriteLine($"Process {Exepath} has started with PID {CurrentProc.Id}");            
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
                Logger.Write("Crashed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Program has not crashed: {ex.Message}");
            }
            finally
            {
                string message = $"** Iteration {Iteration} completed. **";
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
