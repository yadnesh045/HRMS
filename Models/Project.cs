using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Project
    {
        [Key]
        public int id { get; set; }


        public DateTime CreatedDate { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string Status { get; set; }
        public string ClientCompany { get; set; }
        public string ProjectLeader { get; set; }
        public string Estimatedbudget { get; set; }
        public string Totalamountspent { get; set; }
        public string Estimatedprojectduration { get; set; }
        public int ProjectProgress { get; set; }
    }
}
