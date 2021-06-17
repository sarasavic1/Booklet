using Booklet.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.Commands
{
    public interface ICreatePublisherCommand : ICommand<PublisherDto>
    {
    }
}
