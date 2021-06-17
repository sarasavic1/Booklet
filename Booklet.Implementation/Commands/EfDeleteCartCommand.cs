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
    public class EfDeleteCartCommand : IDeleteCartCommand
    {
        private readonly BookletContext _context;
        public EfDeleteCartCommand(BookletContext context)
        {
            _context = context;
        }
        public int Id => 24;

        public string Name => "Delete cart.";

        public void Execute(int id)
        {
            var cart = _context.Cart.Find(id);

            var cartLines = _context.CartLines.FirstOrDefault(x => x.CartId == id);

            if (cart == null)
            {
                throw new EntityNotFoundException(id, typeof(Cart));
            }

            /* _context.Remove(wishlist);
             _context.Remove(wishlistLines);
             _context.SaveChanges();*/

            cart.IsDeleted = true;
            cart.IsActive = false;
            cart.DeletedAt = DateTime.Now;

            if (cartLines != null)
            {
                cartLines.IsDeleted = true;
                cartLines.IsActive = false;
                cartLines.DeletedAt = DateTime.Now;
            }

            _context.SaveChanges();
        }
    }
}
