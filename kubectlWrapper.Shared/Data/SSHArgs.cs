using System;
using System.Collections.Generic;
using System.Text;

namespace kubectlWrapper.Shared.Data
{
    public static class SSHArgs
    {
        public static string GetNodes = "benny kubectl get nodes";
        public static string GetConfig = "benny kubectl config view";
    }
}
