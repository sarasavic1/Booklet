using Booklet.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.Searches
{
    public class AuditLogSearch : PagedSearch
    {
        public int? UserId { get; set; }
        public string? UseCaseName { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
