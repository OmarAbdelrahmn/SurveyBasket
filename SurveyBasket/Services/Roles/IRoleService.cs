using SurveyBasket.Contracts.Roles;

namespace SurveyBasket.Services.Roles;

public interface IRoleService
{
    Task<Result<IEnumerable<RolesResponse>>> GetRolesAsync(bool? IncludeDisable = false);
}
