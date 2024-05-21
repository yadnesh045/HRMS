using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public UserRole GetByEmail(string email)
        {
            return _db.UserRoles.Where(x => x.Email == email).FirstOrDefault();
        }

        public void Update(UserRole obj)
        {
            _db.UserRoles.Update(obj);
        }
    }
    
}
