using DeploymentBot.API.Controllers.Abstractions;
using System;
using System.Threading.Tasks;

namespace DeploymentBot.API.Controllers
{
    public class AzurePipelineController : IAzurePipelineController
    {
        public async Task<bool> CallVMPipeline(string baseName, DateTime? startTime)
        {
            string name = $"{baseName}_VM";
            DateTime startDate = startTime.HasValue ? startTime.Value : DateTime.Now;

            return false;
        }
    }
}
