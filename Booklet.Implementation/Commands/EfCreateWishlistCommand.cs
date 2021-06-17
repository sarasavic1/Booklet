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
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfCreateWishlistCommand : ICreateWishlistCommand
    {
        private readonly BookletContext _context;
        private readonly CreateWishlistValidator _validator;
        //private readonly IMapper _mapper;

        public EfCreateWishlistCommand(BookletContext context, CreateWishlistValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 20;

        public string Name => "Create Wishlist";

        public void Execute(WishlistDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var wishlist = /*_mapper.Map<Author>(dto);*/ new Wishlist
            {
                Name=dto.Name,
                UserId=dto.UserId
            };

            foreach (var lines in dto.WishlistLines)
            {
                var bookFind = _context.Books.Find(lines.BookId);

                if (bookFind == null)
                {
                    throw new EntityNotFoundException(lines.BookId, typeof(Book));
                }

                wishlist.WishlistLines.Add(new WishlistLine
                {
                    BookId=lines.BookId,
                    BookName=bookFind.Title

                });
            }


            _context.Wishlists.Add(wishlist);
            _context.SaveChanges();
        }
    }
}
