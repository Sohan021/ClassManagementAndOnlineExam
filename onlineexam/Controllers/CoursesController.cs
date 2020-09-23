using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using onlineexam.Models;
using onlineexam.Persistence;
using onlineexam.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace onlineexam.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Courses.Include(t => t.Teachers).Include(s => s.Semesters).ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            var teacher = _context.Users.Where(r => r.Role.Name == "Teacher").ToList();
            ViewData["tId"] = new SelectList(teacher, "Id", "Email");

            var semester = _context.Semesters.ToList();
            ViewData["sId"] = new SelectList(semester, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseViewModel course, int id, string userId)
        {

            if (ModelState.IsValid)
            {
                var teachers = _context.Users.Where(c => c.Role.Name == "Teacher").FirstOrDefault(x => x.Id == course.UserId);
                var semester = _context.Semesters.FirstOrDefault(x => x.Id == course.SemesterId);

                if (teachers != null)
                {
                    var c = new Course
                    {
                        Name = course.Name,
                        CourseDetails = course.CourseDetails,
                        Teachers = teachers,
                        Semesters = semester

                    };
                    _context.Courses.Add(c);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(course);
        }

        public IActionResult Update(int? id)
        {
            var teacher = _context.Users.Where(t => t.Role.Name == "Teacher").ToList();
            ViewData["tId"] = new SelectList(teacher, "Id", "Name");

            var semester = _context.Semesters.ToList();
            ViewData["sId"] = new SelectList(semester, "Id", "Name");

            var course = _context.Courses.Include(t => t.Teachers).Include(s => s.Semesters).FirstOrDefault(c => c.Id == id);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _context.Courses.Include(c => c.Teachers).Include(s => s.Semesters).FirstOrDefault(f => f.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }




        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, Course course)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != course.Id)
            {
                return NotFound();
            }

            var c = _context.Courses.Find(id);

            if (c == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Remove(c);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }


    }
}
