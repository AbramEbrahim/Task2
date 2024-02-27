using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task2.Models.Utalities;

namespace task2.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Length(1,10)]
        [Required (ErrorMessage ="must enter the name of the product")]
        [DeniedValues("aaa","bbb")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxPriceAtribute(1000)]
        public float price { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        public bool EnablSize { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? company { get; set; }
    }
}
