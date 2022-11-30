namespace Questao5.Domain.Communication
{
    public class ResponseQuerie : Message
    {
         public bool Error {get;}
        public ResponseQuerie(bool error)
        {
            Error = error;
            MessageType = error ? $"Erro ao executar operação: " : "Executado com sucesso" ;
        }
        public ResponseQuerie(string retorno, bool error = false)
        {
            Error = error;
            MessageType = error ? $"Erro ao executar operação: { retorno }" : "Executado com sucesso" ;
        }
        public override string ToString()
        {
            return MessageType;
        }
    }
}