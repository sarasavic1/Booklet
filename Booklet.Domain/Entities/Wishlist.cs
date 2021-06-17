using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class Wishlist : Entity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<WishlistLine> WishlistLines { get; set; }
                        = new HashSet<WishlistLine>();

    }
}
