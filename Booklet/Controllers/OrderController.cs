using System;
using System.Collections.Generic;
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
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public OrderController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneOrderQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
