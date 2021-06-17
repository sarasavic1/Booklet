using Booklet.Application.Commands;
using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using Booklet.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfCreateCartCommand : ICreateCartCommand
    {
        private readonly BookletContext _context;
        private readonly CreateCartValidator _validator;
        //private readonly IMapper _mapper;

        public EfCreateCartCommand(BookletContext context, CreateCartValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 23;

        public string Name => "Create cart";

        public void Execute(CartDto dto)
        {
            _validator.ValidateAndThrow(dto);

            //var order = _mapper.Map<Order>(dto);
            var cart = new Cart
            {
                UserId = dto.UserId
            };

            foreach (var line in dto.CartLines)
            {
                var book = _context.Books.Find(line.BookId);

                cart.CartLines.Add(new CartLine
                {
                    BookId = line.BookId,
                    Quantity = line.Quantity,
                    BookName = book.Title,
                    Price = book.Price

                });
            }


            _context.Cart.Add(cart);
            _context.SaveChanges();

        }
    }
}
