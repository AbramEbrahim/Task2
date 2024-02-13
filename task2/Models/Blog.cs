using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Type type { get; set;}
    
    }
}
