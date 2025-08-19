using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.BLL.Validations
{
	public class NoNumbersAttribute : ValidationAttribute
	{
		public NoNumbersAttribute()
		{
			ErrorMessage = "{0} cannot contain numbers.";
		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value is string str && str.Any(char.IsDigit))
			{
				return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
			}
			return ValidationResult.Success;
		}
	}
}
