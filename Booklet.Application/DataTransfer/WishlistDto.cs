using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.DataTransfer
{
    public class WishlistDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public IEnumerable<WishlistLineDto> WishlistLines { get; set; } = new List<WishlistLineDto>();
    }

    public class WishlistLineDto
    {
        public string BookName { get; set; }
        public int BookId { get; set; }
    }
}
