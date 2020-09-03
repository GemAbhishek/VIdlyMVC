using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMVC.Models
{
    public class InStockValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            
            if (movie.Instock == null)
                return new ValidationResult(" custom error - required field");

            return (movie.Instock < 21) ? ValidationResult.Success : new ValidationResult("custom error - should be less then 20");
        }
    }
}