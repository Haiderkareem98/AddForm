using System.ComponentModel.DataAnnotations;

namespace jobForm.Filters;

public class RequiredIfAttribute(string otherProperty) : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(otherProperty);
        var otherValue = property?.GetValue(validationContext.ObjectInstance, null);

        if (IsRequired(value) && IsRequired(otherValue))
            return new ValidationResult($"{validationContext.DisplayName} is required.");

        return ValidationResult.Success ?? new ValidationResult("Invalid Operation Result");
    }

    private bool IsRequired(object? value)
    {
        return value == null || string.IsNullOrWhiteSpace(value.ToString());
    }
}