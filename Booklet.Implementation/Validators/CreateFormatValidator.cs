using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateFormatValidator : AbstractValidator<FormatDto>
    {
        public CreateFormatValidator(BookletContext context)
        {
            RuleFor(x => x.FormatName)
                .NotEmpty()
                .Must(format => !context.Formats.Any(f=>f.FormatName == format))
                .WithMessage("Format already exist.");
        }
    }
}
