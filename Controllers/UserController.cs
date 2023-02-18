using Courses.Areas.Identity.Data;
using Courses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Controllers
{
    [Authorize]
    public class UserController : Controller
    {


        private readonly ApplicationDbContext _context;
        private List<Course> courses = new List<Course>();
        private List<Instructor> instructors = new List<Instructor>();

        public UserController(ApplicationDbContext context)
        {
            _context = context;
            courses = _context.Courses.ToList();
            instructors = _context.Instructors.ToList();
        }
        [AllowAnonymous]
        public ActionResult Courses()

        {
            return View(courses);
        }
        [AllowAnonymous]
        public ActionResult ViewCourseDetails(int id)
        {
            return View(_context.Courses.FirstOrDefault(x => x.Id == id));
        }

    }
}
