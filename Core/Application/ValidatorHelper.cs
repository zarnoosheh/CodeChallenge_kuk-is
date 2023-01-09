using FluentValidation.Results;

namespace Core.Application;

public static class ValidatorHelper
{
    public static IEnumerable<string> ToErrorList(this ValidationResult validationResult)
    {
        if (validationResult.IsValid)
        {
            return Enumerable.Empty<string>();
        }

        return validationResult.Errors.Select(s => s.ErrorCode);
    }
}