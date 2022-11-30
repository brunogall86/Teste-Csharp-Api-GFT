using System.Configuration.Assemblies;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    public abstract class RepositoryBase: IRepository<BaseEntity>, IDisposable 
    {
        protected DatabaseConfig databaseConfig { get; private set; }
        protected SqliteConnection Connection {get;set;}
        protected RepositoryBase(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
            Connection = new SqliteConnection(this.databaseConfig.Name);
        }
        
        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}