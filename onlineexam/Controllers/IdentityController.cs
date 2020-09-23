using Microsoft.AspNetCore.Mvc;
using onlineexam.Models;
using onlineexam.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace onlineexam.Controllers
{
    public class IdentityController : Controller
    {
        private readonly AppDbContext _context;

        public IdentityController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Identity role, int id)
        {

            if (ModelState.IsValid)
            {
                var roleexist = _context.Identities.Where(r => r.Id == id).FirstOrDefault();

                if (roleexist != null)
                {
                    ViewBag.message = "Exist";
                }
                _context.Add(role);
                await _context.SaveChangesAsync();
            }
            return View(role);
        }


    }
}
