using Booklet.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.Searches
{
    public class OrderSearch : PagedSearch
    {
        public string Status { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? UserId { get; set; }

    }
}
