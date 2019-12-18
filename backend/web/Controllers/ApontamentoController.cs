using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using web.Controllers;
using services.commands.cadastros;
using entities.rehagro;
using System.Collections.Generic;
using System;
using web;

namespace Seguranca
{
    public static class Permissoes
    {
        public const string ID_NOME_URL = "fazendaid";
        public const string ID_URL = "{"+ ID_NOME_URL + "}";
        public const string MODULO_APONTAMENTO = "APONTAMENTO";

        public const string READ = "READ";
        public const string VIEW = "VIEW";
        public const string CREATE = "CREATE";
        public const string UPDATE = "UPDATE";
        public const string DELETE = "DELETE";
    }

    [Produces("application/json")]
    [Route("api/[controller]"), Permission(Permissoes.MODULO_APONTAMENTO)]
    public class ApontamentoController : BaseController
    {
        private readonly IMediator mediator;

        public ApontamentoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Permissoes.ID_URL), Permission(Permissoes.READ)]
        public async Task<IActionResult> GetAsync([FromQuery] Guid fazendaid)
        {
            return Ok(new List<Apontamento>() { new Apontamento { Id = Guid.NewGuid() } });
        }

        [HttpPost(Permissoes.ID_URL), Permission(Permissoes.CREATE)]
        public async Task<IActionResult> CreateAsync([FromQuery] Guid fazendaid, [FromBody] CreateApontamentoCommand command)
        {
            if (command == null)
                return BadRequest("Command não pode ser nulo");

            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
