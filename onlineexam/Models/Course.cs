using System.ComponentModel.DataAnnotations;

namespace onlineexam.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string CourseDetails { get; set; }

        public string TeacherId { get; set; }

        public ApplicationUser Teachers { get; set; }

        public int? SemesterId { get; set; }

        public Semester Semesters { get; set; }
    }
}
