﻿namespace SurveyBasket.Entites;

public sealed class ApplicataionUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsDisable { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; } = [];

}
