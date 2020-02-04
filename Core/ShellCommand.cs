using System;
using System.Diagnostics;

namespace FoxAgent.Core
{
    public static class ShellCommand
    {
        public static string Command(this string command)
        {
            string result = "";

            var escapedArgs  = command.Replace("\"", "\\\"");
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                #if Windows
                    FileName="cmd.exe",
                    Arguments = $"/C \"{escapedArgs }\"",
                #else
                    FileName="/bin/bash",
                    Arguments = $"-c \"{escapedArgs }\"",
                #endif
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return result;
        }
    }
}