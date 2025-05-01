using Microsoft.AspNetCore.Mvc;
using SurvayBasket.Application.Contracts.Questions;
using SurvayBasket.Application.Services.Questions;
using SurvayBasket.Domain.Consts;
using SurvayBasket.Infrastructure.Authentication.Filters;


namespace SurvayBasket.API.Controllers;
[Route("polls/{PollId}/[controller]")]
[ApiController]

public class QuestionsController(IQuestionService service) : ControllerBase
{
    private readonly IQuestionService service = service;




    [HttpPost]
    [HasPermission(Permissions.AddQuestions)]
    public async Task<IActionResult> AddAsync(int PollId, QuestionRequest request)
    {
        var result = await service.AddAsync(PollId, request);

        if (result.IsSuccess)
            //return CreatedAtAction(nameof(Get), new {PollId,result.Value.Id,result.Value});
            return Ok(result.Value);


        return result.ToProblem();
    }




    [HttpGet("{Id}")]
    [HasPermission(Permissions.GetQuestions)]
    public async Task<IActionResult> Get(int PollId, int Id)
    {
        var result = await service.GetAsync(PollId, Id);

        if (result.IsSuccess)
            return Ok(result.Value);

        return result.ToProblem();
    }



    [HttpGet("")]
    [HasPermission(Permissions.GetQuestions)]
    public async Task<IActionResult> GetAll(int PollId)
    {

        var result = await service.GetAllAsync(PollId);

        if (result.IsSuccess)
            return Ok(result.Value);


        return result.ToProblem();
    }

    [HttpPut("{Id}")]
    [HasPermission(Permissions.UpdateQuestions)]
    public async Task<IActionResult> UpdateQuestion(int PollId, int Id, QuestionRequest request)
    {

        var result = await service.UpdateAsync(PollId, Id, request);

        if (result.IsSuccess)
            return NoContent();


        return result.ToProblem();
    }
}
