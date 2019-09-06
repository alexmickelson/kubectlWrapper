using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace kubectlWrapper.Shared.Services
{
    public class SshKube : IKubeService
    {
        public string Kubectl(string sshArgs)
        {
            //var tcs = new TaskCompletionSource<string>();


            var process = new Process();
            process.StartInfo.FileName = "ssh";
            process.StartInfo.Arguments = sshArgs;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = true;

            //process.Exited += (sender, args) =>
            //{
            //    if (process.ExitCode != 0)
            //    {
            //        tcs.SetResult("Error running command: " + "\n" +
            //            process.StartInfo.FileName + " " + process.StartInfo.Arguments + "\n" +
            //            process.StandardError.ReadToEnd());
            //    }
            //    else
            //    {
            //        tcs.SetResult(process.StandardOutput.ReadToEnd());

            //    }
            //    process.Dispose();
            //};
            process.Start();
            string stdOut = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return stdOut;
        }
    }
}
