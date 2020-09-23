using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlineexam.Models;
using onlineexam.Models.Quiz;
using onlineexam.Persistence;
using onlineexam.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace onlineexam.Controllers
{
    public class CourseDesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public CourseDesController(AppDbContext context,
                                   IHostingEnvironment env,
                                   UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        public IActionResult FileIndex(int id)
        {
            var courseDes = _context.FileModels.Include(x => x.Course)
                .Where(x => x.Course.Id == id).ToList();

            ViewBag.courseId = id;

            return View(courseDes);
        }

        public IActionResult PostIndex(int id)
        {
            var courseDes = _context.InfoModels.Include(x => x.Course).Where(x => x.Course.Id == id).ToList();
            ViewBag.courseId = id;
            return View(courseDes);
        }

        public IActionResult MakeExam(int id)
        {
            var course = new TestViewModel
            {
                CourseId = id
            };
            return View(course);
        }



        [HttpPost]
        public async Task<IActionResult> MakeExam(TestViewModel model, int id)
        {

            if (ModelState.IsValid)
            {

                var course = _context.Courses.FirstOrDefault(x => x.Id == id);

                var exam = new Test
                {
                    TestTitle = model.TestTitle,
                    TotalQuestion = model.TotalQuestion,
                    TotalMarks = model.TotalMarks,
                    Starttime = model.Starttime,
                    EndTime = model.EndTime,
                    Course = course

                };

                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(FileIndex));
            }
            return View(model);
        }
        public IActionResult CreateFileUpload(int id)
        {
            var courseDes = new FileModelViewModel
            {
                CourseId = id
            };
            return View(courseDes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFileUpload(FileModelViewModel model, int id)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                var course = _context.Courses.FirstOrDefault(x => x.Id == id);

                var cd = new FileModel
                {
                    Title = model.Title,
                    dateTime = model.dateTime,
                    FileName = uniqueFileName,
                    Course = course

                };

                _context.Add(cd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(FileIndex));
            }
            return View(model);
        }


        public IActionResult CreateInfo(int id)
        {
            var courseDes = new InfoModelViewModel
            {
                CourseId = id
            };
            return View(courseDes);
        }


        [HttpPost]
        public async Task<IActionResult> CreateInfo(InfoModelViewModel model, int id)
        {

            if (ModelState.IsValid)
            {


                var course = _context.Courses.FirstOrDefault(x => x.Id == id);

                var cd = new InfoModel
                {
                    Title = model.Title,
                    Details = model.Details,
                    dateTime = model.dateTime,
                    Course = course

                };

                _context.Add(cd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PostIndex));
            }
            return View(model);
        }



        private string ProcessUploadedFile(FileModelViewModel model)
        {
            string uniqueFileName = null;
            if (model.FileName != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.FileName.CopyTo(fileStream);
                }

            }

            return uniqueFileName;

        }
    }
}
