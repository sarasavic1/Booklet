using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booklet.Application;
using Booklet.Application.Commands;
using Booklet.Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booklet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public RegisterController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // POST api/<RegisterController>
        [HttpPost]
        public void Post([FromBody] RegisterUserDto dto,
            [FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            //return StatusCode(StatusCodes.Status201Created);
        }

       
    }
}
