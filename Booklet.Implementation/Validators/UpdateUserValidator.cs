using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator(BookletContext context)
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password is required.")
               .MinimumLength(8).WithMessage("New password must contain 8 characters.");
        }
    }
}
