using Microsoft.AspNetCore.Mvc;

namespace SurvayBasket.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TryController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration configuration = configuration;

    [HttpGet("")]
    public IActionResult TryAsync()
    {
        var connection = configuration.GetConnectionString("DefaultConnection");

        return Ok(connection);
    }
}
