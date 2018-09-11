using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper.Oracle.OracleParameters;

namespace Dapper.Oracle.Interfaces.Factories
{
    public interface IQueryFactory
    {
        Task<T> QueryFirstOrDefaultAsync<T>(string commandName, OracleDynamicParameters oracleParamaters,
            IDbTransaction dbTransaction, int? commandTimeout, CommandType commandType);

        Task<IEnumerable<T>> QueryAsync<T>(string commandName, OracleDynamicParameters oracleParamaters,
            IDbTransaction dbTransaction, int? commandTimeout, CommandType commandType);
    }
}
