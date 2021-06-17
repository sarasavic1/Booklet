using Booklet.Application.Commands;
using Booklet.Application.Exceptions;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfDeleteBookCommand : IDeleteBookCommand
    {
        private readonly BookletContext _context;

        public EfDeleteBookCommand(BookletContext context)
        {
            _context = context;
        }
        public int Id => 10;

        public string Name => "Delete Book";

        public void Execute(int id)
        {
            var book = _context.Books.Find(id);

            var bookWish = _context.WishlistLines.FirstOrDefault(x => x.BookId == id);
                            /*.Include(x => x.BookGenres)
                            .Include(x => x.WishlistLines).FirstOrDefault(x => x.Id == id);*/
            
            if (book == null)
            {
                throw new EntityNotFoundException(id, typeof(Book));
            }

            book.IsDeleted = true;
            book.IsActive = false;
            book.DeletedAt = DateTime.Now;

            if (bookWish != null)
            {
                bookWish.IsDeleted = true;
                bookWish.IsActive = false;
                bookWish.DeletedAt = DateTime.Now;
            }

            _context.SaveChanges();
        }
    }
}
