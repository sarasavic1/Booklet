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
    public class EfCreateAuthorCommand : ICreateAuthorCommand
    {
        private readonly BookletContext _context;
        private readonly CreateAuthorValidator _validator;
        //private readonly IMapper _mapper;

        public EfCreateAuthorCommand(BookletContext context, CreateAuthorValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 1;

        public string Name => "Create new Author";

        public void Execute(AuthorDto dto)
        {
            _validator.ValidateAndThrow(dto);

           //var author = _mapper.Map<Author>(dto);
           var author = new Author
            {
                Name = dto.Name
            };

                
            _context.Authors.Add(author); 
            _context.SaveChanges();


        }
    }
}
