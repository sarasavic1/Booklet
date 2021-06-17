using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public long ISBN { get; set; }
        public string Image { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageNumber { get; set; }

        public int FormatId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        
        public virtual Format Format { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; } = new HashSet<BookGenre>();
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
        public virtual ICollection<WishlistLine> WishlistLines { get; set; } = new HashSet<WishlistLine>();

        public virtual ICollection<CartLine> CartLines { get; set; } = new HashSet<CartLine>();
    }
}
