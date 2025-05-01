using FluentValidation;

namespace SurvayBasket.Application.Contracts.Votes;

public class VotesAnswerRequestValidator : AbstractValidator<VotesAnswerRequest>
{
    public VotesAnswerRequestValidator()
    {
        RuleFor(x => x.QuestionId)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.AnswerId)
            .GreaterThanOrEqualTo(0);
    }
}
