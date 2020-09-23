using System.ComponentModel.DataAnnotations;

namespace onlineexam.Models
{
    public class Identity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
