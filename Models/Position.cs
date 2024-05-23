using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The position title is required.")]
        public string position_name { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        public string desciption { get; set; }

    }
}
