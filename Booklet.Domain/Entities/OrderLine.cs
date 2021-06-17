using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class OrderLine : Entity
    {
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int? BookId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
    }
}
