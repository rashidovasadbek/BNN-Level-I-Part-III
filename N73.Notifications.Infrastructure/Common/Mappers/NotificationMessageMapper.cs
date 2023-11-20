using AutoMapper;
using N73.Notifications.Application.Common.Notifications.Models;

namespace N73.Notification.Infrastructure.Common.Mappers;

public class NotificationMessageMapper : Profile
{
    public NotificationMessageMapper()
    {
        CreateMap<EmailNotificationRequest, EmailMessage>();
        CreateMap<SmsNotificationRequest, SmsMessage>();
    }
}