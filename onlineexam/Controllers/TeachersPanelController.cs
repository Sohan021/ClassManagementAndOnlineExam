using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlineexam.Models.Quiz;
using onlineexam.Persistence;
using System.Linq;

namespace onlineexam.Controllers
{
    public class TeachersPanelController : Controller
    {

        private readonly AppDbContext _context;

        public TeachersPanelController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Semester()
        {
            var sem = _context.Semesters.ToList();
            return View(sem);
        }

        [Authorize]
        public IActionResult SemCourseTeachr(int id)
        {
            var userEmail = User.Identity.Name;

            var course = _context.Courses
                .Where(c => c.Semesters.Id == id && c.Teachers.Email == userEmail)
                        .Include(t => t.Teachers)
                        .Include(s => s.Semesters)
                        .ToList();

            return View(course);
        }

        public IActionResult MakeExam(Test test)
        {


            var exam = _context.Tests.Add(test);

            return null;
        }
    }
}
