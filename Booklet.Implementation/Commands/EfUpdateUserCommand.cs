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
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly BookletContext _context;
        private readonly UpdateUserValidator _validator;
        //private readonly IMapper _mapper;

        public EfUpdateUserCommand(BookletContext context, UpdateUserValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
           // _mapper = mapper;
        }
        public int Id => 18;

        public string Name => "Update user";

        public void Execute(UpdateUserDto dto)
        {
            var user = _context.Users.Find(dto.Id);

            if (user == null)
            {
                throw new EntityNotFoundException(dto.Id, typeof(User));
            }

            _validator.ValidateAndThrow(dto);

            user.Address = dto.Address;
            user.Password = dto.Password;

            _context.SaveChanges();
        }
    }
}
