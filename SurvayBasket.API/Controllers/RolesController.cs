using Microsoft.AspNetCore.Mvc;
using SurvayBasket.Application.Contracts.Roles;
using SurvayBasket.Application.Services.Roles;


namespace SurvayBasket.API.Controllers;
[Route("[controller]")]
[ApiController]
public class RolesController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService roleService = roleService;

    [HttpGet("")]
    public async Task<IActionResult> GetAllRoles([FromQuery] bool IncludeDisable)
    {
        var response = await roleService.GetRolesAsync(IncludeDisable);

        return response.IsSuccess ?
            Ok(response.Value) :
            response.ToProblem();

    }

    [HttpGet("role-permissions/{RoleId}")]
    public async Task<IActionResult> GetRolePermission(string RoleId)
    {
        var response = await roleService.GetRoleByIdAsync(RoleId);

        return response.IsSuccess ?
            Ok(response.Value) :
            response.ToProblem();

    }

    [HttpPost("")]
    public async Task<IActionResult> addrole(RoleRequest request)
    {
        var response = await roleService.addroleAsync(request);

        return response.IsSuccess ?
            Ok(response.Value) :
            response.ToProblem();

    }

    [HttpPut("{RoleId}")]
    public async Task<IActionResult> Updaterole(string RoleId, RoleRequest request)
    {
        var response = await roleService.UpdateRoleAsync(RoleId, request);

        return response.IsSuccess ?
            NoContent() :
            response.ToProblem();
    }


    [HttpPut("toggle-status/{RoleId}")]
    public async Task<IActionResult> ToggleStatus(string RoleId)
    {
        var response = await roleService.ToggleStatusAsync(RoleId);

        return response.IsSuccess ?
            NoContent() :
            response.ToProblem();

    }

}
