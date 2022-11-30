using Questao5.Application.Queries.Responses;
using Questao5.Domain.Communication;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.Queries.Handlers
{
    public class ContaCorrenteQuerie : IContaCorrenteQuerie
    {
        private readonly IContaCorrenteRepository _repo;
        private readonly IMovimentoRepository _repoMovimento;

        public ContaCorrenteQuerie(IContaCorrenteRepository repo, IMovimentoRepository repoMovimento)
        {
            _repo = repo;
            _repoMovimento = repoMovimento;
        }
        public async Task<GetSaldoContaCorrenteQueryResponse> GetSaldo(Guid idConta)
        {
            var contaCorrente = await _repo.GetById(idConta);
            if(contaCorrente is null)
                return new GetSaldoContaCorrenteQueryResponse(idConta, true, "Conta inválida"); 

            var movimentacoes = await _repoMovimento.GetAll(contaCorrente);

            return new GetSaldoContaCorrenteQueryResponse(contaCorrente.Id, contaCorrente.GetSaldo(movimentacoes));
        }
    }
}