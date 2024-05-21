using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
