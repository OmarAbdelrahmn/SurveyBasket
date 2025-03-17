using SurveyBasket.Abstraction.Consts;
using SurveyBasket.Contracts.Users;

namespace SurveyBasket.Services.Admin;

public class AdminService(UserManager<ApplicataionUser> manager , ApplicationDbcontext dbcontext) : IAdminService
{
    private readonly UserManager<ApplicataionUser> manager = manager;
    private readonly ApplicationDbcontext dbcontext = dbcontext;

    public async Task<IEnumerable<UserResponse>> GetAllUsers() =>
        await (from u in dbcontext.Users
               join ur in dbcontext.UserRoles
               on u.Id equals ur.UserId
               join r in dbcontext.Roles
               on ur.RoleId equals r.Id into roles
               //to not include members : where r.Name != DefaultRoles.Member  ||
               //where !roles.Any(c=>c.Name == DefaultRoles.Member)
               select new
               {
                   u.Id,
                   u.FirstName,
                   u.LastName,
                   u.Email,
                   u.IsDisable,
                   roles = roles.Select(r => r.Name!).ToList()
               })
                  .GroupBy(x=> new {x.Id , x.FirstName , x.LastName , x.Email , x.IsDisable})
                  .Select(c=> new UserResponse (
                      c.Key.Id,
                      c.Key.FirstName,
                      c.Key.LastName,   
                      c.Key.Email,
                      c.Key.IsDisable,
                      c.SelectMany(x=>x.roles)
                      ))
                  .ToListAsync();

    public async Task<Result<UserResponse>> GetUserAsync(string Id)
    {
        if(await manager.FindByIdAsync(Id) is not { } user)
            return Result.Failure<UserResponse>(UserErrors.UserNotFound);

        var userroles = await manager.GetRolesAsync(user);

        var response = (user , userroles).Adapt<UserResponse>();  

        return Result.Success(response);
    }
}
