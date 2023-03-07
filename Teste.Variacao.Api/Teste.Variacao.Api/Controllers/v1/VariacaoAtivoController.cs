using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Variacao.Application.Commands.VariacaoAtivo;
using Teste.Variacao.Application.DTOs.Request;
using Teste.Variacao.Application.DTOs.Response;
using Teste.Variacao.Application.Extensions;
using Teste.Variacao.Application.Interfaces.Queries;

namespace Teste.Variacao.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VariacaoAtivoController : BaseApiController<VariacaoAtivoController>
    {
        private readonly IVariacaoAtivoQueryService _queryService;

        public VariacaoAtivoController(IMediator mediator, IVariacaoAtivoQueryService queryService, ILogger<VariacaoAtivoController> logger) : base(mediator, logger)
        {
            _queryService = queryService;
        }

        [HttpGet("{name}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<VariacaoAtivoResponse>> GetByIdAsync(string name)
        {
            var result = await _queryService.GetByIdAsync(name);
            return Ok(result);
        }

        [Obsolete]
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> PostAsync([FromBody] List<VariacaoAtivoRequest> request)
        {
            var sendRequest = new InsertVariacaoAtivoCommand(request);
            var result = await Mediator.Send(sendRequest);

            return Created(string.Empty, result);
        }

        [Obsolete]
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] VariacaoAtivoRequest request)
        {
            var sendRequest = new UpdateVariacaoAtivoCommand(id, request);
            return Ok(await Mediator.Send(sendRequest));
        }

        [Obsolete]
        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteVariacaoAtivoCommand(id)));
        }
    }
}