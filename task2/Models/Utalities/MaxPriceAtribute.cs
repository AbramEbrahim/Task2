using System.ComponentModel.DataAnnotations;
using task2.Models;

namespace task2.Models.Utalities
{
    public class MaxPriceAtribute :ValidationAttribute 
    {
        private readonly int _maxPrice;
        public MaxPriceAtribute(int maxPrice)
        { 
        
            _maxPrice = maxPrice;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product p =(Product) validationContext.ObjectInstance;
            int price;
            if (!int.TryParse(value.ToString(),out price)) {
                return new ValidationResult("enter integer value");
            }

            if(p.CompanyId==2 && price < _maxPrice)
            {
                return new ValidationResult("adidas price less than "+_maxPrice.ToString());
            }
            return ValidationResult.Success;
        
        }

    }
}
