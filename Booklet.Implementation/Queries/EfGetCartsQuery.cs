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
    public class EfGetCartsQuery : IGetCartsQuery
    {
        private readonly BookletContext _context;

        public EfGetCartsQuery(BookletContext context)
        {
            _context = context;
        }
        public int Id => 25;

        public string Name => "Search cart.";

        public PagedResponse<ReadCartDto> Execute(CartSearch search)
        {
            var query = _context.Cart
               .Include(x => x.User)
               .Include(x => x.CartLines)
               .ThenInclude(x => x.Book).AsQueryable();

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<ReadCartDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ReadCartDto
                {
                    UserId=x.UserId,
                    CartLines = x.CartLines.Select(y => new ReadCartLineDto
                    {
                        BookName=y.BookName,
                        Price=y.Price,
                        Quantity=y.Quantity
                    })
                }).ToList()
            };

            return response;
        }
    }
}
