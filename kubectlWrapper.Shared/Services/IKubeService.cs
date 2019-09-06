using System.Threading.Tasks;

namespace kubectlWrapper.Shared.Services
{
    public interface IKubeService
    {
        string Kubectl(string sshArgs);
    }
}