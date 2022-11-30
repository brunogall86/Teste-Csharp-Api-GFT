using FluentValidation;
using Questao5.Domain.Communication;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Requests
{
    public class AddMovimentoCommand : Command
    {
        public char TipoMovimento { get; private set; }
        public decimal Valor { get; private set; }
        public Guid IdContaCorrente { get; private set; }
        public DateTime DataMovimento => DateTime.Now;

        public AddMovimentoCommand(Guid idContaCorrente, decimal valor, char tipoMovimento)
        {
            IdContaCorrente = idContaCorrente;
            Valor = valor;
            TipoMovimento = tipoMovimento;
        }

        public override bool EhValido()
        {
            ValidationResult = new AddMovimentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public override string ToString()
        {
            return $"IdConta: { IdContaCorrente } - Valor: { Valor } - TipoMovimento: { TipoMovimento } - DataMovimento: { DataMovimento }";
        }
    }    

    public class AddMovimentoValidation : AbstractValidator<AddMovimentoCommand>
    {
        public AddMovimentoValidation()
        {
            RuleFor(c => c.IdContaCorrente)
                .NotEqual(Guid.Empty)
                .WithMessage("Id ContaCorrente inválida");

            RuleFor(c => c.Valor)                
                .GreaterThanOrEqualTo(0)
                .WithMessage("Valor invalido");
        }
    }
}
