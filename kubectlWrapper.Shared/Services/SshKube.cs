using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace kubectlWrapper.Shared.Services
{
    public class SshKube : IKubeService
    {
        public string Kubectl(string sshArgs)
        {
            var executable = @"C:\Windows\SysNative\OpenSSH\ssh.exe";
            if (!File.Exists(executable))
            {
                throw new FileNotFoundException("cannot find executable: " + executable);
            }

            var process = new Process();
            process.StartInfo.FileName = executable;
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
            process.WaitForExit();
            var stdOut = process.StandardOutput.ReadToEnd();
            return stdOut;
        }
    }
}
