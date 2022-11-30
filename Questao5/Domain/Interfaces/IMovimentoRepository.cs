using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IMovimentoRepository : IRepository<Movimento>
    {
        Task<bool> Add(Movimento movimento);
         Task<IEnumerable<Movimento>> GetAll(ContaCorrente conta);
    }
}