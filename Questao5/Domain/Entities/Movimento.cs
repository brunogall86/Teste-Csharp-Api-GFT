using System.Diagnostics.Contracts;
using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class Movimento : BaseEntity
    {
        public TipoMovimento TipoMovimento { get; private set; }
        public DateTime DataMovimento { get; private set; }
        public Guid IdContaCorrente { get; private set; }
        public decimal  Valor { get; private set; }

        public ContaCorrente ContaCorrente { get; private set; }

        protected Movimento() { }

        public Movimento(Guid id, ContaCorrente contaCorrente, TipoMovimento tipoMovimento, decimal valor, DateTime? dataMovimento) : base(id)
        {
            SetContaCorrente(contaCorrente);
            TipoMovimento = tipoMovimento;
            Valor = valor;
            DataMovimento = dataMovimento ?? DateTime.Now;
        }
        public Movimento(ContaCorrente contaCorrente, TipoMovimento tipoMovimento, decimal valor, DateTime? dataMovimento) : base()
        {
            SetContaCorrente(contaCorrente);
            TipoMovimento = tipoMovimento;
            Valor = valor;
            DataMovimento = dataMovimento ?? DateTime.Now;
        }

        private void SetContaCorrente(ContaCorrente conta)
        {
            ContaCorrente = conta;
            IdContaCorrente = ContaCorrente.Id;
        }

    }
}