using Questao5.Domain.Communication;

namespace Questao5.Domain.Mediator
{
    public interface IMediatorHandler
    {
         Task<ResponseCommand> SendCommand<T>(T command) where T : Command;
    }
}