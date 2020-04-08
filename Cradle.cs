using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace AppCradle
{
    class Cradle
    {
        //constructor
        public Cradle(string exepath = @"C:\Windows\System32\calc.exe")
        {
            Exepath = exepath;
        }
        public string Exepath;
        public Process CurrentProc;
        public string LogFileName = "cradle-log.txt";
        
        public void StartProcess()
        {
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
        }

        internal void PlaySong()
        {
            //ToDo - play a song thats more badass.
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

        internal void DumpCrashToLog()
        {
            using (var writer = File.AppendText(LogFileName))
            {
                //ToDo add crash dump data.  Stack dump + Registers + full memory dump? (no thank you)
                var message = $"{DateTime.Now}: Crash! The application has crashed.";
                writer.WriteLine(message);
            }
        }

        internal void LogStart()
        {
            using (var writer = File.AppendText(LogFileName))
            {
                var message = $"{DateTime.Now}: {Exepath} has been started.";
            }
        }
    }
}
