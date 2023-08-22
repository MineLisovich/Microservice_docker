using Admin.Microservice.Domain.Entities;

namespace Admin.Microservice.Domain.Repositories
{
    public interface IAdminEntity
    {
        IEnumerable<AdminEntity> GetAllMessageForAdmin();
        AdminEntity FindMessageForAdminByID(int Id);
    }
}
