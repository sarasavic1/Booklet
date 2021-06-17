using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateWishlistValidator : AbstractValidator<WishlistDto>
    {
        public CreateWishlistValidator(BookletContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Wishlist name is required.");

            RuleFor(x=>x.UserId).Must(id => context.Users.Any(u => u.Id == id)).WithMessage("User with an id of {ProperyValue} doesn't exist.");
            RuleFor(x=>x.WishlistLines)
                .Must(i => i.Select(x => x.BookId).Distinct().Count() == i.Count())
                .WithMessage("Book is already in wishlist.")
                .DependentRules(() =>
                {
                    RuleForEach(x => x.WishlistLines).SetValidator
                        (new CreateWishlistLineValidator(context));
                });
        }
    }
}
