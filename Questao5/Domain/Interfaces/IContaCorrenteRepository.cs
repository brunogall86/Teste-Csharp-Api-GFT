using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IContaCorrenteRepository : IRepository<ContaCorrente>
    {
         Task<ContaCorrente> GetById(Guid id);
    }
}