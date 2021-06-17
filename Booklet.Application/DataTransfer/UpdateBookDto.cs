using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.DataTransfer
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long ISBN { get; set; }
        public string Image { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageNumber { get; set; }

        public int FormatId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
