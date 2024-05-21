using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;

namespace HRMS.Repository
{
    internal class ProjectRepository : Repository<Project>, IProjectRepository
    {

        private readonly ApplicationDbContext db;
        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public Project GetById(int Id)
        {
            return db.Projects.Find(Id);
        }

        public void Update(Project obj)
        {
            db.Projects.Update(obj);
        }
    }
}