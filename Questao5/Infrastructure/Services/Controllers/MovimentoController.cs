using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Interfaces;
using Questao5.Domain.Mediator;
using Questao5.Infrastructure.Services.Controllers.ViewModel;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentoController : ControllerBase
    {
        private readonly IMovimentoRepository _repoMovimento;
        private readonly IContaCorrenteRepository _repoContaCorrente;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ILogger<MovimentoController> _logger;

        public MovimentoController(IMovimentoRepository repo, IContaCorrenteRepository repoCotaCorrente, IMediatorHandler mediatorHandler, ILogger<MovimentoController> log)
        {
            _repoMovimento = repo;
            _repoContaCorrente = repoCotaCorrente;
            _mediatorHandler = mediatorHandler;
            _logger = log;
        }
        [HttpPost]
        public async Task<IActionResult> Movimentar([FromBody] AddMovimentoViewModel model)
        {   
            try
            {
                if(!ModelState.IsValid)
                    BadRequest("Dados inválidos");

                var command = new AddMovimentoCommand(model.IdContaCorrente, model.Valor, model.TipoMovimento);

                var r = await _mediatorHandler.SendCommand(command);                    

                if(!r.Error)
                    return Ok(r);
                else
                    return BadRequest(r.MessageType);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest("Error ");
            }
        } 
    }
}
