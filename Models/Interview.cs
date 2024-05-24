using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Interview
    {
        [Key]
        public int id { get; set; }

        public string place { get; set; }

        public DateTime Date { get; set; }

        public string CandidateName { get; set; }

        public string CandidateEmail { get; set; }
    }
}
