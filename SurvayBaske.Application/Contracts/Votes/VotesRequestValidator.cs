using FluentValidation;

namespace SurvayBasket.Application.Contracts.Votes;

public class VotesRequestValidator : AbstractValidator<VotesRequest>
{
    public VotesRequestValidator()
    {
        RuleFor(x => x.Answers)
            .NotEmpty();

        RuleForEach(x => x.Answers)
            .SetInheritanceValidator(v => v.Add(new VotesAnswerRequestValidator()));

    }
}
