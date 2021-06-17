using Booklet.Application.Commands;
using Booklet.Application.Exceptions;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfDeleteFormatCommand : IDeleteFormatCommand
    {
        private readonly BookletContext _context;

        public EfDeleteFormatCommand(BookletContext context)
        {
            _context = context;
        }
        public int Id => 8;

        public string Name => "Delete format.";

        public void Execute(int id)
        {
            var format = _context.Formats.Find(id);

            if (format == null)
            {
                throw new EntityNotFoundException(id, typeof(Format));
            }

            format.IsDeleted = true;
            format.IsActive = false;
            format.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
