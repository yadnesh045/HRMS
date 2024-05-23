using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Assets
    {
        [Key]
        public int id { get; set; }
        public string? asset_name { get; set; }
        public string? category { get; set; }
        public string? description { get; set; } 
        public int serial_number { get; set; }

        public int quantitiy { get; set; }

    }
}
