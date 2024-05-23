using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Rec_Candidate
    {
        [Key]
        public int id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public string Address { get; set; }

        public string Experince { get; set; }


        [ValidateNever ]
        public string Resumeurl { get; set; }

    }
}
