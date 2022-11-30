using FluentValidation;
using MediatR;
using Questao5.Domain.Communication;

namespace Questao5.Application.Commands.Requests
{
    public class AddIdempotenciaCommand : Command
    {
        public Guid Chave { get; private set; }
        public string Requisicao { get; private set; }
        public string Resultado { get; private set; }
        
        public AddIdempotenciaCommand(Message request, Message response)
        {
            Chave = Guid.NewGuid();
            Requisicao = request.ToString();
            Resultado = response.ToString();
        }
        public AddIdempotenciaCommand(Guid chave, string requisicao, string resultado)
        {
            Chave = chave;
            Requisicao = requisicao;
            Resultado = resultado;
        }
        public override bool EhValido()
        {
            ValidationResult = new AddIdempotenciaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

      
         
    }

    public class AddIdempotenciaValidation : AbstractValidator<AddIdempotenciaCommand>
    {
        public AddIdempotenciaValidation()
        {
            RuleFor(c => c.Chave)
                .NotEqual(Guid.Empty)
                .WithMessage("Chave inválida");
            
            RuleFor(c => c.Requisicao)
                .NotEmpty()
                .WithMessage("Requisicao inválida");

            RuleFor(c => c.Resultado)
                .NotEmpty()
                .WithMessage("Resultado inválido");
            
        }
    }
}