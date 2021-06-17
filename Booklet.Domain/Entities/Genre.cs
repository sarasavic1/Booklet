using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class Genre : Entity
    {
        public string GenreName { get; set; }

        public virtual ICollection<BookGenre> BookGenres { get; set; } = new HashSet<BookGenre>();
    }
}
