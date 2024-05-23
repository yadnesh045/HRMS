using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;

namespace HRMS.Repository
{
    internal class Rec_CandidateRepository : Repository<Rec_Candidate>, IRec_CandidateRepository
    {

        private readonly ApplicationDbContext db;
        public Rec_CandidateRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public Rec_Candidate GetById(int Id)
        {
            return db.Candiates.Find(Id);
        }

        public void Update(Rec_Candidate obj)
        {
            db.Candiates.Update(obj);
        }
    }
}