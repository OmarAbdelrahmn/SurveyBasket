using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Services.Admin;
using SurveyBasket.Services.User;

namespace SurveyBasket.Controllers;
[Route("[controller]")]
[ApiController]
public class AdminController(IAdminService service) : ControllerBase
{
    private readonly Services.Admin.IAdminService service = service;

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
        var users = await service.GetUserAsync(Id);

        return users.IsSuccess ?
            Ok(users) :
            users.ToProblem();
    }
}
