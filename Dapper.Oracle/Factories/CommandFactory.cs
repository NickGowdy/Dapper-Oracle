using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using Dapper.Oracle.Interfaces.Factories;
using Oracle.ManagedDataAccess.Client;

namespace Dapper.Oracle.Factories
{
    public class CommandFactory : ICommandFactory
    {
        // Replace MyConnectionString with your connection string in web.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public async Task DeleteAsync(string commandName, List<OracleParameter> oracleParamaters,
            IDbTransaction dbTransaction, int commandTimeout, CommandType commandType)
        {
            using (var conn = GetConnection)
            {
                using (var cmd = conn.CreateCommand())
                {
                    //commandName, oracleParamaters, dbTransaction, commandTimeout, commandType
                    cmd.CommandText = commandName;
                    cmd.CommandType = commandType;
                    cmd.CommandTimeout = commandTimeout;

                    //string commandName, OracleDynamicParameters oracleParamaters,IDbTransaction dbTransaction, int commandTimeout, CommandType commandType
                    foreach (var parameter in oracleParamaters)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private IDbConnection GetConnection
        {
            get
            {
                var conn = new OracleConnection { ConnectionString = _connectionString };
                conn.Open();
                return conn;
            }
        }
    }
}
