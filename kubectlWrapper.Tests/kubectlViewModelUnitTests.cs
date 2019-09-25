//using FluentAssertions;
//using kubectlWrapper.Shared.Data;
//using kubectlWrapper.Shared.Services;
//using kubectlWrapper.Shared.ViewModels;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;
//using System.Threading.Tasks;

//namespace kubectlWrapper.Tests
//{
//    class kubectlViewModelUnitTests
//    {
//        public IKubeService moqKube { get; set; }

//        private KubectlViewModel vm;

//        [SetUp]
//        public void moq_service()
//        {
//            var moqKubeService = new Mock<IKubeService>();
//            moqKubeService.Setup(k => k.Kubectl(SSHArgs.CheckConnectivity)).Returns(Task.FromResult("connected"));
//            moqKubeService.Setup(k => k.Kubectl(SSHArgs.GetConfig)).Returns(Task.FromResult(@"apiVersion: v1
//clusters:
//-cluster:
//    certificate - authority - data: DATA + OMITTED
//    server: https://144.17.10.175:6443
//  name: kubernetes
//contexts:
//-context:
//    cluster: kubernetes
//    user: kubernetes - admin
//  name: kubernetes - admin@kubernetes
//current - context: kubernetes - admin@kubernetes
//kind: Config
//preferences: { }
//        users:
//            -name: kubernetes - admin
//  user:
//            client - certificate - data: REDACTED
//    client - key - data: REDACTED"));
//            moqKubeService.Setup(k => k.Kubectl(SSHArgs.GetNodes)).Returns(Task.FromResult(@"NAME            STATUS   ROLES    AGE   VERSION
//sudo.snow.edu   Ready    master   32h   v1.15.3
//sudoclub2       Ready    <none>   32h   v1.15.3
//sudoclub3       Ready    <none>   32h   v1.15.3"));
//            moqKubeService.Setup(k => k.Kubectl(SSHArgs.GetPods)).Returns(Task.FromResult(@"NAME                                  READY   STATUS    RESTARTS   AGE
//sudonet-deployment-55878cd4b6-9f59n   1/1     Running   0          31h
//sudonet-deployment-55878cd4b6-gtcmq   1/1     Running   0          31h
//sudonet-deployment-55878cd4b6-kn64q   1/1     Running   0          31h"));
//            moqKubeService.Setup(k => k.Kubectl(SSHArgs.GetDeployments)).Returns(Task.FromResult(@"NAME                 READY   UP-TO-DATE   AVAILABLE   AGE
//sudonet-deployment   3/3     3            3           31h"));
//            moqKubeService.Setup(k => k.Kubectl(SSHArgs.GetServices)).Returns(Task.FromResult(@"NAME              TYPE        CLUSTER-IP      EXTERNAL-IP   PORT(S)                      AGE
//kubernetes        ClusterIP   10.96.0.1       <none>        443/TCP                      31h
//sudonet-service   NodePort    10.96.130.143   <none>        80:30180/TCP,443:31443/TCP   31h"));
//            moqKubeService.Setup(k => k.Kubectl(SSHArgs.GetNamespaces)).Returns(Task.FromResult(@"NAME              STATUS   AGE
//default           Active   32h
//kube-node-lease   Active   32h
//kube-public       Active   32h
//kube-system       Active   32h"));

//            var moqFileService = new Mock<IFileService>();
//            moqFileService.Setup(f => f.SelectDirectory()).Returns(new List<string>());

//            vm = new KubectlViewModel(moqKubeService.Object, moqFileService.Object);
//        }

//        [Test]
//        public void kubectl_check_connectivity()
//        {
//            vm.Connection = string.Empty;
//            vm.GetConnectivity.Execute();

//            vm.Connection.Should().NotBeNullOrEmpty().And.NotContain("Error");
//        }

//        [Test]
//        public void kubectl_get_cluster_info()
//        {
//            vm.ClusterInfo = string.Empty;
//            vm.GetClusterInfo.Execute();

//            vm.ClusterInfo.Should().NotBeNullOrEmpty();
//        }

//        [Test]
//        public void kubectl_gets_nodes()
//        {
//            vm.Nodes = string.Empty;
//            vm.GetNodes.Execute();

//            vm.Nodes.Should().NotBeNullOrEmpty();
//        }


//        [Test]
//        public void kubectl_get_deployments()
//        {
//            vm.Deployments = string.Empty;
//            vm.GetDeployments.Execute();

//            vm.Deployments.Should().NotBeNullOrEmpty();
//        }

//        [Test]
//        public void kubectl_get_services()
//        {
//            vm.Services = string.Empty;
//            vm.GetServices.Execute();

//            vm.Services.Should().NotBeNullOrEmpty();
//        }

//        [Test]
//        public void kubectl_get_pods()
//        {
//            vm.Pods = string.Empty;
//            vm.GetPods.Execute();

//            vm.Pods.Should().NotBeNullOrEmpty();
//        }
//        [Test]
//        public void kubectl_get_namespaces()
//        {
//            vm.Namespaces = string.Empty;
//            vm.GetNamespaces.Execute();

//            vm.Namespaces.Should().NotBeNullOrEmpty();
//        }



//    }
//}
