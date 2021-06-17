using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
                        = new HashSet<OrderLine>();
    }

    public enum OrderStatus
    {
        Recieved,
        Delivered,
        Shipped,
        Canceled
    }
}
