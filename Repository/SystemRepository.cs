using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using Models = HelloWorld.Models;

namespace HelloWorld.Repository
{
    public class SystemRepository : IRepository<Models.System>
    {

        //http://techbrij.com/asp-net-core-postgresql-dapper-crud
        private string connectionString;
        public SystemRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        void IRepository<Models.System>.Add(Models.System item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO \"tblSystem\" (\"ID\",\"Description\") VALUES(@Id,@description)", item);
            }
        }

        System.Collections.Generic.IEnumerable<Models.System> IRepository<Models.System>.FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Models.System>("SELECT * FROM \"tblSystem\"");
            }
        }

        Models.System IRepository<Models.System>.FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Models.System>("SELECT * FROM \"tblSystem\" WHERE \"id\" = @Id", new { Id = @id }).FirstOrDefault();
            }
        }

        void IRepository<Models.System>.Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM \"tblSystem\" WHERE \"ID\"=@Id", new { Id = id });
            }
        }

        void IRepository<Models.System>.Update(Models.System item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE \"tblSystem\" SET \"Description\" = @description WHERE \"ID\" = @Id", item);
            }
        }
    }
}