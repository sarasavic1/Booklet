using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateWishlistLineValidator : AbstractValidator<WishlistLineDto>
    {
        public CreateWishlistLineValidator(BookletContext context) 
        {
            RuleFor(x => x.BookId)
                .Must(id => context.Books.Any(b => b.Id == id)).WithMessage("Book with an id of {ProperyValue} doesn't exist.");
        }
    }
}
