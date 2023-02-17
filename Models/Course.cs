using Courses.Areas.Identity.Data;
using Courses.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.Models
{
    public class Course
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CourseName { get; set; }

        public Levels Level { get; set; }
        public enum Levels { Basic, Medium, Advanced }

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

    }
}
