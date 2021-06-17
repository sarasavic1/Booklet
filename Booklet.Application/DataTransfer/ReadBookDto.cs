using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.DataTransfer
{
    public class ReadBookDto
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long ISBN { get; set; }
        public string Image { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageNumber { get; set; }
        
        public string Format { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public IEnumerable<ReadBookGenreDto> Genres { get; set; } = new List<ReadBookGenreDto>();

    }

    public class ReadBookGenreDto
    {
        public string genre { get; set; }

    }
}

