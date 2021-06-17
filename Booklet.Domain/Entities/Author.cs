using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class Author : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
