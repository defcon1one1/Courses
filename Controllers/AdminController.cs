using Courses.Areas.Identity.Data;
using Courses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Courses.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _context;


        public AdminController(ApplicationDbContext context)
        {
            _context = context;
            courses = _context.Courses.ToList();
        }




        #region Courses

        private List<Course> courses = new List<Course>();

        public ActionResult Index()
        {
            return View(courses);
        }

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

        public ActionResult ViewDetails(int id)
        {
            return View(_context.Courses.FirstOrDefault(x => x.Id == id));
        }


        #endregion


        public IActionResult AddLesson()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLesson(Lesson lesson)
        {
            try
            {
                var course = _context.Courses.FirstOrDefault(c => c.Id == lesson.CourseId);
                if (course != null)
                {
                    lesson.Course = course;
                    _context.Lessons.Add(lesson);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    }
}
