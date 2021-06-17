using Booklet.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.Searches
{
    public class CartSearch : PagedSearch
    {
        public int? UserId { get; set; }
    }
}
