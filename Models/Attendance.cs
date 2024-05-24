using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Attendance
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public DateOnly Date { get; set; }

        public string? Shift { get; set; }

        public TimeSpan ScheduleInTime { get; set; }
        public TimeSpan ScheduleOutTime { get; set; }

        public TimeSpan ActualInTime { get; set; }

       
        public TimeSpan ActualOutTime { get; set; }






        public TimeSpan? TotalWorkingTime { get; set; }
        public TimeSpan? LateBy { get; set; }

        public string? Status { get; set; }



    }
}
