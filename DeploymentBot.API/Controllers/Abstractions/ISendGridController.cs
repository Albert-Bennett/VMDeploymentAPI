using System.Threading.Tasks;

namespace DeploymentBot.API.Controllers.Abstractions
{
    public interface ISendGridController
    {
        Task SendFailedCreationErrorEmail(string vmName, string emailAddress);
    }
}
