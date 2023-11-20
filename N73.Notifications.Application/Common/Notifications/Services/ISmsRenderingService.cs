using N73.Notifications.Application.Common.Notifications.Models;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface ISmsRenderingService
{
    ValueTask<string> RenderAsync(
        SmsMessage smsMessage,
        CancellationToken cancellationToken = default);
}