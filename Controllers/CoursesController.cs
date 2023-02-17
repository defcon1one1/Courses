using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Courses.Models;
using Courses.Areas.Identity.Data;

namespace Courses.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
            courses = _context.Courses.ToList();
        }

        private List<Course> courses = new List<Course>();

        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        
        
        }

        public ActionResult EditCourse(int id)
        {
            return View(_context.Courses.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourse(int id, Course course)
        {
            try
            {
                Course courseToEdit = _context.Courses.FirstOrDefault(x => x.Id == id);
                courseToEdit.CourseName = course.CourseName;
                _context.Courses.Update(courseToEdit);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DeleteCourse(int id)
        {
            return View(_context.Courses.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourse(int id, Course course)
        {
            try
            {
                Course courseToDelete = _context.Courses.FirstOrDefault(x => x.Id == id);
                _context.Courses.Remove(courseToDelete);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Index()
        {
            return View(courses);
        }
    }
}
