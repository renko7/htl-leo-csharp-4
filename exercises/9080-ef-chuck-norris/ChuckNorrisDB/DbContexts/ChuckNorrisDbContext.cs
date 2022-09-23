using ChuckNorrisClassLibrary;
using Microsoft.EntityFrameworkCore;


namespace ChuckNorrisDB.DbContexts
{
    public class ChuckNorrisDbContext : DbContext
    {
        public ChuckNorrisDbContext(DbContextOptions<ChuckNorrisDbContext> options)
            : base(options)
        { }

        public DbSet<ChuckNorrisFact> ChuckNorrisFacts { get; set;}
    }
}
