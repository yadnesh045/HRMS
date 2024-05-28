using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class EmployeeData
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string AttendanceDate { get; set; }
        public string Shift { get; set; }
        public string ScheduledInTime
        { get; set; }
        public string ScheduledOutTime
        { get; set; }
        public string ActualInTime
        { get; set; }
        public string ActualOutTime
        { get; set; }
        public string WorkDuration
        { get; set; }
        public string Overtime

        { get; set; }
        public string TotalDuration

        { get; set; }
        public string LateBy

        { get; set; }
        public string EarlyGoingBy

        { get; set; }
        public string Status

        { get; set; }

        public string PunchRecords


        { get; set; }
    }
}
