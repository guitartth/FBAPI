using Microsoft.EntityFrameworkCore;
namespace API_FB.Models.Contexts;

public class TeamsContext : DbContext
{
    public TeamsContext(DbContextOptions<TeamsContext> options)
        : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; } = null;

}
