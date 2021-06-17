using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.DataTransfer
{
    public class OrderDto
    {
        public int CartId { get; set; }
        public DateTime OrderDate { get; set; }
        //public IEnumerable<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();
    }

    /*public class OrderLineDto
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }*/
}
