using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurvayBasket.Application.Contracts.Votes;
using SurvayBasket.Application.Services.Questions;
using SurvayBasket.Application.Services.Votes;
using SurvayBasket.Domain.Consts;
using SurvayBasket.Infrastructure.Extensions;
//using System.Web.Http;

namespace SurvayBasket.API.Controllers;

[Route("polls/{PollId}/[controller]")]
[ApiController]
[Authorize(Roles = DefaultRoles.Member)]
public class VotesController(IQuestionService service, IVotesService service1) : ControllerBase
{
    private readonly IQuestionService service = service;
    private readonly IVotesService service1 = service1;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(int PollId)
    {
        var userId = User.GetUserId();

        var result = await service.GetAvailableAsync(PollId, userId!);

        if (result.IsSuccess)
            return Ok(result.Value);

        return result.ToProblem();
    }

    [HttpPost("")]
    public async Task<IActionResult> AddVote([FromRoute] int PollId, [FromBody] VotesRequest request)
    {
        var userId = User.GetUserId();

        var result = await service1.AddVote(PollId, userId!, request);

        if (result.IsSuccess)
            return Created();

        return result.ToProblem();

    }

}
