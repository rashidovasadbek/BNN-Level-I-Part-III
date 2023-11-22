using AutoMapper;
using N73.Notifications.Application.Common.Identity.Services;
using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Application.Common.Notifications.Services;
using N73.Notifications.Domin.Common.Exceptions;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Domin.Enums;
using N73.Notifications.Domin.Extensions;

namespace N73.Notification.Infrastructure.Common.Notifications.Services;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    private readonly IMapper _mapper;
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IEmailRenderingService _emailRenderingService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IEmailHistoryService _emailHistoryService;
    private readonly IUserService _userService;

    public EmailOrchestrationService(
        IMapper mapper,
        IEmailTemplateService emailTemplateService,
        IEmailRenderingService emailRenderingService,
        IEmailSenderService emailSenderService,
        IEmailHistoryService emailHistoryService,
        IUserService userService
        )
    {
        _mapper = mapper;
        _emailTemplateService = emailTemplateService;
        _emailRenderingService = emailRenderingService;
        _emailSenderService = emailSenderService;
        _emailHistoryService = emailHistoryService;
        _userService = userService;
    }
    public async ValueTask<FuncResult<bool>> SendAsync(
        EmailNotificationRequest request,
        CancellationToken cancellationToken)
    {
       // validate
       var sendNotificationRequest = async () =>
       {
           var message = _mapper.Map<EmailMessage>(request);

           // GetUsers
           // set receiver phone number and sender phone number
           var senderUser =
               (await _userService.GetByIdAsync(request.SenderUserId!.Value, cancellationToken: cancellationToken))!;

           var receiverUser =
               (await _userService.GetByIdAsync(request.ReceiverUserId, cancellationToken: cancellationToken))!;

           message.Template =
               await _emailTemplateService.GetByTypeAsync(request.TemplateType, true, cancellationToken) ??
               throw new InvalidOperationException($"Invalid template for sending {NotificationType.Sms} notification");
           // render Template
           await _emailRenderingService.RenderAsync(message, cancellationToken);

           //send message
           await _emailSenderService.SendAsync(message, cancellationToken);

           //save history
           var history = _mapper.Map<EmailHistory>(message);
           await _emailHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

           return history.IsSuccessful;
       };

       return await sendNotificationRequest.GetValueAsync();
    }
}