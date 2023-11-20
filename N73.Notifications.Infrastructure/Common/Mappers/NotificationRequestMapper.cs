using AutoMapper;
using N73.Notifications.Application.Common.Notifications.Models;

namespace N73.Notification.Infrastructure.Common.Mappers;

public class NotificationRequestMapper : Profile
{
    public NotificationRequestMapper()
    {
        CreateMap<NotificationRequest, EmailNotificationRequest>();
        CreateMap<NotificationRequest, SmsNotificationRequest>();
    }
}