using CommandService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(s => s.Platform)
                .HasForeignKey(s => s.PlatformId);

                modelBuilder.Entity<Command>()
               .HasOne(p => p.Platform)
               .WithMany(s => s.Commands)
               .HasForeignKey(s => s.PlatformId);
        }
    }
}
