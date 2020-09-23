using System;

namespace onlineexam.Models
{
    public class InfoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public DateTime dateTime { get; set; }

        public Course Course { get; set; }
    }
}
