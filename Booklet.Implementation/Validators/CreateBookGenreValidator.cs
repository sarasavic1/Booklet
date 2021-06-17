using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateBookGenreValidator : AbstractValidator<CreateBookGenreDto>
    {
        public CreateBookGenreValidator(BookletContext context)
        {
            RuleFor(x => x.Id).Must(y => context.Genres.Any(g => g.Id == y)).WithMessage("Genre with an id of {ProperyValue} doesn't exist.");
        }
    }
}
