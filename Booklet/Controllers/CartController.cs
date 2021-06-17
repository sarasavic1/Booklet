using Booklet.Application;
using Booklet.Application.Commands;
using Booklet.Application.DataTransfer;
using Booklet.Application.Queries;
using Booklet.Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booklet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public CartController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }

        // GET: api/<CartController>
        [HttpGet]
        public IActionResult Get([FromQuery] CartSearch search, [FromServices] IGetCartsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }      

        // POST api/<CartController>
        [HttpPost]
        public IActionResult Post([FromBody] CartDto dto, [FromServices] ICreateCartCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCartCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
