using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.DataTransfer
{
    public class CartDto
    {
        public int UserId { get; set; }
        public IEnumerable<CartLineDto> CartLines { get; set; } = new List<CartLineDto>();
    }

    public class CartLineDto
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
