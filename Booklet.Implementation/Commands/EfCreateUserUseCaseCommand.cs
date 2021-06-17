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
    public class EfCreateUserUseCaseCommand : ICreateUserUseCaseCommand
    {
        private readonly BookletContext _context;
        private readonly CreateUserUseCaseValidator _validator;
        //private readonly IMapper _mapper;

        public EfCreateUserUseCaseCommand(BookletContext context, CreateUserUseCaseValidator validator/*, IMapper mapper*/)
        {
            _context = context;
            _validator = validator;
            //_mapper = mapper;
        }
        public int Id => 26;

        public string Name => "Create user use case.";

        public void Execute(UserUseCaseDto dto)
        {
            _validator.ValidateAndThrow(dto);

            //var author = _mapper.Map<Author>(dto);
            var userUseCase = new UserUseCase
            {
                UserId=dto.UserId,
                UseCaseId=dto.UseCaseId
            };


            _context.UserUseCases.Add(userUseCase);
            _context.SaveChanges();
        }
    }
}
