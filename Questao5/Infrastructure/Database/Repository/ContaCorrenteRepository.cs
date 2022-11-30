using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.EntitiesDTO;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    public class ContaCorrenteRepository : RepositoryBase, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(DatabaseConfig databaseConfig) : base(databaseConfig)
        {
        }

        public async Task<ContaCorrente> GetById(Guid id)
        {
            var sql = @"SELECT * from ContaCorrente where idcontacorrente = @Id";
            
            var result = await Connection.QueryFirstOrDefaultAsync<ContaCorrenteDTO>(sql, new {Id = id});
            
            return ContaCorrenteDTO.ToContaCorrente(result);

        }
    }
}