using HRMS.Models;

namespace HRMS.Repository.IRepository
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetById(int Id);
        void Update(Project obj);
    }
}