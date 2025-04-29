using Microsoft.EntityFrameworkCore;


namespace SurvayBaske.Infrastructure.Dbcontext;
internal class AppDbcontext(DbContextOptions<AppDbcontext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

