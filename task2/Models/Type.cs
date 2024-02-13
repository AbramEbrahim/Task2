using System.ComponentModel.DataAnnotations;

namespace task2.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
