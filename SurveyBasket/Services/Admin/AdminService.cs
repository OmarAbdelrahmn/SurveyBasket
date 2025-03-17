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
               //to not include members : where r.Name != DefaultRoles.Member  || where !roles.any(c=>c.name == DefaultRoles.Member)
               select new UserResponse
               (
                   u.Id,
                   u.FirstName,
                   u.LastName,
                   u.Email!,
                   u.IsDisable,
                   roles.Select(r=>r.Name!).ToList()
                ))
                  .ToListAsync();
}
