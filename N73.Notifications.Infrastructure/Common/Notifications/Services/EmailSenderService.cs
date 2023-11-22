using N73.Notifications.Application.Common.Notifications.Brokers;
using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Application.Common.Notifications.Services;
using N73.Notifications.Domin.Extensions;

namespace N73.Notification.Infrastructure.Common.Notifications.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly IEnumerable<IEmailSenderBroker> _emailSenderBroker;


    public EmailSenderService(IEnumerable<IEmailSenderBroker> emailSenderBroker)
    {
        _emailSenderBroker = emailSenderBroker;
    }
    public async ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken)
    {
        foreach (var emailSenderBroker in _emailSenderBroker)
        {
            var sendNotificationTask = () => emailSenderBroker.SendAsync(emailMessage, cancellationToken);
            var result = await sendNotificationTask.GetValueAsync();

            emailMessage.IsSuccessful = result.IsSuccess;
            emailMessage.ErrorMessage = result.Exception?.Message;
            return result.IsSuccess;
        }

        return false;
    }
}