using HRMS.Data;
using HRMS.Repository.IRepository;
using System.Reflection;

namespace HRMS.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext _db)
        {
            this._db = _db;

        }
        public void Save()
        {
            _db.SaveChanges();

        }
    }
}
