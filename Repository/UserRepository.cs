using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;

namespace HRMS.Repository
{
    public class UserRepository : Repository<User>, IUsersRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {   
            this.db = db;
        }

        public User GetByEmployeeID(int id)
        {
            return db.Users.FirstOrDefault(u => u.EmployeeId == id);
        }

        public User GetById(int Id)
        {
            return db.Users.Find(Id);
        }


        public void Update(User obj)
        {
            db.Users.Update(obj);
        }
    }
}
