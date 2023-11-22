using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using N73.Notification.Infrastructure.Common.Notifications.Services;
using N73.Notifications.Application.Common.Models.Quering;
using N73.Notifications.Application.Common.Models.Querying;
using N73.Notifications.Application.Common.Notifications.Models;
using N73.Notifications.Application.Common.Notifications.Services;
using N73.Notifications.Domin.Entities;

namespace Notifications.Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationAggregatorService _notificationAggregatorService;

    public NotificationsController(INotificationAggregatorService notificationAggregatorService)
    {
        _notificationAggregatorService = notificationAggregatorService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> Send([FromBody] NotificationRequest request)
    {
        var result = await _notificationAggregatorService.SendAsync(request);
        return result.IsSuccess && (result?.Data ?? false) ? Ok() : BadRequest();
    }

    [HttpGet("templates")]
    public async ValueTask<IActionResult> GetTemplates([FromQuery] NotificationTemplateFilter filter,
        CancellationToken cancellationToken)
    {
        var result = await _notificationAggregatorService.GetTemplatesByFilterAsync(filter, cancellationToken);
        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpGet("templaets/emails")]
    public async ValueTask<IActionResult> GetEmailTemplates(
        [FromQuery] FilterPagination filterPagination,
        [FromServices] IEmailTemplateService emailTemplateService,
        bool cancellationToken
    )
    {
        var result = await emailTemplateService.GetByFilterAsync(filterPagination, cancellationToken);
        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpGet("templates/sms")]
    public async ValueTask<IActionResult> GetSmsTemplates(
        [FromQuery] FilterPagination filterPagination,
        [FromServices] ISmsTemplateService smsTemplateService,
        bool cancellationToken
    )
    {
        var result = await smsTemplateService.GetByFilterAsync(filterPagination, cancellationToken);
        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpPost("templates/sms")]
    public async ValueTask<IActionResult> CreateSmsTemplates(
        [FromBody] SmsTemplate smsTemplate,
        [FromServices] ISmsTemplateService smsTemplateService,
        CancellationToken cancellationToken
    )
    {
        var result = await smsTemplateService.CreateAsync(smsTemplate, cancellationToken: cancellationToken);
        return Ok(result);
    }
    
    [HttpPost("templates/emails")]
    public async ValueTask<IActionResult> CreateEmailTemplates(
        [FromBody] EmailTemplate emailTemplate,
        [FromServices] IEmailTemplateService emailTemplateService,
        CancellationToken cancellationToken
    )
    {
        var result = await emailTemplateService.CreateAsync(emailTemplate, cancellationToken: cancellationToken);
        return Ok(result);
    }

}