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
    public class EfGetOneBookQuery : IGetOneBookQuery
    {
        private readonly BookletContext _context;

        public EfGetOneBookQuery(BookletContext context)
        {
            _context = context;
        }
        public int Id => 12;

        public string Name => "Get book by id.";

        public ReadBookDto Execute(int id)
        {
            var book = _context.Books
                        .Include(x => x.Author)
                        .Include(x => x.Publisher)
                        .Include(x => x.Format)
                        .Include(x => x.BookGenres)
                        .ThenInclude(y => y.Genre)
                        .FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                throw new EntityNotFoundException(id, typeof(Book));
            }

            var bookDto = new ReadBookDto
            {
                Title = book.Title,
                Quantity = book.Quantity,
                Price = book.Price,
                Description = book.Description,
                ISBN = book.ISBN,
                Image = book.Image,
                PublishDate = book.PublishDate,
                PageNumber = book.PageNumber,
                Format = book.Format.FormatName,
                Author = book.Author.Name,
                Publisher = book.Publisher.Name,
                Genres = book.BookGenres.Select(x =>
                {
                    return new ReadBookGenreDto
                    {
                        genre = x.Genre.GenreName
                    };
                })
            };

           

            return bookDto;
        /*foreach (var genre in dto.Genres)
        {
            book.BookGenres.Add(new BookGenre
            {
                BookId = book.Id,
                GenreId = genre.Id
            });
        }*/


    }
    }
}
