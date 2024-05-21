using HRMS.Models;

namespace HRMS.Repository.IRepository
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        UserRole GetByEmail(string email );

        void Update(UserRole obj);


    }
}
