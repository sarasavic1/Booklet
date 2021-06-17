using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.DataTransfer
{
    public class ReadCartDto
    {
        public int UserId { get; set; }
        public IEnumerable<ReadCartLineDto> CartLines { get; set; } = new List<ReadCartLineDto>();
    }

    public class ReadCartLineDto
    {
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
