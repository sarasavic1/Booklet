using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Booklet.Application;
using Booklet.Application.Commands;
using Booklet.Application.DataTransfer;
using Booklet.Application.Queries;
using Booklet.Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booklet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public BookController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get([FromQuery] BookSearch search, [FromServices] IGetBooksQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneBookQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<BookController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] CreateBookDto dto, [FromServices] ICreateBookCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }


        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id,[FromBody] UpdateBookDto dto, [FromServices] IUpdateBookCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteBookCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }


}
