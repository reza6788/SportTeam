using FluentValidation.Results;

namespace SP.Common.Utilities
{
    public static class ValidationErrorExtensions
    {
        public static string GetErrors(this IEnumerable<ValidationFailure> errors)
        {
            var errorMessages = errors.Select(p => p.ErrorMessage).Distinct();

            return string.Join(Environment.NewLine, errorMessages);
        }
    }
}
