using HRMS.Models;

namespace HRMS.Repository.IRepository
{
    public interface IRec_ShortListeCandidateRepository : IRepository<ShorList>
    {
        ShorList GetById(int Id);
        void Update(ShorList obj);
    }
}