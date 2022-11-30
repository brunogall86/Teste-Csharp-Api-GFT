using MediatR;
using Questao5.Domain.Communication;

namespace Questao5.Domain.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ResponseCommand> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

       
    }
}