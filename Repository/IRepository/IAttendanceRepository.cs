using HRMS.Models;

namespace HRMS.Repository.IRepository
{
    public interface IAttendanceRepository :IRepository<Attendance>
    {
        void Update(Attendance obj);
    }
}
