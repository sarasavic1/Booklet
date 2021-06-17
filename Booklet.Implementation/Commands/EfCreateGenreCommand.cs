//using AutoMapper;
using Booklet.Application.Commands;
using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using Booklet.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfCreateGenreCommand : ICreateGenreCommand
    {
        private readonly BookletContext _context;
        private readonly CreateGenreValidator _validator;
        //private readonly IMapper _mapper;

        public EfCreateGenreCommand(BookletContext context, CreateGenreValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 5;

        public string Name => "Create new genre.";

        public void Execute(GenreDto dto)
        {
            _validator.ValidateAndThrow(dto);

            //var genre = _mapper.Map<Genre>(dto);
            var genre = new Genre
            {
                GenreName = dto.GenreName
            };


            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
}
