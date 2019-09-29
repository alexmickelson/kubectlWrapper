using System;
using System.Collections.Generic;
using System.Text;

namespace kubectlWrapper.Tests
{
    public static class TestConstants
    {
        public const string KubeMock = "kubeMock";
        public const string RegionManagerMock = "regionManagerMock";
        public const string FileMock = "fileServiceMock";
        public const string MainViewModel = "mainViewModel";
        public const string YamlViewModel = "yamlVewModel";
        public const string StatusViewModel = "statusViewModel";






        public const string GetConfigResult = @"apiVersion: v1
clusters:
-cluster:
    certificate - authority - data: DATA + OMITTED
    server: https://144.17.10.175:6443
  name: kubernetes
contexts:
-context:
    cluster: kubernetes
    user: kubernetes - admin
  name: kubernetes - admin@kubernetes
current - context: kubernetes - admin@kubernetes
kind: Config
preferences: { }
        users:
            -name: kubernetes - admin
  user:
            client - certificate - data: REDACTED
    client - key - data: REDACTED";
    }
}
