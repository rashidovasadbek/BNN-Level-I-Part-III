using FluentValidation;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Domin.Enums;

namespace N73.Notification.Infrastructure.Common.Validators;

public class SmsTemplateValidator : AbstractValidator<SmsTemplate>
{
    public SmsTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            .WithMessage("Sms template content is required")
            .MaximumLength(10)
            .WithMessage("Sms template content must be at least 10 characters long")
            .MaximumLength(256)
            .WithMessage("Sms template content must be at most 256 characters long");

        RuleFor(template => template.Type)
            .Equal(NotificationType.Sms)
            .WithMessage("Sms template notification type must be Sms");
    }
}