using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Domin.Common.Exceptions;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        EmailNotificationRequest request,
        CancellationToken cancellationToken);
}