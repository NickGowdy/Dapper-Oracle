using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper.Oracle.Configurations;
using Dapper.Oracle.Entities;
using Dapper.Oracle.Interfaces.Factories;
using Dapper.Oracle.Interfaces.Repos;
using Dapper.Oracle.OracleParameters;
using Oracle.ManagedDataAccess.Client;

namespace Dapper.Oracle.Repos
{
    /// <summary>
    /// This repo is used to get foos
    /// </summary>
    public class FooRepo : IFooRepo
    {

        private readonly IQueryFactory _queryFactory;

        public FooRepo(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        /// <summary>
        /// Get foo by foo id
        /// </summary>
        /// <param name="fooId"></param>
        /// <returns></returns>
        public async Task<Foo> GetFoo(int fooId)
        {
            var param = new OracleDynamicParameters();
            param.Add("FOOID", fooId, OracleDbType.Int32, ParameterDirection.Input);
            param.Add("cursor_", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            var record = await _queryFactory.QueryFirstOrDefaultAsync<Foo>(UrlConfigurations.GetFoo, param, null, null,
                CommandType.StoredProcedure);
            return record;
        }

        /// <summary>
        /// Get IEnumerable of all foos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Foo>> GetFoos()
        {
            var param = new OracleDynamicParameters();
            param.Add("cursor_", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            var record = await _queryFactory.QueryAsync<Foo>(UrlConfigurations.GetFoos, param, null, null,
                CommandType.StoredProcedure);
            return record;
        }
    }
}
