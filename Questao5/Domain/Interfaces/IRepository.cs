using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T: BaseEntity
    {
         
    }
}