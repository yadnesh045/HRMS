namespace HRMS.Repository.IRepository
{
    public interface IUnitOfWork
    {

        IProjectRepository project { get; set; }
        IRolesRepository Roles { get; set; }
        IUsersRepository Users { get; set; }
        IUserRoleRepository UserRole { get; set; }

        IRec_CandidateRepository Candidate { get; set; }

        IRec_ShortListeCandidateRepository ShortListed { get; set; }
        void Save();
    }
}
