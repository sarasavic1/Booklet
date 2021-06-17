using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(BookletContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(5).WithMessage("Username must contain at least 5 characters.")
                .Must(x => !context.Users.Any(u => u.Username == x)).WithMessage("Username is already taken.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("A valid email is required")
                .Must(x => !context.Users.Any(u => u.Email == x)).WithMessage("User with email address {ProperyValue} is already registered.");

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password is required.")
               .MinimumLength(8).WithMessage("Password must contain 8 characters.");



        }
    }
}
