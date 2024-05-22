using HRMS.Models;

namespace HRMS.Repository.IRepository
{
    public interface IRolesRepository : IRepository<Roles>
    {
        void Update(Roles obj);

    }
}
