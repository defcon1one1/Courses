using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Courses.Areas.Identity.Data;

namespace Courses.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
