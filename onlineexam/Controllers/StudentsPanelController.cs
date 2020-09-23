using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlineexam.Persistence;
using System.Linq;

namespace onlineexam.Controllers
{
    public class StudentsPanelController : Controller
    {
        private AppDbContext _context;

        public StudentsPanelController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Semester()
        {
            var sem = _context.Semesters.ToList();
            return View(sem);
        }

        public IActionResult SemesterCourse(int id)
        {

            var course = _context.Courses
                .Where(c => c.Semesters.Id == id)
                        .Include(t => t.Teachers)
                        .Include(s => s.Semesters)
                        .ToList();

            return View(course);
        }

    }
}
