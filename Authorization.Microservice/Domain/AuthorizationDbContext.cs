using Authorization.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Microservice.Domain
{
    public class AuthorizationDbContext : DbContext
    {
        public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) : base(options) { }

        public DbSet<Users>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Users>().HasData(new Users
            {
               Id = 1,
               Login = "A_daniil",
               Password = "A_daniil",
               Role = "Admin"
              
            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 2,
                Login = "U_daniil",
                Password = "U_daniil",
                Role = "User"

            });
        }
    }
}
