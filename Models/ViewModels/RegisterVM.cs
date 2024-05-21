using System.ComponentModel.DataAnnotations;

namespace HRMS.Models.ViewModels
{
    public class RegisterVM
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
