using System;

namespace onlineexam.ViewModels
{
    public class TestViewModel
    {

        public string TestTitle { get; set; }

        public int TotalQuestion { get; set; }

        public DateTime Starttime { get; set; }

        public DateTime EndTime { get; set; }

        public int TotalMarks { get; set; }

        public int? CourseId { get; set; }


    }
}
