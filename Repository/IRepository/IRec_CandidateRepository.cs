using HRMS.Models;

namespace HRMS.Repository.IRepository
{
    public interface IRec_CandidateRepository : IRepository<Rec_Candidate>
    {
        Rec_Candidate GetById(int Id);
        void Update(Rec_Candidate obj);
    }
}