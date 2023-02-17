using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.Models
{
    public class Course
    {
        [Key]
        
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string CourseName { get; set; }
    }
}
