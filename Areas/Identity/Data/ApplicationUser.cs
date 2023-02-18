using Courses.Areas.Identity.Data;
using Courses.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }


    public List<Course>? Enrollments { get => GetEnrollments(); }

    private List<Course> GetEnrollments()
    {
        using (var db = new ApplicationDbContext())
        {
            var enrollments = new List<Course>();
            enrollments = (from e in db.Enrollments where e.ApplicationUserId == Id select e.Course).ToList();
            return enrollments;
        }
    }

}