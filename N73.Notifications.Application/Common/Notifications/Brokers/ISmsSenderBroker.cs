using N73.Notifications.Application.Common.Notifications.Models;

namespace N73.Notifications.Application.Common.Notifications.Brokers;

public interface ISmsSenderBroker
{
    ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken);
}