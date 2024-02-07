namespace task2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Company company { get; set; }
        public float price { get; set; }
        public int Quantity { get; set; }
        public bool EnablSize { get; set; }

    }
}
