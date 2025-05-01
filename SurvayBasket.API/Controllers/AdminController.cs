using Microsoft.AspNetCore.Mvc;
using SurvayBasket.Application.Contracts.Users;
using SurvayBasket.Application.Services.Admin;


namespace SurvayBasket.API.Controllers;
[Route("[controller]")]
[ApiController]
public class AdminController(IAdminService service) : ControllerBase
{
    private readonly IAdminService service = service;

    [HttpGet("")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await service.GetAllUsers();

        return users is not null ?
            Ok(users) :
            BadRequest();
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUser(string Id)
    {
        var user = await service.GetUserAsync(Id);

        return user.IsSuccess ?
            Ok(user.Value) :
            user.ToProblem();
    }

    [HttpPost("")]
    public async Task<IActionResult> AddUser(CreateUserRequest request)
    {
        var user = await service.AddUserAsync(request);
        return user.IsSuccess ?
            Ok(user.Value) :
            user.ToProblem();
    }

    [HttpPut("{UserId}")]
    public async Task<IActionResult> UpdateUser(string UserId, UpdateUserRequest request)
    {
        var user = await service.UpdateUserAsync(UserId, request);
        return user.IsSuccess ?
            NoContent() :
            user.ToProblem();
    }

    [HttpPut("toggle-status/{UserId}")]
    public async Task<IActionResult> ToggleStatusAsync(string UserId)
    {
        var user = await service.ToggleStatusAsync(UserId);
        return user.IsSuccess ?
            NoContent() :
            user.ToProblem();
    }


    [HttpPut("unlock-user/{UserId}")]
    public async Task<IActionResult> UnclockUserAsync(string UserId)
    {
        var user = await service.EndLockOutAsync(UserId);
        return user.IsSuccess ?
            NoContent() :
            user.ToProblem();
    }
}
