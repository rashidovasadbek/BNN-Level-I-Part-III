using AutoMapper;
using N73.Notifications.Application.Common.Identity.Services;
using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Application.Common.Notifications.Services;
using N73.Notifications.Domin.Common.Exceptions;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Domin.Enums;
using N73.Notifications.Domin.Extensions;
using N73.Notifications.Persistance.DataContexts;
using Twilio.Rest.Content.V1;

namespace N73.Notification.Infrastructure.Common.Notifications.Services;

public class SmsOrchestrationService : ISmsOrchestrationService
{
    private readonly IMapper _mapper;
    private readonly ISmsSenderService _smsSenderService;
    private readonly ISmsHistoryService _smsHistoryService;
    private readonly NotificationDbContext _dbContext;
    private readonly IUserService _userService;
    private readonly ISmsTemplateService _smsTemplateService;
    private readonly ISmsRenderingService _smsRenderingService;

    public SmsOrchestrationService(
        IMapper mapper,
        ISmsSenderService smsSenderService,
        ISmsRenderingService smsRenderingService,
        ISmsHistoryService smsHistoryService,
        NotificationDbContext dbContext,
        ISmsTemplateService smsTemplateService,
        IUserService userService
        
        )
    {
        _mapper = mapper;
        _smsSenderService = smsSenderService;
        _smsRenderingService = smsRenderingService;
        _smsHistoryService = smsHistoryService;
        _dbContext = dbContext;
        _smsTemplateService = smsTemplateService;
        _userService = userService;
    }
    public async ValueTask<FuncResult<bool>> SendAsync(
        SmsNotificationRequest request, 
        CancellationToken cancellationToken)
    {
        var sendNotificationRequest = async () =>
        {
            var message = _mapper.Map<SmsMessage>(request);
            // get users
            // set receiver phone number and sender phone number

            var senderUser =
                (await _userService.GetByIdAsync(request.SenderUserId!.Value, cancellationToken: cancellationToken))!;

            var receiverUser =
                (await _userService.GetByIdAsync(request.ReceiverUserId, cancellationToken: cancellationToken))!;

            message.SenderPhoneNumber = senderUser.PhoneNumber;
            message.ReceiverPhoneNumber = receiverUser.PhoneNumber;

            //get template

            message.Template =
                await _smsTemplateService.GetByTypeAsync(request.TemplateType, true,
                    cancellationToken: cancellationToken) ??
                throw new InvalidOperationException(
                    $"Invalid template for sending {NotificationType.Sms} notification");

            //render template
            await _smsRenderingService.RenderAsync(message, cancellationToken);

            //send message
            await _smsSenderService.SendAsync(message, cancellationToken);

            //save history

            var history = _mapper.Map<SmsHistory>(message);
            var test = _dbContext.Entry(history.Template).State;

            await _smsHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

            return history.IsSuccessful;
        };

        return await sendNotificationRequest.GetValueAsync();
    }
}