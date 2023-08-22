using Microsoft.EntityFrameworkCore;
using User.Microservice.Domain.Entities;

namespace User.Microservice.Domain
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<UserEntity>? UserEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = 1,
                MessageForUser = "Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью USER"
            });
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = 2,
                MessageForUser = "Это сообщение должен видеть только АВТОРИЗОВАННЫЙ пользователь под ролью USER(2)"
            });
        }
    }
}
