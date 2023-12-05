using Cashing.Infra.Application.Common.Extensions;
using Cashing.Infra.Application.Common.Identity.Service;
using Cashing.Infra.Application.Common.Querying;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cashing.Infra.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
   [HttpGet]
   public async ValueTask<IActionResult> GetById([FromQuery] FilterPagination filterPagination)
   {
      var result = await userService.Get(asNoTracking: true).ApplyPagination(filterPagination).ToListAsync();
      return result.Any() ? Ok(result) : NotFound();
   }

   [HttpGet("{userId:guid}")]
   public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
   {
      var result = await userService.GetByIdAsync(userId);
      return result is not null ? Ok(result) : NotFound();
   }
}