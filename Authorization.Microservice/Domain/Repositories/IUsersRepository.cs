using Authorization.Microservice.Domain.Entities;

namespace Authorization.Microservice.Domain.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetUsersList();
        Users FindByLoginPassword(string login, string password);
    }
}
