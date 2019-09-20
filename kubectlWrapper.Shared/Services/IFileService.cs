using System.Collections.Generic;

namespace kubectlWrapper.Shared.Services
{
    public interface IFileService
    {
        List<string> ReadDirectory(string directory);
        string ReadFile(string location);
    }
}