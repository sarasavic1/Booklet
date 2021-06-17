using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class CartLine : Entity
    {
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CartId { get; set; }
        public int? BookId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Book Book { get; set; }
    }
}
