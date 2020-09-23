using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace onlineexam.Controllers
{
    public class QuestionPaperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}