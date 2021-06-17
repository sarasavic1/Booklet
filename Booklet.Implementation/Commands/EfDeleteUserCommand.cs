using Booklet.Application.Commands;
using Booklet.Application.Exceptions;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly BookletContext _context;
        public EfDeleteUserCommand(BookletContext context)
        {
            _context = context;
        }
        public int Id => 19;

        public string Name => "Delete user.";

        public void Execute(int id)
        {
            var user = _context.Users.Find(id);
            var wishlistUser = _context.Wishlists.FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            user.IsDeleted = true;
            user.IsActive = false;
            user.DeletedAt = DateTime.Now;

            if (wishlistUser != null)
            {
                wishlistUser.IsDeleted = true;
                wishlistUser.IsActive = false;
                wishlistUser.DeletedAt = DateTime.Now;
            }

            _context.SaveChanges();
        }
    }
}
