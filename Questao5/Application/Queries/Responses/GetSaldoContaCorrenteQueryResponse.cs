namespace Questao5.Application.Queries.Responses
{
    public class GetSaldoContaCorrenteQueryResponse 
    {
        public Guid IdContaCorrente { get; set; }
        public bool Error { get; set; }
        public string MessageError { get; set; }
        public decimal Saldo { get; set; }

        public GetSaldoContaCorrenteQueryResponse(Guid id, decimal saldo)
        {
            IdContaCorrente = id;
            Saldo = saldo;   
        }
        public GetSaldoContaCorrenteQueryResponse(Guid id)
        {
            IdContaCorrente = id;
        }
        public GetSaldoContaCorrenteQueryResponse(Guid id, bool error, string message)
        {
            IdContaCorrente = id;
            Error = error;
            MessageError = message;
        }
    }
}