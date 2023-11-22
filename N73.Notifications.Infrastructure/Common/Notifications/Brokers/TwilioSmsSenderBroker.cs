using Microsoft.Extensions.Options;
using N73.Notification.Infrastructure.Common.Settings;
using N73.Notifications.Application.Common.Notifications.Brokers;
using N73.Notifications.Application.Common.Notifications.Models;
using Twilio;
using Twilio.Rest.PreviewMessaging.V1;
using Twilio.TwiML.Messaging;
using MessageResource = Twilio.Rest.Api.V2010.Account.MessageResource;

namespace N73.Notification.Infrastructure.Common.Notifications.Brokers;

public class TwilioSmsSenderBroker : ISmsSenderBroker
{
    private readonly TwilioSmsSenderSettings _twilioSmsSenderSettings;

    public TwilioSmsSenderBroker(IOptions<TwilioSmsSenderSettings> twilioSmsSenderSettings)
    {
        _twilioSmsSenderSettings = twilioSmsSenderSettings.Value;
    }
    public ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken)
    {
       TwilioClient.Init(_twilioSmsSenderSettings.AccountSid, _twilioSmsSenderSettings.AuthToken);

       var messageContent = MessageResource.Create(
           body: smsMessage.Message,
           from: new Twilio.Types.PhoneNumber(_twilioSmsSenderSettings.SenderPhoneNumber),
           to: new Twilio.Types.PhoneNumber(smsMessage.ReceiverPhoneNumber));

       return new ValueTask<bool>(true);
    }
}