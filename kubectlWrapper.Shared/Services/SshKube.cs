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

        public Task<string> Kubectl(string sshArgs)
        {
            return Task.Run(() =>
            {
                var executable = @"C:\Windows\SysNative\OpenSSH\ssh.exe";
                if (!File.Exists(executable))
                {
                    if (File.Exists(@"C:\Windows\System32\OpenSSH\ssh.exe"))
                    {
                        executable = @"C:\Windows\System32\OpenSSH\ssh.exe";
                    }
                    else
                    {
                        throw new FileNotFoundException("cannot find executable: " + executable);
                    }
                }

                var process = new Process();
                process.StartInfo.FileName = executable;
                process.StartInfo.Arguments = sshArgs;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.EnableRaisingEvents = true;

                process.Start();
                process.WaitForExit();
                var stdOut = process.StandardOutput.ReadToEnd();
                return stdOut;

            });
        }
    }
}
