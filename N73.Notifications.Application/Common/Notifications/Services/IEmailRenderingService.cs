using N73.Notifications.Application.Common.Notifications.Models;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface IEmailRenderingService
{
    ValueTask<string> RenderAsync(
        EmailMessage emailMessage,
        CancellationToken cancellationToken = default);
}