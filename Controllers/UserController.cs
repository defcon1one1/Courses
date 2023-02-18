using Courses.Areas.Identity.Data;
using Courses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _context;
        private List<Enrollment> Enrollments;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
            Enrollments = _context.Enrollments.ToList();
        }

        public ActionResult MyCourses()
        {
            return View(Enrollments);
        }


    }
}