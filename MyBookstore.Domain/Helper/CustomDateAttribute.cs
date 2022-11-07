using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.Helper
{
    internal class CustomDateAttribute : ValidationAttribute
    {
        public CustomDateAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;
            var minimalDate = DateTime.MinValue.AddDays(1);

            if (DateTime.Compare(date, minimalDate) < 0)
            {
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
