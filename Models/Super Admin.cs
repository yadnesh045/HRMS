using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Super_Admin
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
