
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurvayBasket.Application.Contracts.Polls;
using SurvayBasket.Application.Services.Polls;
using SurvayBasket.Domain.Consts;
using SurvayBasket.Infrastructure.Authentication.Filters;


namespace SurvayBasket.API.Controllers;


[Route("[controller]")]
[ApiController]
public class PollsController(IPollsService service) : ControllerBase
{
    private readonly IPollsService service = service;

    [HttpGet("")]
    [HasPermission(Permissions.GetPolls)]
    [Authorize(Roles = "Admin")]

    public async Task<IActionResult> GetAll()
    {
        var response = await service.GetPollsAsync();

        return response.IsSuccess ? Ok(response.Value) :
            response.ToProblem();
    }



    [HttpGet("current")]
    [Authorize(Roles = DefaultRoles.Member)]
    public async Task<IActionResult> GetCurrent()
    {
        var response = await service.GetCurrentAsync();

        return response.IsSuccess ? Ok(response.Value) :
            response.ToProblem();
    }



    [HttpGet("{Id}")]
    [HasPermission(Permissions.GetPolls)]

    public async Task<IActionResult> Get(int Id)
    {
        var response = await service.GetPollByIdAsync(Id);

        return response.IsSuccess ? Ok(response.Value) :
        response.ToProblem();


    }




    [HttpPost("")]
    [HasPermission(Permissions.AddPolls)]

    public async Task<IActionResult> add(PollRequest request)
    {
        var response = await service.CreatePollAsync(request);

        return response.IsSuccess ?
            Ok(response.Value) :
            response.ToProblem();

    }



    [HttpPut("{Id}")]
    [HasPermission(Permissions.UpdatePolls)]

    public async Task<IActionResult> update(int Id, PollRequest request)
    {

        var response = await service.UpdatePollAsync(Id, request);

        return response.IsSuccess ? Ok(response.Value) :
            response.ToProblem();
    }




    [HttpDelete("{Id}")]
    [HasPermission(Permissions.DeletePolls)]

    public IActionResult delete(int Id, CancellationToken cancellationToken)
    {
        var response = service.DeletePollAsync(Id, cancellationToken);

        return Ok(response);
    }



    [HttpPut("toggle/{Id}")]
    [HasPermission(Permissions.UpdatePolls)]
    public async Task<IActionResult> Toggle(int Id)
    {
        var response = await service.ToggleStatus(Id);
        return response.IsSuccess ?
            Ok(response) :
            response.ToProblem();
    }
}
