using Authorization.Microservice.Domain.Entities;

namespace Authorization.Microservice.Domain.Repositories
{
    public class EFUserRepository : IUsersRepository
    {
        private readonly AuthorizationDbContext _dbContext;
        public EFUserRepository(AuthorizationDbContext dbContext) { _dbContext = dbContext; }

        public IEnumerable<Users> GetUsersList()
        {
            return _dbContext.Users.ToList();
        }

        public Users FindByLoginPassword (string login, string password)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Login == login && user.Password == password);
        }
    }
}
