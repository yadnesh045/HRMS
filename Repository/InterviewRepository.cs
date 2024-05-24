using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;

namespace HRMS.Repository
{
    internal class InterviewRepository : Repository<Interview>, IInterviewRepository
    {
        public readonly ApplicationDbContext db;
        public InterviewRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public Interview GetById(int Id)
        {
            return db.Intervies.Find(Id);
        }

        public void Update(Interview obj)
        {
            db.Intervies.Update(obj);
        }
    }
}