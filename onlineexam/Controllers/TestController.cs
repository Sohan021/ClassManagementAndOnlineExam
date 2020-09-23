using Microsoft.AspNetCore.Mvc;
using onlineexam.Persistence;

namespace onlineexam.Controllers
{
    public class TestController : Controller
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View();
        }


    }
}
