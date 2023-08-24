using Microsoft.EntityFrameworkCore;
namespace API_FB.Models.Contexts;

public class PicksContext : DbContext
{
    public PicksContext(DbContextOptions<PicksContext> options)
        : base(options)
    {
    }

    public DbSet<Pick> Picks { get; set; } = null;

}
