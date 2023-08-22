using Admin.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Admin.Microservice.Domain
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }

        public DbSet<AdminEntity>? AdminEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<AdminEntity>().HasData(new AdminEntity
            {
                Id = 1,
                MessageForAdmin = "Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью АДМИН"
            });
            modelBuilder.Entity<AdminEntity>().HasData(new AdminEntity
            {
                Id = 2,
                MessageForAdmin = "Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью АДМИН(2)"
            });
        }
    }
}
