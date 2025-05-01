using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SurvayBasket.Infrastructure.Dbcontext;

namespace SurvayBasket.Infrastructure;
public static class InfraDependencies
{
    // This class is used to group all the dependencies related to the infrastructure layer.

    public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration Configuration)
    {
        services.AddDbContext<AppDbcontext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
