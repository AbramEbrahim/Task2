using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float price { get; set; }
        public int Quantity { get; set; }
        public bool EnablSize { get; set; }
        
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company company { get; set; }
    }
}
