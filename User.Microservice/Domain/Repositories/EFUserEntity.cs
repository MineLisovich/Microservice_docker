using User.Microservice.Domain.Entities;

namespace User.Microservice.Domain.Repositories
{
    public class EFUserEntity : IUserEntity
    {
        private readonly UserDbContext _dbContext;
        public EFUserEntity(UserDbContext dbContext) { _dbContext = dbContext; }

        public IEnumerable<UserEntity> GetAllMessageForUser()
        {
            return _dbContext.UserEntity.ToList();
        }

        public UserEntity FindMessageForUserByID(int Id)
        {
            return _dbContext.UserEntity.Find(Id);
        }
    }
}
