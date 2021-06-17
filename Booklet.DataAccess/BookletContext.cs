using Booklet.DataAccess.Configurations;
using Booklet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Booklet.DataAccess
{
    public class BookletContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4V9T1U2\SQLEXPRESS;Initial Catalog=booklet-database;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfigurations());
            modelBuilder.ApplyConfiguration(new BookConfigurations());
            modelBuilder.ApplyConfiguration(new FormatConfigurations());
            modelBuilder.ApplyConfiguration(new GenreConfigurations());
            modelBuilder.ApplyConfiguration(new OrderConfigurations());
            modelBuilder.ApplyConfiguration(new PublisherConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new WishlistConfigurations());

            modelBuilder.Entity<BookGenre>().HasKey(x => new { x.BookId, x.GenreId });

            modelBuilder.Entity<Author>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Publisher>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Book>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Format>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Genre>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<OrderLine>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Wishlist>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<WishlistLine>().HasQueryFilter(p => !p.IsDeleted);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        public DbSet<Format> Formats { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<WishlistLine> WishlistLines { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }




    }
}
