using Microsoft.AspNet.Identity.EntityFramework;

namespace SurvayBasket.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public bool IsDefault { get; set; }
    public bool IsDeleted { get; set; }
}
