using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class Format : Entity
    {
        public string FormatName { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();

    }
}
