//using AutoMapper;
using Booklet.Application.Commands;
using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using Booklet.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfCreateBookCommand : ICreateBookCommand
    {
        private readonly BookletContext _context;
        private readonly CreateBookValidator _validator;
        //private readonly IMapper _mapper;

        public EfCreateBookCommand(BookletContext context, CreateBookValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 9;

        public string Name => "Create new book.";

        public void Execute(CreateBookDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.ImageFile.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.ImageFile.CopyTo(fileStream);
            }

            dto.Image = newFileName;

            var book =  new Book
            {
                Title=dto.Title,
                Quantity=dto.Quantity,
                Price=dto.Price,
                Description=dto.Description,
                ISBN=dto.ISBN,
                Image=dto.Image,
                PublishDate=dto.PublishDate,
                PageNumber=dto.PageNumber,
                FormatId=dto.FormatId,
                AuthorId=dto.AuthorId,
                PublisherId=dto.PublisherId
            };

            foreach(var genre in dto.Genres)
            {
                book.BookGenres.Add(new BookGenre
                {
                    BookId=book.Id,
                    GenreId = genre.Id
                });
            }

            //var book = _mapper.Map<Book>(dto);




            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
}
