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
    public class EfGetBooksQuery : IGetBooksQuery
    {
        private readonly BookletContext _context;

        public EfGetBooksQuery(BookletContext context)
        {
            _context = context;
        }
        public int Id => 13;

        public string Name => "Search books.";

        public PagedResponse<ReadBookDto> Execute(BookSearch search)
        {
            var query = _context.Books
                        .Include(x => x.Author)
                        .Include(x => x.Publisher)
                        .Include(x => x.Format)
                        .Include(x => x.BookGenres)
                        .ThenInclude(y => y.Genre).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) || x.Author.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            if (search.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= search.MinPrice);
            }
            if (search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= search.MaxPrice);
            }

            if (search.AuthorId.HasValue)
            {
                query = query.Where(x=>x.AuthorId==search.AuthorId);
            }

            if (search.PublisherId.HasValue)
            {
                query = query.Where(x => x.PublisherId == search.PublisherId);
            }

            if (search.GenreId.HasValue)
            {
                query = query.Where(x => x.BookGenres.Any(y => y.GenreId == search.GenreId));
            }


            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<ReadBookDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ReadBookDto
                {
                    Title = x.Title,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Image = x.Image,
                    PublishDate = x.PublishDate,
                    PageNumber = x.PageNumber,
                    Format = x.Format.FormatName,
                    Author = x.Author.Name,
                    Publisher = x.Publisher.Name,
                    Genres=x.BookGenres.Select(y=> new ReadBookGenreDto
                    {
                        genre=y.Genre.GenreName
                    })
                }).ToList()
            };

            return reponse;
        }
    }
}
