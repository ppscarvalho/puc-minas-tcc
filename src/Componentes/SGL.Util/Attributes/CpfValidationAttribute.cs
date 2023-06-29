using System;
using System.ComponentModel.DataAnnotations;
using SGL.Util.Extensions;

namespace SGL.Util.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CpfValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object cpf)
        {
            if (string.IsNullOrEmpty(cpf?.ToString()) is false)
                return cpf.ToString().CpfValidation();

            return true;
        }
    }
}
