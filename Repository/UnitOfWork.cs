using HRMS.Data;
using HRMS.Repository.IRepository;
using System.Reflection;

namespace HRMS.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IProjectRepository project { get; set; }
        public IRolesRepository Roles { get; set; }
        public IUsersRepository Users { get; set; }
        public IUserRoleRepository UserRole { get; set; }
        public IRec_CandidateRepository Candidate { get; set; }
        public IRec_ShortListeCandidateRepository ShortListed { get; set; }
        public IAttendanceRepository Attendance { get; set; }
        public IInterviewRepository Interview { get; set; }


        public UnitOfWork(ApplicationDbContext _db)
        {
            project = new ProjectRepository(_db);
            Users = new UserRepository(_db);
            Roles = new RolesRepository(_db);
            UserRole = new UserRoleRepository(_db);
            Candidate = new Rec_CandidateRepository(_db);
            ShortListed = new Rec_ShortListeCandidateRepository(_db);
            Attendance = new AttendanceRepository(_db);

            Interview = new InterviewRepository(_db);
            this._db = _db;

        }

       

        public void Save()
        {
            _db.SaveChanges();

        }
    }
}
