using SurveyBasket.Abstraction.Consts;

namespace SurveyBasket.Contracts.Users;

public class RoleRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public RoleRequestValidator()
    {
        RuleFor(i => i.CurrentPassword)
            .NotEmpty();


        RuleFor(i => i.NewPassord)
            .NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Password should be 8 digits and should contains Lowercase,Uppercase,Number and Special character ")
            .NotEqual(c => c.CurrentPassword)
            .WithMessage("New password can't be same as current one");


    }
}
