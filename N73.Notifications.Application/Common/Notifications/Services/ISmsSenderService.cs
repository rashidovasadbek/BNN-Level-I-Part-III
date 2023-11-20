using N73.Notifications.Application.Common.Notifications.Models;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface ISmsSenderService
{
    ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default);
}