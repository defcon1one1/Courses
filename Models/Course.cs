using Courses.Areas.Identity.Data;
using Courses.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Courses.Models
{
    public class Course
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CourseName { get; set; }

        [Required]
        [Precision(5,2)]
        public decimal Price { get; set; }

        [Required]

        public DateTime ReleaseDate { get; set; }
        [Required]
        public Levels Level { get; set; }
        public enum Levels { Basic, Medium, Advanced }

        [Required]
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public List<Lesson> Lessons { get => GetLessons(); }

        private List<Lesson> GetLessons()
        {
            using (var db = new ApplicationDbContext())
            {
                var lessons = new List<Lesson>();
                lessons = (from lesson in db.Lessons where lesson.CourseId == Id select lesson).ToList();
                return lessons;
            }
        }
        [NotMapped]
        public List<Instructor>? InstructorList { get; set; }


    }
}
