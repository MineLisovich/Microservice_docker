using User.Microservice.Domain.Entities;

namespace User.Microservice.Domain.Repositories
{
    public interface IUserEntity
    {
        IEnumerable<UserEntity> GetAllMessageForUser();
        UserEntity FindMessageForUserByID(int Id);
    }
}
