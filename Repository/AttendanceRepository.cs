using HRMS.Data;
using HRMS.Models;
using HRMS.Repository.IRepository;

namespace HRMS.Repository
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        private readonly ApplicationDbContext db;
        public AttendanceRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

       

        public void Update(Attendance obj)
        {
            db.Attendances.Update(obj);
        }
    }
    
}
