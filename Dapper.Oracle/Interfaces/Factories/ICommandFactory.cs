using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Dapper.Oracle.Interfaces.Factories
{
    public interface ICommandFactory
    {
        Task DeleteAsync(string commandName, List<OracleParameter> oracleParamaters, IDbTransaction dbTransaction, int commandTimeout, CommandType commandType);
    }
}
