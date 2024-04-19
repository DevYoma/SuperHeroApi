global using Microsoft.EntityFrameworkCore;

namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        // this can be done in the Program.cs file too 👇
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true;");
        //}

        // create tables
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
