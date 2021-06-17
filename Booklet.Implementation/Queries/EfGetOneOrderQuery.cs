using Booklet.Application.DataTransfer;
using Booklet.Application.Exceptions;
using Booklet.Application.Queries;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Queries
{
    public class EfGetOneOrderQuery : IGetOneOrderQuery
    {
        private readonly BookletContext _context;

        public EfGetOneOrderQuery(BookletContext context)
        {
            _context = context;
        }
        public int Id => 15;

        public string Name => "Get order by id.";

        public ReadOrderDto Execute(int id)
        {
            var order = _context.Orders
                .Include(x=>x.User)
                .Include(x=>x.OrderLines)
                .ThenInclude(x=>x.Book).FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new EntityNotFoundException(id, typeof(Order));
            }

            var orderDto = new ReadOrderDto
            {
                CreatedAt = order.CreatedAt,
                Status = order.OrderStatus.ToString(),
                FullName = order.User.FirstName + " " + order.User.FirstName,
                OrderLines = order.OrderLines.Select(x =>
                {
                    return new ReadOrderLineDto
                    {
                        Book = x.BookName,
                        Quantity = x.Quantity,
                        Price = x.Price
                    };
                })

            };
            return orderDto;
        }
    }
}
