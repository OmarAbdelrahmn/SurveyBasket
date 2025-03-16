using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Contracts.Roles;
using SurveyBasket.Services.Roles;

namespace SurveyBasket.Controllers;
[Route("api/[controller]")]
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

}
