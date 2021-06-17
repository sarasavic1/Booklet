using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Application.DataTransfer
{
    public class ReadOrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public string FullName { get; set; }

        public string Address { get; set; }
        /*public string Email { get; set; }*/
        public decimal TotalPrice => OrderLines.Sum(x => x.Price * x.Quantity);
        public IEnumerable<ReadOrderLineDto> OrderLines { get; set; } = new List<ReadOrderLineDto>();


    }

    public class ReadOrderLineDto
    {
        public int Id { get; set; }
        public string Book { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
