using Booklet.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.Searches
{
    public class BookSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int? GenreId { get; set; }

    }
}
