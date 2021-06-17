//using AutoMapper;
using Booklet.Application.Commands;
using Booklet.Application.DataTransfer;
using Booklet.Application.Exceptions;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using Booklet.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfUpdateBookCommand : IUpdateBookCommand
    {
        private readonly BookletContext _context;
        private readonly UpdateBookValidator _validator;
        //private readonly IMapper _mapper;

        public EfUpdateBookCommand(BookletContext context, UpdateBookValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 11;

        public string Name => "Update book.";

        public void Execute(UpdateBookDto dto)
        {
            var book = _context.Books.Find(dto.Id);

            if (book == null)
            {
                throw new EntityNotFoundException(dto.Id, typeof(Book));
            }

            _validator.ValidateAndThrow(dto);

            book.Title = dto.Title;
            book.Quantity = dto.Quantity;
            book.Price = dto.Price;
            book.Description = dto.Description;
            book.ISBN = dto.ISBN;
            book.Image = dto.Image;
            book.PublishDate = dto.PublishDate;
            book.PageNumber = dto.PageNumber;
            book.FormatId = dto.FormatId;
            book.AuthorId = dto.AuthorId;
            book.PublisherId = dto.PublisherId;


            _context.SaveChanges();
        }

    }
}
