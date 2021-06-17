using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateGenreValidator : AbstractValidator<GenreDto>
    {
        public CreateGenreValidator(BookletContext context)
        {
            RuleFor(x => x.GenreName)
                .NotEmpty()
                .Must(genreName => !context.Genres.Any(g => g.GenreName == genreName))
                .WithMessage("Genre already exist.");
        }
    }
}
