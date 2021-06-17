using Booklet.Application.Commands;
using Booklet.Application.Exceptions;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfDeletePublisherCommand : IDeletePublisherCommand
    {

        private readonly BookletContext _context;

        public EfDeletePublisherCommand(BookletContext context)
        {
            _context = context;
        }
        public int Id => 4;

        public string Name => "Delete Publisher";

        public void Execute(int id)
        {
            var publisher = _context.Publishers.Find(id);

            if (publisher == null)
            {
                throw new EntityNotFoundException(id, typeof(Publisher));
            }

            publisher.IsDeleted = true;
            publisher.IsActive = false;
            publisher.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
