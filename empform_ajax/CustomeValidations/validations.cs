using System;  
using System.Collections.Generic;  
using System.ComponentModel.DataAnnotations;  
using System.Linq;  
using System.Web;  
 
  
namespace empform_ajax.CustomValidations
{
    public class dobvalidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateOfBirth = Convert.ToDateTime(value);
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (DateTime.Today < dateOfBirth.AddYears(age)) age--;

            return age >= 18;
        }
    }

    public class salvalidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int sal = Convert.ToInt32(value);
            
            return sal >= 5000;
        }
    }
}