using FluentValidation;
using SP.Common.Messages;

namespace SP.Services.Person.Validation
{
    public class GetByIdValidator : AbstractValidator<int>
    {
        public GetByIdValidator()
        {
            RuleFor(p => p).GreaterThan(0).WithMessage(ValidationMessagesResource.IdGtZero);
        }
    }
}
