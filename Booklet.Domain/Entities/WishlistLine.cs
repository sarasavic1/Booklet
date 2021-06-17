using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class WishlistLine : Entity
    {
        public string BookName { get; set; }
        public int BookId { get; set; }
        public int WishlistId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Wishlist Wishlist { get; set; }
    }
}
