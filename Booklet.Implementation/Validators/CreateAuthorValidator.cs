using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateAuthorValidator : AbstractValidator<AuthorDto>
    {
        public CreateAuthorValidator(BookletContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(name => !context.Authors.Any(a => a.Name == name))
                .WithMessage("Author with the same name already exist.");
        }
    } 
}
