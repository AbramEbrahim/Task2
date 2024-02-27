using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task2.Models.Utalities;

namespace task2.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [BlogName]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Type? type { get; set;}
    }
}
