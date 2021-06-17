using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booklet.Application;
using Booklet.Application.Commands;
using Booklet.Application.DataTransfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booklet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishlistController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;


        public WishlistController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }
       
        // POST api/<WishlistController>
        [HttpPost]
        public IActionResult Post([FromBody] WishlistDto dto, [FromServices] ICreateWishlistCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<WishlistController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteWishlistCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
