using Microsoft.AspNetCore.Authorization;

namespace SurvayBasket.Infrastructure.Authentication.Filters;

public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
{
}