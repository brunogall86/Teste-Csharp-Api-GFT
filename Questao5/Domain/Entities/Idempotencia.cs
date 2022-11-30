namespace Questao5.Domain.Entities
{
    public class Idempotencia : BaseEntity
    {
        public string Requisicao { get; private set; }
        public string Resultado { get; private set; }

        protected Idempotencia() { }

        public Idempotencia(Guid id, string requisicao, string resultado) : base(id)
        {
            Requisicao = requisicao;
            Resultado = resultado;
        }

        public Idempotencia(string requisicao, string resultado) : base()
        {
            Requisicao = requisicao;
            Resultado = resultado;
        }
    }
}