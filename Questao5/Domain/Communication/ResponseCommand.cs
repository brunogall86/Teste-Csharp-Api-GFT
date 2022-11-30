namespace Questao5.Domain.Communication
{
    public class ResponseCommand : Message
    {
        public bool Error {get;}
        public ResponseCommand(bool error)
        {
            Error = error;
            MessageType = error ? $"Erro ao executar operação: " : "Executado com sucesso" ;
        }
        public ResponseCommand(string retorno, bool error = false)
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