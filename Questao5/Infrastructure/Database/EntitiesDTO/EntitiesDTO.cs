using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;

namespace Questao5.Infrastructure.Database.EntitiesDTO
{
    internal class ContaCorrenteDTO
    {
        internal string idcontacorrente { get; set; }
        internal int numero { get; set; }
        internal string nome { get; set; }
        internal int ativo { get; set; }

        public static ContaCorrente ToContaCorrente(ContaCorrenteDTO contaCorrenteDTO)
        {
            if (contaCorrenteDTO is null) return null;
            
            return new ContaCorrente(Guid.Parse(contaCorrenteDTO.idcontacorrente), 
                                     contaCorrenteDTO.numero,
                                     contaCorrenteDTO.nome);
        }
    }
     internal class MovimentoDTO
    {
        internal string idmovimento { get; set; }
        internal string idcontacorrente {get;set;}
        internal string datamovimento { get; set; }
        internal char tipomovimento { get; set; }
        internal decimal valor { get; set; }

        public static Movimento ToMovimento(MovimentoDTO movimentoDTO)
        {
            if (movimentoDTO is null) return null;
            return new Movimento(Guid.Parse(movimentoDTO.idmovimento),
                                 ContaCorrenteDTO.ToContaCorrente(new ContaCorrenteDTO() { idcontacorrente = movimentoDTO.idcontacorrente }),
                                 (TipoMovimento)movimentoDTO.tipomovimento,
                                 movimentoDTO.valor,
                                 Convert.ToDateTime(movimentoDTO.datamovimento));
        }

    }
     internal class IdempotenciaDTO
    {
        internal string chave_idempotencia { get; set; }
        internal string requisicao { get; set; }
        internal string resultado { get; set; }

        public static Idempotencia ToIdempotencia(IdempotenciaDTO dto)
        {
            return new Idempotencia(Guid.Parse(dto.chave_idempotencia),
                                    dto.requisicao,
                                    dto.resultado);
        }
    }
}