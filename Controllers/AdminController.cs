using Courses.Areas.Identity.Data;
using Courses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _context;
        private List<Instructor> instructors = new List<Instructor>();
        private List<Course> courses = new List<Course>();

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
            courses = _context.Courses.ToList();
            instructors = _context.Instructors.ToList();
        }




        #region Courses


        public ActionResult Index()
        {
            return View(courses);
        }

        public ActionResult AddCourse()
        {
            var courseModel = new Course
            {
                InstructorList = instructors
            };
            return View(courseModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(Course course)
        {
            try
            {
                course.ReleaseDate = DateTime.Now;
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
            var courseModel = new Course
            {
                CourseName = _context.Courses.FirstOrDefault(x => x.Id == id).CourseName,
                InstructorList = instructors
            };
            return View(courseModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourse(int id, Course course)
        {
            try
            {
                Course courseToEdit = _context.Courses.FirstOrDefault(x => x.Id == id);
                courseToEdit.CourseName = course.CourseName;
                courseToEdit.Level= course.Level;
                courseToEdit.InstructorId = course.InstructorId;
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
       
        public ActionResult ViewCourseDetails(int id)
        {
            return View(_context.Courses.FirstOrDefault(x => x.Id == id));
        }


        #endregion


        public ActionResult AddLesson()
        {
            var lessonModel = new Lesson
            {
                CourseList = _context.Courses.ToList()
            };
            return View(lessonModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLesson(Lesson lesson)
        {
            using (var db = new ApplicationDbContext())
            {
                var course = _context.Courses.FirstOrDefault(c => c.Id == lesson.CourseId);
                if (course != null)
                {
                    db.Add(lesson);
                    db.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteLesson(int id)
        {
            return View(_context.Lessons.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLesson(int id, Lesson lesson)
        {
            using (var db = new ApplicationDbContext())
            {
                var lessonToDelete = _context.Lessons.FirstOrDefault(c => c.Id == id);
                if (lessonToDelete != null)
                {
                    db.Remove(lesson);
                    db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult EditLesson(int id)
        {
            var lessonModel = new Lesson
            {
                LessonName = _context.Lessons.FirstOrDefault(x => x.Id == id).LessonName,
                CourseList = _context.Courses.ToList()
            };
            return View(lessonModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLesson(int id, Lesson lesson)
        {
            using (var db = new ApplicationDbContext())
            {
                var lessonToEdit = _context.Lessons.FirstOrDefault(c => c.Id == id);
                if (lessonToEdit != null)
                {
                    db.Update(lesson);
                    db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult ViewLessonDetails(int id)
        {
            return View(_context.Lessons.FirstOrDefault(x => x.Id == id));
        }


    }
}
