using FluentValidation.Results;
using MediatR;

namespace Questao5.Domain.Communication
{
    public abstract class Command : Message, IRequest<ResponseCommand>
    {
        public DateTime TimeStamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        protected Command()
        {
            TimeStamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}