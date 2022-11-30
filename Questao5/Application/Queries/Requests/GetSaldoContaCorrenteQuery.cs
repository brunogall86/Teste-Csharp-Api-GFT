using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Queries.Requests
{
    public class GetSaldoContaCorrenteQuery
    {
        [Required]
        public Guid IdContaCorrente { get; set; }

        public GetSaldoContaCorrenteQuery(Guid id)
        {
            IdContaCorrente = id;
        }
    }
}