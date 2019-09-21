using System.Collections.Generic;

namespace kubectlWrapper.Shared.Services
{
    public interface IFileService
    {
        List<string> ReadDirectoryOrNull(string directory);
        bool DirectoryIsValid(string directory);
        string ReadFile(string location);
    }
}