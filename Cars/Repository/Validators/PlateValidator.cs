using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Cars.Repository.Validators
{
    public class PlateValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string plate = (string)value!;
            if (Regex.IsMatch(plate, "[A-Z]{2}\\d{3}[A-Z]{2}"))
            {
                return ValidationResult.Success;
                ;
            }

            return new ValidationResult("Invalid plate format.");
        }
    }
}