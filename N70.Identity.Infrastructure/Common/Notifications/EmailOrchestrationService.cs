using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using N70.Identity.Application.Common.Notifications;
using N70.Identity.Application.Common.Settings;

namespace N70.Identity.Infrastructure.Common.Notifications;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    private readonly EmailSenderSettings _emailSenderSettings;

    public EmailOrchestrationService(IOptions<EmailSenderSettings> emailSenderSettings)
    {
        _emailSenderSettings = emailSenderSettings.Value;
    }
    public ValueTask<bool> SendAsync(string emailAddress, string message)
    {
        var mail = new MailMessage(_emailSenderSettings.CredentialAddress, emailAddress);
        mail.Subject = "Siz muvaffaqiyatli registratsiyadan o'tdingiz";
        mail.Body = message;

        var smtpClient = new SmtpClient(_emailSenderSettings.Host, _emailSenderSettings.Port); // Replace with your SMTP server address and port
        smtpClient.Credentials = new NetworkCredential(_emailSenderSettings.CredentialAddress, _emailSenderSettings.Password);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);

        return new(true);
    }
}