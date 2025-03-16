using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        return response is not null ?
            Ok(response.Value) :
            response!.ToProblem();

    }

}
