using System;
using System.ComponentModel.DataAnnotations;
using SGL.Util.Extensions;

namespace SGL.Util.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object email)
        {
            if (string.IsNullOrEmpty(email?.ToString()) is false)
                return email.ToString().EmailValidation();

            return true;
        }
    }
}
