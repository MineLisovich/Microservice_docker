using Admin.Microservice.Domain.Entities;

namespace Admin.Microservice.Domain.Repositories
{
    public class EFAdminEntity : IAdminEntity
    {
        private readonly AdminDbContext _dbContext;
        public EFAdminEntity(AdminDbContext dbContext) { _dbContext = dbContext; }

        public IEnumerable<AdminEntity> GetAllMessageForAdmin()
        {
            return _dbContext.AdminEntity.ToList();
        }

        public AdminEntity FindMessageForAdminByID(int Id)
        {
            return _dbContext.AdminEntity.Find(Id);
        }
    }
}
