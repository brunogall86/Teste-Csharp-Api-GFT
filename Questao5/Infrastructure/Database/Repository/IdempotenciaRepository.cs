using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    public class IdempotenciaRepository : RepositoryBase, IIdempotenciaRepository
    {
        public IdempotenciaRepository(DatabaseConfig databaseConfig) : base(databaseConfig)
        {
        }

        public async Task<bool> Add(Idempotencia entity)
        {
            using (Connection)
            {
                var sql = @"INSERT INTO idempotencia(chave_idempotencia, requisicao, resultado)
                                   VALUES(@chave, @requisicao, @resultado)";

                var result = await Connection.ExecuteAsync(sql, new 
                {
                    chave = entity.Id,
                    requisicao = entity.Requisicao,
                    resultado = entity.Resultado
                });

                return Convert.ToBoolean(result);
            }
        }
    }
}