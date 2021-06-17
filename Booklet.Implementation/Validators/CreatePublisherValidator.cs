using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreatePublisherValidator : AbstractValidator<PublisherDto>
    {
        public CreatePublisherValidator(BookletContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(name => !context.Publishers.Any(a => a.Name == name))
                .WithMessage("Publisher with the same name already exist.");
        }
    }
}
