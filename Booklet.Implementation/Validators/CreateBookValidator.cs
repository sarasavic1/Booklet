using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator(BookletContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Book title is required parameter.")
                .Must((dto, title) => !context.Books.Any(b => b.Title == title && b.AuthorId == dto.AuthorId))
                .WithMessage(p => $"Book with the name of {p.Title} with the same author already exists in database.");

            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.ISBN).Must(x => x.ToString().Length == 13);
            RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Number of page must be greater than 0");

            RuleFor(x => x.AuthorId).Must(id => context.Authors.Any(a => a.Id == id)).WithMessage("Author with an id of {ProperyValue} doesn't exist.");
            RuleFor(x => x.PublisherId).Must(id => context.Publishers.Any(a => a.Id == id)).WithMessage("Publisher with an id of {ProperyValue} doesn't exist."); ;
            RuleFor(x => x.FormatId).Must(id => context.Formats.Any(a => a.Id == id)).WithMessage("Format with an id of {ProperyValue} doesn't exist."); 

            RuleFor(x => x.Genres)
                .NotEmpty()
                .WithMessage("There must be at least one order line.")
                .Must(i => i.Select(x => x.Id).Distinct().Count() == i.Count())
                .WithMessage("Duplicates are not allowed.")
                .DependentRules(() =>
                {
                    RuleForEach(x => x.Genres).SetValidator
                        (new CreateBookGenreValidator(context));
                });
        }

       
    }
}
