using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;
using System.Linq.Expressions;

namespace HRMS.Repository
{
    public class RolesRepository : Repository<Roles>, IRolesRepository
    {
        private readonly ApplicationDbContext db;

        public RolesRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        public void Update(Roles obj)
        {
            db.Roles.Update(obj);
        }
    }
}
