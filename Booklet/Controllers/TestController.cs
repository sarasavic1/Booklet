using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booklet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly BookletContext _context;

        public TestController(BookletContext context)
        {
            _context = context;
        }
       
        // POST api/<TestController>
        [HttpPost]
        public void Post()
        {
            var authors = new List<Author>
            {
                new Author
                {
                    Name = "Stephen King"
                },
                new Author
                {
                    Name = "Dan Brown"
                },
                new Author
                {
                    Name = "J. K. Rowling"
                },

            };

            var publishers = new List<Publisher>
            {
                new Publisher
                {
                    Name="Hodder"
                },
                new Publisher
                {
                    Name="Bloomsbury"
                },
                new Publisher
                {
                    Name="Transworld"
                },
                new Publisher
                {
                    Name="Little, Brown Book"
                }
            };

            var genres = new List<Genre>
            {
                new Genre
                {
                    GenreName="Mistery"
                },
                new Genre
                {
                    GenreName="Horror"
                },
                new Genre
                {
                    GenreName="Fantasy"
                },
                new Genre
                {
                    GenreName="Crime"
                }
            };

            var formats = new List<Format>
            {
                new Format
                {
                    FormatName="Paperback"
                },
                new Format
                {
                    FormatName="Hardback"
                },
                new Format
                {
                    FormatName="Audio Book"
                }
            };

            var books = new List<Book>
            {
                new Book
                {
                    Title="Inferno",
                    Quantity=5,
                    Price=26,
                    Description="Dan Brown's new novel, Inferno, features renowned Harvard symbologist Robert Langdon and is set in the heart of Europe, where Langdon is drawn into a harrowing world centred around one of history’s most enduring and mysterious literary masterpieces.",
                    ISBN=9780593072493,
                    Image="inferno.png",
                    PublishDate=Convert.ToDateTime("May 14 2013"),
                    PageNumber=345,
                    Author=authors.ElementAt(1),
                    Publisher=publishers.ElementAt(2),
                    Format=formats.ElementAt(0)

                },
                new Book
                {
                    Title="Pet Sematary",
                    Quantity=10,
                    Price=30,
                    Description="Soon to be a major motion picture from Paramount Pictures starring John Lithgow, Jason Clarke, and Amy Seimetz! King's iconic, beloved classic is 'so beautifully paced that you cannot help but be pulled in' Guardian.",
                    ISBN=9781444708134,
                    Image="pet.png",
                    PublishDate=DateTime.Parse("Jan 02 2012"),
                    PageNumber=428,
                    Author=authors.ElementAt(0),
                    Publisher=publishers.ElementAt(0),
                    Format=formats.ElementAt(1)
                },
                new Book
                {
                    Title="Cujo",
                    Quantity=3,
                    Price=21,
                    Description="The #1 New York Times bestseller, Cujo hits the jugular (The New York Times) with the story of a friendly Saint Bernard that is bitten by a bat. Get ready to meet the most hideous menace ever to terrorize the town of Castle Rock.",
                    ISBN= 9781501192241,
                    Image="cujo.png",
                    PublishDate=DateTime.Parse("Aug 22 2018"),
                    PageNumber=264,
                    Author=authors.ElementAt(0),
                    Publisher=publishers.ElementAt(0),
                    Format=formats.ElementAt(1)
                },
                new Book
                {
                    Title="Harry Potter and the Philosopher's Stone",
                    Quantity=4,
                    Price=14,
                    Description="Escape to Hogwarts with the unmissable series that has sparked a lifelong reading journey for children and families all over the world. The magic starts here.",
                    ISBN= 9781408855652,
                    Image="harrypotter.png",
                    PublishDate=DateTime.Parse("Sep 01 2014"),
                    PageNumber=213,
                    Author=authors.ElementAt(2),
                    Publisher=publishers.ElementAt(1),
                    Format=formats.ElementAt(2)
                },
                new Book
                {
                    Title="Lethal White",
                    Quantity=14,
                    Price=20,
                    Description="Hugely absorbing. . . the best Strike novel yet' SUNDAY MIRROR.",
                    ISBN= 9780751572872,
                    Image="lethalwhite.png",
                    PublishDate=DateTime.Parse("Nov 08 2019"),
                    PageNumber=2423,
                    Author=authors.ElementAt(2),
                    Publisher=publishers.ElementAt(3),
                    Format=formats.ElementAt(0)
                },
                new Book
                {
                    Title="Origin",
                    Quantity=5,
                    Price=45,
                    Description="In keeping with his trademark style, Brown interweaves codes, science, religion, history, art and architecture into this new novel. Origin thrusts Harvard symbologist Robert Langdon into the dangerous intersection of humankind’s two most enduring questions, and the earth-shaking discovery that will answer them.",
                    ISBN=9780593078754,
                    Image="origin.png",
                    PublishDate=DateTime.Parse("Sep 26 2017"),
                    PageNumber=748,
                    Author=authors.ElementAt(1),
                    Publisher=publishers.ElementAt(2),
                    Format=formats.ElementAt(1)
                },
                new Book
                {
                    Title="The Institute",
                    Quantity=10,
                    Price=19,
                    Description="Luke Ellis, a super-smart twelve-year-old with an exceptional gift, is the latest in a long line of kids abducted and taken to a secret government facility, hidden deep in the forest in Maine.",
                    ISBN= 9781529355413,
                    Image="institute.png",
                    PublishDate=DateTime.Parse("Sep 24 2020"),
                    PageNumber=496,
                    Author=authors.ElementAt(0),
                    Publisher=publishers.ElementAt(0),
                    Format=formats.ElementAt(2)
                },
            };

            var bookGenres = new List<BookGenre>
            {
                new BookGenre
                {
                   Book=books.ElementAt(0),
                   Genre=genres.ElementAt(3)
                },
                new BookGenre
                {
                   Book=books.ElementAt(0),
                   Genre=genres.ElementAt(0)
                },
                new BookGenre
                {
                   Book=books.ElementAt(1),
                   Genre=genres.ElementAt(1)
                },
                new BookGenre
                {
                   Book=books.ElementAt(1),
                   Genre=genres.ElementAt(0)
                },
                new BookGenre
                {
                   Book=books.ElementAt(2),
                   Genre=genres.ElementAt(1)
                },
                new BookGenre
                {
                   Book=books.ElementAt(3),
                   Genre=genres.ElementAt(2)
                },
                new BookGenre
                {
                   Book=books.ElementAt(4),
                   Genre=genres.ElementAt(3)
                },
                new BookGenre
                {
                   Book=books.ElementAt(5),
                   Genre=genres.ElementAt(0)
                },
                new BookGenre
                {
                   Book=books.ElementAt(6),
                   Genre=genres.ElementAt(2)
                },
                new BookGenre
                {
                   Book=books.ElementAt(6),
                   Genre=genres.ElementAt(0)
                }

            };

            var users = new List<User>
            {
                new User
                {
                    Username="sara211",
                    FirstName="Sara",
                    LastName="Savic",
                    Address="Bulevar Zorana Djinjdica 71/9"
                },
                new User
                {
                    Username="nikola92",
                    FirstName="Nikola",
                    LastName="Pesic",
                    Address="Svetozara Markovica 62"
                },
                new User
                {
                    Username="milica95",
                    FirstName="Milica",
                    LastName="Mitrovic",
                    Address="Bulevar Umetnosti 19"
                },
            };

            var wishLists = new List<Wishlist>
            {
                new Wishlist
                {
                    Name="Wishlist 1",
                    User=users.ElementAt(0)
                }
            };

            var wishListLines = new List<WishlistLine>
            {
                new WishlistLine
                {
                    BookName = "Cujo",
                    Book=books.ElementAt(2),
                    Wishlist=wishLists.ElementAt(0)
                },
                new WishlistLine
                {
                    BookName = "Origin",
                    Book=books.ElementAt(5),
                    Wishlist=wishLists.ElementAt(0)
                },
            };

            var orders = new List<Order>
            {
                new Order
                {
                    OrderDate = DateTime.UtcNow,
                    User=users.ElementAt(0)
                }
            };

            var orderLines = new List<OrderLine>
            {
                new OrderLine
                {
                    BookName = "Cujo",
                    Book=books.ElementAt(2),
                    Quantity=1,
                    Price=21,
                    Order=orders.ElementAt(0)
                }
            };

            _context.Authors.AddRange(authors);
            _context.Publishers.AddRange(publishers);
            _context.Genres.AddRange(genres);
            _context.Books.AddRange(books);
            _context.BookGenres.AddRange(bookGenres);
            _context.Users.AddRange(users);
            _context.Wishlists.AddRange(wishLists);
            _context.WishlistLines.AddRange(wishListLines);
            _context.Orders.AddRange(orders);
            _context.OrderLines.AddRange(orderLines);

            _context.SaveChanges();
        }
        
    }
}
