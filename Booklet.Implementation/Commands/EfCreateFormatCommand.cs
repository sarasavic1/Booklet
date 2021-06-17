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
    public class EfCreateFormatCommand : ICreateFormatCommand
    {
        private readonly BookletContext _context;
        private readonly CreateFormatValidator _validator;
        //private readonly IMapper _mapper;

        public EfCreateFormatCommand(BookletContext context, CreateFormatValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 7;

        public string Name => "Create Format";

        public void Execute(FormatDto dto)
        {
            _validator.ValidateAndThrow(dto);

            //var format = _mapper.Map<Format>(dto);

            var format = new Format
            {
                FormatName = dto.FormatName
            };


            _context.Formats.Add(format);
            _context.SaveChanges();
        }
    }
}
