using eCommerce.Core.Dto;
using FluentValidation;

namespace eCommerce.Core.Validators;

public abstract class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    protected RegisterRequestValidator()
    {
        RuleFor(type => type.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format");
        RuleFor(type => type.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters")
            .MaximumLength(50).WithMessage("Password must be between 6 and 50 characters");
        RuleFor(type => type.PersonName)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(1).WithMessage("Name must be at least 3 characters")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
        RuleFor(type => type.Gender)
            .NotEmpty().WithMessage("Gender is required");
    }
}
