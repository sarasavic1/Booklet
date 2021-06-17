using Booklet.Application.DataTransfer;
using Booklet.Application.Queries;
using Booklet.Application.Searches;
using Booklet.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Queries
{
    public class EfGetAuditLogsQuery : IGetAuditLogsQuery
    {
        private readonly BookletContext _context;

        public EfGetAuditLogsQuery(BookletContext context)
        {
            _context = context;
        }
        public int Id => 22;

        public string Name => "Search Audit Log";

        public PagedResponse<AuditLogDto> Execute(AuditLogSearch search)
        {
            var query = _context.AuditLogs.AsQueryable();

            if(!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }
            if (search.From != null)
            {
                query = query.Where(x => x.LogDate >= search.From);
            }
            if (search.To != null)
            {
                query = query.Where(x => x.LogDate <= search.To);
            }

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId <= search.UserId);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<AuditLogDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new AuditLogDto
                {
                    LogDate = x.LogDate,
                    UserId = x.UserId,
                    UseCaseName = x.UseCaseName

                }).ToList()
            };
            return reponse;
        }
    }
}
