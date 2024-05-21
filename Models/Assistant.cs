using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Assistant
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
