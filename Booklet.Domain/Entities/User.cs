using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
                        = new HashSet<Order>();

        public virtual ICollection<Cart> Carts { get; set; }
                        = new HashSet<Cart>();

        public virtual ICollection<Wishlist> Wishlists { get; set; }
                        = new HashSet<Wishlist>();

        public virtual ICollection<UserUseCase> UserUseCases { get; set; }

        public virtual ICollection<AuditLog> AuditLogs { get; set; }

    }
}
