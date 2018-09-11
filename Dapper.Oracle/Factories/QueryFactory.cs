using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using Dapper.Oracle.Interfaces.Factories;
using Dapper.Oracle.OracleParameters;
using Oracle.ManagedDataAccess.Client;

namespace Dapper.Oracle.Factories
{
    /// <summary>
    /// This factory opens a connection using IDisposable and either gets an object or IEnumerable
    /// </summary>
    public class QueryFactory : IQueryFactory
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MemSysConnectionString"].ConnectionString;

        /// <summary>
        /// This is used to call stored procedure and return an object of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"></param>
        /// <param name="oracleParamaters"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<T> QueryFirstOrDefaultAsync<T>(string commandName, OracleDynamicParameters oracleParamaters,
            IDbTransaction dbTransaction, int? commandTimeout, CommandType commandType)
        {
            using (var conn = GetConnection)
            {
                return conn.QueryFirstOrDefaultAsync<T>(commandName, oracleParamaters, dbTransaction, commandTimeout, commandType);
            }
        }

        /// <summary>
        /// This is used to call stored procedure and return IEnumerable of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"></param>
        /// <param name="oracleParamaters"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public Task<IEnumerable<T>> QueryAsync<T>(string commandName, OracleDynamicParameters oracleParamaters,
            IDbTransaction dbTransaction, int? commandTimeout, CommandType commandType)
        {
            using (var conn = GetConnection)
            {
                return conn.QueryAsync<T>(commandName, oracleParamaters, dbTransaction, commandTimeout, commandType);
            }

        }

        /// <summary>
        /// Get connection string from config and open connection
        /// </summary>
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
