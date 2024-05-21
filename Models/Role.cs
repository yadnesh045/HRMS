using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleType { get; set; }
        public string Email { get; set; }
    }
}
