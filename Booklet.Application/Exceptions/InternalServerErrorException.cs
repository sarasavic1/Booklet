using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() :base("An error occurred")
        {

        }
    }
}
