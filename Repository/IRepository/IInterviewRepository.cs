using HRMS.Models;

namespace HRMS.Repository.IRepository
{
    public interface IInterviewRepository : IRepository<Interview>
    {

        Interview GetById(int Id);
        void Update(Interview obj);




    }
}