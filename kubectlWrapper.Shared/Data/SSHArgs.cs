using System;
using System.Collections.Generic;
using System.Text;

namespace kubectlWrapper.Shared.Data
{
    public static class SSHArgs
    {
        public static string SSHDest = "benny";
        public static string GetNodes = SSHDest + " kubectl get nodes";
        public static string GetConfig = SSHDest + " kubectl config view";
        public static string GetPods = SSHDest + " kubectl get pods";
        public static string GetServices = SSHDest + " kubectl get services";
        public static string GetDeployments = SSHDest + " kubectl get deployments";
        public static string GetNamespaces = SSHDest + " kubectl get namespaces";
        public static string CheckConnectivity = SSHDest + " echo connected";
    }
}
