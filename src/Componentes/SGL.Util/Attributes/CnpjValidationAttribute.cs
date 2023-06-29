using System;
using System.ComponentModel.DataAnnotations;
using SGL.Util.Extensions;

namespace SGL.Util.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CnpjValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object cnpj)
        {
            if (string.IsNullOrEmpty(cnpj?.ToString()) is false)
                return cnpj.ToString().CnpjValidation();

            return true;
        }
    }
}
