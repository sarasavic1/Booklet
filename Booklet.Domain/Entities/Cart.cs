using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class Cart : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<CartLine> CartLines { get; set; }
                        = new HashSet<CartLine>();
    }
}
