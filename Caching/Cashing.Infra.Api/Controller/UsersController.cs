using Cashing.Infra.Application.Common.Extensions;
using Cashing.Infra.Application.Common.Identity.Service;
using Cashing.Infra.Domain.Common.Entities;
using Cashing.Infra.Domain.Common.Query;
using Microsoft.AspNetCore.Mvc;
using FilterPagination = Cashing.Infra.Application.Common.Querying.FilterPagination;

namespace Cashing.Infra.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
   [HttpGet]
   public async ValueTask<IActionResult> GetById([FromQuery] FilterPagination paginationOptions, CancellationToken cancellationToken = default)
   {
      var specificationA = new QuerySpecification<User>(paginationOptions.PageSize, paginationOptions.PageToken);

      specificationA.FilteringOptions.Add(user => user.FirstName.Length > 4);
      specificationA.FilteringOptions.Add(user => user.LastName.Length > 5);

      var specificationB = new QuerySpecification<User>(paginationOptions.PageSize, paginationOptions.PageToken);

      specificationB.FilteringOptions.Add(user => user.LastName.Length > 5);
      specificationB.FilteringOptions.Add(user => user.FirstName.Length > 4);

      var resultA = await userService.GetAsync(specificationA, true, cancellationToken);
      var resultB = await userService.GetAsync(specificationB, true, cancellationToken);
      return resultA.Any() ? Ok(resultA) : NotFound();
   }

   [HttpGet("{userId:guid}")]
   public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
   {
      var result = await userService.GetByIdAsync(userId);
      return result is not null ? Ok(result) : NotFound();
   }
}