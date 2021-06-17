using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateUserUseCaseValidator : AbstractValidator<UserUseCaseDto>
    {
        public CreateUserUseCaseValidator(BookletContext context)
        {
            RuleFor(x => x.UserId).Must(y => context.Users.Any(u => u.Id == y)).WithMessage("User with an id of {ProperyValue} doesn't exist.");
        }
    }
}
