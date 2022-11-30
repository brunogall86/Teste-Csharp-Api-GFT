using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries.Handlers;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Mediator;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private IContaCorrenteQuerie _repoContaCorrente;

        public ContaCorrenteController(IContaCorrenteQuerie repoCotaCorrente)
        {
            _repoContaCorrente = repoCotaCorrente;
        }

        [HttpGet("saldo")]
        public async Task<IActionResult> GetSaldo(Guid id)
        {   
            try
            {
                if(!ModelState.IsValid)
                    BadRequest("Dados inválidos");

                var result = await _repoContaCorrente.GetSaldo(id);

                if(!result.Error)
                    return Ok(result);
                else
                    return BadRequest(result.MessageError);
            }
            catch (System.Exception)
            {
                return BadRequest("Error ");
            }
        } 
    }
}