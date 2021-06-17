using Booklet.Application.DataTransfer;
using Booklet.Application.Queries;
using Booklet.Application.Searches;
using Booklet.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Queries
{
    public class EfGetOrdersQuery : IGetOrdersQuery
    {
        private readonly BookletContext _context;

        public EfGetOrdersQuery(BookletContext context)
        {
            _context = context;
        }
        public int Id => 16;

        public string Name => "Search orders";

        public PagedResponse<ReadOrderDto> Execute(OrderSearch search)
        {
            var query = _context.Orders
               .Include(x => x.User)
               .Include(x => x.OrderLines)
               .ThenInclude(x => x.Book).AsQueryable();

            if (!string.IsNullOrEmpty(search.Status) || !string.IsNullOrWhiteSpace(search.Status))
            {
                query = query.Where(x => x.OrderStatus.ToString().ToLower() == search.Status.ToLower());
            }

            if (search.MinPrice.HasValue)
            {
                query = query.Where(x => x.OrderLines.Sum(x => x.Quantity * x.Price) >= search.MinPrice.Value);
            }
            if (search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.OrderLines.Sum(x => x.Quantity * x.Price) <= search.MaxPrice.Value);
            }

            if (search.UserId.HasValue)
            {
                query = query.Where(x=>x.UserId==search.UserId);
            }


            var skipCount = search.PerPage * (search.Page - 1);

            var response=new PagedResponse<ReadOrderDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ReadOrderDto
                {
                    CreatedAt=x.CreatedAt,
                    Status=x.OrderStatus.ToString(),
                    FullName=x.User.FirstName + " " + x.User.LastName,
                    Address=x.User.Address,
                    OrderLines = x.OrderLines.Select(y => new ReadOrderLineDto
                    {
                        Book=y.BookName,
                        Quantity=y.Quantity,
                        Price=y.Price
                    })
                }).ToList()
            };

            return response;
        }
    }
}
