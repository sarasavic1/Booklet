using Booklet.Application.Commands;
using Booklet.Application.Exceptions;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfDeleteGenreCommand : IDeleteGenreCommand
    {
        private readonly BookletContext _context;

        public EfDeleteGenreCommand(BookletContext context)
        {
            _context = context;
        }
        public int Id => 6;

        public string Name => "Delete genre.";

        public void Execute(int id)
        {
            var genre = _context.Genres.Find(id);

            if (genre == null)
            {
                throw new EntityNotFoundException(id, typeof(Genre));
            }

            genre.IsDeleted = true;
            genre.IsActive = false;
            genre.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
