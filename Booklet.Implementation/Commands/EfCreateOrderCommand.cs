//using AutoMapper;
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
    public class EfCreateOrderCommand : ICreateOrderCommand
    {
        private readonly BookletContext _context;
        private readonly CreateOrderValidator _validator;
        //private readonly IMapper _mapper;

        public EfCreateOrderCommand(BookletContext context, CreateOrderValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 14;

        public string Name => "Create order.";

        public void Execute(OrderDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var cart = _context.Cart.Find(dto.CartId);

            //var order = _mapper.Map<Order>(dto);


            
                var order = new Order
                {
                    OrderDate = dto.OrderDate,
                    UserId = cart.UserId
                };


            foreach (var book in cart.CartLines)
            {
                var bookFind = _context.Books.Find(book.BookId);

                bookFind.Quantity -= book.Quantity;

                order.OrderLines.Add(new OrderLine
                {
                    BookId = book.BookId,
                    Quantity = book.Quantity,
                    BookName = bookFind.Title,
                    Price = bookFind.Price

                });
            }

                _context.Orders.Add(order);

                _context.Cart.Remove(cart);

                _context.SaveChanges();
            

        }
    }
}
