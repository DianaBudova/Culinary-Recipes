using System.Globalization;
using System.Windows.Controls;

namespace CulinaryRecipes.Validation;

public class NameLengthRangeRule : ValidationRule
{
    public int MinLength { get; set; }
    public int MaxLength { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value.ToString().Length < MinLength || value.ToString().Length > MaxLength)
        {
            return new ValidationResult(false, $"Input should be between {MinLength} and {MaxLength}");
        }
        return ValidationResult.ValidResult;
    }
}
