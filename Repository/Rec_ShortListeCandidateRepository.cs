using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;

namespace HRMS.Repository
{
    internal class Rec_ShortListeCandidateRepository : Repository<ShorList>, IRec_ShortListeCandidateRepository
    {
        public readonly ApplicationDbContext db;
        public Rec_ShortListeCandidateRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public ShorList GetById(int Id)
        {
            return db.ShortListed_Candiates.Find(Id);
        }

        public void Update(ShorList obj)
        {
            db.ShortListed_Candiates.Update(obj);
        }
    }
}