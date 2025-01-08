using eCommerce.Core.Dto;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(type => type.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format");
        RuleFor(type => type.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
