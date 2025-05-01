
using Microsoft.AspNetCore.Identity;

namespace SurvayBasket.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public bool IsDefault { get; set; }
    public bool IsDeleted { get; set; }
}
