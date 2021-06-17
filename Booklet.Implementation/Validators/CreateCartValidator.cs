using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateCartValidator : AbstractValidator<CartDto>
    {
        public CreateCartValidator(BookletContext context)
        {
            RuleFor(x => x.UserId)
               .Must(id => context.Users.Any(u => u.Id == id)).WithMessage("User with an id of {ProperyValue} doesn't exist.");

            RuleFor(x => x.CartLines)
                .NotEmpty()
                .WithMessage("There must be at least one cart line.")
                .Must(i => i.Select(x => x.BookId).Distinct().Count() == i.Count())
                .WithMessage("Duplicate products are not allowed.")
                .DependentRules(() =>
                {
                    RuleForEach(x => x.CartLines).SetValidator
                        (new CreateCartLineValidator(context));
                });
        }

    }
}
