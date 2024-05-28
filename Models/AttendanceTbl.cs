using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class AttendanceTbl
    {
        [Key]
        public int AttendanceId { get; set;}

        public string Name  { get; set; }
        public string date { get; set; }
        public string Attend { get; set;}
    }
}
