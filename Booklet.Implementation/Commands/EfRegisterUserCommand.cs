using Booklet.Application.Commands;
using Booklet.Application.DataTransfer;
using Booklet.Application.Email;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using Booklet.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booklet.Implementation.Commands
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly BookletContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfRegisterUserCommand(BookletContext context, RegisterUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 17;

        public string Name => "User Registration";

        public void Execute(RegisterUserDto dto)
        {
            _validator.ValidateAndThrow(dto);

            _context.Users.Add(new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email,
                Address=dto.Address
            });


            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Successfull registration!</h1>",
                SendTo = dto.Email,
                Subject = "Registration"
            });

        }
    }
}
