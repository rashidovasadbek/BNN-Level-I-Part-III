using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Domin.Entities;

namespace N73.Notifications.Application.Common.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken);
}