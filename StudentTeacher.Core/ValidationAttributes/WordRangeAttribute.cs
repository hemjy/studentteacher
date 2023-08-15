using StudentTeacher.Core.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
namespace StudentTeacher.ValidationFilters
{
    

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class WordRangeAttribute : ValidationAttribute
    {
        private readonly string[] _validWords;

        public WordRangeAttribute(params string[] validWords)
        {
            _validWords = validWords ?? throw new BadRequestException(nameof(validWords));
        }

        public string CustomErrorMessage { get; set; } = "The value must be one of: {0}";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string stringValue)
            {
                if (!_validWords.Any(x => x.Equals(stringValue, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return new ValidationResult(string.Format(CustomErrorMessage, string.Join(", ", _validWords)));
                }
            }

            return ValidationResult.Success;
        }
    }
}
