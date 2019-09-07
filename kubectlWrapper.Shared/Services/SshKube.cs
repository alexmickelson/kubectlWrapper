using kubectlWrapper.Shared.Data;
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
        public Task<string> ApplyYaml(string yaml)
        {
            return Task.Run(() =>
            {
                var executable = @"C:\Windows\SysNative\WindowsPowerShell\v1.0\powershell.exe";
                if (!File.Exists(executable))
                {
                    if (File.Exists(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"))
                    {
                        executable = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
                    }
                    else
                    {
                        throw new FileNotFoundException("cannot find executable: " + executable);
                    }
                }

                var process = new Process();
                process.StartInfo.FileName = executable;
                process.StartInfo.Arguments = "cat " + yaml + " | ssh " + SSHArgs.SSHDest + " kubectl apply -f -";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.EnableRaisingEvents = true;

                process.Start();
                process.WaitForExit();
                var stdOut = process.StandardOutput.ReadToEnd();
                var stdError = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(stdError))
                {
                    return stdOut + "\n" + stdError;
                }
                return stdOut;
            });
        }

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
