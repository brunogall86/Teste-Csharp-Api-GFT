using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IIdempotenciaRepository : IRepository<Idempotencia>
    {
         Task<bool> Add(Idempotencia idempotencia);
    }
}