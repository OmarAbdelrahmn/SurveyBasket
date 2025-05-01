﻿using FluentValidation;

namespace SurvayBasket.Application.Contracts.Roles;

public class RoleRequestValidator : AbstractValidator<RoleRequest>
{
    public RoleRequestValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .Length(3, 256);


        RuleFor(i => i.Permissions)
            .NotEmpty()
            .NotNull();


        RuleFor(i => i.Permissions)
            .Must(i => i.Distinct().Count() == i.Count)
            .WithMessage("you can't add duplicated permission for the role")
            .When(c => c.Permissions != null);


    }
}
