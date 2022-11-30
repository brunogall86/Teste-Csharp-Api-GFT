using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace Questao5.Infrastructure.Services.Controllers.ViewModel
{
    public class AddMovimentoViewModel
    {
        [Required]        
        public char TipoMovimento { get; set; }
        
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public Guid IdContaCorrente { get; set; }
        
    }
}