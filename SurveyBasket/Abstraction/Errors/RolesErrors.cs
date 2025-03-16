namespace SurveyBasket.Abstraction.Errors;

public static class RolesErrors
{
    public static readonly Error InvalidCredentials = new("Invalid credentials", "Invalid Role Credentials", StatusCodes.Status404NotFound);
    public static readonly Error NotFound = new("Invalid credentials", "NotFound", StatusCodes.Status404NotFound);
    public static readonly Error DaplicatedTitle = new("Invalid credentials", "Daplicated Poll Title", StatusCodes.Status409Conflict);

}
