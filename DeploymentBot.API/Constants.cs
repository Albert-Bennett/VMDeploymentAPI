namespace DeploymentBot.API
{
    internal static class Constants
    {
        internal static string FailedVMDeploymentMessage(string vmName) => $"Failed to create the VM '{vmName}'";
        internal static string FailedVMDeploymentEmailSubject = "Failed to create VM";
        internal static string VMBotName = "VM Deployment Bot";
    }
}
