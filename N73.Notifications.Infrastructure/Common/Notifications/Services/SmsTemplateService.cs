using System.Linq.Expressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using N73.Notifications.Application.Common.Models.Quering;
using N73.Notifications.Application.Common.Notifications.Services;
using N73.Notifications.Application.Common.Querying.Extensions;
using N73.Notifications.Domin.Entities;
using N73.Notifications.Domin.Enums;
using N73.Notifications.Persistance.Repositories;

namespace N73.Notification.Infrastructure.Common.Notifications.Services;

public class SmsTemplateService : ISmsTemplateService
{
    private readonly ISmsTemplateRepository _smsTemplateRepository;
    private readonly IValidator<SmsTemplate> _smsTemplateValidator;


    public SmsTemplateService(
        ISmsTemplateRepository smsTemplateRepository,
        IValidator<SmsTemplate> smsTemplateValidator
        )
    {
        _smsTemplateRepository = smsTemplateRepository;
        _smsTemplateValidator = smsTemplateValidator;
    }

    public IQueryable<SmsTemplate> Get(
        Expression<Func<SmsTemplate, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        _smsTemplateRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<SmsTemplate>> GetByFilterAsync(
        FilterPagination filterPagination,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await Get(asNoTracking: asNoTracking)
            .ApplyPagination(filterPagination)
            .ToListAsync(cancellationToken: cancellationToken);


    public async ValueTask<SmsTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await _smsTemplateRepository.Get(template => template.TemplateType == templateType, asNoTracking)
            .SingleOrDefaultAsync(cancellationToken);


    public ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChange = false,
        CancellationToken cancellationToken = default
    )
    {
        var validationResult = _smsTemplateValidator.Validate(smsTemplate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return _smsTemplateRepository.CreateAsync(smsTemplate, saveChange, cancellationToken);
    }
}