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

public class EmailTemplateService : IEmailTemplateService
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IValidator<EmailTemplate> _emailTemplateValidator;

    public EmailTemplateService(
        IEmailTemplateRepository emailTemplateRepository,
        IValidator<EmailTemplate> emailTemplateValidator
        )
    {
        _emailTemplateRepository = emailTemplateRepository;
        _emailTemplateValidator = emailTemplateValidator;
    }

    public IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false
        ) =>
        _emailTemplateRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<EmailTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await Get(asNoTracking: asNoTracking)
            .ApplyPagination(paginationOptions)
            .ToListAsync(cancellationToken: cancellationToken);


    public async ValueTask<EmailTemplate> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await _emailTemplateRepository.Get(template => template.TemplateType == templateType, asNoTracking)
            .SingleOrDefaultAsync(cancellationToken);


    public ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        var validationResult = _emailTemplateValidator.Validate(emailTemplate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return _emailTemplateRepository.CreateAsync(emailTemplate, asNoTracking, cancellationToken);
    }
}