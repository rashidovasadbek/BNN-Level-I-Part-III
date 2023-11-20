using N73.Notifications.Application.Common.Notifications.Models;

namespace N73.Notifications.Application.Common.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken);
}