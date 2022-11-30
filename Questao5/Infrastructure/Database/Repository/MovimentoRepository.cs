using System.Security.AccessControl;
using System;
using System.Net.NetworkInformation;
using System.Data.Common;
using System.Data;
using System.Reflection.Metadata;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Sqlite;
using Dapper;
using Questao5.Infrastructure.Database.EntitiesDTO;

namespace Questao5.Infrastructure.Database.Repository
{
    public class MovimentoRepository : RepositoryBase, IMovimentoRepository
    {
        public MovimentoRepository(DatabaseConfig databaseConfig) : base(databaseConfig) 
        {
        }

        public async Task<bool> Add(Movimento movimento)
        {
            using (Connection)
            {
                var sql = @"INSERT INTO movimento(idmovimento, idcontacorrente, datamovimento, tipomovimento, valor)
                            VALUES(@Id, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)";

                var result = await Connection.ExecuteAsync(sql, new {
                                            Id  = movimento.Id,
                                            IdContaCorrente = movimento.ContaCorrente.Id,
                                            DataMovimento = movimento.DataMovimento,
                                            TipoMovimento = (char)movimento.TipoMovimento, 
                                            Valor = movimento.Valor});

                return Convert.ToBoolean(result);
            }
        }

        public async Task<IEnumerable<Movimento>> GetAll(ContaCorrente conta)
        {
            using (Connection)
            {
                var sql = @"SELECT idmovimento, 
                                   idcontacorrente, 
                                   datamovimento, 
                                   tipomovimento, 
                                   valor
                            FROM movimento WHERE idcontacorrente = @Id";

                var result = await Connection.QueryAsync<MovimentoDTO>(sql, new { Id  = conta.Id });

                var migrate = from p in result select MovimentoDTO.ToMovimento(p);

                return migrate;
            }
        }
    }
}