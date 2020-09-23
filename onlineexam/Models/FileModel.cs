using System;

namespace onlineexam.Models
{
    public class FileModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime dateTime { get; set; }

        public string FileName { get; set; }

        public Course Course { get; set; }
    }
}
