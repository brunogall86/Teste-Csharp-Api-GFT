using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Handlers
{
    public interface IContaCorrenteQuerie
    {
         Task<GetSaldoContaCorrenteQueryResponse> GetSaldo(Guid idConta);
    }
}