using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace CulinaryRecipes.Validation;

public class NameContainsDisallowedSymbolsRule : ValidationRule
{
    private static char[] disallowedSymbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '`', '!', '@', '$', '%', '^', '&', '*' };

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string input = value.ToString();
        foreach (char c in disallowedSymbols)
        {
            if (input.Contains(c))
                return new ValidationResult(false, $"Input shouldn't contain figures");
        }
        return ValidationResult.ValidResult;
    }
}
