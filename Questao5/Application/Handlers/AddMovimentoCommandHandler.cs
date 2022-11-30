using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Communication;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Interfaces;
using Questao5.Domain.Mediator;

namespace Questao5.Application.Handlers
{
    public class AddMovimentoCommandHandler :
                    IRequestHandler<AddMovimentoCommand, ResponseCommand>,
                    IRequestHandler<AddIdempotenciaCommand, ResponseCommand>
    {
        private readonly IMovimentoRepository _movimentoRepository;
        private IIdempotenciaRepository _idempotenciaRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IContaCorrenteRepository _repoContaCorrente;

        public AddMovimentoCommandHandler(IContaCorrenteRepository contaCorrenteRepository,
                                          IMovimentoRepository movimentoRepository, 
                                          IIdempotenciaRepository idempotenciaRepository, 
                                          IMediatorHandler mediatorHandler)
        {
            _movimentoRepository = movimentoRepository;
            _idempotenciaRepository = idempotenciaRepository;
            _mediatorHandler = mediatorHandler;
            _repoContaCorrente = contaCorrenteRepository;
        }
        public async Task<ResponseCommand> Handle(AddMovimentoCommand command, CancellationToken cancellationToken)
        {
            if(!command.EhValido()) return new ResponseCommand("Dados inválidos", false);

            var contaExiste = await _repoContaCorrente.GetById(command.IdContaCorrente);
            if(contaExiste is null)    
                return new ResponseCommand("INVALID_ACCOUNT", true); 

            if(!contaExiste.IsAtiva())
                return new ResponseCommand("INACTIVE_ACCOUNT", true); 

            if(command.Valor <= 0)        
                return new ResponseCommand("INVALID_VALUE", true); 

            if(!EnumeradoresExtensions.ExisteNoEnumTipoMovimento(command.TipoMovimento))
                return new ResponseCommand("INVALID_TYPE", true); 

            
            var movimento = new Movimento(contaExiste, (TipoMovimento)command.TipoMovimento, command.Valor, command.DataMovimento);

            var result = await _movimentoRepository.Add(movimento);
            var response = new ResponseCommand(!result);

            var idempotenciaCommand = new AddIdempotenciaCommand(command, response); 
            await _mediatorHandler.SendCommand(idempotenciaCommand);
            
            return response;
        }

        public async Task<ResponseCommand> Handle(AddIdempotenciaCommand command, CancellationToken cancellationToken)
        {
            if(!command.EhValido()) return new ResponseCommand(false);

            var result = await _idempotenciaRepository.Add(new Idempotencia(command.Chave, command.Requisicao, command.Resultado));
            return new ResponseCommand(result);
        }
    }
}