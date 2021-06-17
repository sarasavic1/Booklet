using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    /*public class CreateOrderLineValidator : AbstractValidator<OrderLineDto>
    {
        public CreateOrderLineValidator(BookletContext context)
        {

            RuleFor(x=>x.BookId)
                .Must(id => context.Books.Any(b => b.Id == id)).WithMessage("Book with an id of {ProperyValue} doesn't exist.")
                .DependentRules(()=> {

                    RuleFor(x => x.Quantity)
                        .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                        .Must((dto, q) => context.Books.Find(dto.BookId).Quantity >= q).WithMessage("Defined quantity ({PropertyValue}) is unavailable.");
                    
                });
        }
    }*/
}
