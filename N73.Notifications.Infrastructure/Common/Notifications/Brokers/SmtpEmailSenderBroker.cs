using System.Net;
using System.Net.Mail;
using N73.Notification.Infrastructure.Common.Settings;
using N73.Notifications.Application.Common.Notifications.Brokers;
using N73.Notifications.Application.Common.Notifications.Models;
using Twilio.Base;

namespace N73.Notification.Infrastructure.Common.Notifications.Brokers;

public class SmtpEmailSenderBroker : IEmailSenderBroker
{
    private readonly SmtpEmailSenderSettings _smtpEmailSenderSettings;

    public SmtpEmailSenderBroker(SmtpEmailSenderSettings smtpEmailSenderSettings)
    {
        _smtpEmailSenderSettings = smtpEmailSenderSettings;
    }
    
    public ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken)
    {
        emailMessage.SendEmailAddress ??= _smtpEmailSenderSettings.CredentialAddress;
        
        var mail = new MailMessage(emailMessage.SendEmailAddress, emailMessage.ReceiverEmailAddress);
        mail.Subject = emailMessage.Subject;
        mail.Body = emailMessage.Body;
        
        var smtpClient = new SmtpClient(_smtpEmailSenderSettings.Host, _smtpEmailSenderSettings.Port);
        smtpClient.Credentials =
            new NetworkCredential(_smtpEmailSenderSettings.CredentialAddress, _smtpEmailSenderSettings.Password);
        smtpClient.EnableSsl = true;
        
        smtpClient.Send(mail);

        return new ValueTask<bool>(true);
    }
}