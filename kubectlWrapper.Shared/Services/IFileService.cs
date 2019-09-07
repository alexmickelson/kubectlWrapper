using System.Collections.Generic;

namespace kubectlWrapper.Shared.Services
{
    public interface IFileService
    {
        List<string> SelectDirectory();
        string ReadFile(string location);
    }
}