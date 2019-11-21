using English.Models;
using Microsoft.EntityFrameworkCore;

namespace English.Models
{
    // >dotnet ef migration add testMigration
    public class EnglishDBContext : DbContext
    {
        public EnglishDBContext(DbContextOptions<EnglishDBContext> options) : base(options)
        {

        }

        public DbSet<Word> Words { get; set; }
        public DbSet<Example> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Word>().HasKey(m => m.ID);
            base.OnModelCreating(builder);
        }
    }
}