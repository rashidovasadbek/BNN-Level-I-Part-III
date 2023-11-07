using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N67.EduCourse.Application.Common.Identity.Services;
using N67.EduCourse.Domin.DTOs;
using N67.EduCourse.Domin.Entities;

namespace N67.EduCourse.Api.Controller;

[ApiController]
[Route("Api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var users = await _userService.Get().ToListAsync();
        return users.Any() ? Ok() : NotFound();
    }

    [HttpGet("userId:guid")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
    {
        var user = await _userService.GetByIdAsync(userId);
        return user != null ? Ok() : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] UserDto userDto)
    {
        var createdUser = await _userService.CreateAsync(userDto);
        return CreatedAtAction(nameof(GetById),
            new
            {
                userId = createdUser.Id
            },
            createdUser);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] UserDto userDto)
    {
        await _userService.UpdateAsync(userDto);
        return Ok();
    }

    [HttpDelete]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid userId)
    {
        await _userService.DeleteAsync(userId);
        return Ok();
    }
}