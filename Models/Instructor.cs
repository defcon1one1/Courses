using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Courses.Areas.Identity.Data;

namespace Courses.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }

    }
}
