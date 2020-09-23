using System;

namespace onlineexam.Models.Quiz
{
    public class Test
    {
        public int Id { get; set; }

        public string TestTitle { get; set; }

        public int TotalQuestion { get; set; }

        public DateTime Starttime { get; set; }

        public DateTime EndTime { get; set; }

        public int TotalMarks { get; set; }

        public int? CourseId { get; set; }

        public Course Course { get; set; }
    }
}
