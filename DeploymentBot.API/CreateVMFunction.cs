using DeploymentBot.API.Controllers.Abstractions;
using DeploymentBot.API.Model;
using Microsoft.Azure.Functions.Worker;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeploymentBot.API
{
    public class CreateVMFunction
    {
        readonly IAzurePipelineController _pipelineController;
        readonly ISendGridController _SendGridService;

        public CreateVMFunction(IAzurePipelineController pipelineController, ISendGridController SendGridService)
        {
            _pipelineController = pipelineController;
            _SendGridService = SendGridService;
        }

        [Function("CreateVM")]
        [ServiceBusOutput("main", Connection = "QueueConnectionString")]
        public async Task Run([ServiceBusTrigger("main", Connection = "QueueConnectionString")] string queueItem, FunctionContext context)
        {
            var request = JsonSerializer.Deserialize<CreateVMRequest>(queueItem);

            var hasCreatedVM = await _pipelineController.CallVMPipeline(request.Name, request.CreationTime);

            if (!hasCreatedVM)
            {
                await _SendGridService.SendFailedCreationErrorEmail(request.Name, request.ContactEmailAddress);
            }
        }
    }
}
