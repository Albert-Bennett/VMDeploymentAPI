using System;
using System.Threading.Tasks;

namespace DeploymentBot.API.Controllers.Abstractions
{
    public interface IAzurePipelineController
    {
        public Task<bool> CallVMPipeline(string baseName, DateTime? startTime);
    }
}
