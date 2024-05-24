using HRMS.Models;

namespace HRMS.Repository.IRepository
{
    public interface IUsersRepository : IRepository<User>
    {
        User GetByEmployeeID(int id);
        User GetById(int Id);

        void Update(User obj);
    }
}
