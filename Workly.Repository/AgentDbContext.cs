using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Workly.Domain;
using Workly.Repository.Models;

namespace Workly.Repository
{
    public class AgentDbContext : IdentityDbContext<ApplicationUser>
    {

        public AgentDbContext(DbContextOptions<AgentDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<UserAddress> UsersAddress { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Mail).IsUnique();
            });
        }

        //Lets take the advantage of.net core and use the DI
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=MyAgentDb; Trusted_Connection=true");
        //}
    }
}
