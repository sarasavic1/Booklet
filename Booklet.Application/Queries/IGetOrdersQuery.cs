using Booklet.Application.DataTransfer;
using Booklet.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.Queries
{
    public interface IGetOrdersQuery : IQuery<OrderSearch, PagedResponse<ReadOrderDto>>
    {
    }
}
