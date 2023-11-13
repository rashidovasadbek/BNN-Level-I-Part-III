namespace N70.Identity.Application.Common.Notifications;

public interface IEmailOrchestrationService
{
    ValueTask<bool> SendAsync(string emailAddress, string message);
}