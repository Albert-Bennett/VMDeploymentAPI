using System;

namespace DeploymentBot.API.Model
{
    public class CreateVMRequest
    {
        public string Name { get; set; }
        public DateTime? CreationTime { get; set; }
        public string ContactEmailAddress { get; set; }
    }
}
