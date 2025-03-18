using SurveyBasket.Contracts.Users;

namespace SurveyBasket.Services.Admin;

public interface IAdminService
{
     Task<IEnumerable<UserResponse>> GetAllUsers();
     Task<Result<UserResponse>> GetUserAsync(string Id);
     Task<Result<UserResponse>> AddUserAsync(CreateUserRequest request);
}
