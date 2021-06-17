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
    public class EfDeleteWishlistCommand : IDeleteWishlistCommand
    {
        private readonly BookletContext _context;
        public EfDeleteWishlistCommand(BookletContext context)
        {
            _context = context;
        }
        public int Id => 21;

        public string Name => "Delete wishlist";

        public void Execute(int id)
        {
            var wishlist = _context.Wishlists.Find(id);

            var wishlistLines = _context.WishlistLines.FirstOrDefault(x => x.WishlistId == id);

            if (wishlist == null)
            {
                throw new EntityNotFoundException(id, typeof(Wishlist));
            }

           /* _context.Remove(wishlist);
            _context.Remove(wishlistLines);
            _context.SaveChanges();*/

            wishlist.IsDeleted = true;
            wishlist.IsActive = false;
            wishlist.DeletedAt = DateTime.Now;

            if (wishlistLines != null)
            {
                wishlistLines.IsDeleted = true;
                wishlistLines.IsActive = false;
                wishlistLines.DeletedAt = DateTime.Now;
            }

            _context.SaveChanges();
        }
    }
}
