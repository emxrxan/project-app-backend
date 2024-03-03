using Microsoft.EntityFrameworkCore;
using PortfolioPorjekt.Resources;

namespace PortfolioPorjekt
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        { 
        }

        public DbSet<HaushaltRechnerResource> DbHaushaltRechner { get; set; }
    }
}
