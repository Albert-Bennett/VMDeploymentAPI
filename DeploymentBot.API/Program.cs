using DeploymentBot.API.Controllers;
using DeploymentBot.API.Controllers.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeploymentBot.API
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                    services.AddLogging();
                    services.AddHttpClient();

                    services.AddSingleton<IAzurePipelineController, AzurePipelineController>();
                    services.AddSingleton<ISendGridController, SendGridController>();
                })
                .Build();

            host.Run();
        }
    }
}