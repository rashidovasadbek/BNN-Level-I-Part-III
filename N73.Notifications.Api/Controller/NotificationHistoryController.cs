using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N73.Notifications.Application.Common.Notifications.Services;
using N73.Notifications.Persistance.Repositories;

namespace Notifications.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class NotificationHistoryController : ControllerBase
{
  [HttpGet("sms")]
  public async ValueTask<IActionResult> Get([FromServices] ISmsHistoryRepository repo) =>
    Ok(await repo.Get().ToListAsync());

  [HttpGet("email")]
  public async ValueTask<IActionResult> Get([FromServices] IEmailHistoryRepository repo) =>
    Ok(await repo.Get().ToListAsync());
}