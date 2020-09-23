using Microsoft.AspNetCore.Http;
using System;

namespace onlineexam.ViewModels
{
    public class FileModelViewModel
    {
        public string Title { get; set; }

        public DateTime dateTime { get; set; }

        public IFormFile FileName { get; set; }

        public int CourseId { get; set; }
    }
}
