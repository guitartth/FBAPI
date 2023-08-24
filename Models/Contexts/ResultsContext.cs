using Microsoft.EntityFrameworkCore;
namespace API_FB.Models.Contexts;

public class ResultsContext : DbContext
{
    public ResultsContext(DbContextOptions<ResultsContext> options)
        : base(options)
    {
    }

    public DbSet<Result> Results { get; set; } = null;

}
