using HRMS.Models;

namespace HRMS.Repository.IRepository
{
    public interface IUsersRepository : IRepository<User>
    {
        User GetById(int Id);

        void Update(User obj);
    }
}
