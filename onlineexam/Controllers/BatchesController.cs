using Microsoft.AspNetCore.Mvc;
using onlineexam.Models;
using onlineexam.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace onlineexam.Controllers
{
    public class BatchesController : Controller
    {
        private readonly AppDbContext _context;

        public BatchesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var batches = _context.Batches.ToList();
            return View(batches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Batch batch)
        {
            if (ModelState.IsValid)
            {
                var batchexist = _context.Batches.FirstOrDefault(b => b.Name == batch.Name);
                if (batchexist != null)
                {
                    ViewBag.message = "Already Exist";
                }

                _context.Add(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batch);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var batch = _context.Batches.Find(id);
            if (batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Batch batch)
        {
            if (ModelState.IsValid)
            {
                _context.Update(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batch);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var batch = _context.Batches.Find(id);
            if (batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, Batch batch)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != batch.Id)
            {
                return NotFound();
            }

            var B = _context.Batches.Find(id);

            if (B == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Remove(batch);
                await _context.SaveChangesAsync();
                RedirectToAction(nameof(Index));
            }

            return View(batch);
        }

    }
}
