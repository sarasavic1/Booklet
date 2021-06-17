using Booklet.Application;
using Booklet.Application.Queries;
using Booklet.Application.Searches;
using Microsoft.AspNetCore.Authorization;
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
    public class AuditLogController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public AuditLogController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }

        // GET: api/<AuditLogController>
        [HttpGet]
        public IActionResult Get([FromQuery] AuditLogSearch search, [FromServices] IGetAuditLogsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

       
    }
}
