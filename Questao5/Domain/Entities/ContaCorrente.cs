using System.Runtime.CompilerServices;
using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
  
    public class ContaCorrente : BaseEntity
    {
        public int Numero { get; private set; }
        public string Nome { get; private set; }
        public StatusContaCorrente Ativo { get; private set; } = StatusContaCorrente.Ativo;

        protected ContaCorrente()
        {

        }
        public ContaCorrente(int numero, string nome) : base()
        {
            Numero = numero;
            Nome = nome;
        }
        public ContaCorrente(Guid id, int numero, string nome) : base(id)
        {
            Numero = numero;
            Nome = nome;
        }

        public decimal GetSaldo(IEnumerable<Movimento> movimentacoes)
        {
            var debitos  = movimentacoes.Where(item => item.TipoMovimento == TipoMovimento.Debito).Select(item => item);
            var creditos = movimentacoes.Where(item => item.TipoMovimento == TipoMovimento.Credito).Select(item => item);

            var totalDebitos  = debitos.Sum(debito => debito.Valor);
            var totalCreditos = creditos.Sum(credito => credito.Valor);

            return Convert.ToDecimal(totalCreditos - totalDebitos);
        }
        public bool IsAtiva() => Ativo.Equals(StatusContaCorrente.Ativo);
        
    }
}