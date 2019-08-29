using System;
using System.Collections.Generic;
using System.Text;

namespace kubectlWrapper.Shared.Data
{
    public static class SSHArgs
    {
        public static string GetNodes = "benny kubectl get nodes";
        public static string GetConfig = "benny kubectl config view";
        public static string GetPods = "benny kubectl get pods";
        public static string GetServices = "benny kubectl get services";
        public static string GetDeployments = "benny kubectl get deployments";
        public static string GetNamespaces = "benny kubectl get namespaces";
    }
}
