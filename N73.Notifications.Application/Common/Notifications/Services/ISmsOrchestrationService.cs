using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Domin.Common.Exceptions;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface ISmsOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        SmsNotificationRequest request,
        CancellationToken cancellationToken);
}