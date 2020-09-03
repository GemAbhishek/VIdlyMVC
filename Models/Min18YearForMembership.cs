using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace VidlyMVC.Models
{
    public class Min18YearForMembership : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cus = (Customer)validationContext.ObjectInstance;
            if (cus.MembershipTypeId == 0 || cus.MembershipTypeId == 1 )
                return ValidationResult.Success;

            if (cus.Dob == null)
                return new ValidationResult("Date Of Birth Reqiured");

            var age = DateTime.Today.Year - cus.Dob.Value.Year;

            return (age > 18) ? ValidationResult.Success : new ValidationResult("for  membership age should be grater then 18");

        }
    }
}