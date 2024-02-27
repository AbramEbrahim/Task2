using System.ComponentModel.DataAnnotations;
using task2.Models;

namespace task2.Models.Utalities
{
    public class BlogName : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            Blog blog = (Blog)validationContext.ObjectInstance;

            if (blog.Name.Length < 6 ) {
            
                return new ValidationResult("Invalid  blog name ---->should blog name be more than 6 letters");
            }

            if (!blog.Name.Contains("blog"))
            {

                return new ValidationResult("Invalid  blog name ---->should contain blog at th end");
            }
            return ValidationResult.Success;
        }

    }
}
