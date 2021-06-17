using Booklet.Application.Commands;
using Booklet.Application.Exceptions;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfDeleteAuthorCommand : IDeleteAuthorCommand
    {
        private readonly BookletContext _context;

        public EfDeleteAuthorCommand(BookletContext context)
        {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Delete Author";

        public void Execute(int id)
        {
            var author = _context.Authors.Find(id);

            if(author == null)
            {
                throw new EntityNotFoundException(id, typeof(Author));
            }

            author.IsDeleted = true;
            author.IsActive = false;
            author.DeletedAt = DateTime.Now;

            _context.SaveChanges();

        }
    }
}
