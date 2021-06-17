using Booklet.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.Queries
{
    public interface IGetOneOrderQuery : IQuery<int, ReadOrderDto>
    {
    }
}
