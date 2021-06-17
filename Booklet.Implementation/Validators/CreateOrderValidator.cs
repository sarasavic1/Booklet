using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Validators
{
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {

        public CreateOrderValidator(BookletContext context)
        {
            RuleFor(x=>x.CartId).Must(id => context.Cart.Any(c => c.Id == id)).WithMessage("Cart with an id of {ProperyValue} doesn't exist.");

            RuleFor(x => x.OrderDate)
                .GreaterThan(DateTime.Today)
                .WithMessage("Order date must be in future.");

            /*RuleFor(x => x.OrderLines)
                .NotEmpty()
                .WithMessage("There must be at least one order line.")
                .Must(i => i.Select(x => x.BookId).Distinct().Count() == i.Count())
                .WithMessage("Duplicate products are not allowed.")
                .DependentRules(() =>
                {
                    RuleForEach(x => x.OrderLines).SetValidator
                        (new CreateOrderLineValidator(context));
                });*/
        }
    }
}
