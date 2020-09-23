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
    public class SemestersController : Controller
    {
        private readonly AppDbContext _context;

        public SemestersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var semester = _context.Semesters.Include(s => s.Batches).Include(c => c.Courses).ToList();

            return View(semester);
        }

        public IActionResult Create()
        {
            var batch = _context.Batches.ToList();
            ViewData["bId"] = new SelectList(batch, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SemesterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var semesterExist = _context.Semesters.FirstOrDefault(s => s.Name == model.Name);
                if (semesterExist != null)
                {
                    ViewBag.message = "Already Exist";
                }

                var batch = _context.Batches.FirstOrDefault();

                if (batch != null)
                {
                    var s = new Semester
                    {
                        Name = model.Name,
                        Batches = batch
                    };
                    _context.Semesters.Add(s);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        public IActionResult Update(int? id)
        {
            var batch = _context.Batches.ToList();
            ViewData["bId"] = new SelectList(batch, "Id", "Name");

            if (id == null)
            {
                return NotFound();
            }
            var semester = _context.Semesters.Find(id);

            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Semester semester)
        {
            if (ModelState.IsValid)
            {
                _context.Update(semester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(semester);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = _context.Semesters.Find(id);

            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, Semester semester)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != semester.Id)
            {
                return NotFound();
            }
            var sem = _context.Semesters.Find(id);
            if (sem == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Remove(semester);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(semester);
        }
    }
}
