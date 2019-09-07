using System.Threading.Tasks;

namespace kubectlWrapper.Shared.Services
{
    public interface IKubeService
    {
        Task<string> Kubectl(string sshArgs);
        Task<string> ApplyYaml(string yaml);
    }
}