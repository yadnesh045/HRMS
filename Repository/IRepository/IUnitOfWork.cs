namespace HRMS.Repository.IRepository
{
    public interface IUnitOfWork
    {

        IProjectRepository project { get; set; }
        void Save();
    }
}
