using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onlineexam.Models
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? BatchId { get; set; }

        public Batch Batches { get; set; }

        public virtual IList<Course> Courses { get; set; } = new List<Course>();
    }
}
