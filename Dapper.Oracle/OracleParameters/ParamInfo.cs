using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Dapper.Oracle.OracleParameters
{
    /// <summary>
    /// This is a class used for different data types in oracle
    /// </summary>
    public class ParamInfo
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public ParameterDirection ParameterDirection { get; set; }

        public OracleDbType? DbType { get; set; }

        public int? Size { get; set; }

        public IDbDataParameter AttachedParam { get; set; }
    }
}
