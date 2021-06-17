using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookValidator(BookletContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Book title is required parameter.")
                .Must((dto, title) => !context.Books.Any(b => b.Title == title && b.Id != dto.Id && b.AuthorId==dto.AuthorId))
                .WithMessage(p => $"Book with the name of {p.Title} with the same author already exists in database.");

            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.ISBN).Must(x => x.ToString().Length == 13);
            RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Number of page must be greater than 0");
        }
    }
}
