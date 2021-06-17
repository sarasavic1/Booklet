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
    public class EfCreatePublisherCommand : ICreatePublisherCommand
    {
        private readonly BookletContext _context;
        private readonly CreatePublisherValidator _validator;
        //private readonly IMapper _mapper;

        public EfCreatePublisherCommand(BookletContext context, CreatePublisherValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 3;

        public string Name => "Create new Publisher";

        public void Execute(PublisherDto dto)
        {
            _validator.ValidateAndThrow(dto);

           // var publisher = _mapper.Map<Publisher>(dto);
            var publisher = new Publisher
            {
                Name = dto.Name
            };


            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }
    }
}
