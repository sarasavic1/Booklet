using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Application.DataTransfer
{
    public class UpdateUserDto
    {
        public int Id { get; set; }     
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
