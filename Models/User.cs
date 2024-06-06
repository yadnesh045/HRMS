using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        // personal information
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [Phone]
        public string Contact { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhar number must be 12 digits long.")]
        public string AadharNumber { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Pancard number must be 10 characters long.")]
        public string PancardNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }





        // work experience
        public string? PreviousCompanyName { get; set; }

        public string? PreviousCompanyJobTitle { get; set; }

        public DateOnly PreviousCompanyJoiningDate { get; set; }

        public DateOnly PreviousCompanyLeavingDate { get; set; }

  
        public string? PreviousCompanyCTC { get; set; }



        // educational details
        
        public string? MastersEducation { get; set; }

        public string? MastersUniversity { get; set; }

       
        [Range(0.00, 10.00, ErrorMessage = "CGPA must be between 0.00 and 10.00.")]
        public decimal MastersPercentage { get; set; }



        [NotMapped]
        [Display(Name = "Masters Certificate")]
        public IFormFile? MastersCertificate { get; set; }

        public string? MastersCertificateURL { get; set; }

        
        public string? BachelorsEducation { get; set; }

 
        public string? BachelorsUniversity { get; set; }

       


        [Range(0.00, 10.00, ErrorMessage = "CGPA must be between 0.00 and 10.00.")]
        public decimal BachelorsPercentage { get; set; }



        [NotMapped]
        [Display(Name = "Bachelors Certificate")]
        public IFormFile? BachelorsCertificate { get; set; }

        public string? BachelorsCertificateURL { get; set; }


        // documents
        [NotMapped]
        [Display(Name = "Resume")]
        public IFormFile? Resume { get; set; }

        public string? ResumeURL { get; set; }

        [NotMapped]
        [Display(Name = "Aadhar Card")]
        public IFormFile? AadharCard { get; set; }

        public string? AadharCardURL { get; set; }

        [NotMapped]
        [Display(Name = "Photo")]
        public IFormFile? Photo { get; set; }

        public string? PhotoURL { get; set; }





        // current job details
        [Required]
        public string Role { get; set; }

        [Required]
        public string JobDescription { get; set; }

        public string? CurrentCTC { get; set; }

       
        public string? HouseRentAllowance { get; set; }

        
        public string? TravelAllowance { get; set; }


        public string? SpecialAllowance { get; set; }

      









        // bank details
        public string? BankName { get; set; }

        public string? BranchName { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountHolderName { get; set; }

        public string? IFSCCode { get; set; }



        // login credentials
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
