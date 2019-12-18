using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using web.Controllers;
using services.commands.cadastros;
using entities.rehagro;
using System.Collections.Generic;
using System;
using web;
using services.services.equipe;
using core.seedwork;

namespace controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EquipeController : BaseController
    {
        private readonly IMediator mediator;
        private readonly QueryEquipe query;

        public EquipeController(IMediator mediator, QueryEquipe query)
        {
            this.mediator = mediator;
            this.query = query;
        }

        [HttpGet("{fazendaid}")]
        public async Task<IActionResult> GetAsync([FromQuery] Guid fazendaid)
        {
            var result = await query.GetEquipesByFazendaId(fazendaid);
            return Ok(new Response(result));
        }
    }
}
