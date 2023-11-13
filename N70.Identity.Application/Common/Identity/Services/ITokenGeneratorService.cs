using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using N70.Identity.Domin.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface ITokenGeneratorService
{
    string GetToken(User user);

    JwtSecurityToken GetJwtToken(User user);

    List<Claim> GetClaims(User user);
}